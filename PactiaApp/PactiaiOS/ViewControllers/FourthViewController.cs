using System;
using UIKit;
using MapKit;
using CoreLocation;
using System.Threading.Tasks;
using SharedContent;
using AVKit;
using FFImageLoading;
using CoreGraphics;

namespace PactiaiOS
{
    public partial class FourthViewController : UIViewController
    {
        #region Variables
        LoadingIndicator loadingIndicator;
        AVPlayerViewController PlayerViewController = new AVPlayerViewController();
        bool SwitchContactAcceptConditionState;
        bool IsInternetConnectionAvailable;
        public string Name;
        Service service = new Service();
        Constants constants = new Constants();
        #endregion

        protected FourthViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLayoutSubviews()
        {
            //base.ViewDidLayoutSubviews();
            //try
            //{
            //    float scrollViewHeight = 0.0f;
            //    float scrollViewWidth = 0.0f;
            //    foreach (UIView view in ScrollViewAbout.Subviews)
            //    {
            //        scrollViewWidth += (float)view.Frame.Size.Width;
            //        scrollViewHeight += (float)view.Frame.Size.Height;
            //    }
            //    ScrollViewAbout.ContentSize = new CGSize(0, scrollViewHeight + View.Frame.Height);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message + ex.StackTrace);
            //}
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            System.Text.Encoding.GetEncoding (1252);
            ScrollViewAbout.ContentSize = new CGSize(0, View.Frame.Height + 1000);
            UIButtonPactiaCom.AddTarget(ButtonEventHandler, UIControlEvent.TouchUpInside);
            UIButtonContactSend.AddTarget(ButtonEventHandler, UIControlEvent.TouchUpInside);
            UIButtonAccepConditions.AddTarget(ButtonEventHandler, UIControlEvent.TouchUpInside);
            UIButtonCallUs.AddTarget(ButtonEventHandler, UIControlEvent.TouchUpInside);

            #region Gestures
            UITapGestureRecognizer UIViewBusiness0Tap = new UITapGestureRecognizer(() =>
            {
                VideoViewController viewController = this.Storyboard.InstantiateViewController("VideoViewControllerId") as VideoViewController;
                this.NavigationController.PushViewController(viewController, true);
            });
            UIImageViewPactiaVideo.UserInteractionEnabled = true;
            UIImageViewPactiaVideo.AddGestureRecognizer(UIViewBusiness0Tap);

            UITapGestureRecognizer UIViewFacebookTap = new UITapGestureRecognizer(() => 
            {
                iOSFunctions.OpenUrl(@"https://www.facebook.com/pactiaoficial/");
            });
            UIImageViewFacebook.UserInteractionEnabled = true;
            UIImageViewFacebook.AddGestureRecognizer(UIViewFacebookTap);

            UITapGestureRecognizer UIViewInstagramTap = new UITapGestureRecognizer(() =>
            {
                iOSFunctions.OpenUrl(@"https://www.instagram.com/pactiaoficial/");
            });
            UIImageViewInstagram.UserInteractionEnabled = true;
            UIImageViewInstagram.AddGestureRecognizer(UIViewInstagramTap);

            UITapGestureRecognizer UIViewLinkedlnTap = new UITapGestureRecognizer(() =>
            {
                iOSFunctions.OpenUrl(@"https://www.linkedin.com/company/pactia");
            });
            UIImageViewLinkedln.UserInteractionEnabled = true;
            UIImageViewLinkedln.AddGestureRecognizer(UIViewLinkedlnTap);

            UITapGestureRecognizer UIViewYoutubeTap = new UITapGestureRecognizer(() =>
            {
                iOSFunctions.OpenUrl(@"https://www.youtube.com/channel/UCFH_l8cOLR-1FiS021ena2Q");
            });
            UIImageViewYoutube.UserInteractionEnabled = true;
            UIImageViewYoutube.AddGestureRecognizer(UIViewYoutubeTap);

            UITapGestureRecognizer UIViewBusiness2Tap = new UITapGestureRecognizer(() =>
            {
                iOSFunctions.OpenUrl(@"https://pactia.com/linea-negocio/comercio/");
            });
            UIViewBusiness2.UserInteractionEnabled = true;
            UIViewBusiness2.AddGestureRecognizer(UIViewBusiness2Tap);

            UITapGestureRecognizer UIViewBusiness3Tap = new UITapGestureRecognizer(() =>
            {
                iOSFunctions.OpenUrl(@"https://pactia.com/linea-negocio/oficinas/");
            });
            UIViewBusiness3.UserInteractionEnabled = true;
            UIViewBusiness3.AddGestureRecognizer(UIViewBusiness3Tap);
            UITapGestureRecognizer UIViewBusiness4Tap = new UITapGestureRecognizer(() =>
            {
                iOSFunctions.OpenUrl(@"https://pactia.com/linea-negocio/autoalmacenamiento/");
            });
            UIViewBusiness4.UserInteractionEnabled = true;
            UIViewBusiness4.AddGestureRecognizer(UIViewBusiness4Tap);
            UITapGestureRecognizer UIViewBusiness5Tap = new UITapGestureRecognizer(() =>
            {
                iOSFunctions.OpenUrl(@"https://pactia.com/linea-negocio/hoteles/");
            });
            UIViewBusiness5.UserInteractionEnabled = true;
            UIViewBusiness5.AddGestureRecognizer(UIViewBusiness5Tap);
            UITapGestureRecognizer UIViewBusiness6Tap = new UITapGestureRecognizer(() =>
            {
                iOSFunctions.OpenUrl(@"https://pactia.com/linea-negocio/multifamily/");
            });
            UIViewBusiness6.UserInteractionEnabled = true;
            UIViewBusiness6.AddGestureRecognizer(UIViewBusiness6Tap);

            UITapGestureRecognizer UIViewBusiness7Tap = new UITapGestureRecognizer(() =>
            {
                BusinessLineContectViewController viewController = this.Storyboard.InstantiateViewController("BusinessLineContectViewControllerId") as BusinessLineContectViewController;
                viewController.BusinessName = "Logistica";
                viewController.Latitude = "4.760737";
                viewController.Longitude = "-74.165095";
                this.NavigationController.PushViewController(viewController, true);
            });
            UIViewBusiness1.UserInteractionEnabled = true;
            UIViewBusiness1.AddGestureRecognizer(UIViewBusiness7Tap);

           

            this.View.AddGestureRecognizer(new UITapGestureRecognizer(tap =>
            {
                View.EndEditing(true);
            })
            {
                NumberOfTapsRequired = 1
            });
            #endregion

            IsInternetConnectionAvailable = SharedFunctions.CheckInternetConnection();
            if (IsInternetConnectionAvailable == true)
            {        
                try
                {         
                    var bounds = UIScreen.MainScreen.Bounds;
                    loadingIndicator = new LoadingIndicator(bounds, "Cargando contenido...");
                    View.Add(loadingIndicator);
                    await Task.Delay(10);
                    LoadUILabelText(UILabelPactiaTitle, "CONÓCENOS");
                    UIImageViewPactiaVideo.Image = UIImage.FromFile("videobackground.jpg");

                    Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=01");
                    ImageService.Instance.LoadUrl(galeria.Url).Into(UIImageViewBusiness1);
                    Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=01");
                    LoadUILabelText(UILabelBusiness1Title, lineas.Nombre);
                    LoadUILabelText(UILabelBusiness1Description, lineas.Texto2);
                    UIImageViewBusiness1Logo.Image = UIImage.FromFile("logikalogo.png");

                    galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=02");
                    ImageService.Instance.LoadUrl(galeria.Url).Into(UIImageViewBusiness2);
                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=02");
                    LoadUILabelText(UILabelBusiness2Title, lineas.Nombre);
                    LoadUILabelText(UILabelBusiness2Description, lineas.Texto2);
                    UIImageViewBusiness2Logo.Image = UIImage.FromFile("logogranplaza.png");

                    galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=03");  
                    ImageService.Instance.LoadUrl(galeria.Url).Into(UIImageViewBusiness3);
                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=03");
                    LoadUILabelText(UILabelBusiness3Title, lineas.Nombre);
                    LoadUILabelText(UILabelBusiness3Description, lineas.Texto2);
                    UIImageViewBusiness3Logo.Image = UIImage.FromFile("burologo.png");

                    galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=77");
                    ImageService.Instance.LoadUrl(galeria.Url).Into(UIImageViewBusiness4);
                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=05");
                    LoadUILabelText(UILabelBusiness4Title, lineas.Nombre);
                    LoadUILabelText(UILabelBusiness4Description, lineas.Texto2);
                    UIImageViewBusiness4Logo.Image = UIImage.FromFile("ustoragelogo.png");

                    galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=04");
                    ImageService.Instance.LoadUrl(galeria.Url).Into(UIImageViewBusiness5);
                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=04");
                    LoadUILabelText(UILabelBusiness5Title, lineas.Nombre);
                    LoadUILabelText(UILabelBusiness5Description, lineas.Texto2);

                    galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=78");
                    ImageService.Instance.LoadUrl(galeria.Url).Into(UIImageViewBusiness6);
                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=07");
                    LoadUILabelText(UILabelBusiness6Title, lineas.Nombre);
                    LoadUILabelText(UILabelBusiness6Description, lineas.Texto2);
                    UIButtonPactiaCom.Hidden = false;

                    var Panama = new MKPointAnnotation();
                    var PanamaCoord = new CLLocationCoordinate2D(9.131443, -79.681025);
                    Panama.Title = "Panamá";
                    Panama.Coordinate = PanamaCoord;

                    var Colombia = new MKPointAnnotation();
                    var ColombiaCoord = new CLLocationCoordinate2D(5.156853, -74.039258);
                    Colombia.Title = "Colombia";
                    Colombia.Coordinate = ColombiaCoord;

                    var Usa = new MKPointAnnotation();
                    var UsaCoord = new CLLocationCoordinate2D(40.343302, -102.066399);
                    Usa.Title = "Estados Unidos";
                    Usa.Coordinate = UsaCoord;

                    MKPointAnnotation[] CoordArray = new MKPointAnnotation[3];
                    CoordArray[0] = Panama;
                    CoordArray[1] = Colombia;
                    CoordArray[2] = Usa;
                    MKMapViewAbout.AddAnnotations(CoordArray);

                    var locationCoordinate = new CLLocationCoordinate2D(25.688297, -100.324346);
                    var coordinateSpan = new MKCoordinateSpan(50, 80);
                    var coordinateRegion = new MKCoordinateRegion(locationCoordinate, coordinateSpan);
                    MKMapViewAbout.SetRegion(coordinateRegion, true);
                    loadingIndicator.Hide();
                }
                catch (Exception ex)
                {
                    ExceptionAlert("Alerta", ex.Message);
                }
            }
            else
            {
                var okCancelAlertController = UIAlertController.Create("Alerta", "Por favor verifique su conexión a internet e intenta nuevamente", UIAlertControllerStyle.Alert);
                okCancelAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, alert => Environment.Exit(0)));
                PresentViewController(okCancelAlertController, true, null);
            }
            float scrollViewHeight = 0.0f;
            float scrollViewWidth = 0.0f;
            foreach (UIView view in ScrollViewAbout.Subviews)
            {
                scrollViewWidth += (float)view.Frame.Size.Width;
                scrollViewHeight += (float)view.Frame.Size.Height;
            }
            ScrollViewAbout.ContentSize = new CGSize(0, scrollViewHeight + View.Frame.Height + 1500);          
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        #region Event Handlers
        private async void ButtonEventHandler(object sender, EventArgs e)
        {
            if (sender == UIButtonPactiaCom)
            {
                iOSFunctions.OpenUrl(@"http://pactia.com");
            }
            else if (sender == UIButtonCallUs)
            {
                Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=06");
                iOSFunctions.CallPhone("tel:" + lineas.Telefono);
            }
            else if (sender == UIButtonAccepConditions)
            {
                iOSFunctions.OpenUrl(@"http://pactia.com/wp-content/uploads/2017/10/politica-proteccion_datos.pdf");
            }
            else if (sender == UIButtonContactSend)
            {
                if (SharedFunctions.IsEmptyOrNullString(UITextFileldContactEmail.Text) == true || SharedFunctions.IsEmptyOrNullString(UITextFieldContactUser.Text) == true || SharedFunctions.IsEmptyOrNullString(UITextFileldContactBusinessName.Text) == true || SharedFunctions.IsEmptyOrNullString(UITextFileldContactMessage.Text) == true || SharedFunctions.IsEmptyOrNullString(UITextFileldContactPhoneNumber.Text) == true)
                {
                    SimpleAlert("Notificación", "Debe completar los campos");
                }              
                else
                {
                    if (SwitchContactAcceptConditionState == true)
                    {
                        IsInternetConnectionAvailable = SharedFunctions.CheckInternetConnection();
                        if (IsInternetConnectionAvailable == true)
                        {
                            try
                            {
                                string MailState = string.Empty;
                                var bounds = UIScreen.MainScreen.Bounds;
                                loadingIndicator = new LoadingIndicator(bounds, "Enviando mensaje...");
                                View.Add(loadingIndicator);
                                await Task.Delay(100);
                                Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=06");
                                MailState = SharedFunctions.SendEmail("Información sobre portafolio ", "Nombre:  " + UITextFieldContactUser.Text + Environment.NewLine + "Funcionario de la empresa: " + UITextFileldContactBusinessName.Text + Environment.NewLine + "Nos pueden contactar via Email: " + UITextFileldContactEmail.Text + Environment.NewLine + "Teléfono: " + UITextFileldContactPhoneNumber.Text + Environment.NewLine + "Mensaje: " + UITextFileldContactMessage.Text + Environment.NewLine + Environment.NewLine, lineas.Email, lineas.EmailRemitente, lineas.Clave, lineas.Smtp);
                                loadingIndicator.Hide();
                                SimpleAlert("Notificación", MailState);
                                UITextFieldContactUser.Text = "";
                                UITextFileldContactBusinessName.Text = "";
                                UITextFileldContactMessage.Text = "";
                                UITextFileldContactEmail.Text = "";
                                UITextFileldContactPhoneNumber.Text = "";
                            }
                            catch (Exception ex)
                            {
                                ExceptionAlert("Alerta",ex.Message);
                            }
                        }
                        else
                        {
                            SimpleAlert("Alerta", "Por favor verifique su conexión a internet e intenta nuevamente");
                        }
                    }
                    else
                    {
                        SimpleAlert("Notificación", "Antes de continuar debe aceptar las políticas de tratamiento de datos personales");
                    }
                }
            }
        }

        partial void UISwitchContactAcceptConditionsChanged(UISwitch sender)
        {
            SwitchContactAcceptConditionState = UISwitchContactAcceptConditions.On;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Simples the alert.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="message">Message.</param>
        public void SimpleAlert(string title, string message)
        {
            var okAlertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            okAlertController.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Default, null));
            PresentViewController(okAlertController, true, null);
        }

        /// <summary>
        /// Exceptions the alert.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="message">Message.</param>
        public void ExceptionAlert(string title, string message)
        {
            var okCancelAlertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            okCancelAlertController.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Cancel, alert => Environment.Exit(0)));
            PresentViewController(okCancelAlertController, true, null);
        }

        /// <summary>
        /// Loads the UIL abel text.
        /// </summary>
        /// <param name="label">Label.</param>
        /// <param name="text">Text.</param>
        public void LoadUILabelText(UILabel label, string text)
        {
            label.Text = text;
        }
        #endregion
    }
}
