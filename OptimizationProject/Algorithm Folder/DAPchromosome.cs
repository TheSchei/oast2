using System;
using System.Collections.Generic;
using System.Text;
using OptimizationProject.Graph_Folder;

namespace OptimizationProject.Algorithm_Folder
{
    class DAPchromosome
    {
        int[,] CurrentResultTable;
        List<int[]> CurrentResultTable2;//nie wiem które lepsze
        int value;

        public DAPchromosome(Graph graph, Random random)//tutaj nie wiem czy nie lepiej dać wygenerowany wcześniej losowo nowy seed, i tworzyć lokalną klasę random, bo nie wiem  czy jak jest tak jak teraz, to każdy "chromosom" nie będzie taki sam
        {

            CurrentResultTable = new int[graph.Demands.Count, graph.getMaxNumberOfPaths()];
            CurrentResultTable2 = new List<int[]>();
            foreach (Demand d in graph.Demands)
            {
                int[] waitingPaths = new int[d.Paths.Count];//sprawdzi, czy inicjują się zera!!!!
                for (int i = d.Volume; i > 0; i--)//generacja losowych wartości
                    waitingPaths[random.Next(0, waitingPaths.Length - 1)]++;
                CurrentResultTable2.Add(waitingPaths);//uczepienie
            }
            calculateValue(graph);
        }
        private void calculateValue(Graph graph)
        {
            value = 0;
            for (int i = 0; i < graph.Demands.Count; i++)//każdy demand
                for (int j = 0; j < graph.Demands[i].Paths.Count; i++)//każda ścieżka
                    value += CurrentResultTable2[i][j] * graph.Demands[i].Paths[j].LinkIDs.Count;//suma = ilość zasobów * długość ścieżki//ojezu xD
        }
    }
}
