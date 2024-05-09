using ObjCRuntime;
using Foundation;

namespace CocoaHTTPServerBinding;

[BaseType(typeof(NSObject))]
[Protocol, Model]
interface HTTPServer : INSNetServiceDelegate
{
    // Properties
    [Export("documentRoot")]
    string DocumentRoot { get; set; }

    [Export("connectionClass")]
    Class ConnectionClass { get; set; }

    [Export("interface")]
    string Interface { get; set; }

    [Export("port")]
    ushort Port { get; set; }

    [Export("domain")]
    string Domain { get; set; }

    [Export("type")]
    string Type { get; set; }

    [Export("name")]
    string Name { get; set; }

    [Export("publishedName")]
    string PublishedName { get; }

    [Export("TXTRecordDictionary")]
    NSDictionary TXTRecordDictionary { get; set; }

    [Export("isRunning")]
    bool IsRunning { get; }

    // Methods
    [Export("start:")]
    bool Start(out NSError err);

    [Export("stop")]
    void Stop();

    [Export("stop:")]
    void Stop(bool keepExistingConnections);

    [Export("republishBonjour")]
    void RepublishBonjour();

    [Export("numberOfHTTPConnections")]
    uint NumberOfHTTPConnections { get; }

    [Export("numberOfWebSocketConnections")]
    uint NumberOfWebSocketConnections { get; }

}