using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace labConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            String choose ="";

            do
            {
                try
                {

                     choose = drawMenu();

                    switch (choose)
                    {
                        case "1":
                            localMaxtoZero();
                             choose = Console.ReadLine();
                            Console.Clear();
                           

                            break;
                        case "2":

                            seriesToOne();
                            choose = Console.ReadLine();
                             Console.Clear();
                           
                            break;
                        case "3":
                            stringInString();
                            choose = Console.ReadLine();
                            Console.Clear();
                            
                            break;
                        case "4":
                            fileReading();
                            choose = Console.ReadLine();
                            Console.Clear();
                            
                            break;
                        case "5":
                            normalizeSpaces();
                            choose = Console.ReadLine();
                            Console.Clear();
                           
                            break;
                        default:
                            Console.WriteLine("Incorrect input try once again");
                            
                            break;
                    }



                }
                catch (System.IO.IOException exc)
                {
                    Console.WriteLine(exc);
                }

            } while (!choose.Equals("exit"));




        }

        private static String drawMenu()
        {
            Console.WriteLine("1.Array76");
            Console.WriteLine("2.Array125");
            Console.WriteLine("3.String31");
            Console.WriteLine("4.File28");
            Console.WriteLine("5.Text20");
            Console.WriteLine("Choose your task, type EXIT when want to finish: ");
            return Console.ReadLine();
        }

        private static String drawMenu2()
        {
            Console.WriteLine("1.Array76");
            Console.WriteLine("2.Array125");
            Console.WriteLine("3.String31");
            Console.WriteLine("4.File28");
            Console.WriteLine("5.Text20");
            Console.WriteLine("Choose your task, type EXIT when want to finish: ");
            return Console.ReadLine();
        }


        private static void normalizeSpaces()
        {
            String[] lines = System.IO.File.ReadAllLines(@"temp2.txt");

            //Console.WriteLine("File contents: " + lines.ToList<String>().ToString());
            Char[] tempCharArr = new Char[10];
            List<Char> lstChar = new List<Char>();

            Console.WriteLine("Text with spaces: ");

            foreach (String s in lines)
            {
                String[] tempStringArr = s.Split(' ');
                tempCharArr = s.ToCharArray();
                lstChar.AddRange(s.ToCharArray());
            }

            for (int i = 0; i < lstChar.Count; i++)
            {
                Console.Write(lstChar[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Text without spaces: ");
           
            for (int i = 0; i < lstChar.Count; i++)
            {
                if (lstChar[i] == ' ')
                {
                    int firstSpace = i;
                    int count = 0;
                    for (int j = i+1; j < lstChar.Count; j++)
                    {
                        if (lstChar[j] == ' ')
                        {
                            count++;
                        }
                        else
                        {
                            lstChar.RemoveRange(i, count);
                            break;
                        }
                    }
                }

                Console.Write(lstChar[i]);              
              }

            string[] strings = Array.ConvertAll<Char, string>(lstChar.ToArray(), Convert.ToString);
            System.IO.File.WriteAllLines(@"temp2.txt", strings);
          
            Console.WriteLine("File was succesfully changed. Check file temp.txt in the bin/Debug folder of the project: ");
        }

        private static void fileReading()
        {
          //Hey-hey-hey~!
            CultureInfo c = new CultureInfo("ru"); // or another culture
            c.NumberFormat.NumberDecimalSeparator = ".";
            string[] lines = System.IO.File.ReadAllLines(@"temp.txt");

            Console.WriteLine("File contents: ");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.Write(lines[i]+" ");
            }
            Console.WriteLine();

            Console.WriteLine("Average of neighbours: ");
            Double[] tempDoubleArr = new double[10];
            List<Double> lstDouble = new List<double>();

            foreach (String s in lines)
            {
                String[] tempStringArr = s.Split(' ');
                tempDoubleArr = new double[tempStringArr.Length];

                for (int i = 0; i < tempStringArr.Length; i++)
                {
                    tempDoubleArr[i] = Double.Parse(tempStringArr[i], c);
                  
                    lstDouble.Add(tempDoubleArr[i]);
                }
          

            }

            for (int i = 1; i < lstDouble.Count - 1; i++)
            {
                lstDouble[i] = (lstDouble[i - 1] + lstDouble[i] + lstDouble[i + 1]) / 3;
            }


            for (int i =0; i < lstDouble.Count; i++)
            {
                Console.WriteLine(String.Format("{0:0.000}", lstDouble[i]));
            }

            string[] strings = Array.ConvertAll<Double, string>( lstDouble.ToArray(), Convert.ToString);
          
            System.IO.File.WriteAllLines(@"temp.txt", strings);
            Console.WriteLine("File was succesfully changed. Check file temp.txt in the bin/Debug folder of the project: ");



        }
        private static void stringInString()
        {
            Console.WriteLine("Input string 1: ");
            String s1 = Console.ReadLine();

            Console.WriteLine("Input string 2: ");
            String s2 = Console.ReadLine();

            if (s1.Contains(s2))
            {
                Console.WriteLine("String " + s1 + " contains string " + s2);
            }
            else
            {
                Console.WriteLine("String " + s1 + " doesn't contain " + s2);
            }



        }

        private static void seriesToOne()
        {
            Console.WriteLine("Old array: ");
            int[] arr = { 1, 1, 1, 1, 2, 2, 2, 3, 3 };
            printArr(arr);
            int[] tempArr = new int[10];

            Console.WriteLine("New array: ");
            int count = 0;
            for (int i = 0; i < arr.Length; i += count)
            {
                int lowerPointer = i;
                int lowerPointerValue = arr[i];
                count = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        count++;
                    }
                    else
                        break;
                }
                Console.Write(arr[i] + "  ");

            }


        }

        private static void localMaxtoZero()
        {
            Console.WriteLine("Old array: ");
            int[] arr = { 9, 3, 1, 9, 1, 2, 1, 3 };


            printArr(arr);

            for (int i = 1; i < arr.Length - 1; i++)
            {
                if ((arr[i] > arr[i + 1]) && (arr[i] > arr[i - 1]))
                {
                    arr[i] = 0;
                }
            }

            Console.WriteLine("New array: ");
            printArr(arr);


        }

        private static void printArr(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }


    }
}
