using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ')
                         .Select(word => new Word(word))
                         .ToList();
            _random = new Random();
        }

        public void HideRandomWords(int count = 3)
        {
            var visibleWords = _words.Where(w => !w.IsHidden).ToList();
            int wordsToHide = Math.Min(count, visibleWords.Count);

            for (int i = 0; i < wordsToHide; i++)
            {
                int index = _random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(_reference.ToString());
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplayText())));
        }

        public bool AllWordsHidden()
        {
            return _words.All(w => w.IsHidden);
        }
    }
}
