using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using PresentationApplication.Fragments;

namespace PresentationApplication
{
    [Activity(Label = "PresentationApplication", MainLauncher = true)]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.bottom_navigation)] private BottomNavigationView bottomNavigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);


            bottomNavigationView.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
            LoadFragment(Resource.Id.menu_home);
        }

        private void LoadFragment(int id)
        {
            Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.menu_home:
                    fragment = new OpenWebTechnologyFragment();
                    break;
                case Resource.Id.menu_audio:
                    fragment = new StoriesFragment();
                    break;
                case Resource.Id.menu_video:
                    fragment = new ContactFragment();
                    break;
            }
            if (fragment == null) return;
            FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment).Commit();
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }
    }
}

