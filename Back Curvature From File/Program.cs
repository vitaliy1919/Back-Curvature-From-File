using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace KDTEST1
{



    class Program
    {
        private static void AlternativeTest()
        {
            List<List<Tuple<double, double>>> points = new List<List<Tuple<double, double>>>();
            String curLine;
            int lineNumber = 1;
            using (StreamReader reader = new StreamReader("data_best_2.txt"))
            {
                points.Add(new List<Tuple<double, double>>());
                while ((curLine = reader.ReadLine())!=null)
                {
                    string[] textArray1 = curLine.Split(',');
                    double z = Convert.ToDouble(textArray1[0]);
                    double y = Convert.ToDouble(textArray1[1]);
                    if (Math.Abs((double)(z + 100.0)) < 1E-06)
                    {
                        points.Add(new List<Tuple<double, double>>());
                        continue;
                    }
                    points[points.Count - 1].Add(new Tuple<double, double>(z, y));
                    lineNumber++;
                }
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int adjacentPointNumber = 12;
            List<Tuple<Tuple<double, double>, double>> rotatesPoints = new List<Tuple<Tuple<double, double>, double>>();
            List<Tuple<double, double>> spinePoints = new List<Tuple<double, double>>();
            foreach (var row in points)
            {
                row.Sort();
                bool spinePointFound = false;
               
                for (int i = 0; i < row.Count; i++)
                {
                    int realAdjacentPointCount = 0;
                    double distanceMetrics = 0.0;
                    int num10 = 0;
                    for (int iter = 0; iter < (adjacentPointNumber / 2); iter++)
                    {
                        if (iter + i < row.Count)
                        {
                            distanceMetrics += Math.Abs((double)(row[i].Item1 - row[i + iter].Item1));
                            realAdjacentPointCount++;
                        }
                    }
                    double a = (14 * Math.PI) / 180.0;
                    double sin = Math.Sin(a);
                    double cos = Math.Cos(a);
                    var rotatedPoint = new Tuple<double, double>(
                            row[i].Item1 * cos + row[i].Item2 * sin,
                            -row[i].Item1 * sin + row[i].Item2 * cos);
                    double updatedMetrics = (realAdjacentPointCount == 0) ? 0.0 : (distanceMetrics / realAdjacentPointCount);
                    if (!spinePointFound && (updatedMetrics < 0.005))
                    {
                        spinePoints.Add(rotatedPoint);
                        spinePointFound = true;
                    }
                
                    rotatesPoints.Add(new Tuple<Tuple<double, double>, double>(rotatedPoint, updatedMetrics));
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Milliseconds: " + stopwatch.ElapsedMilliseconds);
            using (StreamWriter writer = new StreamWriter("writeNew.txt"))
            {
                foreach (var point in rotatesPoints)
                {
                    writer.WriteLine($"{point.Item1.Item1}, {point.Item1.Item2}, {point.Item2}");
                }
            }
            using (StreamWriter writer2 = new StreamWriter("writeNewFiltered.txt"))
            {
                foreach (var point in rotatesPoints)
                {
                    if (point.Item2 < 0.005)
                    {
                        writer2.WriteLine($"{point.Item1.Item1}, {point.Item1.Item2}, {point.Item2}");
                    }
                }
            }
            using (StreamWriter writer3 = new StreamWriter("spinePoints.txt"))
            {
                foreach (var tuple4 in spinePoints)
                {
                    writer3.WriteLine($"{tuple4.Item1}, {tuple4.Item2}");
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AlternativeTest();
        }
    }
}
