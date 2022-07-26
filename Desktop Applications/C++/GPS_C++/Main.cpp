#include <iostream>
#include <string>
#include "Graph.h"

#include "Dijkstra.h"
#include "ConnectionElement.h"
#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
#include <crtdbg.h>


int main(int argc, char** argv)
{
	std::string startingNode, inputFileDirectory, outputFileDirectory, option;
	//try
	//{
	//	if (argc == 7)
	//	{
	//		int i;
	//		
	//		for (i = 1; i < argc; i += 2)
	//		{
	//			option = argv[i];
	//			if (option == std::string("-i"))
	//			{
	//				inputFileDirectory = argv[i + 1];
	//			}
	//			else if (option == std::string("-o")) {
	//				outputFileDirectory = argv[i + 1];
	//			}
	//			else if (option == std::string("-s"))
	//			{
	//				startingNode = argv[i + 1];
	//			}
	//			else {
	//				//std::cout << "Invalid parameter: "<< option << " "<< argv[i+1]<< std::endl;
	//				std::cout << "Parameter list: " << std::endl;
	//				std::cout << "-i input-file" << std::endl;
	//				std::cout << "-o output-file" << std::endl;
	//				std::cout << "-s nodeReference" << std::endl;
	//				throw std::string("o: " + option + " " + std::string(argv[i + 1]));
	//			}
	//		}
	inputFileDirectory = "C:/Users/48573/Documents/nodes.txt";
	outputFileDirectory = "C:/Users/48573/Documents/output_file.txt";
	/*-i input ?le with a map -o output ?le with routes -s name of a reference point*/
	startingNode = "3";
	Graph graph;
	ConnectionList element;
	loadFromFile(inputFileDirectory, &graph);

	calculatePaths(&graph, startingNode); //


	resultToFile(graph.firstNode, outputFileDirectory);
	

	deletePaths(graph.firstNode);

	/*	deleteElement(element.firstElement);*/

	deleteConnections(element.firstElement);


	/*catch (const std::string & blad)
	{
		std::cout << blad << std::endl;
	}
	catch (...)
	{
		std::cout << "nieznany blad :-)" << std::endl;
	}
	cout << "im there"; */
	return 0;
	_CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);
	return 0;
}