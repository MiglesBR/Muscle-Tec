using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq;


namespace Projeto_Muscle_Tec
{
    public partial class TelaTreinos : Form
    {
        private int idAluno; // ID do aluno atual
        private int idTreinoSelecionado;
        private int idExercicioSelecionado;
        // Exemplo de string de conexão
        private string conexaoBanco = "SERVER=localhost; DATABASE=muscletec; UID=root; PASSWORD=;";


        public TelaTreinos(int alunoId)
        {
            InitializeComponent();
            idAluno = alunoId;

            // Associando o evento AfterSelect ao método
            this.treeViewTreinos.AfterSelect += new TreeViewEventHandler(this.treeViewTreinos_AfterSelect);

            ExibirNomeAluno();
            CarregarTreinosEExercicios(); // Carrega treinos e exercícios ao abrir a tela
        }

        private void ExibirNomeAluno()
        {
            string query = "SELECT u.nome FROM usuario u INNER JOIN aluno a ON u.idUsuario = a.idUsuario WHERE a.idAluno = @idAluno";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(conexaoBanco))
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idAluno", idAluno);

                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            string nomeAluno = resultado.ToString();
                            label1.Text = $"Treino - {nomeAluno}";
                        }
                        else
                        {
                            label1.Text = "Treino - Aluno não encontrado";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o nome do aluno: {ex.Message}");
            }
        }

        /// Carrega os treinos e os exercícios vinculados ao aluno
        private void CarregarTreinosEExercicios()
        {
            string query = @"
    SELECT 
        t.idTreino, t.nomeTreino AS NomeTreino, t.descricao AS Descricao,
        e.idExercicio, e.nomeExercicio AS NomeExercicio
    FROM 
        treino t
    LEFT JOIN 
        treino_exercicio te ON t.idTreino = te.idTreino
    LEFT JOIN 
        exercicios e ON te.idExercicio = e.idExercicio
    WHERE 
        t.idAluno = @idAluno";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(conexaoBanco))
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idAluno", idAluno);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Novo dicionário ajustado para o formato esperado
                            var listaTreinos = new Dictionary<int, (string nome, string descricao, Dictionary<string, int> exercicios)>();

                            while (reader.Read())
                            {
                                int idTreino = Convert.ToInt32(reader["idTreino"]);
                                string nomeTreino = reader["NomeTreino"].ToString();
                                string descricao = reader["Descricao"]?.ToString() ?? ""; // Descrição pode ser nula
                                int idExercicio = reader["idExercicio"] != DBNull.Value ? Convert.ToInt32(reader["idExercicio"]) : 0;
                                string nomeExercicio = reader["NomeExercicio"]?.ToString();

                                if (!listaTreinos.ContainsKey(idTreino))
                                {
                                    // Inicializa a estrutura para um treino
                                    listaTreinos[idTreino] = (nome: nomeTreino, descricao: descricao, exercicios: new Dictionary<string, int>());
                                }

                                // Adiciona exercícios ao treino
                                if (!string.IsNullOrEmpty(nomeExercicio))
                                {
                                    listaTreinos[idTreino].exercicios.Add(nomeExercicio, idExercicio);
                                }
                            }

                            // Passa o dicionário ajustado para a função ExibirTreinosEExercicios
                            ExibirTreinosEExercicios(listaTreinos);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar treinos e exercícios: {ex.Message}");
            }
        }

        /// Exibe os treinos e exercícios no TreeView
        /// <param name="listaTreinos">Dicionário contendo treinos e exercícios</param>
        private void ExibirTreinosEExercicios(Dictionary<int, (string nome, string descricao, Dictionary<string, int> exercicios)> listaTreinos)
        {
            treeViewTreinos.Nodes.Clear(); // Limpa o TreeView antes de exibir os dados

            foreach (var treino in listaTreinos)
            {
                int idTreino = treino.Key;
                string nomeTreino = treino.Value.nome;
                string descricaoTreino = treino.Value.descricao;

                // Cria o nó do treino com nome e descrição
                TreeNode nodeTreino = new TreeNode($"{nomeTreino} - '{descricaoTreino}'") { Tag = idTreino };

                foreach (var exercicio in treino.Value.exercicios)
                {
                    // Adiciona os exercícios como subnós
                    TreeNode nodeExercicio = new TreeNode(exercicio.Key) { Tag = exercicio.Value };
                    nodeTreino.Nodes.Add(nodeExercicio);
                }

                treeViewTreinos.Nodes.Add(nodeTreino); // Adiciona o treino ao TreeView
            }

            treeViewTreinos.ExpandAll(); // Expande todos os nós para facilitar a visualização

        }

        private void treeViewTreinos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;

            if (selectedNode.Parent != null) // Nó de exercício
            {
                int idTreino = Convert.ToInt32(selectedNode.Parent.Tag); // ID do treino (nó pai)
                int idExercicio = Convert.ToInt32(selectedNode.Tag); // ID do exercício (nó selecionado)

                idExercicioSelecionado = idExercicio; // Atualiza a variável global
                idTreinoSelecionado = idTreino; // Atualiza a variável global

                lblExercicioSelecionado.Text = $"Treino {idTreino} - Exercício: {selectedNode.Text}";
            }
            else // Nó de treino
            {
                int idTreino = Convert.ToInt32(selectedNode.Tag); // ID do treino (nó selecionado)

                lblExercicioSelecionado.Text = $"Treino selecionado: {idTreino}";
            }
        }

        private void AtualizarTreeView() //Arrumar problema referente ao idAluno
        {
            // Recarrega os treinos e exercícios do banco de dados
            var listaTreinos = new Dictionary<int, (string nome, string descricao, Dictionary<string, int> exercicios)>();

            string query = @"
        SELECT 
            t.idTreino AS idTreino, 
            t.nomeTreino AS nomeTreino, 
            t.descricao AS descricao, 
            e.nomeExercicio AS nomeExercicio, 
            e.idExercicio AS idExercicio
        FROM 
            treino t
        LEFT JOIN 
            treino_exercicio te ON t.idTreino = te.idTreino
        LEFT JOIN 
            exercicios e ON te.idExercicio = e.idExercicio
        WHERE 
            t.idAluno = @idAluno"; // Filtra os treinos pelo aluno atual

            try
            {
                using (MySqlConnection connection = new MySqlConnection(conexaoBanco))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idAluno", idAluno); // Filtra pelo ID do aluno

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idTreino = reader.GetInt32("idTreino");
                                string nomeTreino = reader["nomeTreino"].ToString();
                                string descricao = reader["descricao"]?.ToString() ?? "";
                                string nomeExercicio = reader["nomeExercicio"]?.ToString() ?? "";
                                int idExercicio = reader["idExercicio"] != DBNull.Value ? reader.GetInt32("idExercicio") : 0;

                                // Inicializa o dicionário para o treino, se necessário
                                if (!listaTreinos.ContainsKey(idTreino))
                                {
                                    listaTreinos[idTreino] = (nome: nomeTreino, descricao: descricao, exercicios: new Dictionary<string, int>());
                                }

                                // Adiciona os exercícios ao treino
                                if (!string.IsNullOrEmpty(nomeExercicio))
                                {
                                    listaTreinos[idTreino].exercicios[nomeExercicio] = idExercicio;
                                }
                            }
                        }
                    }
                }

                // Atualiza o TreeView com os dados carregados
                ExibirTreinosEExercicios(listaTreinos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar os treinos: {ex.Message}");
            }
        }



        /// <summary>
        /// Remover o exercício selecionado do treino
        /// </summary>
        private void btnRemoverExercicio_Click(object sender, EventArgs e)
        {
            if (idExercicioSelecionado != 0 && idTreinoSelecionado != 0)
            {
                // Executa a exclusão do exercício
                string queryRemoverExercicio = "DELETE FROM treino_exercicio WHERE idExercicio = @idExercicio AND idTreino = @idTreino";

                using (MySqlConnection connection = new MySqlConnection(conexaoBanco))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(queryRemoverExercicio, connection))
                    {
                        command.Parameters.AddWithValue("@idExercicio", idExercicioSelecionado);
                        command.Parameters.AddWithValue("@idTreino", idTreinoSelecionado);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Verifica se ainda há exercícios no treino
                            string queryVerificarExercicios = "SELECT COUNT(*) FROM treino_exercicio WHERE idTreino = @idTreino";

                            using (MySqlCommand verificarCommand = new MySqlCommand(queryVerificarExercicios, connection))
                            {
                                verificarCommand.Parameters.AddWithValue("@idTreino", idTreinoSelecionado);

                                int exerciciosRestantes = Convert.ToInt32(verificarCommand.ExecuteScalar());

                                // Se não houver mais exercícios, exclui o treino
                                if (exerciciosRestantes == 0)
                                {
                                    string queryRemoverTreino = "DELETE FROM treino WHERE idTreino = @idTreino";

                                    using (MySqlCommand removerTreinoCommand = new MySqlCommand(queryRemoverTreino, connection))
                                    {
                                        removerTreinoCommand.Parameters.AddWithValue("@idTreino", idTreinoSelecionado);
                                        removerTreinoCommand.ExecuteNonQuery();

                                        MessageBox.Show("Treino removido, pois não possui mais exercícios.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Exercício removido com sucesso!");
                                }
                                lblExercicioSelecionado.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Erro ao remover o exercício. Verifique os dados.");
                        }
                    }
                }

                AtualizarTreeView(); // Atualiza o TreeView após a exclusão
            }
            else
            {
                MessageBox.Show("Selecione um exercício válido antes de remover.");
            }
        }


        /// <summary>
        /// Botão para adicionar um novo treino
        /// </summary>
        private void btnAdicionarTreino_Click_1(object sender, EventArgs e)
        {
            AdicionarTreinoForm formAdicionar = new AdicionarTreinoForm(idAluno);
            formAdicionar.ShowDialog();
            CarregarTreinosEExercicios(); // Recarrega os treinos após adicionar
        }
    }
}