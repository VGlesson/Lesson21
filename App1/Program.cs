using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App1
{
    class Program
    {
         static int[,] garden;
         static int m;
         static int n;
        static void Main(string[] args)
        {
            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());

            garden = new int[n, m];

            Thread sadov1 = new Thread(sad1);
            Thread sadov2 = new Thread(sad2);

            sadov1.Start();
            sadov2.Start();

            sadov1.Join();
            sadov2.Join();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(garden[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

         static void sad1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (garden[i, j] == 0)
                        garden[i, j] = 1;
                    Thread.Sleep(1);
                }
                Console.ReadKey();
            }
        }

        static void sad2()
        {
            for (int i = m - 1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    if (garden[j, i] == 0)
                        garden[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
