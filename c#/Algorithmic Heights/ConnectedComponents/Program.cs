using System;
using System.IO;
using System.Collections.Generic;

namespace ConnectedComponents
{
	class Graph
	{
		private int nodes;
		private Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

		public Graph(int nodes)
		{
			this.nodes = nodes;
			InitGraph ();
		}

		private void InitGraph()
		{
			// set each key in the graph to new list
			for (int i=1; i<=nodes; ++i)
				graph.Add (i, new List<int> ());
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
			graph [v].Add (w);

			graph [w].Add (v);
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
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/ConnectedComponents/data.txt",
			                           FileMode.Open, FileAccess.Read);

			using (var reader = new StreamReader(file))
			{
				string line = reader.ReadLine ();

				int[] data = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse)).ToArray ();
				int nodes = data [0];
				int edges = data [1];

				Graph graph = new Graph(nodes);

				for (int i=0; i<edges; ++i)
				{
					line = reader.ReadLine ();
					int[] tokens = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse)).ToArray ();
					graph.Add (tokens [0], tokens [1]);
				}

				graph.PrintGraph ();
			}
		}
	}
}
