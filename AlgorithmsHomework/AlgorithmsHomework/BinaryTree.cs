using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHomework
{
    class BinaryTree
    {
        private BinaryTreeNode Head { get; set;} = null;

        private int[] Array { get; set; } = null;

        private int Depth { get; set; }

        public BinaryTree(params int[] values)
        {
            if (values != null)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    Insert(values[i]);
                }
                TreeToArray();
            }
        }

        public void ShowTree()
        {
            Console.WriteLine("Бинарное дерево:");
            if (Array == null)
            {
                Console.WriteLine("Error. Null array.");
                return;
            }

            if (Array.Length == 1)
            {
                Console.WriteLine("Error. Incorrect array.");
                return;
            }
            else if (Array.Length == 2)
            {
                Console.WriteLine(Array[1]);
                return;
            }
            else
            {
                string[] output = new string[Depth];
                for (int i = 0; i < output.Length; i++)
                    output[i] = "";

                int nElemInStr = 1;
                for (int i = 0; i < Depth - 1; i++)
                    nElemInStr *= 2;
                //Console.WriteLine("nElemInStr = " + nElemInStr);
                int outputFormat = 3;
                int spaceSize = 1;
                int marginSize = 0;

                for (int i = Array.Length - 1, n = 0, j = output.Length - 1; i >= 1; i--)
                {
                    if (n != nElemInStr)
                    {
                        n++;
                    }
                    else
                    {
                        n = 1;
                        nElemInStr /= 2;
                        output[j] = AddSpaces(output[j], marginSize * outputFormat);
                        marginSize = spaceSize;
                        spaceSize = marginSize + 1 + marginSize;
                        j--;
                    }

                    if (Array[i] == int.MinValue)
                    {
                        output[j] = AddSpaces(output[j], spaceSize * outputFormat);
                        output[j] = "___" + output[j];
                    }
                    else if (Array[i] >= 0)
                    {
                        output[j] = AddSpaces(output[j], spaceSize * outputFormat);
                        output[j] = Array[i].ToString("D3") + output[j];
                    }
                    else
                    {
                        output[j] = AddSpaces(output[j], spaceSize * outputFormat - 1);
                        output[j] = Array[i].ToString("D3") + output[j];
                    }

                    if (i == 1)
                    {
                        output[j] = AddSpaces(output[j], marginSize * outputFormat);
                    }
                }

                for (int i = 0; i < output.Length; i++)
                    Console.WriteLine(output[i]);

            }
        }

        private string AddSpaces(string str, int nSpaces)
        {
            for (int i = 0; i < nSpaces; i++)
            {
                str = ' ' + str;
            }

            return str;
        }

        private void TreeToArray()
        {
            if (Head == null)
            {
                Array = null;
                return;
            }
            Depth = GetDepth();
            int size = 1;

            for (int i = 0; i < Depth; i++)
            {
                size = size * 2;
            }

            Array = new int[size];

            for (int i = 0; i < Array.Length; i++)
                Array[i] = int.MinValue;

            Array[1] = Head.Value;

            if (Array.Length == 2)
                return;

            for (int i = 2; i < Array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    int parentValue = Array[i / 2];
                    BinaryTreeNode parent = GetNodeByValue(parentValue);

                    if (parent != null)
                        if (parent.Left != null)
                            Array[i] = parent.Left.Value;
                }
                else
                {
                    int parentValue = Array[(i - 1) / 2];
                    BinaryTreeNode parent = GetNodeByValue(parentValue);
                    if (parent != null)
                        if (parent.Right != null)
                            Array[i] = parent.Right.Value;
                }
            }
        }

        public void ShowArray()
        {
            Console.WriteLine("Массив бинарного дерева:");
            if (Array == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                for (int i = 0; i < Array.Length; i++)
                {
                    if (Array[i] == int.MinValue)
                        Console.Write(i + ") ");
                    else
                        Console.Write(i + ")" + Array[i] + " ");
                }
            }
            Console.WriteLine();
        }

        private int GetDepth()
        {
            int depth = 0;
            CalculateDepth(Head, ref depth, 0);
            return depth;
        }

        private void CalculateDepth(BinaryTreeNode currentNode, ref int depth, int currentDepth)
        {
            if (currentNode == null)
                return;
            else
            {
                currentDepth++;
                if (currentDepth > depth)
                    depth = currentDepth;
                CalculateDepth(currentNode.Left, ref depth, currentDepth);
                CalculateDepth(currentNode.Right, ref depth, currentDepth);
            }
        }

        public BinaryTreeNode GetNodeByValue(int value)
        {
            BinaryTreeNode currentNode = Head;
            return GetNodeByValue(Head, value);
        }

        private BinaryTreeNode GetNodeByValue(BinaryTreeNode currentNode, int value)
        {
            if (currentNode == null)
                return null;
            else if (value == currentNode.Value)
                return currentNode;
            else if (value < currentNode.Value)
                return GetNodeByValue(currentNode.Left, value);
            else
                return GetNodeByValue(currentNode.Right, value);
        }

        public void AddNode(int value)
        {
            Insert(value);
            TreeToArray();
        }

        private void Insert(int value)
        {
            if (Head == null)
            {
                Head = new BinaryTreeNode(value);
                return;
            }

            BinaryTreeNode currentNode = Head;

            while (true)
            {
                if (value > currentNode.Value)
                {
                    if (currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;
                        continue;
                    }
                    else
                    {
                        currentNode.Right = new BinaryTreeNode(value);
                        return;
                    }
                }
                else if (value < currentNode.Value)
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                        continue;
                    }
                    else
                    {
                        currentNode.Left = new BinaryTreeNode(value);
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Элемент "+ value + " не добален: Такой элемент уже присутствует.");
                    return;
                }
            }
        }
    }
}
