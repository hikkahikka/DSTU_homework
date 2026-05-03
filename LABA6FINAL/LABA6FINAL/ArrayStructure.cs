using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA6FINAL
{

    class ArrayStructure
    {
        private int[] data;
        private int count;

        public ArrayStructure(int size)
        {
            data = new int[size];
            count = 0;
        }

        public void Add(int value)
        {
            data[count] = value;
            count++;
        }

        public void MoveForward(int index, int k)
        {
            int newIndex = index + k;

            if (newIndex >= count)
            {
                newIndex = count - 1;
            }

            if (newIndex == index)
            {
                return;
            }

            int value = data[index];

            for (int i = index; i < newIndex; i++)
            {
                data[i] = data[i + 1];
            }

            data[newIndex] = value;
        }

        public void DeleteLessThanAverage()
        {
            if (count == 0)
            {
                return;
            }

            int sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += data[i];
            }

            double average = (double)sum / count;
            int newCount = 0;

            for (int i = 0; i < count; i++)
            {
                if (data[i] >= average)
                {
                    data[newCount] = data[i];
                    newCount++;
                }
            }

            count = newCount;

            Console.WriteLine($"Average value: {average:F2}");
        }

        public void Print()
        {
            if (count == 0)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write(data[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
