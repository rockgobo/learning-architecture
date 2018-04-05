using lifbi.bookers.logic;
using lifbi.bookers.model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifbi.bookers.ui.wpf
{
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            core = new Core();

            books = core.Repository.GetAll<Book>();
        }
        private readonly Core core;

        private IEnumerable<Book> books;
        public IEnumerable<Book> Books {
            get => books;
            set => SetProperty(ref books, value);
        }
    }
}
