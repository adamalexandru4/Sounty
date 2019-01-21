USE [master]

IF DB_ID('Sounty') IS NOT NULL DROP DATABASE Sounty

CREATE DATABASE Sounty
	ON PRIMARY(
		Name = SountyData,
		FileName = 'D:\SountyDB\SountyData.mdf',
		Size = 25 MB,
		maxsize = unlimited,
		filegrowth = 1GB
	)
	LOG ON
	(
		Name = SountyLog,
		FileName = 'D:\SountyDB\SountyLog.ldf',
		size = 30 MB,
		maxsize = unlimited,
		filegrowth = 1GB
	)


	
