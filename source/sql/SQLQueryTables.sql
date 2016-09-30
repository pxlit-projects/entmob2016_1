﻿/*
Deployment script for entmob-database

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "entmob-database"
:setvar DefaultFilePrefix "entmob-database"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Table].[Id] (SqlSimpleColumn) will not be renamed to product_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Table].[Id] (SqlSimpleColumn) will not be renamed to employee_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Cargo].[Id] (SqlSimpleColumn) will not be renamed to cargo_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Cargo].[sensor] (SqlSimpleColumn) will not be renamed to sensor_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Cargo].[werknemer_id] (SqlSimpleColumn) will not be renamed to employee_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Cargo].[bestemming_id] (SqlSimpleColumn) will not be renamed to destination_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[City].[Id] (SqlSimpleColumn) will not be renamed to postal_code';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Sensor].[Id] (SqlSimpleColumn) will not be renamed to sensor_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Product].[Id] (SqlSimpleColumn) will not be renamed to product_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Comment].[Id] (SqlSimpleColumn) will not be renamed to comment_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Exceedings_per_cargo].[Id] (SqlSimpleColumn) will not be renamed to exceedings_per_cargo_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Login].[Id] (SqlSimpleColumn) will not be renamed to login_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Variable].[Id] (SqlSimpleColumn) will not be renamed to variable_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Border_per_product].[Id] (SqlSimpleColumn) will not be renamed to product_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Table].[Id] (SqlSimpleColumn) will not be renamed to destination_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Contact].[Id] (SqlSimpleColumn) will not be renamed to contact_id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Stabilisations_per_cargo].[Id] (SqlSimpleColumn) will not be renamed to stabilisations_per_cargo_id';


GO

IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRANSACTION
GO
PRINT N'Creating [dbo].[Border_per_product]...';


GO
CREATE TABLE [dbo].[Borders_per_product] (
    [product_id]   INT        NOT NULL,
    [variable_id]  INT        NOT NULL,
    [border_value] FLOAT (53) NOT NULL
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Cargo]...';


GO
CREATE TABLE [dbo].[Cargos] (
    [cargo_id]       INT        IDENTITY (1, 1) NOT NULL,
    [sensor_id]      INT        NULL,
    [weight]         FLOAT (53) NULL,
    [employee_id]    INT        NULL,
    [destination_id] INT        NULL,
    PRIMARY KEY CLUSTERED ([cargo_id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[City]...';


GO
CREATE TABLE [dbo].[Cities] (
    [postal_code] VARCHAR (6)  NOT NULL,
    [city]        VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([postal_code] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Comment]...';


GO
CREATE TABLE [dbo].[Comments] (
    [comment_id]  INT           IDENTITY (1, 1) NOT NULL,
    [description] VARCHAR (300) NOT NULL,
    [employee_id] INT           NOT NULL,
    [time]        DATETIME      NOT NULL,
    [sensor_id]   INT           NOT NULL,
    [cargo_id]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([comment_id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Contact]...';


GO
CREATE TABLE [dbo].[Contacts] (
    [contact_id]   INT          IDENTITY (1, 1) NOT NULL,
    [surname]      VARCHAR (26) NOT NULL,
    [name]         VARCHAR (26) NOT NULL,
    [email]        VARCHAR (26) NOT NULL,
    [mobile_phone] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([contact_id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Destination]...';


GO
CREATE TABLE [dbo].[Destinations] (
    [destination_id] INT           IDENTITY (1, 1) NOT NULL,
    [description]    VARCHAR (300) NOT NULL,
    [postal_code]    VARCHAR (6)   NOT NULL,
    [street]         VARCHAR (30)  NOT NULL,
    [housenr]        INT           NOT NULL,
    [contact_id]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([destination_id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Employee]...';


GO
CREATE TABLE [dbo].[Employees] (
    [employee_id]      INT           IDENTITY (1, 1) NOT NULL,
    [username]         VARCHAR (50)  NOT NULL,
    [password]         VARCHAR (20)  NOT NULL,
    [salt]             VARCHAR (MAX) NOT NULL,
    [surname]          VARCHAR (20)  NOT NULL,
    [name]             VARCHAR (20)  NOT NULL,
    [street]           VARCHAR (50)  NOT NULL,
    [housenr]          INT           NOT NULL,
    [postal_code]      VARCHAR (6)   NOT NULL,
    [date_employment]  DATETIME      NOT NULL,
    [mobile_phone]     INT           NOT NULL,
    [telephone_number] INT           NOT NULL,
    [email]            VARCHAR (50)  NOT NULL,
    [sex]              CHAR (1)      NOT NULL,
    [status]           SMALLINT      NOT NULL,
    [clearance_level]  INT           NOT NULL,
    [date_resignation] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([employee_id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Exceedings_per_cargo]...';


GO
CREATE TABLE [dbo].[Exceedings_per_cargo] (
    [exceedings_per_cargo_id] INT IDENTITY (1, 1) NOT NULL,
    [cargo_id]                INT NOT NULL,
    [variable_id]             INT NOT NULL,
    PRIMARY KEY CLUSTERED ([exceedings_per_cargo_id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Login]...';


GO
CREATE TABLE [dbo].[Logins] (
    [login_id]    INT      IDENTITY (1, 1) NOT NULL,
    [employee_id] INT      NOT NULL,
    [time]        DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([login_id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Product]...';


GO
CREATE TABLE [dbo].[Products] (
    [product_id]  INT           NOT NULL,
    [description] VARCHAR (300) NOT NULL,
    PRIMARY KEY CLUSTERED ([product_id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Product_Per_cargo]...';


GO
CREATE TABLE [dbo].[Products_Per_cargo] (
    [product_id] INT NOT NULL,
    [cargo_id]   INT NOT NULL,
    [amount]     INT NOT NULL
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Sensor]...';


GO
CREATE TABLE [dbo].[Sensors] (
    [sensor_id]      INT          IDENTITY (1, 1) NOT NULL,
    [sensor_name]    VARCHAR (30) NOT NULL,
    [employee_id]    INT          NULL,
    [employee_start] DATETIME     NULL,
    [employee_stop]  DATETIME     NULL,
    [status]         SMALLINT     NOT NULL,
    PRIMARY KEY CLUSTERED ([sensor_id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Stabilisations_per_cargo]...';


GO
CREATE TABLE [dbo].[Stabilisations_per_cargo] (
    [stabilisations_per_cargo_id] INT      IDENTITY (1, 1) NOT NULL,
    [exceedings_per_cargo_id]     INT      NOT NULL,
    [time]                        DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([stabilisations_per_cargo_id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Variable]...';


GO
CREATE TABLE [dbo].[Variables] (
    [variable_id] INT           IDENTITY (1, 1) NOT NULL,
    [description] VARCHAR (300) NOT NULL,
    [value]       FLOAT (53)    NULL,
    [time]        DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([variable_id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_BORDER_PER_PRODUCT_PRODUCT]...';


GO
ALTER TABLE [dbo].[Borders_per_product] WITH NOCHECK
    ADD CONSTRAINT [FK_BORDER_PER_PRODUCT_PRODUCT] FOREIGN KEY ([product_id]) REFERENCES [dbo].[Products] ([product_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_BORDER_PER_PRODUCT_VARIABLE]...';


GO
ALTER TABLE [dbo].[Border_per_product] WITH NOCHECK
    ADD CONSTRAINT [FK_BORDER_PER_PRODUCT_VARIABLE] FOREIGN KEY ([variable_id]) REFERENCES [dbo].[Variables] ([variable_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_CARGO_SENSOR]...';


GO
ALTER TABLE [dbo].[Cargo] WITH NOCHECK
    ADD CONSTRAINT [FK_CARGO_SENSOR] FOREIGN KEY ([sensor_id]) REFERENCES [dbo].[Sensors] ([sensor_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_CARGO_EMPLOYEE]...';


GO
ALTER TABLE [dbo].[Cargo] WITH NOCHECK
    ADD CONSTRAINT [FK_CARGO_EMPLOYEE] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employees] ([employee_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_CARGO_DESTINATION]...';


GO
ALTER TABLE [dbo].[Cargo] WITH NOCHECK
    ADD CONSTRAINT [FK_CARGO_DESTINATION] FOREIGN KEY ([destination_id]) REFERENCES [dbo].[Destinations] ([destination_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_COMMENT_EMPLOYEE]...';


GO
ALTER TABLE [dbo].[Comment] WITH NOCHECK
    ADD CONSTRAINT [FK_COMMENT_EMPLOYEE] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employees] ([employee_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_COMMENT_SENSOR]...';


GO
ALTER TABLE [dbo].[Comment] WITH NOCHECK
    ADD CONSTRAINT [FK_COMMENT_SENSOR] FOREIGN KEY ([sensor_id]) REFERENCES [dbo].[Sensors] ([sensor_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_COMMENT_CARGO]...';


GO
ALTER TABLE [dbo].[Comment] WITH NOCHECK
    ADD CONSTRAINT [FK_COMMENT_CARGO] FOREIGN KEY ([cargo_id]) REFERENCES [dbo].[Cargos] ([cargo_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_DESTINATION_CITY]...';


GO
ALTER TABLE [dbo].[Destination] WITH NOCHECK
    ADD CONSTRAINT [FK_DESTINATION_CITY] FOREIGN KEY ([postal_code]) REFERENCES [dbo].[Cities] ([postal_code]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_DESTINATION_CONTACT]...';


GO
ALTER TABLE [dbo].[Destination] WITH NOCHECK
    ADD CONSTRAINT [FK_DESTINATION_CONTACT] FOREIGN KEY ([contact_id]) REFERENCES [dbo].[Contact] ([contact_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_EMPLOYEE_CITY]...';


GO
ALTER TABLE [dbo].[Employee] WITH NOCHECK
    ADD CONSTRAINT [FK_EMPLOYEE_CITY] FOREIGN KEY ([postal_code]) REFERENCES [dbo].[City] ([postal_code]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_EXCEEDINGS_PER_CARGO_CARGO]...';


GO
ALTER TABLE [dbo].[Exceedings_per_cargo] WITH NOCHECK
    ADD CONSTRAINT [FK_EXCEEDINGS_PER_CARGO_CARGO] FOREIGN KEY ([cargo_id]) REFERENCES [dbo].[Cargos] ([cargo_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_EXCEEDINGS_PER_CARGO_VARIABLE]...';


GO
ALTER TABLE [dbo].[Exceedings_per_cargo] WITH NOCHECK
    ADD CONSTRAINT [FK_EXCEEDINGS_PER_CARGO_VARIABLE] FOREIGN KEY ([variable_id]) REFERENCES [dbo].[Cargos] ([cargo_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_LOGIN_EMPLOYEE]...';


GO
ALTER TABLE [dbo].[Login] WITH NOCHECK
    ADD CONSTRAINT [FK_LOGIN_EMPLOYEE] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employees] ([employee_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_PRODUCTPERCARGO_PRODUCT]...';


GO
ALTER TABLE [dbo].[Product_Per_cargo] WITH NOCHECK
    ADD CONSTRAINT [FK_PRODUCTPERCARGO_PRODUCT] FOREIGN KEY ([product_id]) REFERENCES [dbo].[Products] ([product_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_PRODUCTPERCARGO_CARGO]...';


GO
ALTER TABLE [dbo].[Product_Per_cargo] WITH NOCHECK
    ADD CONSTRAINT [FK_PRODUCTPERCARGO_CARGO] FOREIGN KEY ([cargo_id]) REFERENCES [dbo].[Cargos] ([cargo_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_SENSOR_EMPLOYEE]...';


GO
ALTER TABLE [dbo].[Sensor] WITH NOCHECK
    ADD CONSTRAINT [FK_SENSOR_EMPLOYEE] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employees] ([employee_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_STABILISATIONS_PER_CARGO_EXCEEDINGS_PER_CARGO]...';


GO
ALTER TABLE [dbo].[Stabilisations_per_cargo] WITH NOCHECK
    ADD CONSTRAINT [FK_STABILISATIONS_PER_CARGO_EXCEEDINGS_PER_CARGO] FOREIGN KEY ([exceedings_per_cargo_id]) REFERENCES [dbo].[Exceedings_per_cargo] ([exceedings_per_cargo_id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT N'The transacted portion of the database update succeeded.'
COMMIT TRANSACTION
END
ELSE PRINT N'The transacted portion of the database update failed.'
GO
DROP TABLE #tmpErrors
GO
