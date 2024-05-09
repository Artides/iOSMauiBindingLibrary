using Foundation;
using UIKit;
using CocoaHTTPServerBinding;

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
    }

}
