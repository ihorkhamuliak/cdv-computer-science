#include <iostream>

using namespace std;

int main()
{
  int n = 5;
  int suma = 0;
  int i = 1;

  start:
  if (i > n) goto end;
  suma = suma + i;
  i++;

  goto start;
  end:

  cout << "Suma: " << suma;
  
  return 0;
}