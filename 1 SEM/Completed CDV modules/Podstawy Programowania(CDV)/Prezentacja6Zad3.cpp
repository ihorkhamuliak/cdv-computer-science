#include <iostream>
#include <queue>
#include <string>
using namespace std;

int main() {
    queue<string> kolejkaKlientow;

    kolejkaKlientow.push("Anna");
    kolejkaKlientow.push("Piotr");
    kolejkaKlientow.push("Kuba");
    kolejkaKlientow.push("Ola");

    cout << "Symulacja obslugi klientow w sklepie:\n\n";

    while (!kolejkaKlientow.empty()) {
        cout << "Obslugiwany klient: " << kolejkaKlientow.front() << endl;
        kolejkaKlientow.pop();
    }

    cout << "\nWszyscy klienci zostali obsluzeni." << "\n";

    return 0;
}