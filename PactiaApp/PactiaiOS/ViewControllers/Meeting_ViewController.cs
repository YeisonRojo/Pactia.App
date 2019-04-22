using System;
using System.Collections.Generic;
using UIKit;
using XamariniOSUIPicker;

using SharedContent;
using System.Threading.Tasks;
using Foundation;

namespace PactiaiOS
{
    public partial class Meeting_ViewController : UIViewController
    {
        #region Variables
        String BusinessLine;
        bool switchMeetingAcceptConditionState;
        LoadingIndicator loadingIndicator;
        bool IsInternetConnectionAvailable;
        Service service = new Service();
        public List<string> ServiceLines = new List<string>
        {

        };
        #endregion
        protected Meeting_ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.

        }
                  
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            ScrollViewMeeting.ContentSize = new CoreGraphics.CGSize(0, View.Frame.Height + 100);
            buttonMeetingSend.AddTarget(ButtonEventHandler, UIControlEvent.TouchUpInside);
            this.View.AddGestureRecognizer(new UITapGestureRecognizer(tap =>
            {
                View.EndEditing(true);
            })
            {
                NumberOfTapsRequired = 1
            });
            IsInternetConnectionAvailable = SharedFunctions.CheckInternetConnection();
            if (IsInternetConnectionAvailable == true)
            {
                try
                {
                    var bounds = UIScreen.MainScreen.Bounds;
                    loadingIndicator = new LoadingIndicator(bounds, "Cargando contenido...");
                    View.Add(loadingIndicator);
                    await Task.Delay(10);
                    iOSFunctions.LoadUILabelText(UILabelMeetingTitle, "SOLICITAR CITA");
                    Constants constants = new Constants();
                    List<Proyectos> listaProyectos = service.HttpGet<List<Proyectos>>(constants.Url, constants.ProyectoController, constants.ProyectoMethod, string.Empty);
                    ServiceLines.Add("Seleccionar opción");
                    if(listaProyectos != null && listaProyectos.Count > 0)
                    {
                        foreach (var item in listaProyectos)
                        {
                            ServiceLines.Add(item.Nombre);
                        }
                    }
                    else
                    {
                        throw new Exception("No se encontraron registros.");
                    }
                    var picker = new UIPickerViewServiceLinesModel(ServiceLines);
                    pickerViewMeetingServiceLiness.Model = picker;
                    picker.ValueChanged += (sender, e) => 
                    {
                        BusinessLine = picker.SelectedValue.ToString();
                    };
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
        partial void switchMeetingAcceptConditionChanged(UISwitch sender)
        {
            switchMeetingAcceptConditionState = switchMeetingAcceptConditions.On;
        }

        private async void ButtonEventHandler(object sender, EventArgs e)
        {
            Constants constants = new Constants();
            if (sender == buttonMeetingSend)
            {
                if (SharedFunctions.IsEmptyOrNullString(textFieldMeetingUser.Text)==true || SharedFunctions.IsEmptyOrNullString(textFileldMeetingBusinessName.Text) == true || SharedFunctions.IsEmptyOrNullString(textFieldMeetingPhoneNumber.Text)==true|| SharedFunctions.IsEmptyOrNullString(textFieldMeetingMessage.Text) == true)
                {
                    SimpleAlert("Notificación", "Debe completar los campos");
                }
                else if (BusinessLine == "Seleccionar opción"||BusinessLine==null)
                {
                    SimpleAlert("Notificación", "Debe seleccionar una línea de negocio");
                }
                else
                {
                    if (switchMeetingAcceptConditionState == true)
                    {
                        IsInternetConnectionAvailable = SharedFunctions.CheckInternetConnection();
                        if (IsInternetConnectionAvailable == true)
                        {
                            string MailState = string.Empty;
                            var bounds = UIScreen.MainScreen.Bounds;
                            loadingIndicator = new LoadingIndicator(bounds, "Enviando mensaje...");
                            View.Add(loadingIndicator);
                            await Task.Delay(100);
                            Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=06");              
                            MailState = SharedFunctions.SendEmail("Solicitamos cita para: " + BusinessLine, "Favor agendar cita a nombre de:  " + textFieldMeetingUser.Text + Environment.NewLine + "Funcionario de la empresa: " + textFileldMeetingBusinessName.Text + Environment.NewLine + "Nos pueden contactar via Email: " + textFieldMeetingMail.Text + Environment.NewLine + "Teléfono: " + textFieldMeetingPhoneNumber.Text + Environment.NewLine + "Mensaje: " + textFieldMeetingMessage.Text + Environment.NewLine + Environment.NewLine, lineas.Email, lineas.EmailRemitente, lineas.Clave, lineas.Smtp);
                            loadingIndicator.Hide();
                            SimpleAlert("Notificación", MailState);
                            textFieldMeetingUser.Text = "";
                            textFieldMeetingMail.Text = "";
                            textFieldMeetingMessage.Text = "";
                            textFieldMeetingPhoneNumber.Text = "";
                            textFileldMeetingBusinessName.Text = "";
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        SimpleAlert("Notificación", "Antes de continuar debe aceptar las políticas de tratamiento de datos personales");
                    }
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

