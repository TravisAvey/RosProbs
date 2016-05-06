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
				throw new NotImplementedException ();
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
						Console.Write ("Node {0} is connected to ", i);
						foreach (int n in connections)
							Console.Write ("{0} ", n);
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

				diGraph.BFS ();
			}
		}
	}
}
