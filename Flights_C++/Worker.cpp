#include "Worker.h"

void Worker::interfacee(vector <FlightC*>& flightvec, vector<Aiport*>& airportvec, vector<unique_ptr<User>>& uservec)
{

    cout << "Welcome into interface for worker" << endl;

 }

void Worker::addacount(vector<unique_ptr<User>>& uservec)
{
    cout << "Worker does not have ability to add himself. Admin has to do it " << endl; 

}
/* create pure virtual class*/