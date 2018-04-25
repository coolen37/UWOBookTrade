using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
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
        string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BookTrade.db3");

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
                //image = File.ReadAllBytes(data.Data.ToString());
            }
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