using Microsoft.Extensions.Logging;
using MonkeysMVVM.Services;
using MonkeysMVVM.ViewModels;
using MonkeysMVVM.Views;

namespace MonkeysMVVM;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<MonkeysService>();

		//add ViewModels
		builder.Services.AddTransient<FindMonkeyByLocationPageViewModel>();
        builder.Services.AddTransient<MonkeyPageViewModel>();
        builder.Services.AddTransient<ShowMonkeyViewModel>();

        //add Views
        builder.Services.AddTransient<FindMonkeyByLocationPage>();
        builder.Services.AddTransient<MonkeysPage>();
        builder.Services.AddTransient<ShowMonkeyView>();



#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
