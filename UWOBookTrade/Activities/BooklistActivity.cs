using System;
using System.Collections.Generic;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using SQLite;
using UWOBookTrade.Database;

namespace UWOBookTrade.Activities
{
    [Activity(Label = "BooklistActivity")]
    public class BooklistActivity : Activity
    {
        string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BookTrade.db3");
        ListView bookList;
        string title;
        string isbn;
        string author;
        List<string> theBooks = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Booklist);

            bookList = FindViewById<ListView>(Resource.Id.lstBooklist);
            title = Intent.GetStringExtra("Title");
            isbn = Intent.GetStringExtra("ISBN");
            author = Intent.GetStringExtra("Author");

            var db = new SQLiteConnection(filePath);
            var bookTable = db.Table<BookTable>();
            var books = bookTable.Where(x => x.BookTitle.Equals(title) && x.ISBN.Equals(isbn) && x.Author.Equals(author));

            

            if (books.Count() > 0) {
                foreach (BookTable book in books) {
                    theBooks.Add(book.ToString());
                }
                bookList.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, theBooks.ToArray());
            }

            bookList.ItemClick += BookList_ItemClick;
        }

        private void BookList_ItemClick(object sender, AdapterView.ItemClickEventArgs e) {
            string book = theBooks[e.Position];
            string[] b = book.Split();
            int id = int.Parse(b[0]);
            var db = new SQLiteConnection(filePath);
            var bookTable = db.Table<BookTable>();
            var books = bookTable.Where(x => x.BookTitle.Equals(title) && x.ISBN.Equals(isbn) && x.Author.Equals(author));
            var userBookTable = db.Table<UserBookTable>();
            var ubs = userBookTable.Where(x => x.BookId == id);
            var userTable = db.Table<UserTable>();
            StartActivity(typeof(MessageWriteActivity));
        }
    }
}
