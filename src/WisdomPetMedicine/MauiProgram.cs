using WisdomPetMedicine.DataAccess;
using WisdomPetMedicine.Services;
using WisdomPetMedicine.ViewModels;
using WisdomPetMedicine.Views;

namespace WisdomPetMedicine;

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

        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddTransient<ProductsViewModel>();

        var dbContext = new WpmDbContext();
        dbContext.Database.EnsureCreated();
        dbContext.Dispose();

        //Routing.RegisterRoute(nameof(ProductsPage), typeof(ProductsPage));


        return builder.Build();
    }
}