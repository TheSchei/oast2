using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OptimizationProject.Graph_Folder;
using OptimizationProject.Result_Folder;

namespace OptimizationProject.Parser_Folder
{
    public class Parser
    {
        public const string CONF_FOLDER = @"..\..\..\Configuration Files"; //trzeba cofnąć bo zaczyna się w bin/Release coś tam
        public string FullPath; 
        public List<string> Files;
        public Parser()
        {
            Files = new List<string>();
            FullPath = Path.GetFullPath(CONF_FOLDER);
            Files.AddRange(Directory.GetFiles(FullPath, "*.txt"));
        }
        public List<Graph> ReadConfigFiles()
        {
            List<Graph> Graphs = new List<Graph>();
            foreach (var MyFile in Files)
            {
                Graph graph = new Graph();
                string PathToFile = FullPath + "\\" + MyFile;
                string[] lines = File.ReadAllLines(PathToFile);
                int NoEdges = Convert.ToInt32(lines[0]);
                for (int i = 0; i < NoEdges; i++)
                {
                    graph.CreateEdge(lines[i + 1]);
                }
                Graphs.Add(graph);
            }
            // wczytanie zapotrzebowań
            return Graphs;
        }
        public void WriteResultToFile(Result result)
        {

        }

    }
}
