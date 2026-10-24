#include <iostream>
#include <fstream>
#include <map>
#include <vector>
#include <string>
using namespace std;

int main() {
    ifstream file("oceny.txt");
    if (!file.is_open()) {
        cout << "Nie mozna otworzyc pliku oceny.txt" << endl;
        return 1;
    }

    map<string, vector<int>> oceny;
    string name;
    int grade;

    while (file >> name >> grade) {
        oceny[name].push_back(grade);
    }

    file.close();

    for (const auto& pair : oceny) {
        const string& student = pair.first;
        const vector<int>& grades = pair.second;

        double sum = 0;
        for (int g : grades) sum += g;

        double avg = sum / grades.size();

        cout << student << " - srednia ocen: " << avg << endl;
    }

    return 0;
}
