using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Support_Bank_Console_App
{
    class Reader
    {

        public List<Transaction> CreateTransactionList(string path)
        {
            var transactionsRows = File.ReadAllLines(path).Skip(1);

            List<Transaction> transactionList = new List<Transaction>();

            foreach (string row in transactionsRows)
            {
                string[] transactionElements = row.Split(",");
                Transaction singleTransaction = new Transaction(transactionElements);
                transactionList.Add(singleTransaction);
            }

            return transactionList;
        }
    }
}