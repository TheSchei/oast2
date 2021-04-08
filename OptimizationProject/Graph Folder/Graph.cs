using System;
using System.Collections.Generic;
using System.Text;

namespace OptimizationProject.Graph_Folder
{
    public class Graph
    {
        public List<Edge> Edges { get; set; }
        public List<Demand> Demands { get; set; }

        public Graph()
        {
            Edges = new List<Edge>();
            Demands = new List<Demand>();
        }
        public void CreateEdge(int Start, int End, int NumberModules, int CostModule, int SizeModule)
        {
            Edges.Add(new Edge(Start, End, SizeModule, NumberModules, CostModule));
        }
        public void CreateDemand(int Start, int End, int volume, List<Path> paths)
        {
            Demands.Add(new Demand(Start, End, volume, paths));
        }
    }
}
