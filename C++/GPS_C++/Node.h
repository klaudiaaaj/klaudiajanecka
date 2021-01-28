#pragma once
#ifndef Node_h
#define Node_h
#include "ConnectionList.h"
#include <string>
#include <fstream>
/**
Struct with informations about node.
@param Node* nextNode  the pointer to the next node from the list of nodes.
@param connectionList  necked sturct ConnectionList inside struct Node
@param name  sting with name of the node
@param visited  boolean with if informations if node has been visited or nor
@param distance distance witten to the Node. Initiali is max intiger, beacuse in dijkstra algorithm not visited nodes has set infite distance.
@param pathToNode pointer to the node's paths
*/
struct Node {
	Node * nextNode = nullptr;
	ConnectionList connectionList;
	std::string id_number;
	bool visited = false;
	int distance = std::numeric_limits<int>::max();
	Node * pathToNode = nullptr;
};
/** At the begin it checks if set node belongs already to the list. If yes it switches AddConnection function. 
*If not it adding Node at the end of the list, then switches function AddConnection
*@param connection 
@param node
@param owner
*/
void addNodeConnection(Connection * connection, Node * node,const std::string & owner);

/**
Sets initial node for pathfind algorithm ( checking if the name is equal name of the sting)
Function sets distance equal zero, because it is said in dijkstra argorithm for the first node.
Function sets that fist node is visited.
algorithm critical error, list after curretnt node is empty
recursive looking for the start node from the list, if the pointer is not at this node
		
@param node pointer to the first element from the list
@param name is the name of start node
*/
ConnectionList * setInitialNode(Node * node,const std::string & name);

//void setInitialDistances(Node * node, Node * conn);
/**
get node with shortest distance from starting point
closest is dummy
store node with shortest distance
we need to go deeper
/if no more element then return current closest
we need to go deeper recurevly
//if no more element then return current closest
@param node pointer to the first node from the list
@param closes is the tempolary node

*/
Node * getClosestNode(Node * node, Node * closest);
/**
Function looks for the node in the stuct node, using its name. It returns node.
@param node pointer to the fist element from the list
@param name name of a searched node
*/
Node * getNodeByName(Node * node, std::string name);
/**
prints nodes from last to first
if no more nodes on path then print on retract
we use recursin beacuse we need to go deeper need to go deeper
@param node node which connections are printed, pointer to the first node form the list
@outputSstream output file
*/
int printPath(Node * node, std::ofstream &outputStream); 
/**
Function disalocates memory
@node pointer to the first element from the list
*/
void deletePath(Node* node);
#endif