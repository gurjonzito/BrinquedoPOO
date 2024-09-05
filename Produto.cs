using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrinquedoPOOv2
{
    public class Produto
    {
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public Fabricante Fabricante { get; set; }

        public string CodigoDescricao
        {
            get
            {
                return CodigoBarras + " - " + Descricao;
            }
        }
    }
}
