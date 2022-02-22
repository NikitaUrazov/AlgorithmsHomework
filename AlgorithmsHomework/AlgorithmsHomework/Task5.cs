using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHomework
{
    class Task5
    {
        public void ShowResult()
        {
            Console.Clear();

            Console.WriteLine("1) Создадим бинарное дерево с числами 15, 20, 10, -3, 21, 12.");
            BinaryTree testTree = new BinaryTree(15, 20, 10, -3, 21, 12);
            ShowTree(testTree);

            Console.WriteLine("2.1) Добавим числа 18 и 113 в бинарное дерево.");
            testTree.AddNode(18);
            testTree.AddNode(113);
            ShowTree(testTree);

            Console.WriteLine("2.2) Добавим уже присутсвующее в дереве число 20 в бинарное дерево.");
            testTree.AddNode(20);
            ShowTree(testTree);

            Console.WriteLine("3.1) Удалим число 20 из бинарного дерева.");
            testTree.DeleteNodeByValue(20);
            ShowTree(testTree);

            Console.WriteLine("3.2) Удалим отсутствующее в дереве число 25 из бинарного дерева.");
            testTree.DeleteNodeByValue(25);
            ShowTree(testTree);

            Console.WriteLine("3.3) Удалим корень дерева");
            testTree.DeleteNodeByValue(15);
            ShowTree(testTree);

            Console.WriteLine("4.1) Найдём узел дерева с значением -3.");
            BinaryTreeNode node = testTree.GetNodeByValue(-3);
            ShowNode(node);

            Console.WriteLine("4.2) Найдём узел дерева с значением 73.");
            node = testTree.GetNodeByValue(73);
            ShowNode(node);
        }

        private void ShowTree(BinaryTree tree)
        {
            tree.ShowArray();
            Console.WriteLine();
            tree.ShowTree();
            Console.WriteLine();
        }

        private void ShowNode(BinaryTreeNode node)
        {
            Console.Write("Значение узла: ");
            if (node != null)
                Console.WriteLine(node.Value);
            else
                Console.WriteLine("null");
            Console.WriteLine();
        }
    }
}
