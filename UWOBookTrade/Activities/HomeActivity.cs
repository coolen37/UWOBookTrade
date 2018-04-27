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
        Button profile;
        Button logout;
        Button sell;
        Button buy;
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Home);

            home = FindViewById<Button>(Resource.Id.btnBuy);
            profile = FindViewById<Button>(Resource.Id.btnProfile);
            logout = FindViewById<Button>(Resource.Id.btnLogout);
            buy = FindViewById<Button>(Resource.Id.btnBuy);
            sell = FindViewById<Button>(Resource.Id.btnSell);
            home.Click += Home_Click;
            profile.Click += Profile_Click;
            logout.Click += Logout_Click;
            buy.Click += Buy_Click;
            sell.Click += Sell_Click;
        }

        private void Sell_Click(object sender, EventArgs e) {
            StartActivity(typeof(SellActivity));
        }

        private void Buy_Click(object sender, EventArgs e) {
            StartActivity(typeof(BuyActivity));
        }

        private void Logout_Click(object sender, EventArgs e) {
            StartActivity(typeof(LoginActivity));
        }

        private void Profile_Click(object sender, EventArgs e) {
            StartActivity(typeof(ProfileActivity));
        }

        private void Home_Click(object sender, EventArgs e) {
            StartActivity(typeof(BuyActivity));
        }
    }
}