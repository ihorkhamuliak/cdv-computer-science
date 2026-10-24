#include <iostream>
#include <vector>
#include <string>
using namespace std;

struct Gra {
    string nazwa;
    vector<int> oceny;

    double srednia() {
        if (oceny.empty()) return 0.0;

        double suma = 0;
        for (int o : oceny) {
            suma += o;
        }
        return suma / oceny.size();
    }

    void wypisz() {
        cout << "Gra: " << nazwa << endl;
        cout << "Oceny: ";
        for (int o : oceny) cout << o << " ";
        cout << endl;
        cout << "Srednia ocen: " << srednia() << endl;
        cout << "------------------------" << endl;
    }
};

int main() {

    Gra gra1 = {"Cyberpunk 2077", {7, 8, 9}};
    Gra gra2 = {"Minecraft", {10, 9, 10, 9}};
    Gra gra3 = {"GTA V", {9, 10, 8, 9}};

    gra1.wypisz();
    gra2.wypisz();
    gra3.wypisz();

    return 0;
}