#include <iostream>
#include "globals.h"

using namespace std;

int main() 
{
cout << "Poczatkowa wartosc: " << global_counter << endl;
    
    
    incrementCounter();
cout << "Po inkrementacji: " << global_counter << endl;
    
   
global_counter = 42;
cout << "Zmieniona bezposrednio w main: " << global_counter << endl;
    
return 0;
}

int global_counter = 0;

void incrementCounter() {
    global_counter++;
}