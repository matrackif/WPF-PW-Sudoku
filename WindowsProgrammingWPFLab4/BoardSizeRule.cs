using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WindowsProgrammingWPFLab4
{

    public class BoardSizeRule : ValidationRule
    {
        private int _min;
        private int _max;

        public BoardSizeRule()
        {
        }

        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int size = 0;

            try
            {
                if (((string)value).Length > 0)
                    size = Int32.Parse((String)value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Must input integer value " + e.Message);
            }

            if ((size < Min) || (size > Max))
            {
                return new ValidationResult(false,
                  "Please enter an age in the range: " + Min + " - " + Max + ".");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
