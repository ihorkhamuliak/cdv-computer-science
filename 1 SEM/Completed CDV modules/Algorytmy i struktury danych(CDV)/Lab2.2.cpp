//Khamuliak Ihor
#include <iostream>
using namespace std;

int main() {
    int n;
    int f_a = 1;
    int f_b = 1;
    int f_w = 0;
    int i = 3;

    cout << "Dla jakiej wartości n Ciag Fibonaci" << endl;
    cout << "Podaj n: ";
    cin >> n;

    if (n <= 2) {
        f_w = 1;
        }
        else {
            do {
                f_w = f_a + f_b;
                f_a = f_b;
                f_b = f_w;
                i = i + 1;
            } while (i <= n);
        }
    }
    cout << "Wartość ciągu Fibonatiego dla n: " << n << "\nwynosi: " << f_w << endl;
    cout << "f_a: " << f_a << endl;
    cout << "f_b: " << f_b << endl;
    cout << "f_W: " << f_w << endl;
    cout << "i: " << i << endl;
    
    return 0;
}
