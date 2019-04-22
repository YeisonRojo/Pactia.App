using System;
using System.Threading.Tasks;
using SharedContent;
using UIKit;

namespace PactiaiOS
{
    public partial class ThridViewController : UIViewController
    {
        #region Variables
        LoadingIndicator loadingIndicator;
        bool IsInternetConnectionAvailable;
        Service service = new Service();
        #endregion

        protected ThridViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            #region Gestures
            UITapGestureRecognizer UIViewBusiness1Tap = new UITapGestureRecognizer(() =>
            {
                try
                {
                    BusinessLineContectViewController viewController = this.Storyboard.InstantiateViewController("BusinessLineContectViewControllerId") as BusinessLineContectViewController;
                    viewController.BusinessName = "Logistica";
                    viewController.Latitude = "4.760737";
                    viewController.Longitude = "-74.165095";
                    this.NavigationController.PushViewController(viewController, true);
                }
                catch (Exception)
                {
                    SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                }
            });
            UIViewPortfolioBusiness1.UserInteractionEnabled = true;
            UIViewPortfolioBusiness1.AddGestureRecognizer(UIViewBusiness1Tap);

            UITapGestureRecognizer UIViewBusiness2Tap = new UITapGestureRecognizer(() =>
            {
                try
                {
                    iOSFunctions.OpenUrl(@"https://pactia.com/linea-negocio/comercio/");
                }
                catch (Exception)
                {
                    SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                }
            });
            UIViewPortfolioBusiness2.UserInteractionEnabled = true;
            UIViewPortfolioBusiness2.AddGestureRecognizer(UIViewBusiness2Tap);

            UITapGestureRecognizer UIViewBusiness3Tap = new UITapGestureRecognizer(() =>
            {
                try
                {
                    iOSFunctions.OpenUrl(@"https://pactia.com/linea-negocio/oficinas/");
                }
                catch (Exception)
                {
                    SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                }
            });
            UIViewPortfolioBusiness3.UserInteractionEnabled = true;
            UIViewPortfolioBusiness3.AddGestureRecognizer(UIViewBusiness3Tap);

            UITapGestureRecognizer UIViewBusiness4Tap = new UITapGestureRecognizer(() =>
            {             
                try
                {
                    iOSFunctions.OpenUrl(@"https://pactia.com/linea-negocio/autoalmacenamiento/");
                }
                catch (Exception)
                {
                    SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                }
            });
            UIViewPortfolioBusiness4.UserInteractionEnabled = true;
            UIViewPortfolioBusiness4.AddGestureRecognizer(UIViewBusiness4Tap);

            UITapGestureRecognizer UIViewBusiness5Tap = new UITapGestureRecognizer(() =>
            {
                try
                {
                    iOSFunctions.OpenUrl(@"https://pactia.com/linea-negocio/hoteles/");
                }
                catch (Exception)
                {
                    SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                }
            });
            UIViewPortfolioBusiness5.UserInteractionEnabled = true;
            UIViewPortfolioBusiness5.AddGestureRecognizer(UIViewBusiness5Tap);

            UITapGestureRecognizer UIViewBusiness6Tap = new UITapGestureRecognizer(() =>
            {
                try
                {
                    iOSFunctions.OpenUrl(@"https://pactia.com/linea-negocio/multifamily/");
                }
                catch (Exception)
                {
                    SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                }
            });
            UIViewPortfolioBusiness6.UserInteractionEnabled = true;
            UIViewPortfolioBusiness6.AddGestureRecognizer(UIViewBusiness6Tap);
            #endregion

            ScrollViewPortfolio.ContentSize = new CoreGraphics.CGSize(0, View.Frame.Height);
            IsInternetConnectionAvailable = SharedFunctions.CheckInternetConnection();
            if (IsInternetConnectionAvailable == true)
            {
                Constants constants = new Constants();
                var bounds = UIScreen.MainScreen.Bounds;
                loadingIndicator = new LoadingIndicator(bounds, "Cargando contenido...");
                View.Add(loadingIndicator);
                await Task.Delay(10);
                try
                {
                    LoadUILabelText(UILabelPortfolioTitle, "PORTAFOLIO");
                    Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=01");
                    LoadUILabelText(UILabelPortfolioBusinessTitle1, lineas.Nombre);
                    LoadUILabelText(UILabelPortfolioBusinessContent1, lineas.Texto2);

                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=02");
                    LoadUILabelText(UILabelPortfolioBusinessTitle2, lineas.Nombre);
                    LoadUILabelText(UILabelPortfolioBusinessContent2, lineas.Texto2);

                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=03");
                    LoadUILabelText(UILabelPortfolioBusinessTitle3, lineas.Nombre);
                    LoadUILabelText(UILabelPortfolioBusinessContent3, lineas.Texto2);

                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=05");
                    LoadUILabelText(UILabelPortfolioBusinessTitle4, lineas.Nombre);
                    LoadUILabelText(UILabelPortfolioBusinessContent4, lineas.Texto2);

                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=04");
                    LoadUILabelText(UILabelPortfolioBusinessTitle5, lineas.Nombre);
                    LoadUILabelText(UILabelPortfolioBusinessContent5, lineas.Texto2);

                    lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=07");
                    LoadUILabelText(UILabelPortfolioBusinessTitle6, lineas.Nombre);
                    LoadUILabelText(UILabelPortfolioBusinessContent6, lineas.Texto2);

                }
                catch (Exception)
                {
                    var okCancelAlertController = UIAlertController.Create("Alerta", "El servicio no está disponible en el momento, intente de nuevo mas tarde", UIAlertControllerStyle.Alert);
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
        #endregion
    }
}

