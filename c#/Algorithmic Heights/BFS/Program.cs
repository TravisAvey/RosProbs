using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace BFS
{
	class MainClass
	{
		/*
		 * 	Simple DiGraph, Adjacency List
		 */ 
		class DiGraph
		{
			// var for number of nodes
			private int nodes;
			// dictionary to hold the list for each node: Key-> node, value-> list of connected nodes
			private Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
			// array to hold the distance of each node from origin
			private int[] distance;

			// public constructor
			public DiGraph(int nodes)
			{
				// set number of nodes
				this.nodes = nodes;
				// init distance array, +1 b/c rosalind starts with 1
				distance = new int[nodes+1];
				// call helper method to init the Graph
				InitGraph();
			}

			/*
			 * 	helper method to set up the graph and distance
			 * 	array
			 */ 
			private void InitGraph()
			{
				// set each key in the graph to new list
				for (int i=1; i<=nodes; ++i)
					graph.Add (i, new List<int> ());

				// set each distance to -1 to start
				for (int j=0; j<=nodes; ++j)
					distance [j] = -1;
			}

			/*
			 * 	Method that returns the distance from
			 * 	the origin to the value v passed in
			 */ 
			public int distanceTo(int v)
			{
				return distance [v];
			}

			/*
			 * 	Method to Add node connection.  V is node,
			 * 	and w is node connected to
			 */ 
			public void Add(int v, int w)
			{
				// v -> edge; w -> node points to
				// 4 -> 6, this node (4) is directed to 6

				// create a new list
				List<int> list;

				// check if the graph doesn't have the value
				if (!graph.TryGetValue(v, out list))
				{
					// init new list
					list = new List<int> ();
					// add the list
					graph.Add (v, list);
				}
				// now we add the the value to the list for the key
				graph [v].Add (w);
			}

			/*
			 * 	The BFS method.  Value passed in is the
			 * 	target we are searching for from the origin
			 */ 
			public void BFS(int tar)
			{
				// init new array to keep track where we've been
				bool[] marked = new bool[nodes+1];

				// init a Queue, which is necessary for BFS
				// (DFS uses a Stack instead)
				Queue<int> q = new Queue<int> ();

				// mark first explored
				marked [1] = true;
				// set the distance of first to 0
				distance [1] = 0;

				// add the first one to the Queue
				q.Enqueue (1);

				// while we still have nodes in the Queue
				while (q.Count > 0)
				{
					// get the last node (used to get distance)
					int v = q.Peek();
					// get the list of connected components
					List<int> conns = graph [q.Dequeue ()];

					// loop through each node in the connections
					foreach (int n in conns)
					{
						// if they aren't yet visited
						if (!marked[n])
						{
							// get the distance of the last node + 1
							// this is how the dist is calculated
							// the last node corresponds the distance
							// from the origin, + 1 for this level
							distance [n] = distance [v] + 1;
							// set this node to visited
							marked [n] = true;
							// add to queue
							q.Enqueue (n);
						}
					}
				}
			}

			/*
			 * 	Test method to check the DiGraph
			 */ 
			public void GetInfo()
			{
				// loop through each node
				for (int i=1; i<=nodes; ++i)
				{
					// get the list of connectinos
					List<int> connections = graph [i];

					// if none:
					if (connections.Capacity == 0)
						Console.WriteLine ("{0} doesn't have any connections", i);
					else
					{
						// else, we loop through each node in the connection and output connections
						foreach (int n in connections)
							Console.Write ("{0}->{1} ",i, n);
						Console.WriteLine ();
					}
				}
			}
		} // end DiGraph Class


		/*
		 * 	Helper method to print the data output to a file
		 */ 
		private static void PrintToFile(ref List<int> A)
		{
			// open a file stream with access of write
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/BFS/output.txt",
			                           FileMode.Open, FileAccess.Write);

			// using a stream writer on the file stream
			using (var writer = new StreamWriter(file)) 
			{
				// write each value to the file
				foreach (int a in A)
					writer.Write("{0} ", a);
			}
		}

		public static void Main (string[] args)
		{
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/BFS/rosalind_bfs.txt",
			                          FileMode.Open, FileAccess.Read);

			using (var reader = new StreamReader(file))
			{
				// first line is how many nodes, and how many edges
				string line = reader.ReadLine ();
				// create array to hold nodes and edges
				int[] data = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse)).ToArray ();
				int nodes = data [0];
				int edges = data [1];

				// create new diGraph object
				DiGraph diGraph = new DiGraph(nodes);

				// for each # of edges
				for (int i=0; i<edges; ++i)
				{
					// read the line
					line = reader.ReadLine ();
					// array to hold the node and and connected node
					int [] tokens = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse)).ToArray ();
					// add the items to the diGraph
					diGraph.Add (tokens [0], tokens [1]);
				}

				// create a list to hold the results output
				List<int> results = new List<int> ();

				// Breadth First Search on each Node
				for (int i=1; i<=nodes; ++i)
					diGraph.BFS (i);

				// get the distance from origin to each node
				// since we init that array to -1: if no way
				// to node we will get -1
				for (int i=1; i<=nodes; ++i)
					results.Add (diGraph.distanceTo (i));

				// print the results to the file
				PrintToFile (ref results);

			}
		}
	}
}
