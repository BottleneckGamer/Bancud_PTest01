using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTest01_A
{
    public interface ILinkedList<T>
    {
        void AddToHead(Node<T> node);
        void AddToTail(Node<T> node);
        Node<T> RemoveFromHead();
        Node<T> RemoveFromTail();
        bool Delete(T data);
        bool DeleteFromPosition(int index);
        Node<T> Search(T data);
        void SwapHeadAndTail();
        void MoveHeadToRight(int moves);
        void MoveHeadToLeft(int moves);
        void MoveTailToRight(int moves);
        void MoveTailToLeft(int moves);

    }
}
