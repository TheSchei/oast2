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
        private List<DAPchromosome> BestSolutionStack;
        private int Time;
        private int NoMutations;
        private int NoGenerations;//CO TO JEST? XD !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private int NoBetterSolutions;//Ilość iteracji bez poprawy
        private int bestSolutionValue;

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
            CurrentResultsTable.Sort((x, y) => x.value.CompareTo(y.value));
            bestSolutionValue = CurrentResultsTable[0].value;
            BestSolutionStack = new List<DAPchromosome>();
            BestSolutionStack.Add(new DAPchromosome(CurrentResultsTable[0]));
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
        private void mutate()//zakłądam, że każdy gen mutuje, a prawdopodobieństwo mutacji dotyczy nie tego czy chromosom zmutuje, ale czy każdy gen z osobna.
        {
            foreach (DAPchromosome chromosome in CurrentResultsTable)
            {
                DAPchromosome uberChromosome = new DAPchromosome(chromosome);
                NoMutations += uberChromosome.mutate(random, ProbabilityMutation, graph);
                TemporaryResultsTable.Add(uberChromosome);
            }
        }
        private void cross()//jeśli zajdzie cross z P=zadane P, to losujemy z jakimś P ważonym po jakości, które się krzyżują i krzyżujemy
        {
            if(random.NextDouble() < ProbabilityCrossOver)
            {
                CurrentResultsTable.Sort((x, y) => x.value.CompareTo(y.value));//lub odwrotnie//odpuściłem ważoną 
                CurrentResultsTable.Add(CurrentResultsTable[0].cross(random, CurrentResultsTable[1], graph));
            }
        }
        private void clean()//wybieramy TOP ileś najlepszych reszta do utylizacji
        {
            CurrentResultsTable.Sort((x, y) => x.value.CompareTo(y.value));
            CurrentResultsTable.RemoveRange(TargetPopulation, CurrentResultsTable.Count - TargetPopulation);//indeksy sprawdzić!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
        private void checkNewSolution()//sprawdzamy czy wynik lepszy, jeśli tak, to dodajemy do Resultsów, do stosu postępu, jeśli nie, to dodajemy do mziennej kolejny nieudany eksperyment na ludziach
        {
            if (bestSolutionValue > CurrentResultsTable[0].value) NoBetterSolutions++;
            else
            {
                NoBetterSolutions = 0;
                bestSolutionValue = CurrentResultsTable[0].value;
                BestSolutionStack.Add(new DAPchromosome(CurrentResultsTable[0]));
            }
        }
    }
}
