using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Lab1
{
    internal class SetAnalyzer
    {
        private HashSet<char> _rusAlphabet = new HashSet<char>("ё");
        private HashSet<char> _engAlphabet = new ();
        private HashSet<char> _sequence = new HashSet<char>("+-*/^%!<>=");

        public SetAnalyzer()
        {
            for (int i = 1072; i <= 1103; i++)
            {
                _rusAlphabet.Add(Convert.ToChar(i));
            }
            for (int i = 97; i <= 122; i++)
            {
                _engAlphabet.Add(Convert.ToChar(i));
            }
            for (int i = 69;  i <=78; i++)
            {
                _sequence.Add(Convert.ToChar(i));
            }
        }
        public void CheckLetter(string? letter)
        {
            if (letter == null || letter.Length != 1)
            {
                Console.WriteLine("Please input only 1 symbol");
                return;
            }
            if(_engAlphabet.Contains(Convert.ToChar(letter.ToLower()))) Console.WriteLine($"The letter \"{letter}\" is english letter");
            else if (_rusAlphabet.Contains(Convert.ToChar(letter.ToLower()))) Console.WriteLine($"The letter \"{letter}\" is russian letter");
            else Console.WriteLine($"The symbol \"{letter}\" is not letter from rus/eng alphabet");
        }

        public void FindSequence(string? seq)
        {
            if (String.IsNullOrEmpty(seq))
            {
                Console.WriteLine("The string must be not null");
                return;
            }
            HashSet<char>? result = new();
            foreach (char c in seq)
            {
                if(_sequence.Contains(c)) result.Add(c);
            }


            if (result.Count == 0)
            {
                Console.WriteLine("Result set is empty");
                return;
            }
            foreach(char c in result)
            {
                Console.Write(c);
            }
            Console.WriteLine(  );
            Console.WriteLine("Size of set "+result.Count);
        }
    }
}
