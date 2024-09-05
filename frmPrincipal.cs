using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace BrinquedoPOOv2
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            this.Load += frmPrincipal_Load;
            this.Resize += frmPrincipal_Resize;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente fechar o programa?",
                                "Confirmação",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CentralizarLabel();
        }

        private void frmPrincipal_Resize(object sender, EventArgs e)
        {
            CentralizarLabel();
        }

        private void CentralizarLabel()
        {
            lblSysToys.AutoSize = true;
            lblSysToys.Left = (panel1.ClientSize.Width - lblSysToys.Width) / 2;
            lblSysToys.Top = (panel1.ClientSize.Height - lblSysToys.Height) / 2;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCadBrinquedos frm = new frmCadBrinquedos();
            frm.ShowDialog();
        }
    }
}
