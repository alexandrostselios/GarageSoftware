--chrome.exe --user-data-dir="C://Chrome dev session" --disable-web-security
--https://www.back4app.com/database/back4app/car-make-model-dataset

--DBCC CHECKIDENT ('ModelManufacturer', RESEED, 0);
--DBCC CHECKIDENT ('Model', RESEED, 0);
--DROP TABLE ModelManufacturer;
--DROP TABLE Model;
--DROP TABLE Manufacturer;
--DROP TABLE ModelYear;


/* INSERT TEMPORARY DATA */
DECLARE @YEARS TABLE(Y INT);
DECLARE @I INT= 1950;
DECLARE @CurrentYear INT= YEAR(GETDATE());
WHILE @I <= @CurrentYear
    BEGIN
        INSERT INTO CarModelYear
               SELECT @I;
        SET @I = @I + 1;
    END;

--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Abarth')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Alfa Romeo')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Aston Martin')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Audi')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Bentley')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('BMW')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Bugatti')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Cadillac')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Chevrolet')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Chrysler')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Citroën')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Dacia')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Daewoo')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Daihatsu')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Dodge')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Donkervoort')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('DS')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Ferrari')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Fiat')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Fisker')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Ford')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Honda')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Hummer')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Hyundai')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Infiniti')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Iveco')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Jaguar')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Jeep')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Kia')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('KTM')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Lada')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Lamborghini')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Lancia')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Land Rover')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Landwind')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Lexus')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Lotus')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Maserati')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Maybach')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Mazda')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('McLaren')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Mercedes-Benz')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('MG')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Mini')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Mitsubishi')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Morgan')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Nissan')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Opel')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Peugeot')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Porsche')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Renault')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Rolls-Royce')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Rover')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Saab')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Seat')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Skoda')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Smart')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('SsangYong')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Subaru')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Suzuki')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Tesla')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Toyota')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Volkswagen')
--INSERT INTO CarManufacturer (ManufacturerName) VALUES('Volvo')

/* Hyundai */
--INSERT INTO CarModels (ModelName) VALUES('Accent')
--INSERT INTO CarModels (ModelName) VALUES('Atos')
--INSERT INTO CarModels (ModelName) VALUES('Prime')
--INSERT INTO CarModels (ModelName) VALUES('Coupé')
--INSERT INTO CarModels (ModelName) VALUES('Elantra')
--INSERT INTO CarModels (ModelName) VALUES('Galloper')
--INSERT INTO CarModels (ModelName) VALUES('Genesis')
--INSERT INTO CarModels (ModelName) VALUES('Getz')
--INSERT INTO CarModels (ModelName) VALUES('Grandeur')
--INSERT INTO CarModels (ModelName) VALUES('H350')
--INSERT INTO CarModels (ModelName) VALUES('H1')
--INSERT INTO CarModels (ModelName) VALUES('H1Bus')
--INSERT INTO CarModels (ModelName) VALUES('H1Van')
--INSERT INTO CarModels (ModelName) VALUES('H200')
--INSERT INTO CarModels (ModelName) VALUES('i10')
--INSERT INTO CarModels (ModelName) VALUES('i20')
--INSERT INTO CarModels (ModelName) VALUES('i30')
--INSERT INTO CarModels (ModelName) VALUES('i30 CW')
--INSERT INTO CarModels (ModelName) VALUES('i40')
--INSERT INTO CarModels (ModelName) VALUES('i40 CW')
--INSERT INTO CarModels (ModelName) VALUES('ix20')
--INSERT INTO CarModels (ModelName) VALUES('ix35')
--INSERT INTO CarModels (ModelName) VALUES('ix55')
--INSERT INTO CarModels (ModelName) VALUES('Lantra')
--INSERT INTO CarModels (ModelName) VALUES('Matrix')
--INSERT INTO CarModels (ModelName) VALUES('SantaFe')
--INSERT INTO CarModels (ModelName) VALUES('Sonata')
--INSERT INTO CarModels (ModelName) VALUES('Terracan')
--INSERT INTO CarModels (ModelName) VALUES('Trajet')
--INSERT INTO CarModels (ModelName) VALUES('Tucson')
--INSERT INTO CarModels (ModelName) VALUES('Veloster')
--INSERT INTO CarModels (ModelName) VALUES('Kona')
--INSERT INTO CarModels (ModelName) VALUES('Tucson')
--INSERT INTO CarModels (ModelName) VALUES('Bayon')

/* Alfa Romeo */
 --INSERT INTO CarModels (ModelName) VALUES('145')
 --INSERT INTO CarModels (ModelName) VALUES('146')
 --INSERT INTO CarModels (ModelName) VALUES('147')
 --INSERT INTO CarModels (ModelName) VALUES('155')
 --INSERT INTO CarModels (ModelName) VALUES('156')
 --INSERT INTO CarModels (ModelName) VALUES('156 Sportwagon')
 --INSERT INTO CarModels (ModelName) VALUES('159')
 --INSERT INTO CarModels (ModelName) VALUES('159 Sportwagon')
 --INSERT INTO CarModels (ModelName) VALUES('164')
 --INSERT INTO CarModels (ModelName) VALUES('166')
 --INSERT INTO CarModels (ModelName) VALUES('4C')
 --INSERT INTO CarModels (ModelName) VALUES('Brera')
 --INSERT INTO CarModels (ModelName) VALUES('GTV')
 --INSERT INTO CarModels (ModelName) VALUES('MiTo')
 --INSERT INTO CarModels (ModelName) VALUES('Crosswagon')
 --INSERT INTO CarModels (ModelName) VALUES('Spider')
 --INSERT INTO CarModels (ModelName) VALUES('GT')
 --INSERT INTO CarModels (ModelName) VALUES('Giulietta')
 --INSERT INTO CarModels (ModelName) VALUES('Giulia')


--INSERT INTO CarModelManufacturerYear(CarManufacturerID,CarModelID,CarModelYearID) VALUES(24,2,61)
--INSERT INTO CarModelManufacturerYear(CarManufacturerID,CarModelID,CarModelYearID) VALUES(24,2,62)
--INSERT INTO CarModelManufacturerYear(CarManufacturerID,CarModelID,CarModelYearID) VALUES(24,2,63)
--INSERT INTO CarModelManufacturerYear(CarManufacturerID,CarModelID,CarModelYearID) VALUES(24,15,61)
--INSERT INTO CarModelManufacturerYear(CarManufacturerID,CarModelID,CarModelYearID) VALUES(24,16,62)
--INSERT INTO CarModelManufacturerYear(CarManufacturerID,CarModelID,CarModelYearID) VALUES(24,17,63)

--insert into users values('alexandros','tselios','atselios@classter.com','1',1,getdate(),'0001-01-01 00:00:00.0000000','0001-01-01 00:00:00.0000000',1)
--insert into users values('Efthumia','Varvagianni','efi.vanni@gmail.com','ef1234!',2,getdate()+1,'0001-01-01 00:00:00.0000000','0001-01-01 00:00:00.0000000',1)
--insert into users values('Kostas','Kitsikou','kkitsikou@hotmail.com','gafa#$#',2,getdate()+2,'0001-01-01 00:00:00.0000000','0001-01-01 00:00:00.0000000',1)
--insert into users values('Marios','Papadopoulos','mpapadopoulos@yahoo.gr','DfG34#$%^',2,getdate()+3,'0001-01-01 00:00:00.0000000','0001-01-01 00:00:00.0000000',1)


insert into userModels values(1,2,66,'KBT5670','ZAR94000007368150',101,156125)
insert into userModels values(1,3,67,'EYB7174','VNKKG3D330A048555',142,27450)
insert into userModels values(1,4,67,'NIZ2654','NLHBA51BABZ014926',4,88956)
insert into userModels values(2,5,68,'XEZ6532','KHX94000007259841',5,220653)
insert into userModels values(2,6,72,'KBH1452',null,6,65402)
insert into userModels values(3,6,73,'AHZ1495',null,7,9563)


