namespace Com.Cognizant.Truyum.Dao
{
    public class CartDaoSqlTest
    {
        public static void Main(string[] args)
        {

        }
        public static void TestAddCartItem()
        {
            CartDaoSql cartDao = new CartDaoSql();
            cartDao.AddCartItem(1, 2);

        }
        public static void TestGetAllCartItems()
        {

        }
        public static void TestRemoveCartItem()
        {

        }
    }
}
