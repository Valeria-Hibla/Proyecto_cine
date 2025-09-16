CREATE DATABASE db_proyectoCine
GO
USE db_proyectoCine
GO

-- Creacion de tablas

CREATE TABLE Sucursales
(
	IdSucursal INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Nombre NVARCHAR(40) NOT NULL,
	Direccion NVARCHAR(50) NOT NULL,
	Ciudad NVARCHAR(30) NOT NULL
)

CREATE TABLE Peliculas
(
	IdPelicula INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Titulo NVARCHAR(50) NOT NULL,
	Duracion TIME(0) NOT NULL,
	Genero NVARCHAR(30) NOT NULL,
	IdClasificacion INT NOT NULL
)

CREATE TABLE Clientes
(
	IdCliente INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Cedula INT NOT NULL,
	Nombre NVARCHAR(50) NOT NULL,
	Edad SMALLINT NOT NULL
)

CREATE TABLE Productos
(
	IdProductos INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Nombre NVARCHAR(20) NOT NULL,
	Descripcion NVARCHAR(40),
	Precio DECIMAL(6, 2) NOT NULL
)

CREATE TABLE Membresias
(
	IdMembresias INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Nombre NVARCHAR(50) NOT NULL,
	FechaInicio SMALLDATETIME DEFAULT GETDATE(),
	IdCliente INT NOT NULL
)

CREATE TABLE Proveedores
(
	IdProveedores INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Cedula INT NOT NULL,
	Nombre NVARCHAR(50) NOT NULL,
	IdProductos INT
)

CREATE TABLE Salas
(
	IdSalas INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	NumeroSala INT NOT NULL,
	Capacidad INT,
	Estado BIT NOT NULL,
	IdSucursal INT NOT NULL
)

CREATE TABLE Empleados
(
	IdEmpleados INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Cedula INT NOT NULL,
	Nombre NVARCHAR(50) NOT NULL,
	FechaContratacion SMALLDATETIME DEFAULT GETDATE(), 
	IdSucursal INT NOT NULL
)

CREATE TABLE Equipos
(
	IdEquipos INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Tipo NVARCHAR(50),
	Marca NVARCHAR(50),
	Estado BIT NOT NULL,
	IdSucursal INT NOT NULL
)

CREATE TABLE HorariosEmpleados
(
	IdHorariosEmpleados INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Fecha SMALLDATETIME DEFAULT GETDATE(),
	HoraInicio TIME(0) NOT NULL,
	HoraFin TIME(0) NOT NULL,
	IdEmpleados INT NOT NULL
)

CREATE TABLE HorariosFuncion
(
	IdHorariosFuncion INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Fecha SMALLDATETIME DEFAULT GETDATE(),
	IdSalas INT NOT NULL,
	IdPelicula INT NOT NULL
)

CREATE TABLE Boletos
(
	IdBoletos INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Asiento INT NOT NULL,
	Precio DECIMAL(5, 2) NOT NULL,
	IdCliente INT NOT NULL,
	IdSalas INT NOT NULL 
)

CREATE TABLE ClienteProducto
(
	IdClienteProducto INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	FechaCompra SMALLDATETIME DEFAULT GETDATE(),
	Monto DECIMAL(5, 2) NOT NULL,
	IdProductos INT NOT NULL,
	IdCliente INT NOT NULL
)

CREATE TABLE Tecnicos
(
	IdTecnicos INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Cedula INT NOT NULL,
	Nombre NVARCHAR(50) NOT NULL,
	Especialidad NVARCHAR(60),
	IdEquipos INT NOT NULL
)

CREATE TABLE Clasificaciones
(
	IdClasificacion INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Categoria NVARCHAR(10) NOT NULL,
	EdadMinima INT NOT NULL,
	Descripcion NVARCHAR(50)
)

-- RELACIONES

ALTER TABLE Membresias ADD FOREIGN KEY(IdCliente)
REFERENCES Clientes

ALTER TABLE Boletos ADD FOREIGN KEY(IdCliente)
REFERENCES Clientes

ALTER TABLE Boletos ADD FOREIGN KEY(IdSalas)
REFERENCES Salas

ALTER TABLE ClienteProducto ADD FOREIGN KEY(IdProductos)
REFERENCES Productos

ALTER TABLE ClienteProducto ADD FOREIGN KEY(IdCliente)
REFERENCES Clientes

ALTER TABLE Proveedores ADD FOREIGN KEY(IdProductos)
REFERENCES Productos

ALTER TABLE Empleados ADD FOREIGN KEY(IdSucursal)
REFERENCES Sucursales

ALTER TABLE Equipos ADD FOREIGN KEY(IdSucursal)
REFERENCES Sucursales

ALTER TABLE HorariosEmpleados ADD FOREIGN KEY(IdEmpleados)
REFERENCES Empleados

ALTER TABLE HorariosFuncion ADD FOREIGN KEY(IdSalas)
REFERENCES Salas

ALTER TABLE HorariosFuncion ADD FOREIGN KEY(IdPelicula)
REFERENCES Peliculas

ALTER TABLE Peliculas ADD FOREIGN KEY(IdClasificacion)
REFERENCES Clasificaciones

ALTER TABLE Tecnicos ADD FOREIGN KEY(IdEquipos)
REFERENCES Equipos

ALTER TABLE Salas ADD FOREIGN KEY(IdSucursal)
REFERENCES Sucursales

-- INGRESAR DATOS

INSERT INTO Sucursales (Nombre, Direccion, Ciudad) VALUES 
('Cine Colombia', 'Calle 10 #15-20', 'Bogota'),
('Cinepolis', 'Av. 68 #45-32', 'Medell�n'),
('Royal Films', 'Cra. 50 #22-11', 'Cali'),
('Procinal', 'Calle 80 #12-40', 'Barranquilla'),
('Cinemark', 'Av. Las Am�ricas #33-21', 'Cartagena')

INSERT INTO Clientes (Cedula, Nombre, Edad) VALUES
(1002456789, 'Juan Henao', 19),
(1009876543, 'Mar�a Lopez', 25),
(1012345678, 'Carlos P�rez', 32),
(1098765432, 'Ana G�mez', 28),
(1023456789, 'Luis Rodr�guez', 41)

INSERT INTO Productos (Nombre, Descripcion, Precio) VALUES
('Crispetas', 'Crispetas saladas', 2000.00),
('Vaso', 'Vaso de Superman', 1500.50),
('Gaseosa', 'Bebida tama�o mediano', 3500.00),
('Nachos', 'Nachos con queso', 5000.00),
('Chocolate', 'Barra de chocolate', 2500.00)

INSERT INTO Empleados (Cedula, Nombre, IdSucursal) VALUES
(1001234567, 'Andres Villa', 1),  
(1007654321, 'Ana Monsalve', 2),
(1005551111, 'Laura M�ndez', 1),
(1006662222, 'Felipe Rojas', 3),
(1007773333, 'Camila Torres', 4)

INSERT INTO HorariosEmpleados (HoraInicio, HoraFin, IdEmpleados) VALUES
('08:00:00', '16:00:00', 1),  
('09:00:00', '17:00:00', 2),
('10:00:00', '18:00:00', 3),
('12:00:00', '20:00:00', 4),
('14:00:00', '22:00:00', 5)

INSERT INTO Salas (NumeroSala, Capacidad, Estado, IdSucursal) VALUES
(101, 50, 1, 1),  
(202, 30, 0, 2),
(303, 80, 1, 3),
(404, 60, 1, 4),
(505, 100, 1, 5)

INSERT INTO Proveedores (Cedula, Nombre, IdProductos) VALUES
(123456789, 'Jose Rodriguez', 2),
(987654321, 'Monica Rivera', 3),
(555444333, 'Carlos P�rez', 1),
(222333444, 'Laura Mart�nez', 4),
(999888777, 'Sof�a G�mez', 5)

INSERT INTO Membresias (Nombre, IdCliente) VALUES
('Premium', 1),
('B�sica', 2),
('Gold', 3),
('Familiar', 4),
('Estudiante', 5)

INSERT INTO Boletos (Asiento, Precio, IdCliente, IdSalas) VALUES
('32A', 300.00, 5, 1),
(15, 150.00, 1, 1),  
(22, 180.00, 2, 2),
(7, 200.00, 3, 1),  
(12, 250.00, 4, 3),  
(30, 300.00, 5, 1)


INSERT INTO ClienteProducto (Monto, IdProductos, IdCliente) VALUES
(250.50, 2, 1),
(499.99, 3, 1),
(120.00, 1, 2),
(350.75, 4, 3),
(89.99, 5, 2)

INSERT INTO Clasificaciones (Categoria, EdadMinima, Descripcion) VALUES
('G', 0, 'Apta para todo p�blico'),
('PG', 7, 'Se recomienda supervisi�n de padres'),
('PG-13', 13, 'Mayores de 13 a�os'),
('R', 18, 'Restringida, solo adultos'),
('NC-17', 18, 'Contenido exclusivo para mayores de 18 a�os')

INSERT INTO Peliculas (Titulo, Duracion, Genero, IdClasificacion) VALUES
('Toy Story', '01:21:00', 'Animaci�n', 1),       
('Harry Potter', '02:32:00', 'Fantas�a', 2),     
('Avengers', '02:28:00', 'Acci�n', 3),           
('Deadpool', '01:48:00', 'Comedia', 4),          
('50 Sombras', '02:05:00', 'Romance', 5)

INSERT INTO HorariosFuncion (IdSalas, IdPelicula) VALUES
(1, 4),  
(2, 4),  
(1, 5),  
(2, 6),  
(1, 7)

INSERT INTO Equipos (Tipo, Marca, Estado, IdSucursal) VALUES
('Proyector Digital', 'Sony', 1, 1),     
('Sistema de Sonido', 'Bose', 1, 2),     
('M�quina de Crispetas', 'CinemarkTech', 1, 3), 
('Pantalla LED', 'Samsung', 0, 4),       
('Aire Acondicionado', 'LG', 1, 5)

INSERT INTO Tecnicos (Cedula, Nombre, Especialidad, IdEquipos) VALUES
(100200300, 'Carlos Mendoza', 'Reparaci�n de Proyectores', 3),
(200300400, 'Luc�a Ram�rez', 'Mantenimiento de Sonido', 4),
(300400500, 'Andr�s L�pez', 'M�quinas de Alimentos', 5),
(400500600, 'Mariana Torres', 'Pantallas y Sistemas Visuales', 6),
(500600700, 'Jorge Castillo', 'Climatizaci�n y Refrigeraci�n', 7)

ALTER TABLE Boletos ALTER COLUMN Asiento NVARCHAR(10) NOT NULL;