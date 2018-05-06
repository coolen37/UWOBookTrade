using System;

using Android.App;
using Android.OS;
using Android.Widget;
using SQLite;
using UWOBookTrade.Database;

namespace UWOBookTrade.Activities
{
    [Activity(Label = "MessageWriteActivity")]
    public class MessageWriteActivity : Activity
    {
        TextView txtToUsername;
        EditText txtMessageBox;
        TextView history;
        Button sendMsge;
        string filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BookTrade.db3");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MessageWrite);
            
            txtToUsername = FindViewById<TextView>(Resource.Id.txtToUsername);
            history = FindViewById<TextView>(Resource.Id.txtHistory);
            txtMessageBox = FindViewById<EditText>(Resource.Id.txtMessageBox);
            sendMsge = FindViewById<Button>(Resource.Id.btnSendMessage);
            sendMsge.Click += SendMsge_Click;            

            if (Intent.HasExtra("Message")) {
                txtToUsername.Text = Intent.GetStringExtra("User");
                history.Text = Intent.GetStringExtra("Message");
            }
        }

        private void SendMsge_Click(object sender, EventArgs e) {
            MessageTable message = new MessageTable {
                Message = txtMessageBox.Text + "\n" + history.Text,
                User1 = LoginActivity.useremail,
                User2 = txtToUsername.Text
            };
            var db = new SQLiteConnection(filePath);
            db.Insert(message);
            StartActivity(typeof(MessageHomeActivity));
        }
    }
}
