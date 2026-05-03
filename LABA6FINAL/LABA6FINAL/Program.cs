using LABA6FINAL;
using System;

class Program
{
    static void Main()
    {
        int n = Program.ReadInt("Enter number of elements: ", 1, int.MaxValue);

        int[] source = new int[n];

        for (int i = 0; i < n; i++)
        {
            source[i] = Program.ReadInt($"Enter element {i}: ");
        }

        int p0 = Program.ReadInt("Enter P0 index: ", 0, n - 1);
        int k = Program.ReadInt("Enter K: ", 1, int.MaxValue);

        LinkedListStructure linkedList = new LinkedListStructure();

        for (int i = 0; i < n; i++)
        {
            linkedList.Add(source[i]);
        }

        Console.WriteLine("\nLinked list implementation:");
        Console.Write("Source list: ");
        linkedList.Print();

        linkedList.MoveForward(p0, k);
        Console.Write("After moving P0: ");
        linkedList.Print();

        linkedList.DeleteLessThanAverage();
        Console.Write("After deleting elements less than average: ");
        linkedList.Print();

        ArrayStructure arrayList = new ArrayStructure(n);

        for (int i = 0; i < n; i++)
        {
            arrayList.Add(source[i]);
        }

        Console.WriteLine("\nArray implementation:");
        Console.Write("Source list: ");
        arrayList.Print();

        arrayList.MoveForward(p0, k);
        Console.Write("After moving P0: ");
        arrayList.Print();

        arrayList.DeleteLessThanAverage();
        Console.Write("After deleting elements less than average: ");
        arrayList.Print();
    }
    private static int ReadInt(string message, int min = int.MinValue, int max = int.MaxValue)
    {
        while (true)
        {
            Console.Write(message);
            string text = Console.ReadLine();

            if (int.TryParse(text, out int value) && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine("Invalid input. Try again.");
        }
    }
}

