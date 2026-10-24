#include <iostream>

using namespace std;

union MojaUnia {
    int liczba;
    float liczbaP; 
    char znak;  
};

int main()
{
MojaUnia dane;
dane.liczba = 65;

    cout << "Znak: " << dane.znak;
    
    return 0;
}