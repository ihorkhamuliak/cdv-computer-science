#define _CRT_SECURE_NO_WARNINGS
#include <cstdlib> // Potrzebne do system("cls") lub system("clear")
#include <ctime>
#include <iostream>
#include <string>
using namespace std;
void clearScreen() {
#ifdef _WIN32
system("cls");
#else
system("clear");
#endif
}
string dzisiejszaData() {
time_t teraz = time(0);
tm* czas = localtime(&teraz);
int dzien = czas->tm_mday;
int miesiac = 1 + czas->tm_mon;
string dzisiejszaData = to_string(dzien) + "_" + to_string(miesiac);
return dzisiejszaData;
}
string poprawnyLogin() { return "L0g1n_" + dzisiejszaData(); }
string poprawneHaslo() {
time_t teraz = time(0);
tm* czas = localtime(&teraz);
int rok = 1900 + czas->tm_year;
return "H@$10_" + to_string(rok);
}
int main() {
string login, haslo;
string poprawny_login = poprawnyLogin();
string poprawne_haslo = poprawneHaslo();
bool zalogowano = false;
while (!zalogowano) {
cout << "Podaj login: ";
cin >> login;
cout << "Podaj haslo: ";
cin >> haslo;
if (login == poprawny_login && haslo == poprawne_haslo) {
cout << "Logowanie udane!" << endl;
zalogowano = true;
} else {
cout << "Niepoprawny login lub haslo. Nacisnij dowolny klawisz, aby sprobowac ponownie." << endl;
cin.ignore();
cin.get();
system("cls");
}
}
return 0;
}
/*Login: L0g1n_16_11
Hasło: H@$10_2025*/