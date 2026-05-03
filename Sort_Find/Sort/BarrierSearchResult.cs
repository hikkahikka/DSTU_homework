using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class BarrierSearchResult
    {
        public int Size { get; set; }
        public double AvgComparisonsNoBarrier { get; set; }
        public double AvgTimeNoBarrier { get; set; }
        public double BestTimeNoBarrier { get; set; }
        public double WorstTimeNoBarrier { get; set; }
        public double AvgComparisonsBarrier { get; set; }
        public double AvgTimeBarrier { get; set; }
        public double BestTimeBarrier { get; set; }
        public double WorstTimeBarrier { get; set; }
    }
}
