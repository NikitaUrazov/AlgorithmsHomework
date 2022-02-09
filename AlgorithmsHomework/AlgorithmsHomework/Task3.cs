using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHomework
{
    class Task3
    {
        public void ShowResult()
        {
            Console.Clear();
            Node testNode = CreateTestNode();
            Console.WriteLine("Список изначально:");
            ShowNode(testNode);
            Console.WriteLine("Кол-во элементов в списке: " + GetCount(testNode));
            Console.WriteLine();
            Console.WriteLine("Добавление нового элемента с значением 10: ");
            AddNode(testNode, 10);
            ShowNode(testNode);
            Console.WriteLine("Кол-во элементов в списке: " + GetCount(testNode));
            Console.WriteLine();
            Console.WriteLine("Добавление нового элемента с значением -1, после элемента с значением 2: ");
            Node nodeToAddAfter = FindNode(testNode, 2);
            AddNodeAfter(nodeToAddAfter, -1);
            ShowNode(testNode);
            Console.WriteLine("Кол-во элементов в списке: " + GetCount(testNode));
            Console.WriteLine();
            Console.WriteLine("Удаление элемента с индексом 1 (индекс начинается с 0): ");
            RemoveNode(testNode, 1);
            ShowNode(testNode);
            Console.WriteLine("Кол-во элементов в списке: " + GetCount(testNode));
            Console.WriteLine();
            Console.WriteLine("Удаление элемента со значением 3: ");
            Node nodeToRemove = FindNode(testNode, 3);
            RemoveNode(nodeToRemove);
            ShowNode(testNode);
            Console.WriteLine("Кол-во элементов в списке: " + GetCount(testNode));
        }

        public Node CreateTestNode()
        {
            Node startNode = new Node { PrevNode = null, Value = 0 };

            Node currentNode = startNode;

            for (int i = 0, value = 1; i < 4; i++, value++)
            {
                currentNode.NextNode = new Node { Value = value, PrevNode = currentNode };
                currentNode = currentNode.NextNode;
            }
            currentNode.NextNode = null;

            return startNode;
        }

        public void ShowNode(Node startNode)
        {
            Node currentNode = startNode;

            while (currentNode.NextNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
            Console.WriteLine(currentNode.Value);
        }

        public int GetCount(Node startNode)
        {
            Node currentNode = startNode;
            int count = 0;

            while (currentNode.NextNode != null)
            {
                count++;
                currentNode = currentNode.NextNode;
            }
            count++;

            return count;
        }

        public void AddNode(Node startNode, int value)
        {
            Node currentNode = startNode;

            while (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
            }

            currentNode.NextNode = new Node { Value = value, PrevNode = currentNode, NextNode = null };
        }

        public void AddNodeAfter(Node nodeToAddAfter, int value)
        {
            Node newNode = new Node { Value = value, PrevNode = nodeToAddAfter, NextNode = nodeToAddAfter.NextNode };
            nodeToAddAfter.NextNode.PrevNode = newNode;
            nodeToAddAfter.NextNode = newNode;
        }

        public void RemoveNode(Node startNode, int index)
        {
            Node currentNode = startNode;
            int currentIndex = 0;
            while (currentNode != null)
            {
                if (index == currentIndex)
                    break;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            if (currentNode == null)
                return;

            currentNode.PrevNode.NextNode = currentNode.NextNode;

        }

        public void RemoveNode(Node nodeToRemove)
        {
            nodeToRemove.PrevNode.NextNode = nodeToRemove.NextNode;
        }

        public Node FindNode(Node startNode, int searchValue)
        {
            Node currentNode = startNode;
            while (currentNode != null)
            {
                if (currentNode.Value == searchValue)
                    break;
                currentNode = currentNode.NextNode;
            }

            return currentNode;
        }
    }
}
