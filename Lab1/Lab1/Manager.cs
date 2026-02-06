using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lab1
{
    internal class Manager
    {
        private SetAnalyzer _setAnalyzer = new SetAnalyzer();

        public void Start()
        {
            string? ans;
            while (true)
            {
                Console.WriteLine("Choose number (1/2) or \"e\" to exit");
                ans = Console.ReadLine();
                switch (ans)
                {
                    case "1":
                        FirstTask();
                        break;
                    case "2":
                        SecondTask();
                        break;
                    case "e":
                        return;
                    default:
                        Console.WriteLine("Choose right point");
                        break;
                }
            }
        }
        private void FirstTask() {
            Console.WriteLine("Enter letter: ");
            string? let = Console.ReadLine();
            _setAnalyzer.CheckLetter(let);
        }
        private void SecondTask()
        {
            Console.WriteLine("Enter string: ");
            string? str = Console.ReadLine();
            _setAnalyzer.FindSequence(str);
        }
    }
}
