using BookFinder.EnumTypes;
using BookFinder.Helper;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BookFinder
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public ResourceDictionary resourceDictionary = new ResourceDictionary();

        protected override void OnStartup(StartupEventArgs e)
        {
            #region 加载多语言
            string lang; 
            string languageInfo =  RegistryHelper.ReadRegistryValue("Language");
            if (languageInfo == null)
            {
                lang = System.Globalization.CultureInfo.CurrentCulture.Name; // 区域性名称              
                switch (lang)
                {
                    case "zh-CN":
                        LanguageChangeHelper.enumLanguage = EnumLanguage.zhcn;
                        RegistryHelper.CreateRegistFileAndValue("Language", LanguageChangeHelper.enumLanguage.ToString());
                        break;
                    case "en":
                        LanguageChangeHelper.enumLanguage = EnumLanguage.en;
                        RegistryHelper.CreateRegistFileAndValue("Language", LanguageChangeHelper.enumLanguage.ToString());
                        break;
                    default:
                        LanguageChangeHelper.enumLanguage = EnumLanguage.en;
                        RegistryHelper.CreateRegistFileAndValue("Language", LanguageChangeHelper.enumLanguage.ToString());
                        break;
                }
            }
            else 
            {
                ResourceDictionary resourceDictionaryLanguage = new ResourceDictionary();
                switch (languageInfo)
                {
                    case "zhcn":
                        LanguageChangeHelper.enumLanguage = EnumLanguage.zhcn;
                        break;
                    case "en":
                        LanguageChangeHelper.enumLanguage = EnumLanguage.en;
                        break;
                    default:
                        LanguageChangeHelper.enumLanguage = EnumLanguage.en;
                        languageInfo = "en";
                        break;

                }
                //resourceDictionaryLanguage
                resourceDictionaryLanguage.Source = new Uri($"Languages//{languageInfo}.xaml", UriKind.RelativeOrAbsolute);
                App.Current.Resources.MergedDictionaries.Add(resourceDictionaryLanguage);
            }
            #endregion

            bool ret = true;
            if (!ret)
            {
                Environment.Exit(0);
            }
            base.OnStartup(e);
        }

    }
}
