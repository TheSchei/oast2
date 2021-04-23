using System;
using System.Collections.Generic;
using System.Text;

namespace OptimizationProject.Graph_Folder
{
    public class Edge
    {
        public int Id { get; set; } //identyfikator krawędzi
        public int StartNode { get; set; } //jeden węzeł krawędzi
        public int EndNode { get; set; } // drugi węzeł krawędzi
        public int SizeOfModule { get; set; } //rozmiar jednego modułu
        public int NumberOfModules { get; set; } // liczba modułów
        public int CostOfModule { get; set; } // koszt położenia modułu
        public int Capacity { get; set; }

        public Edge(int Id, int start, int end, int SizeMod, int NoModules, int CostModule)
        {
            this.Id = Id;
            StartNode = start;
            EndNode = end;
            SizeOfModule = SizeMod;
            NumberOfModules = NoModules;
            CostOfModule = CostModule;
            Capacity = NumberOfModules * SizeOfModule;
        }
        
    }
}
