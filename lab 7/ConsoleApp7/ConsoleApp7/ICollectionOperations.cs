using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public interface ICollectionOperations<T>
    {
        void Add(T item);
        bool Remove(T item);
        IEnumerable<T> ViewAll();
        T Find(Predicate<T> predicate);
    }

