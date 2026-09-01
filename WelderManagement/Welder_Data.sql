create database WelderDB;
use WelderDB
create table SubContractor
(SubContractorID int primary key,
SubContractorName varchar(150),
Phno varchar(20),
Email varchar(200));

use WelderDB
create table SupplyAgency
(AgencyID int primary key,
AgencyName varchar(200),
Ph varchar(20),
Adres varchar(50));

use WelderDB
create table Welder
(WelderID INT PRIMARY KEY,
WelderCode varchar(30),
WelderName varchar(30),
Nationality varchar(25),
JoinningDate date ,
PassportNo varchar(20),
SubContractorID int,
AgencyID int,
foreign key (SubContractorID) REFERENCES SubContractor(SubContractorID),
foreign key (AgencyID) REFERENCES SupplyAgency(AgencyID));
 

SELECT * FROM SubContractor;
SELECT * FROM SupplyAgency;
SELECT * FROM Welder;



INSERT INTO SubContractor VALUES
(1,'XYZ CONS','3692581475','XY@GMAIL.COM'),
(2,'PWD CONS','2598473621','PWD@GMAIL.COM'),
(3,'ABCD CONS','3625781455','ABCD@GMAIL.COM');

INSERT INTO SupplyAgency VALUES
(1,'GLOBAL SUPPLY','87925','DUBAI'),
(2,'SEMIGLO SUPPLY','36254','SHARJAH'),
(3,'LOCAL SUPPLY','14532','ABU DHABI');


INSERT INTO Welder VALUES
(111,'W101','RAKESH','IND','2020-05-14','P875643',2,1),
(112,'W102','RAHIM','IND','2019-03-18','P901245',1,1),
(113,'W103','MATHEW','IRE','2017-02-10','P458123',3,3),
(114,'W104','HEMANTH','AFG','2021-09-15','P096753',2,1),
(115,'W105','ABDUL','IRN','2026-05-23','P95753',1,1);

alter table Welder add 
WelderQualTest varchar(20);

update Welder set WelderQualTest='Pass' where WelderCode='W105';
select * from Welder
update Welder set WelderID=119 WHERE WelderCode='W109'

DELETE FROM Welder where WelderID=0


select * from MyTest
Insert into MyTest (MyName) VALUES ('Arjun');


CREATE TABLE MyTest
(
 Id int IDENTITY(1,1),
 MyName  VARCHAR(200),
 CONSTRAINT pk_MyTeast PRIMARY KEY  (Id)  
)

SELECT
    WelderID,
    WelderCode,
    WelderName,
    PassportNo,
    WelderQualTest
FROM Welder;

SELECT COUNT(*) AS TotalRows
FROM Welder;