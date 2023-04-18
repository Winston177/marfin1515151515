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

namespace WpfApp4.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public AddWindow()
        {
            DataContext = this;
            InitializeComponent();
            
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            using(AppContext db = new AppContext()) 
            {
                if (!ValidData.IsValidPrice(Price) || !ValidData.IsDescriptionValid(Description) || !ValidData.IsValidProductName(ProductName))
                {
                    MessageBox.Show("Неправильно введены данные");
                    return;
                }
                try
                {
                    var product = db.Products.Where(x => x.ProductName == ProductName && x.Price == Price && x.Description == Description).FirstOrDefault();
                    if (product != null)
                    {
                        MessageBox.Show("Такой продукт уже есть");
                        return;
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Неправильно введены данные");
                    return;
                }
                db.Products.Add(new Product(ProductName, Description, Price));
                db.SaveChanges();
                MessageBox.Show("Готово");
                this.Close();
            }
        }
    }
}
