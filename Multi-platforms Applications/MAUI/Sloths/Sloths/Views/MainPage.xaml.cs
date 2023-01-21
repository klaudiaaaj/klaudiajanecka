using Sloths.Services;
using Sloths.ViewModel;
using Sloths.Views;

namespace Sloths;

public partial class MainPage : ContentPage
{
	private readonly ISlothService slothService;

    public MainPage(SlothsViewModel viewModel)
    {
		BindingContext=viewModel;
        InitializeComponent();
    }
}