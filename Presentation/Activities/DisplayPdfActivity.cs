using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Webkit;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;

namespace Presentation.Activities
{
    [Activity(Label = "DisplayPdfActivity", ScreenOrientation = ScreenOrientation.Landscape)]
    public class DisplayPdfActivity : Activity
    {
        [InjectView(Resource.Id.pdfWebView)] private WebView pdfWebView;

        [InjectView(Resource.Id.tvPdfName)] private TextView tvPdfName;

        [InjectOnClick(Resource.Id.btnBack)]
        private void Back(object sender, EventArgs e)
        {
            Finish();
        }

        private const string GoogleViewUrl = "https://drive.google.com/viewerng/viewer?url=";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PdfViewer);
            Cheeseknife.Inject(this);
            Init();
        }

        private void Init()
        {
            pdfWebView.Settings.JavaScriptEnabled = true;
            var documentUrl = Intent.GetStringExtra("documentUrl");
            var documentName = Intent.GetStringExtra("documentName");
            pdfWebView.LoadUrl($"{GoogleViewUrl}{documentUrl}");
            tvPdfName.Text = documentName;
        }
    }
}