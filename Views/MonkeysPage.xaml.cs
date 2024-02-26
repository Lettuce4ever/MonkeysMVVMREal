using MonkeysMVVM.ViewModels;

namespace MonkeysMVVM.Views;

public partial class MonkeysPage : ContentPage
{
	public MonkeysPage(MonkeyPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}