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
    public partial class frmCadBrinquedos : Form
    {
        BrinquedoExecucao brinquedoExecucao = new BrinquedoExecucao();

        public frmCadBrinquedos()
        {
            InitializeComponent();
        }

        private void AdicionarBrinquedo()
        {
            string codigo, descricao, categoria, nomeFabricante, cnpj;
            decimal preco;
            int idadeMinima;

            codigo = txtCodigo.Text;
            descricao = txtDescricao.Text;
            categoria = txtCategoria.Text;
            nomeFabricante = txtFabricante.Text;
            cnpj = txtCNPJ.Text;

            string cnpjLimpo = new string(cnpj.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Código de barras não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPreco.Text))
            {
                MessageBox.Show("Preço não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!decimal.TryParse(txtPreco.Text, out preco))
            {
                MessageBox.Show("O campo 'Preço' deve conter apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(descricao))
            {
                MessageBox.Show("Descrição não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(categoria))
            {
                MessageBox.Show("Categoria não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIdade.Text) || !int.TryParse(txtIdade.Text, out idadeMinima))
            {
                MessageBox.Show("O campo 'Idade Mínima' deve conter um valor numérico válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(nomeFabricante))
            {
                MessageBox.Show("Nome do fabricante não pode ser vazia.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cnpjLimpo.Length != 14)
            {
                MessageBox.Show("O CNPJ deve conter exatamente 14 dígitos numéricos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Fabricante fabricante = new Fabricante();
            Brinquedo brinquedo = new Brinquedo();
            Produto produto = new Produto();

            fabricante.Nome = nomeFabricante;
            fabricante.CNPJ = cnpj;

            brinquedo.Categoria = categoria;
            brinquedo.IdadeMinima = idadeMinima;

            produto.CodigoBarras = codigo;
            produto.Descricao = descricao;
            produto.Preco = preco;

            brinquedo.Produto = produto;
            brinquedo.Fabricante = fabricante;

            brinquedoExecucao.Adicionar(brinquedo);

            AtualizarListaBrinquedos();

            txtCodigo.Clear();
            txtCategoria.Clear();
            txtFabricante.Clear();
            txtPreco.Clear();
            txtIdade.Clear();
            txtCNPJ.Clear();
            txtDescricao.Clear();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) &&
                ch != 8 &&
                ch != 13)
            {
                e.Handled = true;
                MessageBox.Show(
                    "Este campo aceita apenas números",
                    "Informação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void txtIdade_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) &&
                ch != 8 &&
                ch != 13)
            {
                e.Handled = true;
                MessageBox.Show(
                    "Este campo aceita apenas números",
                    "Informação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) &&
                ch != 8 &&
                ch != 13 &&
                ch != ',')
            {
                e.Handled = true;
                MessageBox.Show(
                        "Este campo aceita apenas números e virgulas",
                        "Informação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }

        private void AtualizarListaBrinquedos()
        {
            lsbCadastros.DataSource = null;
            lsbCadastros.DataSource = brinquedoExecucao.Listar();

            lsbCadastros.DisplayMember = "CodigoDescCatFabricante";
        }

        private void RemoverBrinquedo()
        {
            Brinquedo brinquedoSelecionado = lsbCadastros.SelectedItem as Brinquedo;

            if (brinquedoSelecionado != null)
            {
                brinquedoExecucao.Remover(brinquedoSelecionado);

                AtualizarListaBrinquedos();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarBrinquedo();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            RemoverBrinquedo();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Brinquedo brinquedoSelecionado = lsbCadastros.SelectedItem as Brinquedo;

            if (brinquedoSelecionado != null)
            {
                frmVisuBrinquedos frm = new frmVisuBrinquedos();
                frm.CarregarBrinquedo(brinquedoSelecionado);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um brinquedo para visualizar.", "Nenhuma seleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
