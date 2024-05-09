using MauiTestApp.Services;

namespace MauiTestApp
{
    public partial class MainPage : ContentPage
    {
        private readonly IHttpServerService? httpServerService;
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            httpServerService = MauiProgram.GetService<IHttpServerService>();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            string wwwRoot = Path.Combine(FileSystem.Current.AppDataDirectory, "wwwRoot");
            if (!Directory.Exists(wwwRoot)) Directory.CreateDirectory(wwwRoot);
            var indexPath = Path.Combine(wwwRoot, "index.html");
            File.WriteAllText(indexPath, @"
<!DOCTYPE html>
<html>
<body>

    <h1>My First Heading</h1>
    <p>My first paragraph.</p>

</body>
</html>
");

            httpServerService?.SetwwwRoot(wwwRoot);
            if (httpServerService?.Start(out Exception? error) == true)
            {
                var url = httpServerService.GetUrl();
                webView.Source = new UrlWebViewSource() { Url = url };
            }
            else
            {
                webView.Source = new UrlWebViewSource() { Url = indexPath };

            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            httpServerService?.Stop();
        }
    }

}
