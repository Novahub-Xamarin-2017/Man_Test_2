using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;

namespace PresentationApplication.Fragments
{
    public class OpenWebTechnologyFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.OpenWebTechnologyFragment, container, false);
            Cheeseknife.Inject(this, view);
            return view;
        }
    }
}