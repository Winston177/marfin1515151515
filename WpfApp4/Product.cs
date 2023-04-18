using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp4
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public Product(string ProductName, string Description, double? Price)
        {
            this.ProductName = ProductName;
            this.Description = Description;
            this.Price = Price;
            this.QRCode = QrCodeGenerator.QrCodeGen(ProductName, Description, Price);
        }

        [NotMapped]
        public BitmapImage QRCode { get; set; }





    }
}
