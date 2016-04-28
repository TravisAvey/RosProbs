using System;
using System.IO;
using System.Collections.Generic;

namespace DoubleDegreeArray
{
	/*
	 * 	Simple Graph data structure using adjacency list
	 */ 
	class Graph
	{
		// Dictonary to hold node and a list of what it's connected to
		Dictionary <int, List<int> > g = new Dictionary<int, List<int> >();
		// variable to hold number of nodes
		int nodes;

		// public constructor with # nodes
		public Graph(int nodes)
		{
			// set nodes
			this.nodes = nodes;
			// init the Dictionary
			InitKeys ();
		}

		/*
		 * 	This method initializes the keys in the Dictionary
		 */ 
		private void InitKeys()
		{
			// for each node, set the key and create a list
			for (int i=1; i<=nodes; ++i)
				g.Add(i, new List<int>());
		}

		/*
		 * 	This method allows the user to add the edges
		 */ 
		public void Add (int v, int w)
		{
			// declare a list
			List<int> vList;
			// if the dictionary doesn't have this v (key)
			if (!g.TryGetValue (v, out vList)) 
			{
				// init the new list
				vList = new List<int> ();
				// add the node and the empty list
				g.Add (v, vList);
			}
			// regardless (if list created this time or before)
			// add the value to the corresponding key
			g [v].Add (w);

			// repeat above for other node
			List<int> wList;
			if (!g.TryGetValue (w, out wList)) 
			{
				wList = new List<int> ();
				g.Add (w, wList);
			}
			g [w].Add (v);
		}

		/*
		 * 	This method returns the count of the node passed in
		 */ 
		private int GetEdgeCount(int i)
		{
			// return the count of edges, where i = node
			return g [i].Count;
		}

		/*
		 * 	This method gets the sum of neighbors for each node
		 */ 
		public void GetSumDegree()
		{
			// loop through each node
			for (int i=1; i<=nodes; ++i)
			{
				// init sum counter
				int sum = 0;

				// get the current node's neighbors
				List<int> neighbors = g [i];

				// get the sum of each
				foreach (int n in neighbors)
					sum += GetEdgeCount (n);

				// write out to console
				Console.Write ("{0} ", sum);
			}
		}

	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			// open the file
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/DoubleDegreeArray/data.txt",
			                           FileMode.Open, FileAccess.Read);

			// use a stream reader on the file
			using (var reader = new StreamReader(file))
			{
				// get first line, contains # nodes and # edges
				string line = reader.ReadLine ();
				List<int> toks = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse));
				int nodes = toks [0];
				int edges = toks [1];

				// init new Graph
				Graph g = new Graph (nodes);

				// for the number of edges, get the edges from the file
				for (int i=0; i<edges; ++i)
				{
					line = reader.ReadLine ();
					List<int> tokens = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse));
					g.Add (tokens [0], tokens [1]);
				}

				// call the method to get the sum of each node's neighbor
				g.GetSumDegree ();

			}
		}
	}
}
