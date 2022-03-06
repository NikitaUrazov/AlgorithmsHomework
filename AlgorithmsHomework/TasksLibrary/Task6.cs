using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHomework
{
    public class Task6 : ITask
    {
        public int TaskID => 6;

        public string TaskName => "6) Домашняя работа 5. Реализуйте методы поиска в дереве \"поиск в ширину\" и \"поиск в глубину\".";

        public void ShowResult()
        {
            Console.Clear();
            BinaryTree tree = new BinaryTree(15, 21, 7, 9, 6, 16, 23);

            Console.WriteLine("Попробуем найти элемент 9 поиском в ширину.");
            Console.WriteLine();
            tree.ShowTree();
            Console.WriteLine();            
            BinaryTreeNode node = tree.BFS(9);
            Console.WriteLine($"Полученный элемент: {node.Value}");

            Console.WriteLine();
            Console.WriteLine("Попробуем найти элемент 9 поиском в глубину.");
            Console.WriteLine();
            tree.ShowTree();
            Console.WriteLine();
            node = tree.DFS(9);
            Console.WriteLine($"Полученный элемент: {node.Value}");

            Console.WriteLine();
            Console.WriteLine("Попробуем найти элемент 100 поиском в ширину.");
            Console.WriteLine();
            tree.ShowTree();
            Console.WriteLine();
            node = tree.BFS(100);
            if (node == null)
                Console.WriteLine($"Полученный элемент: null");

            Console.WriteLine();
            Console.WriteLine("Попробуем найти элемент 100 поиском в глубину.");
            Console.WriteLine();
            tree.ShowTree();
            Console.WriteLine();
            node = tree.DFS(100);
            if (node == null)
                Console.WriteLine($"Полученный элемент: null");

            Console.WriteLine();
            Console.WriteLine("Поиск числа в пустом дереве.");
            BinaryTree emptyTree = new BinaryTree();
            Console.WriteLine("В ширину:");
            emptyTree.BFS(15);
            Console.WriteLine("В глубину:");
            emptyTree.DFS(15);
        }
    }
}
