using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using static System.Resources.ResXFileRef;

namespace BookFinder.Converts
{
    public class MaximumRestoreDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = Visibility.Collapsed;
            if (value is WindowState ws)
            {
                if (ws == WindowState.Maximized)
                {
                    visibility = Visibility.Visible;
                }
                else if (ws == WindowState.Normal)
                {
                    visibility = Visibility.Collapsed;
                }

            }

            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
