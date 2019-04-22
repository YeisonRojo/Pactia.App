using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using SharedContent;

namespace PactiaDroid
{
    [Activity(Label = "VideoActivity", ScreenOrientation = ScreenOrientation.Landscape, Theme = "@android:style/Theme.NoTitleBar")]
    public class VideoActivity : Activity
    {
        #region Variables
        private MediaController mediaController;
        VideoView VideoViewMain;
        SharedContent.Service service = new SharedContent.Service();
        Constants constants = new Constants();
        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);     
            SetContentView(Resource.Layout.Video);      
            VideoViewMain = FindViewById<VideoView>(Resource.Id.videoViewMain);
            LoadVideo();
        }
      
        /// <summary>
        /// Load video 
        /// </summary>
        void LoadVideo()
        {
            try
            {
                Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=05");
                var uri = Android.Net.Uri.Parse(galeria.Url);
                VideoViewMain.SetVideoURI(uri);
                VideoViewMain.RequestFocus();
                VideoViewMain.Start();
                mediaController = new Android.Widget.MediaController(this);
                mediaController.SetMediaPlayer(VideoViewMain);
                VideoViewMain.SetMediaController(mediaController);
                VideoViewMain.RequestFocus();
            }
            catch (Exception)
            {
                AlertDialog("Alerta", "Ha ocurrido un error al intentar cargar el video, intente de nuevo mas tarde");
            }
        }

        /// <summary>
        /// Show alert
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
    }
}