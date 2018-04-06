using HalloXamarinForms.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HalloXamarinForms
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            con = DependencyService.Get<ISQLliteHelper>().GetConnection();

            con.CreateTableAsync<Person>(); //Falls Tabelle bereits vorhanden wird diese Tabelle nicht erstellt
		}

        SQLiteAsyncConnection con;

        public void buttonLogin_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Titel", "Hallo Message", "Okay");
        }

        public void buttonEinfügen_Clicked(object sender, EventArgs e)
        {
            Person p = new Person();
            p.Name = entryEingabe.Text;
            p.Status = "Online";

            con.InsertAsync(p);
        }

        public async void listViewDaten_Refreshing(object sender, EventArgs e)
        {
            listViewDaten.ItemsSource = await con.Table<Person>().ToListAsync();
            listViewDaten.EndRefresh();
        }
	}
}
