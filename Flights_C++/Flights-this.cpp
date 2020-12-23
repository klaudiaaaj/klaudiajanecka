
#include <string>
#include <vector> 
#include <iostream>
#include <fstream>
#include "Flights.h"

using namespace std;


Aiport Aiport::operator+ (Aiport& a2)
{
	//string n = name; 
	bool is = false;
	//vector<string>::iterator w; 


		//Aiport* aiportptr1 = new Aiport{ this->name, this-> aiport_connections };

	if (this->aiport_connections.capacity() != 0)
	{
		for (int w = 0; w < aiport_connections.size(); w++)
		{


			if (this->aiport_connections[w] == a2.name)
			{
				is = true;
				return *this;
			}

		}
	}
	else
	{
		this->aiport_connections.push_back(a2.name);
		//a2.aiport_connections.push_back(this->aiport_connections); 
		return *this;
	}
}


void fligh_printf(vector <Aiport*> aiports)
{
	for (int i = 0; i < aiports.size(); i++)
	{
		aiports[i]->printconnections();
	}
}
void Aiport::printconnections()
{
	cout << "\n\n" << this->name << endl;
	cout << "\nFor this aiport there are connections: " << endl;
	for (int i = 0; i < this->aiport_connections.size(); i++)
	{
		cout << this->aiport_connections[i] << "\t " << endl;
	}
}
//void Aiport::print_connections_by_name(string name)
//{
//	for (int i = 0; i < aiports.size(); i++)
//	{
//		aiports[i]->printconnections();
//	}
//
//}

void readflightsfromfile(string& directory,  vector <FlightC*>& flightsvec, vector <Aiport*>& airportvec)
{
	
	string line, s, name2;

	ifstream file;
	directory = "C:/Users/48573/OneDrive - Politechika Œl¹ska/Projekt cpp obiektowy/Travel_agency_step_by_step/file2.txt";
	file.open(directory);
	if (!file)
	{
		cout << "Unable to open file";
		exit(1); // terminate with error
	}
	else
	{

		/*
		In this loop file read variables from the file and sets it into array of objects flight
		*/
		//Aiport* aiportptr1 = new Aiport;
		while (!file.eof())
		{
			//i++
				//Aiport* airportptr = new Aiport;
			FlightC* flightptr = new FlightC;
			file >> flightptr->month_of_the_begin;
			file >> flightptr->day_of_the_begin;
			file >> flightptr->month_of_the_end;
			file >> flightptr->day_of_the_end;
			file >> flightptr->namefrom.name;
			file >> flightptr->nameto.name;
			flightsvec.push_back(flightptr);

			bool yesorno = false;
			bool yesorno2 = false;
			bool yesorno3 = false;
			if (airportvec.size() != 0)
			{
				yesorno3 = true;
				for (int d = 0; d < airportvec.size(); d++)
				{
					if (airportvec[d]->name == flightptr->namefrom.name)
					{

						yesorno = true;
						bool yesorno2 = false;
						if (airportvec[d]->aiport_connections.size() != 0)
						{
							for (int f = 0; f < airportvec[d]->aiport_connections.size(); f++)
							{
								cout << "\t" << airportvec[d]->aiport_connections[f];
								if (airportvec[d]->aiport_connections[f] == flightptr->nameto.name)
								{
									yesorno2 = true;
								}
							}
						}

						if (yesorno2 == false)
						{
							airportvec[d]->aiport_connections.push_back(flightptr->nameto.name);
						}
					}




				}
			}
			if (yesorno == false && yesorno3 == true)
			{
				Aiport* airportptr = new Aiport;
				airportptr->name = flightptr->namefrom.name;

				//airportptr =airportptr + flightptr->nameto;

				flightptr->namefrom = flightptr->namefrom + flightptr->nameto;
				airportvec.push_back(airportptr);

			}

			else if (yesorno3 == false)
			{
				Aiport* airportptr = new Aiport;
				airportptr->name = flightptr->namefrom.name;
				flightptr->namefrom = flightptr->namefrom + flightptr->nameto;
				airportptr->aiport_connections = flightptr->namefrom.aiport_connections;
				cout << airportptr->aiport_connections.size();
				airportvec.push_back(airportptr);

			}
		}
	}

	file.close();
}

void flight_interface()
{

}

void letsprintall(vector <FlightC*> flightsvec)
{
	for (int i = 0; i < flightsvec.size(); i++)
	{
		flightsvec[i]->printall();

	}
}

void FlightC::printall()
{
	cout << this->month_of_the_begin << "\t" << this->day_of_the_begin << "\t" << this->month_of_the_end << "\t" << this->day_of_the_end << "\t" << this->namefrom.name << "\t" << this->nameto.name << "\t" << endl;
}

void deletevecflight(vector <FlightC*> flightsvec)
{
	while (!flightsvec.empty())
	{
		delete flightsvec.back();  //delete flight
		flightsvec.pop_back();       //pop pointer }
	}
}

void deletevecairport(vector <Aiport*> airportvec)
{
	while (!airportvec.empty())
	{
		delete airportvec.back();  //delete aiport
		airportvec.pop_back();       //pop pointer }
	}
}
void writecity(vector <Aiport*>& airportvec)
{

	for (int i = 0; i < airportvec.size(); i++)
	{
		cout << airportvec[i]->name << endl;

	}
}

bool findcity(string name, vector<Aiport*>& airportvec)
{
	for (int i =0; i< airportvec.size(); i++)
	{
		if (airportvec[i]->name == name)
			return true;

	}
	return false;
}
void  writecitiestoother(vector <Aiport*>& airportvec, string name)
{
	for (int i = 0; i < airportvec.size(); i++)
	{
		if (airportvec[i]->name == name)
			for (int j = 0; j < airportvec[i]->aiport_connections.size(); j++)
			{
				cout << j + 1 << ") " << airportvec[i]->aiport_connections[j] << endl;

			}

		
	}
}

void findfinaly(vector<FlightC*> flightsvec, string pl, string other)
{
	int number = 1;

	for (int i = 0; i < flightsvec.size(); i++)
	{
		if (flightsvec[i]->namefrom.name == pl)
			for (int j = 0; i < flightsvec[i]->namefrom.aiport_connections.size(); j++)
			{
				if (flightsvec[i]->namefrom.aiport_connections[j] == other)
					cout << number << ") " << "\nDAY OF BEGIN: " << flightsvec[i]->day_of_the_begin << " MONTH OF BEGIN: " << flightsvec[i]->month_of_the_begin << "\n RETURN DAY:: " << flightsvec[i]->day_of_the_end << " RETURN MONTH: " << flightsvec[i]->month_of_the_end << endl;


			}

	}
}