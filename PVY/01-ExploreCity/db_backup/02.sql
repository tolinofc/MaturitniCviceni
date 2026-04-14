-- phpMyAdmin SQL Dump
-- version 5.2.1deb1+deb12u1
-- https://www.phpmyadmin.net/
--
-- Počítač: localhost:3306
-- Vytvořeno: Úte 14. dub 2026, 17:26
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
(1, 'Praha', 'Hlavní město České republiky', 'images/Praha.jpg'),
(2, 'Brno', 'Druhé město České republiky', 'images/Brno.jpg'),
(3, 'Ostrava', 'Další město České republiky', 'images/Ostrava.jpg');

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
(11, 1, 'test', '2026-04-11', 'asdasdas'),
(16, 6, 'Tomas', '2026-04-12', 'komentar'),
(17, 1, 'Novz', '2026-04-12', 'Novy komentar'),
(18, 9, 'Josef', '2026-04-12', 'fakt dobry jidlo'),
(19, 9, 'Jitka', '2026-04-12', 'nic moc jidlo'),
(20, 1, 'Milan', '2026-04-13', 'asd');

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
  `address` varchar(100) NOT NULL,
  `image_path` varchar(400) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `place`
--

INSERT INTO `place` (`id`, `cityId`, `typeId`, `name`, `description`, `address`, `image_path`) VALUES
(1, 1, 1, 'Staromák', 'namesti', 'Praha 1', 'https://d39-a.sdn.cz/d_39/c_img_p8_A/kBfrbpoeNBFLmuDnJFpuMs3/e3ef/demonstrace.jpeg?fl=cro,0,0,4096,2731%7Cres,1200,,1%7Cjpg,80,,1'),
(3, 1, 1, 'KFC', 'fastfood', 'Vodičkova, Praha 1', 'https://i.ytimg.com/vi/G_5iukY7c9g/maxresdefault.jpg'),
(6, 1, 2, 'The Bridge', 'Popisek noveho mista', 'Adresa mista', 'https://upload.wikimedia.org/wikipedia/commons/3/33/Golden_gate2-2.jpg'),
(8, 2, 1, 'ANova restaurace v Brne', 'Novinka', 'Centrum ig', 'https://www.restaurant-guide.cz/wp-content/uploads/pasta-fresca-ambiente.webp'),
(9, 1, 3, 'McDonalds', 'fastfood', 'u dalnice idk', 'https://d15-a.sdn.cz/d_15/c_img_oV_A/kObgaqJNMnzSiAY5CNKJoe/026a/mcdonald-s-restaurace-pobocky-otevreni.jpeg?fl=cro,0,0,1280,720%7Cres,1200,,1%7Cjpg,80,,1'),
(10, 3, 3, 'Ostravska zajimavost', 'popisek', 'ostrava', 'https://www.visitostrava.eu/images_firmy/476_14-baner-visit-1-m-jpg.jpeg'),
(11, 3, 4, 'tramvaj', 'tram', 'koleje', 'https://www.theseforeignroads.com/wp-content/uploads/2023/02/What-to-Do-in-Ostrava-Czech-Republic.webp'),
(12, 2, 4, 'Brno na mape', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus ornare in tortor at viverra. Phasellus eleifend erat vestibulum, maximus felis eu, maximus velit. Duis imperdiet condimentum enim, quis volutpat velit egestas vitae. Nulla rhoncus metus id turpis dignissim, vel accumsan ex feugiat. Vestibulum risus mauris, cursus at viverra et, tempor eget risus. Maecenas sed facilisis lectus. Cras pulvinar est sed ante iaculis sagittis. ', 'Vychod CR', 'https://upload.wikimedia.org/wikipedia/commons/d/dd/Okres_brno-mesto.png');

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
(4, 1, 2),
(5, 6, 5),
(6, 6, 5),
(7, 6, 5),
(8, 6, 4),
(9, 6, 1),
(10, 6, 2),
(52, 6, 1),
(53, 6, 5);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pro tabulku `comment`
--
ALTER TABLE `comment`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT pro tabulku `place`
--
ALTER TABLE `place`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT pro tabulku `rating`
--
ALTER TABLE `rating`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=97;

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
