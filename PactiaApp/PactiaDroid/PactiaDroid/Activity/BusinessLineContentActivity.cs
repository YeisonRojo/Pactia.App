using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Glide;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using SharedContent;
using Android.Content.PM;

namespace PactiaDroid
{
    [Activity(Label = "BusinessLineContentActivity", ScreenOrientation = ScreenOrientation.Portrait, Theme = "@android:style/Theme.Light")]
    public class BusinessLineContentActivity : Activity
    {
        #region Variables
        public static string BusinessName = string.Empty, BusinessValues = string.Empty;
        public static string[] ItemsList = null;
        bool IsInternetConnectionAvailable;
        SharedContent.Service service = new SharedContent.Service();
        Constants constants = new Constants();
        SharedFunctions sharedFunctions = new SharedFunctions();
        #endregion
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BusinessLineContent); 

            #region Controls references
            var TextViewBusinessLineContentTitle = FindViewById<TextView>(Resource.Id.textViewBusinessLineContentTitle);
            var TextViewBusiness1Description = FindViewById<TextView>(Resource.Id.textViewBusiness1Description);

            var ImageViewBusiness1 = FindViewById<ImageView>(Resource.Id.imageViewBusinessLine1);
            var TextViewBusinessSkill1 = FindViewById<TextView>(Resource.Id.textViewBusinessSkill1);
            var TextViewBusinessSkill2 = FindViewById<TextView>(Resource.Id.textViewBusinessSkill2);
            var TextViewBusinessSkill3 = FindViewById<TextView>(Resource.Id.textViewBusinessSkill3);
            var TextViewBusinessSkill4 = FindViewById<TextView>(Resource.Id.textViewBusinessSkill4);
            var TextViewBusiness1Title = FindViewById<TextView>(Resource.Id.textViewBusiness1Title);
            var imageViewBusiness1Action1 = FindViewById<ImageView>(Resource.Id.imageViewBusiness1Action1);
            var imageViewBusiness1Action2 = FindViewById<ImageView>(Resource.Id.imageViewBusiness1Action2);
            var imageViewBusiness1Action3 = FindViewById<ImageView>(Resource.Id.imageViewBusiness1Action3);
            var imageViewBusiness1Action4 = FindViewById<ImageView>(Resource.Id.imageViewBusiness1Action4);
            var imageViewBusiness1Action5 = FindViewById<ImageView>(Resource.Id.imageViewBusiness1Action5);
            var imageViewBusiness1Action6 = FindViewById<ImageView>(Resource.Id.imageViewBusiness1Action6);


            var ImageViewBusiness2 = FindViewById<ImageView>(Resource.Id.imageViewBusinessLine2);
            var TextViewBusiness2Skill1 = FindViewById<TextView>(Resource.Id.textViewBusiness2Skill1);
            var TextViewBusiness2Skill2 = FindViewById<TextView>(Resource.Id.textViewBusiness2Skill2);
            var TextViewBusiness2Skill3 = FindViewById<TextView>(Resource.Id.textViewBusiness2Skill3);
            var TextViewBusiness2Skill4 = FindViewById<TextView>(Resource.Id.textViewBusiness2Skill4);
            var TextViewBusiness2Title = FindViewById<TextView>(Resource.Id.textViewBusiness2Title);
            var imageViewBusiness2Action1 = FindViewById<ImageView>(Resource.Id.imageViewBusiness2Action1);
            var imageViewBusiness2Action2 = FindViewById<ImageView>(Resource.Id.imageViewBusiness2Action2);
            var imageViewBusiness2Action3 = FindViewById<ImageView>(Resource.Id.imageViewBusiness2Action3);
            var imageViewBusiness2Action4 = FindViewById<ImageView>(Resource.Id.imageViewBusiness2Action4);
            var imageViewBusiness2Action5 = FindViewById<ImageView>(Resource.Id.imageViewBusiness2Action5);
            var imageViewBusiness2Action6 = FindViewById<ImageView>(Resource.Id.imageViewBusiness2Action6);


            var ImageViewBusiness3 = FindViewById<ImageView>(Resource.Id.imageViewBusinessLine3);
            var TextViewBusiness3Skill1 = FindViewById<TextView>(Resource.Id.textViewBusiness3Skill1);
            var TextViewBusiness3Skill2 = FindViewById<TextView>(Resource.Id.textViewBusiness3Skill2);
            var TextViewBusiness3Skill3 = FindViewById<TextView>(Resource.Id.textViewBusiness3Skill3);
            var TextViewBusiness3Skill4 = FindViewById<TextView>(Resource.Id.textViewBusiness3Skill4);
            var TextViewBusiness3Title = FindViewById<TextView>(Resource.Id.textViewBusiness3Title);
            var imageViewBusiness3Action1 = FindViewById<ImageView>(Resource.Id.imageViewBusiness3Action1);
            var imageViewBusiness3Action2 = FindViewById<ImageView>(Resource.Id.imageViewBusiness3Action2);
            var imageViewBusiness3Action3 = FindViewById<ImageView>(Resource.Id.imageViewBusiness3Action3);
            var imageViewBusiness3Action4 = FindViewById<ImageView>(Resource.Id.imageViewBusiness3Action4);
            var imageViewBusiness3Action5 = FindViewById<ImageView>(Resource.Id.imageViewBusiness3Action5);
            var imageViewBusiness3Action6 = FindViewById<ImageView>(Resource.Id.imageViewBusiness3Action6);

            var ImageViewBusiness4 = FindViewById<ImageView>(Resource.Id.imageViewBusinessLine4);
            var TextViewBusiness4Skill1 = FindViewById<TextView>(Resource.Id.textViewBusiness4Skill1);
            var TextViewBusiness4Skill2 = FindViewById<TextView>(Resource.Id.textViewBusiness4Skill2);
            var TextViewBusiness4Skill3 = FindViewById<TextView>(Resource.Id.textViewBusiness4Skill3);
            var TextViewBusiness4Skill4 = FindViewById<TextView>(Resource.Id.textViewBusiness4Skill4);
            var TextViewBusiness4Title = FindViewById<TextView>(Resource.Id.textViewBusiness4Title);
            var TextViewPactiaMapTitle = FindViewById<TextView>(Resource.Id.textViewPactiaMapTitle);

            var imageViewBusiness4Action1 = FindViewById<ImageView>(Resource.Id.imageViewBusiness4Action1);
            var imageViewBusiness4Action2 = FindViewById<ImageView>(Resource.Id.imageViewBusiness4Action2);
            var imageViewBusiness4Action3 = FindViewById<ImageView>(Resource.Id.imageViewBusiness4Action3);
            var imageViewBusiness4Action4 = FindViewById<ImageView>(Resource.Id.imageViewBusiness4Action4);
            var imageViewBusiness4Action5 = FindViewById<ImageView>(Resource.Id.imageViewBusiness4Action5);
            var imageViewBusiness4Action6 = FindViewById<ImageView>(Resource.Id.imageViewBusiness4Action6);
            #endregion

            #region Controls Clicks Business 1
            imageViewBusiness1Action1.Click += (Object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(ContactActivity));
                intent.PutExtra("businessline", "Lógika Siberia");
                StartActivity(intent);
            };
            imageViewBusiness1Action2.Click += (Object sender, EventArgs e) =>
            {
                try
                {                  
                    Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=01");
                    var uri = Android.Net.Uri.Parse("tel:" + lineas.Telefono);
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    
                }
            };
            imageViewBusiness1Action3.Click += (Object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(MapsActivity));
                intent.PutExtra("longitude", 4.760737);
                intent.PutExtra("latitude", -74.165095);
                intent.PutExtra("title", "Lógika Siberia");
                StartActivity(intent);
            };
            imageViewBusiness1Action4.Click += (Object sender, EventArgs e) =>
            {
                try
                {
                    Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=07");
                    var uri = Android.Net.Uri.Parse(galeria.Pdf);
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    
                }
            };
            imageViewBusiness1Action5.Click += (Object sender, EventArgs e) =>
            {
                try
                {
                    var uri = Android.Net.Uri.Parse("https://logika.hauzd.com/logikasiberia");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    throw;
                }
            };
            imageViewBusiness1Action6.Click += (Object sender, EventArgs e) =>
            {
                try
                {
                    var intent = new Intent(this, typeof(PanoramaActivity));
                    intent.PutExtra("SelectionNumber", 0);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    
                }
            };
            ImageViewBusiness1.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    var uri = Android.Net.Uri.Parse("https://pactia.com/activo/logika-siberia-12/");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                   
                }
            };
            #endregion

            #region Controls Clicks Business 2
            imageViewBusiness2Action1.Click += (Object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(ContactActivity));
                intent.PutExtra("businessline", "Lógika Madrid");
                StartActivity(intent);
            };
            imageViewBusiness2Action2.Click += (Object sender, EventArgs e) =>
            {
                try
                {
                    Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=01");
                    var uri = Android.Net.Uri.Parse("tel:" + lineas.Telefono);
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {

                }
            };
            imageViewBusiness2Action3.Click += (Object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(MapsActivity));
                intent.PutExtra("longitude", 4.742864);
                intent.PutExtra("latitude", -74.256246);
                intent.PutExtra("title", "Lógika Madrid");
                StartActivity(intent);
            };
            ImageViewBusiness2.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    var uri = Android.Net.Uri.Parse("https://pactia.com/activo/logika-siberia-12-2/");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    
                }
            };
            imageViewBusiness2Action4.Click += (Object sender, EventArgs e) =>
            {
                try
                {
                    Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=07");
                    var uri = Android.Net.Uri.Parse(galeria.Pdf);
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    
                }
            };

            imageViewBusiness2Action5.Click += (Object sender, EventArgs e) =>
            {
                try
                {
                    
                }
                catch (Exception)
                {
                    
                }
            };

            imageViewBusiness2Action6.Click += (Object sender, EventArgs e) =>
            {
                try
                {
                    var intent = new Intent(this, typeof(PanoramaActivity));
                    intent.PutExtra("SelectionNumber", 1);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    
                }
            };
            #endregion

            #region Controls Clicks Business 3
            imageViewBusiness3Action1.Click += (Object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(ContactActivity));
                intent.PutExtra("businessline", "San Carlos I");
                StartActivity(intent);
            };
            imageViewBusiness3Action2.Click += (Object sender, EventArgs e) =>
            {
                try
                {
                    Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=01");
                    var uri = Android.Net.Uri.Parse("tel:" + lineas.Telefono);
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {

                }
            }; imageViewBusiness3Action3.Click += (Object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(MapsActivity));
                intent.PutExtra("longitude", 4.700809);
                intent.PutExtra("latitude", -74.184920);
                intent.PutExtra("title", "San Carlos I");
                StartActivity(intent);
            };
            ImageViewBusiness3.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    var uri = Android.Net.Uri.Parse("https://pactia.com/activo/parque-industrial-san-carlos-i/");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    
                }
            };
            imageViewBusiness3Action4.Click += (Object sender, EventArgs e) =>
            {
                try
                {
                    Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=07");
                    var uri = Android.Net.Uri.Parse(galeria.Pdf);
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    
                }
            };
            #endregion

            #region Controls Clicks Business 4
            imageViewBusiness4Action1.Click += (Object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(ContactActivity));
                intent.PutExtra("businessline", "Vía 40");
               
                StartActivity(intent);
            };
            imageViewBusiness4Action2.Click += (Object sender, EventArgs e) =>
            {
                try
                {
                    Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=01");
                    var uri = Android.Net.Uri.Parse("tel:" + lineas.Telefono);
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {

                }
            };
            imageViewBusiness4Action3.Click += (Object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(MapsActivity));
                intent.PutExtra("longitude", 11.033809);
                intent.PutExtra("latitude", -74.815730);
                intent.PutExtra("title", "Vía 40");
                StartActivity(intent);
            };
            imageViewBusiness4Action4.Click += (Object sender, EventArgs e) =>
            {
                try
                {
                    Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=07");
                    var uri = Android.Net.Uri.Parse(galeria.Pdf);
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    
                }
            };
            var imageViewBusinessLineFacebook = FindViewById<ImageView>(Resource.Id.imageViewBusinessLineFacebook);
            imageViewBusinessLineFacebook.Click += (object sender, EventArgs e) =>
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
            var ImageViewBusinessLineInstagram = FindViewById<ImageView>(Resource.Id.imageViewBusinessLineInstagram);
            ImageViewBusinessLineInstagram.Click += (object sender, EventArgs e) =>
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
            var ImageViewBusinessLineLinkdln = FindViewById<ImageView>(Resource.Id.imageViewBusinessLineLinkdln);
            ImageViewBusinessLineLinkdln.Click += (object sender, EventArgs e) =>
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
            var ImageViewBusinessLineYoutube = FindViewById<ImageView>(Resource.Id.imageViewBusinessLineYoutube);
            ImageViewBusinessLineYoutube.Click += (object sender, EventArgs e) =>
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
            ImageViewBusiness4.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    var uri = Android.Net.Uri.Parse("https://pactia.com/activo/logika-via-40/");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
                catch (Exception)
                {
                    SimpleToast("Ha ocurrido un error al intentar abrir en enlace.");
                }
            };
            #endregion

            LoadTextViewText(TextViewBusinessLineContentTitle, "Parques Industriales");
            BusinessName = "Logistica";
            if (BusinessName == "Logistica")
            {
                IsInternetConnectionAvailable = sharedFunctions.CheckInternetConnection();
                if (IsInternetConnectionAvailable == true)
                {
                    try
                    {
                        Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=01");
                        LoadTextViewText(TextViewBusinessLineContentTitle, lineas.Nombre);
                        LoadTextViewText(TextViewBusiness1Description, lineas.Texto2);
                        LoadTextViewText(TextViewPactiaMapTitle, "Parques Industriales");

                        List<Galeria> listaGaleria = service.HttpGet<List<Galeria>>(constants.Url, constants.GaleriaController, constants.GaleriaMethod1, "idProyecto=1&slider=1");
                        int num = 0;
                        if (listaGaleria != null && listaGaleria.Count > 0)
                        {
                            foreach (var galeria in listaGaleria)
                            {
                                if (num == 0)
                                {
                                    LoadData(07, ImageViewBusiness1, BusinessValues, ItemsList, TextViewBusiness1Title, TextViewBusinessSkill1, TextViewBusinessSkill2, TextViewBusinessSkill3, TextViewBusinessSkill4, galeria);

                                    num++;
                                }
                                else if (num == 1)
                                {
                                    LoadData(10, ImageViewBusiness2, BusinessValues, ItemsList, TextViewBusiness2Title, TextViewBusiness2Skill1, TextViewBusiness2Skill2, TextViewBusiness2Skill3, TextViewBusiness2Skill4, galeria);
                                    num++;
                                }
                                else if (num == 2)
                                {
                                    LoadData(14, ImageViewBusiness3, BusinessValues, ItemsList, TextViewBusiness3Title, TextViewBusiness3Skill1, TextViewBusiness3Skill2, TextViewBusiness3Skill3, TextViewBusiness3Skill4, galeria);
                                    num++;
                                }
                                else if (num == 3)
                                {
                                    LoadData(12, ImageViewBusiness4, BusinessValues, ItemsList, TextViewBusiness4Title, TextViewBusiness4Skill1, TextViewBusiness4Skill2, TextViewBusiness4Skill3, TextViewBusiness4Skill4, galeria);
                                    num++;
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("");
                        }
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
            }

            #region Add custom font
            Typeface GillSansFont = Typeface.CreateFromAsset(Assets, "GillSans.ttf");
            TextViewBusinessLineContentTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness1Description.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness1Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusinessSkill1.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusinessSkill2.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusinessSkill3.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusinessSkill4.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness1Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);

            TextViewBusiness2Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness2Skill1.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness2Skill2.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness2Skill3.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness2Skill4.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness2Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);

            TextViewBusiness3Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness3Skill1.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness3Skill2.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness3Skill3.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness3Skill4.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness3Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);

            TextViewBusiness4Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness4Skill1.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness4Skill2.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness4Skill3.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness4Skill4.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewBusiness4Title.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        public void AlertDialog(string title, string message)
        {
            var alertDialog = (new Android.App.AlertDialog.Builder(this)).Create();
            alertDialog.SetMessage(message);
            alertDialog.SetTitle(title);
            alertDialog.SetButton("Aceptar", handleNothingButton);
            alertDialog.SetCancelable(false);
            alertDialog.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void SimpleToast(string message)
        {
            Toast.MakeText(this, message, ToastLength.Long).Show();
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
        /// <param name="textview"></param>
        /// <param name="text"></param>
        public static void LoadTextViewText(TextView textview, string text)
        {
            textview.Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessCode"></param>
        /// <param name="imageView"></param>
        /// <param name="CompleteContent"></param>
        /// <param name="ContentList"></param>
        /// <param name="textViewBusinessTitle"></param>
        /// <param name="textView1"></param>
        /// <param name="textView2"></param>
        /// <param name="textView3"></param>
        /// <param name="textView4"></param>
        /// <param name="galeria"></param>
        public void LoadData(int businessCode, ImageView imageView, string CompleteContent, string[] ContentList, TextView textViewBusinessTitle, TextView textView1, TextView textView2, TextView textView3, TextView textView4, Galeria galeria)
        {
            int SkillNumber = 1;
            Glide.With(this)
                .Load(galeria.Url)
                .Into(imageView);
 
            LoadTextViewText(textViewBusinessTitle, galeria.Nombre);
            CompleteContent = galeria.Texto;
            ContentList = CompleteContent.Split('/');
            foreach (string Content in ContentList)
            {
                switch (SkillNumber)
                {
                    case 1:
                        textView1.Text = "•  " + Content;
                        break;
                    case 2:
                        textView2.Text = "•  " + Content;
                        break;
                    case 3:
                        textView3.Text = "•  " + Content;
                        break;
                    case 4:
                        textView4.Text = "•  " + Content;
                        break;
                    default:
                        break;
                }
                SkillNumber++;
            }
        }
    }
}