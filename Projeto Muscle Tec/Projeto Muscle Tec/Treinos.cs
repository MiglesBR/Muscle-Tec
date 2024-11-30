using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto_Muscle_Tec
{
    public partial class Treinos : Form
    {
        private int idAluno; // ID do aluno logado

        public Treinos(MySqlConnection conexao, int idAluno)
        {
            InitializeComponent();
            this.idAluno = idAluno;
            CarregarTreinos(idAluno);
            AdicionarBotaoExercicios();
            AdicionarBotaoRealizado();
            dataGridView1.CellClick += dgvTreinos_CellClick;
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

        private void CarregarTreinos(int idAluno)
        {
            try
            {
                string connectionString = "SERVER=localhost; DATABASE=muscletec; UID=root; PASSWORD=;";
                using (MySqlConnection conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    string query = @"
                        SELECT t.idTreino, t.nomeTreino, t.descricao, u.nome AS Aluno
                        FROM treino t
                        INNER JOIN aluno a ON t.idAluno = a.idAluno
                        INNER JOIN usuario u ON a.idUsuario = u.idUsuario
                        WHERE t.idAluno = @idAluno";

                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@idAluno", idAluno);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                    dataGridView1.Columns["idTreino"].HeaderText = "ID do Treino";
                    dataGridView1.Columns["nomeTreino"].HeaderText = "Nome do Treino";
                    dataGridView1.Columns["descricao"].HeaderText = "Descrição";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os treinos: {ex.Message}");
            }
        }

        private void AdicionarBotaoExercicios()
        {
            if (!dataGridView1.Columns.Contains("btnExercicios"))
            {
                DataGridViewButtonColumn botaoExercicios = new DataGridViewButtonColumn
                {
                    Name = "btnExercicios",
                    HeaderText = "Exercícios",
                    Text = "Ver Exercícios",
                    UseColumnTextForButtonValue = true
                };

                dataGridView1.Columns.Add(botaoExercicios);
            }
        }

        private void AdicionarBotaoRealizado()
        {
            if (!Controls.ContainsKey("btnRealizado"))
            {
                Button btnRealizado = new Button
                {
                    Name = "btnRealizado",
                    Text = "Realizado",
                    Dock = DockStyle.Bottom // Posiciona o botão na parte inferior
                };

                btnRealizado.Click += BtnRealizado_Click;
                Controls.Add(btnRealizado);
            }
        }

        private void BtnRealizado_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE aluno SET sessoes = sessoes + 1 WHERE idAluno = @idAluno";

                using (MySqlConnection conexao = ConexaoDB.GetConexao())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@idAluno", idAluno);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sessão realizada com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar a sessão. Tente novamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar a sessão: {ex.Message}");
            }
        }

        private void dgvTreinos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnExercicios"].Index && e.RowIndex >= 0)
            {
                int idTreino = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idTreino"].Value);
                MostrarExercicios(idTreino);
            }
        }

        private void MostrarExercicios(int idTreino)
        {
            string query = @"
                SELECT nomeExercicio, descricao 
                FROM exercicios
                INNER JOIN treino_exercicio ON exercicios.idExercicio = treino_exercicio.idExercicio
                WHERE treino_exercicio.idTreino = @idTreino";

            try
            {
                using (MySqlConnection conn = ConexaoDB.GetConexao())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idTreino", idTreino);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ExerciciosAluno exerciciosAluno = new ExerciciosAluno(dt);
                    exerciciosAluno.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os exercícios: {ex.Message}");
            }
        }
    }
}
