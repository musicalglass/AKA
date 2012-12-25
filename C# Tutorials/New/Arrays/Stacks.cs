using System;
using System.Collections;

namespace StackImplementation
{
    /// 
    /// Implement the stack class
    /// Created by: Michael Ganesan
    /// Date: 09/02/2001
    /// Note: Pop: removes an element from the stack
    /// Peek: Allows the user to view the top element in the collection
    /// 
    /// 
    public class MyStack
    {
        //variables
        public MyStack()
        {
            _mystack = new Stack();
        }
        public void PushElement(int x)
        {
            //Push an element onto a stack
            if (x > 0)
                _mystack.Push(x);
        }
        public int PopElement()
        {
            //Pop an element off the stack  
            if (_mystack.Count > 0)
            {
                //boxing 
                object i = _mystack.Pop();
                return ((int)i);
            }
            else
                return (0);
        }

        public int PeekElement()
        {
            //View the top element on the stack
            if (_mystack.Count > 0)
            {
                object i = _mystack.Peek();
                return ((int)i);
            }
            else
                return (0);
        }

        public void print_Elements()
        {
            //print all of the elements on the stack
            if (_mystack.Count > 0)
            {
                System.Collections.IEnumerator myenum = _mystack.GetEnumerator();
                while (myenum.MoveNext())
                {
                    Console.WriteLine("Element: {0}", myenum.Current);
                }
                Console.WriteLine("Press any key to continue!");
                Console.ReadLine();
            }
        }

        //private variables
        private Stack _mystack;
    }

    class Class1
    {
        static void Main(string[] args)
        {
            MyStack t = new MyStack();
            //Push 10 elements onto the stack
            for (int i = 0; i < 10; i++)
            {
                t.PushElement(i);
            }
            Console.WriteLine("Current Stack Values!");
            t.print_Elements();
            //Pop the last element: Remove the last element
            t.PopElement();

            //print the contents of the Stack
            Console.WriteLine("The Contents of the stack is: ");
            t.print_Elements();

            //Print the top element of the stack
            Console.WriteLine("Top Element of the stack: {0}", t.PeekElement());
            t.print_Elements();
        }
    }
}

