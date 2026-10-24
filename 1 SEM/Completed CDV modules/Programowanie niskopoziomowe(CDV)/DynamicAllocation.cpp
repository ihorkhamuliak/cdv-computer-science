#include <iostream>
#include <cstdlib> 

using namespace std;

int main() 
{
    int n = 5; 
    
    int *tab = (int*)malloc(n * sizeof(int));
    if (tab == NULL) return 1; 
    
    int suma = 0;
    for(int i = 0; i < n; i++) 
    {
        tab[i] = (i + 1) * 2; 
        suma += tab[i];
    }
    
    float srednia = (float)suma / n;
    cout << "Srednia wynosi: " << srednia << endl;

    int nowyRozmiar = 10;
    int *temp = (int*)realloc(tab, nowyRozmiar * sizeof(int));
    
    if (temp != NULL) 
    {
    tab = temp; // Aktualizujemy wskaźnik, jeśli się udało
    }
    free(tab);
    
    return 0;
}