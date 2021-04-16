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
        private Graph Graph;
        private StopCondition Condition;
        private int StartingPopulation;
        private double ProbabilityCrossOver;
        private double ProbabilityMutation;
        Random random;
        private int ConditionValue;

        private List<DAPchromosome> CurrentResultsTable;

        public DAP(Graph graph, StopCondition condition, int startingPopulation, double probabilityCrossOver, double probabilityMutation, int timeGeneratorSeed, int conditionValue)
        {
            Graph = graph;
            Condition = condition;
            StartingPopulation = startingPopulation;
            ProbabilityCrossOver = probabilityCrossOver;
            ProbabilityMutation = probabilityMutation;
            random = new Random(timeGeneratorSeed);
            ConditionValue = conditionValue;
        }

        public Result run()
        {

            return null;
        }
    }
}
