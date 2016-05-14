using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WindowsProgrammingWPFLab4
{
    public class SudokuButtonInfo : INotifyPropertyChanged
    {
        int rowIndex;
        int columnIndex;
        string name;
        Brush b;
        bool _IsChecked;//for radio buttons only
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public SudokuButtonInfo()
        {
        }
        public SudokuButtonInfo(string _name,bool _checked)//constructor for radio buttons
        {
            name = _name;
            _IsChecked = _checked;
        }
        public SudokuButtonInfo(int rowIdx,int colIdx, string _name,Brush br)
        {
            rowIndex = rowIdx;
            columnIndex = colIdx;
            name = _name;
            b = br;
        }
        public int RowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }
        public int ColumnIndex
        {
            get { return columnIndex; }
            set { columnIndex = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value;
                RaisePropertyChanged("Name");
            }
        }
        public bool IsChecked
        {
            get { return _IsChecked; }
            set {
                _IsChecked = value;
                RaisePropertyChanged("IsChecked"); }
        }
        public Brush BackgroundColor
        {
            get { return b; }
            set {
                b = value;
                RaisePropertyChanged("BackgroundColor");
            }
        }
  
    }
}
