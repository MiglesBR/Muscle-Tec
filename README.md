# **Muscle TEC - Gerenciamento de Treinos**

## **Descrição do Projeto**  
Muscle TEC é um sistema desenvolvido para gerenciar treinos e atividades físicas de uma academia. Ele fornece funcionalidades tanto para **alunos**, que podem acessar e visualizar seus treinos, quanto para **instrutores**, que podem criar, gerenciar e atribuir exercícios e treinos aos alunos. O sistema busca otimizar a comunicação e o acompanhamento dos treinos de forma prática e eficiente.

---

## **Principais Funcionalidades**

### **1. Login e Cadastro**  
- **Cadastro**:
  - Alunos podem ser registrados com um instrutor designado.
  - Instrutores podem ser cadastrados com seus detalhes, como CREF.
- **Login**:
  - Diferencia entre os tipos de usuários (**Instrutor** ou **Aluno**) para redirecionar para as funcionalidades específicas.

### **2. Funcionalidades do Aluno**
- Visualizar **treinos atribuídos** e exercícios relacionados.
- Acompanhar as sessões realizadas com incremento automático por treino concluído.
- Atualizar perfil (peso, altura, metas, etc.).
- Visualizar estatísticas como número total de sessões realizadas.

### **3. Funcionalidades do Instrutor**
- Criar e gerenciar **exercícios** para alunos.
- Criar e gerenciar **treinos**, vinculando exercícios específicos.
- Gerenciar os alunos atribuídos ao instrutor, com informações detalhadas de cada aluno.
- Atualizar informações dos alunos, como metas ou treinos atribuídos.

### **4. Gerenciamento de Dados**
- O sistema utiliza o **MySQL** para armazenamento de dados:
  - Tabelas incluem **usuários**, **alunos**, **instrutores**, **exercícios**, **treinos**, entre outros.
  - Relacionamentos bem definidos para garantir integridade referencial.

---

## **Tecnologias Utilizadas**
- **Linguagem:** C# (Windows Forms)
- **Banco de Dados:** MySQL
- **Ferramentas:** Visual Studio
- **Framework:** .NET Framework
- **Bibliotecas Externas:** MySQL.Data para integração com banco de dados.

---

## **Como Usar o Sistema**

### **Instalação e Configuração**
1. Clone o repositório do projeto:  
   ```bash
   git clone https://github.com/usuario/muscletec.git
   ```
2. Configure o banco de dados:
   - Importe o arquivo `muscletec.sql` disponível na pasta `database/` para o seu MySQL.
   - Certifique-se de atualizar as credenciais de acesso ao banco no código (`ConexaoDB`).
3. Abra o projeto no Visual Studio e compile-o.

### **Execução**
1. Após iniciar o programa, use:
   - Credenciais de **instrutor** para gerenciar treinos e alunos.
   - Credenciais de **aluno** para visualizar treinos e estatísticas.
2. Utilize as opções do menu para navegar entre as telas.

---

## **Modelo de Banco de Dados**
O banco de dados possui as seguintes tabelas principais:
- **`usuario`**: Contém informações básicas (nome, email, senha, tipo).
- **`aluno`**: Estende a tabela `usuario` com dados específicos do aluno (peso, altura, metas, sessões realizadas, instrutor responsável).
- **`instrutor`**: Estende a tabela `usuario` com detalhes do instrutor (CREF).
- **`treino`**: Relaciona-se com `aluno` e contém informações dos treinos.
- **`exercicio`**: Contém os exercícios que podem ser atribuídos a treinos.
- **`treino_exercicio`**: Relaciona `treino` e `exercicio`.

---

## **Estrutura do Sistema**
O projeto é dividido em telas e classes de gerenciamento:
- **Telas:**
  - `TelaInicial`: Tela de boas-vindas.
  - `Login`: Autenticação do usuário.
  - `Cadastro`: Registro do usuário e sua permissão.
  - `TelaAluno`: Direcionamento para as funcionalidades do aluno.
  - `Treinos`: Visualização dos treinos atribuidos ao aluno.
  - `ExerciciosAluno`: Visualização dos exercícios contidos no respectivo treino.
  - `PerfilAluno`: Edição de informações do aluno.
  - `TelaInstrutor`: Direcionamento para as funcionalidades do instrutor.
  - `Alunos`: Exibição dos alunos atribuidos a aquele instrutor.
  - `TelaTreinos`: Exibição e gerenciamento dos treinos de um aluno.
  - `AdicionarTreinoForm`: Criação de treinos com exercícios.
  - `CriarExercicio`: Registro de novos exercícios no sistema.

- **Classes de Suporte:**
  - `ConexaoDB`: Gerencia a conexão com o banco de dados.
  - `Utils`: Contém métodos auxiliares para validações e formatações.

---

## **Pontos a Melhorar**
- Melhorar o layout das telas para maior usabilidade.
- Adicionar autenticação mais segura para senhas (ex: hash).
- Implementar relatórios para o instrutor, como progresso dos alunos.
- Criar uma API para integrar o sistema com outras plataformas no futuro.

---

## **Contato**
Desenvolvido por: **[Miguel Maia, Caio Fábio, Kimberly Moura]**  
Para dúvidas ou sugestões, envie um email para **[miguelmartinsmaia48@gmail.com]**. 
