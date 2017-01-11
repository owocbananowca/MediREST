delete from parametr
DBCC CHECKIDENT ('parametr', RESEED, 0)

delete from pacjent
dbcc checkident ('pacjent', RESEED, 0)

delete from magazyn
dbcc checkident ('magazyn', RESEED, 0)

delete from modyfikacja
dbcc checkident ('modyfikacja', RESEED, 0)

delete from wersja
dbcc checkident ('wersja', RESEED, 0)

TRUNCATE TABLE dane_modyfikacji
TRUNCATE TABLE wizyta
TRUNCATE TABLE zasada
TRUNCATE TABLE przypisanie_parametru