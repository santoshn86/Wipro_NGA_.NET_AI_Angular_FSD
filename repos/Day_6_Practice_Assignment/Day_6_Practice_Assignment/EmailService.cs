using System;
using System.Collections.Generic;
using System.Text;

namespace RealTime_Order_Notification_System
{
    internal class EmailService
    {
        public void SendEmail(Order order)
        {
            Console.WriteLine(
                $"Email sent to {order.CustomerName} for Order #{order.OrderId}");
        }
    }
}
