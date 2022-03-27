-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : mer. 23 mars 2022 à 17:35
-- Version du serveur : 10.4.21-MariaDB
-- Version de PHP : 8.0.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `ppe3`
--

-- --------------------------------------------------------

--
-- Structure de la table `container`
--

CREATE TABLE `container` (
  `numContainer` int(6) NOT NULL,
  `dateAchat` date NOT NULL,
  `typeContainer` varchar(40) NOT NULL,
  `dateDerniereInsp` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `container`
--

INSERT INTO `container` (`numContainer`, `dateAchat`, `typeContainer`, `dateDerniereInsp`) VALUES
(2, '2022-01-18', 'Medium Flat Rack Container', '2022-01-18'),
(3, '2022-01-13', 'Conteneur de fret sec haut', '2022-01-15'),
(4, '2022-01-18', 'Petit conteneur réfrigéré', '2022-01-18'),
(75, '2022-01-18', 'Conteneur de fret sec moyen', '2022-01-18');

-- --------------------------------------------------------

--
-- Structure de la table `decision`
--

CREATE TABLE `decision` (
  `numInspection` int(3) NOT NULL,
  `NumContainer` int(6) NOT NULL,
  `codeTravaux` char(6) NOT NULL,
  `dateEnvoi` date NOT NULL,
  `dateRetour` date NOT NULL,
  `commentaireDecision` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `declaration`
--

CREATE TABLE `declaration` (
  `codeDeclaration` int(9) NOT NULL,
  `commentaireDeclaration` varchar(100) DEFAULT NULL,
  `dateDeclaration` date NOT NULL,
  `codeDocker` char(4) NOT NULL,
  `urgence` tinyint(1) NOT NULL,
  `traite` tinyint(1) NOT NULL,
  `numContainer` int(6) DEFAULT NULL,
  `libelleProbleme` varchar(40) DEFAULT NULL
) ;

--
-- Déchargement des données de la table `declaration`
--

INSERT INTO `declaration` (`codeDeclaration`, `commentaireDeclaration`, `dateDeclaration`, `codeDocker`, `urgence`, `traite`, `numContainer`, `libelleProbleme`) VALUES
(3, 'RTE', '2022-03-18', '456', 1, 1, 3, 'Choc sur container'),
(12, 'Jeremy', '2021-11-19', '45', 1, 1, NULL, 'système de fermeture défectueux'),
(14, 'je suis la', '2022-01-18', '23', 1, 1, NULL, 'système de fermeture défectueux'),
(15, 'JF', '2022-01-18', '45', 0, 1, NULL, 'pb réfrigération'),
(16, 'traite', '2022-01-18', '34', 0, 0, NULL, 'Choc sur container'),
(17, 'zzz', '2022-01-18', '54', 1, 1, NULL, 'pb réfrigération'),
(18, 'DEEDEDDE', '2022-03-17', '33', 0, 1, NULL, 'Choc sur container'),
(19, 'DDEEDEDDETTEST', '2022-03-17', '45', 0, 0, NULL, 'Autre'),
(20, 'EDDE', '2022-03-18', '45', 1, 1, 2, 'Choc sur container');

-- --------------------------------------------------------

--
-- Structure de la table `inspection`
--

CREATE TABLE `inspection` (
  `numInspection` int(3) NOT NULL,
  `NumContainer` int(6) NOT NULL,
  `dateInscription` date NOT NULL,
  `commentairePostInspection` varchar(100) DEFAULT NULL,
  `Avis` varchar(20) DEFAULT NULL,
  `libelleMotif` varchar(40) NOT NULL,
  `libelleEtat` varchar(40) NOT NULL
) ;

--
-- Déchargement des données de la table `inspection`
--

INSERT INTO `inspection` (`numInspection`, `NumContainer`, `dateInscription`, `commentairePostInspection`, `Avis`, `libelleMotif`, `libelleEtat`) VALUES
(56, 75, '2022-03-17', 'RFRF', 'FRFR', 'réparation d’urgence', 'Prévue'),
(444, 4, '2022-03-25', 'EDED', 'TEST', 'réparation d’urgence', 'En cours');

-- --------------------------------------------------------

--
-- Structure de la table `travaux`
--

CREATE TABLE `travaux` (
  `codeTravaux` char(6) NOT NULL,
  `libelleTravaux` varchar(30) NOT NULL,
  `dureeImobilisation` int(3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

CREATE TABLE `utilisateur` (
  `code` smallint(6) NOT NULL,
  `role` varchar(20) NOT NULL,
  `raisonSociale` char(50) NOT NULL,
  `adresse` char(80) NOT NULL,
  `cp` char(5) NOT NULL,
  `ville` char(40) NOT NULL,
  `adrMel` char(100) NOT NULL,
  `telephone` char(15) NOT NULL,
  `contact` char(50) NOT NULL,
  `login` char(10) NOT NULL,
  `mdp` char(10) NOT NULL,
  `codePays` char(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`code`, `role`, `raisonSociale`, `adresse`, `cp`, `ville`, `adrMel`, `telephone`, `contact`, `login`, `mdp`, `codePays`) VALUES
(2, 'chef', 'tholdi', '23 emy les près', '95240', 'Cormeilles en Parisis', 'tholdi@orange.fr', '0156854575', 'Martin', 'tholdi', 'Azerty1', 'AD');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `container`
--
ALTER TABLE `container`
  ADD PRIMARY KEY (`numContainer`);

--
-- Index pour la table `decision`
--
ALTER TABLE `decision`
  ADD PRIMARY KEY (`numInspection`,`NumContainer`,`codeTravaux`),
  ADD KEY `fk_descTrav` (`codeTravaux`);

--
-- Index pour la table `declaration`
--
ALTER TABLE `declaration`
  ADD PRIMARY KEY (`codeDeclaration`),
  ADD KEY `fk_typeCont` (`numContainer`);

--
-- Index pour la table `inspection`
--
ALTER TABLE `inspection`
  ADD PRIMARY KEY (`numInspection`,`NumContainer`),
  ADD KEY `fk_codeCont` (`NumContainer`);

--
-- Index pour la table `travaux`
--
ALTER TABLE `travaux`
  ADD PRIMARY KEY (`codeTravaux`);

--
-- Index pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  ADD PRIMARY KEY (`code`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `declaration`
--
ALTER TABLE `declaration`
  MODIFY `codeDeclaration` int(9) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  MODIFY `code` smallint(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `decision`
--
ALTER TABLE `decision`
  ADD CONSTRAINT `fk_decsInspect` FOREIGN KEY (`numInspection`,`NumContainer`) REFERENCES `inspection` (`numInspection`, `NumContainer`),
  ADD CONSTRAINT `fk_descTrav` FOREIGN KEY (`codeTravaux`) REFERENCES `travaux` (`codeTravaux`);

--
-- Contraintes pour la table `declaration`
--
ALTER TABLE `declaration`
  ADD CONSTRAINT `fk_typeCont` FOREIGN KEY (`numContainer`) REFERENCES `container` (`numContainer`);

--
-- Contraintes pour la table `inspection`
--
ALTER TABLE `inspection`
  ADD CONSTRAINT `fk_codeCont` FOREIGN KEY (`NumContainer`) REFERENCES `container` (`numContainer`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
