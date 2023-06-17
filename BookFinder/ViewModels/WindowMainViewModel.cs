using BookFinder.Attributes;
using BookFinder.Helper.DBHelper;
using BookFinder.Models;
using BookFinder.Servers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.ViewModels
{
    [IocAttribute]
    public  class WindowMainViewModel : ObservableObject
    {
        public RelayCommand<object> WindowMainLoadeCommand => new RelayCommand<object>(OnViewLoaded);

        private ObservableCollection<Book>  books;

        public ObservableCollection<Book> Books
        { 
            get => books;
            set { books = value; OnPropertyChanged(); }
        }

        private void OnViewLoaded(object obj)
        {
            //foreach (var item in IOCContainer.GetSingleton<BookDbManage>().GetAll().ToList())
            //{
            //    Books.Add(item);
            //}
            Books = new ObservableCollection<Book>();
            //IOCContainer.GetSingleton<BookDbManage>().GetAll().ToList();
            for (int i = 0; i < 100; i++)
            {
                Books.Add(new Book() { Title=i.ToString(),BookCover2= "pack://application:,,,/BookFinder;component/Resources/Images/人工智能.jpg" });
            }
            Console.WriteLine(Books[0].ID);
        }
    }
}
