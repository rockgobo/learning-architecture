using HalloXamarinForms.Models;
using HalloXamarinForms.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HalloXamarinForms.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            this.service = new PersonenService();
            ClickCommand = new Command(Clicked);
        }

        private void Clicked(object obj)
        {
            Personenliste = service.GetPersonen();
        }

        private readonly PersonenService service;

        private List<Person> personenliste;
        public List<Person> Personenliste {
            get => personenliste;
            set => SetValue(ref personenliste, value);
        }

        public Command ClickCommand { get; set; }
    }
}
