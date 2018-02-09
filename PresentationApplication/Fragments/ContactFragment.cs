using Android.App;
using Android.OS;
using Android.Views;

namespace PresentationApplication.Fragments
{
    public class ContactFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.ContactFragment, container, false);

            return view;
        }
    }
}