using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               Programmer.ProgrammerStateHandler programmerStateHandler;
                List<string> LanguagesProgramming = new List<string>
             {
             "JavaScript", "C#", "Java", "Python", "Ruby"
             };

                Programmer programmer = new Programmer();

                programmer.Rename += (list, message) =>
                {
                    Console.WriteLine(message);
                    foreach (string item in list)
                    {
                        Console.Write(item + "\t");
                    }
                };
                programmerStateHandler = programmer.Edit;
                programmerStateHandler += programmer.Upload;

                programmer.NewProperty += (list, message) =>
                {
                    Console.WriteLine(message);
                    int index = 1;
                    foreach (string item in list)
                    {
                        Console.Write((index++) + " " + item + "\t");
                    }
                };

                programmerStateHandler(LanguagesProgramming, "");
                programmerStateHandler(LanguagesProgramming, "");
                Console.WriteLine();

                Console.WriteLine("--------------Работа со строками--------------");
                string str = "P! o, i                 .t 6";

                Func<string, string> A = StringHandler.RemoveS;
                Console.WriteLine("Строка до: {0}\nПосле: {1}\n", str, str = A(str));
                A = StringHandler.RemoveSpase;
                Console.WriteLine("Строка до: {0}\nПосле: {1}\n", str, str = A(str));
                A = StringHandler.Upper;
                Console.WriteLine("Строка до: {0}\nПосле: {1}\n", str, str = A(str));
                A = StringHandler.Letter;
                Console.WriteLine("Строка до: {0}\nПосле: {1}\n", str, str = A(str));
                A = StringHandler.AddToString;
                Console.WriteLine("Строка до: {0}\nПосле: {1}\n", str, str = A(str));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadKey();
        }
    }
}