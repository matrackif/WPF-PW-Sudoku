using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WindowsProgrammingWPFLab4
{

    public class NameLengthRule : ValidationRule
    {
    

        public NameLengthRule()
        {
        }

        /*
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
        */
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {


            if (((string)value).Length < 1)
                return new ValidationResult(false, "Name must have at least 1 character ");

            return new ValidationResult(true, null);

        }
    }
}