#include "Flight_portal.h"
#include "User.h"
#include "Class_user.h"
#include "Admin.h"
#include "Passanger.h"
#include <iostream>

using namespace std; 

void Welcome(vector <FlightC*>& flightvec, vector<Aiport*>& airportvec, vector<unique_ptr<User>>& uservec)
{

	User* first;
	//User* second = new Worker;
	//User* third = new Admin;
	Admin a; 
	Passanger p;
	Worker w;
	string username, password;
	int tape = 0;
	//readusersfromfile(dir, uservec);
	cout << "\t\t\n\n\t\t\t\t\t******* 'WHY NOT FLY SOMEWHERE'?****" << endl;
	cout << "\n\n\tWelcome to our travel agency " << endl;
	cout << "\n\n\tThanks to our flight agency, you can find cheap connections in suitable time." << endl;
	cout << "\n\n Taking care about the comfort of our users and workers, at the begin we will ask to log in into our service. \n\tIf you want to log in tape 1 (everybody )\n\tIf you want to register account tape 2\n\tIf ypu want to delete your accont tape 5" << endl;
	cin >> tape;
	switch (tape)
	{
	case 1:
		//cout << "no problem"; 
		first = &p;
		//first = first->login(uservec, flightvec,airportvec); //I initialize function by reference from passanger object
		first->interfacee(flightvec, airportvec, uservec);// function login returns pointer and initialase function interfacee 
		break;

	case 2:
		first = &p;
		first->addacount(uservec);
		first->interfacee(flightvec, airportvec, uservec);
		break;

	case 5:
		cout << "We will send request to admin. Please tape your user name, and password" << endl;

		cout << "Username:\n" << endl;
		cin >> username;
		cout << "Password\n" << endl;
		cin >> password;


	default:
		cout << "You have set wrong/no value, try again" << endl;

		Welcome(flightvec, airportvec,uservec);
		break;
	}


}

void loadusers(vector<unique_ptr<User>>& uservec, const std::string& directory)
{


	string username, email, password;
	int type;
	User* newone;
	Passanger pas;
	Admin ad;
	Worker wor;

	std::ifstream inputstream;

	inputstream.open(directory);
	if (!inputstream.is_open()) throw "non existing file / file corrupted";

	else

		while (!inputstream.eof())
		{
			inputstream >> username;
			inputstream >> email;
			inputstream >> password;
			inputstream >> type;



			switch (type)
			{
			case 1:
				//newone = new Passanger; 

				pas.setUsername(username);
				pas.email = email;
				pas.setType(type);
				pas.setPassword(password);
				uservec.push_back(unique_ptr<User>(new Passanger(pas)));


				break;
			case 2:
				wor.setUsername(username);
				wor.email = email;
				wor.setType(type);
				wor.setPassword(password);
				uservec.push_back(unique_ptr<User>(new Worker(wor)));

				break;
			case 3:

				ad.setUsername(username);
				ad.email = email;
				ad.setType(type);
				ad.setPassword(password);
				uservec.push_back(unique_ptr<User>(new Admin(ad)));

				break;
			default:
				break;
			}

		}
	inputstream.close(); // close user.txt
}



void save_users_into_file(vector<unique_ptr<User>>& uservec, const std::string& directory)
{

	ofstream file;

	file.open(directory, ios::app);
	if (!file)
	{
		cout << "unable to open file";
		exit(1); // terminate with error
	}

	//dodaj foreach 
	for (int i = 0; i < uservec.size(); i++)
		file << "\n" << uservec[i]->username << " " << uservec[i]->email << " " << uservec[i]->password << " " << uservec[i]->type;



	file.close();

}

void clear_flights(vector <FlightC*>& flightvec)
{
	for (auto p : flightvec)
	{
		delete p;
	}
	flightvec.clear();
}

void clear_airports(vector<Aiport*>& airportvec)
{

	for (auto p : airportvec)
	{
		delete p;
	}
	airportvec.clear();



}