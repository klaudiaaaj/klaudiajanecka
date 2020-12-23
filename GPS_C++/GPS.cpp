
#include <iostream>
#include <string>
#include "Map.h"
#include "Dijkstra.h"
#include "ConnectionElement.h"

//#include <conio.h>



int main(int argc, char** argv)
{
	try
	{
		if (argc == 7)
		{
			int i;
			std::string startingCity, inputFileDirectory, outputFileDirectory, option;
			for (i = 1; i < argc; i += 2)
			{
				option = argv[i];
				if (option == std::string("-i"))
				{
					inputFileDirectory = argv[i + 1];
				}
				else if (option == std::string("-o")) {
					outputFileDirectory = argv[i + 1];
				}
				else if (option == std::string("-s"))
				{
					startingCity = argv[i + 1];
				}
				else {
					//std::cout << "Invalid parameter: "<< option << " "<< argv[i+1]<< std::endl;
					std::cout << "Parameter list: " << std::endl;
					std::cout << "-i input-file" << std::endl;
					std::cout << "-o output-file" << std::endl;
					std::cout << "-s cityReference" << std::endl;
					throw std::string("Invalid parameter: " + option + " " + std::string(argv[i + 1]));
				}
			}
			/*-i input ?le with a map -o output ?le with routes -s name of a reference point*/
			Map map;
			ConnectionList element;
			loadFromFile(inputFileDirectory, &map);

			calculatePaths(&map, startingCity); //


			resultToFile(map.firstCity, outputFileDirectory);
			/**
			Function opens the output file and prints to file paths from starting city to all destinations
			*@param map.firstcity starting city
			*@param outputFileDirectory output file;
			*/

			deletePaths(map.firstCity);
			/*	deleteElement(element.firstElement);*/

		}
	}
	catch (const std::string & blad)
	{
		std::cout << blad << std::endl;
	}
	catch (...)
	{
		std::cout << "nieznany blad :-)" << std::endl;
	}
	return 0;
}