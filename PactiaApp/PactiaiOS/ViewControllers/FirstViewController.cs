using System;
using System.Threading.Tasks;
using SharedContent;
using UIKit;

namespace PactiaiOS
{
    public partial class FirstViewController : UIViewController
    {
        #region Variables
        LoadingIndicator loadingIndicator;
        bool IsInternetConnectionAvailable;
        Service service = new Service();       
        #endregion

        protected FirstViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ScrollViewEvents.ContentSize = new CoreGraphics.CGSize(0, View.Frame.Height + 1800);
            buttonNewsEvent1Content.AddTarget(ButtonEventHandler, UIControlEvent.TouchUpInside);
            buttonNewsEvent2Content.AddTarget(ButtonEventHandler, UIControlEvent.TouchUpInside);
            buttonNewsEvent3Content.AddTarget(ButtonEventHandler, UIControlEvent.TouchUpInside);
            buttonNewsEvent4Content.AddTarget(ButtonEventHandler, UIControlEvent.TouchUpInside);
            buttonNewsEvent5Content.AddTarget(ButtonEventHandler, UIControlEvent.TouchUpInside);
            IsInternetConnectionAvailable = SharedFunctions.CheckInternetConnection();
            if (IsInternetConnectionAvailable == true)
            {
                var bounds = UIScreen.MainScreen.Bounds;
                loadingIndicator = new LoadingIndicator(bounds, "Cargando contenido...");
                View.Add(loadingIndicator);
                await Task.Delay(10);
                try
                {
                    Constants constants = new Constants();
                    LoadUILabelText(UILabelNewsTitle, "NOTICIAS");
                    Eventos eventos = service.HttpGet<Eventos>(constants.Url, constants.EventoController, constants.EventoMethod, "idEvent=1");

                    UILabelNewsEvent1Title.Text = eventos.TituloEvento;
                    UILabelNewsEvent1Date.Text = "Fecha: "+ eventos.Fecha.ToString("dd-MM-yyyy");
                    UILabelNewsEvent1Content.Text = eventos.Texto;
                    UILabelNewsEvent1Hour.Text = "Hora: " + eventos.Hora.ToString("hh:mm");
                    UILabelNewsEvent1Location.Text = "Lugar: " + eventos.Direccion;
                    UILabelNewsEvent1City.Text = "Ciudad: " + eventos.Ciudad.Nombre;
                    buttonNewsEvent1Content.Hidden = false;

                    eventos = service.HttpGet<Eventos>(constants.Url, constants.EventoController, constants.EventoMethod, "idEvent=2");
                    UILabelNewsEvent2Title.Text = eventos.TituloEvento;
                    UILabelNewsEvent2Date.Text = "Fecha: " + eventos.Fecha.ToString("dd-MM-yyyy");
                    UILabelNewsEvent2Content.Text = eventos.Texto;
                    UILabelNewsEvent2Hour.Text = "Hora: " + eventos.Hora.ToString("hh:mm");
                    UILabelNewsEvent2Location.Text = "Lugar: " + eventos.Direccion;
                    UILabelNewsEvent2City.Text = "Ciudad: " + eventos.Ciudad.Nombre;
                    buttonNewsEvent2Content.Hidden = false;

                    eventos = service.HttpGet<Eventos>(constants.Url, constants.EventoController, constants.EventoMethod, "idEvent=3");
                    UILabelNewsEvent3Title.Text = eventos.TituloEvento;
                    UILabelNewsEvent3Date.Text = "Fecha: " + eventos.Fecha.ToString("dd-MM-yyyy");
                    UILabelNewsEvent3Content.Text = eventos.Texto;
                    UILabelNewsEvent3Hour.Text = "Hora: " + eventos.Hora.ToString("hh:mm");
                    UILabelNewsEvent3Location.Text = "Lugar: " + eventos.Direccion;
                    UILabelNewsEvent3City.Text = "Ciudad: " + eventos.Ciudad.Nombre;
                    buttonNewsEvent3Content.Hidden = false;

                    eventos = service.HttpGet<Eventos>(constants.Url, constants.EventoController, constants.EventoMethod, "idEvent=5");
                    UILabelNewsEvent4Title.Text = eventos.TituloEvento;
                    UILabelNewsEvent4Date.Text = "Fecha: " + eventos.Fecha.ToString("dd-MM-yyyy");
                    UILabelNewsEvent4Content.Text = eventos.Texto;
                    UILabelNewsEvent4Hour.Text = "Hora: " + eventos.Hora.ToString("hh:mm");
                    UILabelNewsEvent4Location.Text = "Lugar: " + eventos.Direccion;
                    UILabelNewsEvent4City.Text = "Ciudad: " + eventos.Ciudad.Nombre;
                    buttonNewsEvent4Content.Hidden = false;
                          
                    eventos = service.HttpGet<Eventos>(constants.Url, constants.EventoController, constants.EventoMethod, "idEvent=4");UILabelNewsEvent5Title.Text = eventos.TituloEvento;
                    UILabelNewsEvent5Date.Text = "Fecha: " + eventos.Fecha.ToString("dd-MM-yyyy");
                    UILabelNewsEvent5Content.Text = eventos.Texto;
                    UILabelNewsEvent5Hour.Text = "Hora: " + eventos.Hora.ToString("hh:mm");
                    UILabelNewsEvent5Location.Text = "Lugar: " + eventos.Direccion;
                    UILabelNewsEvent5City.Text = "Ciudad: " + eventos.Ciudad.Nombre;
                    buttonNewsEvent5Content.Hidden = false;
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
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        #region Event Handlers
        private void ButtonEventHandler(object sender, EventArgs e)
        {
            if (sender == buttonNewsEvent1Content)
            {
                try
                {
                    iOSFunctions.OpenUrl("https://pactia.com/noticias/");
                }
                catch (Exception)
                {
                    SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el sitio web");
                }
            }
            else if (sender == buttonNewsEvent2Content)
            {
                try
                {
                    iOSFunctions.OpenUrl("https://pactia.com/noticias/");
                }
                catch (Exception)
                {
                    SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el sitio web");
                }
            }
            else if (sender == buttonNewsEvent3Content)
            {
                try
                {
                    iOSFunctions.OpenUrl("https://pactia.com/noticias/");
                }
                catch (Exception)
                {
                    SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el sitio web");
                }
            }
            else if (sender == buttonNewsEvent4Content)
            {
                try
                {
                    iOSFunctions.OpenUrl("https://pactia.com/noticias/");
                }
                catch (Exception)
                {
                    SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el sitio web");
                }
            }
            else if (sender == buttonNewsEvent5Content)
            {
                try
                {
                    iOSFunctions.OpenUrl("https://pactia.com/noticias/");
                }
                catch (Exception)
                {
                    SimpleAlert("Alerta", "Ha ocurrido un error al intentar abrir el sitio web");
                }
            }
        }

        #endregion

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
        #endregion
    }
}

