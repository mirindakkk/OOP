using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap4
{
    class ExtendedStack
    {
        private List<int> storage;
        public Owner owner;
        public Date creationDate;

        public class Owner //вложенный объект 
        {
            public int id;
            public string name;
            public string organisation;

            public Owner(int id, string name, string organisation)
            {
                this.id = id;
                this.name = name;
                this.organisation = organisation;
            }
        }

        public class Date //вложенный класс
        {
            DateTime dateTime = DateTime.Now;

            public override String ToString()
            {
                return dateTime.ToShortDateString();
            }
        }

        public ExtendedStack()
        {
            this.storage = new List<int>();
            this.owner = new Owner(1, "Karolina Mirinskaya", "BSTU");
            this.creationDate = new Date();
        }

        //Public хранилище только для чтения
        public List<int> Storage
        {
            get
            {
                return this.storage;
            }
        }

        //Счетчик
        public int Count
        {
            get
            {
                return this.storage.Count;
            }
        }

        //Добавить элемент в стек
        public void Push(int element)
        {
            this.storage.Add(element);
        }

        //Извлечь элемент из стека
        public int Pop()
        {
            int lastElementIndex = this.storage.Count - 1;
            int lastElement = this.storage[lastElementIndex];
            this.storage.RemoveAt(lastElementIndex);
            return lastElement;
        }

        //Индексатор
        public int this[int index]
        {
            get
            {
                return this.storage[index];
            }

            set
            {
                this.storage[index] = value;
            }
        }

        // + - добавить элемент в стек
        public static ExtendedStack operator +(ExtendedStack stack, int element)
        {
            stack.Push(element);
            return stack;

        }

        // -- - извлечь элемент из стека
        public static ExtendedStack operator --(ExtendedStack stack)
        {
            stack.Pop();
            return stack;
        }
        public static ExtendedStack operator ++(ExtendedStack stack)
        {
            stack.Push(1);
            return stack;
        }

        public IEnumerator GetEnumerator()
        {
            return this.storage.GetEnumerator();
        }

        public bool ContainsNegatives()
        {
            bool containsNegatives = false;
            foreach (int n in storage)
            {
                if (n < 0)
                {
                    containsNegatives = true;
                    break;
                }
            }
            return containsNegatives;
        }

        // true  - проверка, пустой ли стек
        public static bool operator true(ExtendedStack stack)
        {
            return (stack.Count == 0);
        }
        public static bool operator false(ExtendedStack stack)
        {
            return stack.ContainsNegatives();
        }

        // > - копирование одного стека в другой с сортировкой в возрастающем порядке
        public static ExtendedStack operator >(ExtendedStack stack1, ExtendedStack stack2)
        {
            ExtendedStack result = new ExtendedStack();
            while (stack1.Count != 0)
            {
                result = result + stack1.Pop();
            }
            while (stack2.Count != 0)
            {
                result = result + stack2.Pop();
            }
            result.storage.Sort();
            return result;
        }
        public static ExtendedStack operator <(ExtendedStack a, ExtendedStack b)
        {
            if (a.Count < b.Count)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}
