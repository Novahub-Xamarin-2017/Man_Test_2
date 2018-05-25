using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Presentation.Activities;
using Presentation.Interfaces;
using Presentation.Models;

namespace Presentation.Adapters
{
    public class StoriesAdapter : RecyclerView.Adapter, IStoryClickListener
    {
        private readonly List<string> videoExtensions = new List<string> { ".mp3", ".mp4", ".avi" };

        private readonly List<Story> stories;

        public StoriesAdapter(List<Story> stories)
        {
            this.stories = stories;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is StoryViewHolder viewholder)
            {
                viewholder.Story = stories[position];
                viewholder.StoryClickListener = this;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.StoryItem, parent, false);
            return new StoryViewHolder(itemView);
        }

        public override int ItemCount => stories.Count;

        public void OnClick(View itemView, int position)
        {
            if (stories[position].DocumentUrl.ToLower().EndsWith(".pdf"))
            {
                var intent = new Intent(itemView.Context, typeof(DisplayPdfActivity));
                intent.PutExtra("documentName", stories[position].DocumentName);
                intent.PutExtra("documentUrl", stories[position].DocumentUrl);
                itemView.Context.StartActivity(intent);
            }
            else if (videoExtensions.Any(x => stories[position].DocumentUrl.ToLower().EndsWith(x)))
            {
                var intent = new Intent(itemView.Context, typeof(PlayVideoActivity));
                intent.PutExtra("documentUrl", stories[position].DocumentUrl);
                itemView.Context.StartActivity(intent);
            }
        }
    }
}