using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Content.PM;
using Android.Widget;
using SharedContent;
using Android.Views;

namespace PactiaDroid
{
    [Activity(Label = "ContactUs" , ScreenOrientation = ScreenOrientation.Portrait)]
    public class ContactActivity : Activity
    {
        SharedContent.Service service = new SharedContent.Service();
        Constants constants = new Constants();
        public List<string> ServiceLines = new List<string>
        { };
        bool IsInternetConnectionAvailable;
        bool IsValidEmail;
        string BusinessLine = string.Empty;
        SharedFunctions sharedFunctions = new SharedFunctions();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Contact);
            BusinessLine = Intent.Extras.GetString("businessline");
            var TextViewContactTitle = FindViewById<TextView>(Resource.Id.textViewContactTitle);
            TextViewContactTitle.Text = "Escríbenos " + BusinessLine;
            var ButtonContactSend = FindViewById<Button>(Resource.Id.buttonContactSend);
            var SwitchContactAcceptConditions = FindViewById<Switch>(Resource.Id.switchContactAcceptConditions);
            var EditTextContactName = FindViewById<EditText>(Resource.Id.editTextContactName);
            var EditTextContactEmail = FindViewById<EditText>(Resource.Id.editTextContactEmail);
            var EditTextContactBusinessName = FindViewById<EditText>(Resource.Id.editTextContactBusinessName);
            var EditTextContactPhoneNumber = FindViewById<EditText>(Resource.Id.editTextContactPhoneNumber);
            var EditTextContactMessage = FindViewById<EditText>(Resource.Id.editTextContactMessage);
            var SpinnerContactServiceLines = FindViewById<Spinner>(Resource.Id.spinnerContactServiceLines);
            ButtonContactSend.Click += (object sender, EventArgs e) =>
            {
                IsInternetConnectionAvailable = sharedFunctions.CheckInternetConnection();
                if (IsInternetConnectionAvailable == true)
                {
                    try
                    {
                        if (sharedFunctions.IsEmptyOrNullString(EditTextContactName.Text) == true || sharedFunctions.IsEmptyOrNullString(EditTextContactBusinessName.Text) == true || sharedFunctions.IsEmptyOrNullString(EditTextContactPhoneNumber.Text) == true)
                        {
                            SimpleToast("Debe completar todos los campos");
                        }
                        else
                        {
                            if (SwitchContactAcceptConditions.Checked == true)
                            {
                                Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=06");
                                string MailState = sharedFunctions.SendEmail("Información sobre " + BusinessLine, "Nombre:  " + EditTextContactName.Text + System.Environment.NewLine + "Funcionario de la empresa: " + EditTextContactBusinessName.Text + System.Environment.NewLine + "Nos pueden contactar via Email: " + EditTextContactEmail.Text + System.Environment.NewLine + "Teléfono: " + EditTextContactPhoneNumber.Text + System.Environment.NewLine + "Mensaje: " + EditTextContactMessage.Text + System.Environment.NewLine + System.Environment.NewLine, lineas.Email, lineas.EmailRemitente, lineas.Clave, lineas.Smtp);
                                SimpleToast(MailState);
                                EditTextContactName.Text = "";
                                EditTextContactBusinessName.Text = "";
                                EditTextContactEmail.Text = "";
                                EditTextContactPhoneNumber.Text = "";
                                EditTextContactMessage.Text = "";
                            }
                            else
                            {
                                SimpleToast("Antes de continuar debe aceptar las políticas de tratamiento de datos personales");
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    AlertDialog("Alerta", "Por favor verifique su conexión a internet e intente nuevamente");
                }
            };
            IsInternetConnectionAvailable = sharedFunctions.CheckInternetConnection();
            if (IsInternetConnectionAvailable == true)
            {
                if (BusinessLine == "")
                {
                    try
                    {
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
                            throw new Exception("No se encontraron registros.");
                        }
                        var ServiceLinesAdapter = new ArrayAdapter<string>(this.BaseContext, Android.Resource.Layout.SimpleSpinnerItem, ServiceLines);
                        ServiceLinesAdapter = new ArrayAdapter<string>(this.BaseContext, Android.Resource.Layout.SimpleSpinnerItem, ServiceLines);
                        SpinnerContactServiceLines.Adapter = ServiceLinesAdapter;
                    }
                    catch (Exception)
                    {
                        AlertDialog("Alerta", "El servicio no está disponible en el momento, intente nuevamente mas tarde");
                    }
                }
                else
                {
                    SpinnerContactServiceLines.Enabled = false;
                }              
            }
            else
            {
                AlertDialog("Alerta", "Por favor verifique su conexión a internet e intente nuevamente");
            }
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
