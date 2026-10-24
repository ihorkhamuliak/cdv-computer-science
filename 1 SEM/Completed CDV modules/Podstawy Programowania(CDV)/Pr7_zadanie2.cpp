#include <iostream>
#include <cstdlib> 
#include <ctime>  

using namespace std;

class Kostka 
{

private: 
    int iloscScian;

public:
    Kostka(int sciany = 6) 
    {
        iloscScian = sciany;
    }
    void rzuc() 
    {
        int wynik = (rand() % iloscScian) + 1;
        
        cout << "Wynik rzutu: " << wynik << endl;
    }

}; 

int main() 
{
    srand(time(NULL));

    cout << "--- Kostka standardowa (6 scian) ---" << endl;
    Kostka mojaKostka; 

    for(int i = 0; i < 5; i++)
    {
        mojaKostka.rzuc();
    }
    cout << "\n--- Kostka RPG (20 scian) ---" << endl;
    Kostka duzaKostka(20); 
    
    duzaKostka.rzuc();

    return 0;
}