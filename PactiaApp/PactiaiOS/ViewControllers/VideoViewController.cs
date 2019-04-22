using System;
using AVFoundation;
using AVKit;
using CoreGraphics;
using Foundation;
using UIKit;
using SharedContent;

namespace PactiaiOS
{
    public partial class VideoViewController : UIViewController
    {
        #region Variables
        AVPlayerViewController PlayerViewController = new AVPlayerViewController();
        AVPlayer Player;
        #endregion

        public VideoViewController(IntPtr handle) : base(handle)
        {

        }

        public VideoViewController()
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Service service = new Service();
            Constants constants = new Constants();
            Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=05");
            LoadVideo(galeria.Url);
        }

        /// <summary>
        /// Wills the move to parent view controller.
        /// </summary>
        /// <param name="parent">Parent.</param>
        public override void WillMoveToParentViewController(UIViewController parent)
        {
            base.WillMoveToParentViewController(parent);
         
            if (parent == null)
            {
                Player.Pause();
            }
            else
            {

            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
           
        }

        #region Methods
        /// <summary>
        /// Loads the video.
        /// </summary>
        /// <param name="videourl">Videourl.</param>
        public void LoadVideo(string videourl)
        {
            try
            {
                NSUrl videoURL = NSUrl.FromString(videourl);
                Player = AVPlayer.FromUrl(videoURL);
                PlayerViewController.View.Frame = new CGRect(0, 100, View.Frame.Width, View.Frame.Height / 2);
                PlayerViewController.Player = Player;
                View.AddSubview(PlayerViewController.View);
                PlayerViewController.ShowsPlaybackControls = true;
                UIView videoThumbnail = new UIView(); videoThumbnail.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("background.png"));
                PlayerViewController.ContentOverlayView.AddSubview(videoThumbnail);
                Player.Play();
            }
            catch (Exception)
            {
                SimpleAlert("Alerta", "El video no se encuentra disponible actualmente, por favor intente mas tarde.");
            }
        }

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
        #endregion
    }
}

