using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookFinder.Helper
{
    public static class GetResourceCopywriting
    {
        /// <summary>
        /// 获取多语言文案
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GrtString(string resourceDictionaryName)
        {
            string tem = null;
            ResourceDictionary resourceDictionary = App.Current.Resources.MergedDictionaries.First(x => x.Source.ToString() == $"{LanguageChangeHelper.enumLanguage.ToString()}.xaml");
            if (resourceDictionary.Contains(resourceDictionaryName))
            {
                return resourceDictionary[resourceDictionaryName].ToString();
            }
            return tem;
        }
    }
}
