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
using WpfApp4.Windows;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Product SelectedProduct { get; set; }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            using (AppContext db = new AppContext())
            {
                ListBox.ItemsSource = new ObservableCollection<Product>(db.Products.ToList());
            }

        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
            using (AppContext db = new AppContext()) 
            {
                ListBox.ItemsSource = new ObservableCollection<Product>(db.Products.ToList());
            }
            
        }

        private void editbtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProduct == null)
            {
                MessageBox.Show("Продукт не выбран");
                return;
            }
            EditWindow editWindow = new EditWindow(SelectedProduct);
            editWindow.DataContext = this;
            editWindow.ShowDialog();
            using (AppContext db = new AppContext())
            {
                ListBox.ItemsSource = new ObservableCollection<Product>(db.Products.ToList());
            }
        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            using(AppContext db = new AppContext())
            {
                if(SelectedProduct == null)
                {
                    MessageBox.Show("Продукт не выбран");
                    return;
                }
                db.Products.Remove(SelectedProduct);
                db.SaveChanges();
                ListBox.ItemsSource = new ObservableCollection<Product>(db.Products.ToList());
                MessageBox.Show("Готово");
            }
        }
    }
}
