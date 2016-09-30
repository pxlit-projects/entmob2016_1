CREATE TABLE [dbo].[Cargos]
(
	[cargo_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [sensor_id] INT NULL, 
    [weight] FLOAT NULL, 
    [employee_id] INT NULL, 
    [destination_id] INT NULL,
	
	CONSTRAINT [FK_CARGO_SENSOR] FOREIGN KEY ([sensor_id]) REFERENCES [dbo].[Sensors] ([sensor_id]), 
	CONSTRAINT [FK_CARGO_EMPLOYEE] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employees] ([employee_id]),
	CONSTRAINT [FK_CARGO_DESTINATION] FOREIGN KEY ([destination_id]) REFERENCES [dbo].[Destinations] ([destination_id])

);
CREATE TABLE [dbo].[Variables]
(
	[variable_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [description] VARCHAR(300) NOT NULL
    
);
CREATE TABLE [dbo].[Logins]
(
	[login_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [employee_id] INT NOT NULL, 
    [time] DATETIME NOT NULL, 


	CONSTRAINT [FK_LOGIN_EMPLOYEE] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employees] ([employee_id])
);
CREATE TABLE [dbo].[Exceedings_per_cargo]
(
	[exceedings_per_cargo_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [cargo_id] INT NOT NULL, 
    [variable_id] INT NOT NULL, 

	CONSTRAINT [FK_EXCEEDINGS_PER_CARGO_CARGO] FOREIGN KEY ([cargo_id]) REFERENCES [dbo].[Cargos] ([cargo_id]),
	CONSTRAINT [FK_EXCEEDINGS_PER_CARGO_VARIABLE] FOREIGN KEY ([variable_id]) REFERENCES [dbo].[Variables] ([variable_id])
);
CREATE TABLE [dbo].[Comments]
(
	[comment_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [description] VARCHAR(300) NOT NULL, 
    [employee_id] INT NOT NULL, 
    [time] DATETIME NOT NULL, 
    [sensor_id] INT NOT NULL, 
    [cargo_id] INT NOT NULL,

	CONSTRAINT [FK_COMMENT_EMPLOYEE] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employees] ([employee_id]),
	CONSTRAINT [FK_COMMENT_SENSOR] FOREIGN KEY ([sensor_id]) REFERENCES [dbo].[Sensors] ([sensor_id]),
	CONSTRAINT [FK_COMMENT_CARGO] FOREIGN KEY ([cargo_id]) REFERENCES [dbo].[Cargos] ([cargo_id])
);
CREATE TABLE [dbo].[Products]
(
	[product_id] INT NOT NULL PRIMARY KEY, 
    [description] VARCHAR(300) NOT NULL
);
CREATE TABLE [dbo].[Sensors]
(
	[sensor_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [sensor_name] VARCHAR(30) NOT NULL, 
    [employee_id] INT NULL, 
    [employee_start] DATETIME NULL, 
    [employee_stop] DATETIME NULL, 
    [status] SMALLINT NOT NULL, 

	CONSTRAINT [FK_SENSOR_EMPLOYEE] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employees] ([employee_id])
);
CREATE TABLE [dbo].[Employees]
(
	[employee_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [username] VARCHAR(50) NOT NULL, 
    [password] VARCHAR(20) NOT NULL, 
    [salt] VARCHAR(MAX) NOT NULL, 
    [surname] VARCHAR(20) NOT NULL, 
    [name] VARCHAR(20) NOT NULL, 
    [street] VARCHAR(50) NOT NULL, 
    [housenr] INT NOT NULL, 
    [postal_code] VARCHAR(6) NOT NULL, 
    [date_employment] DATETIME NOT NULL, 
    [mobile_phone] INT NOT NULL, 
    [telephone_number] INT NOT NULL, 
    [email] VARCHAR(50) NOT NULL, 
    [sex] CHAR NOT NULL, 
    [status] SMALLINT NOT NULL, 
    [clearance_level] INT NOT NULL, 
    [date_resignation] DATETIME NULL, 

	CONSTRAINT [FK_EMPLOYEE_CITY] FOREIGN KEY ([postal_code]) REFERENCES [dbo].[Cities] ([postal_code])
);
CREATE TABLE [dbo].[Cities]
(
	[postal_code] VARCHAR(6) NOT NULL PRIMARY KEY, 
    [city] VARCHAR(50) NOT NULL,

);
CREATE TABLE [dbo].[Products_Per_cargo]
(
	[product_id] INT NOT NULL, 
    [cargo_id] INT NOT NULL, 
    [amount] INT NOT NULL,


	CONSTRAINT [FK_PRODUCTPERCARGO_PRODUCT] FOREIGN KEY ([product_id]) REFERENCES [dbo].[Products] ([product_id]),
	CONSTRAINT [FK_PRODUCTPERCARGO_CARGO] FOREIGN KEY ([cargo_id]) REFERENCES [dbo].[Cargos] ([cargo_id])
);
CREATE TABLE [dbo].[Contacts]
(
	[contact_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [surname] VARCHAR(26) NOT NULL, 
    [name] VARCHAR(26) NOT NULL, 
    [email] VARCHAR(26) NOT NULL, 
    [mobile_phone] INT NOT NULL
);
CREATE TABLE [dbo].[Stabilisations_per_cargo]
(
	[stabilisations_per_cargo_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [exceedings_per_cargo_id] INT NOT NULL, 
    [time] DATETIME NOT NULL,

	CONSTRAINT [FK_STABILISATIONS_PER_CARGO_EXCEEDINGS_PER_CARGO] FOREIGN KEY ([exceedings_per_cargo_id]) REFERENCES [dbo].[Exceedings_per_cargo] ([exceedings_per_cargo_id])
);




