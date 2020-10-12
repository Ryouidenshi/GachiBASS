using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon1
{
    public class ConsoleView
    {
        public static void Show()
        {
            Random rnd = new Random();
            int[] arrayLengths = new int[]
            {
                100000,
                200000,
                300000,
                500000,
                600000,
                700000,
                800000,
                900000,
                1000000,
                1100000,
                1200000,
                1300000,
                1400000,
                1500000,
                2000000,
                5000000,
                10000000
            };

            foreach (int i in arrayLengths)
            {
                Console.WriteLine("Длина массива - " + i);

                int[] array = ArrayGenerator.GenerateArray(i);
                Console.WriteLine("Быстрая сортировка " + ", время выполнения - " +
                    ActionTimeMeasurer.Measure(new Action(() =>
                    array.HoareSort())));

                array = ArrayGenerator.GenerateArray(i);
                Console.WriteLine("Линейный пожилой поиск " + ", время выполнения - " +
                    ActionTimeMeasurer.Measure(new Action(() =>
                    array.LinearSearch(rnd.Next(10000)))));

                array = ArrayGenerator.GenerateArray(i);
                Console.WriteLine("Поиск уникального элемента " + ", время выполнения - " +
                    ActionTimeMeasurer.Measure(new Action(() =>
                    array.SearchUnique())));

                GC.Collect();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

