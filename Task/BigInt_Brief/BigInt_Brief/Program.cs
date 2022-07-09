using System;

namespace BigInt_Brief
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            Console.WriteLine("Enter a & b:");
            Console.Write("  a = ");
            string a = Console.ReadLine();
            Console.Write("  b = ");
            string b = Console.ReadLine();

            MyBigNumber cal = new MyBigNumber();

            string result = "";

            Console.Clear();
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);

            if (a.Length >= b.Length)
            {
                result = cal.sum(a, b);
            }
            else
            {
                result = cal.sum(b, a);
            }
            Console.WriteLine("Result for a + b is " + result);
        }
    }

    class MyBigNumber
    {
        public MyBigNumber()
        { }

        public string sum(string n1, string n2) // n1 >= n2 if others ... reposition
        {
            int nLenght1 = n1.Length;
            int nLenght2 = n2.Length;

            if (nLenght1 < nLenght2)
            {
                string tmp = n1;
                n1 = n2;
                n2 = tmp;

                nLenght1 = n1.Length;
                nLenght2 = n2.Length;
            }

            int step = 0, count = 1, rem = 0;
            string result = "";

            int gap = nLenght1 - nLenght2;
            while (count <= nLenght1 - gap)
            {
                step++;
                int tmpsum;
                if (nLenght2 - count > 0)
                {
                    tmpsum = (n1[nLenght1 - count] - '0') + (n2[nLenght2 - count] - '0') + rem;
                }
                else
                {
                    if (nLenght1 - count > 0)
                    {
                        gap = gap - 1;
                    }


                    if (nLenght2 - count == 0)
                    {
                        tmpsum = (n1[nLenght1 - count] - '0') + (n2[nLenght2 - count] - '0') + rem;
                    }
                    else
                    {
                        tmpsum = (n1[nLenght1 - count] - '0') + rem;
                    }
                }

                if (tmpsum >= 10)
                {
                    result = (tmpsum - 10) + result;
                    rem = 1;
                }
                else
                {
                    result = tmpsum + result;
                    rem = 0;
                }


                if (nLenght1 - count == 0 & rem == 1)
                {
                    result = '1' + result;
                }

                // Break, put down all uncalculated elements to result.
                if (rem == 0 & nLenght2 - count < 0)
                {
                    String tmpresult = "";
                    for (int i = nLenght1 - count - 1; i >= 0; i--)
                    {
                        tmpresult = n1[i] + tmpresult;
                    }
                    result = tmpresult + result;
                    count = nLenght1;
                }
                count++;
            }

            return result;
        }
    }
}
