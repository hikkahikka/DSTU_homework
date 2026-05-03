using System;
using System.Collections.Generic;
using System.Text;  

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

        public static void PrintBarrierComparisonTable(BarrierSearchResult[] results)
        {
            Console.Write(GetBarrierComparisonTableString(results));
        }

        public static string GetBarrierComparisonTableString(BarrierSearchResult[] results)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{"Size",-8}{"NoBar_AvgComp",-15}{"NoBar_AvgTime",-18}{"NoBar_Best",-15}{"NoBar_Worst",-16}" +
                $"{"Bar_AvgComp",-14}{"Bar_AvgTime",-17}{"Bar_Best",-14}{"Bar_Worst",-15}");
            foreach (var r in results)
            {
                sb.AppendLine(
                    $"{r.Size,-8}" +
                    $"{r.AvgComparisonsNoBarrier,-15:F2}" +
                    $"{r.AvgTimeNoBarrier,-18:F2}" +
                    $"{r.BestTimeNoBarrier,-15:F2}" +
                    $"{r.WorstTimeNoBarrier,-16:F2}" +
                    $"{r.AvgComparisonsBarrier,-14:F2}" +
                    $"{r.AvgTimeBarrier,-17:F2}" +
                    $"{r.BestTimeBarrier,-14:F2}" +
                    $"{r.WorstTimeBarrier,-15:F2}");
            }
            sb.AppendLine();
            return sb.ToString();
        }

        public static void PrintSortedSearchComparisonTable(SortedSearchResult[] results)
        {
            Console.Write(GetSortedSearchComparisonTableString(results));
        }

        public static string GetSortedSearchComparisonTableString(SortedSearchResult[] results)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{"Size",-8}{"Lin_AvgComp",-14}{"Lin_AvgTime",-17}{"Bin_AvgComp",-14}{"Bin_AvgTime",-16}");
            foreach (var r in results)
            {
                sb.AppendLine(
                    $"{r.Size,-8}" +
                    $"{r.LinearAvgComparisons,-14:F2}" +
                    $"{r.LinearAvgTime,-17:F2}" +
                    $"{r.BinaryAvgComparisons,-14:F2}" +
                    $"{r.BinaryAvgTime,-16:F2}");
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}