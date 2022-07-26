#pragma warning(disable : 4996)
#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
#include <crtdbg.h>
#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

#include <dos.h>
#include <conio.h>


#include <conio.h>
#include <windows.h>

#include "makegame.h"
#include "words.h"

#include "interface.h"



#define maxnamelenght 20



int _CrtDumpMemoryLeaks(void);
 
int main()
{


	// reserving memory for the name of player
	
	char *name = malloc(sizeof(char) * maxnamelenght);
	Conntact(name);// connects with interface of a game 

	free(name);

_CrtDumpMemoryLeaks();

    return 0;
}

