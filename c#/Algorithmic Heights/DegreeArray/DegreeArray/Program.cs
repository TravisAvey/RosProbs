using System;
using System.IO;
using System.Collections.Generic;

namespace DegreeArray
{
	/*
	 *  Simple Graph ADT
	 * 	Method to add nodes and to get a count of edges
	 */ 
	class Graph
	{
		// Dictionary (c# ~ of c++ map) to hold the graph's data
		Dictionary<int, List<int>> g = new Dictionary<int, List<int>>();

		/*
		 *	This method takes in two nodes that are connected
		 *	It will add the edge to both nodes
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
		 * 	In my C++ version, the count was good
		 * 	In C#, the count is doubled because of above method.
		 * 	Removing the second part causes errors, because the key
		 * 	wasn't created in some cases
		 */ 
		public int GetEdges(int v)
		{
			// doubled, so return half
			return g [v].Count / 2;
		} 
	}

	class MainClass
	{

		public static void Main (string[] args)
		{
			// file stream, mode: open, access: read only
			var file = new FileStream ("/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/DegreeArray/DegreeArray/dataset.txt", 
			                           FileMode.Open, FileAccess.Read);
			// number of nodes
			int nodes;
			// create a new Graph
			Graph graph = new Graph ();

			// using a stream reader on the file opened
			using (var reader = new StreamReader(file)) 
			{
				// get the first line, contains the nodes and number of edges (throw away edges)
				string line = reader.ReadLine();
				// create a list of tokens, to parse the line and split on ' ' parsing to an int
				List<int> tokens = new List<int> (Array.ConvertAll(line.Split(' '), int.Parse));
				// the first item is our number of nodes
				nodes = tokens [0];

				// while the reader can read a line
				while ((line = reader.ReadLine()) != null) 
				{
					// an array of items split by a ' ' from the current line (should be 2!)
					string[] toks = line.Split (' ');
					// for each item in toks, add to the graph
					foreach (string a in toks)
						graph.Add (int.Parse(toks [0]), int.Parse(toks [1]));

				}
			}

			// loop through all nodes and output the number of edges for each node
			// starting at 1, because dataset doesn't start at 0 but 1
			for (int i=1; i<=nodes; ++i)
				Console.Write ("{0} ", graph.GetEdges (i));

		}
	}
}
