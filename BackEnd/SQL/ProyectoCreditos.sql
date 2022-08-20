DROP DATABASE proyectoCreditos

--Alternative to Drop

USE master;
GO
ALTER DATABASE proyectoCreditos 
SET SINGLE_USER 
WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE proyectoCreditos;

--Create Start

CREATE DATABASE proyectoCreditos;

USE proyectoCreditos;

--ASPNET Users TABLES

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO

ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO


-- Project Tables

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


CREATE TABLE currencies(
	idCurrencies INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	currencyName VARCHAR(75) NOT NULL,
	currencyISO VARCHAR(5) NOT NULL,
	symbol VARCHAR(5) 
);

CREATE TABLE loansStates(
	loansStatesId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	loansStateName VARCHAR(75) NOT NULL
);

CREATE TABLE loansType(
	idloansType INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	loansTypeName VARCHAR(75) NOT NULL
);

CREATE TABLE loansTypeInterest(
	idloansTypeInterest INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	idloansType INT NOT NULL FOREIGN KEY REFERENCES loansType(idloansType),
	idCurrencies INT NOT NULL FOREIGN KEY REFERENCES currencies(idCurrencies),
	interesRate DECIMAL(9,6) NOT NULL,
	yearTime INT,
);

CREATE TABLE loans(
	idLoan INT IDENTITY(1,1)PRIMARY KEY NOT NULL,
	idcustomers INT NOT NULL FOREIGN KEY REFERENCES customers(idCustomers),
	starDate DATETIME NOT NULL,
	endDate DATETIME ,
	interesRate DECIMAL(9,6) NOT NULL,
	loanAmount MONEY NOT NULL,
	currentAmount MONEY DEFAULT 0,
	monthlyAmount MONEY NOT NULL,
	nextDueDate DATETIME ,
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

CREATE TABLE LOG_LoanHistory(
	idlog INT IDENTITY(1,1)PRIMARY KEY NOT NULL,
	idLoansHistory INT NOT NULL,
	loadId INT NOT NULL,
	paymentAmount MONEY NOT NULL,
	payDate DATETIME NOT NULL,
	paymentType INT NOT NULL,
	typeChange VARCHAR(50) NOT NULL,
	changeDate DATETIME NOT NULL,
);

--Triggers,Store Procedures and

CREATE OR ALTER TRIGGER tr_insert_loadAmount 
ON loansHistories
	INSTEAD OF INSERT 
AS
BEGIN 
	SET NOCOUNT ON
	DECLARE @loadId INT;
	DECLARE @paymentAmount MONEY;
	DECLARE @paymentType INT; 
	DECLARE @newCurrentAmount MONEY;

	SELECT @loadId = INSERTED.loadId from INSERTED
	SELECT @paymentAmount = INSERTED.paymentAmount from INSERTED
	SELECT @paymentType = INSERTED.paymentType from INSERTED
	SELECT @newCurrentAmount = currentAmount FROM loans where idLoan = @loadId

	INSERT INTO loansHistories (loadId,paymentAmount,payDate,paymentType)
	VALUES (@loadId,@paymentAmount,GETDATE(),@paymentType);

	SET @newCurrentAmount = @newCurrentAmount - @paymentAmount;

	UPDATE loans SET currentAmount = @newCurrentAmount WHERE idLoan = @loadId;

END;


CREATE OR ALTER TRIGGER tr_update_loadAmount
ON loansHistories
	INSTEAD OF UPDATE 
AS
BEGIN 
	SET NOCOUNT ON
	DECLARE @idLoansHistory INT;
	DECLARE @loadId INT;
	DECLARE @paymentAmount MONEY;
	DECLARE @paymentType INT; 
	DECLARE @newCurrentAmount MONEY;
	DECLARE @payDate DATETIME;

	DECLARE @oldidLoansHistory INT;
	DECLARE @oldloadId INT;
	DECLARE @oldpaymentAmount MONEY;
	DECLARE @oldpaymentType INT; 
	DECLARE @oldpayDate DATETIME;

	SELECT @idLoansHistory = INSERTED.idLoansHistory from INSERTED
	SELECT @loadId = INSERTED.loadId from INSERTED
	SELECT @paymentAmount = INSERTED.paymentAmount from INSERTED
	SELECT @paymentType = INSERTED.paymentType from INSERTED
	SELECT @payDate = INSERTED.payDate from INSERTED
	SELECT @newCurrentAmount = currentAmount FROM loans where idLoan = @loadId

	SELECT @oldidLoansHistory = DELETED.idLoansHistory from DELETED
	SELECT @oldloadId = DELETED.loadId from DELETED
	SELECT @oldpaymentAmount = DELETED.paymentAmount from DELETED
	SELECT @oldpaymentType = DELETED.paymentType from DELETED
	SELECT @oldpayDate = DELETED.payDate from DELETED

	INSERT INTO LOG_LoanHistory (idLoansHistory,loadId,paymentAmount,payDate,paymentType,typeChange,changeDate)
	VALUES(@oldidLoansHistory,@oldloadId,@oldpaymentAmount,@oldpayDate,@oldpaymentType,'BEFORE UPDATE',GETDATE());

	UPDATE loansHistories SET paymentAmount = @paymentAmount, payDate = @payDate, paymentType = @paymentType WHERE idLoansHistory = @idLoansHistory;

	INSERT INTO LOG_LoanHistory (idLoansHistory,loadId,paymentAmount,payDate,paymentType,typeChange,changeDate)
	VALUES (@oldidLoansHistory,@loadId,@paymentAmount,@payDate,@paymentType,'After Update',GETDATE());

	IF(@oldpaymentAmount = @paymentAmount) SET @newCurrentAmount = @newCurrentAmount - @paymentAmount;
	ELSE IF (@oldpaymentAmount > @paymentAmount) SET @newCurrentAmount = @newCurrentAmount + (@oldpaymentAmount -@paymentAmount) ;
	ELSE IF (@oldpaymentAmount < @paymentAmount) SET @newCurrentAmount = @newCurrentAmount - (@paymentAmount - @oldpaymentAmount) ;

	UPDATE loans SET currentAmount = @newCurrentAmount WHERE idLoan = @loadId;

END;


CREATE OR ALTER TRIGGER tr_delete_loadAmount
ON loansHistories
	INSTEAD OF DELETE 
AS
BEGIN 
	SET NOCOUNT ON

	DECLARE @newCurrentAmount MONEY;
	DECLARE @oldidLoansHistory INT;
	DECLARE @oldloadId INT;
	DECLARE @oldpaymentAmount MONEY;
	DECLARE @oldpaymentType INT; 
	DECLARE @oldpayDate DATETIME;

	
	SELECT @oldidLoansHistory = DELETED.idLoansHistory from DELETED
	SELECT @oldloadId = DELETED.loadId from DELETED
	SELECT @oldpaymentAmount = DELETED.paymentAmount from DELETED
	SELECT @oldpaymentType = DELETED.paymentType from DELETED
	SELECT @oldpayDate = DELETED.payDate from DELETED
	SELECT @newCurrentAmount = currentAmount FROM loans where idLoan = @oldloadId

	INSERT INTO LOG_LoanHistory (idLoansHistory,loadId,paymentAmount,payDate,paymentType,typeChange,changeDate)
	VALUES(@oldidLoansHistory,@oldloadId,@oldpaymentAmount,@oldpayDate,@oldpaymentType,'DELETE',GETDATE());

	DELETE FROM loansHistories WHERE idLoansHistory = @oldidLoansHistory;

	SET @newCurrentAmount = @newCurrentAmount + @oldpaymentAmount;

	UPDATE loans SET currentAmount = @newCurrentAmount WHERE idLoan = @oldloadId;

END;



CREATE OR ALTER PROCEDURE sp_delete_loans_all @idLoan int
AS
BEGIN 
	DECLARE	@return_value BIT;
	DECLARE @actualLoanHistory int;
	DECLARE db_cursor CURSOR FOR SELECT idloansHistory from loansHistories where loadId = @idLoan;
	BEGIN TRY
		IF EXISTS (SELECT * FROM loans WHERE idLoan = @idLoan)
			BEGIN
				BEGIN TRANSACTION
					OPEN db_cursor 
					FETCH NEXT FROM db_cursor INTO @actualLoanHistory
					WHILE @@FETCH_STATUS = 0  
					BEGIN  
						DELETE FROM loansHistories WHERE idloansHistory = @actualLoanHistory;
						FETCH NEXT FROM db_cursor INTO @actualLoanHistory
					END
					CLOSE db_cursor  
					DEALLOCATE db_cursor 
					DELETE FROM LOANS WHERE idLoan = @idLoan;
				COMMIT TRANSACTION;
				SET @return_value = 1;
				SELECT 'Return' = @return_value;
			END;
		ELSE
			BEGIN
				SET @return_value = 0;
				SELECT 'Return' = @return_value;
			END;		
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		CLOSE db_cursor  
		DEALLOCATE db_cursor 
		SET @return_value = 0;
		SELECT 'Return' = @return_value;
	END CATCH;
END;


--Create Entries for this Database

INSERT INTO countries (countryName) 
VALUES ('Costa Rica'),
('Panamá'),
('United States'),
('España ');

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


INSERT INTO currencies(currencyName,currencyISO,symbol)
VALUES ('Colones','CRC','₡'),
('Dollares','USD','$'),
('Euros','EUR ','€');

INSERT INTO loansStates (loansStateName)
VALUES ('Creado'),
('Bajo Validación'),
('Aprobado'),
('Activo'),
('Formalizado'),
('Cancelado'),
('Rechazado'),
('Pago Retrazado');

INSERT INTO loansType(loansTypeName)
VALUES ('Personal Loan'),
('Credito Casa'),
('Credito Vehiculo'),
('Credito Comercial');

INSERT INTO loans (idcustomers,starDate,endDate,interesRate,loanAmount,currentAmount,monthlyAmount,nextDueDate,
bankFees,loansDescription,idloansType,idCurrencies,idLoansState)
VALUES (1,'8/1/2021','8/1/2051',8.00,50000000,50000000,366883,'9/15/2022',1000000,'First-time homebuyer loan',2,1,4),
(4,'3/1/2015','4/1/2023',7.4,12000000,10000000,156005,'9/15/2022',500000,'Purchase of Toyota Rav4 2015 Vehicle',3,1,4),
(3,'5/1/2018','6/1/2030',22.6,5000,3000,102,'9/15/2022',250,'Credit Card Payment',1,2,4);

INSERT INTO paymentType(paymentTypeName)
VALUES ('Pago Mensual'),
('Pago Extraordinario');

INSERT INTO loansHistories(loadId,paymentAmount,payDate,paymentType)
values(2,156005,'7/15/2022',1),
(2,156005,'8/15/2022',1),
(3,102,'7/15/2022',1),
(3,1000,'8/1/2022',2),
(3,102,'8/15/2022',1);

INSERT INTO loansTypeInterest (idloansType,idCurrencies,interesRate,yearTime)
VALUES (1,1,15.3,5),
(1,1,15.3,5),
(1,1,16.43,6),
(1,1,17.56,7),
(1,1,18.69,8),
(1,1,19.82,9),
(1,1,20.95,10);

