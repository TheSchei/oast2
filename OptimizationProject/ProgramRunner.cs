using System;
using System.Collections.Generic;
using System.Text;
using OptimizationProject.Algorithm_Folder;
using OptimizationProject.Parser_Folder;

namespace OptimizationProject
{
    class ProgramRunner
    {
        public enum StopCondition { Time, NoGenerations, NoMutations, LackOfBetterSolution};

        private Parser Pars { get; set; }
        private EAlgorithm Algorithm { get; set; }
        private int StartingPopulation { get; set; }
        private double ProbabilityCrossOver { get; set; }
        private double ProbabilityOfMutation { get; set; }
        private int TimeGeneratorSeed { get; set; }
        private int NumberOfCases { get; set; } // liczba grafów
        private StopCondition Condition { get; set; }

        public ProgramRunner()
        {
            Pars = new Parser();
            Algorithm = new EAlgorithm();
            NumberOfCases = Pars.Files.Count;

        }

        public void Run()
        {
            
            Console.WriteLine("Gitara siema w mojej optymalizacji!\n Wpisz swój super wybór");
            int Choice = 0;
            while(true)
            {
                Console.WriteLine("1. Chcesz optymalizację (XD)");
                Console.WriteLine("2. Zabij ten proces... i siebie też");
                Choice = Convert.ToInt32(Console.ReadLine());
                if(Choice != 1 && Choice !=2)
                {
                    Console.WriteLine("Kurwa czytać nie umiesz? jeszcze raz");
                    continue;
                }
                else if(Choice==2)
                {
                    Console.WriteLine("Mądra decyzja");
                    break;
                }
                else
                {
                    FillDataToAlgorithm();
                    Algorithm.Graphs.AddRange(Pars.ReadConfigFiles());
                    Algorithm.Run(StartingPopulation, ProbabilityCrossOver, ProbabilityOfMutation, TimeGeneratorSeed,Condition, NumberOfCases);
                    
                }
            }
            
        }

        public void FillDataToAlgorithm()
        {
            Console.WriteLine("ale z ciebie chory pojeb");
            Console.WriteLine("Wpisz liczebnosć początkowej populacji mordeczko");

            StartingPopulation = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Wpisz prawdopodobieństwo krzyżowania");

            ProbabilityCrossOver = Convert.ToDouble(Console.ReadLine()); // powinno się wyjątek dać tutać no ale cóż
            ProbabilityOfMutation = 1.0 - ProbabilityCrossOver;

            Console.WriteLine("Wpisz ziarno dla generatora liczb :)");
            TimeGeneratorSeed = Convert.ToInt32(Console.ReadLine());
            ChoiceOfStopCondition();
        }

        public void ChoiceOfStopCondition()
        {
            Console.WriteLine("Wybierz warunek stopu:");
            ShowListOfPossibleStopConditions();
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Condition = StopCondition.Time;
                    break;
                case 2:
                    Condition = StopCondition.NoGenerations;
                    break;
                case 3:
                    Condition = StopCondition.NoMutations;
                    break;
                case 4:
                    Condition = StopCondition.LackOfBetterSolution;
                    break;
                default:
                    Console.WriteLine("wybierz jeszcze raz");
                    ChoiceOfStopCondition();
                    break;
            }
        }
        public void ShowListOfPossibleStopConditions()
        {
            Console.WriteLine("1.Time Condition");
            Console.WriteLine("2.Number of Generations");
            Console.WriteLine("3.Number of Mutations");
            Console.WriteLine("4.No Better solution");
        }
    }
}
