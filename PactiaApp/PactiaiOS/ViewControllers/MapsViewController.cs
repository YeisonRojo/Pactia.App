using System;
using CoreLocation;
using MapKit;
using UIKit;

namespace PactiaiOS
{
    public partial class MapsViewController : UIViewController
    {
        #region Variables
        public double LocationLatitude;
        public double LocationLongitude;
        public string AnnotationTitle;
        public MapsViewController(IntPtr handle) : base(handle)
        {

        }
        #endregion

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            LoadMap();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        #region Methods
        public void LoadMap()
        {
            try
            {
                MKPointAnnotation Annotation = new MKPointAnnotation();
                CLLocationCoordinate2D AnnotationCoordinates = new CLLocationCoordinate2D(LocationLatitude, LocationLongitude);
                Annotation.Title = AnnotationTitle;
                Annotation.Coordinate = AnnotationCoordinates;
                MKMapViewBusinessLines.AddAnnotation(Annotation);
                CLLocationCoordinate2D LocationCoordinate = new CLLocationCoordinate2D(LocationLatitude, LocationLongitude);
                MKCoordinateSpan coordinateSpan = new MKCoordinateSpan(5, 5);
                MKCoordinateRegion coordinateRegion = new MKCoordinateRegion(LocationCoordinate, coordinateSpan);
                MKMapViewBusinessLines.SetRegion(coordinateRegion, true);
            }
            catch (Exception ex)
            {

            }         
        }
        #endregion
    }
}

