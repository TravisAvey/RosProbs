#include <iostream>
#include <vector>
#include <map>
#include <fstream>

/*
 * A very simple Graph.  Only need to add
 * the edges.
 * Map => vertex : list of connections to it
 */
class Graph
{
private:
    // private map to hold node and a list of connections
    std::map<int, std::vector<int> > g;

public:
    /*
     * Method that adds the edges.  It's un-directional,
     * so add to both
     */
    void Add(int nodeA, int nodeB)
    {
        g[nodeA].push_back(nodeB);
        g[nodeB].push_back(nodeA);
    }

    /*
     * Method that gets how many connection each node
     * has
     */
    unsigned long GetEdges(int node)
    {
        return g[node].size();
    }
};

int main()
{
    // file stream for file containing the graph
    std::fstream file("rosalind_deg.txt", std::ios::in);

    // initialize variables to hold the no. nodes, and the vertex and edge
    int nodes = 0, n = 0, vertex = 0, edge = 0;

    // init the Graph ADT
    Graph G;

    // if the file is opened
    if (file)
    {
        // get the first two digits from the file
        // using a vector, so disregarding second
        file >> nodes;
        file >> n;

        // while we can get data from the file,
        // add the vertex and edge to the Graph
        while (file >> vertex >> edge)
            G.Add(vertex, edge);

    }

    // close the file
    file.close();

    // loop through the each node and output the amount of
    // connections each node has
    for (int i=1; i<=nodes; ++i)
        std::cout << G.GetEdges(i) << ' ';

    return 0;
}