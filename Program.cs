using System;
using System.Collections.Generic;
using System.Linq;

namespace Support_Bank_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get file path and create a list of all transactions
            Reader fileReader = new Reader();

            List<Transaction> transactionList = fileReader.CreateTransactionList(@"C:\Training\C#\SupportBank\support-bank-resources-master\Transactions2014.csv");

            //Create List of unique Names
            List<string> accountNames = CreateNameList(transactionList);

            //Create accounts for each  name and add to a List.
            Dictionary<string, Account> AccountDictionary = CreateAccounts(accountNames, transactionList);

            //Calling the Program
            Console.WriteLine("Please enter the number for your command\n 1: List All \n 2: List by Account");

            int Command = int.Parse(Console.ReadLine());

            if (Command == 1)
            {
                ListAll(AccountDictionary);
            }

            if (Command == 2)
            {
                Console.WriteLine("Enter Name Of Account");
                string accountName = Console.ReadLine();
                ListByAccount(accountName, AccountDictionary);
            }

        }

        public static List<string> CreateNameList(List<Transaction> transactionList)
        {
            List<string> names = new List<string>();

            // goes through the transactions from and to and adds each name to a list
            foreach (Transaction transaction in transactionList)
            {
                names.Add(transaction.From);
                names.Add(transaction.To);
            }

            // Takes out all duplicate names leaving you with a unique list
            List<string> accountNames = names.Distinct().ToList();

            return accountNames;
        }

        public static Dictionary<string, Account> CreateAccounts(List<string> accountNames, List<Transaction> transactionList)
        {

            //New Dictionary to store name and account details
            Dictionary<string, Account> AccountDictionary = new Dictionary<string, Account>();

            // Go through each name in the account names list and create an account 
            foreach (string name in accountNames)
            {
                Account newAccount = new Account(name);

                // look for the name in the transactionLsist add all incoming and outgoing transactions to the respective fields and calculate to total amount of those fields
                foreach (Transaction transaction in transactionList)
                {
                    if (transaction.From == name)
                    {
                        newAccount.OutgoingTransactions.Add(transaction);
                        newAccount.AmountToPay += transaction.Amount;
                    }
                    if (transaction.To == name)
                    {
                        newAccount.IncomingTransactions.Add(transaction);
                        newAccount.AmountGained += transaction.Amount;
                    }
                }

                //Calculate Net
                newAccount.Balance = newAccount.AmountGained - newAccount.AmountToPay;

                // Add account to Dictionary of accounts
                AccountDictionary.Add(newAccount.Name, newAccount);

            }

            return AccountDictionary;
        }

        public static void ListAll(Dictionary<string, Account> AccountDictionary)
        {
            foreach (KeyValuePair<string, Account> account in AccountDictionary)
            {
                Console.WriteLine($"Name: {account.Key} {(account.Value.Balance < 0 ? "is in debt of" : "is owed")} {Math.Abs(account.Value.Balance):c}");
            }
        }

        public static void ListByAccount(string name, Dictionary<string, Account> AccountDictionary)
        {

            Console.WriteLine();

            Console.WriteLine("Incoming Transactions");

            AccountDictionary[name].IncomingTransactions.ForEach(transaction => Console.WriteLine($"Date: {(transaction.Date).ToShortDateString()} From: {transaction.From} Reason: {transaction.Narrative} Amount:{transaction.Amount:C}"));

            Console.WriteLine();

            Console.WriteLine("Outgoing Transactions");

            AccountDictionary[name].OutgoingTransactions.ForEach(transaction => Console.WriteLine($"Date: {(transaction.Date).ToShortDateString()} To: {transaction.To} Reason: {transaction.Narrative} Amount:{transaction.Amount:C}"));

        }

    }
}





