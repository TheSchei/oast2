using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OptimizationProject.Graph_Folder;
using OptimizationProject.Result_Folder;
using System.Xml;

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
            Files.AddRange(Directory.GetFiles(FullPath, "*.xml"));
        }
        public List<Graph> ReadConfigFiles(int choosenFileIndex)
        {
            List<Graph> Graphs = new List<Graph>();
            Graph graph = new Graph();
            XmlDocument doc = new XmlDocument();
            doc.Load(Files[choosenFileIndex]);
            XmlNodeList edges = doc.DocumentElement.SelectNodes("/network/links/link");
            foreach(XmlNode edge in edges)
            {
                int Start = Convert.ToInt32(edge.SelectSingleNode("startNode").InnerText);
                int End = Convert.ToInt32(edge.SelectSingleNode("endNode").InnerText);
                int NumberModules = Convert.ToInt32(edge.SelectSingleNode("numberOfModules").InnerText);
                int CostModule = Convert.ToInt32(edge.SelectSingleNode("moduleCost").InnerText);
                int SizeModule = Convert.ToInt32(edge.SelectSingleNode("linkModule").InnerText);
                graph.CreateEdge(Start, End, NumberModules, CostModule, SizeModule);
            }
            Graphs.Add(graph);
            // wczytanie zapotrzebowań
            return Graphs;
        }
        public void WriteResultToFile(Result result)
        {

        }
        public void PrintFiles()
        {
            for (int i = 1; i <= Files.Count; i++)
                Console.WriteLine("{0}. {1}", i, Path.GetFileName(Files[i - 1]));
        }

    }
}
