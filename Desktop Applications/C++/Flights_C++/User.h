#pragma once
#include <conio.h>
#include <string>
#include <iostream>
#include <memory>
#include <windows.h>
#include <iomanip>
#include <vector>
#include "Flight_portal.h"
#include "Flights.h"
#include "User_container.h"

using namespace std;

void byebye()
{
	cout << "Are you going so fast? ;(" << endl;
	cout << "See you soon!" << endl;
	return;
}

class User
{
	//zwroc do private 

public:

	int type = 0;
	string username;
	string password;
	string email;

	friend class FlightC;
	friend class Aiport;
	
	User() {}; 
	//User(int type, string name, string psw, string email) : type(type), username(name), password(psw), email(email) {};
	User(int type, string name, string psw, string email) : type(type), username(name), password(psw), email(email) {};

	//functions connected with seeing the offerts and interface
	void setType(int number) { type = number; };
	void setUsername(string name) { username = name; };
	void setEmail(string emaill) { email = emaill; };
	void setPassword(string psw) { password = psw; };

	User* login(vector<unique_ptr<User>>& uservec, vector <FlightC*>& flightvec, vector<Aiport*>& airportvec);

	friend int chceckuserStatus(string username, string password, vector<unique_ptr<User>>& uservec);

	friend bool usernamecheck(vector<unique_ptr<User>>& uservec, string name);
	friend bool useremailchceck(vector<unique_ptr<User>>& uservec, string email);

	virtual void interfacee(vector <FlightC*>& flightvec, vector<Aiport*>& airportvec, vector<unique_ptr<User>>& uservec) = 0;//pure virtual function
// Virtual function : this function will be defined in each of its inheriting class
	virtual void addacount(vector<unique_ptr<User>>& uservec) = 0;
	virtual int returnstatus() = 0;

	//void save_users_into_file(vector<User> uservec); 
	void deleteFromFile(vector<unique_ptr<User>>& uservec);

	void savenewuser(vector<unique_ptr<User>>& uservec);
	


	~User() {};
//	virtual ~User() {};

};

string InputPassword();


