using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OptimizationProject.Graph_Folder;
using static OptimizationProject.Result_Folder.Result;

namespace OptimizationProject.Algorithm_Folder
{
    public class Chromosome
    {
        public List<Gene> ListOfGenes;
        public int GainValue;

        public Chromosome(Chromosome chromosome)//konstruktor kopiujący trszeba dorobić
        {
            GainValue = chromosome.GainValue;
            ListOfGenes = new List<Gene>(chromosome.ListOfGenes);
        }

        public Chromosome(Graph graph, Random random, ResultType resultType)//tutaj nie wiem czy nie lepiej dać wygenerowany wcześniej losowo nowy seed, i tworzyć lokalną klasę random, bo nie wiem  czy jak jest tak jak teraz, to każdy "chromosom" nie będzie taki sam
        {
            ListOfGenes = new List<Gene>();
            foreach (Demand d in graph.Demands)
            {
                int[] waitingPaths = new int[d.Paths.Count];//sprawdzi, czy inicjują się zera!!!!
                for (int i = d.Volume; i > 0; i--)//generacja losowych wartości
                    waitingPaths[random.Next(0, waitingPaths.Length - 1)]++;
                ListOfGenes.Add(new Gene(waitingPaths));//uczepienie
            }
            CalculateGainValue(graph, resultType);
        }
        private void CalculateGainValue(Graph graph, ResultType resultType)
        {
            GainValue = 0;
            List<int> loads = CalculateLoads(graph, resultType);
            if (resultType.Equals(ResultType.DAP))
            {

                GainValue = loads.Max();
            }
            else
            {
                GainValue = SumEdgeCosts(graph, loads);
            }

        }

        private int SumEdgeCosts(Graph graph, List<int> loads)
        {
            int y = 0;
            int sum = 0;
           for(int i=0; i<graph.Edges.Count;i++)
            {
                if (loads[i] <= 0)
                    continue;
                else
                {
                    y = (int)Math.Ceiling((double)loads[i] / graph.Edges[i].SizeOfModule);
                    sum += y * graph.Edges[i].CostOfModule;
                }
            }  
            return sum;
        }

        public List<int> CalculateLoads(Graph graph, ResultType resultType)
        {
            List<int> loads = InitializeList(graph.Edges.Count); //loads[0] obciążenie na krawędzi index 1 loads[1] na krawędzi index 2 itd...

            for(int i=0; i<graph.Demands.Count;i++)
            {
                for (int j=0;j<graph.Demands[i].Paths.Count;j++)
                {
                    for (int k=0; k<graph.Edges.Count;k++)
                    {
                        if (graph.Demands[i].Paths[j].CheckIfContainEdge(graph.Edges[k]))
                        {
                            loads[graph.Edges[k].Id - 1] += ListOfGenes[i].ValueOnPath[j];
                        }

                    }
                }
            }
            for (int i = 0; i < loads.Count; i++)
                loads[i] -= graph.Edges[i].Capacity;
            return loads;
        }
        public List<int> InitializeList(int Length)
        {
            List<int> InitializedList = new List<int>();
            for (int i = 0; i < Length; i++)
                InitializedList.Add(0);
            return InitializedList;
        }
        public int mutate(Random random, double ProbabilityMutation, Graph graph, ResultType resultType)
        {
            int NoMutations = 0;
            foreach (Gene gene in ListOfGenes)
            {
                if (random.NextDouble() < ProbabilityMutation)
                {
                    gene.mutate(random);
                    NoMutations++;
                }
            }
            CalculateGainValue(graph, resultType);//nowy zmutowany walju
            return NoMutations;
        }
        public Chromosome cross(Random random, Chromosome second, Graph graph, ResultType resultType)
        {
            Chromosome temp = new Chromosome(this);
            for (int i = 0; i < ListOfGenes.Count; i++)
                if (random.Next(0, 1) == 1) temp.ListOfGenes[i] = new Gene(second.ListOfGenes[i]);
            temp.CalculateGainValue(graph, resultType);
            return temp;
        }

        public override string ToString()
        {
            string Result = "Chromosome: \n";
            int i = 1;
            foreach(var gene in ListOfGenes)
            {
                Result+="Gene for demand number: "+i.ToString() + "\n";
                foreach (var number in gene.ValueOnPath)
                {
                    Result += number.ToString() + " ";
                }
                Result += "\n *********** \n";
                ++i;
            }
            return Result;
        }
        public string ToShortString()
        {
            string Result = "Chromosome value: " + GainValue + "\n";
            return Result;
        }
    }
}
