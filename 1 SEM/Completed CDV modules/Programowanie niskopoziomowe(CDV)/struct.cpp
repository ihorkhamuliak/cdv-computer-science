#include <iostream>

using namespace std;

struct A 
{
    char c;
    int i;
    char d;
};

int main()
{
    cout << "Ile ma bajtow: " << sizeof(A) << endl;
    
    return 0;
}