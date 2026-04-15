-- phpMyAdmin SQL Dump
-- version 5.2.1deb1+deb12u1
-- https://www.phpmyadmin.net/
--
-- Počítač: localhost:3306
-- Vytvořeno: Stř 15. dub 2026, 17:10
-- Verze serveru: 10.11.11-MariaDB-0+deb12u1
-- Verze PHP: 8.2.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databáze: `4b2_jandatomas_db2`
--

-- --------------------------------------------------------

--
-- Struktura tabulky `Articles`
--

CREATE TABLE `Articles` (
  `Id` int(11) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `Content` varchar(1000) NOT NULL,
  `Published` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `Articles`
--

INSERT INTO `Articles` (`Id`, `Title`, `Content`, `Published`) VALUES
(1, 'Nadp', 'tohle je telo clanku asd', 1),
(2, 'Titulek', 'telo', 1);

--
-- Indexy pro exportované tabulky
--

--
-- Indexy pro tabulku `Articles`
--
ALTER TABLE `Articles`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `Articles`
--
ALTER TABLE `Articles`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
