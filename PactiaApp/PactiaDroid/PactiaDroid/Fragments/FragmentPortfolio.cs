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
    public class FragmentPortfolio : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static FragmentPortfolio NewInstance()
        {
            var frag1 = new FragmentPortfolio { Arguments = new Bundle() };
            return frag1;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Lineas lineas = new Lineas();
            Service service = new Service();
            Constants constants = new Constants();

            #region Reference controls
            var view = inflater.Inflate(Resource.Layout.fragmentPortfolio, container, false);
            var LinearLayoutPortfolio1 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutPortfolio1);
            var LinearLayoutPortfolio2 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutPortfolio2);
            var LinearLayoutPortfolio3 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutPortfolio3);
            var LinearLayoutPortfolio4 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutPortfolio4);
            var LinearLayoutPortfolio5 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutPortfolio5);
            var LinearLayoutPortfolio6 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutPortfolio6);
            var TextViewPortfolioTitle = view.FindViewById<TextView>(Resource.Id.textViewPortfolioTitle);
            var TextViewPortfolioBusiness1Title = view.FindViewById<TextView>(Resource.Id.textViewPortfolioBusiness1Title);
            var TextViewPortfolioBusiness1SubTitle = view.FindViewById<TextView>(Resource.Id.textViewPortfolioBusiness1SubTitle);
            var TextViewPortfolioBusiness2Title = view.FindViewById<TextView>(Resource.Id.textViewPortfolioBusiness2Title);
            var TextViewPortfolioBusiness2SubTitle = view.FindViewById<TextView>(Resource.Id.textViewPortfolioBusiness2SubTitle);
            var TextViewPortfolioBusiness3Title = view.FindViewById<TextView>(Resource.Id.textViewPortfolioBusiness3Title);
            var TextViewPortfolioBusiness3SubTitle = view.FindViewById<TextView>(Resource.Id.textViewPortfolioBusiness3SubTitle);
            var TextViewPortfolioBusiness4Title = view.FindViewById<TextView>(Resource.Id.textViewPortfolioBusiness4Title);
            var TextViewPortfolioBusiness4SubTitle = view.FindViewById<TextView>(Resource.Id.textViewPortfolioBusiness4SubTitle);
            var TextViewPortfolioBusiness5Title = view.FindViewById<TextView>(Resource.Id.textViewPortfolioBusiness5Title);
            var TextViewPortfolioBusiness5SubTitle = view.FindViewById<TextView>(Resource.Id.textViewPortfolioBusiness5SubTitle);
            var TextViewPortfolioBusiness6Title = view.FindViewById<TextView>(Resource.Id.textViewPortfolioBusiness6Title);
            var TextViewPortfolioBusiness6SubTitle = view.FindViewById<TextView>(Resource.Id.textViewPortfolioBusiness6SubTitle);
            var TextViewPortfolioContentMore1 = view.FindViewById<TextView>(Resource.Id.textViewPortfolioContentMore1);
            var TextViewPortfolioContentMore2 = view.FindViewById<TextView>(Resource.Id.textViewPortfolioContentMore2);
            var TextViewPortfolioContentMore3 = view.FindViewById<TextView>(Resource.Id.textViewPortfolioContentMore3);
            var TextViewPortfolioContentMore4 = view.FindViewById<TextView>(Resource.Id.textViewPortfolioContentMore4);
            var TextViewPortfolioContentMore5 = view.FindViewById<TextView>(Resource.Id.textViewPortfolioContentMore5);
            var TextViewPortfolioContentMore6 = view.FindViewById<TextView>(Resource.Id.textViewPortfolioContentMore6);
            #endregion

            #region Controls Clicks
            LinearLayoutPortfolio1.Click += (Object sender, EventArgs e) =>
            {
                var intent = new Intent(Activity, typeof(BusinessLineContentActivity));
                StartActivity(intent);
            };
            LinearLayoutPortfolio2.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("https://pactia.com/linea-negocio/comercio/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };
            LinearLayoutPortfolio3.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("https://pactia.com/linea-negocio/oficinas/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };
            LinearLayoutPortfolio4.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("https://pactia.com/linea-negocio/autoalmacenamiento/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };
            LinearLayoutPortfolio5.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("https://pactia.com/linea-negocio/hoteles/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };
            LinearLayoutPortfolio6.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("https://pactia.com/linea-negocio/multifamily/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };
            #endregion

            #region Add custom font
            Typeface GillSansFont = Typeface.CreateFromAsset(Activity.Assets, "GillSans.ttf");
            TextViewPortfolioTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioBusiness1Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioBusiness1SubTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioBusiness2Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioBusiness2SubTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioBusiness3Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioBusiness3SubTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioBusiness4Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioBusiness4SubTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioBusiness5Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioBusiness5SubTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioBusiness6Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioBusiness6SubTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioContentMore1.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioContentMore2.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioContentMore3.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioContentMore4.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioContentMore5.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPortfolioContentMore6.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            #endregion

            lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=01");
            TextViewPortfolioBusiness1Title.Text = lineas.Nombre;
            TextViewPortfolioBusiness1SubTitle.Text = lineas.Texto2;

            lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=02");
            TextViewPortfolioBusiness2Title.Text = lineas.Nombre;
            TextViewPortfolioBusiness2SubTitle.Text = lineas.Texto2;

            lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=03");
            TextViewPortfolioBusiness3Title.Text = lineas.Nombre;
            TextViewPortfolioBusiness3SubTitle.Text = lineas.Texto2;

            lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=05");
            TextViewPortfolioBusiness4Title.Text = lineas.Nombre;
            TextViewPortfolioBusiness4SubTitle.Text = lineas.Texto2;

            lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=04");
            TextViewPortfolioBusiness5Title.Text = lineas.Nombre;
            TextViewPortfolioBusiness5SubTitle.Text = lineas.Texto2;

            lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=07");
            TextViewPortfolioBusiness6Title.Text = lineas.Nombre;
            TextViewPortfolioBusiness6SubTitle.Text = lineas.Texto2;

            return view;
        }
    }
}