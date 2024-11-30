﻿using System;
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
    public partial class Treinos : Form
    {
        public Treinos(MySqlConnection conexao, int idAluno)
        {
            InitializeComponent();
            CarregarTreinos(idAluno);
            AdicionarBotaoExercicios();
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
                // String de conexão válida
                string connectionString = "SERVER=localhost; DATABASE=muscletec; UID=root; PASSWORD=;";
                using (MySqlConnection conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    // Query para buscar os treinos apenas do aluno logado
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

                    // Define o DataTable como fonte de dados para o DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Opcional: Ajusta os nomes das colunas
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



        ///////////

        private void AdicionarBotaoExercicios()
        {
            if (!dataGridView1.Columns.Contains("btnExercicios"))
            {
                // Cria o botão
                DataGridViewButtonColumn botaoExercicios = new DataGridViewButtonColumn
                {
                    Name = "btnExercicios",
                    HeaderText = "Exercícios",
                    Text = "Ver Exercícios",
                    UseColumnTextForButtonValue = true
                };

                // Adiciona o botão ao DataGridView
                dataGridView1.Columns.Add(botaoExercicios);
                
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


        //////////

        private void MostrarExercicios(int idTreino)
        {
            string query = @"
                    SELECT nomeExercicio, descricao 
                    FROM exercicios
                    INNER JOIN treino_exercicio ON exercicios.idExercicio = treino_exercicio.idExercicio
                    WHERE treino_exercicio.idTreino = @idTreino";
            try
            {
                using (MySqlConnection conn = ConexaoDB.GetConexao()) // Obtém a conexão com a classe ConexaoDB
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idTreino", idTreino);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Exibe os dados no mesmo DataGridView ou em outro formulário
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
