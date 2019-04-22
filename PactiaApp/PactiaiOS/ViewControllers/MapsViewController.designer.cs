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
    [Register ("MapsViewController")]
    partial class MapsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView MKMapViewBusinessLines { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UILabelClientsTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MKMapViewBusinessLines != null) {
                MKMapViewBusinessLines.Dispose ();
                MKMapViewBusinessLines = null;
            }

            if (UILabelClientsTitle != null) {
                UILabelClientsTitle.Dispose ();
                UILabelClientsTitle = null;
            }
        }
    }
}