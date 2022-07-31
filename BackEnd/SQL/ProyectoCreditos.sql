DROP DATABASE proyectoCreditos

CREATE DATABASE proyectoCreditos;

USE proyectoCreditos;

CREATE TABLE countries(
	idCountry INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	countryName VARCHAR(50)  NOT NULL ,
);

CREATE TABLE states(
	idState INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	stateName VARCHAR(50)  NOT NULL ,
	idCountry INT NOT NULL FOREIGN KEY REFERENCES countries(idCountry),
);

CREATE TABLE customers(
	idCustomers INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	firstName VARCHAR(150) NOT NULL,
	lastName VARCHAR(150) NOT NULL,
	documentId VARCHAR(75) UNIQUE NOT NULL,
	email VARCHAR(75) NOT NULL,
	telephone VARCHAR(25) NOT NULL,
	birthDate DATETIME NULL,
	userAddress VARCHAR(250),	
	idState INT NOT NULL FOREIGN KEY REFERENCES states(idState),     
);

CREATE TABLE userRoles(
	idUserRole INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	roleName VARCHAR(25)  NOT NULL ,
);

CREATE TABLE users(
	idUser INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	userName VARCHAR(50)  NOT NULL ,
	userPassword VARCHAR(500) NOT NULL ,
	userRole INT NOT NULL FOREIGN KEY REFERENCES userRoles(idUserRole),
	idCustomers INT NOT NULL FOREIGN KEY REFERENCES customers(idCustomers),
);

CREATE TABLE currencies(
	idCurrencies INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	currencyName VARCHAR(75) NOT NULL,
	currencyISO VARCHAR(5) NOT NULL
);

CREATE TABLE loansStates(
	loansStatesId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	loansStateName VARCHAR(75) NOT NULL
);

CREATE TABLE loansType(
	idloansType INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	loansTypeName VARCHAR(75) NOT NULL
);

CREATE TABLE loans(
	idLoan INT IDENTITY(1,1)PRIMARY KEY NOT NULL,
	idcustomers INT NOT NULL FOREIGN KEY REFERENCES customers(idCustomers),
	starDate DATETIME NOT NULL,
	endDate DATETIME NOT NULL,
	interesRate DECIMAL(9,6) NOT NULL,
	loanAmount MONEY NOT NULL,
	currentAmount MONEY DEFAULT 0,
	monthlyAmount MONEY NOT NULL,
	nextDueDate DATETIME NOT NULL,
	bankFees MONEY NOT NULL,
	loansDescription VARCHAR(250),
	idloansType INT NOT NULL FOREIGN KEY REFERENCES loansType(idloansType),
	idCurrencies INT NOT NULL FOREIGN KEY REFERENCES currencies(idCurrencies),
	idLoansState INT NOT NULL FOREIGN KEY REFERENCES LoansStates(loansStatesId),
);

CREATE TABLE paymentType(
	idPaymentType INT IDENTITY(1,1)PRIMARY KEY NOT NULL,
	paymentTypeName VARCHAR(75) NOT NULL
);

CREATE TABLE loansHistories(
	idLoansHistory INT IDENTITY(1,1)PRIMARY KEY NOT NULL,
	loadId INT NOT NULL FOREIGN KEY REFERENCES loans(idLoan),
	paymentAmount MONEY NOT NULL,
	payDate DATETIME NOT NULL,
	paymentType INT NOT NULL FOREIGN KEY REFERENCES paymentType(idPaymentType),
);

--Triggers,Store Procedures and


--Create Entries for this Database

INSERT INTO countries (countryName) 
VALUES ('Costa Rica'),
('Panamá'),
('United States'),
('Spain ');

INSERT INTO states (stateName,idCountry)
VALUES ('San Jose',1),
('Alajuela',1),
('Heredia',1),
('Cartago',1),
('Guacanacaste',1),
('Puntarenas',1),
('Limon',1),
('Panamá',2),
('Chiriquí',2),
('Bocas del Toro',2),
('California',3),
('Texas',3),
('Florida',3),
('Washington',3),
('New York',3),
('Barcelona',4),
('Madrid',4),
('Valencia',4),
('Sevillla',4);

INSERT INTO customers (firstName,lastName,documentId,email,telephone,birthDate,userAddress,idState)
VALUES ('Wilmar','Arlett','352959179','warlett0@amazon.co.uk','82899837 ','8/2/2001','Praza Sandoval,200 E. and 100 S.',4),
('Mario Villagómez','Leiva Blázquez','ES756872822','valeria.caban@yahoo.es','204 244 4122','3/22/1993','Rúa Aitana',17),
('Scottie ','Minocchi','902588915','sminocchib@google.ca','(806)888-9723','4/10/1971','6903 Cassin Crescent',14),
('Isabel','Briseño Hijo','174898275','ualvarez@info.cr','85608182','09/21/1999','Avenida Benavídez',1);

INSERT INTO userRoles (roleName)
VALUES ('Administrator'),
('Employee'),
('User');

INSERT INTO users(userName,userPassword,userRole,idCustomers)
VALUES ('Admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918',1,null);

INSERT INTO currencies(currencyName,currencyISO)
VALUES ('Colon','CRC'),
('Dollar','USD'),
('Euro','EUR ');

INSERT INTO loansStates (loansStateName)
VALUES ('Created'),
('Under Validation'),
('Approved'),
('Active'),
('Formalization'),
('Canceled'),
('Rejected'),
('Delayed Payment');

INSERT INTO loansType(loansTypeName)
VALUES ('Personal Loan'),
('Home Loan'),
('Vehicle loan'),
('Commercial loans');

INSERT INTO loans (idcustomers,starDate,endDate,interesRate,loanAmount,currentAmount,monthlyAmount,nextDueDate,
bankFees,loansDescription,idloansType,idCurrencies,idLoansState)
VALUES (1,'8/1/2021','8/1/2051',8.00,50000000,50000000,366883,'9/15/2022',1000000,'First-time homebuyer loan',2,1,4),
(4,'3/1/2015','4/1/2023',7.4,12000000,10000000,156005,'9/15/2022',500000,'Purchase of Toyota Rav4 2015 Vehicle',3,1,4),
(3,'5/1/2018','6/1/2030',22.6,5000,3000,102,'9/15/2022',250,'Credit Card Payment',1,2,4);

INSERT INTO paymentType(paymentTypeName)
VALUES ('Monthly Payment'),
('Extraordinary Payment');

INSERT INTO loansHistories(loadId,paymentAmount,payDate,paymentType)
values(2,156005,'7/15/2022',1),
(2,156005,'8/15/2022',1),
(3,102,'7/15/2022',1),
(3,1000,'8/1/2022',2),
(3,102,'8/15/2022',1);
