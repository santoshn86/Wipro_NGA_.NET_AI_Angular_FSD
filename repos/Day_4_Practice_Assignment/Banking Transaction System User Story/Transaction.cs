using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Transaction_System_User_Story
{
    internal class Transaction
    {
        public string TransactionId;
        public string AccountId;
        public double Amount; // +ve = deposit, -ve = withdrawal

        public Transaction(string txnId, string accId, double amount)
        {
            TransactionId = txnId;
            AccountId = accId;
            Amount = amount;
        }
    }
}
