using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonkeyFinder.ViewModel;
using Sloths.Models;
using System.Diagnostics;

namespace Sloths.ViewModel
{
    [QueryProperty(nameof(Sloth), "Sloth")]
    public partial class SlothsDetailsViewModel : BaseViewModel
    {
        // private readonly IMap map;

        [ObservableProperty]
        Sloth sloth;
        IMap map;
        public SlothsDetailsViewModel(IMap map)
        {
            this.map = map;
        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var dept = query["Sloth"] as Sloth;
            sloth = dept;
            OnPropertyChanged();

        }

        [RelayCommand]
        async Task OpenMap()
        {
            try
            {
                await map.OpenAsync((double)Sloth.Latitude, (double)Sloth.Longitude, new MapLaunchOptions
                {
                    Name = Sloth.Name,
                    NavigationMode = NavigationMode.None
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to launch maps: {ex.Message}");
                await Shell.Current.DisplayAlert("Error, there is no app to open map!", ex.Message, "OK");
            }
        }

    }
}
