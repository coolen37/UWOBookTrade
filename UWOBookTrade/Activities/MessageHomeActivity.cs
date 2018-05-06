using System;

using Android.App;
using Android.OS;
using Android.Widget;

namespace UWOBookTrade.Activities
{
    [Activity(Label = "MessageHomeActivity")]
    public class MessageHomeActivity : Activity
    {
        TextView txtMessaging;
        ListView lstMessages;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MessageHome);
            
            txtMessaging = FindViewById<TextView>(Resource.Id.txtMessaging);
            lstMessages = FindViewById<ListView>(Resource.Id.lstMessages);
        }
    }
}
