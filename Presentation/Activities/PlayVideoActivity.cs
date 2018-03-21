using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;

namespace Presentation.Activities
{
    [Activity(Label = "PlayVideoActivity", LaunchMode = LaunchMode.SingleInstance, ScreenOrientation = ScreenOrientation.Landscape)]
    public class PlayVideoActivity : Activity
    {
        [InjectView(Resource.Id.videoView)] private VideoView videoView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VideoViewer);
            Cheeseknife.Inject(this);
            Init();
        }

        private void Init()
        {
            var documentUrl = Intent.GetStringExtra("documentUrl");
            videoView.SetVideoPath(documentUrl);
            videoView.SetMediaController(new MediaController(this));
            videoView.SetZOrderOnTop(true);
            videoView.Start();
        }

        public override void OnBackPressed()
        {
            Finish();
        }
    }
}