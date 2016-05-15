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
    /// Interaction logic for NameInputWindow.xaml
    /// </summary>
    public partial class NameInputWindow : Window,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string name;
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;
        public NameInputWindow()
        {
            name = "";
           
            InitializeComponent();
            this.DataContext = this;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            
            RaiseCustomEvent(this, new CustomEventArgs(NameBox.Text));//sending a custom event to parent window so it gets the input name
            this.Close();
        }
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        public string Name
        {
            get { return name; }
            set { name = value;
                RaisePropertyChanged("Name");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NameBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string s)
        {
            msg = s;
        }
        private string msg;
        public string Message
        {
            get { return msg; }
        }
    }
}
