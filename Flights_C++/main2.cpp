#include "Admin.h"
#include "User.h"
#include "Passanger.h"
#include "Worker.h"
#include "Flight_portal.h"
#include "Flights.h"
#include <fstream>
#include <string>
#include <functional> 
#include <vector>
#include <algorithm>


#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
#include <crtdbg.h>
#include <iterator>
#include <set>
#include <memory>

using namespace std;


//
void Welcome(vector <FlightC*>& flightvec, vector<Aiport*>& airportvec, vector<unique_ptr<User>> &uservec);

//void save_users_into_file(vector<User*> uservec, const std::string& directory);

void loadusers(vector<unique_ptr<User>>& uservec, const std::string& directory);

/* Function which clears vector airportvec from the memory
*/
void clear_airports(vector<Aiport*>& airportvec); 

/* Function which clears vector flightvec from the memory
*/
void clear_flights(vector <FlightC*>& flightvec);

/*
Function says bye
*/
void byebye();
/* Function which saves new Users at the end of the file */
void save_users_into_file(vector<unique_ptr<User>>& uservec, const std::string& directory);

/*
Function loadusers(vector<unique_ptr<User>>& uservec,  const std::string& directory)
Is the main function about saving users from the file into vector. To this implementation I have used unique_pointer.
Structure is vector of the unique_pointers

*/void loadusers(vector<unique_ptr<User>>& uservec, const std::string& directory);
//
/*
Function which is the head of the communication with user
*/
void Welcome(vector <FlightC*>& flightvec, vector<Aiport*>& airportvec, vector<unique_ptr<User>>& uservec);

//void save_users_into_file(vector<User*> uservec, const std::string& directory);

void loadusers(vector<unique_ptr<User>>& uservec, const std::string& directory);

/* Function which clears vector airportvec from the memory
*/
void clear_airports(vector<Aiport*>& airportvec);

/* Function which clears vector flightvec from the memory
*/
void clear_flights(vector <FlightC*>& flightvec);
FlightC program;



int main(int argc, char** argv)
{
	vector<unique_ptr<User>> uservec;
	vector<Aiport*>airportvec;
	vector <FlightC*> flightsvec;
	string inputFileDirectory_users = "C:/Users/48573/source/repos/fstreamtest/user.txt";
	string inputFileDirectory_flights = "C:/Users48573/source/repos/Last_version/Last_version/file2.txt"; 
	//try
	{
		if (argc == 7)
		{
			int i;
			string inputFileDirectory_users, inputFileDirectory_flights, option; 
			inputFileDirectory_flights = ""; 
		
			//for (i = 1; i < argc; i += 2)
			//{
			//	option = argv[i];
			//	if (option == std::string("-i"))
			//	{
			//		inputFileDirectory_users = argv[i + 1];
			//	}

			//	else {
			//		//std::cout << "Invalid parameter: "<< option << " "<< argv[i+1]<< std::endl;
			//		std::cout << "Parameter list: " << std::endl;
			//		std::cout << "-i input-file" << std::endl;
			//		std::cout << "-o output-file" << std::endl;
			//		std::cout << "-s cityReference" << std::endl;
			//		throw std::string("Invalid parameter: " + option + " " + std::string(argv[i + 1]));
			//	}
			}
			/* 
			Function which reads from the file and save into the vector flights and them aiport connections
			*/
			readflightsfromfile(inputFileDirectory_flights, flightsvec, airportvec);


			letsprintall(flightsvec);
			/*
			fligh_printf(airportvec);
			
			Function which reads already saved users from the given file and saves them into vector of users
			*/
			loadusers(uservec, inputFileDirectory_users);
			
			/*
			General  interface. 
			It distributes next task in case of user choice, and type of user
			*/
				Welcome(flightsvec, airportvec, uservec);
			

			/*-i input ?le with a map -o output ?le with routes -s name of a reference point*/

				/**
				Function opens the output file and prints to file paths from starting city to all destinations
				*@param map.firstcity starting city
				*@param outputFileDirectory output file;
				*/

				/*	deleteElement(element.firstElement);*/
			/*	Welcome(flightsvec, airportvec, uservec); */
		}
	//}
	//catch (const std::string & blad)
	//{
	//	std::cout << blad << std::endl;
	//}
	//catch (...)
	//{
	//	std::cout << "nieznany blad :-)" << std::endl;
	//}

	////

	//letsprintall(flightsvec);
	//cout << "\n\nThere is a list of aiports and connections\n" << endl;
	//fligh_printf(airportvec); 
	//deletevecflight(flightsvec);
	//deletevecairport(airportvec);
	clear_flights(flightsvec);
	clear_airports(airportvec);
	_CrtDumpMemoryLeaks();
	return 0;



}

/*
Function loadusers(vector<unique_ptr<User>>& uservec,  const std::string& directory)
Is the main function about saving users from the file into vector. To this implementation I have used unique_pointer. 
Structure is vector of the unique_pointers

*/

void loadusers(vector<unique_ptr<User>>& uservec,  const std::string& directory)
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
			{case 1:
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

void save_users_into_file(vector<User*> uservec, const std::string& directory)
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