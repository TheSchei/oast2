using System;
using System.Collections.Generic;
using System.Text;

namespace OptimizationProject.Result_Folder
{
    public class Result
    {
        enum ResultType { DAP, DDAP }
        private DateTime TimeStamp { get; set; }
        private ResultType TypeOfResult { get; set; }
        private double ValueOfCostFunction { get; set; }
        private int NumberOfIterations { get; set; }
        private double TimeOfExecution { get; set; }

        public override string ToString()
        {
            string ResultString = "Time Stamp: " + TimeStamp.ToString() + " \nType of task: " + TypeOfResult + " \n" +
                "Value of Cost Function: " + ValueOfCostFunction.ToString() + " \nNumber of Iterations: " + NumberOfIterations.ToString() + " \n" +
                "Time of Execution: " + TimeOfExecution.ToString();

            return ResultString;
        }
        public string getFileName()
        {
            return TypeOfResult.ToString() + "::" + TimeStamp.ToString();
        }


    }
}
