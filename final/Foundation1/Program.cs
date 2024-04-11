using System;
using System.Collections.Generic;

namespace VideoComments
{
    class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }
        public List<Comment> Comments { get; set; }

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        public int GetNumComments()
        {
            return Comments.Count;
        }
    }

    class Comment
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            Video v1 = new Video("Introduction to C#", "Bad bunny", 300);
            v1.Comments.Add(new Comment("Alice", "Great video!"));
            v1.Comments.Add(new Comment("Bob", "Thanks for the tutorial!"));
            v1.Comments.Add(new Comment("Charlie", "Very helpful, thanks!"));
            videos.Add(v1);

            Video v2 = new Video("C# OOP Concepts", "Wisin", 450);
            v2.Comments.Add(new Comment("Dalila", "Nice explanation of OOP!"));
            v2.Comments.Add(new Comment("Evanlice", "Very informative, thanks!"));
            videos.Add(v2);

            Video v3 = new Video("Debugging Tips in C#", "Mike Johnson", 200);
            v3.Comments.Add(new Comment("Frank", "This saved me a lot of time!"));
            videos.Add(v3);

            foreach (Video v in videos)
            {
                Console.WriteLine("Title: " + v.Title);
                Console.WriteLine("Author: " + v.Author);
                Console.WriteLine("Length: " + v.Length + " seconds");
                Console.WriteLine("Number of comments: " + v.GetNumComments());
                Console.WriteLine("Comments:");

                foreach (Comment c in v.Comments)
                {
                    Console.WriteLine("- " + c.Name + ": " + c.Text);
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
