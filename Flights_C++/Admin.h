
#pragma once
#include <string>
#include <vector>
#include "Worker.h"

//#include "Flights.h"
using namespace std; 

class Admin :public Worker 
{

protected: string raport = "";
private: 

	void deleteUser(string username, vector<unique_ptr<User>>& uservec);

public:
	Admin( int type,string raport,
		string username,
		string password,
		string email) {};

	Admin() { }; 
	Admin(const Admin & a)
	{
		raport = a.raport;
		type = a.type;
		username = a.username;
		password = a.password;
		email = a.email; 

	}
	
	void addacount(vector<unique_ptr<User>>& uservec)//virtual void from the base class User. In this case you add new worker 
	{
		cout << "";
	};

 //delete old user;

	void interfacee(vector <FlightC*>& flightvec, vector<Aiport*>& airportvec, vector<unique_ptr<User>>& uservec);


	int returnstatus()
	{
		return 3;
	};

};

