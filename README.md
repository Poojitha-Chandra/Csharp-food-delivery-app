# Csharp-food-delivery-app
The classes specified in this document are the primary C# classes that are required for implementation of food delivery(truYum) application.
# <h2>Model Namespace</h2>
Following are the real world objects identified for truYum application. Menu Item refers to a menu item available for sale in truYum. Cart will represent customer’s cart to hold the selected menu items.
- “Com.Cognizant.Truyum.Model” represents the namespace
- MenuItem and Cart are classes
- The content within MenuItem are instance variables
- The hypen in each line represents private access specifier
- Constructor with option to set all instance variables
- Generate ToString() method, Equals() method which checks for equality based on the ‘id’ attribute
# <h2>Utility Namespace</h2>
Common reusable classes and methods across truYum application will be included in this namespace.

`DateUtility.cs`The method used in this class should convert the input date entered in string format to Datetime.
# <h2>Dao namespace</h2>
This namespace contains the list of classes that will code to manage the data for truYum application. The methods in Dao classes will be tested using MenuItemDaoCollectionTest and CartDaoCollectionTest classes. The Dao interface classes will act as a contract for working with any database. In this specification the implementation of MenuItemDaoCollection and CartDaoCollection will be Collection framework based implementation of Dao interfaces MenuItemDao and CartDao.
# <h3> Design for View Menu Item List Admin </h3>
`IMenuItemDao.cs`Add the method GetMenuItemListAdmin() with return type List<MenuItem> in the interface.
  
`MenuItemDaoCollection.cs`Class for managing data of menu items using C# Collections Framework.
# <h3>Design for View Menu Item List Customer</h3>
`IMenuItemDao.cs`Add the method GetMenuItemListCustomer() of return type List<MenuItem> in the interface.
  
`MenuItemDaoCollection.cs`This class manages the data related to Menu Items of truYum application. A new method needs to be added for this use case.
# <h3>Design for Edit Menu Item</h3>
`IMenuItemDao.cs`

- Add method ModifyMenuItem(MenuItem menuItem) of return type void in the interface.
- Add method GetMenuItem(long menuItemId) of return type MenuItem in the interface.
`MenuItemDaoCollection.cs`This class manages the data related to Menu Items of truYum application. A new method needs to be added for this use case.
# <h3>Design for Add to Cart</h3>
`ICartDao.cs`Add method AddCartItem(long userId, long menuItemId) of return type void in the interface.

`CartDaoCollection.cs`This class manages the data related to Cart of all users of truYum application.

#<h3>Design for View Cart</h3>
`ICartDao.cs`Add method GetAllCartItems(long userId) of return type void in the interface

`CartEmptyException.cs`Extend this class from System.Exception and include an empty constructor.

`CartDaoCollection.cs`This class manages the data related to Cart of all users of truYum application. A new method needs to be added for this use case.

# <h3>Design for Remove Cart Item</h3>
`ICartDao.cs`Add method RemoveCartItem(long userId, long menuItemId) of return type void in the interface.

`CartDaoCollection.cs`This class manages the data related to Cart of all users of truYum application.
