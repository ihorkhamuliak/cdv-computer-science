#include <iostream>

using namespace std;
//GOTO FIX
int main()
{
int i, x = 0;
int found = 0;
int n = 5;
int tab[] = {1, 2, 3, 4, 5};

for ( i = 0; i < n; i++)
{
    if(tab[i] == x)
    {
        found = 1;
        break;
    }
    
}
//Rewizja
if (found == 1)
{
    cout << "Znaleziona!";
}
else {
    cout << "Nie znaleziono";
} //Rewizja
return 0;
}