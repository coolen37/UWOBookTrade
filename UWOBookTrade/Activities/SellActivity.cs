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
    [Activity(Label = "SellActivity")]
    public class SellActivity : Activity {
        Button textbookPic;
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Sell);

            textbookPic = FindViewById<Button>(Resource.Id.btnTextbookPic);
            textbookPic.Click += TextbookPic_Click;
        }

        private void TextbookPic_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }
    }
}