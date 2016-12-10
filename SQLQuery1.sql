create table lekarz
(
	id int identity(1,1) primary key,
	nazwa varchar(50)
)

create table magazyn
(
	id int identity(1,1) primary key,
	id_lekarz int foreign key references lekarz(id),
	nazwa varchar(50),
	max_rozmiar int,
	priorytet int
)

create table zasada
(
	id int identity(1,1) primary key,
	id_lekarz int foreign key references lekarz(id),
	id_magazyn int foreign key references magazyn(id),
	nazwa_atrybutu varchar(50),
	operacja_porownania varchar(50),
	wartosc_porownania varchar(50),
	spelnialnosc_operacji bit			--- 1 true, 0 false
)

create table pacjent
(
	id int identity(1,1) primary key,
	id_lekarz int foreign key references lekarz(id),
	id_magazyn int foreign key references magazyn(id),
	aktywny bit,
	imie varchar(50),
	nazwisko varchar(50),
	pesel numeric(11,0),				--- 11 pól, 0 w rozwinięciu dziesiętnym
	numer_koperty int,
	ilosc_dodatkowych_parametrow int
)

create table wizyta
(
	id int identity(1,1) primary key,
	id_lekarz int foreign key references lekarz(id),
	id_pacjent int foreign key references pacjent(id),
	data_wizyty date,
	komentarz varchar(255)
)

create table parametr
(
	id int identity(1,1) primary key,
	id_lekarz int foreign key references lekarz(id),
	typ varchar(1),						-- C, char	I, int	B, bool		itp itd
	nazwa varchar(50),
	wartosc_domyslna varchar(50)
)

create table przypisanie_parametru
(
	id int identity(1,1) primary key, 	-- nowy stuff
	id_lekarz int foreign key references lekarz(id),
	id_pacjent int foreign key references pacjent(id),
	id_parametr int foreign key references parametr(id),
	wartosc varchar(50)
)
-- nowy stuff, poprzednio było to co wyżej bez id przypisanie_parametru
create table wersja
(
	id int identity(1,1) primary key,
	id_lekarz int foreign key references lekarz(id)
)

create table modyfikacje2
(
	id int identity(1,1) primary key,
	id_lekarz int foreign key references lekarz(id),
	id_wersji int foreign key references wersja(id)
)

--SELECT * FROM sysobjects WHERE xtype='U' 