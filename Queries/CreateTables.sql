use [Sounty]

IF OBJECT_ID('RatingsTracks', 'U') IS NOT NULL
	DROP TABLE RatingsTracks;

IF OBJECT_ID('TracksGenres', 'U') IS NOT NULL
	DROP TABLE TracksGenres;

IF OBJECT_ID('PlaylistsGenresTracks', 'U') IS NOT NULL
	DROP TABLE PlaylistsGenresTracks;

IF OBJECT_ID('PlaylistsGenres', 'U') IS NOT NULL
	DROP TABLE PlaylistsGenres;

IF OBJECT_ID('PlaylistTracks', 'U') IS NOT NULL
	DROP TABLE PlaylistTracks;

IF OBJECT_ID('PlaylistsUsers', 'U') IS NOT NULL
	DROP TABLE PlaylistsUsers

IF OBJECT_ID('Playlist', 'U') IS NOT NULL
	DROP TABLE Playlist;

IF OBJECT_ID('TrackArtists', 'U') IS NOT NULL
	DROP TABLE TrackArtists;

If OBJECT_ID('AlbumArtists', 'U') IS NOT NULL
	DROP TABLE AlbumArtists

IF OBJECT_ID('Track', 'U') IS NOT NULL
	DROP TABLE Track;

IF OBJECT_ID('Album', 'U') IS NOT NULL
	DROP TABLE Album

IF OBJECT_ID('Concerts', 'U') IS NOT NULL
	DROP TABLE Concerts;

IF OBJECT_ID('Artist', 'U') IS NOT NULL
	DROP TABLE Artist;

IF OBJECT_ID('UserSounty', 'U') IS NOT NULL
	DROP TABLE UserSounty;

IF OBJECT_ID('Friends', 'U') IS NOT NULL
	DROP TABLE Friends;

IF OBJECT_ID('UserInfo', 'U') IS NOT NULL
	DROP TABLE UserInfo

IF OBJECT_ID('Subscription', 'U') IS NOT NULL
	DROP TABLE Subscription

IF OBJECT_ID('Payment', 'U') IS NOT NULL
	DROP TABLE Payment

IF OBJECT_ID('Images', 'U') IS NOT NULL
	DROP TABLE Images

IF OBJECT_ID('Genre', 'U') IS NOT NULL
	DROP TABLE Genre;

CREATE TABLE Images(
	imageId		int identity(1,1),
	imageName	nvarchar(150),
	imagePath	nvarchar(150),

	PRIMARY KEY (imageId)
)

CREATE TABLE Payment(
	cardId			int identity(1,1),
	cardNumber		nvarchar(16) not null,
	expirationYear	int not null,
	expirationMonth	int not null,
	cardHolder		nvarchar(50)

	PRIMARY KEY (cardId)
)

CREATE TABLE Subscription(
	subscriptionId	int identity(1,1),
	startDate		date not null,
	endDate			date,
	trialPeriod		bit,
	paymentId		int

	PRIMARY KEY (subscriptionId),
	FOREIGN KEY (paymentId) REFERENCES Payment(cardId)
)

CREATE TABLE UserInfo(
	userInfoId		int identity(1,1),
	profileImage	int,
	subscriptionId	int,
	firstName		nvarchar(25),
	lastName		nvarchar(25),
	userAddress		nvarchar(40),
	phoneNumber		nvarchar(12),
	facebookPage	nvarchar(50),
	instagramPage   nvarchar(50),
	youtubePage		nvarchar(50),
	birthDate		date,
	lastLogin		datetime,
	activeStatus	bit,

	PRIMARY KEY(userInfoId),
	CONSTRAINT FK_SubscriptionId FOREIGN KEY(subscriptionId) REFERENCES Subscription(subscriptionId),
	FOREIGN KEY (profileImage) REFERENCES Images(imageId)
)

CREATE TABLE Friends(
	uselessId	int identity(1,1),
	userId		int not null,
	friendId	int not null

	PRIMARY KEY (uselessId),
	FOREIGN KEY (userId) REFERENCES UserInfo(userInfoId),
	FOREIGN KEY (friendId) REFERENCES UserInfo(userInfoId)
)

CREATE TABLE UserSounty(
	userId		int,
	userName	nvarchar(25) not null,
	userPass	nvarchar(25) not null,

	PRIMARY KEY (userId),
	CONSTRAINT FK_UserInfo FOREIGN KEY (userId) REFERENCES UserInfo(userInfoId)
)

CREATE TABLE Artist (
	artistId		int identity(1,1),
	fullName		nvarchar(40),
	biography		nvarchar(2000),
	totalTracks		int,
	totalAlbums		int,
	imageId			int,
	facebookUrl		nvarchar(100),

	PRIMARY KEY (artistId),
	FOREIGN KEY (imageId) REFERENCES Images(imageId)
)

CREATE TABLE Concerts (
	concertId		int identity(1,1),
	artistId		int,
	dateConcert		date,
	locationConcert	nvarchar(80)

	PRIMARY KEY (concertId)
	FOREIGN KEY (artistId) REFERENCES  Artist(artistId)
)

CREATE TABLE Genre (
	genreId		int identity(1,1) not null,
	nameGenre	nvarchar(25)

	PRIMARY KEY (genreId)
)

CREATE TABLE Album (
	albumId			int identity(1,1),
	albumName		nvarchar(50),
	imageId			int,
	genreId			int not null,
	artistId		int not null,

	PRIMARY KEY (albumId),
	FOREIGN KEY (artistId)	REFERENCES Artist(artistId),
	FOREIGN KEY (genreId)	REFERENCES Genre(genreId),
	FOREIGN KEY (imageId)	REFERENCES Images(imageId)
)

CREATE TABLE Track (
	trackId			int identity(1,1),
	albumId			int,
	nameTrack		nvarchar(200),
	filepath		nvarchar(200),
	imageId			int

	PRIMARY KEY (trackId),
	FOREIGN KEY (albumId)	REFERENCES Album(albumId),
	FOREIGN KEY (imageId)	REFERENCES Images(imageId)
)

CREATE TABLE TrackArtists (
	uselessId		int identity(1,1) PRIMARY KEY,
	trackId			int not null,
	artistId		int not null,

	FOREIGN KEY (trackId) REFERENCES Track(trackId),
	FOREIGN KEY (artistId) REFERENCES Artist(artistId)
)

CREATE TABLE Playlist (
	playlistId		int identity(1,1),
	playlistName	nvarchar(50) not null,
	createdDate		date,
	updatedDate		date,
	userId			int not null,
	followers		int,
	imageId			int,
	descriptionText	nvarchar(100)

	PRIMARY KEY (playlistId),
	FOREIGN KEY (userId) REFERENCES UserInfo(userInfoId),
	FOREIGN KEY (imageId) REFERENCES Images(imageId)
)

CREATE TABLE PlaylistsUsers (
	uselessId		int identity(1,1) PRIMARY KEY,
	playlistId		int not null,
	userId			int not null,

	FOREIGN KEY (playlistId)	REFERENCES Playlist(playlistId),
	FOREIGN KEY (userId)		REFERENCES UserInfo(userInfoId)
)

CREATE TABLE PlaylistTracks (
	uselessId		int identity(1,1) PRIMARY KEY,
	playlistId		int,
	trackId			int,
	favoriteFlag	bit

	FOREIGN KEY (playlistId)	REFERENCES Playlist(playlistId),
	FOREIGN KEY (trackId)		REFERENCES Track(trackId)
)

CREATE TABLE PlaylistsGenres (
	playlistId		int identity(1,1),
	playlistName	nvarchar(50) not null,
	imageId			int,
	followers		int,

	PRIMARY KEY (playlistId),
	FOREIGN KEY (imageId) REFERENCES Images(imageId)
)

CREATE TABLE PlaylistsGenresTracks (
	uselessId		int identity(1,1) PRIMARY KEY,
	playlistId		int not null,
	trackId			int not null,

	FOREIGN KEY (playlistId)	REFERENCES PlaylistsGenres(playlistId),
	FOREIGN KEY (trackId)		REFERENCES Track(trackId)
)

CREATE TABLE TracksGenres(
	uselessId		int identity(1,1) PRIMARY KEY,
	trackId			int not null,
	genreId			int not null

	FOREIGN KEY (trackId)		REFERENCES Track(trackId),
	FOREIGN KEY (genreId)		REFERENCES Genre(genreId)
)

CREATE TABLE RatingsTracks (
	uselessId		int identity(1,1) PRIMARY KEY,
	userId			int not null,
	trackId			int not null,
	rating			int not null

	FOREIGN KEY (userId)		REFERENCES UserInfo(userInfoId),
	FOREIGN KEY (trackId)		REFERENCES Track(trackId)
)


/*********************************************** TRIGGERS ***************************************************/

/******* FILL THE PLAYLISTS GENRES TRACKS ******/
/*

IF OBJECT_ID('tr_FillPlaylistsGenresTracks', 'TR') IS NOT NULL
	DROP TRIGGER tr_FillPlaylistsGenresTracks
GO
	CREATE TRIGGER tr_FillPlaylistsGenresTracks
		ON TracksGenres
		AFTER INSERT
	AS
		BEGIN
			DECLARE @trackId int
			DECLARE @playlistId int
			DECLARE @genreId int
			DECLARE @genreName NVARCHAR(100)

			SET @trackId = (SELECT TOP(1) trackId from TracksGenres ORDER BY uselessId DESC )
			
			SET @genreId = (SELECT TOP(1) genreId from TracksGenres ORDER BY uselessId DESC )
			SET @genreName = (SELECT TOP(1) nameGenre FROM Genre WHERE @genreId = genreId)
			
			SET @playlistId = (SELECT playlistId FROM PlaylistsGenres WHERE playlistName = @genreName)

			SET IDENTITY_INSERT PlaylistsGenresTracks OFF

			INSERT INTO PlaylistsGenresTracks (playlistId, trackId)
			VALUES (@playlistId, @trackId)

		END
		*/
/* ************************ */

IF OBJECT_ID('tr_FindIdUserImage', 'TR') IS NOT NULL
	DROP TRIGGER tr_FindIdUserImage
GO
	CREATE TRIGGER tr_FindIdUserImage
		ON UserInfo
		AFTER INSERT, UPDATE
	AS
		BEGIN
			UPDATE UserInfo
			SET profileImage = (SELECT imageID FROM Images WHERE imageName = UserInfo.firstName + ' ' +UserInfo.lastName)
			WHERE profileImage IS NULL
		
		END
		

IF OBJECT_ID('tr_FindIdTrackImage', 'TR') IS NOT NULL
	DROP TRIGGER tr_FindIdTrackImage
GO
	CREATE TRIGGER tr_FindIdTrackImage
		ON Track
		AFTER INSERT, UPDATE
	AS
		BEGIN
			UPDATE Track
			SET nameTrack = substring(Track.filepath, 18, LEN(Track.filepath) - 21)
			WHERE nameTrack IS NULL

			UPDATE Track
			SET imageId = (SELECT imageID FROM Images WHERE imageName = nameTrack)
			WHERE imageId IS NULL;

			WITH CTE AS(
			SELECT t.trackId, t.albumId, t.nameTrack, t.filepath, t.imageId,
				   RN = ROW_NUMBER() OVER(PARTITION BY t.nameTrack ORDER BY t.nameTrack)
			   FROM Track as t
			)
			DELETE FROM CTE WHERE RN > 1
		END


IF OBJECT_ID('tr_FindIdArtistImage', 'TR') IS NOT NULL
	DROP TRIGGER tr_FindIdArtistImage
GO
	CREATE TRIGGER tr_FindIdArtistImage
		ON Artist
		AFTER INSERT, UPDATE
	AS
		BEGIN
			UPDATE Artist
			SET imageId = (SELECT imageID FROM Images WHERE imageName = fullName)
			WHERE imageId IS NULL
		
		END

/***** FILL THE GENRE PLAYLIST *****/

IF OBJECT_ID('tr_CreatePlaylists', 'TR') IS NOT NULL
	DROP TRIGGER tr_CreatePlaylists
GO
	CREATE TRIGGER tr_CreatePlaylists
		ON Genre
		AFTER INSERT
	AS
		BEGIN
			DECLARE @newName NVARCHAR(50)
			DECLARE @imageId int

			SET @newName = (SELECT TOP(1) nameGenre from Genre ORDER BY genreId DESC )
			SET @imageId = (SELECT TOP(1) imageId from Images WHERE imageName = @newName)

			SET IDENTITY_INSERT PlaylistsGenres OFF

			INSERT INTO PlaylistsGenres (playlistName, imageId)
			VALUES (@newName, @imageId)

		END





