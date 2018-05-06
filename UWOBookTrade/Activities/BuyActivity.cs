using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using UWOBookTrade.Database;

namespace UWOBookTrade.Activities {
    [Activity(Label = "BuyActivity")]
    public class BuyActivity : Activity {
        EditText title;
        EditText isbn;
        EditText author;
        Button search;
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Buy);

            title = FindViewById<EditText>(Resource.Id.editTitle);
            isbn = FindViewById<EditText>(Resource.Id.editIsbn);
            author = FindViewById<EditText>(Resource.Id.editAuthor);
            search = FindViewById<Button>(Resource.Id.btnSearch);

            search.Click += Search_Click;
        }

        private void Search_Click(object sender, EventArgs e) {
            string bTitle = title.Text;
            string bIsbn = isbn.Text;
            string bAuthor = author.Text;

            Intent intent = new Intent(this, typeof(BooklistActivity));
            intent.PutExtra("Title", bTitle);
            intent.PutExtra("ISBN", bIsbn);
            intent.PutExtra("Author", bAuthor);
            StartActivity(intent);
        }
    }
}
