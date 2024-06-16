using Seren.Scripts.Views.Pages;

namespace Seren;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
	}
}

