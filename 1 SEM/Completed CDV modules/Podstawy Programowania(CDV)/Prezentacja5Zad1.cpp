#include <iostream>
#include <fstream>
#include <vector>
#include <map>
#include <string>

using namespace std;

int main() {
    ifstream file("tekst.txt");
    if (!file.is_open()) {
        cout << "Nie można otworzyć pliku tekst.txt" << endl;
        return 1;
    }

    vector<string> words;
    string word;

    while (file >> word) {
        words.push_back(word);
    }

    file.close();

    map<string, int> occurrences;
    for (const auto& w : words) {
        occurrences[w]++;
    }

    for (const auto& pair : occurrences) {
        cout << pair.first << " => " << pair.second << endl;
    }

    return 0;
}
