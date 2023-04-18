using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class ValidData
    {
        public static bool IsValidProductName(string ProductName)
        {
            if (string.IsNullOrEmpty(ProductName))
                return false;
            if(ProductName.Length > 30)
                return false;
            return true;
        }
        public static bool IsValidPrice(double? Price)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Price)))
            {
                return false;
            }
            try
            {
                Convert.ToDouble(Price);
            }
            catch (Exception ex)
            {
                return false;
            }
            if(Price > 1000000000)
                return false;
            return true;
        }
        public static bool IsDescriptionValid(string Description)
        {
            if (string.IsNullOrEmpty(Description))
                return false;
            if(Description.Length > 30)
                return false;
            return true;
        }
    }
}
