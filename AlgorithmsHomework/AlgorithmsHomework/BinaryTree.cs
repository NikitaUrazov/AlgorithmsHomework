using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHomework
{
    class BinaryTree
    {
        private BinaryTreeNode Head { get; set; } = null;

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

        public void DeleteNodeByValue(int value)
        {
            if (Array == null)
                return;
            bool valueExists = false;
            for (int i = 0; i < Array.Length; i++)
                if (Array[i] != int.MinValue && Array[i] == value)
                {
                    valueExists = true;
                    Array[i] = int.MinValue;
                    break;
                }

            if (valueExists)
            {
                Head = null;
                for (int i = 1; i < Array.Length; i++)
                    if (Array[i] != int.MinValue)
                        Insert(Array[i]);
                TreeToArray();
            }
            else
            {
                Console.WriteLine($"Удаление не удалось. Число {value} остутвует в дереве.");
            }
        }

        /// <summary>
        /// Вывод бинарного дерева в консоль.
        /// </summary>
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
                int outputFormat = GetOutputFormat(out string strFormat);
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
                        for (int k = 0; k < outputFormat; k++)
                            output[j] = "_" + output[j];
                    }
                    else if (Array[i] >= 0)
                    {
                        output[j] = AddSpaces(output[j], spaceSize * outputFormat);
                        output[j] = Array[i].ToString(strFormat) + output[j];
                    }
                    else
                    {
                        output[j] = AddSpaces(output[j], spaceSize * outputFormat - 1);
                        output[j] = Array[i].ToString(strFormat) + output[j];
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

        /// <summary>
        /// Находит число с наибольшей разрядностью и возвращает кол-во разрядов в качестве формата для вывода всех чисел
        /// </summary>
        /// <param name="strOutputFormat">Формат вывода для ToString()</param>
        /// <returns></returns>
        private int GetOutputFormat(out string strOutputFormat)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] < min && Array[i] != int.MinValue)
                    min = Array[i];
                if (Array[i] > max)
                    max = Array[i];
            }

            max = Math.Abs(max);
            min = Math.Abs(min);
            int formatSetter;

            if (max >= min)
                formatSetter = max;
            else
                formatSetter = min;


            int format = 0;
            while (formatSetter >= 1)
            {
                formatSetter /= 10;
                format++;
            }

            //Минимальный формат вывода. Устанавливается, чтобы не происходило "слипания" чисел из-за знака минус при format = 1 на самом нижнем уровне.
            //Проверено опытным путём.
            if (format == 1)
            {
                strOutputFormat = "D2";
                return 2;
            }
            else
            {
                strOutputFormat = "D" + format;
                return format;
            }
        }

        /// <summary>
        /// Добавляет указанное кол-во пробелов к строке с левой стороны
        /// </summary>
        /// <param name="str">Строка, к которой нужно добавить пробелы</param>
        /// <param name="nSpaces">Кол-во пробелов</param>
        /// <returns></returns>
        private string AddSpaces(string str, int nSpaces)
        {
            for (int i = 0; i < nSpaces; i++)
            {
                str = ' ' + str;
            }

            return str;
        }

        /// <summary>
        /// Запись бинарного дерева в массив
        /// </summary>
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

        /// <summary>
        /// Вывод массива бинарного дерева в консоль
        /// </summary>
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

        /// <summary>
        /// Возвращает глубину бинарного дерева
        /// </summary>
        /// <returns></returns>
        private int GetDepth()
        {
            int depth = 0;
            CalculateDepth(Head, ref depth, 0);
            return depth;
        }

        /// <summary>
        /// Рассчитывает глубину бинарного дерева
        /// </summary>
        /// <param name="currentNode">Текущий узел дерева</param>
        /// <param name="depth">Глубина дерева</param>
        /// <param name="currentDepth">Текущее рассчитанное значение глубины</param>
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

        /// <summary>
        /// Возвращает узел дерева с значением указанной величины
        /// </summary>
        /// <param name="value">Значение величины</param>
        /// <returns></returns>
        public BinaryTreeNode GetNodeByValue(int value)
        {
            BinaryTreeNode currentNode = Head;
            return GetNodeByValue(Head, value);
        }

        /// <summary>
        /// Ищет и возвращает узел дерева с значением указанной величины
        /// </summary>
        /// <param name="currentNode">Текущий узел</param>
        /// <param name="value">Значение величины</param>
        /// <returns></returns>
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

        /// <summary>
        /// Добавляет узел с указанной величиной значения и формирует массив бинарного дерева
        /// </summary>
        /// <param name="value">Значение величины</param>
        public void AddNode(int value)
        {
            Insert(value);
            TreeToArray();
        }

        /// <summary>
        /// Добавляет узел с указанной величиной значения
        /// </summary>
        /// <param name="value">Значение величины</param>
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
                    Console.WriteLine("Элемент " + value + " не добален: Такой элемент уже присутствует.");
                    return;
                }
            }
        }
    }
}
