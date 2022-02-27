using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Diagnostics;

namespace AlgorithmsHomework
{
    class Task4 : ITask
    {
        double Minimum { get; } = -10;
        double Maximum { get; } = 10;

        Random Random { get; set; }

        public int TaskID => 4;

        public string TaskName => "4) Рассчёт расстояния между точками с использованием классов и структур, сравнение затраченного времени.";

        public struct PointStructDouble
        {
            public double X;
            public double Y;
        }

        public Task4()
        {
            Random = new Random();
        }


        public void ShowResult()
        {
            Stopwatch timer = new Stopwatch();

            Console.WriteLine("Формирование массивов...");
            timer.Start();
            PointClassDouble[] arrayClass100000 = GetPointClassArray(100000);
            PointClassDouble[] arrayClass200000 = GetPointClassArray(200000);

            PointStructDouble[] arrayStruct100000 = GetPointStructArray(100000);
            PointStructDouble[] arrayStruct200000 = GetPointStructArray(200000);
            timer.Stop();
            TimeSpan t0 = timer.Elapsed;
            timer.Reset();
            Console.WriteLine("Затраченное время: " + t0.TotalSeconds + " секунд.");
            Console.WriteLine();

            double[] distances;

            timer.Start();
            distances = GetDistanceToAll(arrayClass100000[0], arrayClass100000);
            timer.Stop();
            TimeSpan t1_Class = timer.Elapsed;
            timer.Reset();
            timer.Start();
            distances = GetDistanceToAll(arrayStruct100000[0], arrayStruct100000);
            timer.Stop();
            TimeSpan t1_Struct = timer.Elapsed;
            timer.Reset();
            timer.Start();
            distances = GetDistanceToAll(arrayClass200000[0], arrayClass200000);
            timer.Stop();
            TimeSpan t2_Class = timer.Elapsed;
            timer.Reset();
            timer.Start();
            distances = GetDistanceToAll(arrayStruct200000[0], arrayStruct200000);
            timer.Stop();
            TimeSpan t2_Struct = timer.Elapsed;
            timer.Reset();

            Console.WriteLine("Кол-во точек | Время работы со структурами, x | Время работы с классами, y | Отношение y/x :");
            Console.WriteLine();
            Console.WriteLine($"100 000 | {t1_Struct.TotalMilliseconds} мс | {t1_Class.TotalMilliseconds} мс | {GetRatio(t1_Struct, t1_Class)}");
            Console.WriteLine($"200 000 | {t2_Struct.TotalMilliseconds} мс | {t2_Class.TotalMilliseconds} мс | {GetRatio(t2_Struct, t2_Class)}");
        }

        public double GetRatio(TimeSpan x, TimeSpan y)
        {
            string x_str = "" + x.TotalMilliseconds;
            string y_str = "" + y.TotalMilliseconds;

            double x_double = double.Parse(x_str);
            double y_double = double.Parse(y_str);

            return y_double / x_double;
        }

        /// <summary>
        /// Возвращает массив расстояний от точки до всех остальных.
        /// </summary>
        /// <param name="point">Точка, от которой считаем расстояния.</param>
        /// <param name="arrayOfPoints">Массив точек.</param>
        /// <returns></returns>
        public double[] GetDistanceToAll(PointClassDouble point, PointClassDouble[] arrayOfPoints)
        {
            double[] distances = new double[arrayOfPoints.Length];
            for (int i = 0; i < arrayOfPoints.Length; i++)
            {
                distances[i] = GetDistance(point, arrayOfPoints[i]);
            }

            return distances;
        }

        /// <summary>
        /// Возвращает массив расстояний от точки до всех остальных.
        /// </summary>
        /// <param name="point">Точка, от которой считаем расстояния.</param>
        /// <param name="arrayOfPoints">>Массив точек.</param>
        /// <returns></returns>
        public double[] GetDistanceToAll(PointStructDouble point, PointStructDouble[] arrayOfPoints)
        {
            double[] distances = new double[arrayOfPoints.Length];
            for (int i = 0; i < arrayOfPoints.Length; i++)
            {
                distances[i] = GetDistance(point, arrayOfPoints[i]);
            }

            return distances;
        }

        /// <summary>
        /// Возвращает расстояние между двумя точками.
        /// </summary>
        /// <param name="pointOne"></param>
        /// <param name="pointTwo"></param>
        /// <returns></returns>
        public double GetDistance(PointClassDouble pointOne, PointClassDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// Возвращает расстояние между двумя точками.
        /// </summary>
        /// <param name="pointOne"></param>
        /// <param name="pointTwo"></param>
        /// <returns></returns>
        public double GetDistance(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// Формирует и возвращает массив точек-струткур.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public PointStructDouble[] GetPointStructArray(int length)
        {
            PointStructDouble[] array = new PointStructDouble[length];

            for (int i = 0; i < array.Length; i++)
            {
                array[i].X = GetRandomNumber();
                array[i].Y = GetRandomNumber();
            }

            return array;
        }

        /// <summary>
        /// Формирует и возвращает массив точек-классов.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public PointClassDouble[] GetPointClassArray(int length)
        {
            PointClassDouble[] array = new PointClassDouble[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new PointClassDouble();
                array[i].X = GetRandomNumber();
                array[i].Y = GetRandomNumber();
            }

            return array;
        }

        public double GetRandomNumber()
        {
            return Random.NextDouble() * (Maximum - Minimum) + Minimum;
        }
    }
}
