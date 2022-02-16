using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHomework
{
    class Task5
    {
        public void ShowResult()
        {
            B_Tree_Node testTree = GetTestTree();
            Console.WriteLine(CountB_Tree(testTree));
            Console.WriteLine("Tree depth = " + GetB_TreeDepth(testTree));
            int[] b_TreeArray = GetB_TreeArray(testTree);
            /*
            Console.WriteLine(b_TreeArray.Length);
            
            for (int i = 0; i < b_TreeArray.Length; i++)
            {

                Console.Write(i + ")");
                if (b_TreeArray[i] == int.MinValue)
                    Console.Write("  ");
                else
                    Console.Write(b_TreeArray[i] + " ");
            }
            Console.WriteLine();
            */
            ShowB_Tree(b_TreeArray);
        }

        public B_Tree_Node GetTestTree()
        {
            B_Tree_Node testTree = new B_Tree_Node(17);
            InsertB_Tree(testTree, 15);
            InsertB_Tree(testTree, 20);
            InsertB_Tree(testTree, 21);
            InsertB_Tree(testTree, 14);
            InsertB_Tree(testTree, 22);
            InsertB_Tree(testTree, 23);
            InsertB_Tree(testTree, 19);
            InsertB_Tree(testTree, -18);
            InsertB_Tree(testTree, -19);
            InsertB_Tree(testTree, -15);

            return testTree;
        }

        public void ShowB_Tree(int[] array)
        {
            if (array == null)
            {
                Console.WriteLine("Error. Empty array.");
                return;
            }

            if (array.Length == 1)
            {
                Console.WriteLine("Error. Incorrect array.");
                return;
            }
            else if (array.Length == 2)
            {
                Console.WriteLine(array[1]);
                return;
            }
            else
            {
                int arrayLength = array.Length;
                int depth = 0;

                while (arrayLength > 1)
                {
                    arrayLength /= 2;
                    depth++;
                }
                string[] output = new string[depth];
                for (int i = 0; i < output.Length; i++)
                    output[i] = "";

                int nElemInStr = 1;
                for (int i = 0; i < depth - 1; i++)
                    nElemInStr *= 2;
                //Console.WriteLine("nElemInStr = " + nElemInStr);
                int outputFormat = 3;
                int spaceSize = 1;
                int marginSize = 0;

                for (int i = array.Length - 1, n = 0, j = output.Length - 1; i >= 1; i--)
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

                    if (array[i] == int.MinValue)
                    {
                        output[j] = AddSpaces(output[j], spaceSize * outputFormat);
                        output[j] = "___" + output[j];
                    }
                    else if (array[i] >= 0)
                    {
                        output[j] = AddSpaces(output[j], spaceSize*outputFormat);
                        output[j] = array[i].ToString("D3") + output[j];
                    }
                    else
                    {
                        output[j] = AddSpaces(output[j], spaceSize * outputFormat - 1);
                        output[j] = array[i].ToString("D3") + output[j];
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

        public string AddSpaces(string str, int nSpaces)
        {
            for (int i = 0; i < nSpaces; i++)
            {
                str = ' ' + str;
            }

            return str;
        }

        public int GetB_TreeDepth(B_Tree_Node head)
        {
            int depth = 0;
            CalculateDepth(head, ref depth, 0);
            return depth;
        }

        public void CalculateDepth(B_Tree_Node head, ref int depth, int currentDepth)
        {
            if (head == null)
                return;
            else
            {
                currentDepth++;
                if (currentDepth > depth)
                    depth = currentDepth;
                CalculateDepth(head.Left, ref depth, currentDepth);
                CalculateDepth(head.Right, ref depth, currentDepth);
            }
        }

        public int[] GetB_TreeArray(B_Tree_Node head)
        {
            if (head == null)
                return null;
            int treeDepth = GetB_TreeDepth(head);
            int size = 1;

            for (int i = 0; i < treeDepth; i++)
            {
                size = size * 2;
            }

            int[] b_TreeArray = new int[size];

            FillArray(b_TreeArray, head);

            return b_TreeArray;
        }

        public void FillArray(int[] array, B_Tree_Node b_Tree)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = int.MinValue;

            array[1] = b_Tree.Value;

            if (array.Length == 2)
                return;

            for (int i = 2; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    int parentValue = array[i / 2];
                    B_Tree_Node parent = GetNodeByValue(b_Tree, parentValue);

                    if (parent != null)
                    {
                        if (parent.Left != null)
                        {
                            array[i] = parent.Left.Value;
                        }
                    }
                }
                else
                {
                    int parentValue = array[(i - 1) / 2];
                    B_Tree_Node parent = GetNodeByValue(b_Tree, parentValue);
                    if (parent != null)
                    {
                        if (parent.Right != null)
                        {
                            array[i] = parent.Right.Value;
                        }
                    }
                }
            }

        }

        public B_Tree_Node GetNodeByValue(B_Tree_Node node, int value)
        {
            if (node == null)
                return null;
            else if (value == node.Value)
                return node;
            else if (value < node.Value)
                node = GetNodeByValue(node.Left, value);
            else if (value > node.Value)
                node = GetNodeByValue(node.Right, value);

            return node;
        }

        public int CountB_Tree(B_Tree_Node head)
        {
            if (head != null)
                return 1 + CountB_Tree(head.Right) + CountB_Tree(head.Left);
            else
                return 0;
        }

        public void InsertB_Tree(B_Tree_Node head, int value)
        {
            if (head == null)
            {
                head = new B_Tree_Node(value);
                return;
            }

            B_Tree_Node currentNode = head;

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
                        currentNode.Right = new B_Tree_Node(value);
                        return;
                    }
                }
                else if (value < currentNode.Value)
                {
                    if (value < currentNode.Value)
                    {
                        if (currentNode.Left != null)
                        {
                            currentNode = currentNode.Left;
                            continue;
                        }
                        else
                        {
                            currentNode.Left = new B_Tree_Node(value);
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}
