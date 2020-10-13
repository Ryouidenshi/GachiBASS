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
            while (true)
            {
                Console.WriteLine("Введите количество элементов в массиве - ");
                var num = int.Parse(Console.ReadLine());
                if (num==0)
                    break;
                Console.WriteLine("-------------------------------------");
                int[] array = GenerateSortedArray(num);
                long fastSortOwn = MeasureTime(array, FastSortOwn);
                long fastSortFromLibrary = MeasureTime(array, FastSortFromLibrary);
                long searchUniqueElementsOwn = MeasureTime(array, SearchUniqueElementsOwn);
                long searchUniqueElementsFromLibrary = MeasureTime(array, SearchUniqueElementsFromLibrary);
                Console.WriteLine("Быстрый поиск собственной реализации - " + fastSortOwn);
                Console.WriteLine("Быстрый поиск готовой реализации - " + fastSortFromLibrary);
                Console.WriteLine("Поиск уникальных слов собственной реализации - " + searchUniqueElementsOwn);
                Console.WriteLine("Поиск уникальных слов готовой реализации - " + searchUniqueElementsFromLibrary);
                Console.WriteLine("-------------------------------------");
            }
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
            //pizdec
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
