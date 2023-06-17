using BookFinder.Helper;
using BookFinder.Helper.DBHelper;
using BookFinder.Models;
using BookFinder.Servers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookFinder
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ImageSource = "/BookFinder;component/Resources/Images/人工智能.jpg";

   
        public MainWindow()
        {
           
            InitializeComponent();
            //this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            //FileStream fileStream = new FileStream(@"C:\Users\86151\Desktop\bbb.csv", FileMode.Open);

            //StreamReader reader = new StreamReader(fileStream, Encoding.GetEncoding("gb2312"));

            //string tem;
            //int i = 0;
            //while ((tem = reader.ReadLine()) != null)
            //{
            //    if (i == 1)
            //    {
            //        string[] strings = tem.Split(',');

            //        Book book = new Book()
            //        {
            //            BookNmae = strings[0],
            //            BookWrter = strings[1],
            //            Price = float.Parse(strings[2]),
            //            ID = strings[4],
            //            NumberOfLoans = 0,
            //            Inventory = 100,
            //            Classification = "计算机科学",
            //            Title = strings[9],
            //            PurchaseNumber = 0,
            //            TimeOfPublication = DateTime.Now,
            //            BookCover2 = strings[8]
            //        };
            //        bookDbManage.Create(book);


            //    }
            //    else
            //    {
            //        i++;
            //    }

            //}

            //Book book = new Book()
            //{
            //    BookNmae = "C++第五版",
            //    BookWrter = "123",
            //    Price = float.Parse("12.58"),
            //    ID = "1234567890112",
            //    NumberOfLoans = 0,
            //    Inventory = 100,
            //    Classification = "计算机科学",
            //    Title = "efhuiyhfuiehfusgauydsbaydfga7tyuw",
            //    PurchaseNumber = 0,
            //    TimeOfPublication = DateTime.Now,
            //    BookCover2 = "1232131231"
            //};
            //bookDbManage.Create(book);
            //new BitmapImage(new Uri(strings[8]))
            OrderSheet sheet = new OrderSheet()
            {
                BookName = "人工智能",
                BookID = "9787111384557",
                Pay = float.Parse("49.00"),
                Classification = "计算机科学",
                OrderSheetUserAccount = "123456",
                PurchaseTime = DateTime.Now
            };
            orderSheetDbManage.Create(sheet);
        }
        BookDbManage bookDbManage;
        OrderSheetDbManage orderSheetDbManage;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer("Server=localhost;Database=DB_LibraryManagement;Trusted_Connection=True"));
            
            var db =  new DbContextOptions<ApplicationDbContext>();
            ApplicationDbContext applicationDbContext = new ApplicationDbContext(db);
            bookDbManage = new BookDbManage(applicationDbContext);
            IOCContainer.AddSingleton(bookDbManage);
            bookDbManage.GetAll();
            orderSheetDbManage = new OrderSheetDbManage(applicationDbContext);
            //RegistryHelper.CreateRegistFile();
        }

        private void WindowMaxButton_Click(object sender, RoutedEventArgs e)
        {
             this.WindowState = WindowState.Maximized;
        }

        private void WindowMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void WindowRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void WindowMinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
