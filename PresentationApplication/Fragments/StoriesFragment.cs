using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using PresentationApplication.Adapters;
using PresentationApplication.Models;

namespace PresentationApplication.Fragments
{
    public class StoriesFragment : Fragment
    {
        [InjectView(Resource.Id.rvStories)] private RecyclerView rvStories;

        private List<Story> stories;

        private StoriesAdapter adapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view = inflater.Inflate(Resource.Layout.StoriesFragment, container, false);
            
            Cheeseknife.Inject(this, view);
            Init();
            return view;
        }

        private void Init()
        {
            rvStories.SetLayoutManager(new GridLayoutManager(Context, 1, GridLayoutManager.Horizontal, false));
            stories = new List<Story>
            {
                new Story
                {
                    ImageName = "genolier",
                    DescriptionFileName = ""
                },
                new Story
                {
                    ImageName = "genolier",
                    DescriptionFileName = "first.pdf"
                },
                new Story
                {
                    ImageName = "genolier",
                    DescriptionFileName = "OneMinuteOpenWT.mp4"
                },
                new Story
                {
                    ImageName = "genolier",
                    DescriptionFileName = ""
                },
                new Story
                {
                    ImageName = "genolier",
                    DescriptionFileName = ""
                },
                new Story
                {
                    ImageName = "genolier",
                    DescriptionFileName = ""
                }
            };
            adapter = new StoriesAdapter(stories);
            rvStories.SetAdapter(adapter);
        }
    }
}