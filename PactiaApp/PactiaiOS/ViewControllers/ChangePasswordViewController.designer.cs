// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PactiaiOS
{
    [Register ("ChangePasswordViewController")]
    partial class ChangePasswordViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton buttonChangePassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView ScrollViewChangePassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textFieldConfirmPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textFieldNewPassword { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (buttonChangePassword != null) {
                buttonChangePassword.Dispose ();
                buttonChangePassword = null;
            }

            if (ScrollViewChangePassword != null) {
                ScrollViewChangePassword.Dispose ();
                ScrollViewChangePassword = null;
            }

            if (textFieldConfirmPassword != null) {
                textFieldConfirmPassword.Dispose ();
                textFieldConfirmPassword = null;
            }

            if (textFieldNewPassword != null) {
                textFieldNewPassword.Dispose ();
                textFieldNewPassword = null;
            }
        }
    }
}