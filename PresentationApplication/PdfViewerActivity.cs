using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Com.Joanzapata.Pdfview;

namespace PresentationApplication
{
    [Activity(Label = "PdfViewerActivity", ScreenOrientation = ScreenOrientation.Landscape)]
    public class PdfViewerActivity : Activity
    {
        [InjectView(Resource.Id.pDFView)] private PDFView pdfView;

        [InjectView(Resource.Id.txtFileName)] private TextView txtFileName;

        [InjectOnClick(Resource.Id.btnBack)]
        private void Back(object sender, EventArgs e)
        {
            Finish();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.pdf_viewer);
            Cheeseknife.Inject(this);
            ShowPdf();
        }

        private void ShowPdf()
        {
            var fileName = Intent.GetStringExtra("fileName");
            txtFileName.Text = fileName;
            pdfView.FromAsset($"{fileName}.pdf").Load();
        }
    }
}