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
            Reader fileReader = new Reader();

            List<Transaction> transactionList = fileReader.CreateTransactionList(@"C:\Training\C#\SupportBank\support-bank-resources-master\Transactions2014.csv");

           List<string> accountNames = CreateNameList(transactionList);

           List<Account> AccountList = CreateAccounts(accountNames, transactionList);

            // Console.WriteLine("Please enter the number for your command\n 1: List All \n 2: List by Account");
            // int Command = int.Parse(Console.ReadLine());
            // if (Command == 1)
            // {

            // }
            // if (Command == 2)
            // {

            // }


        }
        public static List<string> CreateNameList(List<Transaction> transactionList)
        {

            List<string> names = new List<string>();

            foreach (Transaction transaction in transactionList)
            {
                names.Add(transaction.From);
                names.Add(transaction.To);
            }

            List<string> accountNames = names.Distinct().ToList();

            return accountNames;
        }

        public static List<Account> CreateAccounts(List<string> accountNames, List<Transaction> transactionList)
        {
            List<Account> AccountLists = new List<Account>();
             foreach (string name in accountNames)
            {
                Account createAccount = new Account(name);
                foreach (Transaction transaction in transactionList)
                {
                    if (transaction.From == name)
                    {
                        createAccount.OutgoingTransactions.Add(transaction);
                        createAccount.AmountToPay += transaction.Amount;
                    }
                    if (transaction.To == name)
                    {
                        createAccount.IncomingTransactions.Add(transaction);
                        createAccount.AmountGained += transaction.Amount;
                    }
                }
                AccountLists.Add(createAccount);
                Console.WriteLine($"Name: {createAccount.Name} Amount To Pay: £{createAccount.AmountToPay} Amount Gained: £{createAccount.AmountGained}");
            }
            return AccountLists;
        }
    }
}





