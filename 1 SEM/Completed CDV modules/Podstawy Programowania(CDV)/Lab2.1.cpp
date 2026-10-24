#include <iostream>
using namespace std;
//Khamuliak Ihor
int main(){
    int a = 0;
    int b = 0;
    int tmp = 0;
    int nwd = 0;
    int op = 0;

    cout <<"NWD dla liczb a i b" <<endl;

    cout <<"Wprowadż a:";
    cin >> a;

    cout <<"Wprowadż b:";
    cin >> b;

    nwd=a;
    op=b;

 while (nwd != op) {
        if (nwd > op)
            nwd = nwd - op;
        else
            op = op - nwd;
    }
    
     cout << endl << " Nwd dla a: " << a << " i b: " << b << " jest " << nwd << endl;
     
     return 0;
}

    

