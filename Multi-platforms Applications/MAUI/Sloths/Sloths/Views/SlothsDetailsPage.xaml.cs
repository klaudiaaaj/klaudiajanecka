using Sloths.ViewModel;

namespace Sloths.Views;

public partial class SlothsDetailsPage : ContentPage
{
	public SlothsDetailsPage(SlothsDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        SlothsDetailsViewModel viewModel = (SlothsDetailsViewModel)BindingContext;
    }

}