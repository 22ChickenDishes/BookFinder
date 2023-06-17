using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace BookFinder.Converts
{
    public class PathToImageSoucreConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imagePath = (string)value;
            ImageSource imageSource = null;
            try
            {
                if (imagePath != null && imagePath != string.Empty)
                {
                    imageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                }
            }
            catch
            { 
            
            }
            return imageSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
