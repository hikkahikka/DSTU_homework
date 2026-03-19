using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3ALG
{
    public struct Pointer
    {
        public int SegmentIndex;
        public int Address;
        public bool IsNull;
        public Type? DataType;
        public int BlockSize;
        public Pointer()
        {
            IsNull = true;
            BlockSize = 0;
        }
        public Pointer(int segInd, int address, bool isNull, Type type, int blockSize)
        {
            SegmentIndex = segInd;
            Address = address;
            IsNull = isNull;
            DataType = type;
            BlockSize = blockSize;
        }
    }
}
