#include <iostream>

using namespace std;

struct Zespolowa
{
    double re, im;
};

void wyswietl(Zespolowa z)
{
    cout << z.re << " + " << z.im << " i" << endl;
}

Zespolowa dodaj(Zespolowa z1, Zespolowa z2)
{
    Zespolowa wynik;

    wynik.re = z1.re + z2.re;
    wynik.im = z1.im + z2.im;

    return wynik;
}

Zespolowa pomnoz(Zespolowa z1, Zespolowa z2)
{
Zespolowa wynik;
    wynik.re = (z1.re * z2.re) - (z1.im * z2.im);
    wynik.im = (z1.re * z2.im) + (z1.im * z2.re);
    
    return wynik;
}
int main()
{
Zespolowa liczba1 = {2.0, 3.0};
Zespolowa liczba2 = {2.0, 3.0};
    
Zespolowa suma = dodaj(liczba1,liczba2);
Zespolowa iloczyn = pomnoz(liczba1, liczba2);

wyswietl(suma);
wyswietl(iloczyn);

return 0;

    
}
