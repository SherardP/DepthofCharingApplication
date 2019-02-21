using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DepthCharingApplicationLibraries;

namespace DepthofCharingMeasurementApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {

            InitializeComponent();
            DataContext = this;

            MenuItem Root = new MenuItem() { Text = "Project Name", ImageSource = "Images/Folder_Open_Icon_16.png" };
            MenuItem Room1 = new MenuItem() { Text = "Room 1", ImageSource = "Images/Home.png" };
            MenuItem Wall1 = new MenuItem() { Text = "Wall 1", ImageSource = "Images/brickwall.png" };
            MenuItem Wall2 = new MenuItem() { Text = "Wall 2", ImageSource = "Images/brickwall.png" };

            Room1.Items.Add(Wall1);
            Room1.Items.Add(Wall2);

            MenuItem Room2 = new MenuItem() { Text = "Room 1", ImageSource = "Images/Home.png" };
            MenuItem Wall3 = new MenuItem() { Text = "Wall 3", ImageSource = "Images/brickwall.png" };
            MenuItem Wall4 = new MenuItem() { Text = "Wall 4", ImageSource = "Images/brickwall.png" };

            Room2.Items.Add(Wall3);
            Room2.Items.Add(Wall4);

            Root.Items.Add(Room1);
            Root.Items.Add(Room2);

            Structure.Items.Add(Root);

            

            //ListView1.Items.Add("test");
        }

        private void MainRibbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TreeViewItem_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DependencyObject depObj = e.OriginalSource as DependencyObject;
            if (depObj != null)
            {
                TreeViewItem tvi = FindParent<TreeViewItem>(depObj);
                if (tvi != null && tvi.IsSelected)
                {
                    //handle right-click here...
                }
            }
        }

        private static T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null) return null;

            var parentT = parent as T;
            return parentT ?? FindParent<T>(parent);
        }

        private void CreateNewProject_Click(object sender, RoutedEventArgs e)
        {
            ProjectWindow PW = new ProjectWindow("Create New Project");
            PW.Show();
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            ProjectWindow PW = new ProjectWindow("Edit Existing Project");
            PW.Show();
            Console.WriteLine(Structure.ItemContainerGenerator.ContainerFromItem(Structure.SelectedItem).ToString());
            if (Structure.SelectedItem.ToString().Equals("Project Name"))
            {
                
            }
        }

        private void Structure_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            
            if (sender.GetType() == typeof(TreeView))
            {
                Console.WriteLine(sender.ToString());
            }
                
            else
                Console.WriteLine("No");
        }

        private string IntToString(int value)
        {
            char[] baseChars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string result = string.Empty;
            int targetBase = baseChars.Length;

            do
            {
                result = baseChars[value % targetBase] + result;
                value = value / targetBase;
            }
            while (value > 0);

            return result;
        }
    }

    /*public class MyItem
    {
        public string UID { get; set; }
        public string Text { get; set; }
        public string ImageSource { get; set; }
    }*/

    public class MenuItem
    {
        public MenuItem()
        {
            this.Items = new ObservableCollection<MenuItem>();
        }

        public string Text { get; set; }
        public string ImageSource { get; set; }

        public ObservableCollection<MenuItem> Items { get; set; }
    }

    
}
