using System;
using System.Collections.Generic;

namespace Final_Project
{
    public class Word
    {
        private string _word;
        private List<char> _letters = new List<char>();
        private int _index;
        private int _points = 5;
        private string[] lines = System.IO.File.ReadAllLines("WordBank.txt");

        public void NewWord()
        {
            _letters.Add('a');
            _letters.Clear();
            Random rng = new Random();
            _word = lines[rng.Next(0,lines.Length)];
            foreach(char i in _word)
            {
                _letters.Add(i);
            }
            _index = 0;
        }
        public int WordLength()
        {
            return _word.Length;
        }
        public char GetLetterIndex(int index)
        {
            return _letters[index];
        }
        public string GetWord()
        {
            return _word;
        }
        public char CurrentLetter()
        {
            return _letters[_index];
        }
        public void IncrementIndex()
        {
            _index++;
        }
        public int GetPoints()
        {
            return _points;
        }
    }

}