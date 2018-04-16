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

namespace UWOBookTrade.Activities {
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity {
        Button home;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Home);

            home = FindViewById<Button>(Resource.Id.btnBuy);
            home.Click += Home_Click;
        }

        private void Home_Click(object sender, EventArgs e) {
            StartActivity(typeof(BuyActivity));
        }
    }
}