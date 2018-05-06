using System;
using System.IO;

using Android.App;
using Android.OS;
using Android.Widget;
using SQLite;
using UWOBookTrade.Database;

namespace UWOBookTrade.Activities {
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity {
        EditText email;
        EditText password;
        EditText confirmPass;
        Button signUp;
        string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BookTrade.db3");

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);

            email = FindViewById<EditText>(Resource.Id.txtEmail);
            password = FindViewById<EditText>(Resource.Id.txtPassword);
            confirmPass = FindViewById<EditText>(Resource.Id.txtConfirmPassword);
            signUp = FindViewById<Button>(Resource.Id.btnSignUp);
            signUp.Click += SignUp_Click;

            try {
                var db = new SQLiteConnection(filePath);
                db.CreateTable<UserTable>();
                db.CreateTable<BookTable>();
                db.CreateTable<UserBookTable>();
                db.CreateTable<MessageTable>();
            } catch (IOException ex) {
                string reason = string.Format("Faild to create Table - Reason {0}", ex.Message);
                Toast.MakeText(this, reason, ToastLength.Long).Show();
            }
        }

        private void SignUp_Click(object sender, EventArgs e) {
            if (!password.Text.Equals(confirmPass.Text)) {
                Toast.MakeText(this, "Passwords don't match!", ToastLength.Short).Show();
            } else if (!string.IsNullOrEmpty(email.Text)) {
                UserTable user = new UserTable { Email = email.Text, Password = password.Text };
                var db = new SQLiteConnection(filePath);
                db.Insert(user);
                Toast.MakeText(this, "Successfully registered!", ToastLength.Short).Show();
                StartActivity(typeof(LoginActivity));
            } else {
                Toast.MakeText(this, "Enter valid email address!", ToastLength.Short).Show();
            }
        }
    }
}
