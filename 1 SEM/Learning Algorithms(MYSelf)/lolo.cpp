#include <iostream>
#include <string>

using namespace std;
void  greet2(string name) 
{
    cout << "how are you, " << name << "?" << endl; 
}
void bye() 
{
    cout << "ok, bye!" << endl;
}
void greet(string name) 
{
    cout << "hello, " << name << "!" << endl;

    greet2(name);

    cout << "getting ready to say bye..." << endl;
      
    bye();
}

int main() 
{
    greet("maggie");
    
    return 0;
}

