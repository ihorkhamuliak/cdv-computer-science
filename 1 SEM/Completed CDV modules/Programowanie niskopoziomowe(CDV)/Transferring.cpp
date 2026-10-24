#include <iostream>

using namespace std;

void przezWartosc(int liczba)
{
    liczba = 99;
}

void przezReferencje(int &liczba)
{
    liczba = 99;
}

void przezWskaznik(int *liczba)
{
    if (liczba != nullptr)
    {
    *liczba = 99;
    }
}

int main()
{
    int a = 10;
    int b = 10;
    int c = 10;

    cout << "Wartosci poczatkowe: a = 10, b = 10, c = 10\n\n";

    przezWartosc(a);
   cout << "1. Przez wartosc: a = " << a << " (brak zmian, to byla tylko kopia)" << endl;

   przezReferencje(b);
    cout << "2. Przez referencje: b = " << b << " (oryginal zostal zmieniony)" << endl;

    przezWskaznik(&c);
    cout << "3. Przez wskaznik: c = " << c << " (oryginal zmieniony przez adres)" << endl;

    return 0;
}
