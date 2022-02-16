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
            Console.WriteLine("4) Рассчёт расстояния между точками с использованием классов и структур, сравнение затраченного времени.");
            Console.WriteLine("5) Дерево.");
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
                    case 4:
                        Task4();
                        break;
                    case 5:
                        Task5();
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
            Task1 task1 = new Task1();

            task1.GetNumber();
            if (task1.IsNumberCorrect())
                task1.ShowResult();
        }

        static void Task2()
        {
            Task2 task2 = new Task2();
            task2.GetNumber();
            if (task2.IsNumberCorrect())
                task2.ShowResult();
        }

        static void Task3()
        {
            Task3 task3 = new Task3();
            task3.ShowResult();
        }

        static void Task4()
        {
            // Третье дз пока отсутствует.
        }

        static void Task5()
        {
            Task5 task5 = new Task5();
            task5.ShowResult();
        }
    }
}
