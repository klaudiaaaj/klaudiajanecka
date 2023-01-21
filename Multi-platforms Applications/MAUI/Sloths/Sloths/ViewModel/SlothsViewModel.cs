using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Networking;
using MonkeyFinder.ViewModel;
using Sloths.Models;
using Sloths.Services;
using Sloths.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Sloths.ViewModel
{
    public partial class SlothsViewModel : BaseViewModel
    {
        public ObservableCollection<Sloth> Sloths { get; } = new();
        private readonly ISlothService slothService;
        IConnectivity connectivity;
        IGeolocation geolocation;

        public SlothsViewModel(ISlothService slothService, IConnectivity connectivity, IGeolocation geolocation)
        {
            Title = "Sloths from the Earth";
            this.slothService = slothService;
            this.connectivity = connectivity;
            this.geolocation = geolocation;
        }

        [RelayCommand]
        async Task GoToDetails(Sloth sloth)
        {
            if (sloth == null)
                return;

            await Shell.Current.GoToAsync(nameof(SlothsDetailsPage), true, new Dictionary<string, object>
        {
            {"Sloth", sloth }
        });
        }

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GetSlothsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }

                IsBusy = true;
                var slothsList = await slothService.GetAllSloths();

                if (Sloths.Count != 0)
                    Sloths.Clear();

                foreach (var sloth in slothsList)
                    Sloths.Add(sloth);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get sloths: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }

        }

        [RelayCommand]
        async Task GetTheClosestSloth()
        {
            if (IsBusy && Sloths.Count == 0)
                return;

            try
            {
                var location = await geolocation.GetLastKnownLocationAsync();
                if (location == null)
                    location = await geolocation.GetLocationAsync(
                        new GeolocationRequest
                        {
                            DesiredAccuracy = GeolocationAccuracy.Low,
                            Timeout = TimeSpan.FromSeconds(30),
                        });

                var theClosest = Sloths.OrderBy(s =>
                location.CalculateDistance(s.Latitude, s.Longitude, DistanceUnits.Miles)).FirstOrDefault();

                if (theClosest is null) return;

                await Shell.Current.DisplayAlert("The closest Sloth to you is: ", $"{theClosest.Name} in " +
                    $"{theClosest.Localization}", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get the closest sloth! {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }
    }
}