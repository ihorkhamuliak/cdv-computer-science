#include <iostream>
using namespace std;

class Prostokat 
{
public:
    double dlugosc;
    double szerokosc;

    Prostokat(double d, double s)
    {
        dlugosc = d;
        szerokosc = s;
    }
    void pole() 
    {
        double wynik = dlugosc * szerokosc;
        cout << "Pole = " << wynik << endl;
    }
    void obwod() 
    {
        double wynik = 2 * (dlugosc + szerokosc);
        cout << "Obwod = " << wynik << endl;
    } 

};

int main() 
{
Prostokat p1(10,15);
p1.pole();
p1.obwod();

Prostokat p2(5.5, 4.0);
p2.pole();
p2.obwod();

}