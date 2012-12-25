namespace Queue
{
    using System;
    /// 
    /// implementation for a First in First out Queue
    /// 
    public class Queue
    {
        private uint count = 0;
        private Node front = null;
        private Node end = null;
        private Node temp = null;

        /// 
        /// Test to see if the Queue might be empty.
        /// 
        public bool empty
        {
            get
            {
                return (count == 0);
            }
        }
        /// 
        /// Number of Items in the Queue.
        /// 
        public uint Count
        {
            get
            {
                return count;
            }
        }
        /// 
        /// This function will append to the end of the Queue or 
        /// create The first Node instance.
        /// 
        ///  
        public void append(object obj)
        {
            if (count == 0)
            {
                front = end = new Node(obj, front);
            }
            else
            {
                end.Next = new Node(obj, end.Next);
                end = end.Next;
            }
            count++;
        }
        /// 
        /// This function will serve from the front of the Queue.  Notice
        /// no deallocation for the Node Class, This is now handled by the 
        /// Garbage Collector.
        /// 
        public object serve()
        {
            temp = front;
            if (count == 0)
                throw new Exception("tried to serve from an empty Queue");
            front = front.Next;
            count--;
            return temp.Value;
        }
        /// 
        /// This function will print everything that is currently in the 
        /// Queue.
        /// 
        public void printQueue()
        {
            temp = front;
            while (temp != null)
            {
                Console.WriteLine("{0}", temp.Value.ToString());
                temp = temp.Next;
            }
        }

    }
    /// 
    /// The Node class holds the object and a pointer to the next
    /// Node class.
    /// 
    class Node
    {
        public Node Next;
        public object Value;

        public Node(object value, Node next)
        {
            Next = next;
            Value = value;
        }
    }
    /// 
    /// This function simply excercises the functionality of the Queue
    /// and is automatically run at runtime.
    /// 
    class QueueTest
    {
        static void Main()
        {
            Queue Q = new Queue();
            object obj;
            uint i, j;
            UInt16[] numbers = new UInt16[] { 10, 20, 30 };
            for (i = 0; i < numbers.Length; i++)
                Q.append(numbers[i]);
            Q.printQueue();
            Console.WriteLine("Queue count = {0}", Q.Count);
            j = Q.Count;
            for (i = 0; i < j; i++)
            {
                obj = Q.serve();
                Console.WriteLine("serve Queue = {0}", obj.ToString());
            }
            Console.WriteLine("Queue count = {0}", Q.Count);
        }
    }

}

