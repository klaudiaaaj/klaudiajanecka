#pragma once
#ifndef Connection_h
#define Connection_h
#include <string>
/** It struct which contain iformations about connections.
@param distance between nodes
@param name name of connected node
*/
struct Connection {
	int distance = -1;
	std::string id_number = "";
};

#endif //Connection_h
