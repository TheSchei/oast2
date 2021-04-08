using System;
using System.Collections.Generic;
using System.Text;

namespace OptimizationProject.Graph_Folder
{
    public class Path
    {
        public List <int> LinkIDs { get; set; }
        public Path(List<int> linkIDs)
        {
            LinkIDs = linkIDs;
        }
    }
}
