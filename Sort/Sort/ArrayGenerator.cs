using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class ArrayGenerator
    {
        private static Random rand = new Random();

        public static int[] RandomArray(int size)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(0, 100000);
            }
            return arr;
        }

        public static int[] SortedArray(int size)
        {
            int[] arr = RandomArray(size);
            Array.Sort(arr);
            return arr;
        }

        public static int[] ReversedArray(int size)
        {
            int[] arr = SortedArray(size);
            Array.Reverse(arr);
            return arr;
        }
        public static int[] PartiallySortedArray(int size, int percent)
        {
            int[] arr = SortedArray(size);
            int split = size * percent / 100;
            for (int i = split; i < size; i++)
                arr[i] = rand.Next(0, 10000);
            return arr;
        }
        public static int[] Copy(int[] source)
        {
            int[] copy = new int[source.Length];
            Array.Copy(source, copy, source.Length);
            return copy;
        }
    }
}
