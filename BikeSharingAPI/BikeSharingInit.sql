PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

DROP TABLE IF EXISTS Session;
DROP TABLE IF EXISTS User;

CREATE TABLE User(
	Id 				INTEGER 		NOT NULL 
									PRIMARY KEY 
									AUTOINCREMENT,
	Name 			NVARCHAR(50) 	NOT NULL,
	Surname 		NVARCHAR(50) 	NOT NULL,
	Gender 			CHARACTER,
	BirthDate 		DATETIME,
	DateJoined 		DATETIME,
	EMail 			NVARCHAR(50),
	PhoneNumber 	NVARCHAR(15),
	Balance 		NUMERIC
	);
	
CREATE TABLE Session(
	Id 				NVARCHAR(36) 	NOT NULL 
									PRIMARY KEY,
	UserId			INTEGER			REFERENCES User(Id) ON DELETE NO ACTION ON UPDATE CASCADE,
	StartDate 		DATETIME,
	EndDate 		DATETIME,
	StartLocation	NVARCHAR(15),
	EndLocation		NVARCHAR(15),
	Temperature		NUMERIC,
	IsHoliday		BOOLEAN,
	Cost			NUMERIC,
	UserComment		NVARCHAR(150),
	TotalDistance	NUMERIC,
	UserRating		INTEGER
	);
	
INSERT INTO User VALUES (NULL,"Can", "Yılmaz", "M", "1995-05-20", "2020-03-19", "canyilmaz999@gmail.com", "05551231212", 85.5);
INSERT INTO User VALUES (NULL,"Mehmet", "Yılmaz", "M", "1995-05-20", "2020-03-19", "canyilmaz999@gmail.com", "05551231212", 85.5);
INSERT INTO User VALUES (NULL,"Derya", "Yılmaz", "F", "1995-05-20", "2020-03-19", "canyilmaz999@gmail.com", "05551231212", 85.5);
INSERT INTO User VALUES (NULL,"Ayşe", "Yılmaz", "F", "1995-05-20", "2020-03-19", "canyilmaz999@gmail.com", "05551231212", 85.5);

INSERT INTO Session VALUES ("48fc25ed-bf80-4c40-9375-c59dca26528f", 1, "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, TRUE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 5);
INSERT INTO Session VALUES ("71a6cb62-1da4-4876-87d7-e1382cf7ac52", 1, "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, TRUE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 5);
INSERT INTO Session VALUES ("e73366f3-c1da-4806-82fd-4bfc12b0f1aa", 1, "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, TRUE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 5);
INSERT INTO Session VALUES ("f3145e41-6f5c-4890-a845-f6034bb82841", 1, "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, TRUE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 5);
INSERT INTO Session VALUES ("86850c29-cd3b-439a-a36f-321cf7d7dd39", 2, "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, TRUE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 5);
INSERT INTO Session VALUES ("95fbe881-4d34-46d9-8548-370e2e262083", 2, "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, TRUE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 5);
INSERT INTO Session VALUES ("d0aa1ae1-2eb5-4729-866e-9a58a520d59b", 3, "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, TRUE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 5);
INSERT INTO Session VALUES ("0d605c39-4a6e-412a-9566-47629a318d2f", 3, "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, TRUE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 5);
INSERT INTO Session VALUES ("ca8b08e1-251c-4825-a7e3-7b7e630ae467", 3, "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, TRUE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 5);
INSERT INTO Session VALUES ("579ef790-e251-47d8-86ec-5137db0aace3", 4, "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, TRUE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 5);
INSERT INTO Session VALUES ("22f78d8d-33f5-4b2b-ade1-289b06f1f52c", 4, "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, TRUE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 5);
INSERT INTO Session VALUES ("551f30ee-3338-4c0b-b098-b4d51bb55bb2", 4, "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, TRUE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 5);
INSERT INTO Session VALUES ("fcdcc587-2965-4af3-a949-03076f708192", 4, "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, TRUE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 5);
 

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
SELECT * FROM User;
SELECT * FROM Session;
