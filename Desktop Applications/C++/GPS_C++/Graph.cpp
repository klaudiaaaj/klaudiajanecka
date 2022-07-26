
#include <string>

#include "Graph.h"
#include "Connection.h"
#include "ConnectionElement.h"
#include "ConnectionList.h"
#include <fstream>

void loadFromFile(const std::string & directory, Graph * graph)
{
	//destroy old 

	int failtureCounter = 0, line = 0;
	bool initialized = false;
	std::ifstream inputStream;

	inputStream.open(directory);
	if (!inputStream.is_open()) throw "Non existing file / file corrupted";
	while (!(inilizeGraphLoading(inputStream, graph) || inputStream.good()))
	{ //initialize graph, if initialisation is correct then break the loop or if eof is reached
		//it adds the first node
		line++;
		failtureCounter++;
		std::cout << "Invalid connection detected and skipped. No: " << failtureCounter << ". Line: " << line << ".\n";
	}
	while (inputStream.good())
	{
		line++;
		if (!loadSingleLine(inputStream, graph)) { //load single data line to structure and check if data is correct
			failtureCounter++;
			std::cout << "Invalid connection detected and skipped. No: " << failtureCounter << ". Line: " << line << ".\n";


			if (inputStream.eof())
				break;
		}

	}

}



bool inilizeGraphLoading(std::ifstream &inputStream, Graph * graph) {//
	Connection * con1 = new Connection;
	Connection * con2 = new Connection;
	inputStream >> con1->id_number >> con2->id_number >> con1->distance; // loading the fiirst names of the nodes from the file
	if (inputStream.eof()) {
		delete con1;
		delete con2;
		return true; //if eof then stop read that line is corrupted
	}
	if (con1->distance < 0) {
		delete con1;
		delete con2;
		return false; //line corrupted
	}
	con2->distance = con1->distance;//adding the same distance to con2,because is equal
	graph->firstNode = new Node;
	graph->firstNode->id_number = con1->id_number; //create first node in array
	addNodeConnection(con1, graph->firstNode, con2->id_number); //add connection / node to graph
	addNodeConnection(con2, graph->firstNode, con1->id_number); //add connection / node to graph //it is added in both sides 
	delete con1;
	delete con2;
	return true;
}


bool loadSingleLine(std::ifstream &inputStream, Graph * graph) { //loads single line from file and sets connection
	Connection * con1 = new Connection;
	Connection * con2 = new Connection;
	inputStream >> con1->id_number >> con2->id_number >> con1->distance; //read line
	if (inputStream.eof()) {
		delete con1;
		delete con2;
		return true; //if eof then stop read that line is corrupted
	}
	if (con1->distance < 0) {
		delete con1;
		delete con2;
		return false; //line corrupted
	}
		
	con2->distance = con1->distance; // coppy distance to pair connection
	addNodeConnection(con1, graph->firstNode, con2->id_number); //add connection / node to graph
	addNodeConnection(con2, graph->firstNode, con1->id_number); //add connection / node to graph
	delete con1;
	delete con2;
	return true; //line is correct
}

void printPaths(Node *node, std::ofstream &outputSstream)
{
	if (node->pathToNode != nullptr) {
		printPath(node->pathToNode, outputSstream);
		outputSstream << node->id_number;
		outputSstream << ": " << node->distance << std::endl;
	}
	if (node->nextNode != nullptr) {
		printPaths(node->nextNode, outputSstream);
	}
	return;
}

void resultToFile(Node * node, std::string &directory) {
	std::ofstream outputStream;
	outputStream.open(directory);
	if (!outputStream.is_open()) throw "Non existing file / file corrupted";
	printPaths(node, outputStream);
}

void deleteConnections(ConnectionElement * pHead)
{
	if (pHead)
	{
		deleteConnections(pHead->nextElement);
		delete pHead;
	}
}

void deletePaths(Node * node)
{
	Node * temp = node;
	while (temp)
	{
		deleteConnections(temp->connectionList.firstElement);
		auto todelete = temp;
		temp = temp->nextNode;
		delete todelete;
	}
}