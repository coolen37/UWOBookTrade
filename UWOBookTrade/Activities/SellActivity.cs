using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace UWOBookTrade.Activities {
    [Activity(Label = "SellActivity")]
    public class SellActivity : Activity {
        Button textbookPic;
        EditText title;
        EditText author;
        EditText isbn;
        EditText price;
        string filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BookTrade.db3");

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Sell);

            title = FindViewById<EditText>(Resource.Id.editTitle);
            author = FindViewById<EditText>(Resource.Id.editAuthor);
            isbn = FindViewById<EditText>(Resource.Id.editIsbn);
            textbookPic = FindViewById<Button>(Resource.Id.btnSearchImage);
            price = FindViewById<EditText>(Resource.Id.editPrice);
            textbookPic.Click += TextbookPic_Click;
        }

        private void TextbookPic_Click(object sender, EventArgs e) {
            Intent intent = new Intent(this, typeof(PhotoUploadActivity));
            intent.PutExtra("Title", title.Text);
            intent.PutExtra("Author", author.Text);
            intent.PutExtra("ISBN", isbn.Text);
            intent.PutExtra("Price", price.Text);
            StartActivity(intent);
        }
    }
}
