using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3ALG
{
    public struct MemorySegment
    {
        public byte[] Data;
        public int Size;
        public bool[] IsUsed;
        public MemorySegment(int size)
        {
            Size = size;
            Data = new byte[size];
            IsUsed = new bool[size];
        }
    }
}
