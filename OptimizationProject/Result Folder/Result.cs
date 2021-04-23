using System;
using System.Collections.Generic;
using System.Text;
using OptimizationProject.Algorithm_Folder;
using OptimizationProject.Graph_Folder;

namespace OptimizationProject.Result_Folder
{
    public class Result
    {
        public enum ResultType { DAP, DDAP }
        public DateTime TimeStamp { get; set; }
        public ResultType TypeOfResult { get; set; }
        public double ValueOfCostFunction { get; set; }
        public int NumberOfIterations { get; set; }
        public double TimeOfExecution { get; set; }
        public Chromosome Solution { get; set; }
        public Demand demand { get; set; }

        public override string ToString()
        {
            string ResultString = "Time Stamp: " + DateTime.Now.ToString() + " \nType of task: " + TypeOfResult.ToString() + " \n" +
                "Value of Cost Function: " + ValueOfCostFunction.ToString() + " \nNumber of Iterations: " + NumberOfIterations.ToString() + " \n" +
                "Time of Execution: " + TimeOfExecution.ToString() + " \n \n \n Description of chromosome: " + Solution.ToString();

            return ResultString;
        }
        public string GetFileName()
        {
            return TypeOfResult.ToString() + " " + DateTime.Now.ToString("yyyy-MM-dd");
        }


    }
}
