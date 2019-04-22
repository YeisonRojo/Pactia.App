using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using Android.Graphics;
using SharedContent;
using Android.Content;

namespace PactiaDroid.Fragments
{
    public class FragmentMeeting : Fragment
    {
        Service service = new Service();
        Constants constants = new Constants();
        public List<string> ServiceLines = new List<string>
        { };
        bool IsInternetConnectionAvailable;
        SharedFunctions sharedFunctions = new SharedFunctions();
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static FragmentMeeting NewInstance()
        {
            var frag1 = new FragmentMeeting { Arguments = new Bundle() };
            return frag1;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            #region Reference controls
            var view = inflater.Inflate(Resource.Layout.fragmentMeeting, container, false);
            var TextViewMeetingTitle = view.FindViewById<TextView>(Resource.Id.textViewMeetingTitle);
            var SwitchMeetingAcceptConditions = view.FindViewById<Switch>(Resource.Id.switchMeetingAcceptConditions);
            var EditTextMeetingName = view.FindViewById<EditText>(Resource.Id.editTextMeetingName);
            var EditTextMeetingEmail = view.FindViewById<EditText>(Resource.Id.editTextMeetingEmail);
            var EditTextMeetingBusinessName = view.FindViewById<EditText>(Resource.Id.editTextMeetingBusinessName);
            var EditTextMeetingPhoneNumber = view.FindViewById<EditText>(Resource.Id.editTextMeetingPhoneNumber);
            var EditTextMeetingMessage = view.FindViewById<EditText>(Resource.Id.editTextMeetingMessage);
            var ButtonMeetingSend = view.FindViewById<Button>(Resource.Id.buttonMeetingSend);
            var SpinnerServiceLines = view.FindViewById<Spinner>(Resource.Id.spinnerServiceLines);
            #endregion

            #region Add custom font
            Typeface GillSansFont = Typeface.CreateFromAsset(Activity.Assets, "GillSans.ttf");
            SwitchMeetingAcceptConditions.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            TextViewMeetingTitle.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            EditTextMeetingName.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            EditTextMeetingEmail.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            EditTextMeetingBusinessName.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            EditTextMeetingPhoneNumber.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            EditTextMeetingMessage.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            ButtonMeetingSend.SetTypeface(GillSansFont, TypefaceStyle.Normal);
            #endregion

            #region Controls Clicks
            ButtonMeetingSend.Click += (object sender, EventArgs e) =>
            {
                if (sharedFunctions.IsEmptyOrNullString(EditTextMeetingName.Text) == true || sharedFunctions.IsEmptyOrNullString(EditTextMeetingBusinessName.Text) == true || sharedFunctions.IsEmptyOrNullString(EditTextMeetingPhoneNumber.Text) == true)
                {
                    SimpleToast("Debe completar todos los campos");
                }
                else if (SpinnerServiceLines.SelectedItem.ToString() =="Acerca de")
                {
                    SimpleToast("Debe seleccionar una línea de negocio");
                }
                else 
                {
                    if (SwitchMeetingAcceptConditions.Checked == true)
                    {
                        Lineas lineas = service.HttpGet<Lineas>(constants.Url, constants.LineaController, constants.LineaMethod, "code=06");
                        string MailState = sharedFunctions.SendEmail("Información sobre " + SpinnerServiceLines.SelectedItem, "Nombre:  " + EditTextMeetingName.Text + System.Environment.NewLine + "Funcionario de la empresa: " + EditTextMeetingBusinessName.Text + System.Environment.NewLine + "Nos pueden contactar via Email: " + EditTextMeetingEmail.Text + System.Environment.NewLine + "Teléfono: " + EditTextMeetingPhoneNumber.Text + System.Environment.NewLine + "Mensaje: " + EditTextMeetingMessage.Text + System.Environment.NewLine + System.Environment.NewLine, lineas.Email, lineas.EmailRemitente, lineas.Clave, lineas.Smtp);
                        SimpleToast(MailState);
                        EditTextMeetingName.Text = "";
                        EditTextMeetingBusinessName.Text = "";
                        EditTextMeetingEmail.Text = "";
                        EditTextMeetingPhoneNumber.Text = "";
                        EditTextMeetingMessage.Text = "";
                    }
                    else
                    {
                        SimpleToast("Antes de continuar debe aceptar las políticas de tratamiento de datos personales");
                    }
                }
            };
            #endregion

            IsInternetConnectionAvailable = sharedFunctions.CheckInternetConnection();
            if (IsInternetConnectionAvailable == true)
            {
                try
                {
                    List<Proyectos> listaProyectos = service.HttpGet<List<Proyectos>>(constants.Url, constants.ProyectoController, constants.ProyectoMethod, string.Empty);
                    ServiceLines.Add("Acerca de");
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
                    var ServiceLinesAdapter = new ArrayAdapter<string>(this.Activity.BaseContext, Android.Resource.Layout.SimpleSpinnerItem, ServiceLines);
                    ServiceLinesAdapter = new ArrayAdapter<string>(this.Activity.BaseContext, Android.Resource.Layout.SimpleSpinnerItem, ServiceLines);
                    SpinnerServiceLines.Adapter = ServiceLinesAdapter;
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
            return view;
        }

        #region Methods

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
        #endregion
    }
}