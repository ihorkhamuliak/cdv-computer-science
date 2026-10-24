#include <iostream>
#include <chrono>

using namespace std;
using namespace chrono;

int main() {

    auto start = high_resolution_clock::now();

    long long sum = 0;
    for (int i = 1; i <= 100000000; i++) {
        sum += i; 
    }

    auto end = high_resolution_clock::now();

    auto duration = duration_cast<milliseconds>(end - start);

    cout << "Czas wykonania petli: " << duration.count() << " ms" << endl;

    return 0;
}
