using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Webkit;
using SharedContent;

namespace PactiaDroid
{
    [Activity(Label = "Panorama", Theme = "@android:style/Theme.NoTitleBar")]
    public class PanoramaActivity : Activity
    {
        public int SelectionNumber = 0;
        Constants constants = new Constants();
        SharedContent.Service service = new SharedContent.Service();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Panorama);
            SelectionNumber = Intent.Extras.GetInt("SelectionNumber");
            // Create your application here
            var WebViewPanorama = FindViewById<WebView>(Resource.Id.webViewPanorama);
            WebSettings webSettings = WebViewPanorama.Settings;
            webSettings.JavaScriptEnabled = true;
            WebViewPanorama.Settings.SetRenderPriority(WebSettings.RenderPriority.High);
      
            WebViewPanorama.SetWebViewClient(new WebViewClient());
            if (SelectionNumber == 0)
            {
                Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=16");             
                WebViewPanorama.LoadUrl(galeria.Url);              
                //WebViewPanorama.LoadUrl("https://momento360.com/e/u/b6dc4b4cfd8b4cb08df599d7140b9d95?utm_campaign=embed&utm_source=other&utm_medium=other&heading=0&pitch=0&field-of-view=100");
            }
            else
            {
                Galeria galeria = service.HttpGet<Galeria>(constants.Url, constants.GaleriaController, constants.GaleriaMethod, "code=20");
                WebViewPanorama.LoadUrl(galeria.Url);
                //WebViewPanorama.LoadUrl(" https://momento360.com/e/u/f74c54af6077455fa3de5914c4b3b92c?utm_campaign=embed&utm_source=other&utm_medium=other&heading=0&pitch=0&field-of-view=75");
            }
            WebViewPanorama.Settings.JavaScriptEnabled = true;
            WebViewPanorama.Settings.BuiltInZoomControls = true;
            WebViewPanorama.Settings.SetSupportZoom(true);
            WebViewPanorama.ScrollBarStyle = ScrollbarStyles.OutsideOverlay;
            WebViewPanorama.ScrollbarFadingEnabled = false;
        }
    }
}