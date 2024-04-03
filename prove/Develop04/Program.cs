#include <iostream>
#include <cstdlib>
#include <ctime>
#include <unistd.h>

using namespace std;


class Activity {
protected:
    int duration; // this would be for the duration 

public:
    Activity(int dur) : duration(dur) {}

    // START1!!!using void
    void startMessage(string activityName, string description) {
        cout << "Welcome to the " << activityName << " activity!" << endl;
        cout << description << endl;
        cout << "Set duration for this activity (in seconds): " << duration << endl;
        cout << "Prepare to begin..." << endl;
        sleep(3); // Pause for 3 seconds
    }

    // Common ending message for all activities
    void endMessage(string activityName) {
        cout << "Congratulations! You have completed the " << activityName << " activity." << endl;
        cout << "Duration: " << duration << " seconds" << endl;
        sleep(3); // Pause for 3 seconds
    }
};

// Remenbering loops from phyton xd
class BreathingActivity : public Activity {
public:
    BreathingActivity(int dur) : Activity(dur) {}

    void performActivity() {
        startMessage("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");

        // Loop for breathing in and out
        for (int i = 0; i < duration; ++i) {
            if (i % 2 == 0)
                cout << "Breathe in..." << endl;
            else
                cout << "Breathe out..." << endl;
            sleep(1); // Pause for 1 second
        }

        endMessage("Breathing Activity");
    }
};

// Do not know wht is hihluthed in red :(
class ReflectionActivity : public Activity {
private:
    string prompts[4] = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    string questions[9] = {
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

public:
    ReflectionActivity(int dur) : Activity(dur) {}

    void performActivity() {
        startMessage("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        // Select a random prompt
        int randIndex = rand() % 4;
        cout << prompts[randIndex] << endl;
        sleep(3); // Pause for 3 seconds

        // Display reflection questions
        for (int i = 0; i < duration; ++i) {
            cout << "Reflection Question " << i+1 << ": " << questions[rand() % 9] << endl;
            sleep(3); // Pause for 3 seconds
        }

        endMessage("Reflection Activity");
    }
};

// Listing activity class
class ListingActivity : public Activity {
private:
    string prompts[5] = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

public:
    ListingActivity(int dur) : Activity(dur) {}

    void performActivity() {
        startMessage("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        // Select a random prompt
        int randIndex = rand() % 5;
        cout << prompts[randIndex] << endl;
        sleep(3); // Pause for 3 seconds

        // Countdown to begin listing
        cout << "Get ready to list..." << endl;
        for (int i = 3; i > 0; --i) {
            cout << i << "...";
            sleep(1); // Pause for 1 second
        }
        cout << "Go!" << endl;

        // User lists items for the specified duration
        cout << "List as many items as you can..." << endl;
        sleep(duration); // Pause for the specified duration

        cout << "
