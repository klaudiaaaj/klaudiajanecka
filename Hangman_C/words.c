#pragma warning(disable : 4996)
#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <stdbool.h>
#include <time.h>
#include<dos.h>
#include <conio.h>
#include <stdbool.h>
#include "words.h"
#include "makegame.h"
#include <conio.h>
#include <windows.h>
#include "interface.h"



//  struct alphabet *head=NULL;
 /* Function which starts the game, by giving word  */
void check(char *table, int won, int lost)// checkwordlengh
{


    int  mysize=0;


	mysize = strlen(table);

  if( mysize!=0)
  makegame(table,  mysize, won, lost);
  else check(table, won, lost);
}

void checkcat(int i, int won, int lost)
{

		struct Words Animalss = { "Animals",{"ELEPHANT", "MONKEY", "TIGER", "GIRAFFE", "OCTOPUS", "CHIMPANZEE","SQUIRREL", "HIPPOPOTAMUS", "KANGAROO", "GOLDFISH","\0" } };
		struct Words Monthss = { "Months", {"JULY", "AUGUST", "OCTOBER", "MAY", "JUNE" ,"SEPTEMBER", "JULY", "DECEMBER", "FEBRUARY ", "JANUARY", "\0"} };
		struct Words Electronic_devicess = { "Electornic devices", {"TELEVISION", "IRON", "PHONE", "ROUTER", "PRINTER", "TRACKBALL", "WATCH", "ALARM", "LAMP", "DVD", "\0"} };
			//3 objects of the structure words


		time_t t; 
		srand((unsigned)time(&t));
		 /*  
		 Switch in case of number of category given by user
		 */
		switch (i)
		{
		case 1:
			{
			 int number = rand() % 10;

			check(Monthss.table[number], won,lost );
		break;
			}
		case 2:
		{ int number = rand() % 10;
			check(Animalss.table[number], won ,lost);
			break;
		}
		case 3:

			{ int number = rand() % 10;
			check(Electronic_devicess.table[number], won, lost);
			break;
			}
	
		}
}
