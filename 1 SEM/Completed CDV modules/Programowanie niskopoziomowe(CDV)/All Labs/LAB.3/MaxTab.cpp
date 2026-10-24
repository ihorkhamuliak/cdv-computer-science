#include <iostream>

using namespace std;

int znajdzMax(int tab[], int rozmiar) 
{
    int max = tab[0]; 
    for (int i = 1; i < rozmiar; i++) 
    {
        if (tab[i] > max) {
            max = tab[i]; 
        }
    }
    return max;
}

int main() 
{
    int liczby[] = {3, 12, 5, 99, 1};
    int rozmiar = 5;
    
    cout << "Maksymalny element to: " << znajdzMax(liczby, rozmiar) << endl;
    return 0;
}