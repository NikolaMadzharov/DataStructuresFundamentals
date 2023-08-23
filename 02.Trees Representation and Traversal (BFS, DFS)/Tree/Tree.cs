namespace Tree

{

    using System;

    using System.Collections.Generic;



    public class Tree<T> : IAbstractTree<T>

    {

        private List<Tree<T>> children;

        private T value;

        private Tree<T> parent;

        public Tree(T value)

        {

            this.value = value;

            this.children = new List<Tree<T>>();

        }



        public Tree(T value, params Tree<T>[] children)

            : this(value)

        {

            foreach (var child in children)

            {

                child.parent = this;

                this.children.Add(child);



            }

        }



        public void AddChild(T parentKey, Tree<T> child)

        {

            var parent = FindParent(parentKey);



            parent.children.Add(child);

            child.parent = parent;

        }



        private Tree<T> FindParent(T parentKey)

        {

            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);





            while (queue.Count > 0)

            {

                var node = queue.Dequeue();



                if (node.value.Equals(parentKey))

                {

                    return node;

                }



                foreach (var child in node.children)

                {

                    queue.Enqueue(child);

                }



            }



            return null;

        }



        public IEnumerable<T> OrderBfs()

        {



            var queue = new Queue<Tree<T>>();

            var result = new List<T>();



            queue.Enqueue(this);



            while (queue.Count > 0)

            {



                var Tree = queue.Dequeue();

                result.Add(Tree.value);



                foreach (var child in Tree.children)

                {

                    queue.Enqueue(child);

                }



            }



            return result;

        }



        public IEnumerable<T> OrderDfs()

        {

            var stack = new Stack<Tree<T>>();

            var result = new List<T>();

            stack.Push(this);



            while (stack.Count > 0)

            {



                var node = stack.Pop();



                foreach (var child in node.children)

                {

                    stack.Push(child);

                }



                result.Add(node.value);

            }

            result.Reverse();



            return result;



        }



        public void RemoveNode(T nodeKey)

        {

            var removeNode = FindParent(nodeKey);



            if (removeNode is null)

            {

                throw new ArgumentException();

            }



            var parent = removeNode.parent;



            parent.children.Remove(removeNode);



        }



        public void Swap(T firstKey, T secondKey)

        {

            var firstNode = FindParent(firstKey);

            var secondNode = FindParent(secondKey);



            var firstParent = firstNode.parent;

            var secondParent = secondNode.parent;



            var firstChild = firstParent.children.IndexOf(firstNode);

            var secondCHild = secondNode.children.IndexOf(secondNode);



            if (firstNode is null || secondNode is null)

            {

                throw new ArgumentException();

            }



            if (firstParent is null || secondParent is null)

            {

                throw new ArgumentException();

            }



            firstParent.children[firstChild] = secondNode;

            secondParent.children[secondCHild] = firstNode;



            firstNode.parent = secondParent;

            secondNode.parent = firstParent;

        }

    }

}