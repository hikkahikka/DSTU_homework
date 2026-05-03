using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;  // остаётся для File (раньше был для StreamWriter)

namespace Sort
{
    public class ProgramManager
    {
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Input \"tb\" to print sorts table");
                Console.WriteLine("Input \"st\" to print state table");
                Console.WriteLine("Input \"22\" to task or \"e\" to exit");
                Console.WriteLine("Inpun \"5.1\" to lab 5");
                Console.WriteLine("Inpun \"5.2\" to lab 5");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "tb":
                        RunAllSizeResearch();
                        break;
                    case "st":
                        RunOrderResearch();
                        break;
                    case "22":
                        RunVariant22();
                        break;
                    case "e":
                        return;
                    case "5.1":
                        RunBarrierResearch();
                        break;
                    case "5.2":
                        RunSortedSearchResearch();
                        break;
                    default:
                        Console.WriteLine("Error!");
                        break;
                }
            }
        }

        private void RunAllSizeResearch()
        {
            int[] researchSizes = { 20, 500, 1000, 3000, 5000, 10000 };

            var insertionMetrics = new Dictionary<int, SortMetrics>();
            var selectionMetrics = new Dictionary<int, SortMetrics>();
            var bubbleMetrics = new Dictionary<int, SortMetrics>();
            var quickMetrics = new Dictionary<int, SortMetrics>();

            foreach (int size in researchSizes)
            {
                int[] original = ArrayGenerator.RandomArray(size);

                int[] copyIns = ArrayGenerator.Copy(original);
                insertionMetrics[size] = SortManager.InsertionSort(copyIns);

                int[] copySel = ArrayGenerator.Copy(original);
                selectionMetrics[size] = SortManager.SelectionSort(copySel);

                int[] copyBub = ArrayGenerator.Copy(original);
                bubbleMetrics[size] = SortManager.BubbleSort(copyBub);

                int[] copyQuick = ArrayGenerator.Copy(original);
                quickMetrics[size] = SortManager.QuickSort(copyQuick);
            }

            TablePrinter.PrintSizeResearchTable("Insertion", researchSizes, insertionMetrics);
            TablePrinter.PrintSizeResearchTable("Selection", researchSizes, selectionMetrics);
            TablePrinter.PrintSizeResearchTable("Bubble", researchSizes, bubbleMetrics);
            TablePrinter.PrintSizeResearchTable("Quick", researchSizes, quickMetrics);
        }

        private void RunOrderResearch()
        {
            Console.Write("Input size N: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Incorrect size");
                return;
            }

            string[] states = { "Random", "Sorted", "Reversed", "25% sorted", "50% sorted", "75% sorted" };
            var insertionMetrics = new SortMetrics[states.Length];
            var selectionMetrics = new SortMetrics[states.Length];
            var bubbleMetrics = new SortMetrics[states.Length];
            var quickMetrics = new SortMetrics[states.Length];

            int[] randomArray = ArrayGenerator.RandomArray(n);
            int[] sortedArray = ArrayGenerator.SortedArray(n);
            int[] reversedArray = ArrayGenerator.ReversedArray(n);
            int[] part25 = ArrayGenerator.PartiallySortedArray(n, 25);
            int[] part50 = ArrayGenerator.PartiallySortedArray(n, 50);
            int[] part75 = ArrayGenerator.PartiallySortedArray(n, 75);

            int[][] stateArrays = { randomArray, sortedArray, reversedArray, part25, part50, part75 };

            for (int i = 0; i < states.Length; i++)
            {
                insertionMetrics[i] = SortManager.InsertionSort(ArrayGenerator.Copy(stateArrays[i]));
                selectionMetrics[i] = SortManager.SelectionSort(ArrayGenerator.Copy(stateArrays[i]));
                bubbleMetrics[i] = SortManager.BubbleSort(ArrayGenerator.Copy(stateArrays[i]));
                quickMetrics[i] = SortManager.QuickSort(ArrayGenerator.Copy(stateArrays[i]));
            }

            TablePrinter.PrintOrderResearchTable(states, insertionMetrics, selectionMetrics, bubbleMetrics, quickMetrics);
        }

        private void RunVariant22()
        {
            Console.WriteLine("Input 20 values");
            int[] arr = new int[20];
            for (int i = 0; i < 20; i++)
            {
                bool valid = false;
                while (!valid)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int value))
                    {
                        arr[i] = value;
                        valid = true;
                    }
                    else
                        Console.WriteLine("Error! Write integer value");
                }
            }
            Console.WriteLine("Before sort: ");
            PrintArray(arr);

            SortManager.SelectionSortForVariant22(arr);
            Console.WriteLine("After sort: ");

            PrintArray(arr);
        }

        private void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }

        private void RunBarrierResearch()
        {
            Random rand = new Random();
            int[] sizes = { 20, 500, 1000, 3000, 5000, 10000 };
            BarrierSearchResult[] results = new BarrierSearchResult[sizes.Length];

            for (int idx = 0; idx < sizes.Length; idx++)
            {
                int size = sizes[idx];
                int[] array = ArrayGenerator.RandomArray(size);

                int[] targets = new int[100];
                for (int i = 0; i < 100; i++)
                    targets[i] = array[rand.Next(size)];

                long totalCompNoBarrier = 0;
                double totalMicrosNoBarrier = 0;
                long totalCompBarrier = 0;
                double totalMicrosBarrier = 0;

                for (int i = 0; i < 100; i++)
                {
                    var m1 = SearchManager.LinearSearch(array, targets[i]);
                    totalCompNoBarrier += m1.Comparisons;
                    totalMicrosNoBarrier += m1.Time.TotalMilliseconds * 1000.0;

                    var m2 = SearchManager.LinearSearchWithBarrier(array, targets[i]);
                    totalCompBarrier += m2.Comparisons;
                    totalMicrosBarrier += m2.Time.TotalMilliseconds * 1000.0;
                }

                var bestNoBar = SearchManager.LinearSearch(array, array[0]);
                var worstNoBar = SearchManager.LinearSearch(array, int.MaxValue);
                var bestBar = SearchManager.LinearSearchWithBarrier(array, array[0]);
                var worstBar = SearchManager.LinearSearchWithBarrier(array, int.MaxValue);

                double avgCompNoBar = totalCompNoBarrier / 100.0;
                double avgTimeNoBar = totalMicrosNoBarrier / 100.0;
                double avgCompBar = totalCompBarrier / 100.0;
                double avgTimeBar = totalMicrosBarrier / 100.0;

                results[idx] = new BarrierSearchResult
                {
                    Size = size,
                    AvgComparisonsNoBarrier = avgCompNoBar,
                    AvgTimeNoBarrier = avgTimeNoBar,
                    BestTimeNoBarrier = bestNoBar.Time.TotalMilliseconds * 1000.0,
                    WorstTimeNoBarrier = worstNoBar.Time.TotalMilliseconds * 1000.0,
                    AvgComparisonsBarrier = avgCompBar,
                    AvgTimeBarrier = avgTimeBar,
                    BestTimeBarrier = bestBar.Time.TotalMilliseconds * 1000.0,
                    WorstTimeBarrier = worstBar.Time.TotalMilliseconds * 1000.0
                };
            }

            string tableText = TablePrinter.GetBarrierComparisonTableString(results);
            Console.Write(tableText);

            string filePath = "barrier_comparison.txt";
            File.WriteAllText(filePath, tableText);
            Console.WriteLine($"Data saved to {filePath}");
        }

        private void RunSortedSearchResearch()
        {
            Random rand = new Random();

            int[] sizes = { 20, 500, 1000, 3000, 5000, 10000 };
            SortedSearchResult[] results = new SortedSearchResult[sizes.Length];

            for (int idx = 0; idx < sizes.Length; idx++)
            {
                int size = sizes[idx];
                int[] sortedArray = ArrayGenerator.SortedArray(size);

                int[] targets = new int[100];
                for (int i = 0; i < 100; i++)
                {
                    if (rand.Next(2) == 0)
                        targets[i] = sortedArray[rand.Next(size)];
                    else
                        targets[i] = 100000 + rand.Next(0, 1000);
                }

                long totalCompLinear = 0;
                double totalMicrosLinear = 0;
                long totalCompBinary = 0;
                double totalMicrosBinary = 0;

                for (int i = 0; i < 100; i++)
                {
                    var mLin = SearchManager.LinearSearch(sortedArray, targets[i]);
                    totalCompLinear += mLin.Comparisons;
                    totalMicrosLinear += mLin.Time.TotalMilliseconds * 1000.0;

                    var mBin = SearchManager.BinarySearch(sortedArray, targets[i]);
                    totalCompBinary += mBin.Comparisons;
                    totalMicrosBinary += mBin.Time.TotalMilliseconds * 1000.0;
                }

                double avgCompLin = totalCompLinear / 100.0;
                double avgTimeLin = totalMicrosLinear / 100.0;
                double avgCompBin = totalCompBinary / 100.0;
                double avgTimeBin = totalMicrosBinary / 100.0;

                results[idx] = new SortedSearchResult
                {
                    Size = size,
                    LinearAvgComparisons = avgCompLin,
                    LinearAvgTime = avgTimeLin,
                    BinaryAvgComparisons = avgCompBin,
                    BinaryAvgTime = avgTimeBin
                };
            }

            string tableText = TablePrinter.GetSortedSearchComparisonTableString(results);
            Console.Write(tableText);

            string filePath = "sorted_search_comparison.txt";
            File.WriteAllText(filePath, tableText);
            Console.WriteLine($"Data saved to {filePath}");
        }
    }
}