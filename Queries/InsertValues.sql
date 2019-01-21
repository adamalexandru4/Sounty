use [Sounty]

/*
	Genre
*/

SET IDENTITY_INSERT Genre OFF

INSERT INTO Genre (nameGenre)
VALUES ('Classical');

INSERT INTO Genre (nameGenre)
VALUES ('Dance/Electronic')

INSERT INTO Genre (nameGenre)
VALUES ('Hip Hop')

INSERT INTO Genre (nameGenre)
VALUES ('Jazz')

INSERT INTO Genre (nameGenre)
VALUES ('Pop')
 
INSERT INTO Genre (nameGenre)
VALUES ('Rock')

INSERT INTO Genre (nameGenre)
VALUES ('Acoustic')

/*
	Payment
*/

SET IDENTITY_INSERT Payment OFF

INSERT INTO Payment (cardNumber, expirationYear, expirationMonth, cardHolder)
VALUES ('1234123412341234', '2020', '2', 'ADAM ALEXANDRU')

/*
	Subscription
*/

select * from UserInfo

SET IDENTITY_INSERT Subscription OFF
GO

INSERT INTO Subscription (startDate, endDate, trialPeriod, paymentId)
VALUES	('2019-01-07', '2019-08-07', 0, 1)

INSERT INTO Subscription (startDate, endDate, trialPeriod)
VALUES	('2019-02-04', '2019-03-04', 1)

/*
	User info
*/

SET IDENTITY_INSERT UserInfo ON
GO

INSERT INTO UserInfo (userInfoId, subscriptionId, firstName, lastName, userAddress, phoneNumber, birthDate)
VALUES (1, 1, 'Alexandru', 'Adam', 'Buzau', '0756278823', '1997-02-04')

INSERT INTO UserInfo (userInfoId, firstName, lastName, userAddress, phoneNumber, birthDate)
VALUES 	(2, 'Andrei', 'Stan', 'Motru', '0740197517', '1997-05-05'),
	(3, 'Mihai', 'Albina', 'Rm. Vilcea', '0732050043', '1997-06-15'),
	(4, 'Adelin', 'Petre', 'Bucuresti', '0789456732', '1997-02-12'),
	(5, 'Alexandru' , 'Chirita', 'Focsani', '0799456879', '1995-03-25'),
	(6, 'Claudiu', 'Purice', 'Targoviste', '0777889915', '1992-08-21'),
	(7, 'Octavian', 'Petre', 'Targoviste', '0752147897', '1994-10-10')

/*
	User Spotify
*/

INSERT INTO UserSounty (userId, userName, userPass)
VALUES (1, 'adam.alexandru', '1234'),
	(2, 'stan.andrei', '0000'),
	(3, 'albina.mihai', '1111'),
	(4, 'petre.adelin', '2222'),
	(5, 'alexandru.chirita', '3333'),
	(6, 'claudiu.purice', '4444'),
	(7, 'octavian.petre', '5555')

/*
	Friends
*/

SET IDENTITY_INSERT Friends OFF

INSERT INTO Friends (userId, friendId)
VALUES (1, 2), (1, 3), (1, 4), (2, 1), (2, 5), (2,7), (3,1), (3,2), (3, 4)

/* 
	Images
*/

SET IDENTITY_INSERT Images OFF

INSERT INTO Images (imageName, imagePath)
VALUES ('ZHU', 'D:\Sounty\Sounty\Resources\Artists\ZHU.jpg'),
		('Ringos Desert', 'D:\Sounty\Sounty\Resources\Albums\RINGOS DESERT.jpg'),
		('G4SHI - 24 Hours', 'D:\Sounty\Sounty\Resources\Songs\Track (1).jpg'),
		('GAULLIN - All The Things', 'D:\Sounty\Sounty\Resources\Songs\Track (2).jpg'),
		('Gaullin - LET ME SHOW YOU', 'D:\Sounty\Sounty\Resources\Songs\Track (3).jpg'),
		('Hotway & Diskover - Be Famous', 'D:\Sounty\Sounty\Resources\Songs\Track (4).jpg'),
		('Kaan Pars & Yusuf Alev - Heroine', 'D:\Sounty\Sounty\Resources\Songs\Track (5).jpg')

/*
	Artists
*/

SET IDENTITY_INSERT Artist OFF
GO

INSERT INTO Artist (fullName, biography, facebookUrl)
VALUES ('ZHU', 'In the beginning, he was known only as Zhu. The electronic dance producer born Stephen Zhu emerged in 2014 with "Moves Like Ms. Jackson," a dance track made up of a medley of OutKast songs. From there, Zhu defied the power of the information age by remaining anonymous, focusing attention solely on his music. As more tracks appeared on the internet, the hype building around his music increased. His debut EP, The Nightday, arrived in the spring of 2014. Included on the EP, his hit single "Faded" was nominated for a Grammy, a first for an anonymous artist. The following year, Zhu recruited an impressive roster of guests for the Genesis Series EP, which featured collaborations with Skrillex, Daniel Johns, Trombone Shorty, Bone Thugs-N-Harmony, A-Trak, Keznamdi, Vancouver Sleep Clinic, AlunaGeorge, and labelmates Gallant and THEY. After embarking on his first headlining tour, which included a spot at Coachella, Zhu released the single "In the Morning" in 2016. "Generationwhy" -- the lead single off his debut album of the same name -- arrived in June 2016. The following year, Zhu surprise-released the four-track EP stardustexhalemarrakechdreams. In 2018, he issued the singles "Blame" with Ekali and "My Life" with Tame Impala. That spring, he released the EP Ringos Desert, Pt. 1, featuring JOY. on "Stormy Love, NM." and Karnaval Blues on "Still Want U." A full-length expansion followed that September. Ringos Desert added guests such as Tame Impala, Tokimonsta, and Majid Jordan to the blissed-out house party.', 
			   'http://facebook.com/ZHU')

/*
	Concerts
*/

SET IDENTITY_INSERT Concerts OFF
GO

INSERT INTO Concerts (artistId, dateConcert, locationConcert)
VALUES (1, '2019-01-15', 'Holy Ship, Miami'),
	   (1, '2019-03-16', 'Espacio IDESA, Asuncion'),
	   (1, '2019-03-25', 'Parque O''Higgins, Santiago')

/*
	Playlists
*/

SET IDENTITY_INSERT Playlist OFF
GO

INSERT INTO Playlist (playlistName, createdDate, updatedDate, userId)
VALUES ('Car ride', GETDATE(), GETDATE(), 1),
	('Rock', GETDATE(), GETDATE(), 2)

/* 
	Tracks
*/

SET IDENTITY_INSERT Track OFF

INSERT INTO Track (filepath)
VALUES ('D:\GitLab Tracks\G4SHI - 24 Hours.mp3'),
	('D:\GitLab Tracks\GAULLIN - All The Things.mp3'),
	('D:\GitLab Tracks\Gaullin - LET ME SHOW YOU.mp3'),
	('D:\GitLab Tracks\Hotway & Diskover - Be Famous.mp3'),
	('D:\GitLab Tracks\Kaan Pars & Yusuf Alev - Heroine.mp3')

/*
	Tracks genres
*/

SET IDENTITY_INSERT TracksGenres OFF

INSERT INTO TracksGenres(trackId, genreId)
VALUES (1, 2)

 INSERT INTO TracksGenres(trackId, genreId)
VALUES (2, 2), (3, 2), (4, 2), (5, 2)

/*
	Albums
*/

SET IDENTITY_INSERT Album OFF

INSERT INTO Album (albumName, genreId, artistId)
VALUES ('Ringos Desert', 3, 1)

/*
	Tracks of playlists
*/

SET IDENTITY_INSERT PlaylistTracks OFF

INSERT INTO PlaylistTracks (playlistId, trackId)
VALUES (1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (2, 1)
