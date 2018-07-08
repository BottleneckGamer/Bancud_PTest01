using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTest01_A
{
    class CircularLinkedList<T> : DoublyLinkedList<T>, ILinkedList<T>
    {

        protected override void AddBetween(T data, Node<T> prev, Node<T> next)
        {
            var newNode = new Node<T>(data, prev, next);

            prev.Next = newNode;
            next.Prev = newNode;

            Head = _header.Next;
            Tail = _trailer.Prev;

            Head.Prev = Tail;
            Tail.Next = Head;

            Size++;
        }

        public override void MoveHeadToLeft(int i)
        {
            if (i >= Size) throw new System.IndexOutOfRangeException("Index movement cannot be greater than size");
            AddToTail(RemoveFromHead());
            var temp = Tail;
            for (int j = 0; j < i - 1; j++)
            {
                SwapReverse(temp);
                temp = temp.Prev;
            }
            Tail = _trailer.Prev;
            //var temp = Head;
            //for (int j = 0; j < i; j++)
            //{
            //    SwapReverse(temp);
            //    temp = temp.Prev;
            //}
            //Head = _header.Next;
        }
        public override void MoveTailToRight(int i)
        {
            if (i >= Size) throw new System.IndexOutOfRangeException("Index movement cannot be greater than size");
            AddToHead(RemoveFromTail());
            var temp = Head;
            for (int j = 0; j < i-1; j++)
            {
                Swap(temp);
                temp = temp.Next;
            }

            Head = _header.Next;
        }

    }
}
