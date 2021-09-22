using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Support_Bank_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
           string path = @"C:\Training\C#\SupportBank\support-bank-resources-master\Transactions2014.csv";

           var transactionsRows = File.ReadAllLines(path).Skip(1);

           List<Transaction> transactionList = new List<Transaction>();
           
           foreach (string row in transactionsRows)
           {
            string[] transactionElements = row.Split(",");
            Transaction singleTransaction = new Transaction(transactionElements);
            transactionList.Add(singleTransaction);
           }

            List<string> names = new List<string>();

           foreach(Transaction transaction in transactionList){
               names.Add(transaction.From);
           }

           List<string> uniqueAccounts = names.Distinct().ToList();
           
           foreach(string name in uniqueAccounts){
            Account createAccount = new Account(name);
            Console.WriteLine(createAccount.Name);
           }
        }
    }
}
