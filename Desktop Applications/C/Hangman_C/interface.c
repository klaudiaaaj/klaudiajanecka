#pragma warning(disable : 4996)
#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <stdbool.h>
#include<dos.h>
#include <conio.h>
#include <stdbool.h>


#include <conio.h>

#include <windows.h>

#include "interface.h"




//#include "makegame.h"
//#define NULL 0

/*
Functions reads number of wrong answers and sent draw hangmen corensonding to this amonth
*/

		void hangman(int i, char taboflets[], int size, char writtenlets[], int given)//printHangmen
		{


			printf("\n\n\n\n");
			switch (i - 1)
			{

			case 0:
				system("cls");

				printf("\n\t||      ");
				break;
			case 1:
				system("cls");

				printf("\n\t||     ");
				printf("\n\t||      ");
				break;
			case 2:
				system("cls");

				printf("\n\t||     ");
				printf("\n\t||      ");
				printf("\n\t||      ");
				break;
			case 3:
				system("cls");

				printf("\n\t||      ");
				printf("\n\t||      ");
				printf("\n\t||      ");
				printf("\n\t||      ");
				break;
			case 4:
				system("cls");

				printf("\n\t||      ");
				printf("\n\t||      ");
				printf("\n\t||      ");
				printf("\n\t||      ");
				printf("\n\t||      ");
				break;
			case 5:
				system("cls");
				printf("\n\t||===== ");
				printf("\n\t||     ");
				printf("\n\t||     ");
				printf("\n\t||      ");
				printf("\n\t||      ");
				printf("\n\t||      ");
				break;

			case 6:
				system("cls");
				printf("\n\t||===== ");
				printf("\n\t||    | ");
				printf("\n\t||     ");
				printf("\n\t||      ");
				printf("\n\t||     ");
				printf("\n\t||      ");
				break;
			case 7:
				system("cls");
				printf("\n\t||===== ");
				printf("\n\t||    | ");
				printf("\n\t||    O ");
				printf("\n\t||   ");
				printf("\n\t||     ");
				printf("\n\t||");
				break;
			case 8:
				system("cls");
				printf("\n\t||===== ");
				printf("\n\t||    | ");
				printf("\n\t||    O ");
				printf("\n\t||    | ");
				printf("\n\t||     ");
				printf("\n\t||   ");
				break;

			case 9:
				system("cls");
				printf("\n\t||===== ");
				printf("\n\t||    | ");
				printf("\n\t||    O ");
				printf("\n\t||    |%c", 92);
				printf("\n\t||      ");
				printf("\n\t||      ");
				break;
			case 10:
				system("cls");
				printf("\n\t||===== ");
				printf("\n\t||    | ");
				printf("\n\t||    O ");
				printf("\n\t||   /|%c", 92);
				printf("\n\t||      ");
				printf("\n\t||    ");
				break;
			case 11:
				system("cls");
				printf("\n\t||===== ");
				printf("\n\t||    | ");
				printf("\n\t||    O ");
				printf("\n\t||   /|%c", 92);
				printf("\n\t||    |  ");
				printf("\n\t||       ");
				break;
			case 12:
				system("cls");
				printf("\n\t||===== ");
				printf("\n\t||    | ");
				printf("\n\t||    O ");
				printf("\n\t||   /|%c", 92);
				printf("\n\t||    |  ");
				printf("\n\t||   / ");
				printf("\n\t|| ");
				break;
			case 13:
				system("cls");
				printf("\n\t||===== ");
				printf("\n\t||    | ");
				printf("\n\t||    O ");
				printf("\n\t||   /|%c", 92);
				printf("\n\t||    |  ");
				printf("\n\t||   / %c", 92);
				printf("\n\n\n\t YOU ARE DEAD !  ");

				break;

			}
			//prints guessed letters, and places of letter which havent been  already guessed
			printf("\n\n");
			for (int j = 0; j < size; j++)
			{

				printf("   %c", taboflets[j]);
			}
			printf("\n\n");


			printf("\n\n\n You have already given:  ");
			//prints all letter already given
			for (int i = 0; i <= given; i++)
			{

				printf("%c, ", writtenlets[i]);

			}

		}



 /*
 Function conntact reads all necessary informations from person who plays this game( such as	, or category choosen)

 */
void Conntact(char* name)  //USERINTERFACE 
{

	int lost = 0;
	int won = 0;
	char enter = 0;

	printf("\n\n\t\t\t\tWelcome to \n");
	printf("\t\t\t**** BIG HANGEMEN GAME ****\t\t\t\n");

	printf("\n\nWe have some rules\n\n");
	printf("Player, pleas enter your name here ( should be not longer than 20 characters )\n\n");
	gets(name);// reads name 
	printf("\nName: %s", name); // write name 

	Sleep(1000);  //it waits a few secont to give person time
	system("cls");

	printf("\n Nice to meet you %s", name);
	printf("\n\n\t\t\t**** LET'S START THE GAME ****\t\t\t\n");



	Sleep(2000);

	system("cls");

	categories(lost, won); // invoke function  categories
	
	



}

/*
Function write all possible categories, and reads id of choosen by person category ( i variable)

*/

        void categories (int lost, int won) //choosewordcatergory
        {

       int categorynr;

        printf("\nChoose category:\n\n a) Months\t\ttape 1\n\n b) Animals\t\ttape 2\n\n c) Eletronics devices\ttape 3\n\n\n\t "); //write categories

		scanf("%d", &categorynr); //read choosen category

        checkcat(categorynr, won, lost); //invoke function checkcat with choosen id of category 
	
        }


		/* Function responsible for printing name, and score to the text file*/


		void printfscore(int win, int lost, int points)
		{
			//Conntact(); // takes char* witn name of person from function Conntact 
			//categories();

			FILE* fp; // creating file 
			fp = fopen("Hangmen results. txt", "w");// creating file 

			if (fp == NULL)// checking if fille si null fille
			{
				printf("Error opening file!\n");
				exit(1);
			}
			fprintf(fp, "Hello there is your score \n"); // if not writting name to the file

			fprintf(fp, "You have win %d runds\nYou have lost %d runds\nYour sum of points equals: %d", win, lost, points);// Write score to the file


			fclose(fp);  //close file
			return;
		}


