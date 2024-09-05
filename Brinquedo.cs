using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrinquedoPOOv2
{
    public class Brinquedo
    {
        public Produto Produto { get; set; }
        public string Categoria { get; set; }
        public int IdadeMinima { get; set; }
        public Fabricante Fabricante { get; set; }

        public string CodigoDescricaoCategoria
        {
            get
            {
                return Produto.CodigoDescricao + " - " + Categoria;
            }
        }

        public string CodigoDescCatFabricante
        {
            get
            {
                return CodigoDescricaoCategoria + " - " + Fabricante.Nome;
            }
        }
    }
}
