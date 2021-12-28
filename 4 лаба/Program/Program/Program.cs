using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap4
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtendedStack myStack1 = new ExtendedStack();
            ExtendedStack myStack2 = new ExtendedStack();

            myStack1.Push(1); 
            myStack1 = myStack1 + (-2);

            Console.WriteLine("myStack1 is empty? {0}\nmyStack2 is empty? {1}\n", myStack1 ? "true" : "false", myStack2 ? "true" : "false");

            myStack2.Push(0);
            myStack2 = myStack2 + 5;

            ExtendedStack myStack3 = myStack1 > myStack2;

            //Тестирование метода расширения для строки
            string testString = "What! Are? You doing.";
            Console.WriteLine(testString + "\n" + string.Format("Sentences: {0}\n", testString.WordCount()));

            myStack3 = myStack3 + 7;
            Console.WriteLine("Medium element = " + Static.MediumElemStack(myStack3) + "\n");

            Console.WriteLine(myStack3.Pop());
            Console.WriteLine(myStack3.Pop());
            myStack3--;
            Console.WriteLine(myStack3.Pop());

            Console.ReadKey();
        }
    }
}
