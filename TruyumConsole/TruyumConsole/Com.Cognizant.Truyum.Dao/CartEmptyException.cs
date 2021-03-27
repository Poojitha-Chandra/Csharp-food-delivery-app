using System;

namespace Com.Cognizant.Truyum.Dao
{
    class CartEmptyException : Exception
    {
        private static readonly string DefaultMessage = "Users Cart is Empty";

        public CartEmptyException() : base(DefaultMessage) { }
        
        //empty constructor
        public CartEmptyException(string message) : base(message)
        {

        }
    }
}
