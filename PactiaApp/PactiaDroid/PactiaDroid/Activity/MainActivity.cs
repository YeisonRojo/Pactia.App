using Android.App;
using Android.Content.PM;
using Android.OS;
using GR.Net.Maroulis.Library;
using Android.Graphics;

namespace PactiaDroid
{
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main);
            ShowSplashScreen();
        }

        /// <summary>
        /// Show the Splash Screen
        /// </summary>
        public void ShowSplashScreen()
        {
            var Config = new EasySplashScreen(this)
                .WithFullScreen()
                .WithTargetActivity(Java.Lang.Class.FromType(typeof(TargetActivity)))
                .WithSplashTimeOut(500)
                .WithBackgroundColor(Color.ParseColor("#1A2335"))
                .WithLogo(Resource.Drawable.logopactia);
                Android.Views.View view = Config.Create();
                SetContentView(view);
        }
    }
}

