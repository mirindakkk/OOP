using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab10
{
    public class Island : IComparable<Island>, IComparer<Island>
    {
        public string Name { get; set; }
        public Island(string nm)
        {
            this.Name = nm;
        }
        public int CompareTo(Island island)
        {
            return this.Name.CompareTo(island.Name);
        }
        public int Compare(Island i1, Island i2)
        {
            if (i1.Name.Length > i2.Name.Length)
            {
                return 1;
            }
            else if (i1.Name.Length < i2.Name.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //1
            ArrayList arrayList = new ArrayList
            {
                1, 2, 3, 4, 5,
                "Lex"
            };

            arrayList.RemoveAt(2);

            foreach (var a in arrayList)
            {
                Console.Write(a + " ");
            }

            Console.WriteLine("\nКоличество элементов:" + arrayList.Count);
            Console.WriteLine("Поиск элемента " + arrayList.Contains("Lex"));
            //2

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            foreach (var el in queue)
            {
                Console.Write(el + " ");
            }

            Console.WriteLine();

            queue.Dequeue();

            foreach (var el in queue)
            {
                Console.Write(el + " ");
            }

            Console.WriteLine();

            SortedDictionary<int, string> SDict = new SortedDictionary<int, string>
            {
                { queue.Dequeue(), "b" },
                { queue.Dequeue(), "s" },
                { queue.Dequeue(), "t" },
                { queue.Dequeue(), "u" },
            };

            foreach (var el in SDict)
            {
                Console.WriteLine(el);
            }

            Console.WriteLine(SDict.ContainsKey(5));
            Console.WriteLine(SDict.ContainsValue("o"));

            Queue<Island> island = new Queue<Island>();
            Island island1 = new Island("Island1");
            Island island2 = new Island("Island2");
            Island island3 = new Island("Island3");
            island.Enqueue(island1);
            island.Enqueue(island2);
            island.Enqueue(island3);

            //observe
            ObservableCollection<Island> p = new ObservableCollection<Island>();

            void p_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Island newIsland = e.NewItems[0] as Island;
                        Console.WriteLine("Добавлен новый объект: " + newIsland.Name);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Island oldIsland = e.OldItems[0] as Island;
                        Console.WriteLine("Удален объект: " + oldIsland.Name);
                        break;
                }
            }

            p.CollectionChanged += p_CollectionChanged;

            p.Add(island1);
            p.Add(island2);
            p.Add(island3);
            p.RemoveAt(2);

            foreach (Island i in p)
            {
                Console.WriteLine(i.ToString());
            }

            Console.ReadKey();
        }
    }
}