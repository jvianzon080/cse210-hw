using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; set; } = new List<Comment>();

    public void AddComment(string commenter, string text)
    {
        Comments.Add(new Comment { Commenter = commenter, Text = text });
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.Commenter}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

public class Comment
{
    public string Commenter { get; set; }
    public string Text { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var videos = new List<Video>();

        var video1 = new Video
        {
            Title = "Van Life: Davao City",
            Author = "Joseph Ezra Vianzon",
            LengthInSeconds = 600
        };
        video1.AddComment("Armel", "Great video!");
        video1.AddComment("Zaera", "I learned a lot, thanks!");

        var video2 = new Video
        {
            Title = "Van Life: Surigao City",
            Author = "Joseph Ezra Vianzon",
            LengthInSeconds = 900
        };
        video2.AddComment("Ezra", "Very entertaining!");

        videos.Add(video1);
        videos.Add(video2);

        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}
