#pragma once
#pragma once
#ifndef Graph_h
#define Graph_h
#include "Node.h"
#include <string>
#include <iostream>
#include <fstream>


/**Struct Graph
This structure contain inside struct Node.This is list of the Nodes
@param Node* first Node is the pointer to the fist element of the Node list
@param nodeCount is the counter of the nodes at the list
*/
struct Graph {
	Node * firstNode = nullptr;
	int nodeCount=-1;
};
/**loads data from file to data structure
*@param inputFileDirectory input file
*@param graph struct
		*/

void loadFromFile(const std::string & directory, Graph * graph);
/** It bases at the same as function inilizeGraphLoading.
But it is not only for the fist element. That why it doesnt create first element in the list graph
If there is end of file program deletes conn1 and conn2, to avoid memory leaks.
The same situation when distance is less than zero, and after invoking addNodeConnections with this param.
@inputStream inputfile
@graph pointer to the fisrt element from the list
*/

bool loadSingleLine(std::ifstream &inputStream, Graph * graph);

/** Function sets first node on graph and adds connections, loads the dirst names from the file.
It invokes inside itsself function addNodeConnection as for con1, as for con2 because, connections are equal.
If there is end of file program deletes conn1 and conn2, to avoid memory leaks.
The same situation when distance is less than zero, and after invoking addNodeConnections with this param.
@param inputStream input file
@param graph pointer to the first element of the list Graph
*/

bool inilizeGraphLoading(std::ifstream &inputStream, Graph * graph);

/**(calculate distances between starting node and all others
*@graph graph struct
*@startingNode Node from which program looks for the connections;
 */


void calculatePaths(Graph * graph, const std::string & startingNode);

/**
This function prints the elements the main nodes from the connection list.
It prints the start node, and its final destination. Inside function invokes function ,,PrintPah"
@param Node* node node from wchich it prints destinations.
@param outputStream it is output file in which it prints answerwas
**/

void printPaths(Node * node, std::ofstream &outputSstream);
/**
			Function opens the output file and prints to file paths from starting node to all destinations
			*@param node starting node
			*@param outputSstream output file;
			*/

void resultToFile(Node * node, std::string &directory);
/**
			Cleans struct graph
			*@param graph.fistNode
			*/

void deletePaths(Node * node);
/* Cleaning stuct ConnectionElement
*@param pHead pointer to the fist element of the list
*/
void deleteConnections(ConnectionElement * pHead);


#endif
