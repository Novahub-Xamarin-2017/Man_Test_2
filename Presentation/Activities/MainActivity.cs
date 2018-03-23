using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Com.Lilarcor.Cheeseknife;
using Presentation.Fragments;

namespace Presentation.Activities
{
    [Activity(Label = "Presentation", MainLauncher = true, ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : Activity
    {
        private OwtFragment owtFragment = new OwtFragment();

        private StoryFragment storyFragment = new StoryFragment();

        private ContactFragment contactFragment = new ContactFragment();

        [InjectView(Resource.Id.bottom_navigation)] private BottomNavigationView bottomNavigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            bottomNavigationView.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
            LoadFragment(Resource.Id.menu_owt);
        }

        private void LoadFragment(int id)
        {
            switch (id)
            {
                case Resource.Id.menu_owt:
                    DisplayFragment(owtFragment);
                    break;
                case Resource.Id.menu_story:
                    DisplayFragment(storyFragment);
                    break;
                case Resource.Id.menu_contact:
                    DisplayFragment(contactFragment);
                    break;
            }
        }

        private void DisplayFragment(Fragment fragment)
        {
            FragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }
    }
}

