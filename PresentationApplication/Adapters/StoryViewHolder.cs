using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Media;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using PresentationApplication.Interfaces;

namespace PresentationApplication.Adapters
{
    public class StoryViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
    {
        [InjectView(Resource.Id.imgStory)] private ImageView imgStory;

        public IStoryClickListener StoryClickListener { get; set; }

        public string ImageName
        {
            set
            {
                //var imageId = (int) typeof(Resource.Drawable).GetField(value).GetValue(null);
                var imageId = ItemView.Context.Resources.GetIdentifier(value, "drawable", ItemView.Context.PackageName);
                imgStory.SetImageResource(imageId);
            }
        }

        public StoryViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
            itemView.SetOnClickListener(this);
        }

        public void OnClick(View v)
        {
            StoryClickListener.OnClick(v, AdapterPosition);
        }
    }
}