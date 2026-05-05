namespace RealTime_Order_Notification_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Publisher
            OrderProcessor processor = new OrderProcessor();

            // Subscribers
            EmailService emailService = new EmailService();
            SMSService smsService = new SMSService();
            LoggerService loggerService = new LoggerService();

            // Subscribe dynamically
            processor.OnOrderPlaced += emailService.SendEmail;
            processor.OnOrderPlaced += smsService.SendSMS;
            processor.OnOrderPlaced += loggerService.LogOrder;

            Console.WriteLine("ALL SERVICES SUBSCRIBED");

            // Create Order
            Order order1 = new Order(
                101,
                "Santosh",
                2500);

            // Process order
            processor.ProcessOrder(order1);

            Console.WriteLine();

            // Bonus: Unsubscribe dynamically
            Console.WriteLine("SMS SERVICE UNSUBSCRIBED");
            processor.OnOrderPlaced -= smsService.SendSMS;

            Order order2 = new Order(
                102,
                "Rahul",
                4000);

            processor.ProcessOrder(order2);

            Console.WriteLine();
            Console.WriteLine("System execution completed.");
        }
    }
}
