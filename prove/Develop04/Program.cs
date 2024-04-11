using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    public abstract class Activity
    {
        protected string name;
        protected string description;
        protected int duration;

        public Activity(string name, string description, int duration)
        {
            this.name = name;
            this.description = description;
            this.duration = duration;
        }

        public abstract void Start();
    }

    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("BRETHING", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 10000)
        {
        }

        public override void Start()
        {
            // Show a welcome message
            Console.WriteLine("WELCOME TO THE BREATHING ACTIVITY!");
            Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

            // Prompt the user for the duration
            Console.WriteLine("How long would you like to do this activity?");
            int userDuration = Convert.ToInt32(Console.ReadLine());

            // Start the timer
            Timer timer = null;
            timer = new Timer(delegate
            {
                // Breathe in
                Console.WriteLine("Breathe in...");

                // Pause for a second
                Thread.Sleep(1000);

                // Breathe out
                Console.WriteLine("Breathe out...");

                // Decrement the timer
                userDuration--;

                // If the timer is not finished, continue breathing
                if (userDuration > 0)
                {
                    timer.Change(1000, Timeout.Infinite);
                }
                else
                {
                    // Finish the activity
                    Console.WriteLine("You just completed the Breathing Activity!");
                    timer.Dispose();
                }
            }, null, 0, Timeout.Infinite);
        }
    }

    public class ReflectionActivity : Activity
    {
        public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 10000)
        {
        }

        public override void Start()
        {
            // Show a welcome message
            Console.WriteLine("Welcome to the Reflection Activity!");
            Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

            // Get a list of questions
            var questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };

            // Start the timer
            Timer timer = null;
            timer = new Timer(delegate
            {
                // Ask a question
                var random = new Random();
                Console.WriteLine(questions[random.Next(questions.Count)]);

                // Pause for a second
                Thread.Sleep(1000);

                // Decrement the timer
                duration--;

                // If the timer is not finished, continue asking questions
                if (duration > 0)
                {
                    timer.Change(1000, Timeout.Infinite);
                }
                else
                {
                    // Finish the activity
                    Console.WriteLine("You have completed the Reflection Activity!");
                    timer.Dispose();
                }
            }, null, 0, Timeout.Infinite);
        }
    }

    public class Program
    {
        public static void Main()
        {
            Activity breathingActivity = new BreathingActivity();
            breathingActivity.Start();

            Activity reflectionActivity = new ReflectionActivity();
            reflectionActivity.Start();

            // Other activities can be added here...

            Console.ReadLine();
        }
    }
}
