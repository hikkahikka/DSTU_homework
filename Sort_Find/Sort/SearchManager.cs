using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class SearchManager
    {
        public static SearchMetrics LinearSearch(int[] array, int key)
        {
            var met = new SearchMetrics();
            int n = array.Length;

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
            {
                met.Comparisons++;
                if (array[i] == key)
                    break;
            }
            sw.Stop();

            met.Time= sw.Elapsed;
            return met;
        }

        public static SearchMetrics LinearSearchWithBarrier(int[] array, int key)
        {
            var met = new SearchMetrics();
            int n = array.Length;
            int[] arr = new int[n + 1];
            Array.Copy(array, arr, n);
            arr[n] = key;

            Stopwatch sw = Stopwatch.StartNew();
            int i = 0;
            while (true)
            {
                met.Comparisons++;
                if (arr[i] == key)
                    break;
                i++;
            }
            sw.Stop();

            met.Time = sw.Elapsed;
            return met;
        }

        public static SearchMetrics BinarySearch(int[] sortedArray, int key)
        {
            var met = new SearchMetrics();
            int left = 0;
            int right = sortedArray.Length - 1;

            Stopwatch sw = Stopwatch.StartNew();

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                met.Comparisons++;
                if (sortedArray[mid] == key)
                {
                    sw.Stop();
                    met.Time = sw.Elapsed;
                    return met;
                }

                met.Comparisons++;
                if (sortedArray[mid] < key)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            sw.Stop();
            met.Time = sw.Elapsed;
            return met;
        }
    }
}
