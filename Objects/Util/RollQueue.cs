using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public class RollQueue<T>:Queue<T>
    {
        private int capacity;
        public RollQueue(int capacity):base(capacity)
        {
            this.capacity = capacity;
        }

        public void Add(T item)
        {
            if (base.Count == capacity)
            {
                base.Dequeue();
                base.Enqueue(item);
            }
            else
            {
             base.Enqueue(item);
            }
        }

        public T FirstOrDefault()
        {
            if (base.TryPeek(out T item))
                return item;
            return default;
        }
    }
}
