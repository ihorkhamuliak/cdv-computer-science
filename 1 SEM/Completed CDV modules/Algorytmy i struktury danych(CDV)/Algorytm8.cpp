#include <iostream>
#include <vector>

using namespace std;

int main() {
    
    vector<int> tab = {28, 17, 3, 15, 22, 28, 5, 13, 18, 1};
    
    int i = 1;      
    int zmien = 0;  
    int num = 10;   
    int j;          

    while (true) {
        
        if (i >= num) {
            
            if (zmien == 0) {
             
                cout << "Wynik (posortowana tablica): ";
                for (int val : tab) {
                    cout << val << " ";
                }
                cout << endl;
                break; 
            } 
            else {
               
                i = 1;          
                zmien = 0;      
                num = num - 1;  
    
            }

        } else {
      
            if (tab[i] < tab[i - 1]) {
                
                j = tab[i - 1];
                tab[i - 1] = tab[i];
                tab[i] = j;
                
                zmien = 1;
            }

            i = i + 1;
        }
    }

    return 0;
}