using System;
using System.Collections.Generic;
using System.Text;
using OptimizationProject.Graph_Folder;
using OptimizationProject.Result_Folder;
using static OptimizationProject.ProgramRunner;

namespace OptimizationProject.Algorithm_Folder
{
    class DAP
    {
        private Graph graph;
        private StopCondition Condition;
        private int ConditionValue;
        private double ProbabilityCrossOver;
        private double ProbabilityMutation;
        private int TargetPopulation;
        
        Random random;
        private List<DAPchromosome> CurrentResultsTable;
        private List<DAPchromosome> TemporaryResultsTable;
        private int Time;
        private int NoMutations;
        private int NoGenerations;
        private int NoBetterSolutions;//Ilość iteracji bez poprawy

        public DAP(Graph graph, StopCondition condition, int startingPopulation, double probabilityCrossOver, double probabilityMutation, int timeGeneratorSeed, int conditionValue)
        {
            this.graph = graph;
            Condition = condition;
            ProbabilityCrossOver = probabilityCrossOver;
            ProbabilityMutation = probabilityMutation;
            TargetPopulation = startingPopulation;
            random = new Random(timeGeneratorSeed);
            ConditionValue = conditionValue;

            for (int i = 0; i < startingPopulation; i++)
                CurrentResultsTable.Add(new DAPchromosome(graph, random));

            Time = 0;
            NoMutations = 0;
            NoGenerations = 0;
            NoBetterSolutions = 0;

        }

        public Result run()
        {
            Result result = new Result();
            while(checkStopCondition())
            {
                Time++;
                cross();//do populacji zostają dodane z jakiś P zcrossowane dwa rozwiązania
                mutate();//populacja jest kopiowana i mutowana (cała)
                clean();//wbierane jest N najlepszych rozwiązan (N=starting population?)
                checkNewSolution();//aktualna populacja jest sprawdzana - jesli najlepsze rozwiazanie sie zmienilo jest dopisywane do stosu (NoBetterSolutions - 0), jesli nie yo zwiekszana jest wartość NoBetterSolutions
            }
            return result;
        }
        private bool checkStopCondition()
        {
            switch(Condition)
            {
                case StopCondition.Time:
                    if (Time > ConditionValue) return false;
                    break;
                case StopCondition.LackOfBetterSolution:
                    if (NoBetterSollutions > ConditionValue) return false;
                    break;
                case StopCondition.NoGenerations:
                    if (NoGenerations > ConditionValue) return false;
                    break;
                case StopCondition.NoMutations:
                    if (NoMutations > ConditionValue) return false;
                    break;
            }
            return true;
        }
        private void mutate()
        {
            foreach (DAPchromosome chromosome in CurrentResultsTable)
            {
                DAPchromosome temp = new DAPchromosome(chromosome);
                foreach (DAPgene gene in temp.CurrentResultTable2)
                    if (random.NextDouble() < ProbabilityMutation)
                    {
                        gene.mutate();
                        NoMutations++;
                    }
                TemporaryResultsTable.Add(new DAPchromosome(temp));
            }
        }
        private void cross()
        {

        }
        private void clean()
        {

        }
        private void checkNewSolution()
        {

        }
    }
}
