using Foundation;
using UIKit;

namespace MauiTestApp
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        HTTPServer? _httpServer;
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        void StartServer()
        {
            if (_httpServer == null) return;
            NSError error;
            bool started = _httpServer.Start(out error);
            if (!started && error != null)
            {
                Console.WriteLine($"Error starting HTTP server: {error.LocalizedDescription}");
            }
            else
            {
                Console.WriteLine("HTTP server started successfully.");
            }

        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            _httpServer = new HTTPServer();
            _httpServer.Type = @"_http._tcp.";
            string webPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Web");
            _httpServer.DocumentRoot = webPath;

            StartServer();
            return base.FinishedLaunching(application, launchOptions);
        }

        public override void WillEnterForeground(UIApplication application)
        {
            base.WillEnterForeground(application);
            StartServer();
        }

        public override void DidEnterBackground(UIApplication application)
        {
            base.DidEnterBackground(application);
            _httpServer?.Stop();
        }
    }

}
