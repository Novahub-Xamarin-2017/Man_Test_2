using Android.App;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace PresentationApplication
{
    [Activity(Label = "VideoViewerActivity")]
    public class VideoViewerActivity : Activity, MediaPlayer.IOnPreparedListener, ISurfaceHolderCallback
    {
        [InjectView(Resource.Id.videoView)] private VideoView videoView;

        private MediaPlayer mediaPlayer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.video_viewer);
            Cheeseknife.Inject(this);

            var holder = videoView.Holder;
#pragma warning disable 618
            holder?.SetType(SurfaceType.PushBuffers);
#pragma warning restore 618
            holder?.AddCallback(this);
            var descriptor = Assets.OpenFd(Intent.GetStringExtra("fileName"));
            mediaPlayer = new MediaPlayer();
            mediaPlayer.SetDataSource(descriptor.FileDescriptor, descriptor.StartOffset, descriptor.Length);
            mediaPlayer.Prepare();
            mediaPlayer.Looping = true;
            mediaPlayer.Start();
        }

        public void OnPrepared(MediaPlayer mp)
        {
        }

        public void SurfaceChanged(ISurfaceHolder holder, Format format, int width, int height)
        {
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            mediaPlayer.SetDisplay(holder);
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            mediaPlayer.Stop();
        }
    }
}