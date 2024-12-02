-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 02/12/2024 às 02:01
-- Versão do servidor: 10.4.28-MariaDB
-- Versão do PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `muscletec`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `aluno`
--

CREATE TABLE `aluno` (
  `idAluno` int(11) NOT NULL,
  `peso` varchar(10) DEFAULT NULL,
  `altura` varchar(10) DEFAULT NULL,
  `meta` varchar(100) DEFAULT NULL,
  `sessoes` int(11) NOT NULL DEFAULT 0,
  `idUsuario` int(11) NOT NULL,
  `idTreinador` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `aluno`
--

INSERT INTO `aluno` (`idAluno`, `peso`, `altura`, `meta`, `sessoes`, `idUsuario`, `idTreinador`) VALUES
(1, NULL, NULL, NULL, 0, 6, 13),
(2, NULL, NULL, NULL, 0, 8, NULL),
(3, NULL, NULL, NULL, 0, 10, NULL),
(4, NULL, NULL, NULL, 0, 11, NULL),
(5, NULL, NULL, NULL, 0, 12, 1),
(6, '120', '181', 'chegar nos 120', 10, 14, 3),
(7, NULL, NULL, NULL, 0, 15, 13),
(8, '70', '1.75', 'Ganhar Massa', 0, 1, NULL),
(9, NULL, NULL, NULL, 0, 16, 9),
(10, NULL, NULL, NULL, 0, 17, 9),
(11, NULL, NULL, NULL, 1, 19, 3),
(12, NULL, NULL, NULL, 0, 20, 18);

-- --------------------------------------------------------

--
-- Estrutura para tabela `exercicios`
--

CREATE TABLE `exercicios` (
  `idExercicio` int(11) NOT NULL,
  `idTreino` int(11) DEFAULT NULL,
  `nomeExercicio` varchar(100) NOT NULL,
  `descricao` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `exercicios`
--

INSERT INTO `exercicios` (`idExercicio`, `idTreino`, `nomeExercicio`, `descricao`) VALUES
(7, NULL, 'Supino Inclinado', 'Exercício para trabalhar a parte superior do peito.'),
(8, NULL, 'Puxada Frente', 'Exercício para trabalhar a largura das costas.'),
(9, NULL, 'Remada Curvada', 'Foca no desenvolvimento das costas médias e superiores.'),
(10, NULL, 'Pull-over', 'Exercício para expandir a caixa torácica e trabalhar as costas.'),
(11, NULL, 'Desenvolvimento com Halteres', 'Exercício para trabalhar a parte frontal e média do ombro.'),
(12, NULL, 'Elevação Lateral', 'Foca no desenvolvimento da parte lateral do ombro.'),
(13, NULL, 'Elevação Frontal', 'Exercício para a parte frontal do ombro.'),
(14, NULL, 'Rosca Direta', 'Exercício clássico para o desenvolvimento do bíceps.'),
(15, NULL, 'Rosca Alternada', 'Foca no desenvolvimento de cada bíceps de forma unilateral.'),
(16, NULL, 'Rosca Scott', 'Exercício isolado para os bíceps.'),
(17, NULL, 'Tríceps Testa', 'Exercício para o desenvolvimento do tríceps na parte superior.'),
(18, NULL, 'Tríceps Corda', 'Exercício que trabalha os três músculos do tríceps.'),
(19, NULL, 'Mergulho', 'Exercício de peso corporal focado no tríceps.'),
(20, NULL, 'Agachamento', 'Exercício fundamental para o desenvolvimento das pernas.'),
(21, NULL, 'Leg Press', 'Exercício que trabalha principalmente quadríceps e glúteos.'),
(22, NULL, 'Cadeira Extensora', 'Foca no desenvolvimento dos quadríceps.'),
(23, NULL, 'Avanço', 'Exercício de pernas que foca nos glúteos e quadríceps.'),
(24, NULL, 'Stiff', 'Exercício para trabalhar o posterior de coxas e glúteos.'),
(25, NULL, 'Glúteo na Polia', 'Exercício para isolar os glúteos com o uso da polia.'),
(26, NULL, 'Abdominal Tradicional', 'Exercício clássico para trabalhar a parte superior do abdômen.'),
(27, NULL, 'Prancha', 'Exercício isométrico que fortalece a região abdominal e lombar.'),
(28, NULL, 'Elevação de Pernas', 'Foca na parte inferior do abdômen.'),
(29, NULL, 'teste', 'testeteste'),
(30, NULL, 'Peixe', 'Costas e trapézio');

-- --------------------------------------------------------

--
-- Estrutura para tabela `instrutor`
--

CREATE TABLE `instrutor` (
  `idTreinador` int(11) NOT NULL,
  `cref` varchar(20) NOT NULL,
  `idUsuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `instrutor`
--

INSERT INTO `instrutor` (`idTreinador`, `cref`, `idUsuario`) VALUES
(1, '123459687', 1),
(2, '9321743564', 3),
(3, '123123534', 5),
(4, '123245547567', 7),
(5, '123', 9),
(6, '23142512', 13),
(14, 'jikutreiner', 18),
(15, 'cref', 21);

-- --------------------------------------------------------

--
-- Estrutura para tabela `treino`
--

CREATE TABLE `treino` (
  `idTreino` int(11) NOT NULL,
  `nomeTreino` varchar(50) NOT NULL,
  `descricao` varchar(100) NOT NULL,
  `idAluno` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `treino`
--

INSERT INTO `treino` (`idTreino`, `nomeTreino`, `descricao`, `idAluno`) VALUES
(5, 'Treino C', 'Treino para Costas e Biceps', 6),
(6, 'Treino D', 'Abdomen e Ombro', 6),
(9, 'Treino A', 'Peito', 10),
(13, 'Treino A', 'Peito e Ombros', 11),
(14, 'foda', 'Treino foda', 6);

-- --------------------------------------------------------

--
-- Estrutura para tabela `treino_exercicio`
--

CREATE TABLE `treino_exercicio` (
  `id` int(11) NOT NULL,
  `idTreino` int(11) NOT NULL,
  `idExercicio` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `treino_exercicio`
--

INSERT INTO `treino_exercicio` (`id`, `idTreino`, `idExercicio`) VALUES
(1, 5, 9),
(5, 5, 15),
(7, 6, 12),
(8, 6, 13),
(9, 6, 11),
(11, 6, 27),
(17, 9, 7),
(18, 9, 8),
(19, 9, 9),
(29, 13, 7),
(30, 13, 8),
(31, 13, 13),
(32, 13, 12),
(33, 14, 9),
(35, 14, 11),
(36, 14, 12),
(37, 14, 14),
(38, 14, 16),
(39, 14, 17),
(41, 14, 29),
(42, 14, 30);

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuario`
--

CREATE TABLE `usuario` (
  `idUsuario` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `senha` varchar(255) NOT NULL,
  `cpf` varchar(11) NOT NULL,
  `tipo` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `usuario`
--

INSERT INTO `usuario` (`idUsuario`, `nome`, `email`, `senha`, `cpf`, `tipo`) VALUES
(1, 'Instrutor', 'Instrutor@gmail.com', '123', '31845618732', 'Instrutor'),
(3, 'Instrutor2', 'Instrutor2@gmail.com', '123', '93873218322', 'Instrutor'),
(5, 'Instrutor3', 'Instrutor3@gmail.com', '123', '123973724', 'Instrutor'),
(6, 'Aluno', 'Aluno@gmail.com', '123', '39128745323', 'Aluno'),
(7, 'Instrutor4', 'Instrutor4@gmail.com', '123', '12395384', 'Instrutor'),
(8, 'Aluno2', 'Aluno2@gmail.com', '123', '123', 'Aluno'),
(9, 'Instrutor5', 'Instrutor5@gmail.com', '123', '125', 'Instrutor'),
(10, 'kimkim', 'kimkim@gmail.com', '123', '129', 'Aluno'),
(11, 'Matheus Barbosa |Chambo', 'Theus14525@gmail.com', 'Theus1004', '51418918873', 'Aluno'),
(12, 'Caio Fabio', 'caio@gmail.com', '1234', '123456789', 'Aluno'),
(13, 'Paulo', 'paulo@gmail.com', '123', '293810', 'Instrutor'),
(14, 'Miguel', 'miguel@gmail.com', '123', '1234', 'Aluno'),
(15, 'joao', 'joao@gmail.com', '123', '12343', 'Aluno'),
(16, 'jikuzinho', 'jikujiku@gmail.com', 'jiku', '1234578910', 'Aluno'),
(17, 'jiku', 'jiku@gmail.com', 'jiku', '12345678910', 'Aluno'),
(18, 'jikutreiner', 'jikutreiner', 'jikutreiner', 'jikutreiner', 'Instrutor'),
(19, 'kimberly', 'kimberly@gmail.com', '4321', '87654321', 'Aluno'),
(20, 'nome', 'email', 'senha', 'cpf', 'Aluno'),
(21, 'nometreiner', 'emailtreiner', 'senhatreiner', 'cpftreiner', 'Instrutor');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `aluno`
--
ALTER TABLE `aluno`
  ADD PRIMARY KEY (`idAluno`),
  ADD KEY `idUsuario` (`idUsuario`),
  ADD KEY `fk_idTreinador` (`idTreinador`);

--
-- Índices de tabela `exercicios`
--
ALTER TABLE `exercicios`
  ADD PRIMARY KEY (`idExercicio`),
  ADD KEY `idTreino` (`idTreino`);

--
-- Índices de tabela `instrutor`
--
ALTER TABLE `instrutor`
  ADD PRIMARY KEY (`idTreinador`),
  ADD UNIQUE KEY `cref` (`cref`),
  ADD KEY `idUsuario` (`idUsuario`);

--
-- Índices de tabela `treino`
--
ALTER TABLE `treino`
  ADD PRIMARY KEY (`idTreino`),
  ADD KEY `idAluno` (`idAluno`);

--
-- Índices de tabela `treino_exercicio`
--
ALTER TABLE `treino_exercicio`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idTreino` (`idTreino`),
  ADD KEY `idExercicio` (`idExercicio`);

--
-- Índices de tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`idUsuario`),
  ADD UNIQUE KEY `email` (`email`),
  ADD UNIQUE KEY `cpf` (`cpf`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `aluno`
--
ALTER TABLE `aluno`
  MODIFY `idAluno` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de tabela `exercicios`
--
ALTER TABLE `exercicios`
  MODIFY `idExercicio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT de tabela `instrutor`
--
ALTER TABLE `instrutor`
  MODIFY `idTreinador` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT de tabela `treino`
--
ALTER TABLE `treino`
  MODIFY `idTreino` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de tabela `treino_exercicio`
--
ALTER TABLE `treino_exercicio`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `idUsuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `aluno`
--
ALTER TABLE `aluno`
  ADD CONSTRAINT `aluno_ibfk_1` FOREIGN KEY (`idUsuario`) REFERENCES `usuario` (`idUsuario`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_idTreinador` FOREIGN KEY (`idTreinador`) REFERENCES `usuario` (`idUsuario`) ON DELETE SET NULL;

--
-- Restrições para tabelas `exercicios`
--
ALTER TABLE `exercicios`
  ADD CONSTRAINT `exercicios_ibfk_1` FOREIGN KEY (`idTreino`) REFERENCES `treino` (`idTreino`) ON DELETE CASCADE;

--
-- Restrições para tabelas `instrutor`
--
ALTER TABLE `instrutor`
  ADD CONSTRAINT `instrutor_ibfk_1` FOREIGN KEY (`idUsuario`) REFERENCES `usuario` (`idUsuario`) ON DELETE CASCADE;

--
-- Restrições para tabelas `treino`
--
ALTER TABLE `treino`
  ADD CONSTRAINT `treino_ibfk_1` FOREIGN KEY (`idAluno`) REFERENCES `aluno` (`idUsuario`) ON DELETE CASCADE;

--
-- Restrições para tabelas `treino_exercicio`
--
ALTER TABLE `treino_exercicio`
  ADD CONSTRAINT `treino_exercicio_ibfk_1` FOREIGN KEY (`idTreino`) REFERENCES `treino` (`idTreino`),
  ADD CONSTRAINT `treino_exercicio_ibfk_2` FOREIGN KEY (`idExercicio`) REFERENCES `exercicios` (`idExercicio`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
