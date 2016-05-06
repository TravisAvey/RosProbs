using System;
using System.IO;
using System.Collections.Generic;

namespace BFS
{
	class MainClass
	{
		/*
		 * 	Simple DiGraph, Adjacency List
		 */ 
		class DiGraph
		{
			private int nodes;
			private Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

			public DiGraph(int nodes)
			{
				this.nodes = nodes;
				InitGraph();
			}

			private void InitGraph()
			{
				for (int i=1; i<=nodes; ++i)
					graph.Add (i, new List<int> ());
			}

			public void Add(int v, int w)
			{
				// v -> edge; w -> node points to
				// 4 -> 6, this node (4) is directed to 6

				List<int> list;

				if (!graph.TryGetValue(v, out list))
				{
					list = new List<int> ();
					graph.Add (v, list);
				}
				graph [v].Add (w);
			}

			public void BFS()
			{
				// create a list to hold the output
				List<int> output = new List<int> ();

				// first node will always be itself == 0 jumps
				output.Add (0);

				// check from 1st node if it is possible to visit all the nodes..
				int node = 1;
				// start on second.. first is a visit to the first
				for (int i=2; i<=nodes; ++i)
				{
					int jumps = 0;

					// visit every possible route to node i from 1
					List<int> path = graph [node];
					foreach (int p in path)
					{
						if (p == i)
							output.Add (jumps++);
						else
						{
							// then grab the next list and repeat? Need a Queue instead of a list!!
						}
					}
				}

			}

			public void GetInfo()
			{
				for (int i=1; i<=nodes; ++i)
				{

					List<int> connections = graph [i];
					if (connections.Capacity == 0)
						Console.WriteLine ("{0} doesn't have any connections", i);
					else
					{
						foreach (int n in connections)
							Console.Write ("{0}->{1} ",i, n);
						Console.WriteLine ();
					}
				}
			}
		}

		public static void Main (string[] args)
		{
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/BFS/data.txt",
			                          FileMode.Open, FileAccess.Read);

			using (var reader = new StreamReader(file))
			{
				// first line is how many nodes, and how many edges
				string line = reader.ReadLine ();
				int[] data = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse)).ToArray ();
				int nodes = data [0];
				int edges = data [1];

				DiGraph diGraph = new DiGraph(nodes);

				for (int i=0; i<edges; ++i)
				{
					line = reader.ReadLine ();
					int [] tokens = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse)).ToArray ();
					diGraph.Add (tokens [0], tokens [1]);
				}

				diGraph.GetInfo ();
			}
		}
	}
}
