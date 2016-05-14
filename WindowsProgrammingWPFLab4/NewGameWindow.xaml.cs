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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Threading;
using System.Diagnostics;


namespace WindowsProgrammingWPFLab4
{
    /// <summary>
    /// Interaction logic for NewGameWindow.xaml
    /// </summary>
    public partial class NewGameWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int boardSize;
        public string StarRowColoumnFormattedString;
        public string timerString;
        public bool gameIsWon;
        DispatcherTimer GameTimer;
        Stopwatch GameStopwatch;
        SudokuInfoCollection TopButtonInfoCollection;
        SudokuInfoCollection RightButtonInfoCollection;
        SudokuInfoCollection SudokuButtonInfoCollection;
        SudokuInfoCollection RadioButtonInfoCollection;
        List<SudokuButtonInfo> SudokuButtonInfos;
        List<SudokuButtonInfo> RadioButtonInfos;
        List<SudokuButtonInfo> TopButtonInfos;
        List<SudokuButtonInfo> RightButtonInfos;
        List<string> highScores;
        List<string> names;
        public NewGameWindow(int bSize, List<string> _scores, List<string> _names)
        {
            InitializeComponent();
            this.DataContext = this;
            gameIsWon = true;
            timerString = "";
            GameTimer = new DispatcherTimer();
            GameStopwatch = new Stopwatch();
            GameTimer.Interval = new TimeSpan(0, 0, 1);
            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Start();
            GameStopwatch.Start();
            boardSize = bSize;

            //The Lists that will hold the information of the buttons
            SudokuButtonInfos = new List<SudokuButtonInfo>();
            RadioButtonInfos = new List<SudokuButtonInfo>();
            TopButtonInfos = new List<SudokuButtonInfo>();
            RightButtonInfos = new List<SudokuButtonInfo>();
            //Now initializing the Observable collections that will hold the List elements defined above
            SudokuButtonInfoCollection = new SudokuInfoCollection();
            RadioButtonInfoCollection = new SudokuInfoCollection();
            TopButtonInfoCollection = new SudokuInfoCollection();
            RightButtonInfoCollection = new SudokuInfoCollection();
            ////////////////////////
            highScores = _scores;
            names = _names;

            for (int k = 1; k <= BoardSize; k++)
            {
                SudokuButtonInfo RadioButtonInfo = new SudokuButtonInfo(k.ToString(), false);
                SudokuButtonInfo TopButtonInfo = new SudokuButtonInfo(0, k - 1, "", new SolidColorBrush(Colors.Green));
                SudokuButtonInfo RightButtonInfo = new SudokuButtonInfo(k - 1, 0, "", new SolidColorBrush(Colors.Green));
                RadioButtonInfos.Add(RadioButtonInfo);
                TopButtonInfos.Add(TopButtonInfo);
                RightButtonInfos.Add(RightButtonInfo);
                MenuItem mi = new MenuItem();
                mi.Header = k.ToString();
                mi.Click += Mi_Click;

                ((ContextMenu)Resources["SudokuMenu"]).Items.Add(mi);

            }
            //////////////////////////

            for (int i = 0; i < BoardSize; i++)
            {
                StarRowColoumnFormattedString += (i + ",");
                for (int j = 0; j < BoardSize; j++)
                {
                    SudokuButtonInfo info = new SudokuButtonInfo(i, j, "", new SolidColorBrush(Colors.White));//this sets the row index and column index for the Grid inside the ItemsControl
                    SudokuButtonInfos.Add(info);
                }

            }

            //Making the ItemsControl in the XAML use the SudokuInfoCollection for its source of button information
            SudokuButtonInfoCollection.Add(SudokuButtonInfos);
            SudokuGridLayout.ItemsSource = SudokuButtonInfoCollection;

            RadioButtonInfoCollection.Add(RadioButtonInfos);
            RadioButtonLayout.ItemsSource = RadioButtonInfoCollection;

            TopButtonInfoCollection.Add(TopButtonInfos);
            TopGridLayout.ItemsSource = TopButtonInfoCollection;

            RightButtonInfoCollection.Add(RightButtonInfos);
            RightGridLayout.ItemsSource = RightButtonInfoCollection;


        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //TimerLabel.Content = DateTime.Now.ToString();
            if (GameStopwatch.IsRunning)
            {
                TimeSpan ts = GameStopwatch.Elapsed;
                TimerString = String.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds);



            }
        }

        private void Mi_Click(object sender, RoutedEventArgs e)
        {


            MenuItem menuItem = sender as MenuItem;
            ContextMenu menu = menuItem.Parent as ContextMenu;
            Button b = menu.PlacementTarget as Button;

            string[] RowAndCol = DecodeTag(b.Tag.ToString());
            int row = int.Parse(RowAndCol[0]);
            int col = int.Parse(RowAndCol[1]);

            List<int> ElementsInSameRow = new List<int>();
            List<int> ElementsInSameColumn = new List<int>();
            // MessageBox.Show("Clicked on button with row: " + row+" And column: "+col);

            foreach (SudokuButtonInfo info in SudokuButtonInfos)
            {

                if (info.RowIndex == row && info.ColumnIndex == col)
                {
                    info.Name = (menuItem.Header as string);  //changing the property of the specific button so GUI can draw new button  

                    if (RadioButtonInfos[int.Parse(info.Name) - 1].IsChecked)
                    {
                        LinearGradientBrush myBrush = new LinearGradientBrush();
                        myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
                        myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.5));
                        myBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));

                        info.BackgroundColor = myBrush; //now we have to check if the radio button that corresponds to this number is selected or not
                    }
                    else
                    {
                        SolidColorBrush myBrush = new SolidColorBrush(Colors.White);
                        info.BackgroundColor = myBrush;
                    }
                    if (!info.Name.Equals(""))
                    {
                        ElementsInSameRow.Add(int.Parse(info.Name));
                        ElementsInSameColumn.Add(int.Parse(info.Name));
                    }

                }
                else if (info.RowIndex == row && !info.Name.Equals(""))
                    ElementsInSameRow.Add(int.Parse(info.Name));
                else if (info.ColumnIndex == col && !info.Name.Equals(""))
                    ElementsInSameColumn.Add(int.Parse(info.Name));
            }

            if ((ElementsInSameRow.Count() == ElementsInSameRow.Distinct().Count()))//means we have all unique elements
            {
                RightButtonInfos[row].BackgroundColor = new SolidColorBrush(Colors.Green);
            }
            else
            {
                RightButtonInfos[row].BackgroundColor = new SolidColorBrush(Colors.Red);
            }
            //////Now we check the columns
            if ((ElementsInSameColumn.Count() == ElementsInSameColumn.Distinct().Count()))//means we have all unique elements
            {
                TopButtonInfos[col].BackgroundColor = new SolidColorBrush(Colors.Green);
            }
            else
            {
                TopButtonInfos[col].BackgroundColor = new SolidColorBrush(Colors.Red);
            }


            UpdateGameIsWon();

        }

        public string[] DecodeTag(string s)//decoding the string of the button tag, row is left of "." and col is the right of "." 
        {
            string[] strings = new string[2];
            int l = s.IndexOf(".");
            if (l > 0)
            {
                strings[0] = s.Substring(0, l);
            }
            strings[1] = s.Substring(l + 1);
            return strings;

        }


        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            string SelectedNumber = rb.Content as string;
            if (!RadioButtonInfos[int.Parse(SelectedNumber) - 1].IsChecked)
            {

                foreach (SudokuButtonInfo info in SudokuButtonInfos)
                {
                    if (info.Name.Equals(SelectedNumber))
                    {

                        LinearGradientBrush myBrush = new LinearGradientBrush();
                        myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
                        myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.5));
                        myBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));

                        info.BackgroundColor = myBrush;

                    }
                }
                RadioButtonInfos[int.Parse(SelectedNumber) - 1].IsChecked = true;

                foreach (SudokuButtonInfo RadioInfo in RadioButtonInfos)//allow only 1 radio button to be selected, delete this loop in order to allow more than 1 to be selected
                {
                    if (!RadioInfo.Name.Equals(SelectedNumber)) { RadioInfo.IsChecked = false; }
                }
            }
            else
            {
                foreach (SudokuButtonInfo info in SudokuButtonInfos)
                {
                    if (info.Name.Equals(SelectedNumber))
                    {

                        SolidColorBrush myBrush = new SolidColorBrush(Colors.White);
                        info.BackgroundColor = myBrush;

                    }
                }

                RadioButtonInfos[int.Parse(SelectedNumber) - 1].IsChecked = false;
            }

        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public int BoardSize
        {
            get { return boardSize; }
            set
            {
                boardSize = value;
                RaisePropertyChanged("BoardSize");
            }
        }
        public string StarRowsAndColumns
        {
            get { return StarRowColoumnFormattedString; }
            set
            {
                StarRowColoumnFormattedString = value;
                RaisePropertyChanged("StarRowsAndColumns");
            }
        }
        public string TimerString
        {
            get { return timerString; }
            set
            {
                timerString = value;
                RaisePropertyChanged("TimerString");
            }
        }

        private void NewGameMenuItem_Click(object sender, RoutedEventArgs e)
        {

            BoardSizePrompt p = new BoardSizePrompt(highScores, names, this);
            p.Show();
        }

        private void HighScoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            HighScoresWindow hsw = new HighScoresWindow(highScores, names);
            hsw.Show();
        }
        public bool GameIsWon
        {
            get { return gameIsWon; }
            set
            {
                gameIsWon = value;
                RaisePropertyChanged("GameIsWon");
            }
        }
        public void UpdateGameIsWon()
        {
            foreach (SudokuButtonInfo info in TopButtonInfos)
            {
                SolidColorBrush scb = info.BackgroundColor as SolidColorBrush;
                if (scb.Color == Colors.Red)
                {
                    GameIsWon = false;
                    return;
                }
            }
            foreach (SudokuButtonInfo info in RightButtonInfos)
            {
                SolidColorBrush scb = info.BackgroundColor as SolidColorBrush;
                if (scb.Color == Colors.Red)
                {
                    GameIsWon = false;
                    return;
                }
            }
            GameIsWon = true;
        }

        private void WinButton_Click(object sender, RoutedEventArgs e)
        {
            GameTimer.IsEnabled = false;
            GameStopwatch.Stop();
            highScores.Add(timerString);
            NameInputWindow niw = new NameInputWindow();
            niw.RaiseCustomEvent += new EventHandler<CustomEventArgs>(NameInputWindow_RaiseCustomEvent);//subscribing to a custom event so we can obtain the name inputted from that window
            niw.Show();
        }
        public void NameInputWindow_RaiseCustomEvent(object sender, CustomEventArgs e)
        {
            if (e.Message.Length < 1)
                highScores.RemoveAt(highScores.Count - 1);//if we get empty string dont add to list
            else
            {
                names.Add(e.Message);
                HighScoresWindow hsw = new HighScoresWindow(highScores, names);
                hsw.Show();
            }
               
            //MessageBox.Show(e.Message);
        }
    }
}
