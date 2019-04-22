using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using SharedContent;
using System;

namespace PactiaDroid.Fragments
{
    public class FragmentClients : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static FragmentClients NewInstance()
        {
            var frag2 = new FragmentClients { Arguments = new Bundle() };
            return frag2;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            #region Reference controls
            var view = inflater.Inflate(Resource.Layout.fragmentClients, container, false);
            var TextViewClientsTitle = view.FindViewById<TextView>(Resource.Id.textViewClientsTitle);
            var TextViewClientsWebSiteTitle = view.FindViewById<TextView>(Resource.Id.textViewClientsWebSiteTitle);
            var TextViewClientsWebSiteContent = view.FindViewById<TextView>(Resource.Id.textViewClientsWebSiteContent);
            var TextViewClientsWebSiteContentMore = view.FindViewById<TextView>(Resource.Id.textViewClientsWebSiteContentMore);
            var LinearLayoutClientsWebSite = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutClientsWebSite);
            var TextViewClientsCallTitle = view.FindViewById<TextView>(Resource.Id.textViewClientsCallTitle);
            var TextViewClientsCallTitleMore = view.FindViewById<TextView>(Resource.Id.textViewClientsCallTitleMore);
            var TextViewClientsCallContent = view.FindViewById<TextView>(Resource.Id.textViewClientsCallContent);
            var LinearLayoutClientsCall = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutClientsCall);
            var LinearLayoutClientsEmail = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutClientsEmail);
            var TextViewClientsMailTitle = view.FindViewById<TextView>(Resource.Id.textViewClientsMailTitle);
            var TextViewClientsMailContent = view.FindViewById<TextView>(Resource.Id.textViewClientsMailContent);
            var TextViewClientsMailContentMore = view.FindViewById<TextView>(Resource.Id.textViewClientsMailTitleMore);
            #endregion

            #region Add custom font
            Typeface GillSansFont = Typeface.CreateFromAsset(Activity.Assets, "GillSans.ttf");
            TextViewClientsTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewClientsWebSiteTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewClientsWebSiteContent.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewClientsWebSiteContentMore.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewClientsCallTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewClientsCallContent.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewClientsCallTitleMore.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewClientsMailTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewClientsMailContent.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewClientsMailContentMore.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            #endregion

            #region Controls Clicks
            LinearLayoutClientsWebSite.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    var uri = Android.Net.Uri.Parse("https://pactia.com/");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {

                }
            };   
            LinearLayoutClientsCall.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    Service service = new Service();
                    Constants constants = new Constants();
                    Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=06");
                    var uri = Android.Net.Uri.Parse("tel:" + lineas.Telefono);
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {

                }
            };
            LinearLayoutClientsEmail.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    var intent = new Intent(Activity, typeof(ContactActivity));
                    intent.PutExtra("businessline", "Portafolio");
                    StartActivity(intent);
                }
                catch (Exception )
                {
                    
                }
            };
            #endregion
            return view;
        }
    }
}