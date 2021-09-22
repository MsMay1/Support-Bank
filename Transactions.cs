using System;

namespace Support_Bank_Console_App
{
    class Transaction
    {
        public string From {get; set;}
        public string To {get; set;}
        public string Narrative {get; set;}
        public decimal Amount {get; set;}
        public  DateTime  Date {get; set;}

    public Transaction (string[] eachTransaction)
    {
        Date = DateTime.Parse(eachTransaction[0]);
        From = eachTransaction[1] ;
        To = eachTransaction[2];
        Narrative = eachTransaction[3];
        Amount = decimal.Parse(eachTransaction[4]);
    }
    }
}