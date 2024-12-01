using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto_Muscle_Tec
{
    public partial class Alunos : Form
    {
        private int idTreinador;
        private int idAluno; // ID do aluno que vai ser editado
        private MySqlConnection conexao;

        public Alunos(MySqlConnection conexao, int treinadorId)
        {
            InitializeComponent();
            idTreinador = treinadorId;
            this.conexao = conexao;

            ConfigurarDataGridView();
            CarregarAlunos("");
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

        private void ConfigurarDataGridView()
        {
            // Certifique-se de que o evento seja registrado apenas uma vez
            dataGridView1.CellContentClick -= dataGridViewAlunos_CellContentClick; // Remove se já registrado
            dataGridView1.CellContentClick += dataGridViewAlunos_CellContentClick;

            // Configuração do DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            // Coluna Nome
            var colunaNome = new DataGridViewTextBoxColumn
            {
                HeaderText = "Nome",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridView1.Columns.Add(colunaNome);

            // Coluna Treino
            var colunaTreino = new DataGridViewButtonColumn
            {
                HeaderText = "Treino",
                Text = "Treino",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView1.Columns.Add(colunaTreino);
        }



        private void CarregarAlunos(string pesquisa)
        {
            string query = @"
            SELECT a.idAluno, u.nome, u.email 
            FROM usuario u
            INNER JOIN aluno a ON u.idUsuario = a.idUsuario
            WHERE a.idTreinador = @idTreinador AND u.nome LIKE @pesquisa";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, ConexaoDB.GetConexao());
                cmd.Parameters.AddWithValue("@idTreinador", idTreinador);
                cmd.Parameters.AddWithValue("@pesquisa", $"%{pesquisa}%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tabelaAlunos = new DataTable();
                adapter.Fill(tabelaAlunos);

                dataGridView1.Rows.Clear(); // Limpa as linhas existentes no DataGridView

                foreach (DataRow row in tabelaAlunos.Rows)
                {
                    int idAluno = Convert.ToInt32(row["idAluno"]);
                    string nome = row["nome"].ToString();

                    // Adiciona a linha ao DataGridView e configura o Tag com o idAluno
                    var linha = new DataGridViewRow();
                    linha.CreateCells(dataGridView1, nome); // Nome do aluno na primeira célula
                    linha.Tag = idAluno; // Armazena o idAluno no Tag da linha
                    dataGridView1.Rows.Add(linha);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar alunos: {ex.Message}");
            }
        }



        private void dataGridViewAlunos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o índice da linha é válido
            if (e.RowIndex >= 0)
            {
                // Obtém o Tag da linha atual
                var linhaSelecionada = dataGridView1.Rows[e.RowIndex];
                int idAluno = Convert.ToInt32(linhaSelecionada.Tag);

                // Identifica qual botão foi clicado
                string colunaClicada = dataGridView1.Columns[e.ColumnIndex].HeaderText;

                switch (colunaClicada)
                {
                    case "Treino":
                        // Abre a tela de treinos
                        MessageBox.Show($"Abrindo treinos para o aluno ID: {idAluno}");
                        TelaTreinos telaTreinos = new TelaTreinos(idAluno);
                        telaTreinos.Show();
                        break;

                    default:
                        // Caso nenhuma das colunas clicadas seja relevante
                        MessageBox.Show("Ação não reconhecida.");
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Executa a pesquisa com base no texto do TextBox
            string pesquisa = textBox1.Text;
            CarregarAlunos(pesquisa);
        }
    }
}
