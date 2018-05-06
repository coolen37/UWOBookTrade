using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Provider;
using Android.Widget;
using SQLite;
using UWOBookTrade.Database;

namespace UWOBookTrade.Activities {
    [Activity(Label = "PhotoUploadActivity")]
    public class PhotoUploadActivity : Activity {
        Button home;
        Button submit;
        Button chooseFile;
        ImageView textbookPic;
        byte[] image = null;
        string filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BookTrade.db3");

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PhotoUpload);

            home = FindViewById<Button>(Resource.Id.btnHome);
            submit = FindViewById<Button>(Resource.Id.btnSubmit);
            chooseFile = FindViewById<Button>(Resource.Id.btnChooseFile);
            textbookPic = FindViewById<ImageView>(Resource.Id.imgTextbok);

            home.Click += Home_Click;
            chooseFile.Click += ChooseFile_Click;
            submit.Click += Submit_Click;
        }

        private void Submit_Click(object sender, EventArgs e) {
            BookTable book = new BookTable {
                BookTitle = Intent.GetStringExtra("Title"),
                Author = Intent.GetStringExtra("Author"),
                ISBN = Intent.GetStringExtra("ISBN"),
                Price = Intent.GetStringExtra("Price"),
                Image = image
            };
            var db = new SQLiteConnection(filePath);
            db.Insert(book);
            StartActivity(typeof(HomeActivity));
        }

        private void ChooseFile_Click(object sender, EventArgs e) {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(
                Intent.CreateChooser(imageIntent, "Select photo"), 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data) {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok) {
                textbookPic.SetImageURI(data.Data);
                string filepath = GetPathToImage(data.Data);
                image = File.ReadAllBytes(filepath);
            }
        }

        private string GetPathToImage(Android.Net.Uri uri) {
            ICursor cursor = this.ContentResolver.Query(uri, null, null, null, null);
            cursor.MoveToFirst();
            string document_id = cursor.GetString(0);
            document_id = document_id.Split(':')[1];
            cursor.Close();

            cursor = ContentResolver.Query(
            Android.Provider.MediaStore.Images.Media.ExternalContentUri,
            null, MediaStore.Images.Media.InterfaceConsts.Id + " = ? ", new String[] { document_id }, null);
            cursor.MoveToFirst();
            string path = cursor.GetString(cursor.GetColumnIndex(MediaStore.Images.Media.InterfaceConsts.Data));
            cursor.Close();

            return path;
        }

        private void Home_Click(object sender, EventArgs e) {
            StartActivity(typeof(HomeActivity));
        }
    }
}
