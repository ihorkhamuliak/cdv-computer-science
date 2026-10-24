//Khamuliak Ihor
#include <iostream>
#include <vector>

using namespace std;

int main() {
    int ilosc_wierszy, ilosc_kolumn;
    int wiersz, kolumna, suma, wartosc;
    
    vector<vector<int>> tablica; 

    cout << "Wprowadz ilosc wierszy w tablicy: ";
    cin >> ilosc_wierszy;
    
    cout << "Wprowadz ilosc kolumn w tablicy: ";
    cin >> ilosc_kolumn;

    tablica.resize(ilosc_wierszy, vector<int>(ilosc_kolumn));

    wiersz = 1;
    kolumna = 1;
    suma = 0;

    while (wiersz <= ilosc_wierszy) {
        
        while (kolumna <= ilosc_kolumn) {
            cout << "Wprowadz wartosc dla kolumny: ";
            cout << kolumna << endl;
            cout << "w wierszu: ";
            cout << wiersz << endl;
            cin >> wartosc;

            tablica[wiersz - 1][kolumna - 1] = wartosc;
            suma = suma + wartosc;
            
            kolumna = kolumna + 1;
        }

        wiersz = wiersz + 1;
        kolumna = 1;
    }

    cout << "zawartosc tablicy: ";
    cout << "(";
    for (int i = 0; i < ilosc_wierszy; i++) {
        cout << "(";
        for (int j = 0; j < ilosc_kolumn; j++) {
            cout << tablica[i][j];
            if (j < ilosc_kolumn - 1) cout << ",";
        }
        cout << ")";
        if (i < ilosc_wierszy - 1) cout << ",";
    }
    cout << ")" << endl;

    cout << "Suma wszystkich elementow: ";
    cout << suma << endl;

    cout << "Wybierz element do wyswietlania, kolumna: ";
    cin >> kolumna; 
    cout << "Wiersz: "; 
    cin >> wiersz;  
    
    cout << tablica[wiersz - 1][kolumna - 1] << endl;

    cout << "\n--- Analiza algorytmu ---" << endl;
    cout << "ilosc_wierszy: " << ilosc_wierszy << endl;
    cout << "ilosc_kolumn:  " << ilosc_kolumn << endl;
    
    cout << "tablica:       (";
    for (int i = 0; i < ilosc_wierszy; i++) {
        cout << "(";
        for (int j = 0; j < ilosc_kolumn; j++) {
            cout << tablica[i][j];
            if (j < ilosc_kolumn - 1) cout << ",";
        }
        cout << ")";
        if (i < ilosc_wierszy - 1) cout << ",";
    }
    cout << ")" << endl;

    cout << "wiersz:        " << wiersz << endl;
    cout << "kolumna:       " << kolumna << endl;
    cout << "suma:          " << suma << endl;
    cout << "wartosc:       " << wartosc << endl;

    return 0;
}