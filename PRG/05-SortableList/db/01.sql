-- phpMyAdmin SQL Dump
-- version 5.2.1deb1+deb12u1
-- https://www.phpmyadmin.net/
--
-- Počítač: localhost:3306
-- Vytvořeno: Sob 18. dub 2026, 18:37
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
-- Struktura tabulky `Products`
--

CREATE TABLE `Products` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `ProductOrder` int(11) NOT NULL,
  `Selected` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `Products`
--

INSERT INTO `Products` (`Id`, `Name`, `ProductOrder`, `Selected`) VALUES
(1, 'Zkouska1', 2, 1),
(2, 'Zkouska2', 5, 0),
(3, 'Zkouska3', 4, 0),
(4, 'Zkouska4', 1, 1),
(5, 'Zkouska5', 6, 0),
(6, 'Zkouska6', 7, 0),
(7, 'Zkouska7', 3, 1),
(8, 'Zkouska8', 0, 1);

--
-- Indexy pro exportované tabulky
--

--
-- Indexy pro tabulku `Products`
--
ALTER TABLE `Products`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `Products`
--
ALTER TABLE `Products`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
