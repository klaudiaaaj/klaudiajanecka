#include "Admin.h"
#include "User.h"
#include <fstream>

void Admin::interfacee(vector <FlightC*>& flightvec, vector<Aiport*>& airportvec, vector<unique_ptr<User>>& uservec)
{
	int option;
	string username;

	Worker worker; 

	cout <<"Hi Admin again\nWhat you want to do?\nThere are options for you" << endl;
	cout << "\nOptions:\n1) Add new worker\nDelete account tape :\n1 for worker\n2 for passanger\3Add new offert" << endl;
	cin >> option;
	switch (option)
	{
	case 1:
		worker.addacount(uservec);
		break;
	case 2:
		cout << "Please write username of User which you want to delete" << endl;
		cin >> username;
		//deleteUser(username, uservec);

		break;

	case 3: 
		break; 

	}



}
/*
Member method because, only class Admin has acces into it
//*/
//void Admin::deleteUser(string username, vector <User*>& uservec)
//{
//
//	for (int i = 0; i < uservec.size(); i++)
//	{
//		if (uservec[i]->username == username)
//		{
//			uservec.erase(uservec.begin() + i);
//			deleteFromFile(uservec); 
//			break; 
//
//		}
//	}
//
//
//}
//
//void User::deleteFromFile(vector <User*>& uservec)
//{
//
//		ofstream file;
//
//		file.open("C:/Users/48573/OneDrive - Politechika �l�ska/Projekt cpp obiektowy/Travel_agency_step_by_step/users.txt", ios::trunc); //contenst of the file is deleted
//		if (!file)
//		{
//			cout << "Unable to open file";
//			exit(1); // terminate with error
//		}
//		for (int i = 0; i < uservec.size(); i++)
//		{
//			file << "\n" << uservec[i]->username << " " << uservec[i]->email << " " << uservec[i]->password << " " << uservec[i]->type;
//
//		}
//		file.close();
//	
//}
