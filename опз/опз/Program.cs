    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlTypes;
    using System.Globalization;
    using System.Reflection;
    using System.Text;
    using System.Xml.Linq;

    namespace lab3
    {
        class Program
        {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x0, xn и шаг");
            double x0 = Convert.ToDouble(Console.ReadLine());
            double xn = Convert.ToDouble(Console.ReadLine());
            double j = Convert.ToDouble(Console.ReadLine());
            int n = Convert.ToInt32(Math.Truncate((xn - x0) / j + 1));
            double[] mas1 = new double[n];
            double[] mas2 = new double[n];
            int MaxLength = 0;
            string s1;
            string s2;

            for (int l = 0; l < n; l++)
            {
                double b = x0 + l * j;
                mas2[l] = Math.Round(power(b), 4);
                mas1[l] = b;
                string s = Convert.ToString(mas1[l]);
                MaxLength = s.Length;
                if (s.Length > MaxLength)
                    MaxLength = s.Length;
            }

            head(MaxLength);
            for (int i = 0; i<n-1; i++)
            {
                switch (i)
                {
                    case 0: borderline(MaxLength, "x", "y"); break;
                    default: s1 = Convert.ToString(mas1[i]);
                        s2 = Convert.ToString(mas2[i]);
                        borderline(MaxLength, s1, s2);
                        break;
                }
                mid(MaxLength);   
            }
            s1 = Convert.ToString(mas1[n-1]);
            s2 = Convert.ToString(mas2[n-1]);
            borderline(MaxLength,s1,s2);
            bottom(MaxLength);
        }

            static double power(double k)
            {
                double m = Math.Pow(k, 2);
                return m;
            }
        static void head(int x)
        {
            Console.Write("┌");
            for (int j = 1; j <= 2; j++)
            {
                for (int i = 0; i <= x; i++)
                    Console.Write("─");
                if (j != 2)
                    Console.Write("┬");
            }
            Console.Write("┐");
            Console.WriteLine();
        }

        static void borderline(int MaxLength,string x,string y)
        {
            bool b = true;
            bool a = true;
            for (int j = 1; j <= 2; j++)
            {
                Console.Write("│");
                for (int i = 1; i <= MaxLength; i++)
                {
                    if (b && i-1 == (MaxLength-x.Length)/2) { Console.Write(x); b = false; a = false; }
                            else  if (!b && i-1 == (MaxLength - y.Length) / 2) Console.Write(y); 
                  else if (b && (i-1<(MaxLength - x.Length) / 2 || i-1> (MaxLength - x.Length) / 2 + x.Length) ||
                        !b && (i - 1 < (MaxLength - y.Length) / 2 || i - 1 > (MaxLength - y.Length) / 2 + y.Length))  Console.Write(" ");
                    string length = Convert.ToString(MaxLength);
                    if (a && (length.Length % 2 != y.Length % 2) || !a && (length.Length % 2 != x.Length % 2))
                        Console.Write(" ");
                }
            }
            Console.Write("│");
            Console.WriteLine();
        }

        static void mid(int x)
        {
            Console.Write("├");
            for (int j = 1; j <= 2; j++)
            {
                for (int i = 1; i <= x; i++)
                    Console.Write("─");
                if (j != 2)
                    Console.Write("┼");
            }
            Console.Write("┤");
            Console.WriteLine();
        }

        static void bottom(int x)
        {
            Console.Write("└");
            for (int j = 1; j <= 2; j++)
            {
                for (int i = 1; i <= x; i++)
                    Console.Write("─");
                if (j != 2)
                    Console.Write("┴");
            }
            Console.Write("┘");
        }
    }


    }