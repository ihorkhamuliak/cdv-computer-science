#include <iostream>
#include <vector>
#include <string>
#include <cstdlib> 
#include <ctime>   
#include <iomanip> 

using namespace std;

class Platnosc 
{
public:
    virtual void zaplac(float kwota) = 0;
    virtual ~Platnosc() {}
};

class PlatnoscKarta : public Platnosc 
{
private:
    string numerKarty;

public:
    PlatnoscKarta(string numer)
    {
        numerKarty = numer;
    }

    void zaplac(float kwota) override 
    {
        cout << "Zaplacono " << kwota << " zl karta VISA " << numerKarty << endl;
    }
};

class PlatnoscBlik : public Platnosc 
{
private:
    string kodBlik; 

public:
    PlatnoscBlik(string kod)
    {
        kodBlik = kod;
    }

    void zaplac(float kwota) override 
    {
        cout << "Zaplacono " << kwota << " zl BLIK (kod: " << kodBlik << ")" << endl;
    }
};

class PlatnoscKrypto : public Platnosc 
{
private:
    string nazwaWaluty;

public:
    PlatnoscKrypto(string waluta)
    {
        nazwaWaluty = waluta;
    }

    void zaplac(float kwota) override 
    {
        cout << "Zaplacono " << kwota << " " << nazwaWaluty << endl;
    }
};

int main() 
{
    srand(time(NULL));
    vector<Platnosc*> listaPlatnosci;

    listaPlatnosci.push_back(new PlatnoscKarta("XXXX-1234"));
    listaPlatnosci.push_back(new PlatnoscBlik("777-123"));
    listaPlatnosci.push_back(new PlatnoscKrypto("BTC"));

    cout << "--- Rozpoczynam przetwarzanie platnosci ---\n" << endl;

    cout << fixed << setprecision(2);

    for (Platnosc* p : listaPlatnosci) 
    {
        float losowaKwota = (rand() % 10000) / 100.0;
        losowaKwota += 1.0;
        p->zaplac(losowaKwota);
    }

    for (Platnosc* p : listaPlatnosci) 
    {
        delete p;
    }
    
    listaPlatnosci.clear();

    return 0;
}