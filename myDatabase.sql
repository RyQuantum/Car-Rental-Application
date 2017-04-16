create database wkdl
go
use wkdl
go

create table userlogin
(
	uid int identity(1,1),
	uName varchar(50) not null,
	uPassword varchar(50) not null,
	usa varchar(50) not null,
	uFullName varchar(50) not null,
	uAddress varchar(50),
	uPhone varchar(50) not null,
	uReservation varchar(100) not null
)

alter table userlogin
add constraint pk_id primary key (uName)

create table ware
(
	[Id] int identity(1,1),
	wareName varchar(30) not null,
	price int not null,
	zip int not null,
	type varchar(20) not null,
	stocks int not null
)

alter table ware
add constraint qk_id primary key (wareName)

insert into ware (wareName,price,zip,type,stocks) values('Mini Cooper',200,91360,'Convertible',3)
insert into ware (wareName,price,zip,type,stocks) values('Honda Accord',150,93065,'Coupe',2)
insert into ware (wareName,price,zip,type,stocks) values('Audi A4',220,92521,'Sedans',1)
insert into ware (wareName,price,zip,type,stocks) values('BMW 335i',250,91451,'	Convertible',4)
insert into ware (wareName,price,zip,type,stocks) values('Ferrari 458',680,92520,'Coupe',1)
insert into ware (wareName,price,zip,type,stocks) values('Audi Q5',360,92521,'SUV',0)
insert into ware (wareName,price,zip,type,stocks) values('McLaren 675LT',800,90521,'Coupe',6)
insert into ware (wareName,price,zip,type,stocks) values('Lamborghini Aventador',1060,92028,'Coupe',6)
insert into ware (wareName,price,zip,type,stocks) values('Benz SLR',420,93621,'Convertible',3)
insert into ware (wareName,price,zip,type,stocks) values('Porsche Cayenne',520,93621,'SUV',3)

insert into userlogin (uName,uPassword,usa,uFullName,uAddress,uPhone,uReservation) values('admin','admin','admin', 'Administrator', '', '', '')
insert into userlogin (uName,uPassword,usa,uFullName,uAddress,uPhone,uReservation) values('guest','guest','guest','Guest', '', '', '')
insert into userlogin (uName,uPassword,usa,uFullName,uAddress,uPhone,uReservation) values('mayue','mayue','member', 'Yue Ma', '1527 Patricia Ave, Simi Valley, CA', '857-285-1873', '')
insert into userlogin (uName,uPassword,usa,uFullName,uAddress,uPhone,uReservation) values('chenqi','chenqi','member','Qi Chen', '2460 Vista Wood Cir, Thousand Oaks, CA', '805-300-8756', '')
insert into userlogin (uName,uPassword,usa,uFullName,uAddress,uPhone,uReservation) values('ryancarlson','ryancarlson','member','Gary Skinner', '129 Merchant Ave, Yarmouth Port, MA', '781-837-1219', '')
insert into userlogin (uName,uPassword,usa,uFullName,uAddress,uPhone,uReservation) values('janessatillman','janessatillman','member','	Brady Roy', '223 8th St SW #2, Decatur, AL', '636-937-9589', '')
insert into userlogin (uName,uPassword,usa,uFullName,uAddress,uPhone,uReservation) values('westleyocon','westleyocon','member','Christine Smith', '9439 County Rd #B, Sauk City, WI', '608-544-2601', '')
insert into userlogin (uName,uPassword,usa,uFullName,uAddress,uPhone,uReservation) values('bradyroyZ3y','bradyroyZ3y','member','Eric Johnson', '129 E Beffa St, Festus, MO', '256-306-9628', '')
insert into userlogin (uName,uPassword,usa,uFullName,uAddress,uPhone,uReservation) values('Nectur4972','Nectur4972','member','Laurence Smith', '3 Garfield, Humarock, MA', '508-394-4008', '')
insert into userlogin (uName,uPassword,usa,uFullName,uAddress,uPhone,uReservation) values('L34de0e37','L34de0e37','member','Gabriel Ruffin', '1572 Nash Street, Detroit, MI', '313-230-0378', '')
go
