using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;
using Com.Lilarcor.Cheeseknife;
using Presentation.Activities;
using Presentation.Models;
using Presentation.Services;

namespace Presentation.Fragments
{
    public class OwtFragment : Fragment
    {
        private readonly SwaggerServices services = new SwaggerServices();

        private List<OwtTile> owtTiles;

        [InjectView(Resource.Id.btnDiscover)] private ImageButton btnDiscover;

        [InjectView(Resource.Id.btnPeople)] private ImageButton btnPeople;

        [InjectView(Resource.Id.btnNumbers)] private ImageButton btnNumbers;

        [InjectView(Resource.Id.btnService)] private ImageButton btnService;

        [InjectView(Resource.Id.btnVenture)] private ImageButton btnVenture;
        
        [InjectOnClick(Resource.Id.btnDiscover)]
        private void ClickButtonDiscover(object sender, EventArgs e)
        {
            ViewDocument(owtTiles[0]);
        }

        [InjectOnClick(Resource.Id.btnPeople)]
        private void ClickButtonPeople(object sender, EventArgs e)
        {
            ViewDocument(owtTiles[1]);
        }

        [InjectOnClick(Resource.Id.btnNumbers)]
        private void ClickButtonNumbers(object sender, EventArgs e)
        {
            ViewDocument(owtTiles[2]);
        }

        [InjectOnClick(Resource.Id.btnService)]
        private void ClickButtonService(object sender, EventArgs e)
        {
            ViewDocument(owtTiles[3]);
        }

        [InjectOnClick(Resource.Id.btnVenture)]
        private void ClickButtonVenture(object sender, EventArgs e)
        {
            ViewDocument(owtTiles[4]);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Owt, container, false);
            Cheeseknife.Inject(this, view);
            GetData();
            SetWidgets();
            return view;
        }

        private void GetData()
        {
            owtTiles = services.GetOwtTiles();
        }

        private void SetWidgets()
        {
            SetButtonSrc(btnDiscover, owtTiles[0]);
            SetButtonSrc(btnPeople, owtTiles[1]);
            SetButtonSrc(btnNumbers, owtTiles[2]);
            SetButtonSrc(btnService, owtTiles[3]);
            SetButtonSrc(btnVenture, owtTiles[4]);
        }

        private void SetButtonSrc(ImageButton imgButton, OwtTile owtTile)
        {
            Glide.With(this).Load(owtTile.ImageUrl).Into(imgButton);
        }

        private void ViewDocument(OwtTile owtTile)
        {
            if (owtTile.DocumentUrl.EndsWith(".pdf"))
            {
                var intent = new Intent(Activity, typeof(DisplayPdfActivity));
                intent.PutExtra("documentName", owtTile.DocumentName);
                intent.PutExtra("documentUrl", owtTile.DocumentUrl);
                StartActivity(intent);
            }
            else if (owtTile.DocumentUrl.EndsWith(".mp4"))
            {
                var intent = new Intent(Activity, typeof(PlayVideoActivity));
                intent.PutExtra("documentUrl", owtTile.DocumentUrl);
                StartActivity(intent);
            }
        }
    }
}