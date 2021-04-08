using System;
using System.Collections.Generic;
using System.Text;

namespace OptimizationProject.Graph_Folder
{
    public class Demand
    {
        public List<Path> Paths { get; set; }
        public int StartNode { get; set; }
        public int EndNode { get; set; }
        public int Volume { get; set; }
        public Demand(int start, int end, int volume, List<Path> paths)
        {
            StartNode = start;
            EndNode = end;
            Volume = volume;
            Paths = paths;
        }
    }
}
