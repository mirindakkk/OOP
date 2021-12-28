using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Programmer
    {
        public delegate void ProgrammerStateHandler(List<string> list, string message);
        public event ProgrammerStateHandler Rename;
        public event ProgrammerStateHandler NewProperty;

        public Programmer()
        {

        }

        public void Edit(List<string> list, string m)
        {
            Console.Write("\n\nВведите номер объекта (1 - 5), которого хотите изменить: ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number > 0 && number < list.Count)
            {
                Console.Write("Введите новый объект: ");
                string name = Console.ReadLine();
                list[number - 1] = name;
                Rename?.Invoke(list, "Изменение прошло успешно\nНовый список объектов:");
            }
            else
            {
                throw new Exception("Неверно задан номер объекта в методе Programmer.Edit");
            }
        }

        public void Upload(List<string> list, string m)
        {
            Console.Write("\nВведите объект, который хотите добавить: ");
            string name = Console.ReadLine();
            list.Add(name);
            NewProperty?.Invoke(list, "Добавление прошло успешно\nНовый список объектов:");
        }
    }
}
