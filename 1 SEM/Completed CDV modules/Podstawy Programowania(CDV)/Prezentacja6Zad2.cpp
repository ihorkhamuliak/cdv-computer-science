#include <iostream>
#include <stack>
#include <string>
using namespace std;

int main() {
    string tekst;

    cout << "Podaj tekst: ";
    getline(cin, tekst);

    stack<char> stos;

    for (char c : tekst) {
        stos.push(c);
    }
    
    string odwrocony = "";
    while (!stos.empty()) {
        odwrocony += stos.top();
        stos.pop();
    }

    cout << "Odwrocony tekst: " << odwrocony << endl;

    return 0;
}