using Android.App;
using Android.OS;
using Android.Webkit;

namespace PresentationApplication
{
    [Activity(Label = "DisplayPdfActivity", MainLauncher = true)]
    public class DisplayPdfActivity : Activity
    {
        [InjectView(Resource.Id.pdfWebView)] private WebView pdfWebView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PdfView);
            Cheeseknife.Inject(this);
            // Create your application here
            pdfWebView.Settings.JavaScriptEnabled = true;
            pdfWebView.LoadUrl("https://www.dl.dropboxusercontent.com/s/pmr6drt7mqui3id/People%20Behind.pdf");
        }
    }
}