using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon1
{
    public static class ArrayExtensions
    {
        static void HoareSortRecursion(int[] array, int start, int end)
        {
            if (end == start) return;
            var pivot = array[end];
            var storeIndex = start;
            for (int i = start; i <= end - 1; i++)
                if (array[i] <= pivot)
                {
                    var t = array[i];
                    array[i] = array[storeIndex];
                    array[storeIndex] = t;
                    storeIndex++;
                }
            var n = array[storeIndex];
            array[storeIndex] = array[end];
            array[end] = n;
            if (storeIndex > start) HoareSortRecursion(array, start, storeIndex - 1);
            if (storeIndex < end) HoareSortRecursion(array, storeIndex + 1, end);
        }

        public static void HoareSort(this int[] array)
        {
            HoareSortRecursion(array, 0, array.Length - 1);
        }

        public static int LinearSearch(this int[] array, int element)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == element) 
                    return i;
            return -1;
        }

        public static int[] SearchUnique(this int[] array)
        {
            //return array.Distinct().Count();
            int[] uniArr = new int[array.Length];
            bool unique = true;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < uniArr.Length; j++)
                {
                    if (array[i] == uniArr[j])
                        unique = false;
                }
                if (unique)
                    uniArr[i] = array[i];
                unique = true;
            }
            return uniArr;
        }


    }
}
