#pragma once
#ifndef Dijkstra_h
#define Dijkstra_h

#include "Graph.h"
/**
It is dijkstra alghorithm
@param graph pointer to the first element from the list graph
@param startingNode name of the set node

*/
void calculatePaths(Graph * graph, std::string * startingNode);
#endif