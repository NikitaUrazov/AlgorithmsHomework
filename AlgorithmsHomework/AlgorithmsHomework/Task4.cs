using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace AlgorithmsHomework
{
    class Task4
    {
        double Minimum { get; } = -10;
        double Maximum { get; } = 10;

        public struct PointStructDouble
        {
            public double X;
            public double Y;
        }


        public void ShowResult()
        {
            PointClassDouble[] arrayClass100000 = GetPointClassArray(100000);
            PointClassDouble[] arrayClass200000 = GetPointClassArray(200000);

            PointStructDouble[] arrayStruct100000 = GetPointStructArray(100000);
            PointStructDouble[] arrayStruct200000 = GetPointStructArray(200000);

            double[] distances;

            Console.Write("Массив 100 000 классов. Затраченное время: ");
            DateTime begining = DateTime.Now;
            distances = GetDistanceToAll(arrayClass100000[0], arrayClass100000);
            DateTime end = DateTime.Now;
            distances = GetDistanceToAll(arrayStruct100000[0], arrayStruct100000);

            distances = GetDistanceToAll(arrayClass200000[0], arrayClass200000);
            distances = GetDistanceToAll(arrayStruct200000[0], arrayStruct200000);




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
            Random random = new Random();
            return random.NextDouble() * (Maximum - Minimum) + Minimum;
        }
    }
}
