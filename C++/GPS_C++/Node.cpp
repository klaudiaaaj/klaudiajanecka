#include "Node.h"

void addNodeConnection(Connection * connection, Node * node,const std::string & owner) {
		if (node->id_number==owner) { //add connection if node have already belongs to the list
			addConnection(connection, &node->connectionList);
		}
		else {
			if (node->nextNode == nullptr) { //if there is no node with id_number "owner" then create new
				Node * x = new Node;//temp pointer
				x->id_number = owner;
				addConnection(connection, &x->connectionList); //add connection to new node
				node->nextNode = x;
			}
			else {
				addNodeConnection(connection, node->nextNode, owner); //go to next node, till the very end of the list
			}
		return;
		}
}




ConnectionList * setInitialNode(Node * node, const std::string & id_number) {
	int i = 1;
	if (node->id_number==id_number) 
	{  
		node->distance = 0;
		node->visited = true; 
		return &node->connectionList;
	}
	else {
		if (node->nextNode == nullptr) {
			std::cout << "no con" << std::endl;
			return nullptr;
		}
		else {
			return setInitialNode(node->nextNode, id_number); 
		}
	}
}


Node * getClosestNode(Node * node, Node * closest) { //
	if (node->distance < closest->distance && !node->visited) {// in the fist line it always compeare
		closest = node; //
		if (node->nextNode != nullptr) {
			return getClosestNode(node->nextNode, closest);
		}//
		else {
			return closest;
		}
	}
	else {
		if (node->nextNode != nullptr)
		{
			return getClosestNode(node->nextNode, closest);
		}//
		else {//
			return closest; 
		}
	}
}




Node * getNodeByName(Node * node, const std::string id_number) { //loking for the node in the struct node by this id_number
	if (node->id_number==id_number) {
		return node;
	}
	else {
		if (node->nextNode == nullptr) {
			return nullptr;
		}
		else {
			return getNodeByName(node->nextNode, id_number);
		}
	}
}


int printPath(Node * node,std::ofstream &outputStream) { //prints node from last to first
	if (node->pathToNode != nullptr) { //if no more nodes on path then print on retract
		printPath(node->pathToNode, outputStream); //we need to go deeper
		outputStream << node->id_number << " -> "; //print node
		return 0; 
	}
	else {
		outputStream << node->id_number << " -> "; // 
		return 0; 
	}
}

void deletePath(Node* node)
{
	Node* temp = node;
	if (node->pathToNode != nullptr)
	{
		deletePath(temp->pathToNode);
		
		temp = node;
		delete (node);

	}
	else
		delete node;


}
