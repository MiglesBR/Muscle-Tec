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
    public partial class Login : Form
    {
        private MySqlConnection conexao;
        public Login()
        {
            InitializeComponent();
            ConectarBanco();
           
        }

        private void ConectarBanco()
        {
            string servidor = "localhost"; // ou o IP do seu servidor MySQL
            string banco = "muscletec";
            string usuario = "root"; // ou o usuário configurado
            string senha = "";

            string stringConexao = $"SERVER={servidor}; DATABASE={banco}; UID={usuario}; PASSWORD={senha};";

            try
            {
                conexao = new MySqlConnection(stringConexao);
                conexao.Open();
                MessageBox.Show("Conexão bem-sucedida!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar: {ex.Message}");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////

        private int ObterIdTreinador(string email)
        {
            try
            {
                string query = "SELECT idUsuario FROM usuario WHERE email = @eemail AND tipo = 'Instrutor'";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@eemail", email);

                object resultado = cmd.ExecuteScalar();

                if (resultado != null)
                {
                    return Convert.ToInt32(resultado); // Retorna o ID do treinador
                }
                else
                {
                    throw new Exception("Usuário não encontrado ou não é instrutor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter ID do treinador: {ex.Message}");
                return -1; // Retorna um valor inválido para indicar erro
            }
        }

        ///////////////////////////////////////////////////////////////////////////////

        public static class ConexaoDB
        {
            private static string stringConexao = "SERVER=localhost; DATABASE=muscletec; UID=root; PASSWORD=;";
            private static MySqlConnection conexao;

            public static MySqlConnection GetConexao()
            {
                if (conexao == null || conexao.State == ConnectionState.Closed)
                {
                    conexao = new MySqlConnection(stringConexao);
                    conexao.Open();
                }
                return conexao;
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////

        private void LogarUsuario()
        {
            string email = textBox1.Text; // Campo para o e-mail
            string senha = textBox2.Text; // Campo para a senha

            try
            {
                // Consulta para verificar o login e obter o tipo do usuário
                string query = "SELECT tipo FROM usuario WHERE email = @eemail AND senha = @senha";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@eemail", email);
                cmd.Parameters.AddWithValue("@senha", senha);

                object resultado = cmd.ExecuteScalar(); // Retorna o tipo do usuário ou null


                if (resultado != null)
                {
                    string tipoUsuario = resultado.ToString();

                    // Redireciona com base no tipo
                    if (tipoUsuario == "Aluno")
                    {
                        MessageBox.Show("Bem-vindo, Aluno!");
                        Treinos Treinos = new Treinos();
                        Treinos.Show();
                        
                    }
                    else if (tipoUsuario == "Instrutor")
                    {
                        MessageBox.Show("Bem-vindo, Instrutor!");
                        int idTreinador = ObterIdTreinador(email);
                        Alunos Alunos = new Alunos(ConexaoDB.GetConexao(), idTreinador);
                        Alunos.Show();
                        
                    }
                }
                else
                {
                    MessageBox.Show("E-mail ou senha inválidos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao fazer login: {ex.Message}");
            }
        

        }

        
        /// /////////////////////////////////////////////////////////////////////////////////
        

            private void Login_Load(object sender, EventArgs e)
        {

        }

         

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogarUsuario();
        }
    }
}
