using System;

namespace DataStructures
{
    /// <summary>
    /// Binary Search Tree using linked list
    /// Author: Pavan Navule
    /// </summary>
    class BinarySearchTreeDemo
    {
        static void Main(string[] args)
        {
            int[] arr = { 9, 5, 1, 6, 12 };
            Tree bst = new Tree();
            foreach (var item in arr)
            {
                bst.Insert(item);
            }

            Console.WriteLine("InOrder Traversal");
            bst.InOrder(bst.Root);
            Console.WriteLine("\r\nPostOrder Traversal");
            bst.PostOrder(bst.Root);
            Console.WriteLine("\r\nPreOrder Traversal");
            bst.PreOrder(bst.Root);
            Console.Read();
        }

        /// <summary>
        /// BST Node Structure
        /// </summary>
        public class Node
        {
            private int _val;

            public Node(int val)
            {
                Val = val;
            }
            public Node Right { get; set; }
            public Node Left { get; set; }
            public int Val { get => _val; set => _val = value; }

            public void Display()
            {
                Console.Write($"[{Val}]");
            }
        }

        /// <summary>
        /// A Binary Search Tree (BST) has a Root/Parent Node and atleast Two Child Node viz.,
        /// Left Node having value less than Parent Node and 
        /// Right Node having value greater than Parent Node
        /// Ex:
        ///          9
        ///         / \
        ///        5   12
        ///       / \
        ///      1   6
        ///      
        ///  A BST can be traversed in three following ways
        ///  1 InOrderTraversal => Left, Root, Right => {1, 5, 6, 9, 12}
        ///  2 PostOrderTraversal => Left, Right, Root => {1, 6, 5, 12, 9}
        ///  3 PreOrderTraversal => Root, Left, Right => {9, 5, 1, 6, 12}
        ///  This BST Tree implementation has O(n) time complexity
        /// </summary>
        public class Tree
        {
            public Tree()
            {
                Root = null;
            }

            public Node Root { get; set; }

            public void Insert(int incomingVal)
            {
                //Construct New Node
                Node newNode = new Node(incomingVal);

                //if its base node assign it to root
                if (Root == null)
                {
                    Root = newNode;
                    return;
                }

                //Take Current Node or base(Root) node into temporary Node
                Node currentTemp = Root;
                Node parent;
                while (true)
                {
                    //For every iteration Set the current node to be the parent node
                    //and then evaluate children based on its value.
                    parent = currentTemp;
                    //Left Node Construction
                    if (incomingVal < currentTemp.Val)
                    {
                        currentTemp = currentTemp.Left;
                        if (currentTemp == null)
                        {
                            parent.Left = newNode;
                            return;
                        }
                    }
                    //Right Node Construction
                    else
                    {
                        currentTemp = currentTemp.Right;
                        if (currentTemp == null)
                        {
                            parent.Right = newNode;
                            return;
                        }
                    }
                }
            }

            /// <summary>
            /// InOrder Traversal: Left -> Root -> Right
            /// </summary>
            /// <param name="node"></param>
            public void InOrder(Node node)
            {
                if (node == null) return;
                //Left
                InOrder(node.Left);
                //Root
                Console.Write($"{node.Val} ");
                //Right
                InOrder(node.Right);
            }

            /// <summary>
            /// PostOrder Traversal: Left -> Right -> Node
            /// </summary>
            /// <param name="node"></param>
            public void PostOrder(Node node)
            {
                if (node == null) return;
                //Left
                PostOrder(node.Left);
                //Right
                PostOrder(node.Right);
                //Node
                Console.Write($"{node.Val} ");
            }

            /// <summary>
            /// PreOrder Traversal: Root -> Left -> Right
            /// </summary>
            /// <param name="node"></param>
            public void PreOrder(Node node)
            {
                if (node == null) return;
                //Root
                Console.Write($"{node.Val} ");
                //Left
                PreOrder(node.Left);
                //Right
                PreOrder(node.Right);
            }
        }
    }
}
