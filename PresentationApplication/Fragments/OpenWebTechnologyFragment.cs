using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;

namespace PresentationApplication.Fragments
{
    public class OpenWebTechnologyFragment : Fragment
    {
        [InjectOnClick(Resource.Id.btnDiscover)]
        private void ShowVideo(object sender, EventArgs e)
        {
            var intent = new Intent(Context, typeof(VideoViewerActivity));
            intent.PutExtra("fileName", "OneMinuteOpenWT.mp4");
            StartActivity(intent);
        }

        [InjectOnClick(Resource.Id.btnPeople)]
        private void ShowPeopleInfo(object sender, EventArgs e)
        {
            ShowPdfByName("People Behind");
        }

        [InjectOnClick(Resource.Id.btnNumber)]
        private void ShowNumbers(object sender, EventArgs e)
        {
            ShowPdfByName("In the Numbers");
        }

        [InjectOnClick(Resource.Id.btnService)]
        private void ShowServices(object sender, EventArgs e)
        {
            ShowPdfByName("Service Offering");
        }

        [InjectOnClick(Resource.Id.btnVenture)]
        private void ShowVenture(object sender, EventArgs e)
        {
            ShowPdfByName("Joint Venture");
        }

        private void ShowPdfByName(string fileName)
        {
            var intent = new Intent(Context, typeof(PdfViewerActivity));
            intent.PutExtra("fileName", fileName);
            StartActivity(intent);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.OpenWebTechnologyFragment, container, false);
            Cheeseknife.Inject(this, view);
            return view;
        }
    }
}