using Sloths.Services;
using Sloths.ViewModel;

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