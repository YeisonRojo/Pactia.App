using System;
using Foundation;
using MessageUI;
using UIKit;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PactiaiOS
{
    public class iOSFunctions
    {
        #region Project PactiaiOS Shared Functions
        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="viewcontroller">Viewcontroller.</param>
        /// <param name="email">Email.</param>
        /// <param name="subject">Subject.</param>
        /// <param name="message">Message.</param>
        public static void SendEmail(UIViewController viewcontroller, string email, string subject, string message)
        {
            if (MFMailComposeViewController.CanSendMail)
            {
                MFMailComposeViewController mailController = new MFMailComposeViewController();
                mailController.SetToRecipients(new string[] { email });
                mailController.SetSubject(subject);              
                mailController.SetMessageBody(message, false);
                viewcontroller.PresentViewController(mailController, true, null);
                mailController.Finished += (object s, MFComposeResultEventArgs args) =>
                {
                    args.Controller.DismissViewController(true, null);
                };
            }
        }

        /// <summary>
        /// Calls the phone.
        /// </summary>
        /// <param name="phonenumber">Phonenumber.</param>
        public static void CallPhone(string phonenumber)
        {
            var url = new NSUrl(phonenumber);
            UIApplication.SharedApplication.OpenUrl(url);
        }

        /// <summary>
        /// Opens the URL.
        /// </summary>
        /// <param name="url">URL.</param>
        public static void OpenUrl(string url)
        {
            //var jrURL = new NSUrl(new System.Uri("http://δπθ.gr").AbsoluteUri);
            UIApplication.SharedApplication.OpenUrl(new NSUrl(new System.Uri(url).AbsoluteUri));
        }

        /// <summary>
        /// Loads the UILabel text.
        /// </summary>
        /// <param name="label">Label.</param>
        /// <param name="text">Text.</param>
        public static void LoadUILabelText(UILabel label, string text)
        {
            label.Text = text;
        }
        #endregion
    }
}
