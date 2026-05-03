using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class SortManager
    {
        public static SortMetrics InsertionSort(int[] array)
        {
            var met = new SortMetrics();
            Stopwatch stopwatch = Stopwatch.StartNew();
            int n = array.Length;

            for (int i =1; i<n; i++)
            {
                met.Iterations++;
                int key = array[i]; //neuporadoch el
                int j = i - 1; //index pered i

                while (j >= 0)
                {
                    met.Comparisons++;
                    met.Iterations++;

                    if (array[j] > key)
                    {
                        array[j + 1] = array[j];
                        met.Swaps++;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }

                array[j + 1] = key;
                //met.Swaps++;

            }

            stopwatch.Stop();
            met.Time = stopwatch.Elapsed;

            return met;
        }

        public static SortMetrics SelectionSort(int[] array)
        {
            var met = new SortMetrics();
            Stopwatch stopwatch = Stopwatch.StartNew();
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                met.Iterations++;
                int minInd = i;
                int min = array[i];

                for (int j = i + 1; j < n; j++)
                {
                    met.Comparisons++;
                    met.Iterations++;

                    if (array[j] < min)
                    {
                        min = array[j];
                        minInd = j;
                    }
                }

                if (minInd != i)
                {
                    met.Swaps++;
                    array[minInd] = array[i];
                    array[i] = min;
                }
            }

            stopwatch.Stop();
            met.Time = stopwatch.Elapsed;
            return met;
        }

        public static SortMetrics BubbleSort(int[] array)
        {
            var met = new SortMetrics();
            Stopwatch stopwatch = Stopwatch.StartNew();
            int n = array.Length;

            for(int i = n-1; i>0; i--)
            {
                for (int j = 0; j<i; j++)
                {
                    met.Iterations ++;
                    met.Comparisons++;
                    if (array[j] > array[j + 1])
                    {
                        met.Swaps++;
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    }
                }
            }

            stopwatch.Stop();
            met.Time = stopwatch.Elapsed;
            return met;
        }

        public static SortMetrics QuickSort(int[] array)
        {
            var met = new SortMetrics();
            Stopwatch stopwatch = Stopwatch.StartNew();

            QuickSortRecursive(array, 0, array.Length - 1, met);

            stopwatch.Stop();
            met.Time = stopwatch.Elapsed;
            return met;
        }

        private static void QuickSortRecursive(int[] array, int l, int r, SortMetrics met)
        {
            if (l < r)
            {
                int pivotIndex = Partition(array, l, r, met);
                QuickSortRecursive(array, l, pivotIndex - 1, met);
                QuickSortRecursive(array, pivotIndex + 1, r, met);
            }
        }

        private static int Partition(int[] array, int l, int r, SortMetrics met)
        {
            int pivot = array[r];
            int i = l - 1;
            int temp;
            for (int j = l; j < r; j++)
            {
                met.Comparisons++;
                met.Iterations++;
                if (array[j] < pivot)
                {
                    i++;
                    temp = array[j];
                    array[j] = array[i];
                    array[i] = temp;
                    met.Swaps++;
                }
            }

            temp = array[i+1];
            array[i + 1] = array[r];
            array[r] = temp;
            met.Swaps++;

            return i + 1;
        }
        public static void SelectionSortForVariant22(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n; i += 2)
            {
                int minIdx = i;
                for (int j = i + 2; j < n; j += 2)
                {
                    if (array[j] < array[minIdx])
                        minIdx = j;
                }
                if (minIdx != i)
                    (array[i], array[minIdx]) = (array[minIdx], array[i]);
            }

            for (int i = 1; i < n; i += 2)
            {
                int maxIdx = i;
                for (int j = i + 2; j < n; j += 2)
                {
                    if (array[j] > array[maxIdx])
                        maxIdx = j;
                }
                if (maxIdx != i)
                    (array[i], array[maxIdx]) = (array[maxIdx], array[i]);
            }
        }
    }
}
