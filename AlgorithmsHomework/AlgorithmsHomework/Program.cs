using System;
using System.Reflection;
using System.Collections.Generic;

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
            Assembly asm = Assembly.LoadFrom("..\\..\\..\\..\\TasksLibrary\\obj\\Debug\\netstandard2.0\\TasksLibrary.dll");
            Type[] types = asm.GetTypes();

            List<object> menu = new List<object>();

            foreach (Type type in types)
                if (type.GetInterface("ITask") != null)
                    menu.Add(Activator.CreateInstance(type));

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
