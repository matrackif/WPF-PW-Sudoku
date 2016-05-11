using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProgrammingWPFLab4
{
    public class SudokuButtonInfo
    {
        int rowIndex;
        int columnIndex;
        string name;
        public int boardSize = 9;
        public int BoardSize
        {
            get { return boardSize; }
            //set { boardSize = value; }
        }
        public SudokuButtonInfo()
        {
        }
        public SudokuButtonInfo(int rowIdx,int colIdx, string _name)
        {
            rowIndex = rowIdx;
            columnIndex = colIdx;
            name = _name;
            boardSize = 9;
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
            set { name = value; }
        }
  
    }
}
