#include <conio.h>
#include "Passanger.h"
#include "Flights.h"
#include "Flight_portal.h"
#include "Class_user.h"

using namespace std; 
/*
Virtual function from base class User, into derived class Passanger. 
It adds new passanger. 
It is created virtual tu corrrectly set type of user. 
In this case passanger tape is 1. 
*/
void Passanger::addacount(vector<unique_ptr<User>>& uservec)
{
	
	string name, password, email;
	cout << "Please write your email" << endl;
	cin >> email;

	if (useremailchceck(uservec, email))
	{
		cout << "User with this e-mail already exist" << endl;
		addacount(uservec);
	}
	this->setEmail(email); 
	cout << "Please write your user name" << endl;
	cin >> name;
	if (usernamecheck(uservec, name))
	{
		cout << "User with this username already exist" << endl;
		addacount(uservec);
	}
	this->setUsername(name); 
	cout << "Please write your password" << endl;
	password = InputPassword(); 
	this->setPassword(password); 


	this->setType(1); 

	uservec.push_back(unique_ptr<User>(new Passanger(*this)));
	cout << "Congratulations, Your account has been already created" << endl;
	//add account into vector 

	//	this->takethetype(name, password, uservec); 

	system("cls"); 

}

/*

Function which literate throw vector of users and chcecks if already user with this username exist.
It compers all already added users in the  base with new one. 

*/
bool usernamecheck( vector<unique_ptr<User>>& uservec, string name)
{
	for (int i = 0; i < uservec.size(); i++)
	{
		if (uservec[i]->username == name)
			return true;
	}
	return false;
}

/*
Function which literate throw vector of users and chcecks if already user with this email exist
It compers all already added users in the  base with new one.
*/
bool  useremailchceck(vector<unique_ptr<User>>& uservec, string email)
{

	for (int i = 0; i < uservec.size(); i++)
	{
		if (uservec[i]->email == email)
			return true;
	}
	return false;

}
/*
Virtual function from base class User, into derived class Passanger.
It provides specific interface for Passanger user. 
*/

void Passanger::interfacee(vector <FlightC*>& flightvec, vector<Aiport*>& airportvec, vector<unique_ptr<User>>& uservec)
{
	string pl_aiport, other_aiport;
	system("CLS");
	cout << "Hey there is interface for passanger" << endl;
	cout << "At the begin please choose suitable for you airport to go.\nThere is list of polish airports: \n" << endl;
	writecity(airportvec);
	cout << "\nPlease write suitable for you aiport" << endl;
	cin >> pl_aiport;
	char character = 0;
	if (findcity(pl_aiport, airportvec) == false)
	{
		while ((findcity(pl_aiport, airportvec) == false) || (character != 27))
		{
			cout << "You have writen wrong name, please write again, otherwise click esc" << endl;
			character = _getch();
			Sleep(200);
			system("cls");
			findcity(pl_aiport, airportvec);
		}
	}

	cout << "There is list of the destinations from this aiport:\n";
		writecitiestoother(airportvec, pl_aiport);
		int s = 6; 
	cout << "Please choose one of them to see the dates\n";
	int choice; 
	cin >> choice;
	if (choice > s || choice <1)
	{
		cout << "wrong number, please tape again '" << endl;
	
		cin >> choice;

	}
	

		//list of the dates and connections;
		
		cout << "Please write the numer of position about which you are interersted about" << endl;


		//Passanger::print_the_ticket();






	
}