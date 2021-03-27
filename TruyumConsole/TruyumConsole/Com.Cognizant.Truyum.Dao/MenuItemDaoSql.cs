using Com.Cognizant.Truyum.Model;
using Com.Cognizant.Truyum.Utility;
using System.Collections.Generic;
using System.Data.SqlClient; //data provider for SQL Server

namespace Com.Cognizant.Truyum.Dao
{
    class MenuItemDaoSql : IMenuItemDao
    {
        private SqlConnection _sqlConnection; // connection object for SQL Server
        private SqlCommand _sqlCommand;
        private SqlDataReader _sqlDataReader;

        public MenuItem GetMenuItem(long menuItemId)
        {
            MenuItem menuItems = null;
            using (_sqlConnection = new SqlConnection(ConnectionHandler.GetConnection))
            {
                using (_sqlCommand = new SqlCommand())
                {
                    _sqlCommand.Connection = _sqlConnection;
                    _sqlCommand.CommandText = CommandHelper.MenuItemList;
                    _sqlCommand.Parameters.AddWithValue("@id", menuItemId);//retrieves an item from menuItem table based on menuItemId
                    _sqlConnection.Open();
                    _sqlDataReader = _sqlCommand.ExecuteReader();
                    while (_sqlDataReader.Read())
                    {
                        menuItems = new MenuItem
                        {
                            Id = long.Parse(_sqlDataReader[0].ToString()),
                            Name = _sqlDataReader[1].ToString(),
                            Price = float.Parse(_sqlDataReader[2].ToString()),
                            Active = bool.Parse(_sqlDataReader[3].ToString()),
                            DateOfLaunch = DateUtility.ConvertToDate(_sqlDataReader[4].ToString()),
                            Category = _sqlDataReader[5].ToString(),
                            FreeDelivery = bool.Parse(_sqlDataReader[6].ToString())

                        };
                    }
                }
            }
            return menuItems;
        }

        public List<MenuItem> GetMenuItemListAdmin()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            using (_sqlConnection = new SqlConnection(ConnectionHandler.GetConnection))
            {
                using (_sqlCommand = new SqlCommand())
                {
                    _sqlCommand.Connection = _sqlConnection;
                    _sqlCommand.CommandText = CommandHelper.MenuItemListAdmin;
                    _sqlConnection.Open();
                    _sqlDataReader = _sqlCommand.ExecuteReader(); //to retrieve rows from data source
                    while (_sqlDataReader.Read())
                    {
                        menuItems.Add(new MenuItem
                        {
                            Id = long.Parse(_sqlDataReader[0].ToString()),
                            Name = _sqlDataReader[1].ToString(),
                            Price = float.Parse(_sqlDataReader[2].ToString()),
                            Active = bool.Parse(_sqlDataReader[3].ToString()),
                            DateOfLaunch = DateUtility.ConvertToDate(_sqlDataReader[4].ToString()),
                            Category = _sqlDataReader[5].ToString(),
                            FreeDelivery = bool.Parse(_sqlDataReader[6].ToString())

                        });
                    }
                }
            }
            return menuItems;
        }

        public List<MenuItem> GetMenuItemListCustomer()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            using (_sqlConnection = new SqlConnection(ConnectionHandler.GetConnection))
            {
                using (_sqlCommand = new SqlCommand())
                {
                    _sqlCommand.Connection = _sqlConnection;
                    _sqlCommand.CommandText = CommandHelper.MenuItemListCustomer;
                    _sqlConnection.Open();
                    _sqlDataReader = _sqlCommand.ExecuteReader();
                    while (_sqlDataReader.Read())
                    {
                        menuItems.Add(new MenuItem
                        {
                            Id = long.Parse(_sqlDataReader[0].ToString()),
                            Name = _sqlDataReader[1].ToString(),
                            Price = float.Parse(_sqlDataReader[2].ToString()),
                            Active = bool.Parse(_sqlDataReader[3].ToString()),
                            DateOfLaunch = DateUtility.ConvertToDate(_sqlDataReader[4].ToString()),
                            Category = _sqlDataReader[5].ToString(),
                            FreeDelivery = bool.Parse(_sqlDataReader[6].ToString())
                        });
                    }
                }
            }
            return menuItems;
        }

        public void ModifyMenuItem(MenuItem menuItem)
        {
            using (_sqlConnection = new SqlConnection(ConnectionHandler.GetConnection))
            {
                using (_sqlCommand = new SqlCommand())
                {
                    _sqlCommand.Connection = _sqlConnection;
                    _sqlCommand.CommandText = CommandHelper.ModifyMenuItemList;
                    _sqlCommand.Parameters.AddWithValue("@name", menuItem.Name);
                    _sqlCommand.Parameters.AddWithValue("@price", menuItem.Price);
                    _sqlCommand.Parameters.AddWithValue("@active", menuItem.Active);
                    _sqlCommand.Parameters.AddWithValue("@dateOfLaunch", menuItem.DateOfLaunch);
                    _sqlCommand.Parameters.AddWithValue("@category", menuItem.Category);
                    _sqlCommand.Parameters.AddWithValue("@freeDelivery", menuItem.FreeDelivery);

                    _sqlConnection.Open();
                    _sqlCommand.ExecuteNonQuery(); // executes command & returns number of rows affected
                }
            }
        }
    }
}
