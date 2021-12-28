using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab16
{
    class Program
    {
        static void Factorial(int x, ParallelLoopState pls)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
                if (i == 5)
                    pls.Break();
            }
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Console.WriteLine($"Факториал числа {x} равен {result}");
        }

        static Task<int> FactorialAsync(int x)
        {
            int result = 1;
            return Task.Run(() =>
            {
                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
                return result;
            });
        }
        static async Task DisplayResultAsync()
        {
            int result = await FactorialAsync(25);//await-нужен чтобы приостановить выполнение метода до тех пор,пока эта задача не завершится
            Thread.Sleep(3);
            Console.WriteLine("Факториал числа {0} равен {1}", 25, result);
        }
        static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        static CancellationToken token = cancelTokenSource.Token;
        static void Main(string[] args)
        {

            int num1, num2;
            float f1, f2;

            num1 = 13 / 3;
            num2 = 13 % 3;

            f1 = 13.0f / 3.0f;
            f2 = 13.2f % 3.0f;

            Console.WriteLine("Результат и остаток от деления 13 на 3: {0} __ {1}", num1, num2);
            Console.WriteLine("Результат деления 13.0 на 3.0: {0:#.###} {1}", f1, f2);

            Console.ReadLine();
            Console.ReadKey();
        }
    }
}