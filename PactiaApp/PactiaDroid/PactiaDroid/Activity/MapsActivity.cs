using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.V7.App;

namespace PactiaDroid
{
    [Activity(Label = "MapsActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class MapsActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap GMap;
        double Longitude, Latitude;
        string Title = string.Empty;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Maps);
            Longitude = Intent.Extras.GetDouble("longitude");
            Latitude = Intent.Extras.GetDouble("latitude");
            Title = Intent.Extras.GetString("title");
            SetUpMap();
        }

        private void SetUpMap()
        {
            if (GMap == null)
            {
               FragmentManager.FindFragmentById<MapFragment>(Resource.Id.mapViewMain).GetMapAsync(this);
            }
        }
        public void OnMapReady(GoogleMap googleMap)
        {
            this.GMap = googleMap;
            GMap.UiSettings.ZoomControlsEnabled = true;
            LatLng latlng = new LatLng(Longitude, Latitude);
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 10);
            GMap.MoveCamera(camera);
            MarkerOptions options = new MarkerOptions().SetPosition(latlng).SetTitle(Title);
            GMap.AddMarker(options);
        }
    }
}