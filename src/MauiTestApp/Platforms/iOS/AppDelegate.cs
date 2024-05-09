using Foundation;
using UIKit;

namespace MauiTestApp
{

    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        /*
        HTTPServer? _httpServer;

        void StartServer()
        {
            if (_httpServer == null) return;
            NSError error;
            bool started = _httpServer.Start(out error);
            if (!started)
            {
                Console.WriteLine($"Error starting HTTP server: {(error != null ?error.LocalizedDescription : "No error Description")}");
            }
            else
            {
                Console.WriteLine($"Started HTTp Server on port {_httpServer.ListeningPort()}");
            }

        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            _httpServer = new HTTPServer();
            _httpServer.SetType(@"_http._tcp.");
            string webPath = Path.Combine(FileSystem.AppDataDirectory, "Web");
            if (!Directory.Exists(webPath)) Directory.CreateDirectory(webPath);
            File.WriteAllText(Path.Combine(webPath, "index.html"), @"
<html>
<head>
<title>iPhone HTTP Server Example</title>
</head>
<body bgcolor=""#FFFFFF"">
<h1>Welcome to CocoaHTTPServer!</h1>

You can customize this page for your app, make other pages, or even serve up dynamic content.<br/>

<a href=""https://github.com/robbiehanson/CocoaHTTPServer"">CocoaHTTPServer Project Page</a><br/>

</body>
</html>
");

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
    */
    }

}
