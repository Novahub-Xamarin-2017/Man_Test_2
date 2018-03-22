﻿using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Com.Lilarcor.Cheeseknife;
using Presentation.Adapters;
using Presentation.Models;
using Presentation.Services;

namespace Presentation.Fragments
{
    public class StoryFragment : Fragment
    {
        [InjectView(Resource.Id.rvStories)] private RecyclerView rvStories;

        private List<Story> stories;

        private StoriesAdapter adapter;

        private readonly SwaggerServices services = new SwaggerServices();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Story, container, false);
            Cheeseknife.Inject(this, view);
            GetData();
            Init(view);
            return view;
        }

        private void GetData()
        {
            stories = services.GetStories();
        }

        private void Init(View view)
        {
            rvStories.SetLayoutManager(new LinearLayoutManager(view.Context, LinearLayoutManager.Horizontal, false));
            adapter = new StoriesAdapter(stories);
            rvStories.SetAdapter(adapter);
        }
    }
}