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
		}

        public void buttonLogin_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Titel", "Hallo Message", "Okay");
        }
	}
}
