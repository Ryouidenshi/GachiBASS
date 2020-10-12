using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon1
{
    public class Program
    {
        //static Random random = new Random();

        //static int LinearSearch(int[] array, int element)
        //{
        //    for (int i = 0; i < array.Length; i++)
        //        if (array[i] == element) return i;
        //    return -1;
        //}

        //static int SearchUnique(int[] array, int element)
        //{
        //    return array.Distinct().Count();
        //}

        //static int[] GenerateSortedArray(int length)
        //{
        //    var array = new int[length];
        //    for (int i = 1; i < array.Length; i++)
        //        array[i] = array[i - 1] + random.Next(10000) + 1;
        //    return array;
        //}

        //static int SortedArray(int[] array, int element)
        //{
        //    Array.Sort(array);
        //    return 0;
        //}

        //static long MeasureTime(int[] array, Func<int[], int, int> searchProcedure)
        //{
        //    var watch = new Stopwatch();
        //    watch.Start();
        //    searchProcedure(array, array[random.Next(array.Length)]);
        //    watch.Stop();
        //    return watch.ElapsedMilliseconds;
        //}

        //static void Main()
        //{
        //    int[] array = GenerateSortedArray(100000);
        //    long linSearch = MeasureTime(array, LinearSearch);
        //    long searchUnique = MeasureTime(array, SearchUnique);
        //    long sortedArray = MeasureTime(array, SortedArray);
        //    Console.WriteLine("Количество элиментов в массиве - "+ array.Count() +" Линейный поиск - " + linSearch);
        //    Console.WriteLine("Количество элиментов в массиве - " + array.Count() + " Поиск уникальных слов - " + searchUnique);
        //    Console.WriteLine("Количество элиментов в массиве - " + array.Count() + " Сортировка Массива - " + sortedArray);
        //    Console.ReadKey();
        //}

        static void Main()
        {
            ConsoleView.Show();
        }
    }
}

