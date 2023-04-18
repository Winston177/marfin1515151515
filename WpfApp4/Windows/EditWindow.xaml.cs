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

    public partial class EditWindow : Window
    {
        Product SelectedProduct { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public EditWindow(Product SelectedProduct)
        {
            DataContext= this;
            InitializeComponent();
            this.SelectedProduct= SelectedProduct;
        }

        private void Editbtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidData.IsValidPrice(Price) || !ValidData.IsDescriptionValid(Description) || !ValidData.IsValidProductName(ProductName))
            {
                MessageBox.Show("Неправильно введены данные");
                return;
            }
            using (AppContext db = new AppContext()) 
            {
                Product newproduct = db.Products.Where(x => x.Id == SelectedProduct.Id).FirstOrDefault();
                newproduct.ProductName = ProductName;
                newproduct.Price = Price;
                newproduct.Description = Description;
                db.SaveChanges();
                MessageBox.Show("Готово");
                this.Close();
            }
        }
    }
}
