-- phpMyAdmin SQL Dump
-- version 5.2.1deb1+deb12u1
-- https://www.phpmyadmin.net/
--
-- Počítač: localhost:3306
-- Vytvořeno: Ned 19. dub 2026, 16:31
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
(1, 'Produkt 1', 4, 0),
(2, 'Produkt 2', 0, 1),
(3, 'Produkt 3', 1, 1),
(4, 'Produkt 4', 5, 0),
(5, 'Produkt 5', 6, 0),
(6, 'Produkt 6', 7, 0),
(7, 'Produkt 7', 3, 1),
(8, 'Produkt 8', 2, 1);

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
