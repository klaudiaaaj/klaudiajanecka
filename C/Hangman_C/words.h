#ifndef Words_HEADER
#define Words_HEADER

struct Words
{
	char* name;
	char *table[11]; // table with words in the category 

};



void check(char *table,int  won, int lost);
void checkcat(int i, int won , int lost);

#endif
// a small change to check wherever it works 