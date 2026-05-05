using System;
using System.Collections.Generic;
using System.Text;

namespace RealTime_Order_Notification_System

{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }

        public Order() {}

        public Order(int orderId, string customerName, decimal amount)
        {
            OrderId = orderId;
            CustomerName = customerName;
            Amount = amount;
        }
    }
}
