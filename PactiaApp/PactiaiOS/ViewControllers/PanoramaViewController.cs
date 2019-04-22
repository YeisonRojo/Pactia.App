using System;
using System.Collections.Generic;
using Foundation;
using SharedContent;
using UIKit;

namespace PactiaiOS.ViewControllers
{
    public partial class PanoramaViewController : UIViewController
    {
        public int SelectionNumber = 0;
        public PanoramaViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Service service = new Service();
            Constants constants = new Constants();
            try
            {
                UIWebView UIWebviewPanorama = new UIWebView(View.Bounds);
                View.AddSubview(UIWebviewPanorama);
                if (SelectionNumber == 1)
                {
                    Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=16");
                    UIWebviewPanorama.LoadRequest(new NSUrlRequest(new NSUrl(galeria.Url)));
                }
                else
                {
                    Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=20");
                    UIWebviewPanorama.LoadRequest(new NSUrlRequest(new NSUrl(galeria.Url)));
                }
            }
            catch (Exception)
            {

            }
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

