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

        public RelayCommand WindowMaxCommand => new RelayCommand(WindowMax);

        public RelayCommand WindowRestoreCommand => new RelayCommand(WindowRestore);

        public RelayCommand WindowMinimizeCommand => new RelayCommand(WindowMinimize);

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

        private void WindowClose()
        {
            _View.Close();
        }

        private void WindowMax()
        {
            _View.WindowState = System.Windows.WindowState.Maximized;
        }

        private void WindowRestore()
        {
            _View.WindowState = System.Windows.WindowState.Normal;
        }

        private void WindowMinimize()
        {
            _View.WindowState = System.Windows.WindowState.Minimized;
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

        public void NavigatePrevious()
        {
            throw new NotImplementedException();
        }

        public void NavigateNext()
        {
            throw new NotImplementedException();
        }

        public void Test()
        { 
        
        }
    }
}
