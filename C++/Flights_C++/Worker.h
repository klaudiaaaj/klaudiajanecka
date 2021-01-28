#pragma once 
#include "User.h"
#include <iostream>
using namespace std; 


class Worker : public User
{

public:

	Worker(int type, string username, string email, string psw) : User(type, username, email, psw) {};
	Worker(const Worker& a) : User(a)
	{
		cout << "copy constructor of worker" << endl;
	};
	Worker() {};
	void interfacee(vector <FlightC*>& flightvec, vector<Aiport*>& airportvec, vector<unique_ptr<User>>& uservec);
	void addofert()
	{
		cout << "hej"; 
	}
	int returnstatus()
	{
		return 2;
	}
	void addacount(vector<unique_ptr<User>>& uservec); 



};