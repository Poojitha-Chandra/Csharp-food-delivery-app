using Com.Cognizant.Truyum.Model;
using System;
namespace Com.Cognizant.Truyum.Dao
{
    public class CartDaoCollectionTest
    {
        public static void Main(string[] args)
        {

        }
        public static void TestAddCartItem()
        {
            CartDaoCollection cartDao = new CartDaoCollection();
            cartDao.AddCartItem(userId: 1, menuItemId: 1);

        }
        public static void TestGetAllCartItems()
        {
            CartDaoCollection cartDao = new CartDaoCollection();
            Cart cart = cartDao.GetAllCartItems(userId: 1);
            Console.WriteLine("Display Added Cart Item");
            cart.MenuItemList.ForEach(item => Console.WriteLine($"{item.Id} {item.Name} {item.Price} {(item.Active ? "Yes" : "No")} {item.DateOfLaunch} {item.Category} {(item.FreeDelivery ? "Yes" : "No")}"));
        }
        public static void TestRemoveCartItem()
        {
            Console.WriteLine("\n Item Removed from user List");
            CartDaoCollection cartDao = new CartDaoCollection();
            cartDao.RemoveCartItem(userId: 1, productId: 1);
            try
            {

                cartDao.GetAllCartItems(userId: 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }
    }
}
