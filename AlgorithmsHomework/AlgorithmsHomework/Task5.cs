using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHomework
{
    class Task5
    {
        public void ShowResult()
        {
            BinaryTree testTree1 = new BinaryTree(15, 20, 21, 14);
            testTree1.ShowArray();
            testTree1.ShowTree();
            Console.WriteLine();

            BinaryTree testTree2 = new BinaryTree();
            testTree2.ShowArray();
            testTree2.ShowTree();

        }

       
    }
}
