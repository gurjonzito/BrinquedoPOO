using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrinquedoPOOv2
{
    public class BrinquedoExecucao
    {
        private List<Brinquedo> brinquedos = new List<Brinquedo>();

        public void Adicionar(Brinquedo brinquedo)
        {
            brinquedos.Add(brinquedo);
        }

        public void Remover(Brinquedo brinquedo)
        {
            brinquedos.Remove(brinquedo);
        }

        public List<Brinquedo> Listar()
        {
            return brinquedos;
        }
    }
}
