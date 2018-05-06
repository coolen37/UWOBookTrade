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

namespace UWOBookTrade.Activities
{
    [Activity(Label = "BooklistActivity")]
    public class BooklistActivity : Activity
    {
        string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BookTrade.db3");
        ListView bookList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Booklist);

            bookList = FindViewById<ListView>(Resource.Id.lstBooklist);
            string title = Intent.GetStringExtra("Title");
            string isbn = Intent.GetStringExtra("ISBN");
            string author = Intent.GetStringExtra("Author");

            var db = new SQLiteConnection(filePath);
            var bookTable = db.Table<BookTable>();
            var books = bookTable.Where(x => x.BookTitle.Equals(title, StringComparison.InvariantCultureIgnoreCase) &&
                                        x.ISBN.Equals(isbn, StringComparison.InvariantCultureIgnoreCase) &&
                                        x.Author.Equals(author, StringComparison.InvariantCultureIgnoreCase));

            List<string> theBooks = new List<string>();

            if (books.Count() > 0) {
                foreach (BookTable book in books) {
                    theBooks.Add(book.ToString());
                }
                bookList.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, theBooks.ToArray());
            }            
        }
    }
}