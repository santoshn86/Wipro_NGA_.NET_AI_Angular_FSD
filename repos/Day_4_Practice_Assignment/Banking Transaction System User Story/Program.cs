namespace Banking_Transaction_System_User_Story
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankingSystem bank = new BankingSystem();

            // Create Accounts
            bank.CreateAccount("A101", 5000);
            bank.CreateAccount("A102", 3000);

            // Add Transactions
            bank.AddTransaction(new Transaction("T1", "A101", 1000));   // deposit
            bank.AddTransaction(new Transaction("T2", "A101", -2000));  // withdrawal
            bank.AddTransaction(new Transaction("T3", "A102", -4000));  // insufficient
            bank.AddTransaction(new Transaction("T1", "A101", 500));    // duplicate

            // Process Transactions
            bank.ProcessTransactions();

            // Show Balance
            bank.ShowBalance("A101");

            // Rollback
            bank.Rollback();

            // Show Balance After Rollback
            bank.ShowBalance("A101");

            // Show History
            bank.ShowHistory();
        }
    }
}
