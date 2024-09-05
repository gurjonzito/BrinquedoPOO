using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrinquedoPOOv2
{
    public partial class frmVisuBrinquedos : Form
    {
        public frmVisuBrinquedos()
        {
            InitializeComponent();
        }

        public void CarregarBrinquedo(Brinquedo brinquedo)
        {
            if (brinquedo != null)
            {
                txtFabricante.Text = brinquedo.Fabricante.NomeCNPJ;
                txtCodigo.Text = brinquedo.Produto.CodigoBarras;
                txtDescricao.Text = brinquedo.Produto.Descricao;
                txtPreco.Text = brinquedo.Produto.Preco.ToString();
                txtCategoria.Text = brinquedo.Categoria;
                txtIdade.Text = brinquedo.IdadeMinima.ToString();
            }
        }
    }
}
