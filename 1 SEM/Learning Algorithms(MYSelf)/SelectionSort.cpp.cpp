#include <iostream>
#include <vector>

using namespace std;

int findSmallest(const vector<int>& arr) 
{
    int smallest = arr[0];
    int smallest_index = 0;

    for (int i = 1; i < arr.size(); i++) 
    {
        if (arr[i] < smallest) 
        {
            smallest = arr[i];
            smallest_index = i;
        }
    }
    return smallest_index;

}

vector<int> selectionSort(vector<int> arr) 
{
    vector<int> newArr;
    int original_size = arr.size();

    for (int i = 0; i < original_size; i++) 
    {
        int smallest_index = findSmallest(arr);

        newArr.push_back(arr[smallest_index]);

        arr.erase(arr.begin() + smallest_index);

    }
    return newArr;
}

int main() 
{
    vector<int> my_arr = {5, 3, 8, 9, 24324, 42, 90, 1, 6, 2, 10};

    vector<int> sorted_arr = selectionSort(my_arr);

    for (int i = 0; i < sorted_arr.size(); i++) 
    {
        cout << sorted_arr[i] << " ";
    }
    cout << endl;

    return 0;
}