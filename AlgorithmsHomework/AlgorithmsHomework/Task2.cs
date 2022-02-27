using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHomework
{
    class Task2 : ITask
    {
        public int Number { get; set; }
        public string Input { get; set; }

        public int TaskID => 2;

        public string TaskName => "2) Реализуйте функцию вычисления числа Фибоначчи.";

        public void ShowResult()
        {
            GetNumber();
            if (!IsNumberCorrect())
                return;

            Console.WriteLine("Число Фибоначчи(" + Number + ") = " + GetFibonacciNumber(Number, 0, 1));
        }

        public void GetNumber()
        {
            Console.Write("Введите номер числа Фибоначчи, считая с нуля (0, 1, 2 и т.д.): ");
            Input = Console.ReadLine();
        }

        public bool IsNumberCorrect()
        {
            try
            {
                Number = int.Parse(Input);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Некорректный ввод.");
                return false;
            }

            if (Number < 0)
            {
                Console.WriteLine("Ошибка. Число меньше нуля.");
                return false;
            }

            return true;

        }

        public long GetFibonacciNumber(int number, int beforePrevious, int previous)
        {
            if (number == 0 && beforePrevious == 0 && previous == 1)
                return 0;
            else if (number == 1 && beforePrevious == 0 && previous == 1)
                return 1;
            else
            {
                if (number > 1)
                    return GetFibonacciNumber(number - 1, previous, beforePrevious + previous);
                else
                    return previous;
            }
        }
    }
}
