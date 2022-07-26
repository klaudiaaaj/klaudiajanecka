#include "ConnectionElement.h"
#include "Dijkstra.h"


void calculatePaths(Graph * graph,const std::string &startingNode)
{
	ConnectionList * initialConnection;
	int i;
	Node * tempDestinationNode, *processedNode;
	Connection * tempConn;
	Node dummy;
	initialConnection = setInitialNode(graph->firstNode,startingNode); //sets initial node and get his connections 
	for (i = 0;i < initialConnection->length;i++) { //iterate thrue connections, looking for the connection with this node
		tempConn = getConnection(&i, initialConnection); //get single connection
		tempDestinationNode = getNodeByName(graph->firstNode, tempConn->id_number); //get destination node according to connection
		tempDestinationNode->distance = tempConn->distance; //set initial distance
		tempDestinationNode->pathToNode = getNodeByName(graph->firstNode, startingNode); //sets previous on path, we will need it to print 
	}

	do {
		processedNode = getClosestNode(graph->firstNode, &dummy); //get unvisited nodes with cosest path
		processedNode->visited = true;//this node is no more taken to process
		for (i = 0;i < processedNode->connectionList.length;i++) { //iterate thrue all paths
			tempConn = getConnection(&i,&processedNode->connectionList); //get next connection to process
			tempDestinationNode = getNodeByName(graph->firstNode, tempConn->id_number); //get destination node
			if ((tempDestinationNode->distance) > (tempConn->distance + processedNode->distance)) {
				tempDestinationNode->distance = tempConn->distance + processedNode->distance; // set new shortest distance to node
				tempDestinationNode->pathToNode = processedNode; //sets previous node on path
			}
		}
	} while (processedNode->distance != std::numeric_limits<int>::max()); //if there is no node found then distance will be infinite. End of algorithm
}



