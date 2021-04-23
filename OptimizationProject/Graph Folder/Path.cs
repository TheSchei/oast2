using System;
using System.Collections.Generic;
using System.Text;

namespace OptimizationProject.Graph_Folder
{
    public class Path
    {
        public List <int> LinkIDs { get; set; } // ścieżka to lista krawędzi, gdzie każda ma swoje ID
        public Path(List<int> linkIDs)
        {
            LinkIDs = linkIDs;
        }
        public bool CheckIfContainEdge(Edge edge)
        {
            foreach(var link in LinkIDs)
            {
                if (link == edge.Id)
                    return true;
            }
            return false;
        }
    }
}
