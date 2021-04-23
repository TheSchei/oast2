using System;
using System.Collections.Generic;
using System.Text;

namespace OptimizationProject.Algorithm_Folder
{
    public class Gene
    {
        public int[] ValueOnPath;
        public Gene(Gene gene)
        {
            gene.ValueOnPath.CopyTo(this.ValueOnPath, 0);
        }
        public Gene(int[] ValueOnPath)
        {
            this.ValueOnPath = ValueOnPath;
        }
        public void mutate(Random random)//zaimplementowane jako losowanie genu, który odda jednostkę wartości innemu genowi
        {
            if (ValueOnPath.Length == 1) return; // nie może mutować
            int i = random.Next(0, ValueOnPath.Length);//gen oddający jednostkę wartości
            while (ValueOnPath[i] == 0)
            {
                i = random.Next(0, ValueOnPath.Length);//losujemy aż nie trafimy na niepusty gen
            }
            int j = random.Next(0, ValueOnPath.Length);//gen otrzymujący jednostkę wartości
            while (i == j)
                j = random.Next(0, ValueOnPath.Length);
            ValueOnPath[i]--;
            ValueOnPath[j]++;
        }
    }
}
