using System;
using System.Collections.Generic;

namespace PTest01_A
{

    public class DoublyLinkedList<T> : ILinkedList<T>
    {
        public int Size { get; protected set; }
        public Node<T> _header;
        public Node<T> _trailer;
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public DoublyLinkedList()
        {
            _header = new Node<T>(default(T), null, null);
            _trailer = new Node<T>(default(T), _header, null);
            _header.Next = _trailer;
            Size = 0;
        }

        public void AddToHead(Node<T> node)
        {
            AddBetween(node.Data, _header, _header.Next);
        }
        public void AddToTail(Node<T> node)
        {
            AddBetween(node.Data, _trailer.Prev, _trailer);

        }

        protected virtual void AddBetween(T data, Node<T> prev, Node<T> next)
        {
            var newNode = new Node<T>(data, prev, next);

            prev.Next = newNode;
            next.Prev = newNode;

            Head = _header.Next;
            Tail = _trailer.Prev;

            Size++;
        }

        public Node<T> RemoveFromTail()
        {
            if (Tail == null) return null;
            var tmp = Tail;
            Remove(Tail.Prev, _trailer);
            return tmp;

        }

        public Node<T> RemoveFromHead()
        {
            if (Head == null) return null;
            var tmp = Head;
            Remove(_header, Head.Next);
            return tmp;

        }
        private void Remove(Node<T> prev, Node<T> next)
        {
            if (Head == null) return;
            if (Head == Tail) Head = Tail = null;
            prev.Next = next;
            next.Prev = prev;

            Head = _header.Next;
            Tail = _trailer.Prev;

            Size--;
        }

        public bool Delete(T data)
        {
            var temp = _header.Next;
            while (temp.Next != null)
            {
                if (AreEqual(temp.Data, data))
                {
                    Remove(temp, temp.Next);
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        public Node<T> Search(T data)
        {
            var temp = _header.Next;
            while (temp.Next != null)
            {
                if (AreEqual(temp.Data, data))
                {
                    return temp;
                }
                temp = temp.Next;
            }

            return null;
        }

        public void MoveHeadToRight(int i)
        {
            if (i >= Size) throw new System.IndexOutOfRangeException("Index movement cannot be greater than size");
            var temp = Head;

            for (int j = 0; j < i; j++)
            {
                Swap(temp);
                temp = temp.Next;
            }
            Head = _header.Next;
        }
        public virtual void MoveHeadToLeft(int i)
        {
            var temp = new Node<T>(Head.Data, _header, Head.Next);
            Head = Head.Next;
            for (int j = 0; j < i; j++)
            {
                Swap(temp);
            }
        }
        public virtual void MoveTailToRight(int i)
        {
            var temp = new Node<T>(Head.Data, _header, Head.Next);
            Head = Head.Next;
            for (int j = 0; j < i; j++)
            {
                Swap(temp) ;

            }
        }
        public void MoveTailToLeft(int i)
        {
            if (i >= Size) throw new System.IndexOutOfRangeException("Index movement cannot be greater than size");
            if (i >= Size) return; ;
            var temp = Tail;
            for (int j = 0; j < i; j++)
            {
                SwapReverse(temp);
                temp = temp.Prev;
            }

            Tail = _trailer.Prev;
        }

        protected void Swap(Node<T> q)
        {

            Node<T> e = q.Next;
            var data = q.Data;
            q.Data = e.Data;
            e.Data = data;
        }
        protected void SwapReverse(Node<T> q)
        {

            Node<T> e = q.Prev;
            var data = q.Data;
            q.Data = e.Data;
            e.Data = data;
        }

        //public void Merge(DoublyLinkedList<T> list)
        //{
        //    var temp = list._header;

        //    while (temp.Next != list._trailer)
        //    {
        //        AddToTail(temp.Next.Data);
        //        temp = temp.Next;
        //    }
        //}
        public bool DeleteFromPosition(int i)
        {
            if (i >= Size) return false;
            var temp = _header.Next;
            for (int j = 0; j < i; j++)
            {
                temp = temp.Next;
            }

            Remove(temp.Prev, temp);
            Size--;
            return true;
        }



        public void SwapHeadAndTail()
        {
            var Data = Head.Data;
            Head.Data = Tail.Data;
            Tail.Data = Data;
        }


        public void PrintList()
        {
            var temp = _header.Next;
            for (int i = 0; i < Size; i++)
        
            {
                Console.Write($"{temp.Data}, ");
                temp = temp.Next;
            }
        }

        public void RemoveAtIndexes(DoublyLinkedList<int> list)
        {
            if (Type.GetTypeCode(this.GetType()) == TypeCode.Int32) this.OrderIncreasing(); ;
            list.RemoveRedundancy();
            list.OrderIncreasing();


            var temp = list._header.Next;
            int counter = 1;
            while (temp.Next != null)
            {
                this.DeleteFromPosition((Convert.ToInt32(temp.Data)) - counter);
                temp = temp.Next;
                counter++;
            }
        }

        public void RemoveRedundancy()
        {
            var temp = _header.Next;
            int index = 0;
            while (temp.Next != null)
            {
                int marker = index + 1;
                for (var temp2 = temp.Next; temp2.Next != null; temp2 = temp2.Next)
                {
                    if (AreEqual(temp.Data, temp2.Data))
                    {
                        this.DeleteFromPosition(marker);
                        marker--;
                    }
                    marker++;
                }
                temp = temp.Next;
                index++;
            }

        }

        public static bool AreEqual<T>(T param1, T param2)
        {
            return EqualityComparer<T>.Default.Equals(param1, param2);
        }


        public void OrderIncreasing()
        {
            var temp = _header.Next;
            int IsOrder = 0;
            do
            {
                IsOrder = 0;
                while (temp.Next.Next != null)
                {
                    if (Convert.ToInt32(temp.Next.Data) < Convert.ToInt32(temp.Data))
                    {
                        Swap(temp);
                        IsOrder++;
                    }
                    else temp = temp.Next;
                }

                temp = _header.Next;
            } while (IsOrder > 0);

        }

        public void Compare(DoublyLinkedList<T> list)
        {
            var temp1 = this._header.Next;
            var temp2 = list._header.Next;
            while (temp1 != null && temp2 != null)
            {
                if (AreEqual(temp1.Data, temp2.Data))
                {
                    temp1 = temp1.Next;
                    temp2 = temp2.Next;

                }
                else
                {
                    Console.WriteLine("Not Equal");
                    return;
                }

            }
            Console.WriteLine("Equal");

        }




        public void Reverse()
        {
            var q = _header.Next;
            var e = _trailer.Prev;
            for (int i = 0; i < (Size / 2); i++)
            {
                T data = q.Data;
                q.Data = e.Data;
                e.Data = data;

                q = q.Next;
                e = e.Prev;

            }
        }

    }

}