using BookFinder.EnumTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookFinder.Helper
{
    public class LanguageChangeHelper
    {
        public static EnumLanguage enumLanguage = new EnumLanguage();

        public void ChangeLanguage(EnumLanguage oldEnumLanguage,EnumLanguage newEnumLanguage)
        {
            ResourceDictionary oldResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri($"{oldEnumLanguage.ToString()}.xaml", UriKind.RelativeOrAbsolute)
            };

            ResourceDictionary newResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri($"{newEnumLanguage.ToString()}.xaml", UriKind.RelativeOrAbsolute)
            };
        
            Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                App.Current.Resources.MergedDictionaries.Add(newResourceDictionary);
                App.Current.Resources.MergedDictionaries.Remove(oldResourceDictionary);     
            }));

            enumLanguage = newEnumLanguage;

        }
    }
}
