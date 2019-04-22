using System;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using SharedContent;
using Android.Content;
using Android.Glide;

namespace PactiaDroid.Fragments
{
    public class FragmentPactia : Fragment, IOnMapReadyCallback
    {
        #region Variables     
        public static GoogleMap GMap;
        public static bool IsInternetConnectionAvailable;
        public static MapView MyMapView;
        Service service = new Service();
        Constants constants = new Constants();
        SharedFunctions sharedFunctions = new SharedFunctions();
        #endregion
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnResume()
        {
            MyMapView.OnResume();
            base.OnResume();
        }

        public override void OnPause()
        {
            base.OnPause();        
        }

        public static FragmentPactia NewInstance()
        {
            var frag1 = new FragmentPactia { Arguments = new Bundle() };
            return frag1;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragmentPactia, container, false);

            #region Reference controls
            var ImageViewVideo = view.FindViewById<ImageView>(Resource.Id.imageViewVideo);
            var ImageViewPactiaFacebook = view.FindViewById<ImageView>(Resource.Id.imageViewPactiaFacebook);
            var ImageViewPactiaInstagram = view.FindViewById<ImageView>(Resource.Id.imageViewPactiaInstagram);
            var ImageViewPactiaLinkdln = view.FindViewById<ImageView>(Resource.Id.imageViewPactiaLinkdln);
            var ImageViewPactiaYoutube = view.FindViewById<ImageView>(Resource.Id.imageViewPactiaYoutube);
            var TextViewPactiaTitle = view.FindViewById<TextView>(Resource.Id.textViewPactiaTitle);
            var TextViewPactiaMapTitle = view.FindViewById<TextView>(Resource.Id.textViewPactiaMapTitle);
            var TextViewPactiaWebPage = view.FindViewById<TextView>(Resource.Id.textViewPactiaWebPage);
            MyMapView = view.FindViewById<MapView>(Resource.Id.mapView1);
            var LinearLayoutBusiness1 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutBusiness1);
            var LinearLayoutContainerBusiness1 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutContainerBusiness1);
            var LinearLayoutBusiness2 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutBusiness2);
            var LinearLayoutContainerBusiness2 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutContainerBusiness2);
            var LinearLayoutBusiness3 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutBusiness3);
            var LinearLayoutContainerBusiness3 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutContainerBusiness3);
            var LinearLayoutBusiness4 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutBusiness4);
            var LinearLayoutContainerBusiness4 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutContainerBusiness4);
            var LinearLayoutBusiness5 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutBusiness5);
            var LinearLayoutContainerBusiness5 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutContainerBusiness5);
            var LinearLayoutBusiness6 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutBusiness6);
            var LinearLayoutContainerBusiness6 = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutContainerBusiness6);
            var ImageViewBusiness1Logo = view.FindViewById<ImageView>(Resource.Id.imageViewBusiness1Logo);
            var ImageViewBusiness2Logo = view.FindViewById<ImageView>(Resource.Id.imageViewBusiness2Logo);
            var ImageViewBusiness3Logo = view.FindViewById<ImageView>(Resource.Id.imageViewBusiness3Logo);
            var ImageViewBusiness4Logo = view.FindViewById<ImageView>(Resource.Id.imageViewBusiness4Logo);
            var TextViewBusiness1Title = view.FindViewById<TextView>(Resource.Id.textViewBusiness1Title);
            var TextViewBusiness2Title = view.FindViewById<TextView>(Resource.Id.textViewBusiness2Title);
            var TextViewBusiness3Title = view.FindViewById<TextView>(Resource.Id.textViewBusiness3Title);
            var TextViewBusiness4Title = view.FindViewById<TextView>(Resource.Id.textViewBusiness4Title);
            var TextViewBusiness5Title = view.FindViewById<TextView>(Resource.Id.textViewBusiness5Title);
            var TextViewBusiness6Title = view.FindViewById<TextView>(Resource.Id.textViewBusiness6Title);
            var TextViewBusiness1Description = view.FindViewById<TextView>(Resource.Id.textViewBusiness1Description);
            var TextViewBusiness2Description = view.FindViewById<TextView>(Resource.Id.textViewBusiness2Description);
            var TextViewBusiness3Description = view.FindViewById<TextView>(Resource.Id.textViewBusiness3Description);
            var TextViewBusiness4Description = view.FindViewById<TextView>(Resource.Id.textViewBusiness4Description);
            var TextViewBusiness5Description = view.FindViewById<TextView>(Resource.Id.textViewBusiness5Description);
            var TextViewBusiness6Description = view.FindViewById<TextView>(Resource.Id.textViewBusiness6Description);
            var SwitchPactiaAcceptConditions = view.FindViewById<Switch>(Resource.Id.switchPactiaAcceptConditions);
            var EditTextPactiaName = view.FindViewById<EditText>(Resource.Id.editTextPactiaName);
            var EditTextPactiaEmail = view.FindViewById<EditText>(Resource.Id.editTextPactiaEmail);
            var EditTextPactiaBusinessName = view.FindViewById<EditText>(Resource.Id.editTextPactiaBusinessName);
            var EditTextPactiaPhoneNumber = view.FindViewById<EditText>(Resource.Id.editTextPactiaPhoneNumber);
            var EditTextPactiaMessage = view.FindViewById<EditText>(Resource.Id.editTextPactiaMessage);
            var ButtonPactiaSend = view.FindViewById<Button>(Resource.Id.buttonPactiaSend);
            var ButtonPactiaCall = view.FindViewById<Button>(Resource.Id.buttonPactiaCall);
            var ButtonViewPactiaPrivacy = view.FindViewById<TextView>(Resource.Id.buttonPactiaPrivacy);
            var TextViewPactiaCopyRight = view.FindViewById<TextView>(Resource.Id.textViewPactiaCopyRight);
            #endregion

            #region Add custom font
            Typeface GillSansFont = Typeface.CreateFromAsset(Activity.Assets, "GillSans.ttf");
            TextViewPactiaTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness1Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness2Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness3Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness4Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness5Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness6Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness1Description.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness2Description.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness3Description.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness4Description.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness5Description.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness6Description.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPactiaMapTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);         
            TextViewPactiaWebPage.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            EditTextPactiaName.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            EditTextPactiaEmail.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            EditTextPactiaPhoneNumber.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            EditTextPactiaBusinessName.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            EditTextPactiaMessage.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            ButtonPactiaCall.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            ButtonPactiaSend.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            ButtonViewPactiaPrivacy.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewPactiaCopyRight.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            SwitchPactiaAcceptConditions.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            #endregion

            #region Controls Events
            ImageViewVideo.Click += (Object sender, EventArgs e) =>
            {
                var intent = new Intent(Activity, typeof(VideoActivity));
                StartActivity(intent);
            };

            TextViewPactiaWebPage.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("http://pactia.com/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };
          
            LinearLayoutBusiness1.Click += (Object sender, EventArgs e) =>
            {
                var intent = new Intent(Activity, typeof(BusinessLineContentActivity));
                StartActivity(intent);
            };
            LinearLayoutBusiness2.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("https://pactia.com/linea-negocio/comercio/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };
            LinearLayoutBusiness3.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("https://pactia.com/linea-negocio/oficinas/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };
            LinearLayoutBusiness4.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("https://pactia.com/linea-negocio/autoalmacenamiento/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };
            LinearLayoutBusiness5.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("https://pactia.com/linea-negocio/hoteles/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };
            LinearLayoutBusiness6.Click += (Object sender, EventArgs e) =>
            {
                var weburi = Android.Net.Uri.Parse("https://pactia.com/linea-negocio/multifamily/");
                var intent = new Intent(Intent.ActionView, weburi);
                StartActivity(intent);
            };

            ButtonPactiaSend.Click += (object sender, EventArgs e) =>
            {
                if (sharedFunctions.IsEmptyOrNullString(EditTextPactiaName.Text) == true || sharedFunctions.IsEmptyOrNullString(EditTextPactiaBusinessName.Text) == true || sharedFunctions.IsEmptyOrNullString(EditTextPactiaPhoneNumber.Text) == true)
                {
                    SimpleToast("Debe completar todos los campos");
                }
                else
                {
                    if (SwitchPactiaAcceptConditions.Checked == true)
                    {
                        Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=06");
                        string MailState = sharedFunctions.SendEmail("Información sobre portafolio ", "Nombre:  " + EditTextPactiaName.Text + System.Environment.NewLine + "Funcionario de la empresa: " + EditTextPactiaBusinessName.Text + System.Environment.NewLine + "Nos pueden contactar via Email: " + EditTextPactiaEmail.Text + System.Environment.NewLine + "Teléfono: " + EditTextPactiaPhoneNumber.Text + System.Environment.NewLine + "Mensaje: " + EditTextPactiaMessage.Text + System.Environment.NewLine + System.Environment.NewLine, lineas.Email, lineas.EmailRemitente, lineas.Clave, lineas.Smtp);
                        SimpleToast(MailState);
                        EditTextPactiaName.Text = "";
                        EditTextPactiaBusinessName.Text = "";
                        EditTextPactiaEmail.Text = "";
                        EditTextPactiaPhoneNumber.Text = "";
                        EditTextPactiaMessage.Text = "";
                    }
                    else
                    {
                        SimpleToast("Antes de continuar debe aceptar las políticas de tratamiento de datos personales");
                    }
                }
            };

            ButtonPactiaCall.Click += (object sender, EventArgs e) =>
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
                    throw;
                }
            };

            ButtonViewPactiaPrivacy.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    var uri = Android.Net.Uri.Parse("https://pactia.com/terminos-y-condiciones/");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    throw;
                }
            };

            ImageViewPactiaFacebook.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    var uri = Android.Net.Uri.Parse("https://www.facebook.com/pactiaoficial/");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    SimpleToast("Ha ocurrido un error al intentar abrir en enlace.");
                }
            };

            ImageViewPactiaInstagram.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    var uri = Android.Net.Uri.Parse("https://www.instagram.com/pactiaoficial/");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    SimpleToast("Ha ocurrido un error al intentar abrir en enlace.");
                }
            };

            ImageViewPactiaLinkdln.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    var uri = Android.Net.Uri.Parse("https://www.linkedin.com/company/pactia");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    SimpleToast("Ha ocurrido un error al intentar abrir en enlace.");
                }
            };

            ImageViewPactiaYoutube.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    var uri = Android.Net.Uri.Parse("https://www.youtube.com/channel/UCFH_l8cOLR-1FiS021ena2Q");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    SimpleToast("Ha ocurrido un error al intentar abrir en enlace.");
                }
            };

            #endregion

            MapsInitializer.Initialize(this.Context);
            MyMapView.OnCreate(savedInstanceState);
            MyMapView.GetMapAsync(this);
            IsInternetConnectionAvailable = sharedFunctions.CheckInternetConnection();
            if (IsInternetConnectionAvailable == true)
            {
                try
                {
                    Glide.With(this).Load(Resource.Drawable.logikalogo).Into(ImageViewBusiness1Logo);
                    Glide.With(this).Load(Resource.Drawable.logogranplaza).Into(ImageViewBusiness2Logo);
                    Glide.With(this).Load(Resource.Drawable.logoburo).Into(ImageViewBusiness3Logo);
                    Glide.With(this).Load(Resource.Drawable.logoustorage).Into(ImageViewBusiness4Logo);

                    Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=01");
                    var ImageViewBusiness1 = view.FindViewById<ImageView>(Resource.Id.imageViewBusiness1);
                    Glide.With(this).Load(galeria.Url).Into(ImageViewBusiness1);
                    Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=01");
                    TextViewBusiness1Title.Text = lineas.Nombre;
                    TextViewBusiness1Description.Text = lineas.Texto2;
                 
                    galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=02");
                    var ImageViewBusiness2 = view.FindViewById<ImageView>(Resource.Id.imageViewBusiness2);
                    Glide.With(this).Load(galeria.Url).Into(ImageViewBusiness2);
                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=02");
                    TextViewBusiness2Title.Text = lineas.Nombre;
                    TextViewBusiness2Description.Text = lineas.Texto2;

                    galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=03");
                    var ImageViewBusiness3 = view.FindViewById<ImageView>(Resource.Id.imageViewBusiness3);
                    Glide.With(this).Load(galeria.Url).Into(ImageViewBusiness3);
                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=03");
                    TextViewBusiness3Title.Text = lineas.Nombre;
                    TextViewBusiness3Description.Text = lineas.Texto2;

                    galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=77");
                    var ImageViewBusiness4 = view.FindViewById<ImageView>(Resource.Id.imageViewBusiness4);
                    Glide.With(this).Load(galeria.Url).Into(ImageViewBusiness4);
                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=05");
                    TextViewBusiness4Title.Text = lineas.Nombre;
                    TextViewBusiness4Description.Text =lineas.Texto2;

                    galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=04");
                    var ImageViewBusiness5 = view.FindViewById<ImageView>(Resource.Id.imageViewBusiness5);
                    Glide.With(this).Load(galeria.Url).Into(ImageViewBusiness5);
                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=04");
                    TextViewBusiness5Title.Text = lineas.Nombre;
                    TextViewBusiness5Description.Text = lineas.Texto2;

                    galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=78");
                    var ImageViewBusiness6 = view.FindViewById<ImageView>(Resource.Id.imageViewBusiness6);
                    Glide.With(this).Load(galeria.Url).Into(ImageViewBusiness6);
                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=07");
                    TextViewBusiness6Title.Text =lineas.Nombre;
                    TextViewBusiness6Description.Text = lineas.Texto2;
                    SetUpMap();
                }
                catch (Exception ex)
                {
                    AlertDialog("Alerta", "El servicio no está disponible en el momento, intente nuevamente mas tarde" + ex.Message);
                }
            }
            else
            {
                AlertDialog("Alerta", "Por favor verifique su conexión a internet e intente nuevamente");
            }
            return view;
        }

        #region Methods
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void SimpleToast(string message)
        {
            Toast.MakeText(Activity, message, ToastLength.Long).Show();
        }
 
        /// <summary>
        /// 
        /// </summary>
        public  void SetUpMap()
        {
            if (GMap == null)
            {
                MyMapView.GetMapAsync(this);
            }           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="googleMap"></param>
        public void OnMapReady(GoogleMap googleMap)
        {
            GMap = googleMap;
            GMap.UiSettings.CompassEnabled = true;
            GMap.UiSettings.MyLocationButtonEnabled = true;
            GMap.UiSettings.MapToolbarEnabled = true;
            MapsInitializer.Initialize(this.Context);
            var ColombiaMarker = new MarkerOptions().SetTitle("Colombia");
            ColombiaMarker.SetPosition(new LatLng(5.156853, -74.039258));
            GMap.AddMarker(ColombiaMarker);
            var PanamaMarker = new MarkerOptions().SetTitle("Panamá");
            PanamaMarker.SetPosition(new LatLng(9.131443, -79.681025));
            GMap.AddMarker(PanamaMarker);
            var UsaMarker = new MarkerOptions().SetTitle("Estados Unidos");
            UsaMarker.SetPosition(new LatLng(40.343302, -102.066399));
            GMap.AddMarker(UsaMarker);
            GMap.UiSettings.ZoomControlsEnabled = true;
            LatLng latlng2 = new LatLng(Convert.ToDouble(40.343302), Convert.ToDouble(-102.066399));
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng2, 0);
            GMap.MoveCamera(camera);
            GMap.MapType = GoogleMap.MapTypeNormal;
        }
        #endregion
    }

   
}