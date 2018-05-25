using Android.Views;

namespace Presentation.Interfaces
{
    public interface IStoryClickListener
    {
        void OnClick(View itemView, int position);
    }
}