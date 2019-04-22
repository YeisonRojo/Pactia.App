using System;
using SharedContent;
using UIKit;

namespace PactiaiOS
{
    public partial class SecondViewController : UIViewController
    {
        protected SecondViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            LoadUILabelText(UILabelClientsTitle, "CLIENTE PACTIA");


            #region Gestures
            UITapGestureRecognizer UIImageViewTap1 = new UITapGestureRecognizer(() =>
            {
                try
                {
                    iOSFunctions.OpenUrl(@"http://pactia.com");
                }
                catch (Exception)
                {
                    SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el enlace");
                }
            });
            UIViewClientsPactiacom.UserInteractionEnabled = true;
            UIViewClientsPactiacom.AddGestureRecognizer(UIImageViewTap1);

            UITapGestureRecognizer UIImageViewTap2 = new UITapGestureRecognizer(() =>
            {
                Service service = new Service();
                Constants constants = new Constants();
                try
                {
                    Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=06");
                    iOSFunctions.CallPhone("tel:" + lineas.Telefono);
                }
                catch (Exception)
                {
                    SimpleAlert("Alerta", "Ha ocurrido un error al intentar realizar la llamada");
                }
            });
            UIViewClientsCall.UserInteractionEnabled = true;
            UIViewClientsCall.AddGestureRecognizer(UIImageViewTap2);

            UITapGestureRecognizer UIImageViewTap3 = new UITapGestureRecognizer(() =>
            {
                try
                {
                    ContactViewController viewController = this.Storyboard.InstantiateViewController("ContactViewControllerId") as ContactViewController;
                    viewController.BusinessLine = "Portafolio";
                    viewController.SubBusinessLine="Portafolio";
                    this.NavigationController.PushViewController(viewController, true);
                }
                catch (Exception)
                {
                    SimpleAlert("Alerta", "Ha ocurrido un error al intentar completar la acción");
                }
            });
            UIViewClientsContactUs.UserInteractionEnabled = true;
            UIViewClientsContactUs.AddGestureRecognizer(UIImageViewTap3);
            #endregion
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        #region Methods
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
