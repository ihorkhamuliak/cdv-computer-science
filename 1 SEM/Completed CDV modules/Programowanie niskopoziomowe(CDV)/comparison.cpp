#include <iostream>
#include <string>

using namespace std;

struct Student {
    string imie;
    float srednia;
};

void zmienWartosc(Student s) {
    s.srednia = 5.0; 
}

void zmienWskaznik(Student *s) {
    s->srednia = 5.0; 
}

int main() {
    Student s1 = {"Jan", 3.0};
    Student s2 = {"Anna", 3.0};

    zmienWartosc(s1);
    cout << "Po funkcji przez wartosc: " << s1.imie << " ma srednia " << s1.srednia << endl;

    zmienWskaznik(&s2); 
    cout << "Po funkcji przez wskaznik: " << s2.imie << " ma srednia " << s2.srednia << endl;

    return 0;
}