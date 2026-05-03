using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class SortedSearchResult
    {
        public int Size { get; set; }
        public double LinearAvgComparisons { get; set; }
        public double LinearAvgTime { get; set; }
        public double BinaryAvgComparisons { get; set; }
        public double BinaryAvgTime { get; set; }
    }
}
