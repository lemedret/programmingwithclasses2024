#include <iostream>
#include <vector>
#include <fstream>

using namespace std;

// THIS IS THE BASE FOR ALL THE GOLS.
class Goal {
protected:
    string name;
    bool completed;

public:
    Goal(string n) : name(n), completed(false) {}
    virtual ~Goal() {}

    virtual void markComplete() = 0;
    virtual int calculatePoints() const = 0;
    virtual string getType() const = 0;

    void display() const {
        cout << "Goal: " << name << " [" << (completed ? "X" : " ") << "]" << endl;
    }

    bool isCompleted() const {
        return completed;
    }

    string getName() const {
        return name;
    }
};

// SIMPE ONE
class SimpleGoal : public Goal {
    int points;

public:
    SimpleGoal(string n, int p) : Goal(n), points(p) {}

    void markComplete() override {
        completed = true;
    }

    int calculatePoints() const override {
        return completed ? points : 0;
    }

    string getType() const override {
        return "Simple";
    }
};

// ETERNAL
class EternalGoal : public Goal {
    int points;

public:
    EternalGoal(string n, int p) : Goal(n), points(p) {}

    void markComplete() override {
        // Always remain incomplete
    }

    int calculatePoints() const override {
        return points;
    }

    string getType() const override {
        return "Eternal";
    }
};

// CHESKLIST CHECKLIST
class ChecklistGoal : public Goal {
    int requiredTimes;
    int currentTimes;
    int pointsPerCompletion;
    int bonusPoints;

public:
    ChecklistGoal(string n, int required, int pointsPer, int bonus)
        : Goal(n), requiredTimes(required), pointsPerCompletion(pointsPer), bonusPoints(bonus), currentTimes(0) {}

    void markComplete() override {
        if (currentTimes < requiredTimes) {
            currentTimes++;
            if (currentTimes == requiredTimes)
                completed = true;
        }
    }

    int calculatePoints() const override {
        int totalPoints = currentTimes * pointsPerCompletion;
        if (completed)
            totalPoints += bonusPoints;
        return totalPoints;
    }

    string getType() const override {
        return "Checklist";
    }

    void display() const {
        cout << "Goal: " << name << " [" << (completed ? "X" : " ") << "] Completed " << currentTimes << "/" << requiredTimes << " times" << endl;
    }
};

// Class to manage goals and user's score
class EternalQuest {
private:
    vector<Goal*> goals;
    int score;

public:
    EternalQuest() : score(0) {}

    ~EternalQuest() {
        for (auto goal : goals)
            delete goal;
    }

    void addGoal(Goal* goal) {
        goals.push_back(goal);
    }

    void recordEvent(int index) {
        if (index >= 0 && index < goals.size()) {
            goals[index]->markComplete();
            score += goals[index]->calculatePoints();
        }
    }

    void displayGoals() const {
        for (size_t i = 0; i < goals.size(); ++i) {
            cout << i+1 << ". ";
            goals[i]->display();
        }
    }

    void displayScore() const {
        cout << "Total Score: " << score << endl;
    }

    void saveToFile(const string& filename) const {
        ofstream file(filename);
        if (file.is_open()) {
            for (auto goal : goals) {
                file << goal->getName() << "," << goal->getType() << "," << goal->isCompleted() << endl;
            }
            file << "Score," << score << endl;
            file.close();
        } else {
            cout << "Unable to save to file." << endl;
        }
    }

    void loadFromFile(const string& filename) {
        ifstream file(filename);
        if (file.is_open()) {
            string line;
            while (getline(file, line)) {
                size_t pos = line.find(",");
                if (pos != string::npos) {
                    string name = line.substr(0, pos);
                    string type = line.substr(pos + 1, line.find(",", pos + 1) - pos - 1);
                    bool completed = stoi(line.substr(line.find(",", pos + 1) + 1));
                    Goal* goal;
                    if (type == "Simple") {
                        goal = new SimpleGoal(name, 100); 
                    } else if (type == "Eternal") {
                        goal = new EternalGoal(name, 50); 
                    } else if (type == "Checklist") {
                        goal = new ChecklistGoal(name, 5, 30, 300); 
                    }
                    goal->markComplete(); // PARAMETERSe
                    goals.push_back(goal);
                }
            }
            // SCORING
            if (getline(file, line)) {
                size_t pos = line.find(",");
                if (pos != string::npos) {
                    score = stoi(line.substr(pos + 1));
                }
            }
            file.close();
        } else {
            cout << "Unable to open file." << endl;
        }
    }
};

int main() {
   
