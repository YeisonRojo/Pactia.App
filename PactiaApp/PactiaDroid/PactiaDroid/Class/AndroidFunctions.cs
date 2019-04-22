using Android.App;
using Android.Content;
using Android.Support.V7.App;

namespace PactiaDroid
{
    class AndroidFunctions
    {
        #region Project PactiaAndroid Shared Functions
        public static void CallPhone(string phonenumber, AppCompatActivity activity)
        {
            var uri = Android.Net.Uri.Parse("tel:"+ phonenumber);
            var intent = new Intent(Intent.ActionView, uri);
            activity.StartActivity(intent);
        }
        #endregion
    }
}