-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 27 May 2023, 11:06:05
-- Sunucu sürümü: 10.4.27-MariaDB
-- PHP Sürümü: 7.4.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `NetCoreBackend`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `operationclaims`
--

CREATE TABLE `operationclaims` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` varchar(255) NOT NULL,
  `Status` tinyint(1) NOT NULL DEFAULT 1,
  `CreatedDate` datetime(6) NOT NULL,
  `UpdatedDate` datetime(6) DEFAULT NULL,
  `DeletedDate` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `operationclaims`
--

INSERT INTO `operationclaims` (`Id`, `Name`, `Value`, `Status`, `CreatedDate`, `UpdatedDate`, `DeletedDate`) VALUES
(1, 'Admin', 'admin', 1, '0001-01-01 00:00:00.000000', NULL, NULL);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `products`
--

CREATE TABLE `products` (
  `Id` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `UnitPrice` decimal(65,30) NOT NULL,
  `UnitsInStock` smallint(6) NOT NULL,
  `Status` tinyint(1) NOT NULL DEFAULT 1,
  `CreatedDate` datetime(6) NOT NULL,
  `UpdatedDate` datetime(6) DEFAULT NULL,
  `DeletedDate` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `refreshtokens`
--

CREATE TABLE `refreshtokens` (
  `Id` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `Token` longtext NOT NULL,
  `Expires` datetime(6) NOT NULL,
  `CreatedByIp` longtext NOT NULL,
  `Revoked` datetime(6) DEFAULT NULL,
  `RevokedByIp` longtext DEFAULT NULL,
  `ReplacedByToken` longtext DEFAULT NULL,
  `ReasonRevoked` longtext DEFAULT NULL,
  `Status` tinyint(1) NOT NULL,
  `CreatedDate` datetime(6) NOT NULL,
  `UpdatedDate` datetime(6) DEFAULT NULL,
  `DeletedDate` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `useroperationclaims`
--

CREATE TABLE `useroperationclaims` (
  `Id` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `OperationClaimId` int(11) NOT NULL,
  `Status` tinyint(1) NOT NULL DEFAULT 1,
  `CreatedDate` datetime(6) NOT NULL,
  `UpdatedDate` datetime(6) DEFAULT NULL,
  `DeletedDate` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `useroperationclaims`
--

INSERT INTO `useroperationclaims` (`Id`, `UserId`, `OperationClaimId`, `Status`, `CreatedDate`, `UpdatedDate`, `DeletedDate`) VALUES
(1, 1, 1, 1, '0001-01-01 00:00:00.000000', NULL, NULL);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `FirstName` longtext NOT NULL,
  `LastName` longtext NOT NULL,
  `Email` varchar(255) NOT NULL,
  `PasswordHash` longblob NOT NULL,
  `PasswordSalt` longblob NOT NULL,
  `Status` tinyint(1) NOT NULL DEFAULT 1,
  `CreatedDate` datetime(6) NOT NULL,
  `UpdatedDate` datetime(6) DEFAULT NULL,
  `DeletedDate` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `users`
--

INSERT INTO `users` (`Id`, `FirstName`, `LastName`, `Email`, `PasswordHash`, `PasswordSalt`, `Status`, `CreatedDate`, `UpdatedDate`, `DeletedDate`) VALUES
(1, 'Furkan', 'Yazar', 'contact@furkanyazar.dev', 0x9564de0b3cadd1031e2a6f4e3a29dd4e3674aafc34a1e55450617b2c680d9771fdc36c700ad87bbd93540265353bfafedf128df278e95a66a12aa8265127c806, 0x1ed330b8c15943dede0e2ea0c8feec2869d037ddcb489bfc01951203dee4ec57924be595cc3632d3393acc4cb1f11505de6cc96c81a3e59c0a6485bd40abf52e44205fc989f9641e9f91bdc0663108bf9cc0cae28e5143ac9446539c292e15e3bd1dceca615e9b6bc4b6af168feb2d46c51ec19c5e4147636e641f51dd6370da, 1, '0001-01-01 00:00:00.000000', NULL, NULL);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20230524192720_Init', '6.0.13'),
('20230525203413_Add_Products', '6.0.13');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `operationclaims`
--
ALTER TABLE `operationclaims`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UK_OperationClaims_Name` (`Name`),
  ADD UNIQUE KEY `UK_OperationClaims_Value` (`Value`);

--
-- Tablo için indeksler `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UK_Products_UserId_Name` (`UserId`,`Name`);

--
-- Tablo için indeksler `refreshtokens`
--
ALTER TABLE `refreshtokens`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_RefreshTokens_UserId` (`UserId`);

--
-- Tablo için indeksler `useroperationclaims`
--
ALTER TABLE `useroperationclaims`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UK_UserOperationClaims_UserId_OperationClaimId` (`UserId`,`OperationClaimId`),
  ADD KEY `IX_UserOperationClaims_OperationClaimId` (`OperationClaimId`);

--
-- Tablo için indeksler `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UK_Users_Email` (`Email`);

--
-- Tablo için indeksler `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `operationclaims`
--
ALTER TABLE `operationclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `products`
--
ALTER TABLE `products`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `refreshtokens`
--
ALTER TABLE `refreshtokens`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `useroperationclaims`
--
ALTER TABLE `useroperationclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `FK_Products_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;

--
-- Tablo kısıtlamaları `refreshtokens`
--
ALTER TABLE `refreshtokens`
  ADD CONSTRAINT `FK_RefreshTokens_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;

--
-- Tablo kısıtlamaları `useroperationclaims`
--
ALTER TABLE `useroperationclaims`
  ADD CONSTRAINT `FK_UserOperationClaims_OperationClaims_OperationClaimId` FOREIGN KEY (`OperationClaimId`) REFERENCES `operationclaims` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_UserOperationClaims_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
