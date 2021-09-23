using System;
using System.Collections.Generic;

namespace Support_Bank_Console_App
{
    class Account
    {
        public string Name { get; set; }
        public decimal AmountGained { get; set; }

        public decimal AmountToPay { get; set; }

        public List<Transaction> IncomingTransactions { get; set; }
        public List<Transaction> OutgoingTransactions { get; set; }

        public Account(string name)
        {
            Name = name;
            IncomingTransactions = new List<Transaction>();
            OutgoingTransactions = new List<Transaction>();
        }


    }
}