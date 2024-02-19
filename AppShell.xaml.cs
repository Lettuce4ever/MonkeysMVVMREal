using MonkeysMVVM.ViewModels;
using MonkeysMVVM.Views;

namespace MonkeysMVVM;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("ShowMonkey", typeof(ShowMonkeyView));
        Routing.RegisterRoute("(MonkeyPage", typeof(MonkeysPage));
        Routing.RegisterRoute("FindMonkeyByLocation", typeof(FindMonkeyByLocationPage));
    }
}
