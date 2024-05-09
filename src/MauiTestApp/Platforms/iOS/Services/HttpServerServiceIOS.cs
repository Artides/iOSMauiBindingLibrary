using MauiTestApp.Services;
using CocoaHTTPServerBinding;
using Foundation;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace MauiTestApp.Platforms.iOS.Services
{
    public class HttpServerServiceIOS : IHttpServerService
    {
        HTTPServer? _httpServer;

        public HttpServerServiceIOS()
        {
            _httpServer = new HTTPServer();
            _httpServer.SetType(@"_http._tcp.");
        }
        private string GetIPAddress()
        {
            string ipAddress = "";

            foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                    netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (var addrInfo in netInterface.GetIPProperties().UnicastAddresses)
                    {
                        if (addrInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipAddress = addrInfo.Address.ToString();
                        }
                    }
                }
            }

            return ipAddress;

        }
        public string GetUrl()
        {
            return $"http://{GetIPAddress()}:{_httpServer.ListeningPort()}";
        }

        public void SetwwwRoot(string path)
        {
            _httpServer.DocumentRoot = path;
        }

        public bool Start(out Exception? error)
        {
            if (_httpServer == null)
            {
                error = new Exception("Server not started");
                return false;
            }

            NSError iOSError;
            bool started = _httpServer.Start(out iOSError);
            if (!started)
            {
                var message = $"Error starting HTTP server: {(iOSError != null ? iOSError.LocalizedDescription : "No error Description")}";
                Console.WriteLine(message);
                error = new Exception(message);
                return false;
            }
            else
            {
                Console.WriteLine($"Started HTTp Server on port {_httpServer.ListeningPort()}");
            }
            error = null;
            return true;
        }

        public void Stop()
        {
            _httpServer?.Stop();
        }
    }
}
