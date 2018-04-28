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
        EditText title;
        EditText author;
        EditText isbn;
        string filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BookTrade.db3");

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Sell);

            textbookPic = FindViewById<Button>(Resource.Id.btnSearchImage);
            textbookPic.Click += TextbookPic_Click;
        }

        private void TextbookPic_Click(object sender, EventArgs e) {
            //Grab info from the three edittexts and submit to database. Refer to ProfileActivity for a recipe.
            StartActivity(typeof(PhotoUploadActivity));
        }
    }
}