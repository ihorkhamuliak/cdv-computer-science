#include <iostream>
using namespace std;

int main() {
    double LG, SG;  
    double podstawowe, dodatkowe, PL;
    double roczne, stawka, podatek, netto;

    // Wprowadzanie danych
    cout << "Podaj liczbe godzin (LG): ";
    cin >> LG;

    cout << "Podaj stawke godzinowa (SG): ";
    cin >> SG;

    // Obliczanie wynagrodzenia podstawowego
    if (LG > 40) {
        podstawowe = 40 * SG;
    } else {
        podstawowe = LG * SG;
    }

    // Obliczanie wynagrodzenia dodatkowego (nadgodziny)
    if (LG > 40) {
        dodatkowe = (LG - 40) * SG * 2;
    } else {
        dodatkowe = 0;
    }

    // Wynagrodzenie tygodniowe
    PL = podstawowe + dodatkowe;

    // Roczne wynagrodzenie
    roczne = PL * 52;

    // Ustalenie stawki podatkowej
    if (roczne <= 20000) {
        stawka = 0.19;
    }
    else if (roczne <= 30000) {
        stawka = 0.21;
    }
    else {
        stawka = 0.28;
    }

    // Podatek
    podatek = roczne * stawka;

    // Wynagrodzenie netto
    netto = roczne - podatek;

    // Wynik
    cout << "\n===== WYNIKI =====\n";
    cout << "Podstawowe: " << podstawowe << endl;
    cout << "Dodatkowe: " << dodatkowe << endl;
    cout << "PL (tygodniowe): " << PL << endl;
    cout << "Roczne wynagrodzenie: " << roczne << endl;
    cout << "Stawka podatkowa: " << stawka * 100 << "%" << endl;
    cout << "Podatek: " << podatek << endl;
    cout << "Netto: " << netto << endl;

    return 0;
}