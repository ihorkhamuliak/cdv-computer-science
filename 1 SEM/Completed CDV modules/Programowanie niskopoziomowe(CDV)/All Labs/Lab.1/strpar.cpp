#include <iostream>

using namespace std;

struct Punkt 
{
    int x, y;
};

void funkcjaWartosc(Punkt dane)
{
dane.x = 100;
}

void funkcjaWskaznik(Punkt *dane)
{
    dane -> x = 200;
}

int main()
{
Punkt testowy;
testowy.x = 10;

funkcjaWartosc(testowy);

cout << "Testowy Wartość: " << testowy.x;

funkcjaWskaznik(&testowy);

cout << "\nTestowy Wskaznik: " << testowy.x;

return 0;

}