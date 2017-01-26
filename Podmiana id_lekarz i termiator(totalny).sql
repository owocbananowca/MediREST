--wywalamy
alter table dane_modyfikacji
drop constraint FK__dane_mody__id_le__75A278F5
alter table dane_modyfikacji
drop column id_lekarz

alter table magazyn
drop constraint FK__magazyn__id_leka__38996AB5
alter table magazyn
drop column id_lekarz

alter table modyfikacja
drop constraint FK__modyfikac__id_le__70DDC3D8
alter table modyfikacja
drop column id_lekarz

alter table pacjent
drop constraint FK__pacjent__id_leka__3F466844
alter table pacjent
drop column id_lekarz

alter table parametr
drop constraint FK__parametr__id_lek__46E78A0C
alter table parametr
drop column id_lekarz

alter table przypisanie_parametru
drop constraint FK__przypisan__id_le__5CD6CB2B
alter table przypisanie_parametru
drop column id_lekarz

alter table wersja
drop constraint FK__wersja__id_lekar__619B8048
alter table wersja
drop column id_lekarz

alter table wizyta
drop constraint FK__wizyta__id_lekar__4316F928
alter table wizyta
drop column id_lekarz

alter table zasada
drop constraint FK__zasada__id_lekar__3B75D760
alter table zasada
drop column id_lekarz

drop table lekarz

--dodajemy
create table lekarz
(
	id int primary key,
	nazwa varchar(50),
	haslo varchar(255)
)

alter table dane_modyfikacji
add id_lekarz integer,
foreign key(id_lekarz) references lekarz(id)

alter table magazyn
add id_lekarz integer,
foreign key(id_lekarz) references lekarz(id)

alter table modyfikacja
add id_lekarz integer,
foreign key(id_lekarz) references lekarz(id)

alter table pacjent
add id_lekarz integer,
foreign key(id_lekarz) references lekarz(id)

alter table parametr
add id_lekarz integer,
foreign key(id_lekarz) references lekarz(id)

alter table przypisanie_parametru
add id_lekarz integer,
foreign key(id_lekarz) references lekarz(id)

alter table wersja
add id_lekarz integer,
foreign key(id_lekarz) references lekarz(id)

alter table zasada
add id_lekarz integer,
foreign key(id_lekarz) references lekarz(id)


--terminator :v
delete from parametr
DBCC CHECKIDENT ('parametr', RESEED, 0)

delete from pacjent
dbcc checkident ('pacjent', RESEED, 0)

delete from modyfikacja
dbcc checkident ('modyfikacja', RESEED, 0)

delete from wersja
dbcc checkident ('wersja', RESEED, 0)

TRUNCATE TABLE dane_modyfikacji
TRUNCATE TABLE wizyta
TRUNCATE TABLE przypisanie_parametru

TRUNCATE TABLE zasada
delete from magazyn
dbcc checkident ('magazyn', RESEED, 0)

delete from lekarz

insert into lekarz
values (1000,'string','string')

select * from lekarz