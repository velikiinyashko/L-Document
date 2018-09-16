using System;
using System.Collections.Generic;
using System.Text;

namespace server.Modules
{
    class QueueModule<T> where T :  Queue<T>
    {

        public Queue<T> Queues { get; set; }

        public QueueModule(Queue<T> Queue)
        {
            Queues = Queue;
        }

        public void EnQueue(T Object)
        {
            Queues.Enqueue(Object);
        }

        public T DeQueue()
        {
            T Object = Queues.Dequeue();
            return Object;
        }
    }
}
