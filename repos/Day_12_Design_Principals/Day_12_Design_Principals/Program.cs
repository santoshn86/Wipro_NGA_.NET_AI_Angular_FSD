namespace Day_12_Design_Principals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            INotificationService notification = new EmailNotification();
            ITransactionRepository repository = new TransactionRepository();
            Wallet wallet = new Wallet(notification, repository);

            // Add money to wallet
            Console.Write("Enter amount to add to wallet: ");
            decimal addAmount = decimal.Parse(Console.ReadLine() ?? "0");
            wallet.AddMoney(addAmount);

            // Pay using UPI
            Console.Write("Enter amount to pay using UPI: ");
            decimal upiAmount = decimal.Parse(Console.ReadLine() ?? "0");
            wallet.MakePayment(new UpiPayment(), upiAmount);

            // Pay using Card
            Console.Write("Enter amount to pay using Card: ");
            decimal cardAmount = decimal.Parse(Console.ReadLine() ?? "0");
            wallet.MakePayment(new CardPayment(), cardAmount);

            // Show current balance
            wallet.ShowBalance();
            wallet.ShowTransactions();
        }
    }
}
