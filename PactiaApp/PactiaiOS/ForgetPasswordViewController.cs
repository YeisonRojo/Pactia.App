using System;

using UIKit;

using SharedContent;

namespace PactiaiOS
{
    public partial class ForgetPasswordViewController : UIViewController
    {
        public ForgetPasswordViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ScrollViewPassword.ContentSize = new CoreGraphics.CGSize(0, View.Frame.Height - 400);
            buttonForgetPasswordSend.AddTarget(ButtonEventHandler, UIControlEvent.TouchUpInside);
            //Touch event, hide virtual keyboard
            this.View.AddGestureRecognizer(new UITapGestureRecognizer(tap =>
            {
                View.EndEditing(true);
            })
            {
                NumberOfTapsRequired = 1
            });

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        #region Button Clicks Event Handler
        private void ButtonEventHandler(object sender, EventArgs e)
        {
            if(SharedFunctions.IsEmptyOrNullString(textFieldForgetPasswordUser.Text)==true)
            {
                SimpleAlert("Notificación", "Debe completar los campos");
            }
            else
            {

            }
        }
        #endregion

        #region Methods
        public void SimpleAlert(string title, string message)
        {
            var okAlertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            okAlertController.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Default, null));
            PresentViewController(okAlertController, true, null);
        }
        #endregion
    }
}

