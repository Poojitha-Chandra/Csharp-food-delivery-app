using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.Truyum.Model
{
    public class MenuItem
    {
        private long id;
        private string name;
        private float price;
        private bool active;
        private DateTime dateOfLaunch;
        private string category;
        private bool freeDelivery;

        //properties
        public long Id
        {
            get => id;
            set { id = value; }
        }
        public string Name
        {
            get => name;
            set { name = value; }
        }
        public float Price
        {
            get => price;
            set { price = value; }
        }
        public bool Active
        {
            get => active;
            set { active = value; }
        }
        public DateTime DateOfLaunch
        {
            get => dateOfLaunch;
            set { dateOfLaunch = value; }
        }
        public string Category
        {
            get => category;
            set { category = value; }
        }
        public bool FreeDelivery
        {
            get => freeDelivery;
            set { freeDelivery = value; }
        }
        public MenuItem() { }

        // parameterized constructor
        public MenuItem(long id, string name, float price, bool active, DateTime dateOfLaunch, string category, bool freeDelivery)
        {
            Id = id;
            Name = name;
            Price = price;
            Active = active;
            DateOfLaunch = dateOfLaunch;
            Category = category;
            FreeDelivery = freeDelivery;
        }

        //generated ToString() method
        public override string ToString()
        {
            return base.ToString();
        }

        //generated Equals() method
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

    }
}
