
-- Crear tabla ciudad
CREATE TABLE Ciudad (
id int identity(1, 1) primary key,
    nombre nvarchar(50) not null,
	estado bit default 1
);
-- Crear tabla materia
CREATE TABLE Materia (
id int identity(1, 1) primary key,
    nombre nvarchar(50) not null,
	estado bit default 1
);

-- Crear tabla Monitor
CREATE TABLE Monitor (
    ID int PRIMARY KEY identity(1,1),
    IDUCA nvarchar(9) not null unique,
    primerNombre nvarchar(50),
    segundoNombre nvarchar(50),
    primerApellido nvarchar(50),
    segundoApellido nvarchar(50),
    FechaNac datetime,
    idCiudad int foreign key references Ciudad(id),
    direccion nvarchar(max), 
    email nvarchar(100),
    Telefono nvarchar(20),
    idMateria int foreign key references Materia(id),
    observaciones nvarchar(max),
    estado bit default 'true'
);