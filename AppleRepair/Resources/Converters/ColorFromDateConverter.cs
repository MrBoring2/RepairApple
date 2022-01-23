using AppleRepair.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace AppleRepair.Resources.Converters
{
    internal class ColorFromDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var order = value as Order;
            if (order.Status == "В процессе выполнения")
            {
                if ((order.EndDate.Date - DateTime.Now.Date).Days >= 3 && (order.EndDate.Date - DateTime.Now.Date).Days <= 7)
                {
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#FFF59D");
                }
                else if ((order.EndDate.Date - DateTime.Now.Date).Days >= 1 && (order.EndDate.Date - DateTime.Now.Date).Days <= 2)
                {
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#FFCC80");
                }
                else if ((order.EndDate.Date - DateTime.Now.Date).Days == 0)
                {
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#FFCCBC");
                }
                else
                {
                    return Brushes.Transparent;
                }
            }
            else if (order.Status == "Отменён")
            {
                return (SolidColorBrush)new BrushConverter().ConvertFrom("#FF8A65");
            }
            else
            {

                return (SolidColorBrush)new BrushConverter().ConvertFrom("#C8E6C9");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
