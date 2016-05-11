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

        public int boardSize = 9;
        public int BoardSize
        {
            get { return boardSize; }
            //set { boardSize = value; }
        }

        
        private ContextMenu menu;
        SudokuInfoCollection SudokuInfos;
        List<SudokuButtonInfo> sudokuButtons;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            sudokuButtons = new List<SudokuButtonInfo>();
            ////////////////////////
            menu = new ContextMenu(); 

            for (int k = 1; k <= BoardSize; k++)
            {
                MenuItem mi = new MenuItem();
                mi.Header = k.ToString();
                mi.Click += Mi_Click;
                
                menu.Items.Add(mi);

            }
            //////////////////////////
            
            for (int i = 0; i < BoardSize; i++)
            {

                for (int j = 0; j < BoardSize; j++)
                {
                    SudokuButtonInfo info = new SudokuButtonInfo(i,j,"R:"+i+"C:"+j);//this is tempory, later the content will be a binding in the XAML file
                    sudokuButtons.Add(info);
                }

            }
            
            SudokuInfos = new SudokuInfoCollection();
            SudokuInfos.Add(sudokuButtons);
            SudokuGridLayout.ItemsSource = SudokuCollection;
           
          
            
            /*
                for (int i = 0; i < BOARD_SIZE; i++) {
                    ColumnDefinition cd = new ColumnDefinition();

                    SudokuGrid.ColumnDefinitions.Add(cd);

                }
                for (int i = 0; i < BOARD_SIZE; i++)
                {
                   RowDefinition rd = new RowDefinition();

                    SudokuGrid.RowDefinitions.Add(rd);

                }

                for (int i = 0; i < BOARD_SIZE; i++)
                {
                    ColumnDefinition cd = new ColumnDefinition();

                    RadioButtonGrid.ColumnDefinitions.Add(cd);

                }
                for (int i = 1; i <= BOARD_SIZE; i++)
                {
                    RadioButton rb = new RadioButton();
                    rb.Content = i;
                    Grid.SetColumn(rb, i-1);
                    RadioButtonGrid.Children.Add(rb);

                }

                for (int i = 0; i < BOARD_SIZE; i++)
                {

                    for (int j = 0; j < BOARD_SIZE; j++)
                    {
                        Button b = new Button();

                        b.Content = " ";
                        b.ContextMenu = menu;

                        Grid.SetRow(b, i);
                        Grid.SetColumn(b, j);


                        SudokuGrid.Children.Add(b);

                    }

                }
                */
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
            get { return SudokuInfos; }
        }
            
    }
}
