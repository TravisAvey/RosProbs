using System;
using System.IO;
using System.Collections.Generic;

namespace ConnectedComponents
{
	/*
	 * 	Simple ADT undirected Graph class
	 */ 
	class Graph
	{
		// number of nodes
		private int nodes;
		// the structure to hold the graph: dict of node with a list of connections to that node
		private Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
		// array to test if we have visited node when traversing graph
		private bool[] marked;
		// the count of connected components
		private int count;

		// Constructor, number of nodes for graph
		public Graph(int nodes)
		{
			// set the number of nodes
			this.nodes = nodes;
			// init count to 0
			count = 0;
			// int makred array (+1 b/c rosalind starts at 1)
			marked = new bool[nodes + 1];

			// call method to set up graph
			InitGraph ();
		}

		// helper method to set up graph
		private void InitGraph()
		{
			// set each key in the graph to new list
			for (int i=1; i<=nodes; ++i)
				graph.Add (i, new List<int> ());
		}

		// Count Property
		public int Count
		{
			// getter only: return number of connected components
			get {return count;}
		}

		/*
		 * 	Method to add an edge.  Moved all the overhead
		 *  that was needed here to Creation of the Graph
		 *	object upon initialization.  Don't need to try
		 *	because each key 1-node # was set up with a new
		 *	list in InitGraph()
		 */ 
		public void Add(int v, int w)
		{
			// undirected graph: add edge for both
			graph [v].Add (w);
			graph [w].Add (v);
		}

		/*
		 * 	The Depth First Search method.
		 * 	This version uses recursion vs using
		 * 	a stack.  (DFS with a stack is the same
		 * 	as BFS)
		 */ 
		private void DFS(int v)
		{
			// mark the passed in node as visited
			marked [v] = true;

			// get the list of connections
			List<int> conns = graph [v];

			// loop through each connection
			foreach(int w in conns)
			{
				// if we haven't visited, recurse on that node
				if (!marked [w])
					DFS (w);
			}
		}

		/*
		 * 	Public interface to get the number of 
		 * 	connected components
		 */ 
		public void connectedComponents()
		{
			// loop through each node in Graph
			for (int i=1; i<=nodes; ++i)
			{
				// if not visited
				if (!marked[i])
				{
					// call depth first search
					DFS (i);
					// once done inc count (this only incerments
					// on the number of connected components)
					count++;
				}
			}
		}

		/*
		 * 	Helper method to display the graph && debugging
		 */ 
		public void PrintGraph()
		{
			// loop through each node
			for (int i=1; i<=nodes; ++i)
			{
				// get the list of connectinos
				List<int> connections = graph [i];

				if (connections.Count == 0)
					Console.Write ("{0} has no connections", i);

				foreach (int n in connections)
					Console.Write ("{0}->{1} ",i, n);
				Console.WriteLine ();

			}
		}

	} // end class Graph


	class MainClass
	{

		public static void Main (string[] args)
		{
			// open the file using a filestream
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/ConnectedComponents/rosalind_cc.txt",
			                           FileMode.Open, FileAccess.Read);

			// use a stream reader on the opened file
			using (var reader = new StreamReader(file))
			{
				// get the first line: contains the # nodes & # edges
				string line = reader.ReadLine ();

				// get the data into proper variables
				int[] data = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse)).ToArray ();
				int nodes = data [0];
				int edges = data [1];

				// create new Graph object
				Graph graph = new Graph(nodes);

				// loop through the number of edges
				for (int i=0; i<edges; ++i)
				{
					// get each line containing the node & conn. node
					line = reader.ReadLine ();
					// split into array
					int[] tokens = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse)).ToArray ();
					// add the nodes to the graph
					graph.Add (tokens [0], tokens [1]);
				}

				// call method to get the number of components
				graph.connectedComponents ();
				// output components
				Console.WriteLine (graph.Count);

			}
		}
	}
}
