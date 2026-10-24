//Khamuliak Ihor
#include <iostream>
#include <vector>

using namespace std;

int main()
{
    vector<int> tablica; 
    int temp; 

    while (true) {
        cout << "Jaka wartosc dodac do tablicy? (0 aby zakonczyc): ";
        cin >> temp;

        if (temp == 0) {
            break; 
        }
        tablica.push_back(temp);
    }

    int rozmiar = tablica.size();

    cout << "Pierwszy element: " << tablica[0] << endl;

    cout << "Zawartosc tablicy: ";
    for (int i = 0; i < rozmiar; i++) {
        cout << tablica[i] << " ";
    }
    cout << endl;

    cout << "Roznica miedzy ostatnim a pierwszym: " << tablica.back() - tablica.front() << endl;

    int suma = 0;
    for (int i = 0; i < rozmiar; i++) {
        suma += tablica[i];
    }
    cout << "Suma wszystkich elementow: " << suma << endl;

    cout << "Ktory element tablicy wyswietlic? " << endl;
    int n;
    cin >> n;
    cout << "Element na pozycji " << n << " to: " << tablica[n - 1] << endl;

    return 0;
}