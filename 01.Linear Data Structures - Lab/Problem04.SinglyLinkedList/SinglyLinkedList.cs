namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {

        private class Node
        {

            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element)
            {
                this.Element = element;
            }
        }

        private Node head;
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
           var noode = new Node(item, head);
            head = noode;
            this.Count++;
        }

        public void AddLast(T item)
        {
            if (this.head == null)
            {
                this.head = new Node(item);
                this.Count++;
                return;
            }

            var lastElement = this.head;
            while (lastElement.Next != null)
            {
                lastElement = lastElement.Next;

            }
            lastElement.Next = new Node(item);
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
           var node = head;
            while (node.Next != null)
            {
               node = node.Next;
               yield return node.Element;
            }
        }

        public T GetFirst()
        {

            if (head == null)
            {
                throw new InvalidOperationException();
            }
            return this.head.Element;
        }

        public T GetLast()
        {


            if (head == null)
            {
                throw new InvalidOperationException();
            }
            var node = this.head;
            while (node.Next != null)
            {
                node = node.Next;
            }

            return node.Element;
        }

        public T RemoveFirst()
        {

            if (head == null)
            {
                throw new InvalidOperationException();
            }

            var newHead = this.head;
            head= newHead.Next;
            this.Count--;
            return newHead.Element;

            
            
        }

        public T RemoveLast()
        {

            if (head == null)
            {
                throw new InvalidOperationException();
            }
            else if (head.Next == null)
            {
                var node = head.Element;
                head = null;
                this.Count--;
                return node;

            }

            var oldHead = head;
            while (oldHead.Next != null)
            {
                oldHead = oldHead.Next;
            }

           var lastElement = oldHead.Element;
            oldHead.Next = null;
            this.Count--;
            return lastElement;
            



            
        }

        IEnumerator IEnumerable.GetEnumerator()
         => this.GetEnumerator();
    }
}