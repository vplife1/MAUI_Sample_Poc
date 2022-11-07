using FirstApp.Repository;
using FirstApp.Service;
using FirstApp.View;
using FirstApp.ViewModel;

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
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IMap>(Map.Default);

        builder.Services.AddSingleton<AddEmployeePageViewModel>();
        builder.Services.AddSingleton<ShowEmployeePageViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<AddEmployeePage>();
        builder.Services.AddTransient<ShowEmployeePage>();
        builder.Services.AddTransient<PersonRepository>();
        builder.Services.AddTransient<EmployeeService>();
        builder.Services.AddTransient<IEmployeeService>();

        return builder.Build();
	}
}
