using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab8
{
    public class FileHandler<T> where T : class
    {
        public static void AddToFile(CollectionType<T> type, CollectionType<T> elem)
        {
            if (type == null || type.file == null)
            {
                throw new Exception("Ссылка на null");
            }

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(type.file, elem.num);
        }
        public static void AddFromFile(CollectionType<T> type)
        {
            if (type == null || type.file == null)
            {
                throw new Exception("Ссылка на null");
            }

            
            type.file.Seek(0, SeekOrigin.Begin);
            BinaryFormatter formatter = new BinaryFormatter();
            T buf = (T)formatter.Deserialize(type.file);

            CollectionType<T> temp = new CollectionType<T>(buf);
            type.Add(temp);
        }
    }
}
