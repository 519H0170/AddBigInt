using System;
using System.Collections.Generic;

namespace BigNumbers_Calculate
{
    class Program
    {
        static void Main(string[] args)
        {
            string exit = "";
            // Input
            while (exit != "x")
            {
                Console.Clear();
                Console.WriteLine("Enter a & b:");
                Console.Write("  a = ");
                string a = Console.ReadLine();
                Console.Write("  b = ");
                string b = Console.ReadLine();


                MyBigNumber cal = new MyBigNumber(a, b);
                String result = cal.sum();
                Console.WriteLine("Result for a + b is " + result);

                Console.Write("Enter 'x' and Enter to exit program:");
                exit = Console.ReadLine();
            }
            
        }
    }

    class MyBigNumber
    {
        private char[] lista,listb;

        public MyBigNumber(string n1,string n2)
        {
            // String Lenght Balance
            if (n1.Length > n2.Length)
            {
                int gap = n1.Length - n2.Length;
                for(int i = 0; i < gap; i++)
                {
                    n2 = "0" + n2;
                }
            }
            else
            {
                int gap = n2.Length - n1.Length;
                for (int i = 0; i < gap; i++)
                {
                    n1 = "0" + n1;
                }
            }

            //String to CharArray
            this.lista = n1.ToCharArray();
            this.listb = n2.ToCharArray();

            //Console.WriteLine(this.lista);
            //Console.WriteLine(this.listb);
        }

        public String sum()
        {
            // Declare default variable
            int nLenght = this.lista.Length;
            int rem = 0; // 0 or 1
            int step = 0;
            String result="";
            // Calculate at each position last -> first
            Console.WriteLine("Start:");
            while (nLenght != 0)
            {
                step += 1;
                int tmpsum = 0; 
                // Char to int: number = int(char - '0')
                int n1 = Convert.ToInt32(this.lista[nLenght - 1] - '0');
                int n2 = Convert.ToInt32(this.listb[nLenght - 1] - '0');

                if (rem == 0){
                    tmpsum = n1 + n2;
                }
                else
                {
                    tmpsum = n1 + n2 + rem;
                }

                if (tmpsum >= 10)
                {
                    result = (tmpsum - 10) + result;
                    if (nLenght - 1 == 0)
                    {
                        result = 1 + result;
                        Console.WriteLine(" Step " + step + ": Add 1(rem). End");
                    }
                    else {
                        Console.WriteLine(" Step " + step + ": "+ n1+" + " + n2 + " + " + rem + "(rem) = " + tmpsum + ". Add " + (tmpsum-10) + ", remember 1");
                        rem = 1;
                    }
                }
                else
                {
                    result = tmpsum + result;
                    Console.WriteLine(" Step " + step + ": " + n1 + " + " + n2 + " + " + rem + "(rem) = " + tmpsum + ". Add " + tmpsum + ", remember 0");
                    rem = 0;
                }
                nLenght -= 1;
            }
            return result;
        }
    }
}
