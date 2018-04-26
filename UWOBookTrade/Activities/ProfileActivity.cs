using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using UWOBookTrade.Database;

namespace UWOBookTrade.Activities {
    [Activity(Label = "ProfileActivity")]
    public class ProfileActivity : Activity {

        Button save;
        Button home;
        EditText name;
        EditText description;
        ImageView photo;
        byte[] image;
        string filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BookTrade.db3");

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Profile);

            save = FindViewById<Button>(Resource.Id.btnSave);
            home = FindViewById<Button>(Resource.Id.btnHome);
            name = FindViewById<EditText>(Resource.Id.txtName);
            description = FindViewById<EditText>(Resource.Id.txtDesc);
            photo = FindViewById<ImageView>(Resource.Id.imgPhoto);

            home.Click += Home_Click;
            save.Click += Save_Click;
            photo.Click += Photo_Click;

            image = null;
            FillNameDescription();
        }

        private void Photo_Click(object sender, EventArgs e) {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(
                Intent.CreateChooser(imageIntent, "Select photo"), 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data) {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok) {
                photo.SetImageURI(data.Data);
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

        private void FillNameDescription() {
            var db = new SQLiteConnection(filePath);
            var userTable = db.Table<UserTable>();
            var user = userTable.Where(x => x.Email.Equals(LoginActivity.useremail)).FirstOrDefault();

            if (user.Name != null) {
                name.Text = user.Name;
            }
            if (user.Description != null) {
                description.Text = user.Description;
            }
            if (user.Picture != null) {
                image = user.Picture;
                Bitmap bitmap = BitmapFactory.DecodeByteArray(image, 0, image.Length);
                photo.SetImageBitmap(bitmap);
            }
        }

        private void Save_Click(object sender, EventArgs e) {
            var db = new SQLiteConnection(filePath);
            var userTable = db.Table<UserTable>();
            var user = userTable.Where(x => x.Email.Equals(LoginActivity.useremail)).FirstOrDefault();

            user.Name = name.Text;
            user.Description = description.Text;

            if (image != null) {
                user.Picture = image;
            }

            db.Update(user);
        }

        private void Home_Click(object sender, EventArgs e) {
            StartActivity(typeof(HomeActivity));
        }
    }
}