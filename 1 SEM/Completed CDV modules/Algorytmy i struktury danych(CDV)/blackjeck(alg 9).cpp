//Ihor Khamuliak
#include <iostream>
#include <vector>
#include <cstdlib>
#include <ctime>

using namespace std;

int main() {

    srand(time(NULL));

    int Wygrana = 0;
    int Przegrana = 0;
    int Remis = 0;
    
    int start;
    int Los; 

    while (true) {
        
        cout << "\nCzy chcesz rozpoczac gre?" << "\n" << "Tak:= 1" << "\n" << "Nie:= 2" << endl;
        cin >> start;

        if (start != 1) {
            break; 
        }

        int Gracz = 0;
        int Dealer = 0;
        int Ilosc = 0;
        vector<int> Talia(14, 0); 

        bool koniecRundy = false; 

        while (true) {
            cout << "Obecne punkty gracza: " << Gracz << endl;
            cout << "Czy chcesz dobrac karte?" << "\n" << "tak := 1" << endl;
            int Knock;
            cin >> Knock;

            if (Knock == 1) {
                do {
                    Los = rand() % 12 + 1; 
                } while (Talia[Los] >= 5); 

                Talia[Los] = Talia[Los] + 1;
                Gracz = Gracz + Los;

                if (Gracz > 21) {
                    Przegrana = Przegrana + 1;
                    cout << "przegrales" << endl; 
                    koniecRundy = true; 
                    break; 
                }
            } else {
                break; 
            }
        }

        if (koniecRundy == false) {
            
            while (Ilosc < 3) {
                do {
                    Los = rand() % 12 + 1;
                } while (Talia[Los] >= 5);

                Talia[Los] = Talia[Los] + 1;
                Dealer = Dealer + Los;
                Ilosc = Ilosc + 1;
            }

            if (Dealer > 21) {
                Wygrana = Wygrana + 1;
                cout << "wygrales" << endl;
            } 
            else {
                if (Gracz > Dealer) {
                    Wygrana = Wygrana + 1;
                    cout << "wygrales" << endl;
                } 
                else {
                    if (Gracz == Dealer) {
                        Remis = Remis + 1;
                        cout << "remis" << endl;
                    } 
                    else {
                        Przegrana = Przegrana + 1;
                        cout << "przegrales" << endl;
                    }
                }
            }
        }

        cout << "-----------------------" << endl;
        cout << "Twoje punkty: " << Gracz << endl;
        cout << "Punkty dealera: " << Dealer << endl;
        cout << "Balans gier: " << endl;
        cout << "Wygrana: " << Wygrana << endl;
        cout << "Przegrana: " << Przegrana << endl;
        cout << "Remis: " << Remis << endl;
        cout << "-----------------------" << endl;
    }

    return 0;
}