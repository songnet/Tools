using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFReportGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql = "1.1.1.";

            char s = '.';

            Array a = sql.Split(s);

            foreach (var i in a)
            {
                Console.Write(i);
            }

            Console.ReadLine();
        }
    }
}
