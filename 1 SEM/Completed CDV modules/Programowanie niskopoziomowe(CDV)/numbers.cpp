#include <iostream>

using namespace std;

int main()
{
    int liczby[10];

    for (int i = 0; i < 10; i++)
    {
      liczby[i] = i + 1;

    }
    for (int i = 0; i < 10; i++)
    {
        cout << liczby[i] << " " << endl;
    }
    
    return 0;
}