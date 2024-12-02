using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto_Muscle_Tec
{
    public partial class AdicionarTreinoForm : Form
    {
        private int idAluno;
        private List<int> exerciciosAdicionados;
        private MySqlConnection conexao;

        public AdicionarTreinoForm(int alunoId)
        {
            InitializeComponent();
            idAluno = alunoId;
            exerciciosAdicionados = new List<int>();
            conexao = Alunos.ConexaoDB.GetConexao(); // Usar a conexão única

            CarregarExerciciosDisponiveis();

            // Associar o evento SelectedIndexChanged do ListBox
            listBoxExercicios.SelectedIndexChanged += ListBoxExercicios_SelectedIndexChanged;
        }

        private void CarregarExerciciosDisponiveis()
        {
            string query = "SELECT idExercicio, nomeExercicio, descricao FROM exercicios";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tabelaExercicios = new DataTable();
                adapter.Fill(tabelaExercicios);

                listBoxExercicios.DataSource = tabelaExercicios;
                listBoxExercicios.DisplayMember = "nomeExercicio";
                listBoxExercicios.ValueMember = "idExercicio";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar exercícios: {ex.Message}");
            }
        }

        private void ListBoxExercicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxExercicios.SelectedItem != null)
            {
                // Capturar o item selecionado
                DataRowView itemSelecionado = (DataRowView)listBoxExercicios.SelectedItem;

                // Exibir a descrição na lblExercicioSelecionado
                lblExercicioSelecionado.Text = $"Descrição exercício: {itemSelecionado["descricao"]}";
            }
        }

        private void btnAdicionarExercicio_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"idAluno: {idAluno}");

            if (listBoxExercicios.SelectedItem != null)
            {
                DataRowView itemSelecionado = (DataRowView)listBoxExercicios.SelectedItem;
                string nomeExercicio = itemSelecionado["nomeExercicio"].ToString();
                int idExercicio = (int)itemSelecionado["idExercicio"];

                if (!exerciciosAdicionados.Contains(idExercicio))
                {
                    exerciciosAdicionados.Add(idExercicio);
                    listBoxExerciciosAdicionados.Items.Add(nomeExercicio);
                }
            }
        }

        private void btnRemoverExercicio_Click(object sender, EventArgs e)
        {
            if (listBoxExerciciosAdicionados.SelectedItem != null)
            {
                int index = listBoxExerciciosAdicionados.SelectedIndex;
                exerciciosAdicionados.RemoveAt(index);
                listBoxExerciciosAdicionados.Items.RemoveAt(index);
            }
        }

        private void btnSalvarTreino_Click(object sender, EventArgs e)
        {
            string nomeTreino = txtNomeTreino.Text.Trim();
            string descricao = txtDescricao.Text.Trim();

            if (string.IsNullOrEmpty(nomeTreino))
            {
                MessageBox.Show("Por favor, insira um nome para o treino.");
                return;
            }

            try
            {
                // Iniciar uma transação para garantir que as operações de inserção aconteçam de forma atômica
                using (var transaction = conexao.BeginTransaction())
                {
                    // Inserir o treino no banco
                    string queryTreino = @"
                        INSERT INTO treino (idAluno, nomeTreino, descricao)
                        VALUES (@idAluno, @nomeTreino, @descricao);
                        SELECT LAST_INSERT_ID();";

                    MySqlCommand cmdTreino = new MySqlCommand(queryTreino, conexao, transaction);
                    cmdTreino.Parameters.AddWithValue("@idAluno", idAluno);
                    cmdTreino.Parameters.AddWithValue("@nomeTreino", nomeTreino);
                    cmdTreino.Parameters.AddWithValue("@descricao", descricao);

                    int idTreino = Convert.ToInt32(cmdTreino.ExecuteScalar());

                    // Inserir os exercícios vinculados ao treino na tabela intermediária
                    foreach (int idExercicio in exerciciosAdicionados)
                    {
                        string queryExercicio = @"
                            INSERT INTO treino_exercicio (idTreino, idExercicio)
                            VALUES (@idTreino, @idExercicio);";

                        MySqlCommand cmdExercicio = new MySqlCommand(queryExercicio, conexao, transaction);
                        cmdExercicio.Parameters.AddWithValue("@idTreino", idTreino);
                        cmdExercicio.Parameters.AddWithValue("@idExercicio", idExercicio);
                        cmdExercicio.ExecuteNonQuery();
                    }

                    // Commit na transação para salvar todas as alterações
                    transaction.Commit();
                }

                MessageBox.Show("Treino criado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar treino: {ex.Message}");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBoxExerciciosAdicionados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
