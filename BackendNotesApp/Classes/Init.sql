create table Semestru(
    ID int primary key,
    Numar int not null,
)

create table Curs(
    ID int primary key,
    AreDistribuita int not null,
)

create table Laborator(
    ID int primary key,
    NotaProiect int,     --poate fi null daca nu a fost dat proiectul
    PondereProiect int,  --maxim 100/cred ca tot de la 0 la 1
    
)

create table Materie(
    ID int primary key,
    Nume varchar(50) not null,
    NumarCredite int not null,           --maxim 5 
    PondereCurs int not null,                --maxim 100//desi cred ca e de la 0 la 1 
    SemestruID int not null,
    foreign key (SemestruID) references Semestru(ID)
    CursId int not null,
    foreign key (CursId) references Curs(ID)

)