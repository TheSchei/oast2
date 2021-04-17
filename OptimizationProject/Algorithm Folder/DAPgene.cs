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
        public void mutate()
        {
            throw new NotImplementedException();
        }
    }
}
