using System;
using System.Collections.Generic;
using System.Text;

namespace OptimizationProject.Graph_Folder
{
    public class Edge
    {
        public int StartNode { get; set; }
        public int EndNode { get; set; }

        public int SizeOfModule { get; set; }
        public int NumberOfModules { get; set; }
        public int CostOfModule { get; set; }

        public Edge(int start, int end, int SizeMod, int NoModules, int CostModule)
        {
            StartNode = start;
            EndNode = end;
            SizeOfModule = SizeMod;
            NumberOfModules = NoModules;
            CostOfModule = CostModule;
        }
        
    }
}
