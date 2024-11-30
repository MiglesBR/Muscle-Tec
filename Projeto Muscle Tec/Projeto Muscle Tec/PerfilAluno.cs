using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto_Muscle_Tec
{
    public partial class Perfil : Form
    {
        private int idAluno; // ID do aluno que vai ser editado
        private MySqlConnection conexao;

        // Construtor que recebe o idAluno e a conexão
        public Perfil(MySqlConnection conexao, int idAluno)
        {
            InitializeComponent();
            this.conexao = conexao;
            this.idAluno = idAluno;
            CarregarPerfil();
        }

        // Carregar os dados do aluno no formulário
        private void CarregarPerfil()
        {
            try
            {
                string query = @"
                    SELECT u.nome, a.peso, a.altura, a.meta, a.sessoes
                    FROM aluno a
                    INNER JOIN usuario u ON a.idUsuario = u.idUsuario
                    WHERE a.idAluno = @idAluno";

                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@idAluno", idAluno);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Carregar dados no formulário
                    txtNome.Text = reader["nome"].ToString();
                    txtPeso.Text = reader["peso"].ToString();
                    txtAltura.Text = reader["altura"].ToString();
                    txtMeta.Text = reader["meta"].ToString();
                    txtSessoes.Text = reader["sessoes"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o perfil: {ex.Message}");
            }
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
        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Atualiza o nome na tabela 'usuario'
                string queryAtualizarNome = @"
            UPDATE usuario 
            SET nome = @novoNome 
            WHERE idUsuario = (SELECT idUsuario FROM aluno WHERE idAluno = @idAluno)";

                using (MySqlCommand cmd = new MySqlCommand(queryAtualizarNome, conexao))
                {
                    cmd.Parameters.AddWithValue("@novoNome", txtNome.Text); // txtNome é o TextBox onde o usuário digita o novo nome
                    cmd.Parameters.AddWithValue("@idAluno", idAluno);

                    cmd.ExecuteNonQuery();
                }

                // Atualiza os dados na tabela 'aluno' (peso, altura, meta, sessões)
                string queryAtualizarAluno = @"
            UPDATE aluno 
            SET peso = @peso, altura = @altura, meta = @meta, sessoes = @sessoes
            WHERE idAluno = @idAluno";

                using (MySqlCommand cmd = new MySqlCommand(queryAtualizarAluno, conexao))
                {
                    cmd.Parameters.AddWithValue("@peso", txtPeso.Text);
                    cmd.Parameters.AddWithValue("@altura", txtAltura.Text);
                    cmd.Parameters.AddWithValue("@meta", txtMeta.Text);
                    cmd.Parameters.AddWithValue("@sessoes", txtSessoes.Text);
                    cmd.Parameters.AddWithValue("@idAluno", idAluno);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Dados atualizados com sucesso!");

                // Fechar a tela de perfil e reabrir a tela de treinos com as informações atualizadas
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar os dados: {ex.Message}");
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close(); // Apenas fecha a tela sem salvar
        }
    }
}
