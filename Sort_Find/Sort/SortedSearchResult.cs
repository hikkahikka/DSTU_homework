namespace Sort
{
    public class SortedSearchResult
    {
        public int Size { get; set; }

        public double LinearFoundAvgComparisons { get; set; }
        public double LinearFoundAvgTime { get; set; }
        public double BinaryFoundAvgComparisons { get; set; }
        public double BinaryFoundAvgTime { get; set; }

        public double LinearMissingAvgComparisons { get; set; }
        public double LinearMissingAvgTime { get; set; }
        public double BinaryMissingAvgComparisons { get; set; }
        public double BinaryMissingAvgTime { get; set; }
    }
}