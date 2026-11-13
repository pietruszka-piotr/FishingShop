IF DB_ID(N'FishingShop') IS NULL
    EXEC (N'CREATE DATABASE [FishingShop];');
GO

USE [FishingShop];
GO

SELECT DB_NAME() AS DatabaseName;
GO
