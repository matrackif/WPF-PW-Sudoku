using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WindowsProgrammingWPFLab4
{
    /// <summary>
    /// Interaction logic for BoardSizePrompt.xaml
    /// </summary>
    public partial class BoardSizePrompt : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string boardSize;
        public BoardSizePrompt()
        {
            InitializeComponent();
            this.DataContext = this;
            boardSize = 2.ToString();
        }
        
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string BoardSize
        {
            get { return boardSize; }
            set { boardSize = value;
                RaisePropertyChanged("BoardSize");
            }
        }
       
    }
}
