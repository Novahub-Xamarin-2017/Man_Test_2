using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using PresentationApplication.Interfaces;
using PresentationApplication.Models;

namespace PresentationApplication.Adapters
{
    public class StoriesAdapter : RecyclerView.Adapter, IStoryClickListener
    {
        private readonly List<Story> stories;

        public StoriesAdapter(List<Story> stories)
        {
            this.stories = stories;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is StoryViewHolder viewHolder)
            {
                viewHolder.ImageName = stories[position].ImageName;
                viewHolder.StoryClickListener = this;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.story_item, parent, false);
            return new StoryViewHolder(itemView);
        }

        public override int ItemCount => stories.Count;

        public void OnClick(View itemView, int position)
        {
            if (stories[position].DescriptionFileName.EndsWith(".pdf"))
            {
                var intent = new Intent(itemView.Context, typeof(PdfViewerActivity));
                intent.PutExtra("fileName", stories[position].DescriptionFileName.Remove(stories[position].DescriptionFileName.LastIndexOf('.')));
                itemView.Context.StartActivity(intent);
            }
            else if (stories[position].DescriptionFileName.EndsWith(".mp4"))
            {
                var intent = new Intent(itemView.Context, typeof(VideoViewerActivity));
                intent.PutExtra("fileName", stories[position].DescriptionFileName);
                itemView.Context.StartActivity(intent);
            }
        }
    }
}