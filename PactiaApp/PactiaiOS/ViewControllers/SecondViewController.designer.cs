// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace PactiaiOS
{
    [Register ("SecondViewController")]
    partial class SecondViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView ScrollViewClients { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UILabelClientsTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView UIViewClientsCall { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView UIViewClientsContactUs { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView UIViewClientsPactiacom { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ScrollViewClients != null) {
                ScrollViewClients.Dispose ();
                ScrollViewClients = null;
            }

            if (UILabelClientsTitle != null) {
                UILabelClientsTitle.Dispose ();
                UILabelClientsTitle = null;
            }

            if (UIViewClientsCall != null) {
                UIViewClientsCall.Dispose ();
                UIViewClientsCall = null;
            }

            if (UIViewClientsContactUs != null) {
                UIViewClientsContactUs.Dispose ();
                UIViewClientsContactUs = null;
            }

            if (UIViewClientsPactiacom != null) {
                UIViewClientsPactiacom.Dispose ();
                UIViewClientsPactiacom = null;
            }
        }
    }
}