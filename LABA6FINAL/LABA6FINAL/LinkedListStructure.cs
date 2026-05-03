using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA6FINAL
{
    class LinkedListStructure
    {
        private Node head;

        public void Add(int value)
        {
            Node node = new Node(value);

            if (head == null)
            {
                head = node;
                return;
            }

            Node current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = node;
        }

        public void MoveForward(int index, int k)
        {
            Node previous = null;
            Node target = head;

            for (int i = 0; i < index; i++)
            {
                previous = target;
                target = target.Next;
            }

            Node destination = target;

            for (int i = 0; i < k && destination.Next != null; i++)
            {
                destination = destination.Next;
            }

            if (destination == target)
            {
                return;
            }

            if (previous == null)
            {
                head = target.Next;
            }
            else
            {
                previous.Next = target.Next;
            }

            target.Next = destination.Next;
            destination.Next = target;
        }

        public void DeleteLessThanAverage()
        {
            if (head == null)
            {
                return;
            }

            int sum = 0;
            int count = 0;
            Node current = head;

            while (current != null)
            {
                sum += current.Value;
                count++;
                current = current.Next;
            }

            double average = (double)sum / count;

            while (head != null && head.Value < average)
            {
                head = head.Next;
            }

            current = head;

            while (current != null && current.Next != null)
            {
                if (current.Next.Value < average)
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }

            Console.WriteLine($"Average value: {average:F2}");
        }

        public void Print()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            Node current = head;

            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }

            Console.WriteLine();
        }
    }

}
