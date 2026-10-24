//Ihor Khamuliak
#include <iostream>
#include <vector>

using namespace std;

int main()
{
    vector<vector<int>> tab;
    int szuk, kol, wiersz, k_max, w_max, w_start;

    cout << "Podaj liczbe jaką szukasz: ";
    cin >> szuk;

    cout << "Podaj pierwszą kategorie szukania: ";
    cin >> kol;

    cout << "Podaj wiersz: ";
    cin >> wiersz;

    cout << "Podaj drugą kategorie szukania: ";
    cin >> k_max;

    cout << "Podaj drugi Wiersz: ";
    cin >> w_max;

    tab = {
        {5, 7, 13, 22},
        {88, 100, 3, 2},
        {33, 7, 2, 3},
        {7, 3, 15, 2}
    };

    w_start = wiersz;

    while (kol <= k_max) {

        while (wiersz <= w_max) {

            if (tab[wiersz - 1][kol - 1] == szuk) {

                cout << "KOM" << endl;
                cout << wiersz << endl;
                cout << kol << endl;
                cout << "Zawiera w sobie wskazane liczbe" << endl;
                cout << szuk << endl;
                
                wiersz = wiersz + 1;
            } 
            else {
                wiersz = wiersz + 1;
            }
        }

        kol = kol + 1;
        wiersz = w_start;
    }

    cout << "\n===============================" << endl;
    cout << "       Analiza algorytmu       " << endl;
    cout << "===============================" << endl;
    cout << "szuk:    " << szuk << endl;
    cout << "kol:     " << kol << endl;
    cout << "wiersz:  " << wiersz << endl;
    cout << "k_max:   " << k_max << endl;
    cout << "w_max:   " << w_max << endl;
    cout << "w_start: " << w_start << endl;

    return 0;
}