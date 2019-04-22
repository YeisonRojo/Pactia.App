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
    public class FragmentNews : Fragment
    {
        #region Variables
        bool IsInternetConnectionAvailable;
        SharedFunctions sharedFunctions = new SharedFunctions();
        #endregion
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static FragmentNews NewInstance()
        {
            var frag1 = new FragmentNews { Arguments = new Bundle() };
            return frag1;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragmentNews, container, false);

            #region Reference controls
            var TextViewNewsTitle = view.FindViewById<TextView>(Resource.Id.textViewNewsTitle);
            var LinearLayoutEvent1 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutEvent1);
            var LinearLayoutEvent2 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutEvent2);
            var LinearLayoutEvent3 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutEvent3);
            var LinearLayoutEvent4 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutEvent4);
            var LinearLayoutEvent5 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutEvent5);

            var TextViewNewsEvent1Title = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent1Title);
            var TextViewNewsEvent1Date = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent1Date);
            var TextViewNewsEvent1City = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent1City);
            var TextViewNewsEvent1Content = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent1Content);
            var TextViewNewsEvent1Hour = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent1Hour);
            var TextViewNewsEvent1Location = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent1Location);

            var TextViewNewsEvent2Title = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent2Title);
            var TextViewNewsEvent2Date = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent2Date);
            var TextViewNewsEvent2Place = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent2Place);
            var TextViewNewsEvent2Content = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent2Content);
            var TextViewNewsEvent2Hour = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent2Hour);
            var TextViewNewsEvent2Location = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent2Location);

            var TextViewNewsEvent3Title = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent3Title);
            var TextViewNewsEvent3Date = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent3Date);
            var TextViewNewsEvent3Place = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent3Place);
            var TextViewNewsEvent3Content = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent3Content);
            var TextViewNewsEvent3Hour = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent3Hour);
            var TextViewNewsEvent3Location = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent3Location);

            var TextViewNewsEvent4Title = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent4Title);
            var TextViewNewsEvent4Date = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent4Date);
            var TextViewNewsEvent4Place = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent4Place);
            var TextViewNewsEvent4Content = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent4Content);
            var TextViewNewsEvent4Hour = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent4Hour);
            var TextViewNewsEvent4Location = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent4Location);

            var TextViewNewsEvent5Title = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent5Title);
            var TextViewNewsEvent5Date = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent5Date);
            var TextViewNewsEvent5Place = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent5Place);
            var TextViewNewsEvent5Content = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent5Content);
            var TextViewNewsEvent5Hour = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent5Hour);
            var TextViewNewsEvent5Location = view.FindViewById<TextView>(Resource.Id.textViewNewsEvent5Location);
            #endregion

            #region Add custom font
            Typeface GillSansFont = Typeface.CreateFromAsset(Activity.Assets, "GillSans.ttf");
            TextViewNewsTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent1Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent1Date.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent1City.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent1Content.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent1Hour.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent1Location.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent2Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent2Date.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent2Place.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent2Content.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent2Hour.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent2Location.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent3Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent3Date.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent3Place.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent3Content.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent3Hour.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent3Location.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent4Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent4Date.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent4Place.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent4Content.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent4Hour.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent4Location.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent5Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent5Date.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent5Place.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent5Content.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent5Hour.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewNewsEvent5Location.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            #endregion

            #region Control events
            LinearLayoutEvent1.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("http://pactia.com/noticias/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };
            LinearLayoutEvent2.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("http://pactia.com/noticias/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };
            LinearLayoutEvent3.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("http://pactia.com/noticias/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };
            LinearLayoutEvent4.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("http://pactia.com/noticias/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };
            LinearLayoutEvent5.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("http://pactia.com/noticias/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };

            #endregion

            IsInternetConnectionAvailable = sharedFunctions.CheckInternetConnection();
            if (IsInternetConnectionAvailable == true)
            {
                Service service = new Service();
                Constants constants = new Constants();
                try
                {
                    Eventos eventos = service.HttpGet<Eventos>(constants.Url, constants.EventoController, constants.EventoMethod, "idEvent=1");
                    TextViewNewsEvent1Title.Text = eventos.TituloEvento;
                    TextViewNewsEvent1Date.Text = "Fecha: " + eventos.Fecha.ToString("dd-MM-yyyy");
                    TextViewNewsEvent1Content.Text = eventos.Texto;
                    TextViewNewsEvent1Hour.Text = "Hora: " + eventos.Hora.ToString("hh:mm");
                    TextViewNewsEvent1Location.Text = "Lugar: " + eventos.Direccion;
                    TextViewNewsEvent1City.Text = "Ciudad: " + eventos.Ciudad.Nombre;

                    eventos = service.HttpGet<Eventos>(constants.Url, constants.EventoController, constants.EventoMethod, "idEvent=2");
                    TextViewNewsEvent2Title.Text = eventos.TituloEvento;
                    TextViewNewsEvent2Date.Text = "Fecha: " + eventos.Fecha.ToString("dd-MM-yyyy"); ;
                    TextViewNewsEvent2Content.Text = eventos.Texto;
                    TextViewNewsEvent2Hour.Text = "Hora: " + eventos.Hora.ToString("hh:mm");
                    TextViewNewsEvent2Location.Text = "Lugar: " + eventos.Direccion;
                    TextViewNewsEvent2Place.Text = "Ciudad: " + eventos.Ciudad.Nombre;

                    eventos = service.HttpGet<Eventos>(constants.Url, constants.EventoController, constants.EventoMethod, "idEvent=3");
                    TextViewNewsEvent3Title.Text = eventos.TituloEvento;
                    TextViewNewsEvent3Date.Text = "Fecha: " + eventos.Fecha.ToString("dd-MM-yyyy"); ;
                    TextViewNewsEvent3Content.Text = eventos.Texto;
                    TextViewNewsEvent3Hour.Text = "Hora: " + eventos.Hora.ToString("hh:mm");
                    TextViewNewsEvent3Location.Text = "Lugar: " + eventos.Direccion;
                    TextViewNewsEvent3Place.Text = "Ciudad: " + eventos.Ciudad.Nombre;

                    eventos = service.HttpGet<Eventos>(constants.Url, constants.EventoController, constants.EventoMethod, "idEvent=5");
                    TextViewNewsEvent4Title.Text = eventos.TituloEvento;
                    TextViewNewsEvent4Date.Text = "Fecha: " + eventos.Fecha.ToString("dd-MM-yyyy"); ;
                    TextViewNewsEvent4Content.Text = eventos.Texto;
                    TextViewNewsEvent4Hour.Text = "Hora: " + eventos.Hora.ToString("hh:mm");
                    TextViewNewsEvent4Location.Text = "Lugar: " + eventos.Direccion;
                    TextViewNewsEvent4Place.Text = "Ciudad: " + eventos.Ciudad.Nombre;

                    eventos = service.HttpGet<Eventos>(constants.Url, constants.EventoController, constants.EventoMethod, "idEvent=4");
                    TextViewNewsEvent5Title.Text = eventos.TituloEvento;
                    TextViewNewsEvent5Date.Text = "Fecha: " + eventos.Fecha.ToString("dd-MM-yyyy"); ;
                    TextViewNewsEvent5Content.Text = eventos.Texto;
                    TextViewNewsEvent5Hour.Text = "Hora: " + eventos.Hora.ToString("hh:mm");
                    TextViewNewsEvent5Location.Text = "Lugar: " + eventos.Direccion;
                    TextViewNewsEvent5Place.Text = "Ciudad: " + eventos.Ciudad.Nombre;
                }
                catch (Exception)
                {
                    AlertDialog("Alerta", "El servicio no está disponible en el momento, intente nuevamente mas tarde");
                }
            }
            else
            {
                AlertDialog("Alerta", "Por favor verifique su conexión a internet e intente nuevamente");
            }     
            return view;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinearLayoutEvent1_Click(object sender, System.EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("http://pactia.com/");
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        public void AlertDialog(string title, string message)
        {
            var alertDialog = (new Android.App.AlertDialog.Builder(Activity)).Create();
            alertDialog.SetMessage(message);
            alertDialog.SetTitle(title);
            alertDialog.SetButton("Aceptar", handleNothingButton);
            alertDialog.SetCancelable(false);
            alertDialog.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void handleNothingButton(object sender, DialogClickEventArgs e)
        {
            Android.App.AlertDialog objAlertDialog = sender as Android.App.AlertDialog;
            Button btnClicked = objAlertDialog.GetButton(e.Which);
            if (btnClicked.Text == "Aceptar")
            {
                System.Environment.Exit(0);
            }
        }
    }
}