using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCchecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Creditcard cc = new Creditcard("4563648800001007");
            cc.DisplayInfo();
            Console.ReadLine();
        }
    }
}
