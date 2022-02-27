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
            ITask[] menu =
            {
                new Task1(),
                new Task2(),
                new Task3(),
                new Task4(),
                new Task5(),
                new Task6()
            };

            foreach (ITask task in menu)
                Console.WriteLine(task.TaskName);

            Console.WriteLine();
            Console.Write("Введите номер задания: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int taskId))
            {
                foreach (ITask task in menu)
                    if (taskId == task.TaskID)
                    {
                        task.ShowResult();
                        return;
                    }
                Console.WriteLine("Такого задания нет.");
            }
            else
            {
                Console.WriteLine("Неккоректный ввод.");
            }
        }
    }
}
