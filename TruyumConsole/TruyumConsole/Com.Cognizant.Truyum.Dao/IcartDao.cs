using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.Truyum.Model;

namespace Com.Cognizant.Truyum.Dao
{
    interface IcartDao
    {
        void AddCartItem(long userId, long menuItemId);
        Cart GetAllCartItems(long userId); // cart raises cart empty exception
        void RemoveCartItem(long userId, long productId);
    }
}
