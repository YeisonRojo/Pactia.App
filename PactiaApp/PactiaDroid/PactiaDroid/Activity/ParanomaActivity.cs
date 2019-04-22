using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Glide;
using Android.OS;
using Android.Support.V7.App;
using Com.Gjiazhe.Panoramaimageview;

namespace PactiaDroid
{
    [Activity(Label = "ParanomaActivity")]
    public class ParanomaActivity : Activity
    {
        private GyroscopeObserver gyroscopeObserver;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Paranoma);
            gyroscopeObserver = new GyroscopeObserver();
            gyroscopeObserver.SetMaxRotateRadian(Math.PI / 9);
            PanoramaImageView panoramaImageView = FindViewById<PanoramaImageView>(Resource.Id.panoramaImageView1);
            panoramaImageView.SetGyroscopeObserver(gyroscopeObserver);
            Glide.With(this).Load(Resource.Drawable.panorama).Into(panoramaImageView);
            // Create your application here
        }
        protected override void OnResume()
        {
            base.OnResume();
            gyroscopeObserver.Register(this);
        }

        protected override void OnPause()
        {
            base.OnPause();
            gyroscopeObserver.Unregister();
        }
    }
}