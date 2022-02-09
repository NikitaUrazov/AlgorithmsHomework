using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHomework
{
    class Task1
    {
        public int Number { get; set; }

        public string Input { get; set; }

        public void ShowResult()
        {
            if (IsSimple(Number))
                Console.WriteLine("Простое.");
            else
                Console.WriteLine("Не простое.");
        }

        public void GetNumber()
        {
            Console.Write("Введите число: ");
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
                Console.WriteLine("Неккоректный ввод.");
                return false;
            }

            return true;
        }

        public bool IsSimple(int number)
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
    }
}
