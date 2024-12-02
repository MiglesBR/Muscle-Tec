using System;
using System.Windows.Forms;

namespace Projeto_Muscle_Tec
{

    //controle de versão
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();

            // Configura o evento de clique para todo o formulário
            this.MouseDown += TelaInicial_Click;

            // Adiciona o evento de clique a todos os controles do formulário
            foreach (Control control in this.Controls)
            {
                control.MouseDown += TelaInicial_Click;
            }
        }

        private void TelaInicial_Click(object sender, EventArgs e)
        {
            AbrirProximaTela();
        }

        private void AbrirProximaTela()
        {
            this.Hide(); // Esconde a tela atual

            Login Login = new Login();
            Login.Show();
        }
    

        private void Login_Load(object sender, EventArgs e)
        {
            // Deixe este método vazio ou remova-o, se não for necessário
        }
    }
}
