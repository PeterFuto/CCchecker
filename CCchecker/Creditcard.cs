using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCchecker
{
    class Creditcard
    {
        public long CCnumber { get; set; }
        public int IndustryID { get; set; }
        public int IssuerID { get; set; }
        public int AccountNumber { get; set; }
        public int Checksum { get; set; }

        public Creditcard(string ccnumber)
        {
            CCnumber = Convert.ToInt64(ccnumber);
            IndustryID = Convert.ToInt32(ccnumber.Substring(0,1));
            IssuerID = Convert.ToInt32(ccnumber.Substring(1, 5));
            AccountNumber = Convert.ToInt32(ccnumber.Substring(6, 9));
            Checksum = Convert.ToInt32(ccnumber.Substring(15, 1));
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Card number is: {CCnumber}");
            Console.WriteLine($"Card industry ID is: {IndustryID}");
            Console.WriteLine($"Card issuer ID is: {IssuerID}");
            Console.WriteLine($"Card account number is: {AccountNumber}");
            Console.WriteLine($"Card checksum is: {Checksum}");
        }
    }

}
