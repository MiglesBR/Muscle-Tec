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

        // Carregar os dados do aluno e do usuário no formulário
        private void CarregarPerfil()
        {
            try
            {
                // Query para pegar os dados do aluno e do usuário
                string query = @"
                    SELECT u.nome, u.email, u.senha, u.cpf, 
                           a.peso, a.altura, a.meta, a.sessoes
                    FROM aluno a
                    INNER JOIN usuario u ON a.idUsuario = u.idUsuario
                    WHERE a.idAluno = @idAluno";

                using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@idAluno", idAluno);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Carregar dados do usuário
                        txtNome.Text = reader["nome"].ToString();
                        txtEmail.Text = reader["email"].ToString();
                        txtSenha.Text = reader["senha"].ToString();
                        txtCpf.Text = reader["cpf"].ToString();

                        // Carregar dados do aluno
                        txtPeso.Text = reader["peso"].ToString();
                        txtAltura.Text = reader["altura"].ToString();
                        txtMeta.Text = reader["meta"].ToString();
                        txtSessoes.Text = reader["sessoes"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o perfil: {ex.Message}");
            }
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Atualiza os dados na tabela 'usuario'
                string queryAtualizarUsuario = @"
                    UPDATE usuario 
                    SET nome = @novoNome, email = @novoEmail, senha = @novaSenha, cpf = @novoCpf
                    WHERE idUsuario = (SELECT idUsuario FROM aluno WHERE idAluno = @idAluno)";

                using (MySqlCommand cmd = new MySqlCommand(queryAtualizarUsuario, conexao))
                {
                    cmd.Parameters.AddWithValue("@novoNome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@novoEmail", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@novaSenha", txtSenha.Text);
                    cmd.Parameters.AddWithValue("@novoCpf", txtCpf.Text);
                    cmd.Parameters.AddWithValue("@idAluno", idAluno);

                    cmd.ExecuteNonQuery();
                }

                // Atualiza os dados na tabela 'aluno'
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
                this.Close(); // Fecha a tela após salvar os dados
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

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            txtSenha.PasswordChar = '\0'; // Remove o PasswordChar para mostrar o texto
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            txtSenha.PasswordChar = '*'; // Restaura o PasswordChar para ocultar o texto
        }
    }
}
