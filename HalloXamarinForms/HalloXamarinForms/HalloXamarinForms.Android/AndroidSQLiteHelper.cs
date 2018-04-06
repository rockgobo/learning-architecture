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

[assembly: Xamarin.Forms.Dependency(typeof(HalloXamarinForms.Droid.AndroidSQLiteHelper))]
namespace HalloXamarinForms.Droid
{
    class AndroidSQLiteHelper : ISQLliteHelper
    {
        public SQLiteAsyncConnection GetConnection()
        {
            //data/data/[appname]/files
            var folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var fullpath = Path.Combine(folder, "meinDB.sqlite");
            return new SQLiteAsyncConnection(fullpath);
        }
    }
}