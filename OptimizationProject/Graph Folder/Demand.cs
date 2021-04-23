using System;
using System.Collections.Generic;
using System.Text;

namespace OptimizationProject.Graph_Folder
{
    public class Demand
    {
        public List<Path> Paths { get; set; } // wymaganie ma listę ścieżek
        public int StartNode { get; set; } // początkowy węzeł
        public int EndNode { get; set; } // końcowy węzeł
        public int Volume { get; set; } // wymaganą przepustowość
        public Demand(int start, int end, int volume, List<Path> paths)
        {
            StartNode = start;
            EndNode = end;
            Volume = volume;
            Paths = paths;
        }
        public override string ToString()
        {
            return "Demand: \n Start Node: " + StartNode.ToString() + "\n End Node: " +
                EndNode.ToString() + "\n Volume: " + Volume.ToString() + "\n";
        }
    }
}
