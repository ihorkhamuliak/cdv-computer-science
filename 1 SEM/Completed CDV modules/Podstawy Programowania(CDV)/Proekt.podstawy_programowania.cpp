//Khamuliak Ihor
//Dynamiczna lista ocen
#include <iostream>
using namespace std;

struct Ocena { //struktura 
int wartosc; //W przyszłości można łatwo rozbudować ją o inne pola(data, nazwa przedmiotu).
};

class Dziennik { //Zarządza całą logiką 
public:
 Ocena* lista; //wskaźnik
 int rozmiar; //przehowanie informacji

Dziennik(int n) { //Konstruktor 
 rozmiar = n; //Tworzenie tablicy
 lista = new Ocena[n];  //rezerwacja pamięci 
}

~Dziennik() {
delete[] lista; //zwalniamy pamięc 
}

 void wpiszOceny() { //interacja z użytkownikiem 
 for (int i = 0; i < rozmiar; i++) { //pętla for 
     cout << "Podaj ocene nr " << (i+1) << ": "; //wyjście
 cin >> lista[i].wartosc; //wejście
 }
}

void wypiszOceny() { //Prezentacja wyników 
cout << "\nTwoje oceny: "; //wyjście
for (int i = 0; i < rozmiar; i++) { //for przejście przez tablice 
 cout << lista[i].wartosc << " "; // Wyświetlenie wartości pola WARTOSC z każdego obiektu.
}
cout << endl;
 }
}; //zamykanie klasy

int main() {
int n;
cout << "Ile ocen chcesz wpisac? " << "\n"; //Pobieramy rozmiar od użytkownika 
cin >> n;

if (n > 0) {
Dziennik mojDziennik(n); //tworzymy obiekt moj dziennik
mojDziennik.wpiszOceny(); 
mojDziennik.wypiszOceny(); 
} //wywolanie metod na obiekcie 

return 0;
//Zakończenie programu (automatyczne uruchomienie destruktora).
}
