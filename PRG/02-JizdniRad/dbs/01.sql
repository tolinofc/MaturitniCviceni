-- phpMyAdmin SQL Dump
-- version 5.2.1deb1+deb12u1
-- https://www.phpmyadmin.net/
--
-- Počítač: localhost:3306
-- Vytvořeno: Stř 15. dub 2026, 17:41
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
-- Struktura tabulky `Departure`
--

CREATE TABLE `Departure` (
  `id` int(11) NOT NULL,
  `lineId` int(11) NOT NULL,
  `departureTime` time NOT NULL,
  `dayType` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `Departure`
--

INSERT INTO `Departure` (`id`, `lineId`, `departureTime`, `dayType`) VALUES
(1, 1, '06:35:00', 1);

-- --------------------------------------------------------

--
-- Struktura tabulky `Line`
--

CREATE TABLE `Line` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `direction` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `Line`
--

INSERT INTO `Line` (`id`, `name`, `direction`) VALUES
(1, '349', 'Praha, Ládví'),
(2, '467', 'Roudnice n. Labem');

-- --------------------------------------------------------

--
-- Struktura tabulky `LineStop`
--

CREATE TABLE `LineStop` (
  `id` int(11) NOT NULL,
  `lineId` int(11) NOT NULL,
  `stopId` int(11) NOT NULL,
  `stopOrder` int(11) NOT NULL,
  `timeFromPrevious` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `LineStop`
--

INSERT INTO `LineStop` (`id`, `lineId`, `stopId`, `stopOrder`, `timeFromPrevious`) VALUES
(1, 1, 1, 1, 0),
(2, 1, 2, 2, 2),
(3, 1, 3, 3, 1),
(4, 1, 4, 4, 10),
(5, 1, 5, 5, 18),
(6, 1, 6, 6, 2);

-- --------------------------------------------------------

--
-- Struktura tabulky `Stop`
--

CREATE TABLE `Stop` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `Stop`
--

INSERT INTO `Stop` (`id`, `name`) VALUES
(1, 'Mělník aut. nádr.'),
(2, 'Mělník, U Hřiště'),
(3, 'Mělník, Cukrovar'),
(4, 'Neratovice, Byškovice'),
(5, 'Třebenická'),
(6, 'Ládví');

--
-- Indexy pro exportované tabulky
--

--
-- Indexy pro tabulku `Departure`
--
ALTER TABLE `Departure`
  ADD PRIMARY KEY (`id`),
  ADD KEY `LineDep` (`lineId`);

--
-- Indexy pro tabulku `Line`
--
ALTER TABLE `Line`
  ADD PRIMARY KEY (`id`);

--
-- Indexy pro tabulku `LineStop`
--
ALTER TABLE `LineStop`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Line` (`lineId`),
  ADD KEY `Stop` (`stopId`);

--
-- Indexy pro tabulku `Stop`
--
ALTER TABLE `Stop`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `Departure`
--
ALTER TABLE `Departure`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pro tabulku `Line`
--
ALTER TABLE `Line`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pro tabulku `LineStop`
--
ALTER TABLE `LineStop`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT pro tabulku `Stop`
--
ALTER TABLE `Stop`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Omezení pro exportované tabulky
--

--
-- Omezení pro tabulku `Departure`
--
ALTER TABLE `Departure`
  ADD CONSTRAINT `LineDep` FOREIGN KEY (`lineId`) REFERENCES `Line` (`id`);

--
-- Omezení pro tabulku `LineStop`
--
ALTER TABLE `LineStop`
  ADD CONSTRAINT `Line` FOREIGN KEY (`lineId`) REFERENCES `Line` (`id`),
  ADD CONSTRAINT `Stop` FOREIGN KEY (`stopId`) REFERENCES `Stop` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
