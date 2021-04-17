using System;
using System.Collections.Generic;
using System.Text;
using OptimizationProject.Graph_Folder;

namespace OptimizationProject.Algorithm_Folder
{
    class DAPchromosome
    {
        public List<DAPgene> CurrentResultTable2;//nie wiem które lepsze
        public int value;

        public DAPchromosome(DAPchromosome chromosome)//konstruktor kopiujący trszeba dorobić
        {
            value = chromosome.value;
            CurrentResultTable2 = new List<DAPgene>(chromosome.CurrentResultTable2);
        }

        public DAPchromosome(Graph graph, Random random)//tutaj nie wiem czy nie lepiej dać wygenerowany wcześniej losowo nowy seed, i tworzyć lokalną klasę random, bo nie wiem  czy jak jest tak jak teraz, to każdy "chromosom" nie będzie taki sam
        {
            CurrentResultTable2 = new List<DAPgene>();
            foreach (Demand d in graph.Demands)
            {
                int[] waitingPaths = new int[d.Paths.Count];//sprawdzi, czy inicjują się zera!!!!
                for (int i = d.Volume; i > 0; i--)//generacja losowych wartości
                    waitingPaths[random.Next(0, waitingPaths.Length - 1)]++;
                CurrentResultTable2.Add(new DAPgene(waitingPaths));//uczepienie
            }
            calculateValue(graph);
        }
        private void calculateValue(Graph graph)
        {
            value = 0;
            for (int i = 0; i < graph.Demands.Count; i++)//każdy demand
                for (int j = 0; j < graph.Demands[i].Paths.Count; i++)//każda ścieżka
                    value += CurrentResultTable2[i].gene[j] * graph.Demands[i].Paths[j].LinkIDs.Count;//suma = ilość zasobów * długość ścieżki//ojezu xD
        }
        public int mutate(Random random, double ProbabilityMutation)
        {
            int NoMutations = 0;
            foreach (DAPgene gene in CurrentResultTable2)
                if (random.NextDouble() < ProbabilityMutation)
                {
                    gene.mutate(random);
                    NoMutations++;
                }
            return NoMutations;
        }
    }
}
