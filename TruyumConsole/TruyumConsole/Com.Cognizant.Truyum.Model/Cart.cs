using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.Truyum.Model
{
    public class Cart
    {
        private List<MenuItem> menuItemList;
        private double total;

        //properties
        public List<MenuItem> MenuItemList
        {
            get => menuItemList;
            set { menuItemList = value; }
        }
        public double Total
        {
            get => total;
            set { total = value; }
        }

        public Cart() { }

        //parameterized constructor
        public Cart(List<MenuItem> menuItemList, double total)
        {
            MenuItemList = menuItemList;
            Total = total;
        }

        //generate ToString() method
        public override string ToString()
        {
            return base.ToString();
        }

        //generate Equals() method
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
