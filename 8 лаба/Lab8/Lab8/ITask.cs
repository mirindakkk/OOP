using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    interface ITask <T> where T : class
    {
        void Add(CollectionType<T> type);
        void Delete();
        void Show();
    }
}
