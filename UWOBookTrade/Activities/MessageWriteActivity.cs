using System;

using Android.App;
using Android.OS;
using Android.Widget;

namespace UWOBookTrade.Activities
{
    [Activity(Label = "MessageWriteActivity")]
    public class MessageWriteActivity : Activity
    {
        TextView txtToUsername;
        EditText txtMessageBox;
    
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MessageWrite);
            
            txtToUsername = FindViewById<TextView>(Resource.Id.txtToUsername);
            txtMessageBox = FindViewById<EditText>(Resource.Id.txtMessageBox);
        }
    }
}
