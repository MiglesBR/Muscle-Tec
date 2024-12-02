-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 02/12/2024 às 02:13
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
(31, NULL, 'Supino Reto', 'Exercício de peito realizado no banco reto com barra ou halteres.'),
(32, NULL, 'Supino Inclinado', 'Variante do supino, focado na parte superior do peito.'),
(33, NULL, 'Crucifixo', 'Exercício de peito realizado com halteres, enfatizando a abertura dos braços.'),
(34, NULL, 'Crossover', 'Exercício de peito com cabos para isolar os músculos peitorais.'),
(35, NULL, 'Barra Fixa', 'Exercício de costas que utiliza o peso do corpo para fortalecer a dorsal.'),
(36, NULL, 'Remada Curvada', 'Exercício de costas realizado com barra para espessura muscular.'),
(37, NULL, 'Pulldown', 'Exercício com polia para ativar o grande dorsal.'),
(38, NULL, 'Remada Unilateral', 'Exercício isolado para costas, realizado com halteres.'),
(39, NULL, 'Agachamento Livre', 'Exercício composto para quadríceps e glúteos realizado com barra.'),
(40, NULL, 'Leg Press', 'Exercício de pernas realizado na máquina de leg press.'),
(41, NULL, 'Extensora', 'Isolamento de quadríceps realizado em máquina.'),
(42, NULL, 'Passada', 'Exercício de avanço, trabalhando pernas e glúteos.'),
(43, NULL, 'Stiff', 'Exercício para isquiotibiais realizado com barra ou halteres.'),
(44, NULL, 'Flexora deitada', 'Exercício isolado para posteriores em máquina.'),
(45, NULL, 'Good Morning', 'Exercício para fortalecer os isquiotibiais e glúteos.'),
(46, NULL, 'Glúteo na Polia', 'Exercício para posterior de coxa e glúteos, realizado com cabos.'),
(47, NULL, 'Desenvolvimento com Halteres', 'Exercício de ombro realizado com halteres.'),
(48, NULL, 'Elevação Lateral', 'Isolamento para deltoides laterais com halteres.'),
(49, NULL, 'Desenvolvimento Arnold', 'Variante do desenvolvimento para trabalhar mais o ombro.'),
(50, NULL, 'Elevação Frontal', 'Exercício de ombro focado na parte frontal.'),
(51, NULL, 'Rosca Direta', 'Exercício clássico para bíceps realizado com barra.'),
(52, NULL, 'Rosca Alternada', 'Exercício de bíceps realizado com halteres alternadamente.'),
(53, NULL, 'Rosca Martelo', 'Exercício de bíceps braquial realizado com pegada neutra.'),
(54, NULL, 'Rosca Concentrada', 'Exercício isolado para bíceps realizado com halteres.'),
(55, NULL, 'Tríceps Pulley', 'Exercício de tríceps realizado na polia com barra reta.'),
(56, NULL, 'Tríceps Testa', 'Exercício isolado realizado com barra para tríceps.'),
(57, NULL, 'Tríceps Mergulho', 'Exercício para tríceps utilizando o peso do corpo.'),
(58, NULL, 'Kickback', 'Exercício de tríceps realizado com halteres.'),
(59, NULL, 'Abdominal Supra', 'Exercício básico para fortalecimento do abdômen superior.'),
(60, NULL, 'Prancha Isométrica', 'Exercício de estabilidade para abdômen.'),
(61, NULL, 'Elevação de Pernas', 'Exercício para abdômen inferior realizado deitado.'),
(62, NULL, 'Abdominal na Polia', 'Exercício de abdômen realizado com carga em polia.');

-- --------------------------------------------------------

--
-- Estrutura para tabela `instrutor`
--

CREATE TABLE `instrutor` (
  `idTreinador` int(11) NOT NULL,
  `cref` varchar(20) NOT NULL,
  `idUsuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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

-- --------------------------------------------------------

--
-- Estrutura para tabela `treino_exercicio`
--

CREATE TABLE `treino_exercicio` (
  `id` int(11) NOT NULL,
  `idTreino` int(11) NOT NULL,
  `idExercicio` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
  MODIFY `idAluno` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de tabela `exercicios`
--
ALTER TABLE `exercicios`
  MODIFY `idExercicio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=63;

--
-- AUTO_INCREMENT de tabela `instrutor`
--
ALTER TABLE `instrutor`
  MODIFY `idTreinador` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `treino`
--
ALTER TABLE `treino`
  MODIFY `idTreino` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de tabela `treino_exercicio`
--
ALTER TABLE `treino_exercicio`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `idUsuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

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
