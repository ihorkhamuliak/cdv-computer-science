#include <iostream>
using namespace std;

int main()
{
   int a, b, i, n, c;
   a = 0;
   b = 1;
   i = 0;

   cout << "podaj n: ";
   cin >> n;

   while (n > i)
   {
    c = a + b;
    b = a;
    a = c;
    i = i + 1;
   }

   cout <<"Write c: " << c << "\n";

   cout << "\n--- Stan zmiennych (Analiza) ---" << endl;
   cout << "n: " << n << endl;
   cout << "a: " << a << endl;
   cout << "b: " << b << endl;
   cout << "i: " << i << endl;
   cout << "c: " << c << endl;

   return 0;
}
