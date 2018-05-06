using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using SQLite;
using UWOBookTrade.Database;

namespace UWOBookTrade.Activities
{
    [Activity(Label = "MessageHomeActivity")]
    public class MessageHomeActivity : Activity
    {
        TextView txtMessaging;
        ListView lstMessages;
        List<string> theMessages = new List<string>();
        string filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BookTrade.db3");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MessageHome);
            
            txtMessaging = FindViewById<TextView>(Resource.Id.txtMessaging);
            lstMessages = FindViewById<ListView>(Resource.Id.lstMessages);
            
            var db = new SQLiteConnection(filePath);
            var messageTable = db.Table<MessageTable>();
            var messages = messageTable.Where(x => x.User1.Equals(LoginActivity.useremail) || x.User2.Equals(LoginActivity.useremail));

            

            if (messages.Count() > 0) {
                foreach (MessageTable message in messages) {
                    theMessages.Add(message.DisplayName());
                }
            }

            lstMessages.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, theMessages.ToArray());

            lstMessages.ItemClick += LstMessages_ItemClick;
        }

        private void LstMessages_ItemClick(object sender, AdapterView.ItemClickEventArgs e) {
            string name = theMessages[e.Position];
            var db = new SQLiteConnection(filePath);
            var messageTable = db.Table<MessageTable>();
            var messages = messageTable.Where(x => (x.User1.Equals(LoginActivity.useremail) || x.User2.Equals(LoginActivity.useremail)) &&
                                                    (x.User1.Equals(name) || x.User2.Equals(name)));
            string msg = "";
            foreach (MessageTable message in messages) {
                msg = message.Message;
            }
            Intent intent = new Intent(this, typeof(MessageWriteActivity));
            intent.PutExtra("User", theMessages[e.Position]);
            intent.PutExtra("Message", msg);
            StartActivity(intent);
        }
    }
}
