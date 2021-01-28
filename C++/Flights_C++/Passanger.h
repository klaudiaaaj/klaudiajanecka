#pragma once

#include "User.h"

using namespace std; 

class Passanger : public User
{
public:

	
	Passanger() {};
	Passanger(int type, string name, string psw, string email) : User(type, name, psw, email) {};
	//void buyatickey(); //function with process of buying tickets 
	//int takethetype(string user, string psw, vector <User*>uservec);
	//void addaccount(vector <User*>& uservec);
	//
	void interfacee(vector <FlightC*>& flightvec, vector<Aiport*>& airportvec, vector<unique_ptr<User>>& uservec);
	 // Virtual function : this function will be defined in each of its inheriting class
	
	void informator()
	{
		cout << "\n Hey ther!\n";
		cout << "Hey we have prepared for you special offert. If you will buy flight till the end of the day, you will have 20 % of dyscount" << endl;
	}
	int  returnstatus()
	{
		return 1;

	}
	void addacount(vector<unique_ptr<User>>& uservec); 


	


	//void login(vector <*User> uservec);


};