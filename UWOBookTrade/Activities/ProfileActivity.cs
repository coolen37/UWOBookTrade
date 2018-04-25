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
        string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BookTrade.db3");

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Profile);

            save = FindViewById<Button>(Resource.Id.btnSave);
            home = FindViewById<Button>(Resource.Id.btnHome);
            name = FindViewById<EditText>(Resource.Id.txtName);
            description = FindViewById<EditText>(Resource.Id.txtDesc);

            home.Click += Home_Click;
            save.Click += Save_Click;

            FillNameDescription();
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

            db.Update(user);
        }

        private void Home_Click(object sender, EventArgs e) {
            StartActivity(typeof(HomeActivity));
        }
    }
}