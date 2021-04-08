using System;
using System.Collections.Generic;
using System.Text;

namespace OptimizationProject.Graph_Folder
{
    public class Graph
    {
        public List<Edge> Edges { get; set; }

        public Graph()
        {
            Edges = new List<Edge>();
        }
        public void CreateEdge(string line)
        {

            string[] attributes = line.Split(' ');
            int Start = Convert.ToInt32(attributes[0]);
            int End = Convert.ToInt32(attributes[1]);
            int NumberModules = Convert.ToInt32(attributes[2]);
            int CostModule = Convert.ToInt32(attributes[3]);
            int SizeModule = Convert.ToInt32(attributes[4]);
            Edges.Add(new Edge(Start, End, SizeModule, NumberModules, CostModule)); 
        }
    }
}
