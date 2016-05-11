using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProgrammingWPFLab4
{
    public class SudokuInfoCollection : ObservableCollection<SudokuButtonInfo>
    {
        public SudokuInfoCollection() : base() { }

        public void Add(List<SudokuButtonInfo> sudokuInfos)
        {
            foreach (SudokuButtonInfo sbi in sudokuInfos) this.Add(sbi);
        }
       

    }
}
