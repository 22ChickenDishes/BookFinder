using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Animation;
using System.Reflection;

namespace BookFinder.Helper
{
    public class RegistryHelper
    {
        /// <summary>
        /// 获取注册表所在的系统视图
        /// </summary>
        private static RegistryView registryView = Environment.Is64BitOperatingSystem? RegistryView.Registry64 : RegistryView.Registry32;

        /// <summary>
        /// 注册表的第一级处理文件名
        /// </summary>
        private static string registryFileName = "SOFTWARE";

        private static string ProductName { get {
                Assembly assembly = Assembly.GetExecutingAssembly();
                object[] objects = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (objects.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)objects[0]).Product;
            } } 

        public static void CreateRegistFileAndValue(string key,string value)
        {
           
            //RegistryView registryView =Environment.Is64BitOperatingSystem? RegistryView.Registry64 :  RegistryView.Registry32;

            //RegistryKey registry =  RegistryKey.OpenBaseKey(RegistryHive.LocalMachine , registryView);

            //+"\\SOFTWARE"
            RegistryKey registry = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, registryView);
           
            RegistryKey registry2 = registry.OpenSubKey(registryFileName, true);
            if (registry2 == null)
            {
                registry2 = registry.CreateSubKey(registryFileName, true);
                if (registry2 == null)
                {
                    return;
                }
            }
            RegistryKey registry3 = registry2.CreateSubKey(ProductName, true);
            registry3.SetValue(key, value);
        }

        public static string ReadRegistryValue(string key)
        {
            if (!IsRegeditItemExist(ProductName))
            {
                return null;
            }
            if (!IsRegeditKeyExit(key))
            {
                return null;
            }
            string info = null;
            RegistryKey registry = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, registryView);
            RegistryKey myreg = registry.OpenSubKey(registryFileName).OpenSubKey(ProductName, true);
            info = myreg.GetValue(key).ToString();
            myreg.Close();
            return info;
        }

        public static void DeleRegistryValue(string key)
        {
            if (!IsRegeditItemExist(ProductName))
            {
                return;
            }
            if (!IsRegeditKeyExit(key))
            { 
                return ;
            }
            RegistryKey delKey = Registry.LocalMachine.OpenSubKey(registryFileName, true);
            delKey.DeleteValue(key);
            delKey.Close();
        }

        private static bool IsRegeditItemExist(string fileName)
        {
            string[] subkeyNames;
            RegistryKey hkml = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, registryView);
            //RegistryKey software = hkml.OpenSubKey(SOFTWARE);
            RegistryKey software = hkml.OpenSubKey(registryFileName, true);
            if (software == null)
            {
                CreateRegistFileAndValue(fileName, "");
                software = hkml.OpenSubKey(registryFileName, true);
                if (software == null)
                { 
                    return false;
                }
            }
            subkeyNames = software.GetSubKeyNames();
            //取得该项下所有子项的名称的序列，并传递给预定的数组中  
            foreach (string keyName in subkeyNames) //遍历整个数组
        {
                if (keyName == fileName) //判断子项的名称
        {
                    hkml.Close();
                    return true;
                }
            }
            hkml.Close();
            return false;
        }


        private static bool IsRegeditKeyExit(string key)
        {
            string[] subkeyNames;
            RegistryKey hkml = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, registryView);
            //RegistryKey software = hkml.OpenSubKey(SOFTWAREtest);
            RegistryKey software = hkml.OpenSubKey(registryFileName, true);
            subkeyNames = software.GetValueNames();
            //取得该项下所有键值的名称的序列，并传递给预定的数组中  
            foreach (string keyName in subkeyNames)
            {
                if (keyName == key)// 判断键值的名称
            {
                    hkml.Close();
                    return true;
                }
            }
            hkml.Close();
            return false;
        }
    }
}
