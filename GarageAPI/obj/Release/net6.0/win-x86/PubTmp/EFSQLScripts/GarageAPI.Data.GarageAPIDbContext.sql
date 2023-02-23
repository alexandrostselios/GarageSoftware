IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE TABLE [CarManufacturer] (
        [ID] bigint NOT NULL IDENTITY,
        [ManufacturerName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_CarManufacturer] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE TABLE [CarModels] (
        [ID] bigint NOT NULL IDENTITY,
        [ModelName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_CarModels] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE TABLE [CarModelYear] (
        [ID] bigint NOT NULL IDENTITY,
        [Description] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_CarModelYear] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE TABLE [EngineerSpeciality] (
        [ID] bigint NOT NULL IDENTITY,
        [Speciality] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_EngineerSpeciality] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE TABLE [Output] (
        [id] bigint NOT NULL IDENTITY,
        [UserID] bigint NOT NULL,
        [LicencePlate] nvarchar(max) NOT NULL,
        [VIN] nvarchar(max) NOT NULL,
        [Color] bigint NOT NULL,
        [Kilometer] bigint NOT NULL,
        [ModelName] nvarchar(max) NOT NULL,
        [ManufacturerName] nvarchar(max) NOT NULL,
        [ModelYear] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Output] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE TABLE [ServiceHistoryDTO] (
        [Description] nvarchar(max) NOT NULL,
        [ServiceDate] datetime NULL,
        [ServiceKilometer] bigint NOT NULL,
        [StartPrice] real NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Surname] nvarchar(max) NOT NULL,
        [LicencePlate] nvarchar(max) NOT NULL,
        [VIN] nvarchar(max) NOT NULL,
        [Color] bigint NOT NULL,
        [ModelName] nvarchar(max) NOT NULL,
        [ManufacturerName] nvarchar(max) NOT NULL,
        [ModelYear] nvarchar(max) NOT NULL
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE TABLE [Users] (
        [ID] bigint NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Surname] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [GarageID] bigint NOT NULL,
        [UserType] int NOT NULL,
        [Speciality] bigint NULL,
        [CreationDate] datetime NULL,
        [ModifiedDate] datetime NULL,
        [LastLoginDate] datetime NULL,
        [EnableAccess] int NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE TABLE [CarModelManufacturerYear] (
        [ID] bigint NOT NULL IDENTITY,
        [CarManufacturerID] bigint NOT NULL,
        [CarModelID] bigint NOT NULL,
        [CarModelYearID] bigint NOT NULL,
        CONSTRAINT [PK_CarModelManufacturerYear] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_CarModelManufacturerYear_CarManufacturer_CarManufacturerID] FOREIGN KEY ([CarManufacturerID]) REFERENCES [CarManufacturer] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_CarModelManufacturerYear_CarModelYear_CarModelYearID] FOREIGN KEY ([CarModelYearID]) REFERENCES [CarModelYear] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_CarModelManufacturerYear_CarModels_CarModelID] FOREIGN KEY ([CarModelID]) REFERENCES [CarModels] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE TABLE [UserModels] (
        [ID] bigint NOT NULL IDENTITY,
        [UserID] bigint NOT NULL,
        [ModelManufacturerYearID] bigint NOT NULL,
        [ModelYearID] bigint NOT NULL,
        [LicencePlate] nvarchar(max) NULL,
        [VIN] nvarchar(max) NULL,
        [Color] bigint NULL,
        [Kilometer] bigint NULL,
        CONSTRAINT [PK_UserModels] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_UserModels_CarModelManufacturerYear_ModelManufacturerYearID] FOREIGN KEY ([ModelManufacturerYearID]) REFERENCES [CarModelManufacturerYear] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserModels_CarModelYear_ModelYearID] FOREIGN KEY ([ModelYearID]) REFERENCES [CarModelYear] ([ID]),
        CONSTRAINT [FK_UserModels_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [Users] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE TABLE [ServiceHistory] (
        [ID] bigint NOT NULL IDENTITY,
        [UserModelsID] bigint NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [ServiceDate] datetime NULL,
        [ServiceKilometer] bigint NOT NULL,
        [EngineerID] bigint NOT NULL,
        [StartPrice] real NOT NULL,
        [DiscountPrice] real NULL,
        [DiscountPercentage] real NULL,
        [FinalPrice] real NOT NULL,
        [StartingTime] datetime NULL,
        [StartingDate] datetime NULL,
        [FinishingTime] datetime NULL,
        [FinishingDate] datetime NULL,
        CONSTRAINT [PK_ServiceHistory] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_ServiceHistory_UserModels_UserModelsID] FOREIGN KEY ([UserModelsID]) REFERENCES [UserModels] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_ServiceHistory_Users_EngineerID] FOREIGN KEY ([EngineerID]) REFERENCES [Users] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'ManufacturerName') AND [object_id] = OBJECT_ID(N'[CarManufacturer]'))
        SET IDENTITY_INSERT [CarManufacturer] ON;
    EXEC(N'INSERT INTO [CarManufacturer] ([ID], [ManufacturerName])
    VALUES (CAST(1 AS bigint), N''Abarth''),
    (CAST(2 AS bigint), N''Alfa Romeo''),
    (CAST(3 AS bigint), N''Aston Martin''),
    (CAST(4 AS bigint), N''Audi''),
    (CAST(5 AS bigint), N''Bentley''),
    (CAST(6 AS bigint), N''BMW''),
    (CAST(7 AS bigint), N''Bugatti''),
    (CAST(8 AS bigint), N''Cadillac''),
    (CAST(9 AS bigint), N''Chevrolet''),
    (CAST(10 AS bigint), N''Chrysler''),
    (CAST(11 AS bigint), N''Citroën''),
    (CAST(12 AS bigint), N''Dacia''),
    (CAST(13 AS bigint), N''Daewoo''),
    (CAST(14 AS bigint), N''Daihatsu''),
    (CAST(15 AS bigint), N''Dodge''),
    (CAST(16 AS bigint), N''Donkervoort''),
    (CAST(17 AS bigint), N''DS''),
    (CAST(18 AS bigint), N''Ferrari''),
    (CAST(19 AS bigint), N''Fiat''),
    (CAST(20 AS bigint), N''Fisker''),
    (CAST(21 AS bigint), N''Ford''),
    (CAST(22 AS bigint), N''Honda''),
    (CAST(23 AS bigint), N''Hummer''),
    (CAST(24 AS bigint), N''Hyundai''),
    (CAST(25 AS bigint), N''Infiniti''),
    (CAST(26 AS bigint), N''Iveco''),
    (CAST(27 AS bigint), N''Jaguar''),
    (CAST(28 AS bigint), N''Jeep''),
    (CAST(29 AS bigint), N''Kia''),
    (CAST(30 AS bigint), N''KTM''),
    (CAST(31 AS bigint), N''Lada''),
    (CAST(32 AS bigint), N''Lamborghini''),
    (CAST(33 AS bigint), N''Lancia''),
    (CAST(34 AS bigint), N''Land Rover''),
    (CAST(35 AS bigint), N''Landwind''),
    (CAST(36 AS bigint), N''Lexus''),
    (CAST(37 AS bigint), N''Lotus''),
    (CAST(38 AS bigint), N''Maserati''),
    (CAST(39 AS bigint), N''Maybach''),
    (CAST(40 AS bigint), N''Mazda''),
    (CAST(41 AS bigint), N''McLaren''),
    (CAST(42 AS bigint), N''Mercedes-Benz'');
    INSERT INTO [CarManufacturer] ([ID], [ManufacturerName])
    VALUES (CAST(43 AS bigint), N''MG''),
    (CAST(44 AS bigint), N''Mini''),
    (CAST(45 AS bigint), N''Mitsubishi''),
    (CAST(46 AS bigint), N''Morgan''),
    (CAST(47 AS bigint), N''Nissan''),
    (CAST(48 AS bigint), N''Opel''),
    (CAST(49 AS bigint), N''Peugeot''),
    (CAST(50 AS bigint), N''Porsche''),
    (CAST(51 AS bigint), N''Renault''),
    (CAST(52 AS bigint), N''Rolls-Royce''),
    (CAST(53 AS bigint), N''Rover''),
    (CAST(54 AS bigint), N''Saab''),
    (CAST(55 AS bigint), N''Seat''),
    (CAST(56 AS bigint), N''Skoda''),
    (CAST(57 AS bigint), N''Smart''),
    (CAST(58 AS bigint), N''SsangYong''),
    (CAST(59 AS bigint), N''Subaru''),
    (CAST(60 AS bigint), N''Suzuki''),
    (CAST(61 AS bigint), N''Tesla''),
    (CAST(62 AS bigint), N''Toyota''),
    (CAST(63 AS bigint), N''Volkswagen''),
    (CAST(64 AS bigint), N''Volvo'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'ManufacturerName') AND [object_id] = OBJECT_ID(N'[CarManufacturer]'))
        SET IDENTITY_INSERT [CarManufacturer] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Description') AND [object_id] = OBJECT_ID(N'[CarModelYear]'))
        SET IDENTITY_INSERT [CarModelYear] ON;
    EXEC(N'INSERT INTO [CarModelYear] ([ID], [Description])
    VALUES (CAST(1 AS bigint), N''1950''),
    (CAST(2 AS bigint), N''1951''),
    (CAST(3 AS bigint), N''1952''),
    (CAST(4 AS bigint), N''1953''),
    (CAST(5 AS bigint), N''1954''),
    (CAST(6 AS bigint), N''1955''),
    (CAST(7 AS bigint), N''1956''),
    (CAST(8 AS bigint), N''1957''),
    (CAST(9 AS bigint), N''1958''),
    (CAST(10 AS bigint), N''1959''),
    (CAST(11 AS bigint), N''1960''),
    (CAST(12 AS bigint), N''1961''),
    (CAST(13 AS bigint), N''1962''),
    (CAST(14 AS bigint), N''1963''),
    (CAST(15 AS bigint), N''1964''),
    (CAST(16 AS bigint), N''1965''),
    (CAST(17 AS bigint), N''1966''),
    (CAST(18 AS bigint), N''1967''),
    (CAST(19 AS bigint), N''1968''),
    (CAST(20 AS bigint), N''1969''),
    (CAST(21 AS bigint), N''1970''),
    (CAST(22 AS bigint), N''1971''),
    (CAST(23 AS bigint), N''1972''),
    (CAST(24 AS bigint), N''1973''),
    (CAST(25 AS bigint), N''1974''),
    (CAST(26 AS bigint), N''1975''),
    (CAST(27 AS bigint), N''1976''),
    (CAST(28 AS bigint), N''1977''),
    (CAST(29 AS bigint), N''1978''),
    (CAST(30 AS bigint), N''1979''),
    (CAST(31 AS bigint), N''1980''),
    (CAST(32 AS bigint), N''1981''),
    (CAST(33 AS bigint), N''1982''),
    (CAST(34 AS bigint), N''1983''),
    (CAST(35 AS bigint), N''1984''),
    (CAST(36 AS bigint), N''1985''),
    (CAST(37 AS bigint), N''1986''),
    (CAST(38 AS bigint), N''1987''),
    (CAST(39 AS bigint), N''1988''),
    (CAST(40 AS bigint), N''1989''),
    (CAST(41 AS bigint), N''1990''),
    (CAST(42 AS bigint), N''1991'');
    INSERT INTO [CarModelYear] ([ID], [Description])
    VALUES (CAST(43 AS bigint), N''1992''),
    (CAST(44 AS bigint), N''1993''),
    (CAST(45 AS bigint), N''1994''),
    (CAST(46 AS bigint), N''1995''),
    (CAST(47 AS bigint), N''1996''),
    (CAST(48 AS bigint), N''1997''),
    (CAST(49 AS bigint), N''1998''),
    (CAST(50 AS bigint), N''1999''),
    (CAST(51 AS bigint), N''2000''),
    (CAST(52 AS bigint), N''2001''),
    (CAST(53 AS bigint), N''2002''),
    (CAST(54 AS bigint), N''2003''),
    (CAST(55 AS bigint), N''2004''),
    (CAST(56 AS bigint), N''2005''),
    (CAST(57 AS bigint), N''2006''),
    (CAST(58 AS bigint), N''2007''),
    (CAST(59 AS bigint), N''2008''),
    (CAST(60 AS bigint), N''2009''),
    (CAST(61 AS bigint), N''2010''),
    (CAST(62 AS bigint), N''2011''),
    (CAST(63 AS bigint), N''2012''),
    (CAST(64 AS bigint), N''2013''),
    (CAST(65 AS bigint), N''2014''),
    (CAST(66 AS bigint), N''2015''),
    (CAST(67 AS bigint), N''2016''),
    (CAST(68 AS bigint), N''2017''),
    (CAST(69 AS bigint), N''2018''),
    (CAST(70 AS bigint), N''2019''),
    (CAST(71 AS bigint), N''2020''),
    (CAST(72 AS bigint), N''2021''),
    (CAST(73 AS bigint), N''2022''),
    (CAST(74 AS bigint), N''2023'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Description') AND [object_id] = OBJECT_ID(N'[CarModelYear]'))
        SET IDENTITY_INSERT [CarModelYear] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'ModelName') AND [object_id] = OBJECT_ID(N'[CarModels]'))
        SET IDENTITY_INSERT [CarModels] ON;
    EXEC(N'INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(1 AS bigint), N''Accent''),
    (CAST(2 AS bigint), N''Atos''),
    (CAST(3 AS bigint), N''Prime''),
    (CAST(4 AS bigint), N''Coupe''),
    (CAST(5 AS bigint), N''Elantra''),
    (CAST(6 AS bigint), N''Galloper''),
    (CAST(7 AS bigint), N''Genesis''),
    (CAST(8 AS bigint), N''Getz''),
    (CAST(9 AS bigint), N''Grandeur''),
    (CAST(10 AS bigint), N''H350''),
    (CAST(11 AS bigint), N''H1''),
    (CAST(12 AS bigint), N''H1Bus''),
    (CAST(13 AS bigint), N''H1Van''),
    (CAST(14 AS bigint), N''H200''),
    (CAST(15 AS bigint), N''i10''),
    (CAST(16 AS bigint), N''i20''),
    (CAST(17 AS bigint), N''i30''),
    (CAST(18 AS bigint), N''i30 CW''),
    (CAST(19 AS bigint), N''i40''),
    (CAST(20 AS bigint), N''i40 CW''),
    (CAST(21 AS bigint), N''ix20''),
    (CAST(22 AS bigint), N''ix35''),
    (CAST(23 AS bigint), N''ix55''),
    (CAST(24 AS bigint), N''Lantra''),
    (CAST(25 AS bigint), N''Matrix''),
    (CAST(26 AS bigint), N''SantaFe''),
    (CAST(27 AS bigint), N''Sonata''),
    (CAST(28 AS bigint), N''Terracan''),
    (CAST(29 AS bigint), N''Trajet''),
    (CAST(30 AS bigint), N''Tucson''),
    (CAST(31 AS bigint), N''Veloster''),
    (CAST(32 AS bigint), N''Kona''),
    (CAST(33 AS bigint), N''Bayon''),
    (CAST(34 AS bigint), N''145''),
    (CAST(35 AS bigint), N''146''),
    (CAST(36 AS bigint), N''147''),
    (CAST(37 AS bigint), N''155''),
    (CAST(38 AS bigint), N''156''),
    (CAST(39 AS bigint), N''156 Sportwagon''),
    (CAST(40 AS bigint), N''159''),
    (CAST(41 AS bigint), N''159 Sportwagon''),
    (CAST(42 AS bigint), N''164'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(43 AS bigint), N''166''),
    (CAST(44 AS bigint), N''4C''),
    (CAST(45 AS bigint), N''Brera''),
    (CAST(46 AS bigint), N''GTV''),
    (CAST(47 AS bigint), N''Mito''),
    (CAST(48 AS bigint), N''Crosswagon''),
    (CAST(49 AS bigint), N''Spider''),
    (CAST(50 AS bigint), N''GT''),
    (CAST(51 AS bigint), N''Giulietta''),
    (CAST(52 AS bigint), N''Giulia''),
    (CAST(53 AS bigint), N''4-Runner''),
    (CAST(54 AS bigint), N''Auris''),
    (CAST(55 AS bigint), N''Avensis''),
    (CAST(56 AS bigint), N''Avensis Combi''),
    (CAST(57 AS bigint), N''Avensis Van Verso''),
    (CAST(58 AS bigint), N''Aygo''),
    (CAST(59 AS bigint), N''Camry''),
    (CAST(60 AS bigint), N''Carina''),
    (CAST(61 AS bigint), N''Celica''),
    (CAST(62 AS bigint), N''Corolla''),
    (CAST(63 AS bigint), N''Corolla Combi''),
    (CAST(64 AS bigint), N''Corolla sedan''),
    (CAST(65 AS bigint), N''Corolla Verso''),
    (CAST(66 AS bigint), N''FJ Cruiser''),
    (CAST(67 AS bigint), N''GT86''),
    (CAST(68 AS bigint), N''Hiace''),
    (CAST(69 AS bigint), N''Hiace Van''),
    (CAST(70 AS bigint), N''Highlander''),
    (CAST(71 AS bigint), N''Hilux''),
    (CAST(72 AS bigint), N''Land Cruiser''),
    (CAST(73 AS bigint), N''MR2''),
    (CAST(74 AS bigint), N''Paseo''),
    (CAST(75 AS bigint), N''Picnic''),
    (CAST(76 AS bigint), N''Prius''),
    (CAST(77 AS bigint), N''RAV4''),
    (CAST(78 AS bigint), N''Sequoia''),
    (CAST(79 AS bigint), N''Starlet''),
    (CAST(80 AS bigint), N''Supra''),
    (CAST(81 AS bigint), N''Tundra''),
    (CAST(82 AS bigint), N''Urban Cruiser''),
    (CAST(83 AS bigint), N''Verso''),
    (CAST(84 AS bigint), N''Yaris'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(85 AS bigint), N''Yaris Verso''),
    (CAST(86 AS bigint), N''Alhambra,''),
    (CAST(87 AS bigint), N''Altea''),
    (CAST(88 AS bigint), N''Altea XL''),
    (CAST(89 AS bigint), N''Arosa''),
    (CAST(90 AS bigint), N''Cordoba''),
    (CAST(91 AS bigint), N''Cordoba Vario''),
    (CAST(92 AS bigint), N''Exeo''),
    (CAST(93 AS bigint), N''Ibiza,''),
    (CAST(94 AS bigint), N''Ibiza ST''),
    (CAST(95 AS bigint), N''Exeo ST''),
    (CAST(96 AS bigint), N''Leon,''),
    (CAST(97 AS bigint), N''Leon ST''),
    (CAST(98 AS bigint), N''Inca''),
    (CAST(99 AS bigint), N''Mii,''),
    (CAST(100 AS bigint), N''Toledo''),
    (CAST(101 AS bigint), N''Captur''),
    (CAST(102 AS bigint), N''Clio''),
    (CAST(103 AS bigint), N''Clio Grandtour''),
    (CAST(104 AS bigint), N''Espace''),
    (CAST(105 AS bigint), N''Express''),
    (CAST(106 AS bigint), N''Fluence''),
    (CAST(107 AS bigint), N''Grand Espace''),
    (CAST(108 AS bigint), N''Grand Modus''),
    (CAST(109 AS bigint), N''Grand Scenic''),
    (CAST(110 AS bigint), N''Kadjar''),
    (CAST(111 AS bigint), N''Kangoo''),
    (CAST(112 AS bigint), N''Kangoo Express''),
    (CAST(113 AS bigint), N''Koleos''),
    (CAST(114 AS bigint), N''Laguna''),
    (CAST(115 AS bigint), N''Laguna Grandtour''),
    (CAST(116 AS bigint), N''Latitude''),
    (CAST(117 AS bigint), N''Mascott''),
    (CAST(118 AS bigint), N''Mégane''),
    (CAST(119 AS bigint), N''Mégane CC''),
    (CAST(120 AS bigint), N''Mégane Combi''),
    (CAST(121 AS bigint), N''Mégane Grandtour''),
    (CAST(122 AS bigint), N''Mégane Coupé''),
    (CAST(123 AS bigint), N''Mégane Scénic''),
    (CAST(124 AS bigint), N''Scénic''),
    (CAST(125 AS bigint), N''Talisman''),
    (CAST(126 AS bigint), N''Talisman Grandtour'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(127 AS bigint), N''Thalia''),
    (CAST(128 AS bigint), N''Twingo''),
    (CAST(129 AS bigint), N''Wind''),
    (CAST(130 AS bigint), N''Zoé''),
    (CAST(131 AS bigint), N''1007''),
    (CAST(132 AS bigint), N''107''),
    (CAST(133 AS bigint), N''106''),
    (CAST(134 AS bigint), N''108''),
    (CAST(135 AS bigint), N''2008''),
    (CAST(136 AS bigint), N''205''),
    (CAST(137 AS bigint), N''205 Cabrio''),
    (CAST(138 AS bigint), N''206''),
    (CAST(139 AS bigint), N''206 CC''),
    (CAST(140 AS bigint), N''206 SW''),
    (CAST(141 AS bigint), N''207''),
    (CAST(142 AS bigint), N''207 CC''),
    (CAST(143 AS bigint), N''207 SW''),
    (CAST(144 AS bigint), N''306''),
    (CAST(145 AS bigint), N''307''),
    (CAST(146 AS bigint), N''307 CC''),
    (CAST(147 AS bigint), N''307 SW''),
    (CAST(148 AS bigint), N''308''),
    (CAST(149 AS bigint), N''308 CC''),
    (CAST(150 AS bigint), N''308 SW''),
    (CAST(151 AS bigint), N''309''),
    (CAST(152 AS bigint), N''4007''),
    (CAST(153 AS bigint), N''4008''),
    (CAST(154 AS bigint), N''405''),
    (CAST(155 AS bigint), N''406''),
    (CAST(156 AS bigint), N''407''),
    (CAST(157 AS bigint), N''407 SW''),
    (CAST(158 AS bigint), N''5008''),
    (CAST(159 AS bigint), N''508''),
    (CAST(160 AS bigint), N''508 SW''),
    (CAST(161 AS bigint), N''605''),
    (CAST(162 AS bigint), N''806''),
    (CAST(163 AS bigint), N''607''),
    (CAST(164 AS bigint), N''807''),
    (CAST(165 AS bigint), N''Bipper''),
    (CAST(166 AS bigint), N''RCZ Dokker''),
    (CAST(167 AS bigint), N''Duster''),
    (CAST(168 AS bigint), N''Lodgy'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(169 AS bigint), N''Logan''),
    (CAST(170 AS bigint), N''Logan MCV''),
    (CAST(171 AS bigint), N''Logan Van''),
    (CAST(172 AS bigint), N''Sandero''),
    (CAST(173 AS bigint), N''Solenza Berlingo''),
    (CAST(174 AS bigint), N''C-Crosser''),
    (CAST(175 AS bigint), N''C-Elissée''),
    (CAST(176 AS bigint), N''C-Zero''),
    (CAST(177 AS bigint), N''C1''),
    (CAST(178 AS bigint), N''C2''),
    (CAST(179 AS bigint), N''C3''),
    (CAST(180 AS bigint), N''C3 Picasso''),
    (CAST(181 AS bigint), N''C4''),
    (CAST(182 AS bigint), N''C4 Aircross''),
    (CAST(183 AS bigint), N''C4 Cactus''),
    (CAST(184 AS bigint), N''C4 Coupé''),
    (CAST(185 AS bigint), N''C4 Grand Picasso''),
    (CAST(186 AS bigint), N''C4 Sedan''),
    (CAST(187 AS bigint), N''C5''),
    (CAST(188 AS bigint), N''C5 Break''),
    (CAST(189 AS bigint), N''C5 Tourer''),
    (CAST(190 AS bigint), N''C6''),
    (CAST(191 AS bigint), N''C8''),
    (CAST(192 AS bigint), N''DS3''),
    (CAST(193 AS bigint), N''DS4''),
    (CAST(194 AS bigint), N''DS5''),
    (CAST(195 AS bigint), N''Evasion''),
    (CAST(196 AS bigint), N''Jumper''),
    (CAST(197 AS bigint), N''Jumpy''),
    (CAST(198 AS bigint), N''Saxo''),
    (CAST(199 AS bigint), N''Nemo''),
    (CAST(200 AS bigint), N''Xantia''),
    (CAST(201 AS bigint), N''Xsara Agila''),
    (CAST(202 AS bigint), N''Ampera''),
    (CAST(203 AS bigint), N''Antara''),
    (CAST(204 AS bigint), N''Astra''),
    (CAST(205 AS bigint), N''Astra cabrio''),
    (CAST(206 AS bigint), N''Astra caravan''),
    (CAST(207 AS bigint), N''Astra coupé''),
    (CAST(208 AS bigint), N''Calibra''),
    (CAST(209 AS bigint), N''Campo''),
    (CAST(210 AS bigint), N''Cascada'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(211 AS bigint), N''Corsa''),
    (CAST(212 AS bigint), N''Frontera''),
    (CAST(213 AS bigint), N''Insignia''),
    (CAST(214 AS bigint), N''Insignia kombi''),
    (CAST(215 AS bigint), N''Kadett''),
    (CAST(216 AS bigint), N''Meriva''),
    (CAST(217 AS bigint), N''Mokka''),
    (CAST(218 AS bigint), N''Movano''),
    (CAST(219 AS bigint), N''Omega''),
    (CAST(220 AS bigint), N''Signum''),
    (CAST(221 AS bigint), N''Vectra''),
    (CAST(222 AS bigint), N''Vectra Caravan''),
    (CAST(223 AS bigint), N''Vivaro''),
    (CAST(224 AS bigint), N''Vivaro Kombi''),
    (CAST(225 AS bigint), N''Zafira''),
    (CAST(226 AS bigint), N''Favorit''),
    (CAST(227 AS bigint), N''Felicia''),
    (CAST(228 AS bigint), N''Citigo''),
    (CAST(229 AS bigint), N''Fabia''),
    (CAST(230 AS bigint), N''Fabia Combi''),
    (CAST(231 AS bigint), N''Fabia Sedan''),
    (CAST(232 AS bigint), N''Felicia Combi''),
    (CAST(233 AS bigint), N''Octavia''),
    (CAST(234 AS bigint), N''Octavia Combi''),
    (CAST(235 AS bigint), N''Roomster''),
    (CAST(236 AS bigint), N''Yeti''),
    (CAST(237 AS bigint), N''Rapid''),
    (CAST(238 AS bigint), N''Rapid Spaceback''),
    (CAST(239 AS bigint), N''Superb''),
    (CAST(240 AS bigint), N''Superb Combi''),
    (CAST(241 AS bigint), N''Alero''),
    (CAST(242 AS bigint), N''Aveo''),
    (CAST(243 AS bigint), N''Camaro''),
    (CAST(244 AS bigint), N''Captiva''),
    (CAST(245 AS bigint), N''Corvette''),
    (CAST(246 AS bigint), N''Cruze''),
    (CAST(247 AS bigint), N''Cruze SW''),
    (CAST(248 AS bigint), N''Epica''),
    (CAST(249 AS bigint), N''Equinox''),
    (CAST(250 AS bigint), N''Evanda''),
    (CAST(251 AS bigint), N''HHR''),
    (CAST(252 AS bigint), N''Kalos'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(253 AS bigint), N''Lacetti''),
    (CAST(254 AS bigint), N''Lacetti SW''),
    (CAST(255 AS bigint), N''Lumina''),
    (CAST(256 AS bigint), N''Malibu''),
    (CAST(257 AS bigint), N''Matiz''),
    (CAST(258 AS bigint), N''Monte Carlo''),
    (CAST(259 AS bigint), N''Nubira''),
    (CAST(260 AS bigint), N''Orlando''),
    (CAST(261 AS bigint), N''Spark''),
    (CAST(262 AS bigint), N''Suburban''),
    (CAST(263 AS bigint), N''Tacuma''),
    (CAST(264 AS bigint), N''Tahoe''),
    (CAST(265 AS bigint), N''Trax''),
    (CAST(266 AS bigint), N''911 Carrera''),
    (CAST(267 AS bigint), N''911 Carrera Cabrio''),
    (CAST(268 AS bigint), N''911 Targa''),
    (CAST(269 AS bigint), N''911 Turbo''),
    (CAST(270 AS bigint), N''924''),
    (CAST(271 AS bigint), N''944''),
    (CAST(272 AS bigint), N''997''),
    (CAST(273 AS bigint), N''Boxster''),
    (CAST(274 AS bigint), N''Cayenne''),
    (CAST(275 AS bigint), N''Cayman''),
    (CAST(276 AS bigint), N''Macan''),
    (CAST(277 AS bigint), N''Panamera''),
    (CAST(278 AS bigint), N''Accord''),
    (CAST(279 AS bigint), N''Accord Coupé''),
    (CAST(280 AS bigint), N''Accord Tourer''),
    (CAST(281 AS bigint), N''City''),
    (CAST(282 AS bigint), N''Civic''),
    (CAST(283 AS bigint), N''Civic Aerodeck''),
    (CAST(284 AS bigint), N''Civic Coupé''),
    (CAST(285 AS bigint), N''Civic Tourer''),
    (CAST(286 AS bigint), N''Civic Type R''),
    (CAST(287 AS bigint), N''CR-V''),
    (CAST(288 AS bigint), N''CR-X''),
    (CAST(289 AS bigint), N''CR-Z''),
    (CAST(290 AS bigint), N''FR-V''),
    (CAST(291 AS bigint), N''HR-V''),
    (CAST(292 AS bigint), N''Insight''),
    (CAST(293 AS bigint), N''Integra''),
    (CAST(294 AS bigint), N''Jazz'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(295 AS bigint), N''Legend''),
    (CAST(296 AS bigint), N''Prelude''),
    (CAST(297 AS bigint), N''BRZ''),
    (CAST(298 AS bigint), N''Forester''),
    (CAST(299 AS bigint), N''Impreza''),
    (CAST(300 AS bigint), N''Impreza Wagon''),
    (CAST(301 AS bigint), N''Justy''),
    (CAST(302 AS bigint), N''Legacy''),
    (CAST(303 AS bigint), N''Legacy Wagon''),
    (CAST(304 AS bigint), N''Legacy Outback''),
    (CAST(305 AS bigint), N''Levorg''),
    (CAST(306 AS bigint), N''Outback''),
    (CAST(307 AS bigint), N''SVX''),
    (CAST(308 AS bigint), N''Tribeca''),
    (CAST(309 AS bigint), N''Tribeca B9''),
    (CAST(310 AS bigint), N''XV''),
    (CAST(311 AS bigint), N''121''),
    (CAST(312 AS bigint), N''2''),
    (CAST(313 AS bigint), N''3''),
    (CAST(314 AS bigint), N''323''),
    (CAST(315 AS bigint), N''323 Combi''),
    (CAST(316 AS bigint), N''323 Coupé''),
    (CAST(317 AS bigint), N''323 F''),
    (CAST(318 AS bigint), N''5''),
    (CAST(319 AS bigint), N''6''),
    (CAST(320 AS bigint), N''6 Combi''),
    (CAST(321 AS bigint), N''626''),
    (CAST(322 AS bigint), N''626 Combi''),
    (CAST(323 AS bigint), N''B-Fighter''),
    (CAST(324 AS bigint), N''B2500''),
    (CAST(325 AS bigint), N''BT''),
    (CAST(326 AS bigint), N''CX-3''),
    (CAST(327 AS bigint), N''CX-5''),
    (CAST(328 AS bigint), N''CX-7''),
    (CAST(329 AS bigint), N''CX-9''),
    (CAST(330 AS bigint), N''Demio''),
    (CAST(331 AS bigint), N''MPV''),
    (CAST(332 AS bigint), N''MX-3''),
    (CAST(333 AS bigint), N''MX-5''),
    (CAST(334 AS bigint), N''MX-6''),
    (CAST(335 AS bigint), N''Premacy''),
    (CAST(336 AS bigint), N''RX-7'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(337 AS bigint), N''RX-8''),
    (CAST(338 AS bigint), N''Xedox 6''),
    (CAST(339 AS bigint), N''3000 GT''),
    (CAST(340 AS bigint), N''ASX''),
    (CAST(341 AS bigint), N''Carisma''),
    (CAST(342 AS bigint), N''Colt''),
    (CAST(343 AS bigint), N''Colt CC''),
    (CAST(344 AS bigint), N''Eclipse''),
    (CAST(345 AS bigint), N''Fuso canter''),
    (CAST(346 AS bigint), N''Galant''),
    (CAST(347 AS bigint), N''Galant Combi''),
    (CAST(348 AS bigint), N''Grandis''),
    (CAST(349 AS bigint), N''L200''),
    (CAST(350 AS bigint), N''L200 Pick up''),
    (CAST(351 AS bigint), N''L200 Pick up Allrad''),
    (CAST(352 AS bigint), N''L300''),
    (CAST(353 AS bigint), N''Lancer''),
    (CAST(354 AS bigint), N''Lancer Combi''),
    (CAST(355 AS bigint), N''Lancer Evo''),
    (CAST(356 AS bigint), N''Lancer Sportback''),
    (CAST(357 AS bigint), N''Outlander''),
    (CAST(358 AS bigint), N''Pajero''),
    (CAST(359 AS bigint), N''Pajeto Pinin''),
    (CAST(360 AS bigint), N''Pajero Pinin Wagon''),
    (CAST(361 AS bigint), N''Pajero Sport''),
    (CAST(362 AS bigint), N''Pajero Wagon''),
    (CAST(363 AS bigint), N''Space Star''),
    (CAST(364 AS bigint), N''CT''),
    (CAST(365 AS bigint), N''GS''),
    (CAST(366 AS bigint), N''GS 300''),
    (CAST(367 AS bigint), N''GX''),
    (CAST(368 AS bigint), N''IS''),
    (CAST(369 AS bigint), N''IS 200''),
    (CAST(370 AS bigint), N''IS 250 C''),
    (CAST(371 AS bigint), N''IS-F''),
    (CAST(372 AS bigint), N''LS''),
    (CAST(373 AS bigint), N''LX''),
    (CAST(374 AS bigint), N''NX''),
    (CAST(375 AS bigint), N''RC F''),
    (CAST(376 AS bigint), N''RX''),
    (CAST(377 AS bigint), N''RX 300''),
    (CAST(378 AS bigint), N''RX 400h'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(379 AS bigint), N''RX 450h''),
    (CAST(380 AS bigint), N''SC 430''),
    (CAST(381 AS bigint), N''i3''),
    (CAST(382 AS bigint), N''i8''),
    (CAST(383 AS bigint), N''M3''),
    (CAST(384 AS bigint), N''M4''),
    (CAST(385 AS bigint), N''M5''),
    (CAST(386 AS bigint), N''M6''),
    (CAST(387 AS bigint), N''Rad 1''),
    (CAST(388 AS bigint), N''Rad 1 Cabrio''),
    (CAST(389 AS bigint), N''Rad 1 Coupé''),
    (CAST(390 AS bigint), N''Rad 2''),
    (CAST(391 AS bigint), N''Rad 2 Active Tourer''),
    (CAST(392 AS bigint), N''Rad 2 Coupé''),
    (CAST(393 AS bigint), N''Rad 2 Gran Tourer''),
    (CAST(394 AS bigint), N''Rad 3''),
    (CAST(395 AS bigint), N''Rad 3 Cabrio''),
    (CAST(396 AS bigint), N''Rad 3 Compact''),
    (CAST(397 AS bigint), N''Rad 3 Coupé''),
    (CAST(398 AS bigint), N''Rad 3 GT''),
    (CAST(399 AS bigint), N''Rad 3 Touring''),
    (CAST(400 AS bigint), N''Rad 4''),
    (CAST(401 AS bigint), N''Rad 4 Cabrio''),
    (CAST(402 AS bigint), N''Rad 4 Gran Coupé''),
    (CAST(403 AS bigint), N''Rad 5''),
    (CAST(404 AS bigint), N''Rad 5 GT''),
    (CAST(405 AS bigint), N''Rad 5 Touring''),
    (CAST(406 AS bigint), N''Rad 6''),
    (CAST(407 AS bigint), N''Rad 6 Cabrio''),
    (CAST(408 AS bigint), N''Rad 6 Coupé''),
    (CAST(409 AS bigint), N''Rad 6 Gran Coupé''),
    (CAST(410 AS bigint), N''Rad 7''),
    (CAST(411 AS bigint), N''Rad 8 Coupé''),
    (CAST(412 AS bigint), N''X1''),
    (CAST(413 AS bigint), N''X3''),
    (CAST(414 AS bigint), N''X4''),
    (CAST(415 AS bigint), N''X5''),
    (CAST(416 AS bigint), N''X6''),
    (CAST(417 AS bigint), N''Z3''),
    (CAST(418 AS bigint), N''Z3 Coupé''),
    (CAST(419 AS bigint), N''Z3 Roadster''),
    (CAST(420 AS bigint), N''Z4'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(421 AS bigint), N''Z4 Roadster''),
    (CAST(422 AS bigint), N''Amarok''),
    (CAST(423 AS bigint), N''Beetle''),
    (CAST(424 AS bigint), N''Bora''),
    (CAST(425 AS bigint), N''Bora Variant''),
    (CAST(426 AS bigint), N''Caddy''),
    (CAST(427 AS bigint), N''Caddy Van''),
    (CAST(428 AS bigint), N''Life''),
    (CAST(429 AS bigint), N''California''),
    (CAST(430 AS bigint), N''Caravelle''),
    (CAST(431 AS bigint), N''CC''),
    (CAST(432 AS bigint), N''Crafter''),
    (CAST(433 AS bigint), N''Crafter Van''),
    (CAST(434 AS bigint), N''Crafter Kombi''),
    (CAST(435 AS bigint), N''CrossTouran''),
    (CAST(436 AS bigint), N''Eos''),
    (CAST(437 AS bigint), N''Fox''),
    (CAST(438 AS bigint), N''Golf''),
    (CAST(439 AS bigint), N''Golf Cabrio''),
    (CAST(440 AS bigint), N''Golf Plus''),
    (CAST(441 AS bigint), N''Golf Sportvan''),
    (CAST(442 AS bigint), N''Golf Variant''),
    (CAST(443 AS bigint), N''Jetta''),
    (CAST(444 AS bigint), N''LT''),
    (CAST(445 AS bigint), N''Lupo''),
    (CAST(446 AS bigint), N''Multivan''),
    (CAST(447 AS bigint), N''New Beetle''),
    (CAST(448 AS bigint), N''New Beetle Cabrio''),
    (CAST(449 AS bigint), N''Passat''),
    (CAST(450 AS bigint), N''Passat Alltrack''),
    (CAST(451 AS bigint), N''Passat CC''),
    (CAST(452 AS bigint), N''Passat Variant''),
    (CAST(453 AS bigint), N''Passat Variant Van''),
    (CAST(454 AS bigint), N''Phaeton''),
    (CAST(455 AS bigint), N''Polo''),
    (CAST(456 AS bigint), N''Polo Van''),
    (CAST(457 AS bigint), N''Polo Variant''),
    (CAST(458 AS bigint), N''Scirocco''),
    (CAST(459 AS bigint), N''Sharan''),
    (CAST(460 AS bigint), N''T4''),
    (CAST(461 AS bigint), N''T4 Caravelle''),
    (CAST(462 AS bigint), N''T4 Multivan'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(463 AS bigint), N''T5''),
    (CAST(464 AS bigint), N''T5 Caravelle''),
    (CAST(465 AS bigint), N''T5 Multivan''),
    (CAST(466 AS bigint), N''T5 Transporter Shuttle''),
    (CAST(467 AS bigint), N''Tiguan''),
    (CAST(468 AS bigint), N''Touareg''),
    (CAST(469 AS bigint), N''Touran''),
    (CAST(470 AS bigint), N''Alto''),
    (CAST(471 AS bigint), N''Baleno''),
    (CAST(472 AS bigint), N''Baleno kombi''),
    (CAST(473 AS bigint), N''Grand Vitara''),
    (CAST(474 AS bigint), N''Grand Vitara XL-7''),
    (CAST(475 AS bigint), N''Ignis''),
    (CAST(476 AS bigint), N''Jimny''),
    (CAST(477 AS bigint), N''Kizashi''),
    (CAST(478 AS bigint), N''Liana''),
    (CAST(479 AS bigint), N''Samurai''),
    (CAST(480 AS bigint), N''Splash''),
    (CAST(481 AS bigint), N''Swift''),
    (CAST(482 AS bigint), N''SX4''),
    (CAST(483 AS bigint), N''SX4 Sedan''),
    (CAST(484 AS bigint), N''Vitara''),
    (CAST(485 AS bigint), N''Wagon R+''),
    (CAST(486 AS bigint), N''100 D''),
    (CAST(487 AS bigint), N''115''),
    (CAST(488 AS bigint), N''124''),
    (CAST(489 AS bigint), N''126''),
    (CAST(490 AS bigint), N''190''),
    (CAST(491 AS bigint), N''190 D''),
    (CAST(492 AS bigint), N''190 E''),
    (CAST(493 AS bigint), N''200 - 300''),
    (CAST(494 AS bigint), N''200 D''),
    (CAST(495 AS bigint), N''200 E''),
    (CAST(496 AS bigint), N''210 Van''),
    (CAST(497 AS bigint), N''210 kombi''),
    (CAST(498 AS bigint), N''310 Van''),
    (CAST(499 AS bigint), N''310 kombi''),
    (CAST(500 AS bigint), N''230 - 300 CE Coupé''),
    (CAST(501 AS bigint), N''260 - 560 SE''),
    (CAST(502 AS bigint), N''260 - 560 SEL''),
    (CAST(503 AS bigint), N''500 - 600 SEC Coupé''),
    (CAST(504 AS bigint), N''Trieda A'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(505 AS bigint), N''A''),
    (CAST(506 AS bigint), N''A L''),
    (CAST(507 AS bigint), N''AMG GT''),
    (CAST(508 AS bigint), N''Trieda B''),
    (CAST(509 AS bigint), N''Trieda C''),
    (CAST(510 AS bigint), N''C''),
    (CAST(511 AS bigint), N''C Sportcoupé''),
    (CAST(512 AS bigint), N''C T''),
    (CAST(513 AS bigint), N''Citan''),
    (CAST(514 AS bigint), N''CL''),
    (CAST(515 AS bigint), N''CL''),
    (CAST(516 AS bigint), N''CLA''),
    (CAST(517 AS bigint), N''CLC''),
    (CAST(518 AS bigint), N''CLK Cabrio''),
    (CAST(519 AS bigint), N''CLK Coupé''),
    (CAST(520 AS bigint), N''CLS''),
    (CAST(521 AS bigint), N''Trieda E''),
    (CAST(522 AS bigint), N''E''),
    (CAST(523 AS bigint), N''E Cabrio''),
    (CAST(524 AS bigint), N''E Coupé''),
    (CAST(525 AS bigint), N''E T''),
    (CAST(526 AS bigint), N''Trieda G''),
    (CAST(527 AS bigint), N''G Cabrio''),
    (CAST(528 AS bigint), N''GL''),
    (CAST(529 AS bigint), N''GLA''),
    (CAST(530 AS bigint), N''GLC''),
    (CAST(531 AS bigint), N''GLE''),
    (CAST(532 AS bigint), N''GLK''),
    (CAST(533 AS bigint), N''Trieda M''),
    (CAST(534 AS bigint), N''MB 100''),
    (CAST(535 AS bigint), N''Trieda R''),
    (CAST(536 AS bigint), N''Trieda S''),
    (CAST(537 AS bigint), N''S''),
    (CAST(538 AS bigint), N''S Coupé''),
    (CAST(539 AS bigint), N''SL''),
    (CAST(540 AS bigint), N''SLC''),
    (CAST(541 AS bigint), N''SLK''),
    (CAST(542 AS bigint), N''SLR''),
    (CAST(543 AS bigint), N''Sprinter''),
    (CAST(544 AS bigint), N''44994''),
    (CAST(545 AS bigint), N''9-3 Cabriolet''),
    (CAST(546 AS bigint), N''9-3 Coupé'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(547 AS bigint), N''9-3 SportCombi''),
    (CAST(548 AS bigint), N''45055''),
    (CAST(549 AS bigint), N''9-5 SportCombi''),
    (CAST(550 AS bigint), N''900''),
    (CAST(551 AS bigint), N''900 C''),
    (CAST(552 AS bigint), N''900 C Turbo''),
    (CAST(553 AS bigint), N''9000''),
    (CAST(554 AS bigint), N''100''),
    (CAST(555 AS bigint), N''100 Avant''),
    (CAST(556 AS bigint), N''80''),
    (CAST(557 AS bigint), N''80 Avant''),
    (CAST(558 AS bigint), N''80 Cabrio''),
    (CAST(559 AS bigint), N''90''),
    (CAST(560 AS bigint), N''A1''),
    (CAST(561 AS bigint), N''A2''),
    (CAST(562 AS bigint), N''A3''),
    (CAST(563 AS bigint), N''A3 Cabriolet''),
    (CAST(564 AS bigint), N''A3 Limuzina''),
    (CAST(565 AS bigint), N''A3 Sportback''),
    (CAST(566 AS bigint), N''A4''),
    (CAST(567 AS bigint), N''A4 Allroad''),
    (CAST(568 AS bigint), N''A4 Avant''),
    (CAST(569 AS bigint), N''A4 Cabriolet''),
    (CAST(570 AS bigint), N''A5''),
    (CAST(571 AS bigint), N''A5 Cabriolet''),
    (CAST(572 AS bigint), N''A5 Sportback''),
    (CAST(573 AS bigint), N''A6''),
    (CAST(574 AS bigint), N''A6 Allroad''),
    (CAST(575 AS bigint), N''A6 Avant''),
    (CAST(576 AS bigint), N''A7''),
    (CAST(577 AS bigint), N''A8''),
    (CAST(578 AS bigint), N''A8 Long''),
    (CAST(579 AS bigint), N''Q3''),
    (CAST(580 AS bigint), N''Q5''),
    (CAST(581 AS bigint), N''Q7''),
    (CAST(582 AS bigint), N''R8''),
    (CAST(583 AS bigint), N''RS4 Cabriolet''),
    (CAST(584 AS bigint), N''RS4/RS4 Avant''),
    (CAST(585 AS bigint), N''RS5''),
    (CAST(586 AS bigint), N''RS6 Avant''),
    (CAST(587 AS bigint), N''RS7''),
    (CAST(588 AS bigint), N''S3/S3 Sportback'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(589 AS bigint), N''S4 Cabriolet''),
    (CAST(590 AS bigint), N''S4/S4 Avant''),
    (CAST(591 AS bigint), N''S5/S5 Cabriolet''),
    (CAST(592 AS bigint), N''S6/RS6''),
    (CAST(593 AS bigint), N''S7''),
    (CAST(594 AS bigint), N''S8''),
    (CAST(595 AS bigint), N''SQ5''),
    (CAST(596 AS bigint), N''TT Coupé''),
    (CAST(597 AS bigint), N''TT Roadster''),
    (CAST(598 AS bigint), N''TTS''),
    (CAST(599 AS bigint), N''Avella''),
    (CAST(600 AS bigint), N''Besta''),
    (CAST(601 AS bigint), N''Carens''),
    (CAST(602 AS bigint), N''Carnival''),
    (CAST(603 AS bigint), N''Cee`d''),
    (CAST(604 AS bigint), N''Cee`d SW''),
    (CAST(605 AS bigint), N''Cerato''),
    (CAST(606 AS bigint), N''K 2500''),
    (CAST(607 AS bigint), N''Magentis''),
    (CAST(608 AS bigint), N''Opirus''),
    (CAST(609 AS bigint), N''Optima''),
    (CAST(610 AS bigint), N''Picanto''),
    (CAST(611 AS bigint), N''Pregio''),
    (CAST(612 AS bigint), N''Pride''),
    (CAST(613 AS bigint), N''Pro Cee`d''),
    (CAST(614 AS bigint), N''Rio''),
    (CAST(615 AS bigint), N''Rio Combi''),
    (CAST(616 AS bigint), N''Rio sedan''),
    (CAST(617 AS bigint), N''Sephia''),
    (CAST(618 AS bigint), N''Shuma''),
    (CAST(619 AS bigint), N''Sorento''),
    (CAST(620 AS bigint), N''Soul''),
    (CAST(621 AS bigint), N''Sportage''),
    (CAST(622 AS bigint), N''Venga''),
    (CAST(623 AS bigint), N''109''),
    (CAST(624 AS bigint), N''Defender''),
    (CAST(625 AS bigint), N''Discovery''),
    (CAST(626 AS bigint), N''Discovery Sport''),
    (CAST(627 AS bigint), N''Freelander''),
    (CAST(628 AS bigint), N''Range Rover''),
    (CAST(629 AS bigint), N''Range Rover Evoque''),
    (CAST(630 AS bigint), N''Range Rover Sport'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(631 AS bigint), N''Avenger''),
    (CAST(632 AS bigint), N''Caliber''),
    (CAST(633 AS bigint), N''Challenger''),
    (CAST(634 AS bigint), N''Charger''),
    (CAST(635 AS bigint), N''Grand Caravan''),
    (CAST(636 AS bigint), N''Journey''),
    (CAST(637 AS bigint), N''Magnum''),
    (CAST(638 AS bigint), N''Nitro''),
    (CAST(639 AS bigint), N''RAM''),
    (CAST(640 AS bigint), N''Stealth''),
    (CAST(641 AS bigint), N''Viper''),
    (CAST(642 AS bigint), N''300 C''),
    (CAST(643 AS bigint), N''300 C Touring''),
    (CAST(644 AS bigint), N''300 M''),
    (CAST(645 AS bigint), N''Crossfire''),
    (CAST(646 AS bigint), N''Grand Voyager''),
    (CAST(647 AS bigint), N''LHS''),
    (CAST(648 AS bigint), N''Neon''),
    (CAST(649 AS bigint), N''Pacifica''),
    (CAST(650 AS bigint), N''Plymouth''),
    (CAST(651 AS bigint), N''PT Cruiser''),
    (CAST(652 AS bigint), N''Sebring''),
    (CAST(653 AS bigint), N''Sebring Convertible''),
    (CAST(654 AS bigint), N''Stratus''),
    (CAST(655 AS bigint), N''Stratus Cabrio''),
    (CAST(656 AS bigint), N''Town & Country''),
    (CAST(657 AS bigint), N''Voyager''),
    (CAST(658 AS bigint), N''Aerostar''),
    (CAST(659 AS bigint), N''B-Max''),
    (CAST(660 AS bigint), N''C-Max''),
    (CAST(661 AS bigint), N''Cortina''),
    (CAST(662 AS bigint), N''Cougar''),
    (CAST(663 AS bigint), N''Edge''),
    (CAST(664 AS bigint), N''Escort''),
    (CAST(665 AS bigint), N''Escort Cabrio''),
    (CAST(666 AS bigint), N''Escort kombi''),
    (CAST(667 AS bigint), N''Explorer''),
    (CAST(668 AS bigint), N''F-150''),
    (CAST(669 AS bigint), N''F-250''),
    (CAST(670 AS bigint), N''Fiesta''),
    (CAST(671 AS bigint), N''Focus''),
    (CAST(672 AS bigint), N''Focus C-Max'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(673 AS bigint), N''Focus CC''),
    (CAST(674 AS bigint), N''Focus kombi''),
    (CAST(675 AS bigint), N''Fusion''),
    (CAST(676 AS bigint), N''Galaxy''),
    (CAST(677 AS bigint), N''Grand C-Max''),
    (CAST(678 AS bigint), N''Ka''),
    (CAST(679 AS bigint), N''Kuga''),
    (CAST(680 AS bigint), N''Maverick''),
    (CAST(681 AS bigint), N''Mondeo''),
    (CAST(682 AS bigint), N''Mondeo Combi''),
    (CAST(683 AS bigint), N''Mustang''),
    (CAST(684 AS bigint), N''Orion''),
    (CAST(685 AS bigint), N''Puma''),
    (CAST(686 AS bigint), N''Ranger''),
    (CAST(687 AS bigint), N''S-Max''),
    (CAST(688 AS bigint), N''Sierra''),
    (CAST(689 AS bigint), N''Street Ka''),
    (CAST(690 AS bigint), N''Tourneo Connect''),
    (CAST(691 AS bigint), N''Tourneo Custom''),
    (CAST(692 AS bigint), N''Transit''),
    (CAST(693 AS bigint), N''Transit''),
    (CAST(694 AS bigint), N''Transit Bus''),
    (CAST(695 AS bigint), N''Transit Connect LWB''),
    (CAST(696 AS bigint), N''Transit Courier''),
    (CAST(697 AS bigint), N''Transit Custom''),
    (CAST(698 AS bigint), N''Transit kombi''),
    (CAST(699 AS bigint), N''Transit Tourneo''),
    (CAST(700 AS bigint), N''Transit Valnik''),
    (CAST(701 AS bigint), N''Transit Van''),
    (CAST(702 AS bigint), N''Transit Van 350''),
    (CAST(703 AS bigint), N''Windstar''),
    (CAST(704 AS bigint), N''H2''),
    (CAST(705 AS bigint), N''H3''),
    (CAST(706 AS bigint), N''EX''),
    (CAST(707 AS bigint), N''FX''),
    (CAST(708 AS bigint), N''G''),
    (CAST(709 AS bigint), N''G Coupé''),
    (CAST(710 AS bigint), N''M''),
    (CAST(711 AS bigint), N''Q''),
    (CAST(712 AS bigint), N''QX''),
    (CAST(713 AS bigint), N''Daimler''),
    (CAST(714 AS bigint), N''F-Pace'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(715 AS bigint), N''F-Type''),
    (CAST(716 AS bigint), N''S-Type''),
    (CAST(717 AS bigint), N''Sovereign''),
    (CAST(718 AS bigint), N''X-Type''),
    (CAST(719 AS bigint), N''X-type Estate''),
    (CAST(720 AS bigint), N''XE''),
    (CAST(721 AS bigint), N''XF''),
    (CAST(722 AS bigint), N''XJ''),
    (CAST(723 AS bigint), N''XJ12''),
    (CAST(724 AS bigint), N''XJ6''),
    (CAST(725 AS bigint), N''XJ8''),
    (CAST(726 AS bigint), N''XJ8''),
    (CAST(727 AS bigint), N''XJR''),
    (CAST(728 AS bigint), N''XK''),
    (CAST(729 AS bigint), N''XK8 Convertible''),
    (CAST(730 AS bigint), N''XKR''),
    (CAST(731 AS bigint), N''XKR Convertible''),
    (CAST(732 AS bigint), N''Cherokee''),
    (CAST(733 AS bigint), N''Commander''),
    (CAST(734 AS bigint), N''Compass''),
    (CAST(735 AS bigint), N''Grand Cherokee''),
    (CAST(736 AS bigint), N''Patriot''),
    (CAST(737 AS bigint), N''Renegade''),
    (CAST(738 AS bigint), N''Wrangler''),
    (CAST(739 AS bigint), N''100 NX''),
    (CAST(740 AS bigint), N''200 SX''),
    (CAST(741 AS bigint), N''350 Z''),
    (CAST(742 AS bigint), N''350 Z Roadster''),
    (CAST(743 AS bigint), N''370 Z''),
    (CAST(744 AS bigint), N''Almera''),
    (CAST(745 AS bigint), N''Almera Tino''),
    (CAST(746 AS bigint), N''Cabstar E - T''),
    (CAST(747 AS bigint), N''Cabstar TL2 Valnik''),
    (CAST(748 AS bigint), N''e-NV200''),
    (CAST(749 AS bigint), N''GT-R''),
    (CAST(750 AS bigint), N''Insterstar''),
    (CAST(751 AS bigint), N''Juke''),
    (CAST(752 AS bigint), N''King Cab''),
    (CAST(753 AS bigint), N''Leaf''),
    (CAST(754 AS bigint), N''Maxima''),
    (CAST(755 AS bigint), N''Maxima QX''),
    (CAST(756 AS bigint), N''Micra'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(757 AS bigint), N''Murano''),
    (CAST(758 AS bigint), N''Navara''),
    (CAST(759 AS bigint), N''Note''),
    (CAST(760 AS bigint), N''NP300 Pickup''),
    (CAST(761 AS bigint), N''NV200''),
    (CAST(762 AS bigint), N''NV400''),
    (CAST(763 AS bigint), N''Pathfinder''),
    (CAST(764 AS bigint), N''Patrol''),
    (CAST(765 AS bigint), N''Patrol GR''),
    (CAST(766 AS bigint), N''Pickup''),
    (CAST(767 AS bigint), N''Pixo''),
    (CAST(768 AS bigint), N''Primastar''),
    (CAST(769 AS bigint), N''Primastar Combi''),
    (CAST(770 AS bigint), N''Primera''),
    (CAST(771 AS bigint), N''Primera Combi''),
    (CAST(772 AS bigint), N''Pulsar''),
    (CAST(773 AS bigint), N''Qashqai''),
    (CAST(774 AS bigint), N''Serena''),
    (CAST(775 AS bigint), N''Sunny''),
    (CAST(776 AS bigint), N''Terrano''),
    (CAST(777 AS bigint), N''Tiida''),
    (CAST(778 AS bigint), N''Trade''),
    (CAST(779 AS bigint), N''Vanette Cargo''),
    (CAST(780 AS bigint), N''X-Trail''),
    (CAST(781 AS bigint), N''240''),
    (CAST(782 AS bigint), N''340''),
    (CAST(783 AS bigint), N''360''),
    (CAST(784 AS bigint), N''460''),
    (CAST(785 AS bigint), N''850''),
    (CAST(786 AS bigint), N''850 kombi''),
    (CAST(787 AS bigint), N''C30''),
    (CAST(788 AS bigint), N''C70''),
    (CAST(789 AS bigint), N''C70 Cabrio''),
    (CAST(790 AS bigint), N''C70 Coupé''),
    (CAST(791 AS bigint), N''S40''),
    (CAST(792 AS bigint), N''S60''),
    (CAST(793 AS bigint), N''S70''),
    (CAST(794 AS bigint), N''S80''),
    (CAST(795 AS bigint), N''S90''),
    (CAST(796 AS bigint), N''V40''),
    (CAST(797 AS bigint), N''V50''),
    (CAST(798 AS bigint), N''V60'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(799 AS bigint), N''V70''),
    (CAST(800 AS bigint), N''V90''),
    (CAST(801 AS bigint), N''XC60''),
    (CAST(802 AS bigint), N''XC70''),
    (CAST(803 AS bigint), N''XC90''),
    (CAST(804 AS bigint), N''Espero''),
    (CAST(805 AS bigint), N''Kalos''),
    (CAST(806 AS bigint), N''Lacetti''),
    (CAST(807 AS bigint), N''Lanos''),
    (CAST(808 AS bigint), N''Leganza''),
    (CAST(809 AS bigint), N''Lublin''),
    (CAST(810 AS bigint), N''Matiz''),
    (CAST(811 AS bigint), N''Nexia''),
    (CAST(812 AS bigint), N''Nubira''),
    (CAST(813 AS bigint), N''Nubira kombi''),
    (CAST(814 AS bigint), N''Racer''),
    (CAST(815 AS bigint), N''Tacuma''),
    (CAST(816 AS bigint), N''Tico''),
    (CAST(817 AS bigint), N''1100''),
    (CAST(818 AS bigint), N''126''),
    (CAST(819 AS bigint), N''500''),
    (CAST(820 AS bigint), N''500L''),
    (CAST(821 AS bigint), N''500X''),
    (CAST(822 AS bigint), N''850''),
    (CAST(823 AS bigint), N''Barchetta''),
    (CAST(824 AS bigint), N''Brava''),
    (CAST(825 AS bigint), N''Cinquecento''),
    (CAST(826 AS bigint), N''Coupé''),
    (CAST(827 AS bigint), N''Croma''),
    (CAST(828 AS bigint), N''Doblo''),
    (CAST(829 AS bigint), N''Doblo Cargo''),
    (CAST(830 AS bigint), N''Doblo Cargo Combi''),
    (CAST(831 AS bigint), N''Ducato''),
    (CAST(832 AS bigint), N''Ducato Van''),
    (CAST(833 AS bigint), N''Ducato Kombi''),
    (CAST(834 AS bigint), N''Ducato Podvozok''),
    (CAST(835 AS bigint), N''Florino''),
    (CAST(836 AS bigint), N''Florino Combi''),
    (CAST(837 AS bigint), N''Freemont''),
    (CAST(838 AS bigint), N''Grande Punto''),
    (CAST(839 AS bigint), N''Idea''),
    (CAST(840 AS bigint), N''Linea'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(841 AS bigint), N''Marea''),
    (CAST(842 AS bigint), N''Marea Weekend''),
    (CAST(843 AS bigint), N''Multipla''),
    (CAST(844 AS bigint), N''Palio Weekend''),
    (CAST(845 AS bigint), N''Panda''),
    (CAST(846 AS bigint), N''Panda Van''),
    (CAST(847 AS bigint), N''Punto''),
    (CAST(848 AS bigint), N''Punto Cabriolet''),
    (CAST(849 AS bigint), N''Punto Evo''),
    (CAST(850 AS bigint), N''Punto Van''),
    (CAST(851 AS bigint), N''Qubo''),
    (CAST(852 AS bigint), N''Scudo''),
    (CAST(853 AS bigint), N''Scudo Van''),
    (CAST(854 AS bigint), N''Scudo Kombi''),
    (CAST(855 AS bigint), N''Sedici''),
    (CAST(856 AS bigint), N''Seicento''),
    (CAST(857 AS bigint), N''Stilo''),
    (CAST(858 AS bigint), N''Stilo Multiwagon''),
    (CAST(859 AS bigint), N''Strada''),
    (CAST(860 AS bigint), N''Talento''),
    (CAST(861 AS bigint), N''Tipo''),
    (CAST(862 AS bigint), N''Ulysse''),
    (CAST(863 AS bigint), N''Uno''),
    (CAST(864 AS bigint), N''X1/9''),
    (CAST(865 AS bigint), N''Cooper''),
    (CAST(866 AS bigint), N''Cooper Cabrio''),
    (CAST(867 AS bigint), N''Cooper Clubman''),
    (CAST(868 AS bigint), N''Cooper D''),
    (CAST(869 AS bigint), N''Cooper D Clubman''),
    (CAST(870 AS bigint), N''Cooper S''),
    (CAST(871 AS bigint), N''Cooper S Cabrio''),
    (CAST(872 AS bigint), N''Cooper S Clubman''),
    (CAST(873 AS bigint), N''Countryman''),
    (CAST(874 AS bigint), N''Mini One''),
    (CAST(875 AS bigint), N''One D''),
    (CAST(876 AS bigint), N''200''),
    (CAST(877 AS bigint), N''214''),
    (CAST(878 AS bigint), N''218''),
    (CAST(879 AS bigint), N''25''),
    (CAST(880 AS bigint), N''400''),
    (CAST(881 AS bigint), N''414''),
    (CAST(882 AS bigint), N''416'');
    INSERT INTO [CarModels] ([ID], [ModelName])
    VALUES (CAST(883 AS bigint), N''620''),
    (CAST(884 AS bigint), N''75''),
    (CAST(885 AS bigint), N''Cabrio''),
    (CAST(886 AS bigint), N''City-Coupé''),
    (CAST(887 AS bigint), N''Compact Pulse''),
    (CAST(888 AS bigint), N''Forfour''),
    (CAST(889 AS bigint), N''Fortwo cabrio''),
    (CAST(890 AS bigint), N''Fortwo coupé''),
    (CAST(891 AS bigint), N''Roadster'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'ModelName') AND [object_id] = OBJECT_ID(N'[CarModels]'))
        SET IDENTITY_INSERT [CarModels] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Speciality') AND [object_id] = OBJECT_ID(N'[EngineerSpeciality]'))
        SET IDENTITY_INSERT [EngineerSpeciality] ON;
    EXEC(N'INSERT INTO [EngineerSpeciality] ([ID], [Speciality])
    VALUES (CAST(1 AS bigint), N''Ηλεκτρολόγος''),
    (CAST(2 AS bigint), N''Φαναρτζής''),
    (CAST(3 AS bigint), N''Βαφέας''),
    (CAST(4 AS bigint), N''Τεχνικός Παρμπρίζ'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Speciality') AND [object_id] = OBJECT_ID(N'[EngineerSpeciality]'))
        SET IDENTITY_INSERT [EngineerSpeciality] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'CreationDate', N'Email', N'EnableAccess', N'GarageID', N'LastLoginDate', N'ModifiedDate', N'Name', N'Password', N'Speciality', N'Surname', N'UserType') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    EXEC(N'INSERT INTO [Users] ([ID], [CreationDate], [Email], [EnableAccess], [GarageID], [LastLoginDate], [ModifiedDate], [Name], [Password], [Speciality], [Surname], [UserType])
    VALUES (CAST(1 AS bigint), ''2022-01-06T14:05:14.258'', N''atselios@classter.com'', 1, CAST(0 AS bigint), NULL, NULL, N''Alexandros'', N''1'', NULL, N''Tselios'', 1),
    (CAST(2 AS bigint), ''2022-02-06T09:19:46.369'', N''efi.vanni@gmail.com'', 1, CAST(0 AS bigint), NULL, NULL, N''Efthumia'', N''f1234!'', NULL, N''Varvagianni'', 2),
    (CAST(3 AS bigint), ''2022-12-15T22:19:46.456'', N''kkitsikou@hotmail.com'', 1, CAST(0 AS bigint), NULL, NULL, N''Kostas'', N''gafa#$#'', NULL, N''Kitsikou'', 2),
    (CAST(4 AS bigint), ''2022-12-24T13:42:34.566'', N''mpapadopoulos@yahoo.gr'', 2, CAST(0 AS bigint), NULL, NULL, N''Marios'', N''MP1234@?'', NULL, N''Papadopoulos'', 2),
    (CAST(5 AS bigint), ''2023-02-03T20:08:23.860'', N''konpapa@yahoo.gr'', 1, CAST(0 AS bigint), NULL, NULL, N''Κωνσταντίνος'', N''DfG34#$%^'', CAST(3 AS bigint), N''Παπαδόπουλος'', 3),
    (CAST(6 AS bigint), ''2023-02-06T23:01:57.810'', N''mmichail@gmail.com'', 1, CAST(0 AS bigint), NULL, NULL, N''Μιχάλης'', N''KavMixalis$%'', CAST(2 AS bigint), N''Μιχαήλ'', 3)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'CreationDate', N'Email', N'EnableAccess', N'GarageID', N'LastLoginDate', N'ModifiedDate', N'Name', N'Password', N'Speciality', N'Surname', N'UserType') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'CarManufacturerID', N'CarModelID', N'CarModelYearID') AND [object_id] = OBJECT_ID(N'[CarModelManufacturerYear]'))
        SET IDENTITY_INSERT [CarModelManufacturerYear] ON;
    EXEC(N'INSERT INTO [CarModelManufacturerYear] ([ID], [CarManufacturerID], [CarModelID], [CarModelYearID])
    VALUES (CAST(1 AS bigint), CAST(2 AS bigint), CAST(51 AS bigint), CAST(66 AS bigint)),
    (CAST(2 AS bigint), CAST(24 AS bigint), CAST(2 AS bigint), CAST(62 AS bigint)),
    (CAST(3 AS bigint), CAST(62 AS bigint), CAST(84 AS bigint), CAST(69 AS bigint)),
    (CAST(4 AS bigint), CAST(24 AS bigint), CAST(16 AS bigint), CAST(61 AS bigint)),
    (CAST(5 AS bigint), CAST(24 AS bigint), CAST(16 AS bigint), CAST(62 AS bigint)),
    (CAST(6 AS bigint), CAST(24 AS bigint), CAST(17 AS bigint), CAST(63 AS bigint))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'CarManufacturerID', N'CarModelID', N'CarModelYearID') AND [object_id] = OBJECT_ID(N'[CarModelManufacturerYear]'))
        SET IDENTITY_INSERT [CarModelManufacturerYear] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'UserID', N'ModelManufacturerYearID', N'ModelYearID', N'LicencePlate', N'VIN', N'Color', N'Kilometer') AND [object_id] = OBJECT_ID(N'[UserModels]'))
        SET IDENTITY_INSERT [UserModels] ON;
    EXEC(N'INSERT INTO [UserModels] ([ID], [UserID], [ModelManufacturerYearID], [ModelYearID], [LicencePlate], [VIN], [Color], [Kilometer])
    VALUES (CAST(1 AS bigint), CAST(1 AS bigint), CAST(1 AS bigint), CAST(66 AS bigint), N''KBT5670'', N''ZAR94000007368150'', CAST(101 AS bigint), CAST(156125 AS bigint)),
    (CAST(2 AS bigint), CAST(1 AS bigint), CAST(3 AS bigint), CAST(67 AS bigint), N''EYB7174'', N''VNKKG3D330A048555'', CAST(142 AS bigint), CAST(27450 AS bigint)),
    (CAST(3 AS bigint), CAST(1 AS bigint), CAST(4 AS bigint), CAST(67 AS bigint), N''NIZ2654'', N''NLHBA51BABZ014926'', CAST(4 AS bigint), CAST(88956 AS bigint)),
    (CAST(4 AS bigint), CAST(2 AS bigint), CAST(5 AS bigint), CAST(68 AS bigint), N''XEZ6532'', N''KHX94000007259841'', CAST(5 AS bigint), CAST(220653 AS bigint)),
    (CAST(5 AS bigint), CAST(2 AS bigint), CAST(6 AS bigint), CAST(72 AS bigint), N''KBH1452'', N''JNKCV61E09M303716'', CAST(6 AS bigint), CAST(65402 AS bigint)),
    (CAST(6 AS bigint), CAST(3 AS bigint), CAST(6 AS bigint), CAST(73 AS bigint), N''AHZ1495'', N''JH4DA9460MS032070'', CAST(6 AS bigint), CAST(9563 AS bigint))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'UserID', N'ModelManufacturerYearID', N'ModelYearID', N'LicencePlate', N'VIN', N'Color', N'Kilometer') AND [object_id] = OBJECT_ID(N'[UserModels]'))
        SET IDENTITY_INSERT [UserModels] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Description', N'ServiceDate', N'UserModelsID', N'ServiceKilometer', N'EngineerID', N'StartPrice', N'FinalPrice', N'StartingDate', N'FinishingTime', N'FinishingDate') AND [object_id] = OBJECT_ID(N'[ServiceHistory]'))
        SET IDENTITY_INSERT [ServiceHistory] ON;
    EXEC(N'INSERT INTO [ServiceHistory] ([Description], [ServiceDate], [UserModelsID], [ServiceKilometer], [EngineerID], [StartPrice], [FinalPrice], [StartingDate], [FinishingTime], [FinishingDate])
    VALUES (N''Αλλαγή λαδιών'', ''2022-12-06T20:40:10.552'', CAST(1 AS bigint), CAST(65080 AS bigint), CAST(5 AS bigint), CAST(55 AS real), CAST(55 AS real), ''2022-12-07T13:24:10.552'', ''2022-12-07T13:24:10.552'', ''2022-12-07T13:24:10.552''),
    (N''Αλλαγή ιμάντα χρονισμού'', ''2023-02-06T20:40:10.552'', CAST(1 AS bigint), CAST(70898 AS bigint), CAST(5 AS bigint), CAST(95 AS real), CAST(95 AS real), ''2023-02-06T20:40:10.552'', ''2023-02-06T20:40:10.552'', ''2023-02-06T20:40:10.552'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Description', N'ServiceDate', N'UserModelsID', N'ServiceKilometer', N'EngineerID', N'StartPrice', N'FinalPrice', N'StartingDate', N'FinishingTime', N'FinishingDate') AND [object_id] = OBJECT_ID(N'[ServiceHistory]'))
        SET IDENTITY_INSERT [ServiceHistory] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE PROCEDURE GetCustomerCars
                    -- Add the parameters for the stored procedure here
                    @UserID BIGINT
                    AS
                    BEGIN
    	                SET NOCOUNT ON;
    	                SELECT UM.ID, 
    		                   UM.UserID, 
    		                   CMAN.ManufacturerName, 
    		                   CM.ModelName, 
    		                   CMY.Description AS ModelYear, 
    		                   UM.LicencePlate, 
    		                   UM.VIN, 
    		                   UM.Color, 
    		                   UM.Kilometer
    	                FROM UserModels UM
    		                 INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = um.ModelManufacturerYearID
    		                 INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID
    		                 INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID
    		                 INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID
    	                WHERE UserId = @UserID;
                    END
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE PROCEDURE GetCustomerCar
                    -- Add the parameters for the stored procedure here
                    @UserModelID BIGINT
                    AS
                    BEGIN
    	                SET NOCOUNT ON;
    	                SELECT UM.ID, 
    		                   UM.UserID, 
    		                   CMAN.ManufacturerName, 
    		                   CM.ModelName, 
    		                   CMY.Description AS ModelYear, 
    		                   UM.LicencePlate, 
    		                   UM.VIN, 
    		                   UM.Color, 
    		                   UM.Kilometer
    	                FROM UserModels UM
    		                 INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = um.ModelManufacturerYearID
    		                 INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID
    		                 INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID
    		                 INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID
    	                WHERE UM.ID = @UserModelID;
                    END
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE PROCEDURE[dbo].[GetCarServiceHistory]
                    -- Add the parameters for the stored procedure here
                    @UserModelsID BIGINT
                    AS
                    BEGIN
    	                SET NOCOUNT ON;
    		                SELECT SH.Description, 
    		                   SH.ServiceDate, 
    		                   SH.ServiceKilometer, 
    		                   SH.StartPrice, 
                               SH.FinalPrice,
    		                   UE.Surname, 
    		                   UE.Name, 
    		                   CMAN.ManufacturerName, 
    		                   CM.ModelName, 
    		                   CMY.Description AS ModelYear, 
    		                   UM.LicencePlate, 
    		                   UM.VIN, 
    		                   UM.Color, 
    		                   UM.Kilometer
    	                FROM ServiceHistory SH
    		                 INNER JOIN Users UE ON UE.ID = EngineerID
    		                 INNER JOIN UserModels UM ON UM.ID = SH.UserModelsID
    		                 INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = um.ModelManufacturerYearID
    		                 INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID
    		                 INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID
    		                 INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID
    	                WHERE SH.UserModelsID = @UserModelsID
    	                ORDER BY SH.ServiceDate DESC;
                    END;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE INDEX [IX_CarModelManufacturerYear_CarManufacturerID] ON [CarModelManufacturerYear] ([CarManufacturerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE INDEX [IX_CarModelManufacturerYear_CarModelID] ON [CarModelManufacturerYear] ([CarModelID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE INDEX [IX_CarModelManufacturerYear_CarModelYearID] ON [CarModelManufacturerYear] ([CarModelYearID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE INDEX [IX_ServiceHistory_EngineerID] ON [ServiceHistory] ([EngineerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE INDEX [IX_ServiceHistory_UserModelsID] ON [ServiceHistory] ([UserModelsID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE INDEX [IX_UserModels_ModelManufacturerYearID] ON [UserModels] ([ModelManufacturerYearID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE INDEX [IX_UserModels_ModelYearID] ON [UserModels] ([ModelYearID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    CREATE INDEX [IX_UserModels_UserID] ON [UserModels] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230206210158_Initial-Migration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230206210158_Initial-Migration', N'7.0.2');
END;
GO

COMMIT;
GO

