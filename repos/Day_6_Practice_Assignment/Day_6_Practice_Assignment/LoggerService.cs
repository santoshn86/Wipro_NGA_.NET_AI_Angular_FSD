using System;
using System.Collections.Generic;
using System.Text;

namespace RealTime_Order_Notification_System
{
    internal class LoggerService
    {
        public void LogOrder(Order order)
        {
            Console.WriteLine(
                $"Order #{order.OrderId} logged successfully.");
        }
    }
}
