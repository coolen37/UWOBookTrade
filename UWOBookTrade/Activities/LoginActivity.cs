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
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity {
        public static string useremail;
        Button login;
        EditText email;
        EditText password;
        string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BookTrade.db3");

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);

            email = FindViewById<EditText>(Resource.Id.txtEmail);
            password = FindViewById<EditText>(Resource.Id.txtPassword);
            login = FindViewById<Button>(Resource.Id.btnLogin);
            login.Click += Login_Click;
        }

        private void Login_Click(object sender, EventArgs e) {
            var db = new SQLiteConnection(filePath);
            var userTable = db.Table<UserTable>();
            var user = userTable.Where(x => x.Email.Equals(email.Text) && x.Password.Equals(password.Text)).FirstOrDefault();
            
            if (user != null) {
                useremail = email.Text;
                StartActivity(typeof(HomeActivity));
            } else {
                Toast.MakeText(this, "Email or Password invalid", ToastLength.Short).Show();
            }           
        }
    }
}