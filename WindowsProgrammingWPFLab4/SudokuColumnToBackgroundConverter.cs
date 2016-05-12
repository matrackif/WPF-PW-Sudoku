using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WindowsProgrammingWPFLab4
{
    public class SudokuColumnToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            ItemsControl ic = value as ItemsControl;
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Green);
         
            for (int i = 0; i < ic.Items.Count; i++)
            {
                Button b = ic.Items[i] as Button;
                if (b != null )
                {
                   
                        return new SolidColorBrush(Colors.DeepPink);
                }           
            }
            return myBrush;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}