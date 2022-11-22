using FirstApp.Repository;
using FirstApp.Service;
using FirstApp.View;
using FirstApp.ViewModel;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace FirstApp;

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
        AppCenter.Start("android=378e316d-7355-4725-92d3-930500cd2a49;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here};" +
                  "macos={Your macOS App secret here};",
                  typeof(Analytics), typeof(Crashes));
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IMap>(Map.Default);

        builder.Services.AddSingleton<AddEmployeePageViewModel>();
        builder.Services.AddSingleton<ShowEmployeePageViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<AddEmployeePage>();
        builder.Services.AddTransient<ShowEmployeePage>();
        builder.Services.AddTransient<PersonRepository>();
        builder.Services.AddTransient<EmployeeService>();
      //  builder.Services.AddTransient<IEmployeeService>();

        return builder.Build();
	}
}
