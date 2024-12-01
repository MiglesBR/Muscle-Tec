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
    public partial class CriarExercicio : Form
    {
        private MySqlConnection conexao;
        public CriarExercicio()
        {
            InitializeComponent();
            conexao = Alunos.ConexaoDB.GetConexao();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Capturar os dados inseridos
            string nomeExercicio = txtNomeExercicio.Text.Trim();
            string descricao = txtDescricao.Text.Trim();

            if (string.IsNullOrEmpty(nomeExercicio))
            {
                MessageBox.Show("Por favor, insira um nome para o exercício.");
                return;
            }

            try
            {
                // Inserir o novo exercício no banco de dados
                string query = @"
                    INSERT INTO exercicios (nomeExercicio, descricao)
                    VALUES (@nomeExercicio, @descricao);";

                using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@nomeExercicio", nomeExercicio);
                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Exercício criado com sucesso!");
                this.Close(); // Fecha o formulário após salvar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar exercício: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
