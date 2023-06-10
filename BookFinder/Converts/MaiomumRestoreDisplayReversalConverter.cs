using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BookFinder.Converts
{
    public class MaiomumRestoreDisplayReversalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = Visibility.Collapsed;
            if (value is WindowState ws)
            {
                if (ws == WindowState.Maximized)
                {
                    visibility = Visibility.Collapsed;
                   
                }
                else if (ws == WindowState.Normal)
                {
                    visibility = Visibility.Visible;
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
