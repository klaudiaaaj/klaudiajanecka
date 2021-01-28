#include <fstream>
#include <string>
#include <iostream>
#include <windows.h>
#include <iomanip>
#include <cstdlib>
#include <cstdio>
#include <sstream>
#include <thread>
#include <chrono>   
#include <windows.h>
#include <conio.h> // In order to use function _getch()
#include "Admin.h"
#include"Passanger.h"





// Get user's status

/*
Function is responsible for the visual part of giving password in log in. It changes characters into "*" */
string InputPassword()
{
	// Input password
	char temp_c;
	int length = 0;

	string psw = "";
	while (true) {
		temp_c = _getch(); // Get a character without showing it
		if (temp_c != char(13))
		{ // If character is ENTER then break
			switch (temp_c) {
			case 8: // If character is Backspace
				if (length != 0) {
					cout << "\b \b";
					psw = psw.substr(0, length - 1);
					length--;
				}
				break;
			default:
				cout << "*"; // Use '*' to replace what you input
				psw += temp_c; // Connect each character to string 'psw'
				length++;
				break;
			}
		}
		else break;
	}
	cout << endl;
	return psw;

}
/*
Function  User::login(vector<unique_ptr<User>>& uservec, vector <FlightC*>& flightvec, vector<Aiport*>& airportvec)
is the log in panel.
At the begining user gives him username and password, and next function invokes function chceckstatus, which returns the type of the user
{
*/

User* User::login(vector<unique_ptr<User>>& uservec, vector <FlightC*>& flightvec, vector<Aiport*>& airportvec)
{
	vector<unique_ptr<User>> user; 

	User* abstract_user = new Admin;
	string username, psw;
	int tape = 0;
	Passanger p;
	Admin a; 
	Worker w;

	system("cls");
	cout << "Log in platform";
	system("cls");
	cout << "Please write yout username" << endl;
	cin >> username;
	system("cls");
	cout << "Please write yout pasword" << endl;
	psw = InputPassword();
	system("cls");


			// If find username and password in User.txt
			  // Return status
	
	int status;
	status = chceckuserStatus(username, psw, uservec);

	switch (status)
	{
	case 0:
		cout << "If you want to try again click 1" << endl;
		cin >> tape;
		if (tape == 1)
			login(uservec, flightvec, airportvec);
		else byebye();
			
	case 1:
		abstract_user = &p; 
		
		
		break;

		break;
	case 2:
		abstract_user = &w;
		abstract_user = new Worker;

		break;
	case 3:
		abstract_user = &a; 
		break;
	}
	abstract_user->interfacee(flightvec, airportvec, uservec); 
	return abstract_user; 
	delete abstract_user; 
}
/* Function checks type of the user and returns it into login function*/
int chceckuserStatus(string username, string password, vector<unique_ptr<User>>& uservec)
{


	for (size_t i = 0; i < uservec.size(); i++)
	{
		if (username == uservec[i]->username && password == uservec[i]->password)

			// If find username and password in User.txt
			return uservec[i]->type;  // Return status
	}
	cout << "Such a account does not exgist. Please try to log in again. Otherwise click esc" << endl;
	Sleep(1000);
	return 0;
	//this_thread::sleep_for(std::chrono::milliseconds(10000000));
	return 0;


}