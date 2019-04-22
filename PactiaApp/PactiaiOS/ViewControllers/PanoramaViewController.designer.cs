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

namespace PactiaiOS.ViewControllers
{
    [Register ("PanoramaViewController")]
    partial class PanoramaViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView UIImageView360 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UILabelClientsTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (UIImageView360 != null) {
                UIImageView360.Dispose ();
                UIImageView360 = null;
            }

            if (UILabelClientsTitle != null) {
                UILabelClientsTitle.Dispose ();
                UILabelClientsTitle = null;
            }
        }
    }
}