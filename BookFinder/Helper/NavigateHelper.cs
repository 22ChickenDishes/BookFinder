using CommunityToolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookFinder.Helper
{
    public class NavigateHelper
    {
        /// <summary>
        /// 获取或设置导航控件Frame
        /// </summary>
        public Frame Frame { get; set; }

        /// <summary>
        /// 页面跳转
        /// </summary>
        /// <param name="uri"></param>
        public void Navigate(string uri)
        {
            NavigationCommands.GoToPage.Execute(uri, Frame);
        }

        /// <summary>
        /// 页面跳转
        /// </summary>
        /// <param name="uri"></param>
        public void Navigate(object content)
        {
            if (Frame != null)
            {
                Frame.Source = null;
                Frame.Content = content;
            }
        }

        /// <summary>
        /// 单例导航模式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public T NavigateSigton<T>()
        {
            var view = Ioc.Default.GetService(typeof(T));
            Navigate(view);
            return (T)view;
        }
    }
}
