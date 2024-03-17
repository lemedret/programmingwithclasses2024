using System;
using System.Collections.Generic;

class Word
{
    public string Text { get; set; }
    public bool Hidden { get; set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }
}

class Reference
{
    public string Book { get; set; }
    public int Chapter { get; set; }
    public int VerseStart { get; set; }
    public int? VerseEnd { get; set; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verse;
        VerseEnd = null;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    public override string ToString()
    {
        if (VerseEnd == null)
        {
            return $"{Book} {Chapter}:{VerseStart}";
        }
        else
        {
            return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
        }
    }
}

class Scripture
{
    private List<Word> words = new List<Word>();
    private Reference reference;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        string[] splitText = text.Split(' ');
        foreach (string word in splitText)
        {
            words.Add(new Word(word));
        }
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        foreach (Word word in words)
        {
            if (!word.Hidden && random.Next(2) == 0)
            {
                word.Hidden = true;
            }
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in words)
        {
            if (!word.Hidden)
            {
                return false;
            }
        }
        return true;
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(reference);
        foreach (Word word in words)
        {
            if (word.Hidden)
            {
                Console.Write("***** ");
            }
            else
            {
                Console.Write(word.Text + " ");
            }
        }
        Console.WriteLine("\n\nPress Enter to continue or type 'quit' to exit.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Scripture scripture = new Scripture(reference, text);

        while (!scripture.AllWordsHidden())
        {
            scripture.Display();
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                return;
            }
            else
            {
                scripture.HideRandomWords();
            }
        }
        Console.WriteLine("All words are hidden. Press any key to exit.");
        Console.ReadKey();
    }
}
