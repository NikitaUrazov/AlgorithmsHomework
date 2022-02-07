using System;

namespace AlgorithmsHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            string input;
            int taskNumber;

            Console.WriteLine("1) Напишите функцию согласно блок-схеме.");
            Console.WriteLine("2) Реализуйте функцию вычисления числа Фибоначчи.");
            Console.WriteLine("3) Реализуйте класс двусвязного списка и операции вставки, удаления и поиска элемента в нём.");
            Console.WriteLine();
            Console.Write("Введите номер задания: ");
            input = Console.ReadLine();

            if (int.TryParse(input, out taskNumber))
            {
                switch (taskNumber)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    default:
                        Console.WriteLine("Задание отстутсвует");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Неккоректный ввод.");
            }

            return;
        }

        static void Task1()
        {
            int number;
            Console.Write("Введите число: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Неккоректный ввод.");
                return;
            }

            if (IsSimple(number))
                Console.WriteLine("Простое.");
            else
                Console.WriteLine("Не простое.");
        }

        static bool IsSimple(int number)
        {
            int d = 0, i = 2;

            while (i < number)
            {
                if (number % i == 0)
                    d++;
                i++;
            }

            if (d == 0)
                return true;
            else
                return false;
        }

        static void Task2()
        {
            int n;
            Console.Write("Введите номер числа Фибоначчи, считая с нуля (0, 1, 2 и т.д.): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out n))
            {
                Console.WriteLine("Неккоректный ввод.");
                return;
            }

            if (n < 0)
            {
                Console.WriteLine("Ошибка. Число меньше нуля.");
                return;
            }

            Console.WriteLine("Число Фибоначчи(" + n + ") = " + Fibonacci(n, 0, 1));
        }

        static long Fibonacci(int n, int beforePrevious, int previous)
        {
            if (n == 0 && beforePrevious == 0 && previous == 1)
                return 0;
            else if (n == 1 && beforePrevious == 0 && previous == 1)
                return 1;
            else
            {
                if (n > 1)
                    return Fibonacci(n - 1, previous, beforePrevious + previous);
                else
                    return previous;
            }
        }

        static void Task3()
        {
            Console.Clear();
            Node testNode = CreateTestNode();
            Console.WriteLine("Список изначально:");
            ShowNode(testNode);
            Console.WriteLine("Кол-во элементов в списке: " + GetCount(testNode));
            Console.WriteLine();
            Console.WriteLine("Добавление нового элемента элемента с значением 10: ");
            AddNode(testNode, 10);
            ShowNode(testNode);
            Console.WriteLine("Кол-во элементов в списке: " + GetCount(testNode));
            Console.WriteLine();
            Console.WriteLine("Добавление нового элемента элемента с значением -1, после элемента с значением 2: ");
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

        
        static Node CreateTestNode()
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

        static void ShowNode(Node startNode)
        {
            Node currentNode = startNode;

            while (currentNode.NextNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
            Console.WriteLine(currentNode.Value);
        }

        static int GetCount(Node startNode)
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

        static void AddNode(Node startNode, int value)
        {
            Node currentNode = startNode;

            while (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
            }

            currentNode.NextNode = new Node { Value = value, PrevNode = currentNode, NextNode = null };
        }

        static void AddNodeAfter(Node nodeToAddAfter, int value)
        {
            Node newNode = new Node { Value = value, PrevNode = nodeToAddAfter, NextNode = nodeToAddAfter.NextNode };
            nodeToAddAfter.NextNode.PrevNode = newNode;
            nodeToAddAfter.NextNode = newNode;
        }
    
        static void RemoveNode(Node startNode, int index)
        {
            Node currentNode = startNode;
            int currentIndex = 0;
            while(currentNode != null)
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
    
        static void RemoveNode(Node nodeToRemove)
        {
            nodeToRemove.PrevNode.NextNode = nodeToRemove.NextNode;
        }
    
        static Node FindNode(Node startNode, int searchValue)
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
