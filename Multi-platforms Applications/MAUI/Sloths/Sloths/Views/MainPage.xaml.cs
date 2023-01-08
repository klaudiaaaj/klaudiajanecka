using Sloths.Services;

namespace Sloths;

public partial class MainPage : ContentPage
{
	private readonly ISlothService slothService;

    public MainPage(ISlothService slothService)
    {
        this.slothService = slothService;
        InitializeComponent();
    }

    int count = 0;

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		GetSlothsList();


        if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private async void GetSlothsList()
	{
		var result= await slothService.GetAllSloths();
	}
}

