using BookFinder.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookFinder.TemplateSelectors
{
    public class MaximizeAndRestoreTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate dt = null;
            if (item == null)
            {
                return null;
            }
            WindowState value = (WindowState)item;


            // 寻找container元素的父元素WindowMain
            Window tempPre = CustomVisualTreeHelper.GetParentObject<Window>(container, "WindowMain");
            if (null == tempPre) return dt;

            string dataTemplateName = string.Empty;

            switch (value)
            {
                case WindowState.Normal:
                    dataTemplateName = "Restore";
                    break;
                case WindowState.Maximized:
                    dataTemplateName = "Max";
                    break;
                case WindowState.Minimized:
                    break;
            }


            if (!string.IsNullOrEmpty(dataTemplateName))
            {
                // 搜索指定键的功能
                dt = tempPre.TryFindResource(dataTemplateName) as DataTemplate;
            }
            return dt;

        }
    }
}
