create table przypisanie_parametru(
	id int identity(1,1) primary key, 	-- nowy stuff
	id_lekarz int foreign key references lekarz(id),
	id_pacjent int foreign key references pacjent(id),
	id_parametr int foreign key references parametr(id),
	wartosc varchar(50)
)

create table wersja
(
	id int identity(1,1) primary key,
	id_lekarz int foreign key references lekarz(id)
)

create table modyfikacja
(
	id int identity(1,1) primary key, --tylko dlatego że entity się pluje
	id_lekarz int foreign key references lekarz(id),
	id_wersji int foreign key references wersja(id),
	obiekt varchar(50),
	id_obiekt int,
	operaca varchar(50)
)

create table dane_modyfikacji
(
	id int identity(1,1) primary key,
	id_modyfikacja int foreign key references modyfikacja(id),
	id_lekarz int foreign key references lekarz(id),
	nazwa_danej varchar(50),
	stara_wartosc varchar(50),
	nowa_wartosc varchar(50)
)

alter table dane_modyfikacji add id_lekarz int foreign key references lekarz(id)

drop table dane_modyfikacji

SELECT * FROM sysobjects WHERE xtype='U' 