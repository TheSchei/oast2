using System;
using System.Collections.Generic;
using System.Text;

namespace OptimizationProject.Algorithm_Folder
{
    class DAPgene
    {
        public int[] gene;
        public DAPgene(DAPgene gene)
        {
            gene.gene.CopyTo(this.gene, 0);
        }
        public DAPgene(int[] gene)
        {
            this.gene = gene;
        }
        public void mutate(Random random)//zaimplementowane jako losowanie genu, który odda jednostkę wartości innemu genowi
        {
            if (gene.Length == 1) return; // nie może mutować
            int i = random.Next(0, gene.Length - 1);//gen oddający jednostkę wartości
            while(gene[i] == 0)
                i = random.Next(0, gene.Length - 1);//losujemy aż nie trafimy na niepusty gen
            int j = random.Next(0, gene.Length - 1);//gen otrzymujący jednostkę wartości
            while (i == j)
                j = random.Next(0, gene.Length - 1);
            gene[i]--;
            gene[j]++;
        }
    }
}
