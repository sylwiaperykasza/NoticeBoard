-- dodanie głównych kategorii
INSERT INTO Category(Name)
VALUES ('Dom i ogród');
INSERT INTO Category(Name)
VALUES ('Motoryzacja');
INSERT INTO Category(Name)
VALUES ('Elektronika');
INSERT INTO Category(Name)
VALUES ('Usługi');
INSERT INTO Category(Name)
VALUES ('Pozostałe');

--dodanie podkategorii dla 'Dom i ogród'
INSERT INTO Category(Name, ParentId)
VALUES ('Meble', (SELECT Id from Category where Name='Dom i ogród'));
INSERT INTO Category(Name, ParentId)
VALUES ('Sprzęt AGD', (SELECT Id from Category where Name='Dom i ogród'));
INSERT INTO Category(Name, ParentId)
VALUES ('Ogród', (SELECT Id from Category where Name='Dom i ogród'));
INSERT INTO Category(Name, ParentId)
VALUES ('Pozostałe', (SELECT Id from Category where Name='Dom i ogród'));

--dodanie podkategorii dla 'Motoryzacja'
INSERT INTO Category(Name, ParentId)
VALUES ('Samochody osobowe', (SELECT Id from Category where Name='Motoryzacja'));
INSERT INTO Category(Name, ParentId)
VALUES ('Samochody ciężarowe', (SELECT Id from Category where Name='Motoryzacja'));
INSERT INTO Category(Name, ParentId)
VALUES ('Motocykle', (SELECT Id from Category where Name='Motoryzacja'));
INSERT INTO Category(Name, ParentId)
VALUES ('Pozostałe', (SELECT Id from Category where Name='Motoryzacja'));

--dodanie podkategorii dla 'Elektronika'
INSERT INTO Category(Name, ParentId)
VALUES ('Komputery', (SELECT Id from Category where Name='Elektronika'));
INSERT INTO Category(Name, ParentId)
VALUES ('Tablety', (SELECT Id from Category where Name='Elektronika'));
INSERT INTO Category(Name, ParentId)
VALUES ('Telefony', (SELECT Id from Category where Name='Elektronika'));
INSERT INTO Category(Name, ParentId)
VALUES ('Części/akcesoria', (SELECT Id from Category where Name='Elektronika'));
INSERT INTO Category(Name, ParentId)
VALUES ('Pozostałe', (SELECT Id from Category where Name='Elektronika'));

--dodanie podkategorii dla 'Usługi'
INSERT INTO Category(Name, ParentId)
VALUES ('Transportowe', (SELECT Id from Category where Name='Usługi'));
INSERT INTO Category(Name, ParentId)
VALUES ('Kosmetyczne', (SELECT Id from Category where Name='Usługi'));
INSERT INTO Category(Name, ParentId)
VALUES ('Reklamowe', (SELECT Id from Category where Name='Usługi'));
INSERT INTO Category(Name, ParentId)
VALUES ('Informatyczne', (SELECT Id from Category where Name='Usługi'));
INSERT INTO Category(Name, ParentId)
VALUES ('Ogrodnicze', (SELECT Id from Category where Name='Usługi'));
INSERT INTO Category(Name, ParentId)
VALUES ('Pozostałe', (SELECT Id from Category where Name='Usługi'));