using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTest01_A
{
    class Program
    {
        static void Main(string[] args)
        {
           ILinkedList<int> ilist = new CircularLinkedList<int>();;
            ilist.AddToTail(new Node<int>(1));
            ilist.AddToTail(new Node<int>(2));
            ilist.AddToTail(new Node<int>(3));
            ilist.AddToTail(new Node<int>(4));
            ilist.AddToTail(new Node<int>(5));
            ilist.MoveTailToRight(1);
            ilist.MoveTailToRight(1);

           
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddToTail(new Node<int>(1));
            list.AddToTail(new Node<int>(2));
            list.AddToTail(new Node<int>(3));
            list.AddToTail(new Node<int>(4));
            list.AddToTail(new Node<int>(5));
     

            CircularLinkedList<int> list1 = new CircularLinkedList<int>();
            list1.AddToTail(new Node<int>(1));
            list1.AddToTail(new Node<int>(2));
            list1.AddToTail(new Node<int>(3));
            list1.AddToTail(new Node<int>(4));
            list1.AddToTail(new Node<int>(5));
            list1.MoveTailToRight(1);
            list1.MoveTailToRight(1);


            

            list1.PrintList();
            Console.ReadLine();
        }
    }
}
