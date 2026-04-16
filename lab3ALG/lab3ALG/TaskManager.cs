using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab3ALG
{
    public class TaskManager
    {
        private MemoryManager memoryManager;
        public TaskManager(MemoryManager mm)
        {
            memoryManager = mm;
        }
        private int ReadInt()
        {
            int res;
            string str = Console.ReadLine();
            while (!int.TryParse(str, out res) || res <= 0)
            {
                Console.WriteLine("Error, write correct size!");
                Console.WriteLine("Input n: ");
                str = Console.ReadLine();
            }
            return res;
        }
        private Pointer GenerateArrayWithNull(int n)
        {
            Random random = new Random();
            Pointer arrayPtr = memoryManager.NewPointer(typeof(int), n);
            if (arrayPtr.IsNull)
            {
                Console.WriteLine("Couldn't allocate memory for the array");
                return arrayPtr;
            }
            for(int i = 0; i<n; i++)
            {
                Pointer elPtr = new Pointer
                (
                    arrayPtr.SegmentIndex,
                    arrayPtr.Address + i * sizeof(int),
                    false,
                    typeof(int),
                    sizeof(int)
                );
                memoryManager.WritePointer(elPtr, random.Next(-10, 11));
            }
            int zeroPos = random.Next(0, n);
            Pointer zeroPtr = new Pointer
            (
                arrayPtr.SegmentIndex,
                arrayPtr.Address + zeroPos * sizeof(int),
                false,
                typeof(int),
                sizeof(int)
            );
            memoryManager.WritePointer(zeroPtr, 0);
            return arrayPtr;
        }
        private Pointer GenerateArrayWithoutNull(int n)
        {
            Random random = new Random();
            Pointer arrayPtr = memoryManager.NewPointer(typeof(int), n);
            if (arrayPtr.IsNull)
            {
                Console.WriteLine("Couldn't allocate memory for the array");
                return arrayPtr;
            }
            int value, i = 0;
            while (i < n) { 
                value = random.Next(-10, 11);
                if (value != 0)
                {
                    Pointer elPtr = new Pointer
                    (
                        arrayPtr.SegmentIndex,
                        arrayPtr.Address + i * sizeof(int),
                        false,
                        typeof(int),
                        sizeof(int)
                        );
                    memoryManager.WritePointer(elPtr, value);
                    i++;
                }                
            }
            return arrayPtr;
        }
        private int ReadArrayElement(Pointer arrayPtr, int index)
        {
            Pointer elPtr = new Pointer
            (
                arrayPtr.SegmentIndex,
                arrayPtr.Address  +index * sizeof(int),
                false,
                typeof(int),
                sizeof(int)
            );
            return memoryManager.ReadPointerInt(elPtr);
        }
        private void PrintArray(Pointer ptr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int value = ReadArrayElement(ptr, i);
                Console.Write(value);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        private void Task1()
        {
            Console.WriteLine("Input size n: ");
            int n = ReadInt();
            Pointer arrPtr = GenerateArrayWithoutNull(n);
            if (arrPtr.IsNull)
            {
                return ;
            }
            PrintArray(arrPtr, n);
            if(n<2)
            {
                Console.WriteLine(0);
                memoryManager.FreePointer(ref arrPtr);
                return;
            }
            int prev = ReadArrayElement(arrPtr, 0);
            for(int i = 1; i<n; i++)
            {
                int cur = ReadArrayElement(arrPtr, i);
                if ((prev >0 && cur>0)|| (prev<0 && cur < 0)){
                    Console.WriteLine(i);
                    memoryManager.FreePointer(ref arrPtr);
                    return;
                }
                prev = cur;
            }
            Console.WriteLine(0);
            memoryManager.FreePointer(ref arrPtr);
        }
        private void Task2()
        {
            Console.WriteLine("Input size n: ");
            int n = ReadInt();
            Pointer arrPtr = GenerateArrayWithNull(n);
            if (arrPtr.IsNull)
            {
                return;
            }
            PrintArray(arrPtr, n);
            int sum = 0;
            bool flag = false; 
            for(int i = 0; i<n; i++)
            {
                int value = ReadArrayElement(arrPtr, i);
                if (value == 0) flag = true;
                if (flag)
                {
                    sum += Math.Abs(value);
                }
            }
            Console.WriteLine(sum);
            memoryManager.FreePointer(ref arrPtr);

        }
        private void DemonstrateLeak()
        {
            Pointer ptr = memoryManager.NewPointer(typeof(int));
            memoryManager.WritePointer(ptr, 200326);
            Console.WriteLine($"{ memoryManager.ReadPointerInt(ptr)}, { ptr.Address}");
            ptr = memoryManager.NewPointer(typeof(int));
            memoryManager.WritePointer(ptr, 123456);
            Console.WriteLine($"{memoryManager.ReadPointerInt(ptr)}, {ptr.Address}");
            memoryManager.FreePointer(ref ptr);
        }
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Input 1 or 2 for run task, \"dl\" for demonstration leak, \"e\" for exit");
                string ch = Console.ReadLine();
                switch (ch)
                {
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    case "dl":
                        DemonstrateLeak();
                        break;
                    case "e":
                        Console.WriteLine("Bye");
                        return;
                    default:
                        Console.WriteLine("Incorrect choiсe");
                        break;
                }
            }
        }
    }
}
