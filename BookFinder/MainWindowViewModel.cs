using BookFinder.Helper;
using BookFinder.Servers;
using BookFinder.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BookFinder
{
    public class MainWindowViewModel:ObservableObject,INavigationService
    {
        private MainWindow _View;

        public Frame MainFrame;

        public RelayCommand<object> MainWindowLoadeCommand => new RelayCommand<object>(OnViewLoaded);

        public RelayCommand WindowCloseCommand => new RelayCommand(WindowClose);

        public string CurrentPageKey => throw new NotImplementedException();

        public void OnViewLoaded(object view)
        {
             _View = view as MainWindow;
          
            if (null != view)
            {
                MainFrame = CustomVisualTreeHelper.GetChildObject<Frame>(_View, "PATE_Prense");
                MainFrame.Source = new Uri("Views\\WindowMain.xaml", UriKind.RelativeOrAbsolute);
            } 
        }

        public void WindowClose()
        {
            _View.Close();
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(string pagekey)
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(string pagekey, string parameter)
        {
            throw new NotImplementedException();
        }
    }
}
