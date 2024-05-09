namespace MauiTestApp.Services;

internal class HttpServerServiceNoImplementation : IHttpServerService
{
    public string GetUrl()
    {
        return string.Empty;
    }

    public void SetwwwRoot(string path)
    {
       
    }

    public bool Start(out Exception error)
    {
        error = new Exception("No implementation");
        return false;
    }

    public void Stop()
    {
        
    }
}
