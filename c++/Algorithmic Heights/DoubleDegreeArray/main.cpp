#include <iostream>
#include <map>
#include <vector>
#include <fstream>

/*
    Simple Graph ADT.  Undirected Graph
    Only need to add nodes, get the edge count for
    each node, and get the sum of degrees of each node
*/
class Graph
{
private:
    // simple ADT to hold the graph
    std::map<int, std::vector<int> > g;
    // the number of nodes
    int nodes;
    
    // private method to get the number of edges attached to node
    unsigned long GetEdgeCount(int node)
    {
        return g[node].size();
    }
    
public:
    
    // method to add in the nodes: where a is connected to b
    void Add(int a, int b)
    {
        g[a].push_back(b);
        g[b].push_back(a);
    }
    
    /*
        This method gets the sum of degree of each neighbor
        and prints out the answer for all nodes
    */
    void GetSumDegree()
    {
        // go through each node
        for (int i=1; i<=nodes; ++i)
        {
            unsigned long sum = 0;
            // for each node get neighbors
            std::vector<int> neighbors = g[i];
            // sum up count of each neighbor
            for (int n : neighbors)
                sum += GetEdgeCount(n);
                
            std::cout << sum << ' ';   
        }
    }
    
    // setter for the number of nodes
    void SetSize(int s)
    {
        nodes = s;
    }
};

int main()
{
    // open file for processing
    std::fstream file("rosalind_ddeg.txt", std::ios::in);
    // Graph object
    Graph G;
    variables to hold data
    int nodes = 0, n = 0, vertex = 0, edge = 0;
    
    // if file is opened
    if (file)
    {
        // get number of nodes (n is a throw away: number of edges)
        file >> nodes;
        file >> n;
        
        // set the number of nodes
        G.SetSize(nodes);
        
        // grab the vertex and edge for each node
        while (file >> vertex >> edge)
            G.Add(vertex, edge);
    }
    
    // close file, done
    file.close();
    
    // Call public method to print out the sum of degrees for each neighbor
    G.GetSumDegree();
        
    return 0;
}