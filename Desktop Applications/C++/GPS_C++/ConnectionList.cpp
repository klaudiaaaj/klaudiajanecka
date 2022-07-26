
#include "ConnectionList.h"

void addConnection(Connection * element, ConnectionList * list) {
	if (list->firstElement == nullptr) {
		ConnectionElement * x = new ConnectionElement;
		x->element = *element;
		list->firstElement = x;
	}
	else {
		addConnectionElement(list->firstElement, element);
	}
	list->length++;
}

Connection * getConnection(int * position, ConnectionList * list) {
	if (list->length > * position)
	{
		int i = 0;
		return getConnectionElement(list->firstElement, position, i);
	}
	else
		throw "NullPointerException: index out of range";
}


