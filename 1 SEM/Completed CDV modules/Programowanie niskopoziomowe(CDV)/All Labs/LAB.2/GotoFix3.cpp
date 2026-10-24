#include <iostream>

using namespace std;

int main()
{
    int n = 5;
    int suma = 0;

    for (int i = 1; i <= n; i++)
    {
        suma = suma + i;
    }
    cout << "Suma: " << suma;

    return 0;
}