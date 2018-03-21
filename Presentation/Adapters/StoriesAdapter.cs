using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Presentation.Activities;
using Presentation.Interfaces;
using Presentation.Models;

namespace Presentation.Adapters
{
    class StoriesAdapter : RecyclerView.Adapter, IStoryClickListener
    {
        private readonly List<Story> stories;

        public StoriesAdapter(List<Story> stories)
        {
            this.stories = stories;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (!(holder is StoryViewHolder viewholder)) return;
            viewholder.Story = stories[position];
            viewholder.StoryClickListener = this;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.StoryItem, parent, false);
            return new StoryViewHolder(itemView);
        }

        public override int ItemCount => stories.Count;

        public void OnClick(View itemView, int position)
        {
            if (stories[position].DocumentUrl.EndsWith(".pdf"))
            {
                var intent = new Intent(itemView.Context, typeof(DisplayPdfActivity));
                intent.PutExtra("documentName", stories[position].DocumentName);
                intent.PutExtra("documentUrl", stories[position].DocumentUrl);
                itemView.Context.StartActivity(intent);
            }
            else if (stories[position].DocumentUrl.EndsWith(".mp4"))
            {
                var intent = new Intent(itemView.Context, typeof(PlayVideoActivity));
                intent.PutExtra("documentUrl", stories[position].DocumentUrl);
                itemView.Context.StartActivity(intent);
            }
        }
    }
}