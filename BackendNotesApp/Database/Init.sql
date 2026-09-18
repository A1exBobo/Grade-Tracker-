CREATE TABLE Semestru(
    ID int primary key;
    Numar int CHECK (Numar > 0 AND Numar <= 2) not null
);

CREATE TABLE Curs(
    ID int primary key;
    AreDistribuita boolean not null
);

CREATE TABLE Laborator(
    ID int;
    NotaProiect float;
    PondereProiect int not null;
    NotaSeminar float;
    PondereSeminar int not null
);

CREATE TABLE Materie(
    ID int;
    Nume varchar(50) not null;
    NumarCredite int not null;
    PondereCurs int not null;
    SemestruID int not null;
    CursID int not null;
    LaboratorID int
);

CREATE TABLE NotaLaborator(
ID int;
LaboratorID int not null;
Nota float
);

CREATE TABLE Distribuita(
    ID int;
    CursID int not null;
    NumarEvaluare int not null;
    Nota float
);


