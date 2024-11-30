using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Projeto_Muscle_Tec
{
    public partial class TelaAluno : Form
    {
        private int idAluno;
        public TelaAluno(int idAluno)
        {
            InitializeComponent();
            this.idAluno = idAluno;
        }

        public static class ConexaoDB
        {
            private static MySqlConnection conexao;

            public static MySqlConnection GetConexao()
            {
                if (conexao == null)
                {
                    string servidor = "localhost";
                    string banco = "muscletec";
                    string usuario = "root";
                    string senha = "";

                    string stringConexao = $"SERVER={servidor}; DATABASE={banco}; UID={usuario}; PASSWORD={senha};";
                    conexao = new MySqlConnection(stringConexao);
                    conexao.Open();
                }

                return conexao;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"idAluno: {idAluno}");
            Treinos Treinos = new Treinos(ConexaoDB.GetConexao(), idAluno);
            Treinos.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Perfil perfilForm = new Perfil(ConexaoDB.GetConexao(), idAluno);
            perfilForm.Show();

        }
    }
}
