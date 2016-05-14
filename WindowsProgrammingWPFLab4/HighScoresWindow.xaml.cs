using System;
using System.Collections.Generic;
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
    public partial class HighScoresWindow : Window
    {
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

           for(int i = 0; i < highScores.Count && i < names.Count; i++)
            {
                if(i%2 == 0)
                    entries.Add(new HighScoreEntry() { Name = names[i],HighScore = highScores[i], BrushColor = new SolidColorBrush(Colors.Blue)});
                else
                    entries.Add(new HighScoreEntry() { Name = names[i], HighScore = highScores[i], BrushColor = new SolidColorBrush(Colors.Pink) });
            }

            //HighScoreListBox.ItemsSource = entries;
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
        }

        public class HighScoreEntry
        {
            public string Name { get; set; }
            public string HighScore { get; set; }
            public Brush BrushColor { get; set; }
        }
    }
}
