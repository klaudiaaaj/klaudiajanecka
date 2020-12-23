
#include "ConnectionElement.h"


void addConnectionElement(ConnectionElement * elementPointer, Connection * element)
{
	if (elementPointer->nextElement == nullptr) {
		ConnectionElement * newElement = new ConnectionElement;
		newElement->element = *element;
		elementPointer->nextElement = newElement;
	}
	else {
		addConnectionElement(elementPointer->nextElement, element);
	}
}

Connection * getConnectionElement(ConnectionElement * elementPointer, int * index, int i)
{ 
  
	if (*index != i) {
		i += 1;
		return getConnectionElement(elementPointer->nextElement, index, i);
	}
	else {
		return &elementPointer->element;
	}
		
}

