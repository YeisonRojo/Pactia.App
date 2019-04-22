using CoreGraphics;
using FFImageLoading;
using PactiaiOS.ViewControllers;
using SharedContent;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;

namespace PactiaiOS
{
    public partial class BusinessLineContectViewController : UIViewController
    {
        #region Variables
        public string BusinessName = string.Empty, Latitude = string.Empty, Longitude = string.Empty, BusinessValues = String.Empty;
        private string[] ItemsList = null;
        LoadingIndicator loadingIndicator;
        bool IsInternetConnectionAvailable;
        Service service = new Service();
        Constants constants = new Constants();
        #endregion

        public BusinessLineContectViewController(IntPtr handle) : base(handle)
        {

        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            UIScrollViewBusinessContent.ContentSize = new CoreGraphics.CGSize(0, View.Frame.Height + 5100);
            IsInternetConnectionAvailable = SharedFunctions.CheckInternetConnection();
            if (IsInternetConnectionAvailable == true)
            {
                var bounds = UIScreen.MainScreen.Bounds;
                loadingIndicator = new LoadingIndicator(bounds, "Cargando contenido...");
                View.Add(loadingIndicator);
                await Task.Delay(15);
                if (BusinessName == "Logistica")
                {
                    Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=01");              
                    LoadUILabelText(UILabelBusinessContentTitle, lineas.Nombre);
                    LoadUILabelText(UILabelBusinessContentDescription, lineas.Texto2);
                    LoadUILabelText(UILabelBusinessContentSubTitle, "Parques Industriales");
                    UIImageViewBusinessContentLogo.Image = UIImage.FromFile("logikalogo.png");
                    UIImageViewBusinessContentFacebook.Image = UIImage.FromFile("facebook.png");
                    UIImageViewBusinessContentInstagram.Image = UIImage.FromFile("instagram.png");
                    UIImageViewBusinessContentLinkdln.Image = UIImage.FromFile("linkedin.png");
                    UIImageViewBusinessContentYoutube.Image = UIImage.FromFile("youtube.png");
                    List<Galeria> listaGaleria = service.HttpGet<List<Galeria>>(constants.Url, constants.GaleriaController, constants.GaleriaMethod1, "idProyecto=1&slider=1");
                    int LoadNumber = 0;
                    if (listaGaleria != null && listaGaleria.Count > 0)
                    {
                        foreach (var galeria in listaGaleria)
                        {
                            if (LoadNumber == 0)
                            {
                                LoadData("code=07", UIImageViewBusiness1, BusinessValues, ItemsList, UILabelBusiness1SubTitle1, UILabelBusiness1Skill1, UILabelBusiness1Skill2, UILabelBusiness1Skill3, UILabelBusiness1Skill4, galeria);
                                LoadNumber++;
                            }
                            else if (LoadNumber == 1)
                            {
                                LoadData("code=10", UIImageViewBusiness2, BusinessValues, ItemsList, UILabelBusiness2SubTitle1, UILabelBusiness2Skill1, UILabelBusiness2Skill2, UILabelBusiness2Skill3, UILabelBusiness2Skill4, galeria);
                                LoadNumber++;
                            }
                            else if (LoadNumber == 2)
                            {
                                LoadData("code=14", UIImageViewBusiness3, BusinessValues, ItemsList, UILabelBusiness3SubTitle1, UILabelBusiness3Skill1, UILabelBusiness3Skill2, UILabelBusiness3Skill3, UILabelBusiness3Skill4, galeria);
                                LoadNumber++;
                            }
                            else if (LoadNumber == 3)
                            {
                                LoadData("code=12", UIImageViewBusiness4, BusinessValues, ItemsList, UILabelBusiness4SubTitle1, UILabelBusiness4Skill1, UILabelBusiness4Skill2, UILabelBusiness4Skill3, UILabelBusiness4Skill4, galeria);
                                LoadNumber++;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("");
                    }
                    UITapGestureRecognizer UIImageViewTap1 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            iOSFunctions.OpenUrl(@"https://pactia.com/activo/logika-siberia-12/");
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el sitio web");
                        }
                    });

                    UITapGestureRecognizer UIViewFacebookTap = new UITapGestureRecognizer(() =>
                    {
                        iOSFunctions.OpenUrl(@"https://www.facebook.com/pactiaoficial/");
                    });
                    UIImageViewBusinessContentFacebook.UserInteractionEnabled = true;
                    UIImageViewBusinessContentFacebook.AddGestureRecognizer(UIViewFacebookTap);

                    UITapGestureRecognizer UIViewInstagramTap = new UITapGestureRecognizer(() =>
                    {
                        iOSFunctions.OpenUrl(@"https://www.instagram.com/pactiaoficial/");
                    });
                    UIImageViewBusinessContentInstagram.UserInteractionEnabled = true;
                    UIImageViewBusinessContentInstagram.AddGestureRecognizer(UIViewInstagramTap);

                    UITapGestureRecognizer UIViewLinkedlnTap = new UITapGestureRecognizer(() =>
                    {
                        iOSFunctions.OpenUrl(@"https://www.linkedin.com/company/pactia");
                    });
                    UIImageViewBusinessContentLinkdln.UserInteractionEnabled = true;
                    UIImageViewBusinessContentLinkdln.AddGestureRecognizer(UIViewLinkedlnTap);

                    UITapGestureRecognizer UIViewYoutubeTap = new UITapGestureRecognizer(() =>
                    {
                        iOSFunctions.OpenUrl(@"https://www.youtube.com/channel/UCFH_l8cOLR-1FiS021ena2Q");
                    });
                    UIImageViewBusinessContentYoutube.UserInteractionEnabled = true;
                    UIImageViewBusinessContentYoutube.AddGestureRecognizer(UIViewYoutubeTap);
                   
                    UIImageViewBusiness1.UserInteractionEnabled = true;
                    UIImageViewBusiness1.AddGestureRecognizer(UIImageViewTap1);

                    UITapGestureRecognizer UIImageViewTap2 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            iOSFunctions.OpenUrl(@"https://pactia.com/activo/logika-siberia-12-2/");
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el enlace");
                        }
                    });
                    UIImageViewBusiness2.UserInteractionEnabled = true;
                    UIImageViewBusiness2.AddGestureRecognizer(UIImageViewTap2);

                    UITapGestureRecognizer UIImageViewTap3 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            iOSFunctions.OpenUrl(@"https://pactia.com/activo/parque-industrial-san-carlos-i/");
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el enlace");
                        }
                    });
                    UIImageViewBusiness3.UserInteractionEnabled = true;
                    UIImageViewBusiness3.AddGestureRecognizer(UIImageViewTap3);

                    UITapGestureRecognizer UIImageViewTap4 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            iOSFunctions.OpenUrl(@"https://pactia.com/activo/logika-via-40/");
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el enlace");
                        }
                    });
                    UIImageViewBusiness4.UserInteractionEnabled = true;
                    UIImageViewBusiness4.AddGestureRecognizer(UIImageViewTap4);

                    #region Gestures business1
                    UITapGestureRecognizer UIImageViewTap1Action1Business1 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            ContactViewController viewController = this.Storyboard.InstantiateViewController("ContactViewControllerId") as ContactViewController;
                            viewController.BusinessLine="Logística y almacenamiento";
                            viewController.SubBusinessLine="Lógika Siberia";
                            this.NavigationController.PushViewController(viewController, true);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction1Business1.UserInteractionEnabled = true;
                    UIImageViewAction1Business1.AddGestureRecognizer(UIImageViewTap1Action1Business1);

                    UITapGestureRecognizer UIImageViewTap2Action2Business1 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=01");
                            iOSFunctions.CallPhone("tel:" + lineas.Telefono);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction2Business1.UserInteractionEnabled = true;
                    UIImageViewAction2Business1.AddGestureRecognizer(UIImageViewTap2Action2Business1);

                    UITapGestureRecognizer UIImageViewTap3Action3Business1 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            MapsViewController viewController = this.Storyboard.InstantiateViewController("MapsViewControllerId") as MapsViewController;
                            viewController.AnnotationTitle = "Lógika Siberia";
                            viewController.LocationLatitude = 4.760737;
                            viewController.LocationLongitude = -74.165095;
                            this.NavigationController.PushViewController(viewController, true);
                           
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction3Business1.UserInteractionEnabled = true;
                    UIImageViewAction3Business1.AddGestureRecognizer(UIImageViewTap3Action3Business1);

                    UITapGestureRecognizer UIImageViewTap4Action4Business1 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=07");
                            iOSFunctions.OpenUrl(galeria.Pdf);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el enlace");
                        }
                    });
                    UIImageViewAction4Business1.UserInteractionEnabled = true;
                    UIImageViewAction4Business1.AddGestureRecognizer(UIImageViewTap4Action4Business1);

                    UITapGestureRecognizer UIImageViewTap5Action5Business1 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            iOSFunctions.OpenUrl(@"https://logika.hauzd.com/logikasiberia");
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el enlace");
                        }
                    });
                    UIImageViewAction5Business1.UserInteractionEnabled = true;
                    UIImageViewAction5Business1.AddGestureRecognizer(UIImageViewTap5Action5Business1);

                    UITapGestureRecognizer UIImageViewTap6Action6Business1 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            PanoramaViewController viewController = this.Storyboard.InstantiateViewController("PanoramaViewControllerId") as PanoramaViewController;
                            viewController.SelectionNumber = 0;
                            this.NavigationController.PushViewController(viewController, true);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction6Business1.UserInteractionEnabled = true;
                    UIImageViewAction6Business1.AddGestureRecognizer(UIImageViewTap6Action6Business1);
                    #endregion

                    #region Gestures business2
                    UITapGestureRecognizer UIImageViewTap1Action1Business2 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            ContactViewController viewController = this.Storyboard.InstantiateViewController("ContactViewControllerId") as ContactViewController;
                            viewController.BusinessLine="Logística y almacenamiento";
                            viewController.SubBusinessLine="Lógika Madrid";
                            this.NavigationController.PushViewController(viewController, true);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction1Business2.UserInteractionEnabled = true;
                    UIImageViewAction1Business2.AddGestureRecognizer(UIImageViewTap1Action1Business2);

                    UITapGestureRecognizer UIImageViewTap2Action2Business2 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=01");
                            iOSFunctions.CallPhone("tel:" + lineas.Telefono);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction2Business2.UserInteractionEnabled = true;
                    UIImageViewAction2Business2.AddGestureRecognizer(UIImageViewTap2Action2Business2);

                    UITapGestureRecognizer UIImageViewTap3Action3Business2 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            MapsViewController viewController = this.Storyboard.InstantiateViewController("MapsViewControllerId") as MapsViewController;
                            viewController.AnnotationTitle = "Lógika Madrid";
                            viewController.LocationLatitude = 4.742864;
                            viewController.LocationLongitude = -74.256246;
                            this.NavigationController.PushViewController(viewController, true);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction3Business2.UserInteractionEnabled = true;
                    UIImageViewAction3Business2.AddGestureRecognizer(UIImageViewTap3Action3Business2);

                    UITapGestureRecognizer UIImageViewTap4Action4Business2 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=07");
                            iOSFunctions.OpenUrl(galeria.Pdf);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el enlace");
                        }
                    });
                    UIImageViewAction4Business2.UserInteractionEnabled = true;
                    UIImageViewAction4Business2.AddGestureRecognizer(UIImageViewTap4Action4Business2);

                    UITapGestureRecognizer UIImageViewTap5Action5Business2 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                           
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction5Business2.UserInteractionEnabled = true;
                    UIImageViewAction5Business2.AddGestureRecognizer(UIImageViewTap5Action5Business2);

                    UITapGestureRecognizer UIImageViewTap6Action6Business2 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            PanoramaViewController viewController = this.Storyboard.InstantiateViewController("PanoramaViewControllerId") as PanoramaViewController;
                            viewController.SelectionNumber = 1;
                            this.NavigationController.PushViewController(viewController, true);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction6Business2.UserInteractionEnabled = true;
                    UIImageViewAction6Business2.AddGestureRecognizer(UIImageViewTap6Action6Business2);

                    #endregion

                    #region Gestures business3
                    UITapGestureRecognizer UIImageViewTap1Action1Business3 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            ContactViewController viewController = this.Storyboard.InstantiateViewController("ContactViewControllerId") as ContactViewController;
                            viewController.BusinessLine="Logística y almacenamiento";
                            viewController.SubBusinessLine="San Carlos I";
                            this.NavigationController.PushViewController(viewController, true);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction1Business3.UserInteractionEnabled = true;
                    UIImageViewAction1Business3.AddGestureRecognizer(UIImageViewTap1Action1Business3);

                    UITapGestureRecognizer UIImageViewTap2Action2Business3 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=01");
                            iOSFunctions.CallPhone("tel:" + lineas.Telefono);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction2Business3.UserInteractionEnabled = true;
                    UIImageViewAction2Business3.AddGestureRecognizer(UIImageViewTap2Action2Business3);

                    UITapGestureRecognizer UIImageViewTap3Action3Business3 = new UITapGestureRecognizer(() =>
                    {           
                        try
                        {
                            MapsViewController viewController = this.Storyboard.InstantiateViewController("MapsViewControllerId") as MapsViewController;
                            viewController.AnnotationTitle = "San Carlos I";
                            viewController.LocationLatitude = 4.700809;
                            viewController.LocationLongitude = -74.184920;
                            this.NavigationController.PushViewController(viewController, true);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction3Business3.UserInteractionEnabled = true;
                    UIImageViewAction3Business3.AddGestureRecognizer(UIImageViewTap3Action3Business3);

                    UITapGestureRecognizer UIImageViewTap4Action4Business3 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=07");
                            iOSFunctions.OpenUrl(galeria.Pdf);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el enlace");
                        }
                    });
                    UIImageViewAction4Business3.UserInteractionEnabled = true;
                    UIImageViewAction4Business3.AddGestureRecognizer(UIImageViewTap4Action4Business3);

                    UITapGestureRecognizer UIImageViewTap5Action5Business3 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {

                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction5Business3.UserInteractionEnabled = true;
                    UIImageViewAction5Business3.AddGestureRecognizer(UIImageViewTap5Action5Business3);

                    UITapGestureRecognizer UIImageViewTap6Action6Business3 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {

                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction6Business3.UserInteractionEnabled = true;
                    UIImageViewAction6Business3.AddGestureRecognizer(UIImageViewTap6Action6Business3);
                    #endregion

                    #region Gestures business4
                    UITapGestureRecognizer UIImageViewTap1Action1Business4 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            ContactViewController viewController = this.Storyboard.InstantiateViewController("ContactViewControllerId") as ContactViewController;
                            viewController.BusinessLine="Logística y almacenamiento";
                            viewController.SubBusinessLine="Vía 40";
                            this.NavigationController.PushViewController(viewController, true);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction1Business4.UserInteractionEnabled = true;
                    UIImageViewAction1Business4.AddGestureRecognizer(UIImageViewTap1Action1Business4);

                    UITapGestureRecognizer UIImageViewTap2Action2Business4 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=01");
                            iOSFunctions.CallPhone("tel:" + lineas.Telefono);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction2Business4.UserInteractionEnabled = true;
                    UIImageViewAction2Business4.AddGestureRecognizer(UIImageViewTap2Action2Business4);

                    UITapGestureRecognizer UIImageViewTap3Action3Business4 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            MapsViewController viewController = this.Storyboard.InstantiateViewController("MapsViewControllerId") as MapsViewController;
                            viewController.AnnotationTitle = "Vía 40";
                            viewController.LocationLatitude = 11.033809;
                            viewController.LocationLongitude = -74.815730;
                            this.NavigationController.PushViewController(viewController, true);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction3Business4.UserInteractionEnabled = true;
                    UIImageViewAction3Business4.AddGestureRecognizer(UIImageViewTap3Action3Business4);

                    UITapGestureRecognizer UIImageViewTap4Action4Business4 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {
                            Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=07");
                            iOSFunctions.OpenUrl(galeria.Pdf);
                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el enlace");
                        }
                    });
                    UIImageViewAction4Business4.UserInteractionEnabled = true;
                    UIImageViewAction4Business4.AddGestureRecognizer(UIImageViewTap4Action4Business4);

                    UITapGestureRecognizer UIImageViewTap5Action5Business4 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {

                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction5Business4.UserInteractionEnabled = true;
                    UIImageViewAction5Business4.AddGestureRecognizer(UIImageViewTap5Action5Business4);

                    UITapGestureRecognizer UIImageViewTap6Action6Business4 = new UITapGestureRecognizer(() =>
                    {
                        try
                        {

                        }
                        catch (Exception)
                        {
                            SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                        }
                    });
                    UIImageViewAction6Business4.UserInteractionEnabled = true;
                    UIImageViewAction6Business4.AddGestureRecognizer(UIImageViewTap6Action6Business4);
                    #endregion

                }
                else
                {
                    var okCancelAlertController = UIAlertController.Create("Alerta", "El servicio no está disponible en el momento, intente de nuevo más tarde", UIAlertControllerStyle.Alert);
                    okCancelAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, alert => Environment.Exit(0)));
                    PresentViewController(okCancelAlertController, true, null);
                }
                loadingIndicator.Hide();
            }
            else
            {
                var okCancelAlertController = UIAlertController.Create("Alerta", "Por favor verifique su conexión a internet e intenta nuevamente", UIAlertControllerStyle.Alert);
                okCancelAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, alert => Environment.Exit(0)));
                PresentViewController(okCancelAlertController, true, null);
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        #region Methods

        /// <summary>
        /// Loads the contebt text in UILabel.
        /// </summary>
        /// <param name="label">Label.</param>
        /// <param name="text">Text.</param>
        public void LoadUILabelText(UILabel label, string text)
        {
            label.Text = text;
        }

        /// <summary>
        /// Show alert message.
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
        /// Loads the data in the view.
        /// </summary>
        /// <param name="businessCode">Business code.</param>
        /// <param name="uIImageView">U II mage view.</param>
        /// <param name="CompleteContent">Complete content.</param>
        /// <param name="ContentList">Content list.</param>
        /// <param name="uILabelBusinessTitle">U IL abel business title.</param>
        /// <param name="uILabel1">U IL abel1.</param>
        /// <param name="uILabel2">U IL abel2.</param>
        /// <param name="uILabel3">U IL abel3.</param>
        /// <param name="uILabel4">U IL abel4.</param>
        public void LoadData(string businessCode, UIImageView uIImageView, string CompleteContent, string[] ContentList, UILabel uILabelBusinessTitle, UILabel uILabel1, UILabel uILabel2, UILabel uILabel3, UILabel uILabel4, Galeria galeria)
        {
            int SkillNumber = 1;
            ImageService.Instance.LoadUrl(galeria.Url).Into(uIImageView);
            LoadUILabelText(uILabelBusinessTitle, galeria.Nombre);
            CompleteContent = galeria.Texto;
            ContentList = CompleteContent.Split("/");
            foreach (string Content in ContentList)
            {
                switch (SkillNumber)
                {
                    case 1:
                        uILabel1.Text = "• " + Content;
                        break;
                    case 2:
                        uILabel2.Text = "• " + Content;
                        break;
                    case 3:
                        uILabel3.Text = "• " + Content;
                        break;
                    case 4:
                        uILabel4.Text = "• " + Content;
                        break;
                    default:
                        break;
                }
                SkillNumber++;
            }
        }
        #endregion
    }
}