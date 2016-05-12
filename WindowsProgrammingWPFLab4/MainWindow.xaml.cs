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
namespace WindowsProgrammingWPFLab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {

        public int boardSize;
        public string StarRowColoumnFormattedString;
        public int BoardSize
        {
            get { return boardSize; }
            set { boardSize = value; }
        }
        public string StarRowsAndColumns
        {
            get { return StarRowColoumnFormattedString; }
            set { StarRowColoumnFormattedString = value; }
        }
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
                SudokuButtonInfo RadioButtonInfo = new SudokuButtonInfo(k.ToString());
                SudokuButtonInfo TopButtonInfo = new SudokuButtonInfo(0,k-1,"");
                SudokuButtonInfo RightButtonInfo = new SudokuButtonInfo(k-1,0,"");
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
                    SudokuButtonInfo info = new SudokuButtonInfo(i,j,"");//this sets the row index and column index for the Grid inside the ItemsControl
                    SudokuButtonInfos.Add(info);
                }

            }
            
          //Making the ItemsControl in the XAML use the SudokuInfoCollection for its source of button information
            SudokuButtonInfoCollection.Add(SudokuButtonInfos);
            SudokuGridLayout.ItemsSource = SudokuCollection;

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
            b.Content = (menuItem.Header as string);
            
            


        }
        public SudokuInfoCollection SudokuCollection
        {
            get { return SudokuButtonInfoCollection; }
        }
            
    }
}
