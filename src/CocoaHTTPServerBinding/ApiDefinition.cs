using ObjCRuntime;
using Foundation;

namespace CocoaHTTPServerBinding;

[BaseType(typeof(NSObject))]
[Protocol, Model]
interface HTTPServer : INSNetServiceDelegate
{

    [Export("documentRoot")]
    string DocumentRoot { get; set; }

    [Export("connectionClass")]
    Class ConnectionClass();

    [Export("setConnectionClass:")]
    void SetConnectionClass(Class value);

    [Export("interface")]
    string Interface();

    [Export("setInterface:")]
    void SetInterface(string value);

    [Export("port")]
    ushort Port();

    [Export("listeningPort")]
    ushort ListeningPort();

    [Export("setPort:")]
    void SetPort(ushort value);

    [Export("domain")]
    string Domain();

    [Export("setDomain:")]
    void SetDomain(string value);

    [Export("name")]
    string Name();

    [Export("publishedName")]
    string PublishedName();

    [Export("setName:")]
    void SetName(string value);

    [Export("type")]
    string Type();

    [Export("setType:")]
    void SetType(string value);

    [Export("republishBonjour")]
    void RepublishBonjour();

    [Export("TXTRecordDictionary")]
    NSDictionary TXTRecordDictionary();

    [Export("setTXTRecordDictionary:")]
    void SetTXTRecordDictionary(NSDictionary dict);

    [Export("start:")]
    bool Start(out NSError errPtr);

    [Export("stop")]
    void Stop();

    [Export("stop:")]
    void Stop(bool keepExistingConnections);

    [Export("isRunning")]
    bool IsRunning();

    [Export("numberOfHTTPConnections")]
    nuint NumberOfHTTPConnections();

    [Export("numberOfWebSocketConnections")]
    nuint NumberOfWebSocketConnections();
}