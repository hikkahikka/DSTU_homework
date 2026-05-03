using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Sort
{
    public class TablePrinter
    {
        public static void CreateBarrierGraphHtml(BarrierSearchResult[] results, string filePath = "barrier_graph.html")
        {
            try
            {
                List<string> sizeStrings = new List<string>();

                List<string> noBarAvgTimeStrings = new List<string>();
                List<string> barAvgTimeStrings = new List<string>();

                List<string> noBarBestTimeStrings = new List<string>();
                List<string> barBestTimeStrings = new List<string>();

                List<string> noBarWorstTimeStrings = new List<string>();
                List<string> barWorstTimeStrings = new List<string>();

                List<string> noBarCompStrings = new List<string>();
                List<string> barCompStrings = new List<string>();

                foreach (var r in results)
                {
                    sizeStrings.Add(r.Size.ToString());

                    noBarAvgTimeStrings.Add(r.AvgTimeNoBarrier.ToString(System.Globalization.CultureInfo.InvariantCulture));
                    barAvgTimeStrings.Add(r.AvgTimeBarrier.ToString(System.Globalization.CultureInfo.InvariantCulture));

                    noBarBestTimeStrings.Add(r.BestTimeNoBarrier.ToString(System.Globalization.CultureInfo.InvariantCulture));
                    barBestTimeStrings.Add(r.BestTimeBarrier.ToString(System.Globalization.CultureInfo.InvariantCulture));

                    noBarWorstTimeStrings.Add(r.WorstTimeNoBarrier.ToString(System.Globalization.CultureInfo.InvariantCulture));
                    barWorstTimeStrings.Add(r.WorstTimeBarrier.ToString(System.Globalization.CultureInfo.InvariantCulture));

                    noBarCompStrings.Add(r.AvgComparisonsNoBarrier.ToString(System.Globalization.CultureInfo.InvariantCulture));
                    barCompStrings.Add(r.AvgComparisonsBarrier.ToString(System.Globalization.CultureInfo.InvariantCulture));
                }

                string sizes = string.Join(",", sizeStrings);

                string noBarAvgTimes = string.Join(",", noBarAvgTimeStrings);
                string barAvgTimes = string.Join(",", barAvgTimeStrings);

                string noBarBestTimes = string.Join(",", noBarBestTimeStrings);
                string barBestTimes = string.Join(",", barBestTimeStrings);

                string noBarWorstTimes = string.Join(",", noBarWorstTimeStrings);
                string barWorstTimes = string.Join(",", barWorstTimeStrings);

                string noBarComps = string.Join(",", noBarCompStrings);
                string barComps = string.Join(",", barCompStrings);

                var sb = new StringBuilder();

                sb.AppendLine("<!DOCTYPE html><html><head><meta charset='UTF-8'>");
                sb.AppendLine("<title>Barrier Search Comparison</title>");
                sb.AppendLine("<script src='https://cdn.plot.ly/plotly-latest.min.js'></script>");
                sb.AppendLine("<style>body { font-family: Arial, sans-serif; margin: 20px; } .plot { width: 1000px; height: 600px; margin-bottom: 40px; }</style>");
                sb.AppendLine("</head><body>");
                sb.AppendLine("<h2>Linear Search: With Barrier vs Without Barrier</h2>");
                sb.AppendLine("<div id='avgTimePlot' class='plot'></div>");
                sb.AppendLine("<div id='bestWorstTimePlot' class='plot'></div>");
                sb.AppendLine("<div id='comparisonPlot' class='plot'></div>");
                sb.AppendLine("<script>");

                sb.AppendLine($@"
            var noBarAvgTime = {{
                x: [{sizes}],
                y: [{noBarAvgTimes}],
                mode: 'lines+markers',
                name: 'Without Barrier Average Time',
                line: {{color: 'red', width: 2}},
                marker: {{size: 8}}
            }};

            var barAvgTime = {{
                x: [{sizes}],
                y: [{barAvgTimes}],
                mode: 'lines+markers',
                name: 'With Barrier Average Time',
                line: {{color: 'blue', width: 2}},
                marker: {{size: 8}}
            }};

            var noBarBestTime = {{
                x: [{sizes}],
                y: [{noBarBestTimes}],
                mode: 'lines+markers',
                name: 'Without Barrier Best Time',
                line: {{color: 'green', width: 2}},
                marker: {{size: 8}}
            }};

            var barBestTime = {{
                x: [{sizes}],
                y: [{barBestTimes}],
                mode: 'lines+markers',
                name: 'With Barrier Best Time',
                line: {{color: 'orange', width: 2}},
                marker: {{size: 8}}
            }};

            var noBarWorstTime = {{
                x: [{sizes}],
                y: [{noBarWorstTimes}],
                mode: 'lines+markers',
                name: 'Without Barrier Worst Time',
                line: {{color: 'purple', width: 2}},
                marker: {{size: 8}}
            }};

            var barWorstTime = {{
                x: [{sizes}],
                y: [{barWorstTimes}],
                mode: 'lines+markers',
                name: 'With Barrier Worst Time',
                line: {{color: 'brown', width: 2}},
                marker: {{size: 8}}
            }};

            var noBarComparisons = {{
                x: [{sizes}],
                y: [{noBarComps}],
                mode: 'lines+markers',
                name: 'Without Barrier Comparisons',
                line: {{color: 'red', width: 2}},
                marker: {{size: 8}}
            }};

            var barComparisons = {{
                x: [{sizes}],
                y: [{barComps}],
                mode: 'lines+markers',
                name: 'With Barrier Comparisons',
                line: {{color: 'blue', width: 2}},
                marker: {{size: 8}}
            }};

            var avgTimeLayout = {{
                title: 'Average Search Time',
                xaxis: {{ title: 'Array Size' }},
                yaxis: {{ title: 'Average Time, microseconds' }},
                hovermode: 'closest'
            }};

            var bestWorstTimeLayout = {{
                title: 'Best and Worst Search Time',
                xaxis: {{ title: 'Array Size' }},
                yaxis: {{ title: 'Time, microseconds' }},
                hovermode: 'closest'
            }};

            var comparisonLayout = {{
                title: 'Average Number of Comparisons',
                xaxis: {{ title: 'Array Size' }},
                yaxis: {{ title: 'Average Comparisons' }},
                hovermode: 'closest'
            }};

            Plotly.newPlot('avgTimePlot', [noBarAvgTime, barAvgTime], avgTimeLayout);
            Plotly.newPlot('bestWorstTimePlot', [noBarBestTime, barBestTime, noBarWorstTime, barWorstTime], bestWorstTimeLayout);
            Plotly.newPlot('comparisonPlot', [noBarComparisons, barComparisons], comparisonLayout);
        ");

                sb.AppendLine("</script></body></html>");

                File.WriteAllText(filePath, sb.ToString());
                Console.WriteLine($"HTML graph saved to: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating HTML graph: {ex.Message}");
            }
        }
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

            sb.AppendLine(
                $"{"Size",-8}" +
                $"{"Lin_Found_Comp",-17}" +
                $"{"Lin_Found_Time",-17}" +
                $"{"Bin_Found_Comp",-17}" +
                $"{"Bin_Found_Time",-17}" +
                $"{"Lin_Miss_Comp",-16}" +
                $"{"Lin_Miss_Time",-16}" +
                $"{"Bin_Miss_Comp",-16}" +
                $"{"Bin_Miss_Time",-16}");

            foreach (var r in results)
            {
                sb.AppendLine(
                    $"{r.Size,-8}" +
                    $"{r.LinearFoundAvgComparisons,-17:F2}" +
                    $"{r.LinearFoundAvgTime,-17:F2}" +
                    $"{r.BinaryFoundAvgComparisons,-17:F2}" +
                    $"{r.BinaryFoundAvgTime,-17:F2}" +
                    $"{r.LinearMissingAvgComparisons,-16:F2}" +
                    $"{r.LinearMissingAvgTime,-16:F2}" +
                    $"{r.BinaryMissingAvgComparisons,-16:F2}" +
                    $"{r.BinaryMissingAvgTime,-16:F2}");
            }

            sb.AppendLine();
            return sb.ToString();
        }
    }
}