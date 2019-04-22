using SharedContent;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;
using XamariniOSUIPicker;

namespace PactiaiOS
{
    public partial class ContactViewController : UIViewController
    {
        #region Variables
        public string BusinessLine= string.Empty;
        public string SubBusinessLine = string.Empty;
        bool switchContactAcceptConditionState;
        LoadingIndicator loadingIndicator;
        bool IsInternetConnectionAvailable;
        Service service = new Service();
        Constants constants = new Constants();
        public List<string> ServiceLines = new List<string>
        {

        };
        #endregion

        public ContactViewController (IntPtr handle) : base (handle)
        {

        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            buttonContactSend.AddTarget(ButtonEventHandler, UIControlEvent.TouchUpInside);
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
                    LoadUILabelText(UILabelContactTitle, "ESCRÍBENOS " + SubBusinessLine);
                    if (BusinessLine != string.Empty)
                    {
                        pickerViewContactServiceLines.UserInteractionEnabled = false;
                    }
                    else
                    {
                        constants = new Constants();
                        List<Proyectos> listaProyectos = service.HttpGet<List<Proyectos>>(constants.Url, constants.ProyectoController, constants.ProyectoMethod, string.Empty);
                        if (listaProyectos != null && listaProyectos.Count > 0)
                        {
                            foreach (var item in listaProyectos)
                            {
                                ServiceLines.Add(item.Nombre);
                            }
                        }
                        else
                        {
                            throw new Exception("No se encontraron registros");
                        }
                        var picker = new UIPickerViewServiceLinesModel(ServiceLines);
                        pickerViewContactServiceLines.Model = picker;
                        picker.ValueChanged += (sender, e) =>
                        {
                            BusinessLine = picker.SelectedValue.ToString();
                        };
                    }

                    loadingIndicator.Hide();
                }
                catch (Exception)
                {
                    var okCancelAlertController = UIAlertController.Create("Alerta", "El servicio no está disponible en el momento, intente de nuevo más tarde", UIAlertControllerStyle.Alert);
                    okCancelAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, alert => Environment.Exit(0)));
                    PresentViewController(okCancelAlertController, true, null);
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
        partial void switchContactAcceptConditionChanged(UISwitch sender)
        {
            switchContactAcceptConditionState = switchContactAcceptCondition.On;
        }

        private async void ButtonEventHandler(object sender, EventArgs e)
        {
            if (sender == buttonContactSend)
            {
                if (SharedFunctions.IsEmptyOrNullString(textFieldContactUser.Text) == true || SharedFunctions.IsEmptyOrNullString(textFileldContactBusinessName.Text) == true || SharedFunctions.IsEmptyOrNullString(textFieldContactPhoneNumber.Text) == true || SharedFunctions.IsEmptyOrNullString(textFieldContactMessage.Text) == true)
                {
                    SimpleAlert("Notificación", "Debe completar los campos");
                }
                else if (BusinessLine == "Seleccionar opción" || BusinessLine == null)
                {
                    SimpleAlert("Notificación", "Debe seleccionar una línea de negocio válida");
                }
                else
                {
                    if (switchContactAcceptConditionState == true)
                    {
                        string MailState = string.Empty;
                        var bounds = UIScreen.MainScreen.Bounds;
                        loadingIndicator = new LoadingIndicator(bounds, "Enviando mensaje...");
                        View.Add(loadingIndicator);
                        await Task.Delay(100);
                        Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=06");
                        MailState = SharedFunctions.SendEmail("Línea de negocio: " + SubBusinessLine, "Nombre:  " + textFieldContactUser.Text + Environment.NewLine + "Funcionario de la empresa: " + textFileldContactBusinessName.Text + Environment.NewLine + "Nos pueden contactar via Email: " + textFieldContactMail.Text + Environment.NewLine + "Teléfono: " + textFieldContactPhoneNumber.Text + Environment.NewLine + "Mensaje: " + textFieldContactMessage.Text + Environment.NewLine + Environment.NewLine, lineas.Email, lineas.EmailRemitente, lineas.Clave, lineas.Smtp);
                        loadingIndicator.Hide();
                        SimpleAlert("Notificación", MailState);
                        textFieldContactUser.Text = "";
                        textFieldContactMail.Text = "";
                        textFieldContactMessage.Text = "";
                        textFieldContactPhoneNumber.Text = "";
                        textFileldContactBusinessName.Text = "";
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