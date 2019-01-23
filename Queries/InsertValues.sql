use [Sounty]

/*
	Payment
*/

SET IDENTITY_INSERT Payment OFF

INSERT INTO Payment (cardNumber, expirationYear, expirationMonth, cardHolder)
VALUES ('1234123412341234', '2020', '2', 'ADAM ALEXANDRU')

/*
	Subscription
*/
SET IDENTITY_INSERT Subscription OFF
GO

INSERT INTO Subscription (startDate, endDate, trialPeriod, paymentId)
VALUES	('2019-01-07', '2019-08-07', 0, 1)

INSERT INTO Subscription (startDate, endDate, trialPeriod)
VALUES	('2019-02-04', '2019-03-04', 1)

/* 
	Images
*/

SET IDENTITY_INSERT Images OFF

INSERT INTO Images (imageName, imagePath)
VALUES ('Ringos Desert', 'D:\Sounty\Sounty\Resources\Albums\Ringos Desert.jpg'),
	('Bad Land', 'D:\Sounty\Sounty\Resources\Albums\Bad Land.jpg'),
	('Gheorghe Zamfir Album', 'D:\Sounty\Sounty\Resources\Albums\Gheorghe Zamfir Album.jpg'),
	('Jacob Lee Album', 'D:\Sounty\Sounty\Resources\Albums\Jacob Lee Album.jpg'),
	('Master Of Puppets', 'D:\Sounty\Sounty\Resources\Albums\Master Of Puppets.jpg'),
	('Piano Sonatas', 'D:\Sounty\Sounty\Resources\Albums\Piano Sonatas.jpg'),
	('Revelation', 'D:\Sounty\Sounty\Resources\Albums\Revelation.jpg'),
	('Xcape', 'D:\Sounty\Sounty\Resources\Albums\Xcape.jpg'),
	('Calvin Harris Album', 'D:\Sounty\Sounty\Resources\Albums\Calvin Harris Album.jpg'),
	('Frank Sinatra Album', 'D:\Sounty\Sounty\Resources\Albums\Frank Sinatra Album.jpg'),
	('Miguel Album', 'D:\Sounty\Sounty\Resources\Albums\Miguel Album.jpg')

INSERT INTO Images (imageName, imagePath)
VALUES ('Beethoven', 'D:\Sounty\Sounty\Resources\Artists\Beethoven.jpg'),
		('Eminem', 'D:\Sounty\Sounty\Resources\Artists\Eminem.jpg'),
		('Frank Sinatra', 'D:\Sounty\Sounty\Resources\Artists\Frank Sinatra.jpg'),
		('Gheorghe Zamfir', 'D:\Sounty\Sounty\Resources\Artists\Gheorghe Zamfir.jpg'),
		('Halsey', 'D:\Sounty\Sounty\Resources\Artists\Halsey.jpg'),
		('Jacob Lee', 'D:\Sounty\Sounty\Resources\Artists\Jacob Lee.jpg'),
		('Metallica', 'D:\Sounty\Sounty\Resources\Artists\Metallica.jpg'),
		('Michael Jackson', 'D:\Sounty\Sounty\Resources\Artists\Michael Jackson.jpg'),
		('Miguel', 'D:\Sounty\Sounty\Resources\Artists\Miguel.jpg'),
		('ZHU', 'D:\Sounty\Sounty\Resources\Artists\ZHU.jpg')

INSERT INTO Images (imageName, imagePath)
VALUES ('Classical', 'D:\Sounty\Sounty\Resources\Genres\Classical.jpg'),
		('Dance/Electronic', 'D:\Sounty\Sounty\Resources\Genres\House.jpg'),
		('Hip Hop', 'D:\Sounty\Sounty\Resources\Genres\Hip Hop.jpg'),
		('Jazz', 'D:\Sounty\Sounty\Resources\Genres\Jazz.jpg'),
		('Pop', 'D:\Sounty\Sounty\Resources\Genres\Pop.jpg'),
		('Rock', 'D:\Sounty\Sounty\Resources\Genres\Rock.jpg'),
		('Acoustic', 'D:\Sounty\Sounty\Resources\Genres\Acoustic.jpg')

INSERT INTO Images (imageName, imagePath)
VALUES 	('G4SHI - 24 Hours', 'D:\Sounty\Sounty\Resources\Songs\Track (1).jpg'),
		('GAULLIN - All The Things', 'D:\Sounty\Sounty\Resources\Songs\Track (2).jpg'),
		('Gaullin - LET ME SHOW YOU', 'D:\Sounty\Sounty\Resources\Songs\Track (3).jpg'),
		('Hotway & Diskover - Be Famous', 'D:\Sounty\Sounty\Resources\Songs\Track (4).jpg'),
		('6ix9ine, Nicki Minaj, Murda Beatz - FEFE', 'D:\Sounty\Sounty\Resources\Songs\Track (5).jpg'),
		('Adele - Hello (Cover)', 'D:\Sounty\Sounty\Resources\Songs\Track (6).jpg'),
		('Anto - What I Feel', 'D:\Sounty\Sounty\Resources\Songs\Track (7).jpg'),
		('Artenvielfalt Presents Paulina Adler - Stop Breathing', 'D:\Sounty\Sounty\Resources\Songs\Track (8).jpg'),
		('Bad Bunny feat. Drake - Mia', 'D:\Sounty\Sounty\Resources\Songs\Track (9).jpg'),
		('Bang La Decks - Utopia', 'D:\Sounty\Sounty\Resources\Songs\Track (10).jpg'),
		('Bebe Rexha - Knees', 'D:\Sounty\Sounty\Resources\Songs\Track (11).jpg'),
		('Ben Pearce - What I Might Do', 'D:\Sounty\Sounty\Resources\Songs\Track (12).jpg'),
		('Blackbear - runnin low', 'D:\Sounty\Sounty\Resources\Songs\Track (13).jpg'),
		('Blvmenkind - Dream With You', 'D:\Sounty\Sounty\Resources\Songs\Track (14).jpg'),
		('BURNS - Hands On Me (Blond Remix)', 'D:\Sounty\Sounty\Resources\Songs\Track (15).jpg'),
		('Calvin Harris & Dua Lipa - One Kiss (R3HAB Remix)', 'D:\Sounty\Sounty\Resources\Songs\Track (16).jpg'),
		('Calvin Harris - How Deep Is Your Love', 'D:\Sounty\Sounty\Resources\Songs\Track (17).jpg'),
		('Cardi B, Bad Bunny & J Balvin - I Like It (Dillon Francis Remix)', 'D:\Sounty\Sounty\Resources\Songs\Track (18).jpg'),
		('CID - Bad For Me', 'D:\Sounty\Sounty\Resources\Songs\Track (19).jpg'),
		('Danny Avila & The Vamps - Too Good To Be True', 'D:\Sounty\Sounty\Resources\Songs\Track (20).jpg'),
		('David Guetta & Sia - Flames (Pink Panda Remix)', 'D:\Sounty\Sounty\Resources\Songs\Track (21).jpg'),
		('Deadly Zoo & Donna Lugassy - Wine It Up', 'D:\Sounty\Sounty\Resources\Songs\Track (22).jpg'),
		('Dean Lewis - Be Alright', 'D:\Sounty\Sounty\Resources\Songs\Track (23).jpg'),
		('DHARIA - Sugar & Brownies', 'D:\Sounty\Sounty\Resources\Songs\Track (24).jpg'),
		('DJ Snake - Taki Taki', 'D:\Sounty\Sounty\Resources\Songs\Track (25).jpg'),
		('Dua Lipa & BLACKPINK - Kiss and Make Up', 'D:\Sounty\Sounty\Resources\Songs\Track (26).jpg'),
		('Dynoro - Hangover', 'D:\Sounty\Sounty\Resources\Songs\Track (27).jpg'),
		('El Profesor - Bella Ciao (HUGEL Remix)', 'D:\Sounty\Sounty\Resources\Songs\Track (28).jpg'),
		('Fisher - Losing It', 'D:\Sounty\Sounty\Resources\Songs\Track (29).jpg'),
		('French Montana - No Stylist ft. Drake', 'D:\Sounty\Sounty\Resources\Songs\Track (30).jpg'),
		('Future - Low Life', 'D:\Sounty\Sounty\Resources\Songs\Track (31).jpg'),
		('G-Eazy - No Limit (Remix)', 'D:\Sounty\Sounty\Resources\Songs\Track (32).jpg'),
		('Guz - Prefer (Vik Leifa Remix)', 'D:\Sounty\Sounty\Resources\Songs\Track (33).jpg'),
		('Halsey & Khalid - Eastside', 'D:\Sounty\Sounty\Resources\Songs\Track (34).jpg'),
		('Halsey - Sorry', 'D:\Sounty\Sounty\Resources\Songs\Track (35).jpg'),
		('Infinity Ink - Infinity (Dubdogz & Bhaskar Remix)', 'D:\Sounty\Sounty\Resources\Songs\Track (37).jpg'),
		('Jacob Lee - I Belong to You', 'D:\Sounty\Sounty\Resources\Songs\Track (38).jpg'),
		('Jacob Lee - With You', 'D:\Sounty\Sounty\Resources\Songs\Track (39).jpg'),
		('Jarryd James - Do You Remember', 'D:\Sounty\Sounty\Resources\Songs\Track (40).jpg'),
		('Just Kiddin - Body Talk', 'D:\Sounty\Sounty\Resources\Songs\Track (41).jpg'),
		('Justin Bieber - The Feeling', 'D:\Sounty\Sounty\Resources\Songs\Track (42).jpg'),
		('Kanye West & Lil Pump ft. Adele Givens - I Love It', 'D:\Sounty\Sounty\Resources\Songs\Track (43).jpg'),
		('Khalid - Stay', 'D:\Sounty\Sounty\Resources\Songs\Track (44).jpg'),
		('Khalid - Suncity', 'D:\Sounty\Sounty\Resources\Songs\Track (45).jpg'),
		('Kiiara - L___ Is A Bad Word', 'D:\Sounty\Sounty\Resources\Songs\Track (46).jpg'),
		('LSD - Genius (Banx & Ranx Remix)', 'D:\Sounty\Sounty\Resources\Songs\Track (47).jpg'),
		('Lucas & Steve x Brandy - I Could Be Wrong', 'D:\Sounty\Sounty\Resources\Songs\Track (48).jpg'),
		('Lucky Luke Remake - In my feelings', 'D:\Sounty\Sounty\Resources\Songs\Track (49).jpg'),
		('Lund- Broken', 'D:\Sounty\Sounty\Resources\Songs\Track (50).jpg'),
		('Mansionair - Easier', 'D:\Sounty\Sounty\Resources\Songs\Track (51).jpg'),
		('Marshmello & Anne-Marie - Friends (Borgeous Remix)', 'D:\Sounty\Sounty\Resources\Songs\Track (52).jpg'),
		('Martin Garrix feat. Khalid - Ocean (Silque Remix)', 'D:\Sounty\Sounty\Resources\Songs\Track (53).jpg'),
		('ZHU - Faded', 'D:\Sounty\Sounty\Resources\Songs\Track (54).jpg'),
		('ZHU - Save Me', 'D:\Sounty\Sounty\Resources\Songs\Track (55).jpg'),
		('ZHU - Love That Hurts (feat. Karnaval Blues & Indiana)', 'D:\Sounty\Sounty\Resources\Songs\Track (56).jpg'),
		('ZHU - Drowning', 'D:\Sounty\Sounty\Resources\Songs\Track (57).jpg'),
		('ZHU - Desert Woman', 'D:\Sounty\Sounty\Resources\Songs\Track (58).jpg'),
		('ZHU - Coming Home (feat. Majid Jordan)', 'D:\Sounty\Sounty\Resources\Songs\Track (59).jpg'),
		('ZHU - Burn Babylon Ft. Keznamdi & Daniel Wilson', 'D:\Sounty\Sounty\Resources\Songs\Track (60).jpg')

INSERT INTO Images (imageName, imagePath)
VALUES ('Alexandru Adam', 'D:\Sounty\Sounty\Resources\Profile\Alexandru Adam.jpg'),
		('Andrei Stan', 'D:\Sounty\Sounty\Resources\Profile\Andrei Stan.jpg'),
		('Mihai Albina', 'D:\Sounty\Sounty\Resources\Profile\Mihai Albina.jpg'),
		('Adelin Petre', 'D:\Sounty\Sounty\Resources\Profile\Adelin Petre.jpg'),
		('Alexandru Chirita', 'D:\Sounty\Sounty\Resources\Profile\Alexandru Chirita.jpg'),
		('Octavian Petre', 'D:\Sounty\Sounty\Resources\Profile\Octavian Petre.jpg')

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
	Artists
*/

SET IDENTITY_INSERT Artist OFF
GO

INSERT INTO Artist (fullName, biography, facebookUrl)
VALUES ('ZHU', 'In the beginning, he was known only as Zhu. The electronic dance producer born Stephen Zhu emerged in 2014 with "Moves Like Ms. Jackson," a dance track made up of a medley of OutKast songs. From there, Zhu defied the power of the information age by remaining anonymous, focusing attention solely on his music. As more tracks appeared on the internet, the hype building around his music increased. His debut EP, The Nightday, arrived in the spring of 2014. Included on the EP, his hit single "Faded" was nominated for a Grammy, a first for an anonymous artist. The following year, Zhu recruited an impressive roster of guests for the Genesis Series EP, which featured collaborations with Skrillex, Daniel Johns, Trombone Shorty, Bone Thugs-N-Harmony, A-Trak, Keznamdi, Vancouver Sleep Clinic, AlunaGeorge, and labelmates Gallant and THEY. After embarking on his first headlining tour, which included a spot at Coachella, Zhu released the single "In the Morning" in 2016. "Generationwhy" -- the lead single off his debut album of the same name -- arrived in June 2016. The following year, Zhu surprise-released the four-track EP stardustexhalemarrakechdreams. In 2018, he issued the singles "Blame" with Ekali and "My Life" with Tame Impala. That spring, he released the EP Ringos Desert, Pt. 1, featuring JOY. on "Stormy Love, NM." and Karnaval Blues on "Still Want U." A full-length expansion followed that September. Ringos Desert added guests such as Tame Impala, Tokimonsta, and Majid Jordan to the blissed-out house party.', 
			   'http://facebook.com/ZHU'),
	   ('Jacob Lee', 'Lee''s first public success was in 2012 as part of boyband "Oracle East". Devised by Gold Coast radio station Sea FM in their search for a "Gold Coast Boy band".[2] In 2011, Lee made it to boot camp of Season 3 of popular talent-search TV show, The X Factor (Australian TV series), at age 17 after Guy Sebastian believed he wasn''t ready. In 2014, Lee appeared on the third season of The Voice Australia finishing in the top 6 of Will.i.Am''s team. In January 2016, Lee accompanied Australian boyband Justice Crew around their New South Wales tour from Coffs Harbour to Sydney, Australia.',
	   'http://facebook.com/JacobLee'),
	   ('Miguel', 'Miguel Jontel Pimentel (born October 23, 1985) is an American singer and songwriter. Raised in San Pedro, California, he began pursuing a music career at age thirteen. After signing to Jive Records in 2007, Miguel released his debut studio album, All I Want Is You, in November 2010. Although it was underpromoted upon its release, the album became a sleeper hit and helped Miguel garner commercial standing.',
	   'https://www.facebook.com/Miguel'),
	   ('Halsey', 'Ashley Nicolette Frangipane born September 29, 1994, known professionally as Halsey is an American singer, songwriter, and actress. Her stage name is a reference to the Halsey Street station of the New York City Subway in Brooklyn, and an anagram of her first name. Gaining attention from self-released music on social media platforms, Halsey was signed by Astralwerks in 2014. She toured with acts such as The Kooks and Imagine Dragons to promote her debut extended play, Room 93 (2014). Her debut studio album, Badlands (2015), was certified platinum by the Recording Industry Association of America (RIAA). Four singles were released from the album, all of which achieved minor commercial success.',
	   'https://www.facebook.com/Halsey'),
	   ('Metallica', 'Metallica is an American heavy metal band. The band was formed in 1981 in Los Angeles, California by drummer Lars Ulrich and vocalist/guitarist James Hetfield, and has been based in San Francisco, California for most of its career. The group''s fast tempos, instrumentals and aggressive musicianship made them one of the founding "big four" bands of thrash metal, alongside Megadeth, Anthrax and Slayer. Metallica''s current lineup comprises founding members Hetfield and Ulrich, longtime lead guitarist Kirk Hammett and bassist Robert Trujillo. Guitarist Dave Mustaine (who went on to form Megadeth) and bassists Ron McGovney, Cliff Burton and Jason Newsted are former members of the band.',
	   'https://www.facebook.com/Metallica'),
	   ('Michael Jackson', 'Michael Joseph Jackson (August 29, 1958 – June 25, 2009) was an American singer, songwriter and dancer. Dubbed the "King of Pop", he is regarded as one of the most significant cultural icons of the 20th century and is also regarded as one of the greatest entertainers of all time. Jackson''s contributions to music, dance, and fashion, along with his publicized personal life, made him a global figure in popular culture for over four decades. The eighth child of the Jackson family, Michael made his professional debut in 1964 with his elder brothers Jackie, Tito, Jermaine, and Marlon as a member of the Jackson 5. He began his solo career in 1971 while at Motown Records. In the early 1980s, Jackson became a dominant figure in popular music. His music videos, including those for "Beat It", "Billie Jean", and "Thriller" from his 1982 album Thriller, are credited with breaking racial barriers and transforming the medium into an art form and promotional tool. Their popularity helped bring the television channel MTV to fame.',
	   'https://www.facebook.com/MichaelJackson'),
	   ('Eminem', 'Marshall Bruce Mathers III (born October 17, 1972), known professionally as Eminem is an American rapper, songwriter, record producer, record executive, film producer, and actor. He is consistently cited as one of the greatest and most influential artists of all time in any genre, with Rolling Stone placing him in its list of the 100 Greatest Artists of All Time and labeling him the "King of Hip Hop". After his debut album Infinite (1996) and the extended play Slim Shady EP (1997), Eminem signed with Dr. Dre''s Aftermath Entertainment and subsequently achieved mainstream popularity in 1999 with The Slim Shady LP, which earned him his first Grammy Award for Best Rap Album. His next two releases, 2000''s The Marshall Mathers LP and 2002''s The Eminem Show, were worldwide successes, with each being certified diamond in U.S. sales and both winning Best Rap Album Grammy Awards—making Eminem the first artist to win the award for three consecutive LPs. They were followed by Encore in 2004, another critical and commercial success. Eminem went on hiatus after touring in 2005, releasing Relapse in 2009 and Recovery in 2010. Both won Grammy Awards and Recovery was the best-selling album of 2010 worldwide, the second time he had the international best-selling album of the year (after The Eminem Show). Eminem''s eighth album, 2013''s The Marshall Mathers LP 2, won two Grammy Awards, including Best Rap Album; it expanded his record for the most wins in that category and his Grammy total to 15. These were followed by 2017''s Revival and 2018''s Kamikaze.',
	   'https://www.facebook.com/Eminem'),
	   ('Frank Sinatra', 'Francis Albert Sinatra was an American singer, actor, and producer who was one of the most popular and influential musical artists of the 20th century. He is one of the best-selling music artists of all time, having sold more than 150 million records worldwide. Born in Hoboken, New Jersey, to Italian Americans, Sinatra began his musical career in the swing era with bandleaders Harry James and Tommy Dorsey. Sinatra found success as a solo artist after he signed with Columbia Records in 1943, becoming the idol of the "bobby soxers". He released his debut album, The Voice of Frank Sinatra, in 1946. Sinatra''s professional career had stalled by the early 1950s, and he turned to Las Vegas, where he became one of its best known residency performers as part of the Rat Pack. His career was reborn in 1953 with the success of From Here to Eternity, with his performance subsequently winning an Academy Award and Golden Globe Award for Best Supporting Actor. Sinatra released several critically lauded albums, including In the Wee Small Hours (1955), Songs for Swingin'' Lovers! (1956), Come Fly with Me (1958), Only the Lonely (1958) and Nice ''n'' Easy (1960).',
	   'https://www.facebook.com/FrankSinatra'),
	   ('Beethoven', 'Ludwig van Beethoven (/ˈlʊdvɪɡ væn ˈbeɪt(h)oʊvən/ (listen); German: [ˈluːtvɪç fan ˈbeːthoːfn̩] (listen); baptised 17 December 1770[1] – 26 March 1827) was a German composer and pianist. A crucial figure in the transition between the Classical and Romantic eras in classical music, he remains one of the most recognised and influential of all composers. His best-known compositions include 9 symphonies; 5 piano concertos; 1 violin concerto; 32 piano sonatas; 16 string quartets; a mass, the Missa solemnis; and an opera, Fidelio. His career as a composer is conventionally divided into early, middle, and late periods; the "early" period is typically seen to last until 1802, the "middle" period from 1802 to 1812, and the "late" period from 1812 to his death in 1827.',
	   'https://www.facebook.com/Beethoven'),
	   ('Gheorghe Zamfir', 'Zamfir came to the public eye when he was approached by Swiss ethnomusicologist Marcel Cellier, who extensively researched Romanian folk music in the 1960s. The composer Vladimir Cosma brought Zamfir with his pan flute to Western European countries for the first time in 1972 as the soloist in Cosma''s original music for the movie Le grand blond avec une chaussure noire. This was very successful,and since then, he has been used as soloist in movie soundtracks by composers Francis Lai, Ennio Morricone and many others. Largely through television commercials where he was billed as "Zamfir, Master of the Pan Flute", he introduced the folk instrument to a modern audience and revived it from obscurity. In 1966, Zamfir was appointed conductor of the "Ciocîrlia Orchestra", one of the most prestigious state ensembles of Romania, destined for concert tours abroad. This created the opportunity for composition and arranging. In 1969, he left Ciocîrlia and started his own taraf (small band) and in 1970 he had his first longer term contract in Paris. Zamfir discovered the much greater freedom for artistic adventure.',
	   'https://www.facebook.com/GheorgheZamfir'),
	   ('Calvin Harris', 'Adam Richard Wiles (born 17 January 1984), known professionally as Calvin Harris, is a Scottish DJ, record producer, singer and songwriter. His debut studio album I Created Disco was released in June 2007; it spawned two UK top 10 singles, "Acceptable in the 80s" and "The Girls". In 2009, Harris released his second studio album, Ready for the Weekend, which debuted at number one on the UK Albums Chart and was later certified gold by the BPI. Its lead single, "I''m Not Alone", became his first song to top the UK Singles Chart. Born in Dumfries, Scotland, Harris rose to international prominence with the release of his third studio album, 18 Months, in October 2012. Topping the UK charts, the album became his first to chart on the Billboard 200 chart in the United States, peaking at number 19. All eight of the album''s singles, including "Feel So Close", "Sweet Nothing" and "I Need Your Love", reached the top 10 in the UK. At the time, Harris broke the record for the most top 10 songs from one studio album on the UK Singles Chart with eight entries, surpassing Michael Jackson. Harris released his fourth studio album, Motion, in November 2014. It debuted at number two in the United Kingdom and at number five in the United States and became Harris''s second consecutive number one album on the US Dance/Electronic Albums chart.',
	   'https://www.facebook/CalvinHarris')

/*
	Concerts
*/

SET IDENTITY_INSERT Concerts OFF
GO

INSERT INTO Concerts (artistId, dateConcert, locationConcert)
VALUES (1, '2019-01-15', 'Holy Ship, Miami'),
	   (1, '2019-03-16', 'Espacio IDESA, Asuncion'),
	   (1, '2019-03-25', 'Parque O''Higgins, Santiago'),
	   (2, '2019-02-23', 'Feierwerk, Munich'),
	   (2, '2019-03-08', 'The Electric Theater, St. George'),
	   (2, '2019-03-09', 'Velour Live Music Gallery, Provo'),
	   (2, '2019-04-15', 'Valley Bar, Phoenix'),
	   (3, '2019-02-23', 'Tyson Ranch, Desert Hot Springs'),
	   (3, '2019-04-04', 'House of Blues - Dallas, Dallas'),
	   (5, '2019-02-01', 'Quicken Loans Arena, Cleveland'),
	   (5, '2019-02-28', 'Don Haskins center, El Paso'),
	   (5, '2019-08-14', 'Arena Nationala - Bucharest'),
	   (7, '2019-02-15', 'Aloha Stadium, Honolulu'),
	   (7, '2019-02-27', 'Optus Stadium, Burswood'),
	   (7, '2019-03-02', 'Westpac Stadium, Wellington')

/*
	Playlists
*/
SET IDENTITY_INSERT Playlist OFF
GO

INSERT INTO Playlist (playlistName, createdDate, updatedDate, userId)
VALUES ('Car Ride', GETDATE(), GETDATE(), 1),
	   ('Rock', GETDATE(), GETDATE(), 2)

/*
	Albums
*/

SET IDENTITY_INSERT Album OFF

INSERT INTO Album (albumName, genreId, artistId, imageId)
VALUES ('Ringos Desert', 2, 1, 1),
		('Bad Land', 5, 4, 2),
		('Gheorghe Zamfir Album', 1, 10, 3),
		('Jacob Lee Album', 7, 2, 4),
		('Master of Puppets', 6, 5, 5),
		('Piano Sonatas', 1, 9, 6),
		('Revelation', 3, 7, 7),
		('Xcape', 5, 6, 8),
		('Frank Sinatra Album', 4, 8, 10),
		('Miguel Album', 5, 3, 11)

/* 
	Tracks
*/

SET IDENTITY_INSERT Track OFF

INSERT INTO Track(albumId, nameTrack, filepath)
VALUES (1, 'ZHU - Burn Babylon Ft. Keznamdi & Daniel Wilson', 'D:\GitLab Tracks\ZHU\ZHU - Burn Babylon Ft. Keznamdi & Daniel Wilson.mp3'),
		(1, 'ZHU - Coming Home (feat. Majid Jordan)', 'D:\GitLab Tracks\ZHU\ZHU - Coming Home (feat. Majid Jordan).mp3'),
		(1, 'ZHU - Desert Woman', 'D:\GitLab Tracks\ZHU\ZHU - Desert Woman.mp3'),
		(1, 'ZHU - Drowning', 'D:\GitLab Tracks\ZHU\ZHU - Drowning.mp3'),
		(1, 'ZHU - Ghost In My Bed', 'D:\GitLab Tracks\ZHU\ZHU - Ghost In My Bed.mp3'),
		(1, 'ZHU - Guilty Love', 'D:\GitLab Tracks\ZHU\ZHU - Guilty Love.mp3'),
		(1, 'ZHU - Light It Up (feat. TOKiMONSTA)', 'D:\GitLab Tracks\ZHU\ZHU - Light It Up (feat. TOKiMONSTA).mp3'),
		(1, 'ZHU - Love That Hurts', 'D:\GitLab Tracks\ZHU\ZHU - Love That Hurts (feat. Karnaval Blues & Indiana).mp3'),
		(1, 'ZHU - Save Me', 'D:\GitLab Tracks\ZHU\ZHU - Save Me.mp3'),
		(1, 'ZHU - Stormy Love', 'D:\GitLab Tracks\ZHU\ZHU - Stormy Love.mp3'),
		(1, 'ZHU - Waters of Monaco', 'D:\GitLab Tracks\ZHU\ZHU - Waters of Monaco.mp3'),
		(1, 'ZHU, Karnaval Blues - Still Want U', 'ZHU, Karnaval Blues - Still Want U.mp3')

INSERT INTO Track(albumId, nameTrack, filepath)
VALUES (2, 'Halsey - Alone', 'D:\GitLab Tracks\Halsey\Halsey - Alone.mp3'),
		(2, 'Halsey - Bad At Love', 'D:\GitLab Tracks\Halsey\Halsey - Bad At Love.mp3'),
		(2, 'Halsey - Castle', 'D:\GitLab Tracks\Halsey\Halsey - Castle.mp3'),
		(2, 'Halsey - Colors', 'D:\GitLab Tracks\Halsey\Halsey - Colors.mp3'),
		(2, 'Halsey - Ghost', 'D:\GitLab Tracks\Halsey\Halsey - Ghost.mp3'),
		(2, 'Halsey - Hurricane', 'D:\GitLab Tracks\Halsey\Halsey - Hurricane.mp3'),
		(2, 'Halsey - Now Or Never', 'D:\GitLab Tracks\Halsey\Halsey - Now Or Never.mp3'),
		(2, 'Halsey - Sorry', 'D:\GitLab Tracks\Halsey\Halsey - Sorry.mp3'),
		(2, 'Halsey - Strangers', 'D:\GitLab Tracks\Halsey\Halsey - Strangers.mp3')
		
INSERT INTO Track(albumId, nameTrack, filepath)
VALUES (3, 'Gheorghe Zamfir - Chariots of Fire', 'D:\GitLab Tracks\Gheorghe Zamfir\Gheorghe Zamfir - Chariots of Fire.mp3'),
		(3, 'Gheorghe Zamfir - Ciocarlia', 'D:\GitLab Tracks\Gheorghe Zamfir\Gheorghe Zamfir - Ciocarlia.mp3'),
		(3, 'Gheorghe Zamfir - De cand ne-a aflat multimea', 'D:\GitLab Tracks\Gheorghe Zamfir\Gheorghe Zamfir - De cand ne-a aflat multimea.mp3'),
		(3, 'Gheorghe Zamfir - Ete D''amour', 'D:\GitLab Tracks\Gheorghe Zamfir\Gheorghe Zamfir - Ete D''amour.mp3'),
		(3, 'Gheorghe Zamfir - Love story', 'D:\GitLab Tracks\Gheorghe Zamfir\Gheorghe Zamfir - Love story.mp3'),
		(3, 'Gheorghe Zamfir - She', 'D:\GitLab Tracks\Gheorghe Zamfir\Gheorghe Zamfir - She.mp3'),
		(3, 'Gheorghe Zamfir - Sound of silence', 'D:\GitLab Tracks\Gheorghe Zamfir\Gheorghe Zamfir - Sound of silence.mp3'),
		(3, 'Gheorghe Zamfir - The Lonely Shepherd', 'D:\GitLab Tracks\Gheorghe Zamfir\Gheorghe Zamfir - The Lonely Shepherd.mp3')

INSERT INTO Track(albumId, nameTrack, filepath)
VALUES (4, 'Jacob Lee - Black Shees', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - Black Shees.mp3'),
		(4, 'Jacob Lee - Cursed', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - Cursed.mp3'),
		(4, 'Jacob Lee - Demons', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - Demons.mp3'),
		(4, 'Jacob Lee - I Belong to You', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - I Belong to You.mp3'),
		(4, 'Jacob Lee - I Still Know You', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - I Still Know You.mp3'),
		(4, 'Jacob Lee - Nevermind', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - Nevermind.mp3'),
		(4, 'Jacob Lee - Reality', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - Reality.mp3'),
		(4, 'Jacob Lee - Suitcase', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - Suitcase.mp3'),
		(4, 'Jacob Lee - With You', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - With You.mp3')

INSERT INTO Track(albumId, nameTrack, filepath)
VALUES (4, 'Jacob Lee - Black Shees', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - Black Shees.mp3'),
		(4, 'Jacob Lee - Cursed', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - Cursed.mp3'),
		(4, 'Jacob Lee - Demons', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - Demons.mp3'),
		(4, 'Jacob Lee - I Belong to You', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - I Belong to You.mp3'),
		(4, 'Jacob Lee - I Still Know You', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - I Still Know You.mp3'),
		(4, 'Jacob Lee - Nevermind', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - Nevermind.mp3'),
		(4, 'Jacob Lee - Reality', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - Reality.mp3'),
		(4, 'Jacob Lee - Suitcase', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - Suitcase.mp3'),
		(4, 'Jacob Lee - With You', 'D:\GitLab Tracks\Jacob Lee\Jacob Lee - With You.mp3')

INSERT INTO Track(albumId, nameTrack, filepath)
VALUES (5, 'Metallica - Spit Out the Bone', 'D:\GitLab Tracks\Metallica\Metallica - Spit Out the Bone.mp3'),
		(5, 'Metallica - Now That We''re Dead', 'D:\GitLab Tracks\Metallica\Metallica - Now That We''re Dead.mp3'),
		(5, 'Metallica - Murder One', 'D:\GitLab Tracks\Metallica\Metallica - Murder One.mp3'),
		(5, 'Metallica - Moth Into Flame', 'D:\GitLab Tracks\Metallica\Metallica - Moth Into Flame.mp3'),
		(5, 'Metallica - Here Comes Revenge', 'D:\GitLab Tracks\Metallica\Metallica - Here Comes Revenge.mp3'),
		(5, 'Metallica - Halo On Fire', 'D:\GitLab Tracks\Metallica\Metallica - Halo On Fire.mp3'),
		(5, 'Metallica - Confusion', 'D:\GitLab Tracks\Metallica\Metallica - Confusion.mp3'),
		(5, 'Metallica - Atlas, Rise!', 'D:\GitLab Tracks\Metallica\Metallica - Atlas, Rise!.mp3')

INSERT INTO Track(albumId, nameTrack, filepath)
VALUES (6, 'Beethoven - 9na-Sinfonia', 'D:\GitLab Tracks\Beethoven\Beethoven - 9na-Sinfonia.mp3'),
		(6, 'Beethoven - A melody of tears', 'D:\GitLab Tracks\Beethoven\Beethoven - A melody of tears.mp3'),
		(6, 'Beethoven - Für Elise', 'D:\GitLab Tracks\Beethoven\Beethoven - Für Elise.mp3'),
		(6, 'Beethoven - Melody of Love', 'D:\GitLab Tracks\Beethoven\Beethoven - Melody of Love.mp3'),
		(6, 'Beethoven - Moonlight Sonata', 'D:\GitLab Tracks\Beethoven\Beethoven - Moonlight Sonata.mp3')

INSERT INTO Track(albumId, nameTrack, filepath)
VALUES (7, 'Eminem - Beautiful', 'D:\GitLab Tracks\Eminem\Eminem - Beautiful.mp3'),
		(7, 'Eminem - Berzerk', 'D:\GitLab Tracks\Eminem\Eminem - Berzerk.mp3'),
		(7, 'Eminem - Love The Way You Lie', 'D:\GitLab Tracks\Eminem\Eminem - Love The Way You Lie.mp3'),
		(7, 'Eminem - Not Afraid', 'D:\GitLab Tracks\Eminem\Eminem - Not Afraid.mp3'),
		(7, 'Eminem - Nowhere Fast', 'D:\GitLab Tracks\Eminem\Eminem - Nowhere Fast.mp3'),
		(7, 'Eminem - Rap God', 'D:\GitLab Tracks\Eminem\Eminem - Rap God.mp3'),
		(7, 'Eminem - River', 'D:\GitLab Tracks\Eminem\Eminem - River.mp3'),
		(7, 'Eminem - Survival', 'D:\GitLab Tracks\Eminem\Eminem - Survival.mp3'),
		(7, 'Eminem - Untouchable', 'D:\GitLab Tracks\Eminem\Eminem - Untouchable.mp3'),
		(7, 'Eminem - Walk On Water', 'D:\GitLab Tracks\Eminem\Eminem - Walk On Water.mp3'),
		(7, 'Eminem - When I''m Gone', 'D:\GitLab Tracks\Eminem\Eminem - When I''m Gone.mp3'),
		(7, 'Eminem - You Don''t Know', 'D:\GitLab Tracks\Eminem\Eminem - You Don''t Know.mp3')

INSERT INTO Track(albumId, nameTrack, filepath)
VALUES (8, 'Michael Jackson - Bad', 'D:\GitLab Tracks\Michael Jackson\Michael Jackson - Bad.mp3'),
		(8, 'Michael Jackson - Beat It', 'D:\GitLab Tracks\Michael Jackson\Michael Jackson - Beat It.mp3'),
		(8, 'Michael Jackson - Billie Jean', 'D:\GitLab Tracks\Michael Jackson\Michael Jackson - Billie Jean.mp3'),
		(8, 'Michael Jackson - Black Or White', 'D:\GitLab Tracks\Michael Jackson\Michael Jackson - Black Or White.mp3'),
		(8, 'Michael Jackson - Dont Stop ''Til You Get Enough', 'D:\GitLab Tracks\Michael Jackson\Michael Jackson - Dont Stop ''Til You Get Enough.mp3'),
		(8, 'Michael Jackson - Jam', 'D:\GitLab Tracks\Michael Jackson\Michael Jackson - Jam.mp3'),
		(8, 'Michael Jackson - Remember The Time', 'D:\GitLab Tracks\Michael Jackson\Michael Jackson - Remember The Time.mp3'),
		(8, 'Michael Jackson - Rock With You', 'D:\GitLab Tracks\Michael Jackson\Michael Jackson - Rock With You.mp3'),
		(8, 'Michael Jackson - Smooth Criminal', 'D:\GitLab Tracks\Michael Jackson\Michael Jackson - Smooth Criminal.mp3'),
		(8, 'Michael Jackson - They Dont Care About Us', 'D:\GitLab Tracks\Michael Jackson\Michael Jackson - They Dont Care About Us.mp3'),
		(8, 'Michael Jackson - Thriller', 'D:\GitLab Tracks\Michael Jackson\Michael Jackson - Thriller.mp3')

INSERT INTO Track(albumId, nameTrack, filepath)
VALUES (9, 'Frank Sinatra - Half As Lovely', 'D:\GitLab Tracks\Frank Sinatra\Frank Sinatra - Half As Lovely.mp3'),
		(9, 'Frank Sinatra - I''ll Wind', 'D:\GitLab Tracks\Frank Sinatra\Frank Sinatra - I''ll Wind.mp3'),
		(9, 'Frank Sinatra - I''ve got you under my skin', 'D:\GitLab Tracks\Frank Sinatra\Frank Sinatra - I''ve got you under my skin.mp3'),
		(9, 'Frank Sinatra - Killing me softly', 'D:\GitLab Tracks\Frank Sinatra\Frank Sinatra - Killing me softly.mp3'),
		(9, 'Frank Sinatra - My Way', 'D:\GitLab Tracks\Frank Sinatra\Frank Sinatra - My Way.mp3'),
		(9, 'Frank Sinatra - New York, New York.', 'D:\GitLab Tracks\Frank Sinatra\Frank Sinatra - New York, New York..mp3'),
		(9, 'Frank Sinatra - Strangers in the Night', 'D:\GitLab Tracks\Frank Sinatra\Frank Sinatra - Strangers in the Night.mp3'),
		(9, 'Frank Sinatra - The Gal That Got Away', 'D:\GitLab Tracks\Frank Sinatra\Frank Sinatra - The Gal That Got Away.mp3'),
		(9, 'Frank Sinatra - The Way You Look Tonight', 'D:\GitLab Tracks\Frank Sinatra\Frank Sinatra - The Way You Look Tonight.mp3'),
		(9, 'Frank Sinatra - This Love of Mine', 'D:\GitLab Tracks\Frank Sinatra\Frank Sinatra - This Love of Mine.mp3')

INSERT INTO Track(albumId, nameTrack, filepath)
VALUES (10, 'Miguel - Anointed', 'D:\GitLab Tracks\Miguel\Miguel - Anointed.mp3'),
		(10, 'Miguel - Caramelo Duro', 'D:\GitLab Tracks\Miguel\Miguel - Caramelo Duro.mp3'),
		(10, 'Miguel - City of Angels', 'D:\GitLab Tracks\Miguel\Miguel - City of Angels.mp3'),
		(10, 'Miguel - Come Through and Chill', 'D:\GitLab Tracks\Miguel\Miguel - Come Through and Chill.mp3'),
		(10, 'Miguel - Criminal', 'D:\GitLab Tracks\Miguel\Miguel - Criminal.mp3'),
		(10, 'Miguel - Harem', 'D:\GitLab Tracks\Miguel\Miguel - Harem.mp3'),
		(10, 'Miguel - I Found You', 'D:\GitLab Tracks\Miguel\Miguel - I Found You.mp3'),
		(10, 'Miguel - Now', 'D:\GitLab Tracks\Miguel\Miguel - Now.mp3'),
		(10, 'Miguel - Pineapple Skies', 'D:\GitLab Tracks\Miguel\Miguel - Pineapple Skies.mp3'),
		(10, 'Miguel - Remind Me to Forget', 'D:\GitLab Tracks\Miguel\Miguel - Remind Me to Forget.mp3'),
		(10, 'Miguel - Told You So', 'D:\GitLab Tracks\Miguel\Miguel - Told You So.mp3')


/*
	TrackArtists
*/

SET IDENTITY_INSERT TrackArtists OFF

INSERT into TrackArtists(trackId, artistId)
values (1, 1), (2, 1), (3, 1), (4, 1), (5, 1), (6, 1), (7, 1), (8, 1), (9, 1), (10, 1), (11, 1), (12, 1),
	   (13, 4), (14, 4), (15, 4), (16, 4), (17, 4), (18, 4), (19, 4), (20, 4), (21, 4),
	   (22, 10), (23, 10), (24, 10), (25, 10), (26, 10), (27, 10), (28, 10), (29, 10),
	   (30, 2), (31, 2), (32, 2), (33, 2), (34, 2), (35, 2), (36, 2), (37, 2), (38, 2), (39, 2), (40, 2), (41, 2), (42, 2), (43, 2), (44, 2), (45, 2), (46, 2), (47, 2),
	   (48, 5), (49, 5), (50, 5), (51, 5), (52, 5), (53, 5), (54, 5), (55, 5),
	   (56, 9), (57, 9), (58, 9), (59, 9), (60, 9),
	   (61, 7), (62, 7), (63, 7), (64, 7), (65, 7), (66, 7), (67, 7), (68, 7), (69, 7), (70, 7), (71, 7), (72, 7),
	   (73, 6), (74, 6), (75, 6), (76, 6), (77, 6), (78, 6), (79, 6), (80, 6), (81, 6), (82, 6), (83, 6),
	   (84, 8), (85, 8), (86, 8), (87, 8), (88, 8), (89, 8), (90, 8), (91, 8), (92, 8), (93, 8),
	   (94, 3), (95, 3), (96, 3), (97, 3), (98, 3), (99, 3), (100, 3), (101, 3), (102, 3), (103, 3), (104, 3)

/*
	PlaylistGenres
*/

SET IDENTITY_INSERT PlaylistsGenresTracks OFF

INSERT INTO PlaylistsGenresTracks(playlistId, trackId)
VALUES (1, 22), (1, 23), (1, 24), (1, 25), (1, 26), (1, 27), (1, 28), (1, 29), (1, 56), (1, 57), (1, 58), (1, 59), (1, 60),
	(2, 1), (2, 2), (2, 3), (2, 4), (2, 5), (2, 6), (2, 7), (2, 8), (2, 9), (2, 10), (2, 11), (2, 12),
	(3, 61), (3, 62), (3, 63), (3, 64), (3, 65), (3, 66), (3, 67), (3, 68), (3, 69), (3,70), (3, 71), (3, 72),
	(4, 84), (4, 85), (4, 86), (4, 87), (4, 88), (4, 89), (4, 90), (4, 91), (4, 92), (4, 93),
	(5, 13), (5, 14), (5, 15), (5, 16), (5, 17), (5, 18), (5, 19), (5, 20), (5, 21), (5, 94), (5, 95), (5, 96), (5, 97), (5, 98), (5, 99), (5, 100), (5, 101), (5, 102), (5, 103), (5, 104),
	(6, 48), (6, 49), (6, 50), (6, 51), (6, 52), (6, 53), (5, 54), (6, 55),
	(7, 30), (7, 31), (7, 32), (7, 33), (7, 34), (7, 35), (7, 36), (7, 37), (7, 38), (7, 39), (7, 40), (7, 41), (7, 42), (7, 43), (7, 44), (7, 45), (7, 46), (7, 47)

/*
	Tracks of playlists
*/

SET IDENTITY_INSERT PlaylistTracks OFF

INSERT INTO PlaylistTracks (playlistId, trackId)
VALUES (1, 10), (1, 12), (1, 13), (1, 20), (1, 25)


INSERT INTO PlaylistTracks (playlistId, trackId)
VALUES (2, 1), (2, 5), (2, 10), (2, 18), (2, 25), (2, 30), (2, 54), (2, 67), (2, 80), (2, 99)

