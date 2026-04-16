using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
