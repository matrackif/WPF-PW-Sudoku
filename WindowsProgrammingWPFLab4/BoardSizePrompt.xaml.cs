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
        List<string> scores;
        List<string> names;
        Window parent;
        public BoardSizePrompt(List<string> _scores,List<string> _names,Window ParentWindow)
        {
            InitializeComponent();
            parent = ParentWindow;
            this.DataContext = this;
            boardSize = 2.ToString();
            scores = _scores;
            names = _names;
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

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            NewGameWindow window = new NewGameWindow(int.Parse(BoardSize) * int.Parse(BoardSize), scores,names);
            window.Show();
            parent.Close();
            this.Close();
            
            
        }
    }
}
