using Android.App;
using Android.OS;
using Android.Views;

namespace PresentationApplication.Fragments
{
    public class StoriesFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view = inflater.Inflate(Resource.Layout.StoriesFragment, container, false);
            
            Cheeseknife.Inject(this, view);
            return view;
        }
    }
}