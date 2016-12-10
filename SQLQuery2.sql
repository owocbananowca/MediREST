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
	obiekt varchar,
	id_obiekt int,
	operaca varchar
)

create table dane_modyfikacji
(
	id int identity,
	id_modyfikacja int foreign key references modyfikacja(id),
	nazwa_danej varchar,
	stara_wartosc varchar,
	nowa_wartosc varchar
)

SELECT * FROM sysobjects WHERE xtype='U' 