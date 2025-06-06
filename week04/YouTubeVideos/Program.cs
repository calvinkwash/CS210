using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Learning C# Basics", "TechTalk", 300);
        video1.AddComment(new Comment("Alice", "Very helpful video!"));
        video1.AddComment(new Comment("Bob", "Loved the explanation."));
        video1.AddComment(new Comment("Carol", "Great content!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Top 10 Travel Destinations", "Wanderlust", 480);
        video2.AddComment(new Comment("Dave", "I want to go now!"));
        video2.AddComment(new Comment("Emma", "Beautiful places."));
        video2.AddComment(new Comment("Frank", "Adding to my bucket list."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("How to Bake a Cake", "BakingDaily", 600);
        video3.AddComment(new Comment("Grace", "Yummy!"));
        video3.AddComment(new Comment("Henry", "Tried this at home."));
        video3.AddComment(new Comment("Ivy", "More baking tips please!"));
        videos.Add(video3);

        // Display video info
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine();
        }
    }
}
