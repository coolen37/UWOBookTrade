using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace UWOBookTrade.Activities
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        Button login;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);

            login = FindViewById<Button>(Resource.Id.btnLogin);
            login.Click += Login_Click;

        }

        private void Login_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(HomeActivity));
        }
    }
}