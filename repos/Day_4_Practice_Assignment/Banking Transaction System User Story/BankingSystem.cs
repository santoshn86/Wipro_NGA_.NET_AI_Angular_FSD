using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Banking_Transaction_System_User_Story
{
    internal class BankingSystem
    {
        // List for transaction history
        private List<Transaction> history = new List<Transaction>();

        // Dictionary for account balances
        private Dictionary<string, double> accounts = new Dictionary<string, double>();

        // Queue for pending transactions (FIFO)
        private Queue<Transaction> pendingQueue = new Queue<Transaction>();

        // Stack for rollback (LIFO)
        private Stack<Transaction> rollbackStack = new Stack<Transaction>();

        // HashSet for unique transaction IDs
        private HashSet<string> txnIds = new HashSet<string>();

        // Create Account
        public void CreateAccount(string accountId, double initialBalance)
        {
            accounts[accountId] = initialBalance;
            Console.WriteLine($"Account {accountId} created with balance {initialBalance}");
        }

        // Add Transaction (enqueue)
        public void AddTransaction(Transaction txn)
        {
            if (!txnIds.Add(txn.TransactionId))
            {
                Console.WriteLine($"Duplicate transaction blocked: {txn.TransactionId}");
                return;
            }

            pendingQueue.Enqueue(txn);
            Console.WriteLine($"Transaction {txn.TransactionId} added to queue.");
        }

        // Process Transactions
        public void ProcessTransactions()
        {
            while (pendingQueue.Count > 0)
            {
                Transaction txn = pendingQueue.Dequeue();

                if (!accounts.ContainsKey(txn.AccountId))
                {
                    Console.WriteLine($"Invalid account: {txn.AccountId}");
                    continue;
                }

                double currentBalance = accounts[txn.AccountId];

                // Check for insufficient balance
                if (txn.Amount < 0 && currentBalance + txn.Amount < 0)
                {
                    Console.WriteLine($"Transaction {txn.TransactionId} failed: Insufficient balance");
                    continue;
                }

                // Apply transaction
                accounts[txn.AccountId] += txn.Amount;

                // Save to history
                history.Add(txn);

                // Push to rollback stack
                rollbackStack.Push(txn);

                Console.WriteLine($"Transaction {txn.TransactionId} processed. New Balance: {accounts[txn.AccountId]}");
            }
        }

        // Rollback last transaction
        public void Rollback()
        {
            if (rollbackStack.Count == 0)
            {
                Console.WriteLine("No transaction to rollback.");
                return;
            }

            Transaction lastTxn = rollbackStack.Pop();

            // Reverse the transaction
            accounts[lastTxn.AccountId] -= lastTxn.Amount;

            history.Remove(lastTxn);

            Console.WriteLine($"Rollback successful for Transaction {lastTxn.TransactionId}. Updated Balance: {accounts[lastTxn.AccountId]}");
        }

        // Show Account Balance
        public void ShowBalance(string accountId)
        {
            if (accounts.ContainsKey(accountId))
            {
                Console.WriteLine($"Account {accountId} Balance: {accounts[accountId]}");
            }
        }

        // Show Transaction History
        public void ShowHistory()
        {
            Console.WriteLine("\nTransaction History:");
            foreach (var txn in history)
            {
                Console.WriteLine($"{txn.TransactionId} | {txn.AccountId} | {txn.Amount}");
            }
        }
    }
}
