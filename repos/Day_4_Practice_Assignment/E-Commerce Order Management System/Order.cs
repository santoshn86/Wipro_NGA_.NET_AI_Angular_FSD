using System;
using System.Collections.Generic;
using System.Text;

namespace Day_4_Practice_Assignment
{
    internal class Order
    {
        public int OrderId;
        public int CustomerId;
        public string ProductName;
        public string Category;
        public double Price;

        // Stack for status history (LIFO)
        public Stack<string> StatusHistory = new Stack<string>();

        public Order(int orderId, int customerId, string productName, string category, double price)
        {
            OrderId = orderId;
            CustomerId = customerId;
            ProductName = productName;
            Category = category;
            Price = price;

            StatusHistory.Push("Created");
        }
    }

}
