namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
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

        public void Enqueue(T item)
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
               lastElement =  lastElement.Next;

            }
            lastElement.Next = new Node(item);
            this.Count++;

        }

        public T Dequeue()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            this.Count--;
            var oldHead = this.head;
            head = oldHead.Next;
            return oldHead.Element;
        }

        public T Peek()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            return this.head.Element;
        }

        public bool Contains(T item)
        {

            var node = this.head;

            while (node != null)
            {
                if (node.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}