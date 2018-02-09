using Android.Views;

namespace PresentationApplication.Interfaces
{
    public interface IStoryClickListener
    {
        void OnClick(View itemView, int position);
    }
}