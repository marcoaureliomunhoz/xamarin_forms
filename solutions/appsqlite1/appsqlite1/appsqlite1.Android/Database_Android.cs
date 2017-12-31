using SQLite;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;

using appsqlite1.Droid;

[assembly: Dependency(typeof(Database_Android))]

namespace appsqlite1.Droid
{
    public class Database_Android : IDatabase
    {
        public Database_Android()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var fileName = "torcedor.db3";
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(folder, fileName);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}