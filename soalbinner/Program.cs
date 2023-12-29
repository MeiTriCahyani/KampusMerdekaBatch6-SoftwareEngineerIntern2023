using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soalbinner
{
    public class KonversiBilangan
    {
        static void Main(string[] args)
        {
            int desimal;
            Console.WriteLine("Enter a Decimal Number: ");
            desimal = int.Parse(Console.ReadLine());
            string biner = "";
            int sisa;
            while (desimal != 0)
            {
                sisa = desimal % 2;
                biner = sisa.ToString() + biner;
                desimal = desimal / 2;
            }
            string bin = "";
            for(int i = biner.Length - 1; i >=0 ; i--)
            {
                bin = bin + biner[i];
            }
            Console.WriteLine("The Binary format for given number is {0}", bin);
            Console.Read();
        }
    }
}
