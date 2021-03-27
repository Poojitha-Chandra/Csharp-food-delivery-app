using Com.Cognizant.Truyum.Model;
using Com.Cognizant.Truyum.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Com.Cognizant.Truyum.Dao
{
    class CartDaoSql : IcartDao
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private SqlDataReader _sqlDataReader;
        public void AddCartItem(long userId, long menuItemId)
        {
            Console.WriteLine("Conn open");

           
            try
            {
                _sqlConnection = new SqlConnection(ConnectionHandler.GetConnection);
                _sqlCommand = new SqlCommand();
                _sqlCommand.Connection = _sqlConnection;

                _sqlCommand.CommandText = CommandHelper.AddCartItem;
                _sqlCommand.Parameters.AddWithValue("@userId", userId);
                _sqlCommand.Parameters.AddWithValue("@menuItemId", menuItemId);
                _sqlConnection.Open();

                _sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Data added");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }

        }

        public Cart GetAllCartItems(long userId)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            using (_sqlConnection = new SqlConnection(ConnectionHandler.GetConnection))
            {
                using (_sqlCommand = new SqlCommand())
                {
                    _sqlCommand.Connection = _sqlConnection;
                    _sqlCommand.CommandText = CommandHelper.GetAllCartItems;
                    _sqlCommand.Parameters.AddWithValue("@userId", userId);//retrieve list of menu items associated with specific user
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
            Cart cart = new Cart(menuItems, 0);
            if (cart == null)
            {
                throw new CartEmptyException();
            }
            return cart;
        }

        public void RemoveCartItem(long userId, long productId)
        {
            using (_sqlConnection = new SqlConnection(ConnectionHandler.GetConnection))
            {
                using (_sqlCommand = new SqlCommand())
                {
                    _sqlCommand.Connection = _sqlConnection;
                    _sqlCommand.CommandText = CommandHelper.RemoveCartItem;
                    //delete data into cart table based on userId and menuItemId
                    _sqlCommand.Parameters.AddWithValue("@menuId", productId);
                    _sqlCommand.Parameters.AddWithValue("@userId", userId);
                    _sqlCommand.ExecuteNonQuery();
                    _sqlConnection.Close();
                }
            }
        }
    }
}