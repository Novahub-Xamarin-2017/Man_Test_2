using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;
using Com.Lilarcor.Cheeseknife;
using Presentation.Interfaces;
using Presentation.Models;

namespace Presentation.Adapters
{
    public class StoryViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
    {
        [InjectView(Resource.Id.imgStory)] private ImageView imgStory;

        public IStoryClickListener StoryClickListener { get; set; }

        public Story Story
        {
            set => Glide.With(ItemView.Context).Load(value.ImageUrl).Into(imgStory);
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