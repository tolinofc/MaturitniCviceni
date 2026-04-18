-- phpMyAdmin SQL Dump
-- version 5.2.1deb1+deb12u1
-- https://www.phpmyadmin.net/
--
-- Počítač: localhost:3306
-- Vytvořeno: Sob 18. dub 2026, 13:34
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
  `Id` int(11) NOT NULL,
  `LineId` int(11) NOT NULL,
  `DepartureTime` timestamp NOT NULL,
  `DayType` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `Departure`
--

INSERT INTO `Departure` (`Id`, `LineId`, `DepartureTime`, `DayType`) VALUES
(1, 1, '2026-04-16 04:35:00', 1),
(2, 1, '2026-04-16 04:55:00', 1),
(4, 2, '2026-04-16 12:00:00', 1),
(5, 4, '2026-04-18 13:00:00', 1);

-- --------------------------------------------------------

--
-- Struktura tabulky `Line`
--

CREATE TABLE `Line` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Direction` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `Line`
--

INSERT INTO `Line` (`Id`, `Name`, `Direction`) VALUES
(1, '349', 'Praha, Ládví'),
(2, '467', 'Roudnice n. Labem'),
(3, '369', 'Praha, Ládví'),
(4, 'test', 'Třebenická');

-- --------------------------------------------------------

--
-- Struktura tabulky `LineStop`
--

CREATE TABLE `LineStop` (
  `Id` int(11) NOT NULL,
  `LineId` int(11) NOT NULL,
  `StopId` int(11) NOT NULL,
  `StopOrder` int(11) NOT NULL,
  `TimeFromPrevious` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `LineStop`
--

INSERT INTO `LineStop` (`Id`, `LineId`, `StopId`, `StopOrder`, `TimeFromPrevious`) VALUES
(1, 1, 1, 1, 0),
(2, 1, 2, 2, 3),
(3, 1, 3, 3, 2),
(4, 1, 4, 4, 10),
(5, 1, 5, 5, 18),
(6, 1, 6, 6, 2),
(7, 2, 1, 1, 0),
(9, 4, 1, 1, 0),
(10, 4, 6, 2, 5);

-- --------------------------------------------------------

--
-- Struktura tabulky `Stop`
--

CREATE TABLE `Stop` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `Stop`
--

INSERT INTO `Stop` (`Id`, `Name`) VALUES
(1, 'Mělník aut. nádr.'),
(2, 'Mělník, U Hřiště'),
(3, 'Mělník, Cukrovar'),
(4, 'Neratovice, Byškovice'),
(5, 'Třebenická'),
(6, 'Ládví'),
(8, 'Citov, Roudnicka'),
(9, 'Citov'),
(10, 'Citov, Melnicka'),
(11, 'Melnik, Podoli'),
(12, 'Melnik, Pivovar');

--
-- Indexy pro exportované tabulky
--

--
-- Indexy pro tabulku `Departure`
--
ALTER TABLE `Departure`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `LineDep` (`LineId`);

--
-- Indexy pro tabulku `Line`
--
ALTER TABLE `Line`
  ADD PRIMARY KEY (`Id`);

--
-- Indexy pro tabulku `LineStop`
--
ALTER TABLE `LineStop`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Line` (`LineId`),
  ADD KEY `Stop` (`StopId`);

--
-- Indexy pro tabulku `Stop`
--
ALTER TABLE `Stop`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `Departure`
--
ALTER TABLE `Departure`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT pro tabulku `Line`
--
ALTER TABLE `Line`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pro tabulku `LineStop`
--
ALTER TABLE `LineStop`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT pro tabulku `Stop`
--
ALTER TABLE `Stop`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Omezení pro exportované tabulky
--

--
-- Omezení pro tabulku `Departure`
--
ALTER TABLE `Departure`
  ADD CONSTRAINT `LineDep` FOREIGN KEY (`LineId`) REFERENCES `Line` (`Id`);

--
-- Omezení pro tabulku `LineStop`
--
ALTER TABLE `LineStop`
  ADD CONSTRAINT `Line` FOREIGN KEY (`LineId`) REFERENCES `Line` (`Id`),
  ADD CONSTRAINT `Stop` FOREIGN KEY (`StopId`) REFERENCES `Stop` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
