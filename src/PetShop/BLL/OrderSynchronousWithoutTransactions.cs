using System;
using PetShop.IBLLStrategy;

namespace PetShop.BLL {
    /// <summary>
    /// This is a synchronous implementation of IOrderStrategy which does not use a transaction scope 
    /// By implementing IOrderStrategy interface, the developer can add a new order insert strategy without re-compiling the whole BLL 
    /// </summary>
    public class OrderSynchronousWithoutTransactions : IOrderStrategy {

        // Get an instance of the Order DAL using the DALFactory
        // Making this static will cache the DAL instance after the initial load
        private static readonly PetShop.IDAL.IOrder dal = PetShop.DALFactory.DataAccess.CreateOrder();

        /// <summary>
        /// Inserts the order and updates the inventory stock.
        /// </summary>
        /// <param name="order">All information about the order</param>
        public void Insert(PetShop.Model.OrderInfo order)
        {
            dal.Insert(order);

            // Update the inventory to reflect the current inventory after the order submission
            Inventory inventory = new Inventory();
            inventory.TakeStock(order.LineItems);
        }
    }
}