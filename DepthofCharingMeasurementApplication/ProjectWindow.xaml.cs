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

namespace DepthofCharingMeasurementApplication
{
    /// <summary>
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {

        private ViewModel _vm;

        public ProjectWindow(String Title)
        {
            
            InitializeComponent();

            _vm = new ViewModel();
            this.DataContext = _vm;

            _vm.AppTitle = Title;

            //Add code to fill in table data
        }

        public class ViewModel : INotifyPropertyChanged
        {
            private string _appTitle = "MyApp";

            public string AppTitle
            {
                get { return _appTitle; }
                set
                {
                    if (_appTitle == value) return;

                    _appTitle = value;
                    this.OnPropertyChanged("AppTitle");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
