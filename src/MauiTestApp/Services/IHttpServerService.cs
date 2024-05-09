namespace MauiTestApp.Services
{
    public interface IHttpServerService
    {
        void SetwwwRoot(string path);
        bool Start(out Exception? error);
        void Stop();
        string GetUrl();
    }
}
