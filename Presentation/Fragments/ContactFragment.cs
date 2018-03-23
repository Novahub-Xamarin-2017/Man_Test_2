using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Presentation.Models;
using Presentation.Services;
using System.IO;
using Android.Graphics;

namespace Presentation.Fragments
{
    public class ContactFragment : Fragment
    {
        private readonly SwaggerServices services = new SwaggerServices();

        private List<CheckBox> checkboxes;

        private string reason;

        private bool reasonChecked = false;

        private bool isFirstNameNotNull = false;

        private bool isLastNameNotNull = false;

        private string helloTo;

        private string imageBase64String = string.Empty;

        private View view;

        [InjectView(Resource.Id.imgCard)] private ImageView imgCard;

        [InjectView(Resource.Id.cbDigitalProject)] private CheckBox cbDigitalProject;

        [InjectView(Resource.Id.cbJobOrMasterThesis)] private CheckBox cbJobOrMasterThesis;

        [InjectView(Resource.Id.cbSayHi)] private CheckBox cbSayHi;

        [InjectView(Resource.Id.cbOther)] private CheckBox cbOther;

        [InjectView(Resource.Id.tvFirstName)] private EditText tvFirstName;

        [InjectView(Resource.Id.tvLastName)] private EditText tvLastName;

        [InjectView(Resource.Id.tvAddress)] private EditText tvAddress;

        [InjectView(Resource.Id.tvCompany)] private EditText tvCompany;

        [InjectView(Resource.Id.tvPosition)] private EditText tvPosition;

        [InjectView(Resource.Id.tvBranch)] private EditText tvBranch;

        [InjectView(Resource.Id.tvComments)] private EditText tvComments;

        [InjectView(Resource.Id.btnSend)] private Button btnSend;

        [InjectView(Resource.Id.spnTo)] private Spinner spnTo;

        [InjectOnClick(Resource.Id.btnCamera)]
        private void TakeImage(object sender, EventArgs e)
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 0);
        }

        [InjectOnClick(Resource.Id.btnSend)]
        private void Send(object sender, EventArgs e)
        {
            Log.Info("string", imageBase64String);
            var contact = new Contact
            {
                Reason = reason,
                FirstName = tvFirstName.Text,
                LastName = tvLastName.Text,
                HelloTo = cbSayHi != null && (cbSayHi.Checked) ? helloTo : string.Empty,
                Email = tvAddress.Text,
                Industry = tvBranch.Text,
                Position = tvPosition.Text,
                Token = "v5?1Q$Q974-tE_i1K!_!7qoiEo_?4@-35ptR57tedi66Mx-Duqm-2?x$j@zX6@U",
                Company = tvCompany.Text,
                Comments = tvComments.Text,
                Images = string.IsNullOrEmpty(imageBase64String) ? new List<Image>() : new List<Image>
                {
                    new Image
                    {
                        Id = 0,
                        ImageBase64 = imageBase64String
                    }
                }
            };
            if (services.PostContact(contact))
            {
                Toast.MakeText(view.Context, "Success", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(view.Context, "Failed", ToastLength.Short).Show();
            }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view =  inflater.Inflate(Resource.Layout.Contact, container, false);
            Cheeseknife.Inject(this, view);
            checkboxes = new List<CheckBox> { cbDigitalProject, cbJobOrMasterThesis, cbSayHi, cbOther };
            Init();
            return view;
        }

        private void UncheckedOthers(IDisposable checkBox)
        {
            foreach (var cb in checkboxes.Where(x => !Equals(x, checkBox)))
            {
                cb.Checked = false;
            }
        }

        private void HandleOnCheckedCheckbox(CompoundButton checkBox, string reasonUpdated)
        {
            checkBox.CheckedChange += (s, e) =>
            {
                if (!checkBox.Checked) return;
                UncheckedOthers(checkBox);
                reasonChecked = true;
                reason = reasonUpdated;
                ChangeButtonSendStatus();
            };
        }

        private void Init()
        {
            HandleOnCheckedCheckbox(cbDigitalProject, "DIGITAL_PROJET");
            HandleOnCheckedCheckbox(cbJobOrMasterThesis, "JOB_OR_MASTER_THESIS");
            HandleOnCheckedCheckbox(cbSayHi, "SAY_HI");
            HandleOnCheckedCheckbox(cbOther, "OTHER");

            tvFirstName.TextChanged += (s, e) =>
            {
                isFirstNameNotNull = !string.IsNullOrEmpty(tvFirstName.Text);
                ChangeButtonSendStatus();
            };

            tvLastName.TextChanged += (s, e) =>
            {
                isLastNameNotNull = !string.IsNullOrEmpty(tvLastName.Text);
                ChangeButtonSendStatus();
            };

            spnTo.ItemSelected += SpinnerItemSelected;
            var persons = new [] { "Frédéric", "Markus", "Paul", "Kay", "Joël", "Pascal", "Mike", "Hoa Vo" };
            var adapter = new ArrayAdapter(view.Context, Android.Resource.Layout.SimpleListItem1, persons);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spnTo.Adapter = adapter;
        }

        private void ChangeButtonSendStatus()
        {
            if (isLastNameNotNull && isFirstNameNotNull && reasonChecked)
            {
                btnSend.SetBackgroundResource(Resource.Drawable.btnSendActive);
                btnSend.Enabled = true;
            }
            else
            {
                btnSend.SetBackgroundResource(Resource.Drawable.btnSendInactive);
                btnSend.Enabled = false;
            }
        }

        private void SpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var spinner = (Spinner)sender;
            helloTo = spinner.GetItemAtPosition(e.Position).ToString();
            Log.Info("helloTo", helloTo);
        }

        public override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode != Result.Ok) return;
            imgCard.SetImageURI(data.Data);
            var imageStream = view.Context.ContentResolver.OpenInputStream(data.Data);
            var imageBitmap = BitmapFactory.DecodeStream(imageStream);
            imageBase64String = $"{EncodeImage(imageBitmap)}==";
        }

        private static string EncodeImage(Bitmap bitmap)
        {
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                var bytes = stream.ToArray();
                var base64String = Convert.ToBase64String(bytes);
                return base64String;
            }
        }
    }
}