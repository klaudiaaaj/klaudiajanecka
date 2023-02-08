using Sloths.Views;

namespace Sloths;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(SlothsDetailsPage), typeof(SlothsDetailsPage));
	}
}
