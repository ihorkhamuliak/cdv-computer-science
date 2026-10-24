#include <iostream>
#include <vector>

using namespace std;

int binary_search(const vector<int>& list, int item) 
{
int low = 0;
int high = list.size() - 1;

while (low <= high) 
{
    int mid = (low + high) / 2;
    int guess = list[mid];

    if (guess == item) 
    {
        return mid;
    }
    if (guess > item)
    {
        high = mid - 1;

    } else {
        low = mid + 1;
    }
}
return -1;
}
int main() 
{
    vector<int> my_list = {1, 3, 5, 7, 9};

    cout << binary_search(my_list, 9) << endl;
    cout << binary_search(my_list, 1) << endl;

    return 0;
}