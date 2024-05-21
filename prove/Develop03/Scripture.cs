using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private List<Word> words;
    public ScriptureReference Reference { get; private set; }

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count)
    {
        var random = new Random();
        var wordsToHide = words.Where(w => !w.IsHidden).OrderBy(w => random.Next()).Take(count).ToList();
        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(w => w.IsHidden);
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(string.Join(" ", words));
        Console.WriteLine();
        Console.WriteLine(Reference);
    }
}
