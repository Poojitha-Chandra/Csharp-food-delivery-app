using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.Truyum.Dao
{
    class CommandHelper
    {
        //TODO
        public static readonly string MenuItemListAdmin = "select * from menu_item";
        public static readonly string MenuItemListCustomer = "select * from menu_item where date_launch < getdate() and active_status = true";
        public static readonly string MenuItemList = "select * from menu_item where menu_item_id = @id";
        public static readonly string ModifyMenuItemList = "update menu_item set item_name = @name, price = @price, active_status = @active, date_launch = @dateOfLaunch, category = @category, free_delivery = @freeDelivery";

        public static readonly string AddCartItem = "insert into Cart(userID, menuItemID) values(@userId, @menuItemId)";
        public static readonly string GetAllCartItems = "select m.item_name as Name, m.free_delivery as 'Free Delivery', concat('Rs. ', price) as Price from menu_item m join cart c on m.menu_item_id = c.menu_item_id join user_details u on c.user_id = u.user_id where user_id = @userId";
        public static readonly string RemoveCartItem = "delete from Cart where menu_item_id = @menuId and user_id = @userId";

    }
}