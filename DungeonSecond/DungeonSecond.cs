using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace DungeonFirst
{
    class DungeonSecond
    {
        static void Main(string[] args)
        {
            int[] arrayLengths = new int[] { 10000, 50000, 100000 };
            foreach (int i in arrayLengths)
            {
                Console.WriteLine("Количество элементов в массиве - " + i);
                int[] array;
                int[] results;

                results = new int[100];
                for (int j = 0; j < 100; j++)
                {
                    array = GenerateArray(i);
                    results[j] = MeasureTime(array, FastSortOwn);
                }
                Console.WriteLine("Быстрый поиск собственной реализации (лучший случай) - " + results.Min());
                Console.WriteLine("Быстрый поиск собственной реализации (средний) - " + results.Average());
                Console.WriteLine("Быстрый поиск собственной реализации (худший) - " + results.Max());
                GC.Collect();

                results = new int[100];
                for (int j = 0; j < 100; j++)
                {
                    array = GenerateArray(i);
                    results[j] = MeasureTime(array, FastSortFromLibrary);
                }
                Console.WriteLine("Быстрый поиск готовой реализации (лучший случай) - " + results.Min());
                Console.WriteLine("Быстрый поиск готовой реализации (средний) - " + results.Average());
                Console.WriteLine("Быстрый поиск готовой реализации (худший) - " + results.Max());
                GC.Collect();

                results = new int[100];
                for (int j = 0; j < 100; j++)
                {
                    array = GenerateArray(i);
                    results[j] = MeasureTime(array, SearchUniqueElementsOwn);
                }
                Console.WriteLine("Поиск уникальных слов собственной реализации (лучший случай) - " + results.Min());
                Console.WriteLine("Поиск уникальных слов собственной реализации (средний) - " + results.Average());
                Console.WriteLine("Поиск уникальных слов собственной реализации (худший) - " + results.Max());
                GC.Collect();

                results = new int[100];
                for (int j = 0; j < 100; j++)
                {
                    array = GenerateArray(i);
                    results[j] = MeasureTime(array, SearchUniqueElementsFromLibrary);
                }
                Console.WriteLine("Поиск уникальных слов готовой реализации (лучший случай) - " + results.Min());
                Console.WriteLine("Поиск уникальных слов готовой реализации (средний) - " + results.Average());
                Console.WriteLine("Поиск уникальных слов готовой реализации (худший) - " + results.Max());
                GC.Collect();

                Console.WriteLine();
            }
            Console.ReadKey();
        }
        
        static int[] GenerateSortedArray(int length)
        {
            var array = new int[length];
            for (int i = 1; i < array.Length; i++)
                array[i] = array[i - 1] + random.Next(10000) + 1;
            return array;
        }

        static Random random = new Random();
        static long MeasureTime(int[] array, Func<int[],int[]> searchProcedure)
        {
            var watch = new Stopwatch();
            watch.Start();
            searchProcedure(array);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        static int[] FastSortOwn(int[] a)
        {
            int h;
            for (h = 1; h <= a.Length / 9; h = 3 * h + 1) ;
            for (; h > 0; h /= 3)
            {
                for (int i = h; i < a.Length; ++i)
                {
                    int t = a[i];
                    int j = i;
                    while (j >= h && a[j - h].CompareTo(t) > 0)
                    {
                        a[j] = a[j - h];
                        j -= h;
                    }
                    a[j] = t;
                }
            }
            return a;
        }

        static int[] FastSortFromLibrary(int[] a)
        {
            Array.Sort(a);
            return a;
        }

        static int[] SearchUniqueElementsOwn(int[] a)
        {
            int[] uniArr = new int[a.Length];
            bool unique = true;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < uniArr.Length; j++)
                {
                    if (a[i] == uniArr[j])
                        unique = false;
                }
                if (unique)
                    uniArr[i] = a[i];
                unique = true;
            }
            return uniArr;
        }

        static int[] SearchUniqueElementsFromLibrary(int[] a)
        {
            return a.Distinct().ToArray();
        }
    }
}
