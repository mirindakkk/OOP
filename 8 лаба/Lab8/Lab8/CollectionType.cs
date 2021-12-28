using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab8
{
    public class CollectionType<T> : ITask<T> where T : class  //обобщенный класс с обобщенной коллекцией и ограничителем
    {
        public T num;
        public static int number;
        public int count;
        public CollectionType<T> next;
        public CollectionType<T> pred;
        public string name;
        public FileStream file;
        public CollectionType(T n, int c)
        {
            if (n == null)
            {
                throw new Exception("Ссылка на null");
            }
            count = c;
            num = n;
            next = null;
            pred = null;

            name = Convert.ToString(count) + ".txt";
            file = new FileStream(name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }
        public CollectionType(T n)
        {
            if (n == null)
            {
                throw new Exception("Ссылка на null");
            }
            num = n;
            next = null;
            pred = null;
        }
        public void Delete()
        {
            CollectionType<T> I = this;
            for (int i = 0; I.next != null; i++)
            {
                I = I.next;
            }
            I.pred.next = null;
            I.pred = null;
        }
        public void Add(CollectionType<T> type)
        {
            CollectionType<T> I = this;
            if (type == null)
            {
                throw new Exception("Ссылка на null");
            }
            for (int i = 0; I.next != null; i++)
            {
                I = I.next;
            }
            I.next = type;
            type.pred = I;
        }
        public void Show()
        {
            CollectionType<T> I = this;
            Console.WriteLine("\n------- CollectionType -------");
            for (int i = 0; I != null; i++)
            {
                Console.WriteLine((i + 1) + " элемент списка - " + I.num.ToString());
                I = I.next;
            }
            Console.WriteLine("--------------------");
        }
    }
}