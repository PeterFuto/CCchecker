using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCchecker
{
    class Creditcard
    {
        public string CCnumber { get; set; }
        public int IndustryID { get; set; }
        public int IssuerID { get; set; }
        public int AccountNumber { get; set; }
        public int Checksum { get; set; }

        public Creditcard(string ccnumber)
        {
            CCnumber = ccnumber;
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
        public bool IsValid()
        {
            int[] iArr = new int[CCnumber.Length-1];
            for (int i = 0; i < iArr.Length; i++)
            {
                iArr[i] = Convert.ToInt32(Convert.ToString(CCnumber[i]));
                if (i % 2 == 0 || i == 0) //double the first, and every second item
                {
                    iArr[i] *= 2;
                    if (IsXDigits(iArr[i], 2)) //checks if it became double digits
                    {
                        iArr[i] = AddDigitsTogether(iArr[i]);
                    }
                }
            }
            if (Check(iArr))
            {
                return true;
            }
            return false;
        }
        //helpers
        public bool IsXDigits(int num, int x)
        {
            if (num.ToString().Length == x)
            {
                return true;
            }
            return false;
        }
        public int AddDigitsTogether(int num)
        {
            int r = 0;
            string s = num.ToString();
            int[] iArr = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                iArr[i] = Convert.ToInt32(s[i].ToString());
            }
            foreach (int digit in iArr)
            {
                r += digit;
            }
            return r;
        }
        public bool Check(int[] iArr) //checks if it's a multiple of ten
        {
            int r = 0;
            for (int i = 0; i < iArr.Length; i++)
            {
                r += iArr[i];
            }
            r += Checksum;
            if (r % 10 == 0)
            {
                return true;
            }
            return false;
        }
    }

}
