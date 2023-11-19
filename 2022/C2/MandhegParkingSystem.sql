CREATE DATABASE MandhegParkingSystem
GO
USE MandhegParkingSystem

CREATE TABLE Employee(
	id					INT				NOT NULL	IDENTITY,
	[name]				VARCHAR(200)	NOT NULL,
	email				VARCHAR(200)	NOT NULL	UNIQUE,
	[password]			VARCHAR(64)		NOT NULL,
	phone_number		VARCHAR(200)	NOT NULL,
	[address]			VARCHAR(200)	NOT NULL,
	[date_of_birth]		DATE			NOT NULL,
	gender				VARCHAR(10)		NOT NULL,	/*'Male' or 'Female'*/
	created_at			DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	last_updated_at		DATETIME,
	deleted_at			DATETIME,
	PRIMARY KEY (id),
);

CREATE TABLE Membership(
	id					INT				NOT NULL	IDENTITY,
	[name]				VARCHAR(20)		NOT NULL,
	created_at			DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	last_updated_at		DATETIME,
	deleted_at			DATETIME,
	PRIMARY KEY (id),
);

CREATE TABLE VehicleType(
	id					INT				NOT NULL	IDENTITY,
	name				VARCHAR(100)	NOT NULL,
	created_at			DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	last_updated_at		DATETIME,
	deleted_at			DATETIME,
    PRIMARY KEY (id),
);

CREATE TABLE HourlyRates(
	id					INT				NOT NULL	IDENTITY,
	membership_id		INT				NOT NULL,
	vehicle_type_id		INT				NOT NULL,
	[value]				DECIMAL(10,2)	NOT NULL,
	created_at			DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	last_updated_at		DATETIME,
	deleted_at			DATETIME,
	PRIMARY KEY (id),
	FOREIGN KEY (membership_id)		REFERENCES Membership (id),
	FOREIGN KEY (vehicle_type_id)	REFERENCES VehicleType (id),
);

CREATE TABLE Member(
	id					INT				NOT NULL	IDENTITY,
	membership_id		INT				NOT NULL,
	[name]				VARCHAR(200)	NOT NULL,
	email				VARCHAR(200)	NOT NULL	UNIQUE,
	phone_number		VARCHAR(200)	NOT NULL,
	[address]			VARCHAR(200)	NOT NULL,
	[date_of_birth]		DATE			NOT NULL,
	gender				VARCHAR(10)		NOT NULL,	/*'Male' or 'Female'*/
	created_at			DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	last_updated_at		DATETIME,
	deleted_at			DATETIME,
	PRIMARY KEY (id),
	FOREIGN KEY (membership_id)		REFERENCES Membership (id),
);

CREATE TABLE Vehicle(
	id					INT				NOT NULL	IDENTITY,
	vehicle_type_id		INT				NOT NULL,
	member_id			INT				NOT NULL,
	license_plate		VARCHAR(20)		NOT NULL	UNIQUE,
	notes				VARCHAR(200),
	created_at			DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	last_updated_at		DATETIME,
	deleted_at			DATETIME,
	PRIMARY KEY (id),
	FOREIGN KEY (vehicle_type_id)	REFERENCES VehicleType (id),
	FOREIGN KEY (member_id)			REFERENCES Member (id),
);

CREATE TABLE ParkingData(
	id					INT				NOT NULL	IDENTITY,
	license_plate		VARCHAR(20)		NOT NULL,
	vehicle_id			INT				NULL,
	employee_id	        INT 			NOT NULL,
	hourly_rates_id     INT             NOT NULL,
	datetime_in			DATETIME		NOT NULL,
	datetime_out		DATETIME 		NOT NULL,
	amount_to_pay		DECIMAL(10,2)	NOT NULL,
	created_at			DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	last_updated_at		DATETIME,
	deleted_at			DATETIME,
	PRIMARY KEY (id),	
	FOREIGN KEY (vehicle_id)		REFERENCES Vehicle (id),
	FOREIGN KEY (employee_id)		REFERENCES Employee (id),
	FOREIGN KEY (hourly_rates_id)	REFERENCES HourlyRates (id),
);


INSERT INTO Employee([name],[email],[password],[phone_number],[address],[date_of_birth],[gender]) VALUES
('Laurel Vang','pellentesque.massa.lobortis@fringillacursus.net','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918','1-181-155-6849','Ap #735-828 Magna. Rd.','1989-04-19','Female'),
('Daniel Cervantes','Praesent.luctus@egestasSed.ca','7dee848708b11ad455f358d04d47a70065b37dc4423d744fa9eab81fb1086d67','1-146-372-5842','Ap #118-7803 A, St.','1985-07-24','Female'),
('Sophia Cooley','tellus.lorem.eu@suscipit.edu','da3f0ee9e00124a839b456e93038310d935de13f254a2762212e57b7c28dbfb1','1-691-593-4518','P.O. Box 918, 7534 Sit Ave','1988-05-16','Female'),
('Paula Sanford','ut.eros@accumsan.com','a7a65b5c533b6bb9df0a0f31f236b2c3adbd19df28d9e6763d4c754db9dbcdbb','1-120-886-4114','Ap #594-3475 Lorem Avenue','1980-10-01','Male'),
('Anthony Mcintosh','ipsum@non.com','86e4a97ffaebe688393983536ae4d160085c4251f39d006849817da9263d13bc','1-858-819-4192','P.O. Box 712, 1123 Sem Av.','1982-01-17','Male'),
('Giacomo Merrill','Nunc.sollicitudin.commodo@pellentesque.net','89fce7ab67a52f8e3187525d5e5635ccc3cff122324f174c9296a7cf7016400c','1-597-208-4825','P.O. Box 141, 1506 Cras Ave','1991-06-12','Male'),
('Clinton Rhodes','ridiculus.mus@purusactellus.co.uk','e759a5fbb2476c0e95d86901d0a8ce0727cdedc89182bd6c747b0a3ec7df5781','1-858-735-8932','378-3448 Aliquet Rd.','1997-03-15','Female'),
('Howard Peters','enim.Curabitur@rutrumurna.com','273cce6c2b6144cdaaeea059c33989511ee4bc3fca9d83ab62aa1474948c6362','1-938-432-2020','3595 Justo Avenue','1998-07-18','Male'),
('Eagan Griffin','tempor.est.ac@dictumsapien.edu','b29b15b020c7397bafaffc6069486173e0b80fad582b619ed60fc749c8af7947','1-294-696-7151','9008 Dignissim. Street','1983-03-10','Male'),
('Aristotle Rivers','erat.volutpat.Nulla@cursuset.net','ef8f3125dbddb62a2053fa74c4422907c0695bccf73445471f80b2324d12b852','1-823-449-5494','Ap #322-4296 Cras Rd.','1996-06-20','Female');


INSERT INTO Membership([name]) VALUES
('Non Member'),
('Regular'),
('VIP');


INSERT INTO VehicleType([name]) VALUES
('Motorcycle'),
('Car'),
('Truck');


INSERT INTO HourlyRates([membership_id],[vehicle_type_id],[value]) VALUES
(1,1,2000),
(1,2,4000),
(1,3,6000),
(2,1,1000),
(2,2,2000),
(2,3,3000),
(3,1,500),
(3,2,1000),
(3,3,1500);


INSERT INTO Member([membership_id],[name],[email],[phone_number],[address],[date_of_birth],[gender]) VALUES
(3,'Odette Lee','at@congueIn.com','1-244-372-1974','939-4359 Nec Ave','1996-07-04','Female'),
(2,'Basil Calhoun','nisi.a@nonummyultricies.ca','1-441-758-9364','3139 Urna. Av.','1992-03-06','Male'),
(2,'Chaim Conrad','augue.eu@nisidictum.org','1-666-938-1104','P.O. Box 615, 2760 Eleifend Avenue','1982-08-09','Female'),
(3,'Elijah Macdonald','orci.in@sempercursusInteger.co.uk','1-608-477-6519','Ap #837-5419 Lorem Rd.','1987-07-10','Male'),
(3,'Alexis Logan','urna.convallis.erat@commodo.org','1-880-397-0481','1826 Donec Ave','1999-05-11','Female'),
(2,'Logan Maldonado','volutpat@Duisdignissimtempor.ca','1-974-243-1140','8139 Viverra. St.','1997-03-18','Male'),
(2,'Rosalyn Holland','eget.venenatis@sedliberoProin.co.uk','1-320-971-7638','9435 In Av.','1998-07-20','Female'),
(3,'Abel Mccoy','mattis@felisorci.com','1-638-287-7552','972-5620 Curabitur St.','2000-04-17','Male'),
(3,'Maryam Mcconnell','pretium.neque.Morbi@maurisid.co.uk','1-708-874-1230','7284 Id St.','1990-06-04','Male'),
(3,'Ulysses Oconnor','vitae.erat@utodio.ca','1-747-385-0774','583-2158 Nunc Rd.','1985-12-01','Female'),
(2,'Stacey Roman','a.magna.Lorem@velitQuisquevarius.co.uk','1-232-398-7897','8044 Mattis St.','1981-08-14','Male'),
(3,'Ferdinand Duncan','netus.et.malesuada@fermentum.com','1-999-431-4390','891-1306 Gravida. Road','1984-04-29','Female'),
(3,'Xanthus Mcpherson','eget.venenatis@velpede.com','1-847-126-0779','9410 Eu Av.','1993-02-19','Female'),
(2,'Kaye Weber','orci.luctus.et@sitametlorem.co.uk','1-255-242-8647','P.O. Box 253, 5331 Volutpat Avenue','1995-05-11','Male'),
(3,'Jada Noel','ipsum@Vivamusnon.org','1-465-532-1833','359-4976 Lacus. Road','1987-11-03','Female'),
(3,'Yuli Doyle','dictum.magna.Ut@Nuncquisarcu.edu','1-634-514-5566','1560 Dolor, Avenue','1985-05-25','Female'),
(3,'Nadine Sanchez','Morbi.quis@justo.org','1-637-398-7564','Ap #104-8169 Non, Avenue','1989-10-23','Male'),
(3,'Halee Hall','netus.et.malesuada@commodoipsum.ca','1-546-372-5032','7902 Ultrices Rd.','1983-01-25','Female'),
(3,'Beverly Farrell','dui.nec.tempus@elit.com','1-578-793-6192','8576 Consectetuer Avenue','1989-03-04','Male'),
(3,'Maxine Castro','Mauris.eu.turpis@vehiculaPellentesque.edu','1-203-724-6691','2359 Laoreet, Ave','1999-08-21','Female');


INSERT INTO Vehicle([vehicle_type_id],[member_id],[license_plate],[notes]) VALUES
(1,14,'PK 7335 ZBA','magna a neque. Nullam ut'),
(3,7,'SA 2216 UJD','Cum sociis'),
(2,13,'AB 1978 ERC','et tristique pellentesque, tellus sem mollis dui, in sodales elit'),
(2,9,'HH 9402 DCB','ante. Vivamus non lorem vitae odio sagittis semper.'),
(1,12,'XJ 9372 EDL',''),
(3,11,'ND 3307 FLW','lorem vitae odio sagittis semper. Nam tempor diam'),
(2,1,'JZ 4826 EFE','vitae nibh. Donec est mauris, rhoncus'),
(2,11,'JF 0598 QQX','tempor arcu.'),
(3,7,'YK 4818 ILT','dolor. Fusce feugiat. Lorem ipsum dolor sit amet, consectetuer adipiscing'),
(2,3,'SG 6072 KXZ','Nunc pulvinar arcu et pede. Nunc'),
(3,15,'HD 1562 RWK',''),
(1,20,'VW 7820 TMH','lectus'),
(1,6,'MF 3869 MEB',''),
(2,17,'LQ 5694 AZI','sed dictum eleifend, nunc risus'),
(2,9,'OW 3001 EGJ','rhoncus. Nullam velit'),
(1,14,'FU 0290 VBF','lorem lorem, luctus ut, pellentesque eget, dictum placerat, augue. Sed'),
(2,13,'YU 7286 QTQ','Fusce feugiat. Lorem ipsum dolor sit amet,'),
(2,5,'EP 7841 MAR','arcu. Vestibulum ante ipsum primis in faucibus'),
(1,16,'VV 2698 QGZ',''),
(2,18,'PV 7265 AZV','tortor.'),
(3,5,'AZ 5367 DVL','lorem, sit amet ultricies sem'),
(1,17,'FN 2752 OHM','nulla.'),
(2,4,'ZT 1965 MYR','vel, convallis in, cursus et,'),
(2,20,'AM 9686 DVG',''),
(3,14,'NJ 8762 HPS','nonummy'),
(3,5,'MO 8159 XIV','sodales at, velit. Pellentesque'),
(1,1,'EH 8782 ZJY','interdum. Nunc sollicitudin commodo ipsum. Suspendisse non leo. Vivamus nibh'),
(1,18,'RH 2018 BTK','ipsum primis in faucibus orci'),
(3,11,'KR 3467 EFB','parturient'),
(1,17,'YF 6970 ZRQ','');


INSERT INTO ParkingData([license_plate],[vehicle_id],[employee_id],[hourly_rates_id],[datetime_in],[datetime_out],[amount_to_pay]) VALUES
('KK 2131 HGT',NULL,1,2,'2021-03-23 06:00:51.437',CURRENT_TIMESTAMP,12000),
('ND 3307 FLW',6,2,2,'2021-03-23 08:00:51.437',CURRENT_TIMESTAMP,3000),
('JF 0598 QQX',8,2,2,'2021-03-23 05:00:51.437',CURRENT_TIMESTAMP,8000);


SELECT * FROM Employee
SELECT * FROM Membership
SELECT * FROM VehicleType
SELECT * FROM HourlyRates
SELECT * FROM Member
SELECT * FROM Vehicle
SELECT * FROM ParkingData


 --DROP TABLE ParkingData
 --DROP TABLE Vehicle
 --DROP TABLE Member
 --DROP TABLE HourlyRates
 --DROP TABLE VehicleType
 --DROP TABLE Membership
 --DROP TABLE Employee