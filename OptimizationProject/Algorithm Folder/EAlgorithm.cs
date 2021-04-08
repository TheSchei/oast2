using System;
using System.Collections.Generic;
using System.Text;
using OptimizationProject.Graph_Folder;
using OptimizationProject.Result_Folder;
using static OptimizationProject.ProgramRunner;

namespace OptimizationProject.Algorithm_Folder
{
    class EAlgorithm
    {
        List<Result> DAPResults;
        List<Result> DDAPResults;
        public List<Graph> Graphs;

        public EAlgorithm()
        {
            DAPResults = new List<Result>();
            DDAPResults = new List<Result>();
            Graphs = new List<Graph>();
        }
        public void Run(int StartingPopulation,double ProbabilityCrossOver, double ProbabilityMutation, int TimeGeneratorSeed, StopCondition Condition,int NumberOfCases)
        {
            for (int i = 0; i < NumberOfCases; i++)
            {
                DAPResults.Add(RunDAPCase());
                DDAPResults.Add(RunDDAPCase());
            }
        }
        public Result RunDAPCase()
        {
            return null;
        }
        public Result RunDDAPCase()
        {
            return null;
        }
    }
}
