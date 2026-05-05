using System;
using System.Collections.Generic;
using System.Text;

namespace RealTime_Order_Notification_System
{
    internal class SMSService
    {
        public void SendSMS(Order order)
        {
            Console.WriteLine(
                $"SMS sent to {order.CustomerName} for Order #{order.OrderId}");
        }
    }
}
