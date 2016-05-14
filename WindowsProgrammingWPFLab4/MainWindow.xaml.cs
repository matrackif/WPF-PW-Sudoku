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

namespace WindowsProgrammingWPFLab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int boardSize;
        public string StarRowColoumnFormattedString;        
        SudokuInfoCollection TopButtonInfoCollection;
        SudokuInfoCollection RightButtonInfoCollection;    
        SudokuInfoCollection SudokuButtonInfoCollection;
        SudokuInfoCollection RadioButtonInfoCollection;
        List<SudokuButtonInfo> SudokuButtonInfos;
        List<SudokuButtonInfo> RadioButtonInfos;
        List<SudokuButtonInfo> TopButtonInfos;
        List<SudokuButtonInfo> RightButtonInfos;
        public MainWindow()
        {
            InitializeComponent();
            boardSize = 9;
            this.DataContext = this;
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
          

            for (int k = 1; k <= BoardSize; k++)
            {
                SudokuButtonInfo RadioButtonInfo = new SudokuButtonInfo(k.ToString(),false);
                SudokuButtonInfo TopButtonInfo = new SudokuButtonInfo(0,k-1,"",new SolidColorBrush(Colors.Green));
                SudokuButtonInfo RightButtonInfo = new SudokuButtonInfo(k-1,0,"", new SolidColorBrush(Colors.Green));
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
                StarRowColoumnFormattedString += (i+",");
                for (int j = 0; j < BoardSize; j++)
                {
                    SudokuButtonInfo info = new SudokuButtonInfo(i,j,"", new SolidColorBrush(Colors.White));//this sets the row index and column index for the Grid inside the ItemsControl
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

                 if(info.RowIndex == row && info.ColumnIndex == col)
                  {
                    info.Name = (menuItem.Header as string);  //changing the property of the specific button so GUI can draw new button  
                    
                    if(RadioButtonInfos[int.Parse(info.Name) - 1].IsChecked)
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
                 else if(info.RowIndex == row && !info.Name.Equals(""))
                    ElementsInSameRow.Add(int.Parse(info.Name));
                 else if (info.ColumnIndex == col && !info.Name.Equals(""))
                    ElementsInSameColumn.Add(int.Parse(info.Name));
            }

          if((ElementsInSameRow.Count() == ElementsInSameRow.Distinct().Count()))//means we have all unique elements
            {
                //MessageBox.Show("Same elements: "+ ElementsInSameRow.Count()+" Distinct: "+ ElementsInSameRow.Distinct().Count());
                RightButtonInfos[row].BackgroundColor = new SolidColorBrush(Colors.Green);

            }
            else
            {
                RightButtonInfos[row].BackgroundColor = new SolidColorBrush(Colors.Red);
            }
          //////Now we check the columns
            if ((ElementsInSameColumn.Count() == ElementsInSameColumn.Distinct().Count()))//means we have all unique elements
            {
                //MessageBox.Show("Same elements: " + ElementsInSameRow.Count() + " Distinct: " + ElementsInSameRow.Distinct().Count());
                TopButtonInfos[col].BackgroundColor = new SolidColorBrush(Colors.Green);

            }
            else
            {
                TopButtonInfos[col].BackgroundColor = new SolidColorBrush(Colors.Red);
            }




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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
          
                
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

                foreach(SudokuButtonInfo RadioInfo in RadioButtonInfos)//allow only 1 radio button to be selected, delete this loop in order to allow more than 1 to be selected
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

    }
}
