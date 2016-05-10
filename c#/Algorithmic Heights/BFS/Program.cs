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
			private int nodes;
			private Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
			private int[] distance;

			public DiGraph(int nodes)
			{
				this.nodes = nodes;
				distance = new int[nodes+1];
				InitGraph();
			}

			private void InitGraph()
			{
				for (int i=1; i<=nodes; ++i)
					graph.Add (i, new List<int> ());

				for (int j=0; j<=nodes; ++j)
					distance [j] = -1;
			}

			public int distanceTo(int v)
			{
				return distance [v];
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

			public void BFS(int tar)
			{
				bool[] marked = new bool[nodes+1];

				Queue<int> q = new Queue<int> ();

				// mark first explored
				marked [1] = true;
				distance [1] = 0;

				q.Enqueue (1);
				while (q.Count > 0)
				{
					int v = q.Peek();
					List<int> conns = graph [q.Dequeue ()];

					foreach (int n in conns)
					{
						if (!marked[n])
						{
							distance [n] = distance [v] + 1;
							marked [n] = true;
							q.Enqueue (n);
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

				List<int> results = new List<int> ();

				for (int i=1; i<=nodes; ++i)
					diGraph.BFS (i);

				for (int i=1; i<=nodes; ++i)
					results.Add (diGraph.distanceTo (i));

				PrintToFile (ref results);

			}
		}
	}
}
