using System;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Support_Bank_Console_App
{

    class Transaction
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public string From { get; set; }
        public string To { get; set; }
        public string Narrative { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string[] eachTransaction)
        {
            try
            {
                Date = DateTime.Parse(eachTransaction[0]);
            }
            catch (FormatException e)
            {
                Logger.Debug("Can't convert to Date", e);
                Console.WriteLine($"Skipped Transaction due to Invalid Date - Date: {eachTransaction[0]}, From: {eachTransaction[1]}, To: {eachTransaction[2]}, Reason: {eachTransaction[3]}, Amount: {eachTransaction[4]}");
            };

            try
            {
                Amount = decimal.Parse(eachTransaction[4]);
            }
            catch (FormatException e)
            {
                Logger.Debug("Can't convert to Decimal", e);
                Console.WriteLine($"Skipped Transaction due to Invalid Amount - Date: {eachTransaction[0]}, From: {eachTransaction[1]}, To: {eachTransaction[2]}, Reason: {eachTransaction[3]}, Amount: {eachTransaction[4]}");
            };

            From = eachTransaction[1];
            To = eachTransaction[2];
            Narrative = eachTransaction[3];
        }
    }
}
