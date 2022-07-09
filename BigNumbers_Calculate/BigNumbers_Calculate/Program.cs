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
            Console.WriteLine("Enter a & b:");
            Console.Write("  a = ");
            string a = Console.ReadLine();
            Console.Write("  b = ");
            string b = Console.ReadLine();

            MyBigNumber cal = new MyBigNumber();
            String result = cal.sum(a, b);
            Console.WriteLine("Result for a + b is " + result);
        }
    }

    class MyBigNumber
    {
        public MyBigNumber()
        {}

        public String sum(string n1, string n2)
        {
            // Declare default variable
            int nLenght1 = n1.Length;
            int nLenght2 = n2.Length;


            Console.Clear();
            Console.WriteLine("a = "+n1);
            Console.WriteLine("b = "+n2);
            Console.WriteLine();

            int step = 0, count = 1, rem = 0;
            String result = "";
            
            Console.WriteLine("Start: ");
            if (nLenght1 >= nLenght2)
            {
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
                        else { 
                            tmpsum = (n1[nLenght1 - count] - '0') + rem;
                        }
                    }

                    if (tmpsum >= 10)
                    {
                        result = (tmpsum - 10) + result;

                        if (nLenght2 - count >= 0)
                        {
                            Console.WriteLine(" Step " + step + ": " + n1[nLenght1 - count] + " + " + n2[nLenght2 - count] + " + " + rem + "(rem) = " + tmpsum + ". Add " + (tmpsum - 10) + ", rem = 1");
                        }
                        else
                        {
                            Console.WriteLine(" Step " + step + ": " + n1[nLenght1 - count] + " + " + rem + "(rem) = " + tmpsum + ". Add " + (tmpsum - 10) + ", rem = 1");
                        }

                        rem = 1;
                    }
                    else
                    {
                        result = tmpsum + result;

                        if (nLenght2 - count >= 0)
                        {
                            Console.WriteLine(" Step " + step + ": " + n1[nLenght1 - count] + " + " + n2[nLenght2 - count] + " + " + rem + "(rem) = " + tmpsum + ". Add " + tmpsum + ", rem = 0");
                        }
                        else
                        {
                            Console.WriteLine(" Step " + step + ": " + n1[nLenght1 - count] + " + " + rem + "(rem) = " + tmpsum + ". Add " + tmpsum + ", rem = 0");
                        }

                        rem = 0;
                    }


                    if (nLenght1-count==0 & rem == 1)
                    {
                        result = '1' + result;
                        Console.WriteLine(" Step " + step + ": Add 1(rem). End");
                    }

                    if(rem==0 & nLenght2 - count < 0)
                    {
                        String tmpresult="";
                        for(int i = nLenght1 - count - 1; i >= 0; i--)
                        {
                            tmpresult = n1[i] + tmpresult;
                        }
                        Console.WriteLine(" Step " + (++step) + ": no rem -> Put down all uncalculated digits.End");
                        result = tmpresult + result;
                        count = nLenght1;
                    }
                    count++;
                }
            }
            else
            {
                int gap = nLenght2 - nLenght1;
                while (count <= nLenght2 - gap)
                {
                    step++;
                    int tmpsum;
                    if (nLenght1 - count > 0)
                    {
                        tmpsum = (n2[nLenght2 - count] - '0') + (n1[nLenght1 - count] - '0') + rem;
                    }
                    else
                    {
                        if (nLenght2 - count > 0)
                        {
                            gap = gap - 1;
                        }


                        if (nLenght1 - count == 0)
                        {
                            tmpsum = (n2[nLenght2 - count] - '0') + (n1[nLenght1 - count] - '0') + rem;
                        }
                        else
                        {
                            tmpsum = (n2[nLenght2 - count] - '0') + rem;
                        }
                    }

                    if (tmpsum >= 10)
                    {
                        result = (tmpsum - 10) + result;

                        if (nLenght1 - count >= 0)
                        {
                            Console.WriteLine(" Step " + step + ": " + n1[nLenght1 - count] + " + " + n2[nLenght2 - count] + " + " + rem + "(rem) = " + tmpsum + ". Add " + (tmpsum - 10) + ", rem = 1");
                        }
                        else
                        {
                            Console.WriteLine(" Step " + step + ": " + n2[nLenght2 - count] + " + " + rem + "(rem) = " + tmpsum + ". Add " + (tmpsum - 10) + ", rem = 1");
                        }

                        rem = 1;
                    }
                    else
                    {
                        result = tmpsum + result;

                        if (nLenght1 - count >= 0)
                        {
                            Console.WriteLine(" Step " + step + ": " + n1[nLenght1 - count] + " + " + n2[nLenght2 - count] + " + " + rem + "(rem) = " + tmpsum + ". Add " + tmpsum + ", rem = 0");
                        }
                        else
                        {
                            Console.WriteLine(" Step " + step + ": " + n2[nLenght2 - count] + " + " + rem + "(rem) = " + tmpsum + ". Add " + tmpsum + ", rem = 0");
                        }

                        rem = 0;
                    }


                    if (nLenght2 - count == 0 & rem == 1)
                    {
                        result = '1' + result;
                        Console.WriteLine(" Step " + step + ": Add 1(rem). End");
                    }

                    if (rem == 0 & nLenght1 - count < 0)
                    {
                        String tmpresult = "";
                        for (int i = nLenght2 - count - 1; i >= 0; i--)
                        {
                            tmpresult = n2[i] + tmpresult;
                        }
                        Console.WriteLine(" Step " + (++step) + ": no rem -> Put down all uncalculated digits.End");
                        result = tmpresult + result;
                        count = nLenght2;
                    }
                    count++;
                }
            }

            Console.WriteLine();
 
            return result;
        }
    }
}
