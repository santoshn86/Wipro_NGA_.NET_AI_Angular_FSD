using System;
using System.Collections.Generic;
using System.Text;

namespace RealTime_Order_Notification_System
{
    public delegate void OrderPlacedHandler(Order order);

    public class OrderProcessor
    {
        // Event Declaration
        public event OrderPlacedHandler OnOrderPlaced;

        public void ProcessOrder(Order order)
        {
            try
            {
                if (order == null)
                    throw new ArgumentNullException("Order cannot be null.");

                Console.WriteLine();
                Console.WriteLine("==================================");
                Console.WriteLine($"Order Placed: {order.OrderId}");
                Console.WriteLine($"Customer: {order.CustomerName}");
                Console.WriteLine($"Amount: ₹{order.Amount}");
                Console.WriteLine("==================================");

                // Null-safe event invocation
                OnOrderPlaced?.Invoke(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while processing order: " + ex.Message);
            }
        }
    }
}
