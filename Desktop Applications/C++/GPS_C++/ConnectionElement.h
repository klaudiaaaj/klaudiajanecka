#pragma once
#ifndef ConnectionElement_h
#define ConnectionElement_h
#include "Connection.h"
 /**
 Struct which contains Connection struct inside, and pointer to the next element of the list of the connecions in the COnnection struct
 @param ConnecionElement * nextElement pointer to the next Connection
 @param element is element of the struct Connection
 */
struct ConnectionElement {
	ConnectionElement * nextElement = nullptr;
	Connection element;
};
/** In case when elementPointer is at the end of the connection list, fucntion adds element to the list of connectonions.
*In other case function recursevly goes to the end of the list and adds alement at the end.
@param elementPointer pointer to the first element from the list
@param element pointer to the connection element
*/
void addConnectionElement(ConnectionElement * elementPointer, Connection * element);


/**
Function is initiated with 
int- current, with value of 1.
Recurevely it goes throw the list, as long as current will be equal to given index.
Thanks that, pointer will be at the given by index position at the list of connections.
@param elemenPointer pointer to the first element from the list
@param index given index of connection
@param current new int, temporary int equal to 0
*/

Connection * getConnectionElement(ConnectionElement * elementPointer, int * index, int i);

#endif