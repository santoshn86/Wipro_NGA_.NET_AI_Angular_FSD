namespace Day_4_Practice_Assignment
{
    internal class Program
    {
        public static void Main()
        {
            OrderManagementSystem system = new OrderManagementSystem();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nOrder Management System Menu:");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Add Order");
                Console.WriteLine("3. Update Order");
                Console.WriteLine("4. Process Orders");
                Console.WriteLine("5. Show Order History");
                Console.WriteLine("6. Show Unique Categories");
                Console.WriteLine("7. Remove Order");
                Console.WriteLine("8. Exit");
                Console.Write("Select an option (1-8): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("How many customers do you want to add? ");
                        int customerCount = int.Parse(Console.ReadLine());
                        for (int i = 0; i < customerCount; i++)
                        {
                            Console.Write($"Enter Customer #{i + 1} ID: ");
                            int custId = int.Parse(Console.ReadLine());
                            Console.Write($"Enter Customer #{i + 1} Name: ");
                            string custName = Console.ReadLine();
                            system.AddCustomer(custId, custName);
                        }
                        break;
                    case "2":
                        Console.Write("How many orders do you want to add? ");
                        int orderCount = int.Parse(Console.ReadLine());
                        for (int i = 0; i < orderCount; i++)
                        {
                            Console.Write($"Enter Order #{i + 1} ID: ");
                            int orderId = int.Parse(Console.ReadLine());
                            Console.Write($"Enter Customer ID for Order #{i + 1}: ");
                            int oCustId = int.Parse(Console.ReadLine());
                            Console.Write($"Enter Product Name for Order #{i + 1}: ");
                            string product = Console.ReadLine();
                            Console.Write($"Enter Category for Order #{i + 1}: ");
                            string category = Console.ReadLine();
                            Console.Write($"Enter Price for Order #{i + 1}: ");
                            double price = double.Parse(Console.ReadLine());
                            system.AddOrder(new Order(orderId, oCustId, product, category, price));
                        }
                        break;
                    case "3":
                        Console.Write("Enter Order ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new Product Name: ");
                        string newProduct = Console.ReadLine();
                        Console.Write("Enter new Price: ");
                        double newPrice = double.Parse(Console.ReadLine());
                        system.UpdateOrder(updateId, newProduct, newPrice);
                        break;
                    case "4":
                        system.ProcessOrders();
                        break;
                    case "5":
                        Console.Write("Enter Order ID to show history: ");
                        int histId = int.Parse(Console.ReadLine());
                        system.ShowOrderHistory(histId);
                        break;
                    case "6":
                        system.ShowCategories();
                        break;
                    case "7":
                        Console.Write("Enter Order ID to remove: ");
                        int remId = int.Parse(Console.ReadLine());
                        system.RemoveOrder(remId);
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
