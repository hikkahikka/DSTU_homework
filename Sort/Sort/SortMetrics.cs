using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public  class SortMetrics
    {
        public long Iterations { get; set; }
        public long Comparisons { get; set; }
        public long Swaps { get; set; }
        public TimeSpan Time {  get; set; }

        //public override string ToString()=>$"Iter. - {Iterations}, Comp. - {Comparisons}, Swaps - {Swaps}, Time - {Time.TotalMilliseconds:F2}";
        
    }
}
