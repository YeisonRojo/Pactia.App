using System;
using MessageUI;

namespace SharedPCL
{
    public class MyClass
    {
        public SharedFunctions()

        {
            public void SendEmail()
            {

#if __ANDROID__

                        var email = new Intent(Android.Content.Intent.ActionSend);
                        email.PutExtra(Android.Content.Intent.ExtraEmail, "matapluche@gmail.com");
                        email.PutExtra(Android.Content.Intent.ExtraCc, new string[] {"susairajs18@live.com"});
                        email.PutExtra(Android.Content.Intent.ExtraSubject, "Prueba Android");
                        email.PutExtra(Android.Content.Intent.ExtraText, "Hello from Android...!");
                        email.SetType("message/rfc822");
                        return email;StartActivity(email);
#endif

#if __IOS__

                if (MFMailComposeViewController.CanSendMail)
                {
                    MFMailComposeViewController mailController = new MFMailComposeViewController();
                    mailController.SetToRecipients(new string[] { "john@doe.com" });
                    mailController.SetSubject("mail test");
                    mailController.SetMessageBody("this is a test", false);
                    GetController().PresentViewController(mailController, true, null);
                    mailController.Finished += (object s, MFComposeResultEventArgs args) =>
                    {
                        Console.WriteLine(args.Result.ToString());
                        args.Controller.DismissViewController(true, null);

                    };
                    return null;
                }
#endif
            }
        }
    }
}
