using System;
using System.Collections.Generic;

namespace Sort
{
    public class TablePrinter
    {
        
        public static void PrintSizeResearchTable(
            string methodName,
            int[] sizes,
            Dictionary<int, SortMetrics> metrics)
        {
            Console.WriteLine($"{methodName}");
            Console.WriteLine($"{"Size",-8}{"Comparisons",-16}{"Swaps",-16}{"Iterations",-16}{"Time (ms)",-12}");
            foreach (int size in sizes)
            {
                var m = metrics[size];
                Console.WriteLine(
                    $"{size,-8}" +
                    $"{m.Comparisons,-16}" +
                    $"{m.Swaps,-16}" +
                    $"{m.Iterations,-16}" +
                    $"{m.Time.TotalMilliseconds,-12:F3}");
            }
            Console.WriteLine();
        }

        public static void PrintOrderResearchTable(
            string[] states,
            SortMetrics[] insertion,
            SortMetrics[] selection,
            SortMetrics[] bubble,
            SortMetrics[] quick)
        {
            Console.WriteLine($"{"State",-14}{"Insertion",-20}{"Selection",-20}{"Bubble",-20}{"Quick",-20}");
            Console.WriteLine();

            for (int i = 0; i < states.Length; i++)
            {
                Console.Write($"{states[i],-14}");
                Console.Write($"{insertion[i].Swaps} / {insertion[i].Time.TotalMilliseconds:F2}".PadRight(20));
                Console.Write($"{selection[i].Swaps} / {selection[i].Time.TotalMilliseconds:F2}".PadRight(20));
                Console.Write($"{bubble[i].Swaps} / {bubble[i].Time.TotalMilliseconds:F2}".PadRight(20));
                Console.Write($"{quick[i].Swaps} / {quick[i].Time.TotalMilliseconds:F2}".PadRight(20));
                Console.WriteLine();
            }
        }
    }
}