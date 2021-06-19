-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1:3307
-- Üretim Zamanı: 19 Haz 2021, 14:47:03
-- Sunucu sürümü: 10.4.10-MariaDB
-- PHP Sürümü: 7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `bitlancer`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `items`
--

DROP TABLE IF EXISTS `items`;
CREATE TABLE IF NOT EXISTS `items` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `item_name` varchar(250) COLLATE utf8_turkish_ci DEFAULT NULL,
  `balance` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `items`
--

INSERT INTO `items` (`id`, `item_name`, `balance`) VALUES
(2, 'Altın', 0),
(3, 'Gümüş', 0),
(4, 'TL', 1),
(5, 'Elmas', 0),
(6, 'Bitcoin', 0),
(7, 'Dolar', 1),
(8, 'Euro', 1),
(9, 'Sterlin', 1),
(10, 'İsviçre Frangı', 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `item_adds`
--

DROP TABLE IF EXISTS `item_adds`;
CREATE TABLE IF NOT EXISTS `item_adds` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `item_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `unit_price` double NOT NULL,
  `date` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `state` tinyint(1) NOT NULL,
  `description` text COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`),
  KEY `item_id` (`item_id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `item_adds`
--

INSERT INTO `item_adds` (`id`, `user_id`, `item_id`, `quantity`, `unit_price`, `date`, `state`, `description`) VALUES
(1, 4, 4, 150, 1, '2021-05-06', 1, 'TAMAMLANDI'),
(2, 3, 4, 1200, 1, '2021-05-07', 1, 'TAMAMLANDI.'),
(3, 5, 4, 3000, 1, '2021-15-2', 1, 'TAmamlandı'),
(4, 4, 4, 7, 1, '16.05.2021 15:33:50', 1, 'cghc'),
(5, 3, 4, 7000, 1, '16.05.2021 23:08:35', 1, ''),
(6, 4, 4, 10, 1, '16.05.2021 23:16:20', 1, ''),
(7, 4, 4, 15, 1, '16.05.2021 23:18:22', 1, ''),
(8, 3, 9, 36, 11.8891, '13.06.2021 02:18:07', 1, ''),
(9, 3, 10, 10, 9.3801, '13.06.2021 02:53:20', 1, ''),
(10, 3, 4, 100, 1, '13.06.2021 15:36:19', 1, ''),
(11, 3, 4, 100, 1, '13.06.2021 15:37:08', 1, ''),
(12, 3, 4, 100, 1, '13.06.2021 15:37:58', 1, ''),
(13, 3, 4, 100, 1, '13.06.2021 15:38:39', 1, ''),
(14, 3, 4, 100, 1, '13.06.2021 15:39:31', 1, ''),
(15, 3, 4, 100, 1, '13.06.2021 15:40:35', 1, ''),
(16, 4, 4, 1000, 1, '13.06.2021 15:41:24', 1, ''),
(17, 3, 7, 1000, 8.3649, '14.06.2021 22:02:49', 1, 'ONAYLANDI'),
(18, 3, 7, 15, 8.5499, '16.06.2021 23:12:54', 1, ''),
(19, 3, 7, 10, 8.5499, '16.06.2021 23:14:53', 1, ''),
(20, 3, 4, 100, 1, '16.06.2021 23:17:27', 1, ''),
(21, 4, 4, 1000, 1, '16.06.2021 23:18:22', 1, ''),
(22, 3, 7, 100, 8.5499, '17.06.2021 00:00:11', 1, ''),
(24, 4, 7, 1000, 8.6933, '19.06.2021 17:07:32', 1, '');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `item_orders`
--

DROP TABLE IF EXISTS `item_orders`;
CREATE TABLE IF NOT EXISTS `item_orders` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `destination_user_id` int(11) NOT NULL,
  `source_user_id` int(11) NOT NULL,
  `item_id` int(11) NOT NULL,
  `order_unit_price` double NOT NULL,
  `order_quantity` int(11) NOT NULL,
  `order_date` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `destination_user_id` (`destination_user_id`,`source_user_id`,`item_id`),
  KEY `source_user_id` (`source_user_id`),
  KEY `item_id` (`item_id`)
) ENGINE=InnoDB AUTO_INCREMENT=835 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `item_orders`
--

INSERT INTO `item_orders` (`id`, `destination_user_id`, `source_user_id`, `item_id`, `order_unit_price`, `order_quantity`, `order_date`) VALUES
(811, 3, 5, 2, 1, 930, '16.05.2021 22:41:10'),
(812, 3, 5, 2, 1, 110, '16.05.2021 22:47:38'),
(813, 3, 5, 2, 1, 110, '16.05.2021 22:52:43'),
(814, 3, 4, 2, 12.8, 90, '16.05.2021 22:54:01'),
(815, 3, 5, 2, 1, 1000, '16.05.2021 23:01:14'),
(816, 3, 4, 2, 700, 8, '19.05.2021 23:01:46'),
(817, 3, 4, 2, 700, 10, '16.05.2021 23:04:27'),
(818, 4, 3, 2, 600, 8, '16.05.2021 23:15:28'),
(819, 3, 4, 2, 700, 2, '17.05.2021 18:08:50'),
(820, 5, 4, 2, 600, 2, '14.06.2021 21:14:57'),
(821, 5, 4, 2, 600, 1, '14.06.2021 21:14:58'),
(822, 5, 4, 2, 600, 2, '14.06.2021 21:24:39'),
(823, 5, 4, 2, 600, 3, '14.06.2021 21:27:01'),
(824, 4, 3, 5, 10, 490, '14.06.2021 21:31:07'),
(825, 4, 3, 5, 10, 10, '14.06.2021 21:32:56'),
(826, 4, 3, 5, 10, 10, '14.06.2021 21:34:23'),
(827, 4, 3, 5, 10, 10, '14.06.2021 21:37:20'),
(828, 4, 3, 5, 10, 10, '14.06.2021 21:38:14'),
(829, 3, 4, 5, 3, 100, '16.06.2021 23:09:51'),
(830, 4, 3, 5, 5, 10, '18.06.2021 20:45:01'),
(831, 4, 3, 5, 5, 10, '18.06.2021 20:47:00'),
(832, 4, 3, 5, 5, 10, '18.06.2021 20:47:28'),
(834, 4, 3, 5, 5, 100, '19.06.2021 16:21:23');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `item_orders_wait`
--

DROP TABLE IF EXISTS `item_orders_wait`;
CREATE TABLE IF NOT EXISTS `item_orders_wait` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `item_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `unit_price` double NOT NULL,
  `date` varchar(250) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`),
  KEY `item_id` (`item_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `item_user_infos`
--

DROP TABLE IF EXISTS `item_user_infos`;
CREATE TABLE IF NOT EXISTS `item_user_infos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `item_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `unit_price` double NOT NULL,
  `selling` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`,`item_id`),
  KEY `item_id` (`item_id`)
) ENGINE=InnoDB AUTO_INCREMENT=649 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `item_user_infos`
--

INSERT INTO `item_user_infos` (`id`, `user_id`, `item_id`, `quantity`, `unit_price`, `selling`) VALUES
(3, 4, 2, 975, 600, 1),
(44, 4, 3, 6050, 12, 0),
(46, 5, 3, 1198, 12, 1),
(59, 4, 4, 12456, 1, 0),
(503, 3, 5, 300, 5, 1),
(626, 3, 5, 1146, 10, 0),
(635, 5, 4, 200, 1, 0),
(639, 3, 2, 1012, 1, 0),
(641, 4, 2, 8, 600, 0),
(642, 4, 5, 585, 1, 0),
(643, 4, 6, 15, 425000, 1),
(644, 3, 4, 15886, 1, 0),
(646, 5, 2, 5, 600, 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_full_name` varchar(250) COLLATE utf8_turkish_ci DEFAULT NULL,
  `user_name` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL,
  `user_password` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL,
  `user_address` varchar(1000) COLLATE utf8_turkish_ci DEFAULT NULL,
  `user_mail` varchar(250) COLLATE utf8_turkish_ci DEFAULT NULL,
  `user_tc` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `user_tel` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `user_type_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_type_id` (`user_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `users`
--

INSERT INTO `users` (`id`, `user_full_name`, `user_name`, `user_password`, `user_address`, `user_mail`, `user_tc`, `user_tel`, `user_type_id`) VALUES
(3, 'Muhammet Sezer Yıldırım', 'sezer_admin', 'asd', 'İZMİRsdfsdgfsdsdfsdf', 'asd@gmail.com', '65432156321', '(546) 213-3521', 5),
(4, 'Enes Koyuncu', 'asd', '123', 'İzmir', 'asdas@gmail.com', '532156321', '(545) 224-6932', 6),
(5, 'Simge', 'asd', 'asd', 'asd', 'asd', '213', '123', 6),
(6, 'Ali Eren Eriş', 'eren', '123', 'asdasdasd', 'asdasdasd', '123123', '(456) 421-2112', 6);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `user_type_infos`
--

DROP TABLE IF EXISTS `user_type_infos`;
CREATE TABLE IF NOT EXISTS `user_type_infos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_type` varchar(64) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `user_type_infos`
--

INSERT INTO `user_type_infos` (`id`, `user_type`) VALUES
(5, 'admin'),
(6, 'basic');

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `item_adds`
--
ALTER TABLE `item_adds`
  ADD CONSTRAINT `item_adds_ibfk_1` FOREIGN KEY (`item_id`) REFERENCES `items` (`id`),
  ADD CONSTRAINT `item_adds_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Tablo kısıtlamaları `item_orders`
--
ALTER TABLE `item_orders`
  ADD CONSTRAINT `item_orders_ibfk_1` FOREIGN KEY (`destination_user_id`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `item_orders_ibfk_2` FOREIGN KEY (`source_user_id`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `item_orders_ibfk_3` FOREIGN KEY (`item_id`) REFERENCES `items` (`id`);

--
-- Tablo kısıtlamaları `item_orders_wait`
--
ALTER TABLE `item_orders_wait`
  ADD CONSTRAINT `item_orders_wait_ibfk_1` FOREIGN KEY (`item_id`) REFERENCES `items` (`id`),
  ADD CONSTRAINT `item_orders_wait_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Tablo kısıtlamaları `item_user_infos`
--
ALTER TABLE `item_user_infos`
  ADD CONSTRAINT `item_user_infos_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `item_user_infos_ibfk_2` FOREIGN KEY (`item_id`) REFERENCES `items` (`id`);

--
-- Tablo kısıtlamaları `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`user_type_id`) REFERENCES `user_type_infos` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
