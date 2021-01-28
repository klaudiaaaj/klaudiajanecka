#pragma once
#ifndef ConnectionList_h
#define ConnectionList_h
#include "ConnectionElement.h"
#include <iostream>
/*
Stuct which contain the amouth of the elements and pointer to the first element of the ConnectionElement struct;

*/
struct ConnectionList {
	ConnectionElement * firstElement = nullptr;
	int length = 0;
};

void addConnection(Connection * element, ConnectionList * list);



/**
Funtions checks if it is possible to find node with given index.
It checks if idnex is smaller than list lenght
@param position index of the position in the list
@param list list of Connections ot the node
*/

Connection * getConnection(int * position, ConnectionList * list);



#endif // ConnectionList_h