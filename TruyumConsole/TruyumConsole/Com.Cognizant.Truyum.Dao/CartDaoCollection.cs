using Com.Cognizant.Truyum.Model;
using System.Collections.Generic;

namespace Com.Cognizant.Truyum.Dao
{
    class CartDaoCollection : IcartDao
    {
        private static Dictionary<long, Cart> userCart;

        //constructor
        public CartDaoCollection()
        {
            if (userCart == null)
            {
                userCart = new Dictionary<long, Cart>();

            }
        }

        public void AddCartItem(long userId, long menuItemId)
        {
            MenuItemDaoCollection menuItemDao = new MenuItemDaoCollection(); //instantiation
            MenuItem menuItem = menuItemDao.GetMenuItem(menuItemId);

            if (userCart.ContainsKey(userId))//checking existence of user
            {
                userCart[userId].MenuItemList.Add(menuItem);
            }
            else
            {
                List<MenuItem> menuItemList = new List<MenuItem>() { menuItem };
                userCart.Add(userId, new Cart(menuItemList, 0));
            }

        }

        public Cart GetAllCartItems(long userId)
        {
            //calculate total price
            float totalPrice = 0f;

            // get the cart
            var menuItemList = userCart[userId];
            if (menuItemList.MenuItemList.Count.Equals(0))
            {
                throw new CartEmptyException();
            }
            else
            {
                //adding up menuitem prices
                foreach (var item in menuItemList.MenuItemList)
                {
                    totalPrice += item.Price;
                }

            }
            Cart cart = new Cart(menuItemList.MenuItemList, totalPrice);
            return cart;
        }

        public void RemoveCartItem(long userId, long productId)
        {
            List<MenuItem> menuItem = userCart[userId].MenuItemList;
            foreach (MenuItem item in menuItem)
            {
                if (item.Id.Equals(productId))
                {
                    userCart[userId].MenuItemList.Remove(item);
                    break;
                }
            }
        }
    }
}
