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
            Console.WriteLine();
            Console.Write("Введите номер задания: ");
            input = Console.ReadLine();

            if (int.TryParse(input, out taskNumber))
            {
                switch (taskNumber)
                {
                    default:
                        Console.WriteLine("Задание отстутсвует");
                        break;
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
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
    }
}
