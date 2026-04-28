using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Design_Principals
{
    public class Transaction
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }

   
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        List<Transaction> GetAll();
    }



    #region Payment Implementations (Strategy Pattern)

    public class UpiPayment : IPaymentMethod
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid ₹{amount} using UPI");
        }
    }

    public class CardPayment : IPaymentMethod
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid ₹{amount} using Card");
        }
    }

    public class NetBankingPayment : IPaymentMethod
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid ₹{amount} using Net Banking");
        }
    }

    public class EmailNotification : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"[EMAIL] {message}");
        }
    }

    #endregion

    #region Repository

    public class TransactionRepository : ITransactionRepository
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void Add(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        public List<Transaction> GetAll()
        {
            return transactions;
        }
    }

    #endregion

    #region Wallet (Core Business Logic)

    public class Wallet
    {
        private decimal balance;
        private readonly INotificationService notificationService;
        private readonly ITransactionRepository transactionRepository;

        public Wallet(INotificationService notification, ITransactionRepository repository)
        {
            notificationService = notification;
            transactionRepository = repository;
        }

        public void AddMoney(decimal amount)
        {
            balance += amount;

            var transaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Amount = amount,
                Type = "Credit",
                Date = DateTime.Now
            };

            transactionRepository.Add(transaction);
            notificationService.Send($"₹{amount} added to wallet. Balance: ₹{balance}");
        }

        public void MakePayment(IPaymentMethod paymentMethod, decimal amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Insufficient balance!");
                return;
            }

            paymentMethod.Pay(amount);
            balance -= amount;

            var transaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Amount = amount,
                Type = "Debit",
                Date = DateTime.Now
            };

            transactionRepository.Add(transaction);
            notificationService.Send($"Payment of ₹{amount} successful. Balance: ₹{balance}");
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Current Balance: ₹{balance}");
        }

        public void ShowTransactions()
        {
            var transactions = transactionRepository.GetAll();

            Console.WriteLine("\nTransaction History:");
            foreach (var t in transactions)
            {
                Console.WriteLine($"{t.Date} | {t.Type} | ₹{t.Amount}");
            }
        }
    }
#endregion
}
