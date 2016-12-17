drop table modyfikacja
drop table dane_modyfikacji

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