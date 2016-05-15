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
    /// Interaction logic for HighScoresWindow.xaml
    /// </summary>
    public partial class HighScoresWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        List<string> highScores;
        List<string> names;
        List<HighScoreEntry> entries;
        public HighScoresWindow(List<string> _scores, List<string> _names)
        {
            InitializeComponent();
            this.DataContext = this;
            entries = new List<HighScoreEntry>();
            highScores = _scores;
            names = _names;
            
            for (int i = 0; i < highScores.Count && i < names.Count; i++)
            {
                if(i%2 == 0)
                    entries.Add(new HighScoreEntry() { Name = names[i],HighScore = highScores[i], BrushColor = new SolidColorBrush(Colors.Blue)});
                else
                    entries.Add(new HighScoreEntry() { Name = names[i], HighScore = highScores[i], BrushColor = new SolidColorBrush(Colors.DarkOrange) });
            }

          

        }

        public List<string> HighScores
        {
            get { return highScores; }
            
        }

        public List<string> Names
        {
            get { return names; }

        }
        public List<HighScoreEntry> Entries
        {
            get { return entries; }
            set { entries = value;
                RaisePropertyChanged("Entries");
            }
        }
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public class HighScoreEntry
        {
            public string Name { get; set; }
            public string HighScore { get; set; }
            public Brush BrushColor { get; set; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource cvs = ((CollectionViewSource)Resources["SortedItems"]);
            var list = cvs.View.Cast<HighScoreEntry>().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                    list[i].BrushColor = new SolidColorBrush(Colors.Blue);
                else
                    list[i].BrushColor = new SolidColorBrush(Colors.DarkOrange);
            }

            Entries = list;
        }
    }
}
