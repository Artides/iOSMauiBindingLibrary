using MauiTestApp.Services;
using Microsoft.Extensions.Logging;

namespace MauiTestApp
{
    public static class MauiProgram
    {
        static MauiApp? App;

        public static T? GetService<T>()
        {
            if (App == null) throw new ArgumentNullException(nameof(MauiApp));
            return App.Services.CreateScope().ServiceProvider.GetService<T>();
        }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
#if IOS
                .Services.AddSingleton<IHttpServerService,Platforms.iOS.Services.HttpServerServiceIOS>()
#else
                .Services.AddSingleton<IHttpServerService,HttpServerServiceNoImplementation>()
#endif
                ;

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            App = builder.Build();
            return App;
        }
    }
}
