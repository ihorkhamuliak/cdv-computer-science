#include <iostream>

using namespace std;

void increment(int *p)
{
    (*p)++;
}

int globalna = 100;   

int main()
{
    int automatyczna = 10;       
    static int statyczna = 50;   

    increment(&automatyczna);
    increment(&statyczna);
    increment(&globalna);

    cout << "Automatyczna: " << automatyczna << endl;
    cout << "Statyczna: " << statyczna << endl;
    cout << "Globalna: " << globalna << endl;

    return 0;
}