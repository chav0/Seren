using Seren.Scripts.Views.Pages;

namespace Seren;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("practices/meditations", typeof(MeditationListPage));
		NavigationPage.SetHasNavigationBar(this, false);
	}
}

