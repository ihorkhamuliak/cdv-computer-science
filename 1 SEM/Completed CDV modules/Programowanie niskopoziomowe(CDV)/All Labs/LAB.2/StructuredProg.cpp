#include <iostream>

using namespace std;

int dodaj(int a, int b)
{
    return a + b;
}
int odejmij(int a, int b)
{
    return a - b;
}

void wypisz(int wynik)
{
cout << wynik << endl;
}

int main()
{
    int a, b;
    cout << "Podaj a: ";
    cin >> a;
    cout << "Podaj b: "; 
    cin >> b;

    int sum = dodaj(a, b);
    int diff = odejmij(a, b);
    wypisz(sum);
    wypisz(diff);

    

    return 0;
}