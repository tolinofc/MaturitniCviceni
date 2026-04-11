-- phpMyAdmin SQL Dump
-- version 5.2.1deb1+deb12u1
-- https://www.phpmyadmin.net/
--
-- Počítač: localhost:3306
-- Vytvořeno: Sob 11. dub 2026, 10:02
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
-- Databáze: `4b2_jandatomas_db1`
--

-- --------------------------------------------------------

--
-- Struktura tabulky `city`
--

CREATE TABLE `city` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `description` varchar(1000) DEFAULT NULL,
  `image_path` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `city`
--

INSERT INTO `city` (`id`, `name`, `description`, `image_path`) VALUES
(1, 'Praha', 'Hlavní město České republiky', 'images\\Praha.jpg'),
(2, 'Brno', 'Druhé město České republiky', 'images\\Brno.jpg'),
(3, 'Ostrava', 'Další město České republiky', 'images\\Ostrava.jpg');

-- --------------------------------------------------------

--
-- Struktura tabulky `comment`
--

CREATE TABLE `comment` (
  `id` int(11) NOT NULL,
  `placeId` int(11) NOT NULL,
  `author` varchar(50) NOT NULL,
  `added_date` date NOT NULL,
  `comment` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `comment`
--

INSERT INTO `comment` (`id`, `placeId`, `author`, `added_date`, `comment`) VALUES
(1, 1, 'Tomas', '2026-03-31', 'Málo lidí'),
(2, 2, 'Netomas', '2026-03-29', 'Hodně lidí'),
(3, 1, 'Tomas', '2026-03-04', 'docela hezky'),
(5, 1, 'Tolin', '2026-03-31', 'docela hezky'),
(6, 2, 'Student', '2026-04-07', 'Komentar'),
(7, 2, 'Student', '2026-04-07', 'Komentar'),
(9, 2, 'Student', '2026-04-07', 'Komentar'),
(10, 2, 'StudentKomentar', '2026-04-07', NULL);

-- --------------------------------------------------------

--
-- Struktura tabulky `place`
--

CREATE TABLE `place` (
  `id` int(11) NOT NULL,
  `cityId` int(11) NOT NULL,
  `typeId` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` varchar(1000) DEFAULT NULL,
  `address` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `place`
--

INSERT INTO `place` (`id`, `cityId`, `typeId`, `name`, `description`, `address`) VALUES
(1, 1, 1, 'Staromák', 'Supr památka', 'Praha 1'),
(2, 2, 1, 'Restaurace u Orloje', 'Jídlo za 150Kč', 'Orloj v Brně, Brno 234'),
(3, 1, 1, 'KFC', 'fastfood', 'Vodičkova, Praha 1'),
(4, 1, 2, 'Nove misto', 'Popis noveho mista', 'Nove Misto, Praha 1'),
(6, 1, 1, 'Stare misto', 'Popisek noveho mista', 'Adresa mista');

-- --------------------------------------------------------

--
-- Struktura tabulky `rating`
--

CREATE TABLE `rating` (
  `id` int(11) NOT NULL,
  `placeId` int(11) NOT NULL,
  `rating` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `rating`
--

INSERT INTO `rating` (`id`, `placeId`, `rating`) VALUES
(3, 1, 4),
(4, 1, 2);

-- --------------------------------------------------------

--
-- Struktura tabulky `type`
--

CREATE TABLE `type` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `type`
--

INSERT INTO `type` (`id`, `name`) VALUES
(1, 'Restaurace'),
(2, 'Památka'),
(3, 'Zajímavost'),
(4, 'Ostatní');

--
-- Indexy pro exportované tabulky
--

--
-- Indexy pro tabulku `city`
--
ALTER TABLE `city`
  ADD PRIMARY KEY (`id`);

--
-- Indexy pro tabulku `comment`
--
ALTER TABLE `comment`
  ADD PRIMARY KEY (`id`),
  ADD KEY `commentId_place` (`placeId`);

--
-- Indexy pro tabulku `place`
--
ALTER TABLE `place`
  ADD PRIMARY KEY (`id`),
  ADD KEY `placeId_city` (`cityId`),
  ADD KEY `typeId_type` (`typeId`);

--
-- Indexy pro tabulku `rating`
--
ALTER TABLE `rating`
  ADD PRIMARY KEY (`id`),
  ADD KEY `rating_placeID` (`placeId`);

--
-- Indexy pro tabulku `type`
--
ALTER TABLE `type`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `city`
--
ALTER TABLE `city`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pro tabulku `comment`
--
ALTER TABLE `comment`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT pro tabulku `place`
--
ALTER TABLE `place`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT pro tabulku `rating`
--
ALTER TABLE `rating`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pro tabulku `type`
--
ALTER TABLE `type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Omezení pro exportované tabulky
--

--
-- Omezení pro tabulku `comment`
--
ALTER TABLE `comment`
  ADD CONSTRAINT `commentId_place` FOREIGN KEY (`placeId`) REFERENCES `place` (`id`);

--
-- Omezení pro tabulku `place`
--
ALTER TABLE `place`
  ADD CONSTRAINT `placeId_city` FOREIGN KEY (`cityId`) REFERENCES `city` (`id`),
  ADD CONSTRAINT `typeId_type` FOREIGN KEY (`typeId`) REFERENCES `type` (`id`);

--
-- Omezení pro tabulku `rating`
--
ALTER TABLE `rating`
  ADD CONSTRAINT `rating_placeID` FOREIGN KEY (`placeId`) REFERENCES `place` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
