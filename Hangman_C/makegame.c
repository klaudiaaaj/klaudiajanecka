#pragma warning(disable : 4996)
#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <stdbool.h>
#include<dos.h>
#include <conio.h>
#include <stdbool.h>
#include "words.h"
#include <conio.h>
#include <windows.h>
#include "makegame.h"
#include "interface.h"





 /* this function is main function operating the game hangemen*/
int makegame(char* random, int size, int won, int lost)
{

	// bool torf=false;//checking if letter is in the word
	int counterfalse = 11; // counter of wrong given letters
	int points = 0; // points at the begining of the round
	int countertrue = 0; // variable counting correctly given letters
	int givenletcounter = 0; //it is variable which counts given letters ( apart from the letter which were already given, to avoid doubling )
	char a[100]; // is a array of all placed character ( even they are repeated)
			int acounter = -1;// starts form the -1, because it increments at the beginning 
			int error = 0;


				char *writtenles = malloc(sizeof(int) * (10*size));  //allocating memory for the table wit given h letters
				char *rubish = malloc(sizeof(int) * (10*size)); // array with all given letter. Is usefull to check if new letter which is onlu in the "a" array, is not already in the "rubish" array
				char *taboflet= malloc(sizeof(int) * (10 * size));
				rubish[0] = "";
	

	// at the begining it would be fullfil by the "_"

		for (int i=0; i< size ; i++)
		{

			taboflet[i]=95;

		}


		while ((counterfalse != 14) && (countertrue != size)) //condition checking if player should have another chance to guest letter ( if the amouth of mistakes is not bigger than 14, and if the word has not been already guested)
		{
			bool torf = false;
			//int torf = 0; //its like boolean variable. When it is equal to 0, it means that given letter is not correct, otherwise it is changed to 1. 
			acounter++;
			error = 0;



					printf("\n\n\tPlease, give one capital letter   ");

					scanf("%s", &a[acounter]);
					for (int n = 0; n <= acounter; n++)
					{
						if (rubish[n] == a[acounter])
							error = 1;
					} 
					
	
					rubish[acounter] = a[acounter];

					if (error == 0)

					{
						writtenles[givenletcounter] = a[acounter];
						for (int i = 0; i < size; i++)
						{
							char tempchar; // its template character
							tempchar = random[i];
							if (tempchar == a[acounter])
							{
								points++;
								printf("\n YOU ARE RIGHT");
								printf("\n %c is correct", a[acounter]);
								taboflet[i] = a[acounter];
								torf = 1;
								countertrue += 1;
								Sleep(1000);
								hangman(counterfalse, taboflet, size, writtenles, givenletcounter);
								printf("\n");

							
							}

						}

						if (torf == 0)
						{
							counterfalse++;
							points--;
							printf(" \n\nYou are not right - %d point(s)", counterfalse);
							Sleep(1000);
							hangman(counterfalse, taboflet, size, writtenles, givenletcounter);

							if (counterfalse == 14)
							{

								printf("\n\t\t G A M E   O V E R  ");


								printf("\n\n\t\t Answer was  ");


								for (int j = 0; j < size; j++)
								{

									printf("   %c", random[j]);
								}
								printf("\n\n");


								lost++;



							}
						}
						givenletcounter++;
					}
					else
					{
						printf("YOU HAVE ALREADY GIVEN THIS LETTER!!");

					}
	
					a[acounter] = "";
	
				}
					

			

				if (countertrue==size)
				{
					won++;
					printf("\n\n\n\t Congratulations you have won big HANGMEN GAME!!");

				}
				
				free(taboflet);
				free(writtenles);
				free(rubish);
		

				printf("\n\n\n\tIf you want play again please tap 1, otherwise 0\n");
			
			 
					int like;
					scanf("%d", &like);
					if (like == 1)
						categories(lost, won);
					else
					{
				
						printf("\n\n\n\tThank you for participation. Have a nice day :)");

						printf("\n\n\n\t You can find your results in file called 'Hangmen results' ");

						printfscore(won, lost, points);

						Sleep(100);
						return 0;
					}

						
        


		
		


}


