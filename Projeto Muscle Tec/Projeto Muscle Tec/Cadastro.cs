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
    public partial class Cadastro : Form
    {
        private MySqlConnection conexao;
        public Cadastro()
        {
            InitializeComponent();
            ConectarBanco();

            label9.Visible = false;
            comboBox1.Visible = false;
            label8.Visible = false;
            textBox5.Visible = false;

            PopularComboBoxTreinador();
        }

        private void ConectarBanco()
        {
            string servidor = "localhost";
            string banco = "muscletec";
            string usuario = "root"; 
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
                label8.Visible = true;
                textBox5.Visible = true;
                comboBox1.Visible = false;// treinadores fica invisivel
                label9.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
                label8.Visible = false; // Oculta a label
                textBox5.Visible = false;
                comboBox1.Visible = true;// Treinadores fica visivel
                label9.Visible = true;
        }

        private bool CadastrarUsuario()
        {
            string nome = textBox1.Text;
            string email = textBox2.Text;
            string senha = textBox3.Text;
            string cpf = textBox4.Text;

            string tipoUsuario = radioButton1.Checked ? "Instrutor" : "Aluno";

            try
            {
                // Verifica se CPF ou e-mail já existem no banco
                string queryVerificar = "SELECT COUNT(*) FROM usuario WHERE cpf = @cpf OR email = @eemail";
                MySqlCommand cmdVerificar = new MySqlCommand(queryVerificar, conexao);
                cmdVerificar.Parameters.AddWithValue("@cpf", cpf);
                cmdVerificar.Parameters.AddWithValue("@eemail", email);

                int resultado = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                if (resultado > 0)
                {
                    MessageBox.Show("Erro: CPF ou e-mail já cadastrado no sistema.");
                    return false; // Cadastro não permitido
                }

                // Insere na tabela usuario
                string queryUsuario = "INSERT INTO usuario (nome, email, senha, cpf, tipo) VALUES (@nome, @eemail, @senha, @cpf, @tipo)";
                MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, conexao);
                cmdUsuario.Parameters.AddWithValue("@nome", nome);
                cmdUsuario.Parameters.AddWithValue("@eemail", email);
                cmdUsuario.Parameters.AddWithValue("@senha", senha);
                cmdUsuario.Parameters.AddWithValue("@cpf", cpf);
                cmdUsuario.Parameters.AddWithValue("@tipo", tipoUsuario);
                cmdUsuario.ExecuteNonQuery();

                int idUsuario = (int)cmdUsuario.LastInsertedId; // Recupera o ID gerado

                // Verifica o tipo de usuário e insere na tabela específica
                if (radioButton1.Checked)
                {
                   
                    string cref = textBox5.Text;
                    string queryInstrutor = "INSERT INTO instrutor (cref, idUsuario) VALUES (@cref, @idUsuario)";
                    MySqlCommand cmdInstrutor = new MySqlCommand(queryInstrutor, conexao);
                    cmdInstrutor.Parameters.AddWithValue("@cref", cref);
                    cmdInstrutor.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmdInstrutor.ExecuteNonQuery();
                }
                else if (radioButton2.Checked)
                { 

                    int idTreinador = 0; // Caso nenhum treinador seja selecionado, será 0

                    if (comboBox1.SelectedItem != null)
                    {
                        idTreinador = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;
                    }

                    string queryAluno = "INSERT INTO aluno (idUsuario, idTreinador) VALUES (@idUsuario, @idTreinador)";
                    MySqlCommand cmdAluno = new MySqlCommand(queryAluno, conexao);
                    cmdAluno.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmdAluno.Parameters.AddWithValue("@idTreinador", idTreinador > 0 ? idTreinador : (object)DBNull.Value); // Permite nulo
                    cmdAluno.ExecuteNonQuery();
                }

                MessageBox.Show("Usuário cadastrado com sucesso!");
                return true; // Cadastro realizado com sucesso
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar usuário: {ex.Message}");
                return false; // Cadastro falhou
            }
        }

        private void PopularComboBoxTreinador()
        {
            string query = "SELECT idUsuario, nome FROM usuario WHERE tipo = 'Instrutor'";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Adiciona os treinadores ao ComboBox
                        comboBox1.Items.Add(new KeyValuePair<int, string>(
                        Convert.ToInt32(reader["idUsuario"]),
                        reader["nome"].ToString()
                    ));
                }

                reader.Close();

                // Configura o ComboBox para exibir os nomes
                comboBox1.DisplayMember = "Value"; // Mostra o nome do treinador
                comboBox1.ValueMember = "Key"; // Armazena o ID do treinador
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar treinadores: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CadastrarUsuario())
            {
                Login Login = new Login();
                Login.Show();

                this.Close();
            }
            else
            {
                // Cadastro falhou, manter na tela e limpar campos
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
