CREATE DATABASE ProyectoCine
GO
USE ProyectoCine
GO

-- Creacion de tablas

CREATE TABLE Sucursales
(
	IdSucursal INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Nombre NVARCHAR(50) NOT NULL,
	Direccion NVARCHAR(50) NOT NULL,
	Ciudad NVARCHAR(30) NOT NULL
)
GO

CREATE TABLE Peliculas
(
	IdPelicula INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Titulo NVARCHAR(50) NOT NULL,
	Duracion TIME(0) NOT NULL,
	Genero NVARCHAR(30) NOT NULL,
	IdClasificacion INT NOT NULL
)
GO

CREATE TABLE Clientes
(
	IdCliente INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Cedula NVARCHAR(11) NOT NULL,
	Nombre NVARCHAR(50) NOT NULL,
	Edad INT NOT NULL,
	IdMembresia INT NOT NULL
)
GO

CREATE TABLE Productos
(
	IdProductos INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Nombre NVARCHAR(40) NOT NULL,
	Descripcion NVARCHAR(40),
	Precio DECIMAL(6, 2) NOT NULL,
	Imagen VARBINARY(MAX)
)
GO

CREATE TABLE Membresias
(
	IdMembresias INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Nombre NVARCHAR(50) NOT NULL,
	Descripcion NVARCHAR(80),
	FechaInicio SMALLDATETIME DEFAULT GETDATE()
)
GO

CREATE TABLE Proveedores
(
	IdProveedor INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Cedula NVARCHAR(11) NOT NULL,
	Nombre NVARCHAR(50) NOT NULL,
	IdProducto INT
)
GO

CREATE TABLE Salas
(
	IdSalas INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	NumeroSala INT NOT NULL,
	Capacidad INT,
	Estado BIT NOT NULL,
	IdSucursal INT NOT NULL
)
GO

CREATE TABLE Empleados
(
	IdEmpleado INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Cedula NVARCHAR(11) NOT NULL,
	Nombre NVARCHAR(50) NOT NULL,
	FechaContratacion SMALLDATETIME DEFAULT GETDATE(), 
	IdSucursal INT NOT NULL,
	IdHorarioEmpleado INT NOT NULL
)
GO 

CREATE TABLE Equipos
(
	IdEquipos INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Tipo NVARCHAR(50),
	Marca NVARCHAR(50),
	Estado BIT NOT NULL,
	IdSucursal INT NOT NULL
)
GO

CREATE TABLE HorariosEmpleados
(
	IdHorariosEmpleados INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Fecha SMALLDATETIME DEFAULT GETDATE(),
	HoraInicio TIME(0) NOT NULL,
	HoraFin TIME(0) NOT NULL
)
GO

CREATE TABLE HorariosFunciones
(
	IdHorariosFuncion INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Fecha SMALLDATETIME DEFAULT GETDATE(),
	Hora TIME(0),
	IdSala INT NOT NULL,
	IdPelicula INT NOT NULL
)
GO

CREATE TABLE Boletos
(
	IdBoletos INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Asiento NVARCHAR(20) NOT NULL,
	Precio DECIMAL(5, 2) NOT NULL,
	IdCliente INT NOT NULL,
	IdSala INT NOT NULL 
)
GO

CREATE TABLE ClientesProductos
(
	IdClienteProducto INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	FechaCompra SMALLDATETIME DEFAULT GETDATE(),
	Monto DECIMAL(5, 2) NOT NULL,
	IdProducto INT NOT NULL,
	IdCliente INT NOT NULL
)
GO

CREATE TABLE Tecnicos
(
	IdTecnicos INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Cedula NVARCHAR(11) NOT NULL,
	Nombre NVARCHAR(50) NOT NULL,
	Especialidad NVARCHAR(60),
	IdEquipo INT NOT NULL
)
GO

CREATE TABLE Clasificaciones
(
	IdClasificacion INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Categoria NVARCHAR(10) NOT NULL,
	EdadMinima INT NOT NULL,
	Descripcion NVARCHAR(50)
)
GO

CREATE TABLE Usuarios
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Nombre NVARCHAR(30) NOT NULL,
	Contrasena NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE Auditorias
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Controlador NVARCHAR(100) NOT NULL,
	Accion NVARCHAR(100) NOT NULL,
	Fecha DATE NOT NULL
)
GO


-- RELACIONES

ALTER TABLE Clientes ADD FOREIGN KEY(IdMembresia)
REFERENCES Membresias
GO

ALTER TABLE Boletos ADD FOREIGN KEY(IdCliente)
REFERENCES Clientes
GO

ALTER TABLE Boletos ADD FOREIGN KEY(IdSala)
REFERENCES Salas
GO

ALTER TABLE ClientesProductos ADD FOREIGN KEY(IdProducto)
REFERENCES Productos
GO

ALTER TABLE ClientesProductos ADD FOREIGN KEY(IdCliente)
REFERENCES Clientes
GO

ALTER TABLE Proveedores ADD FOREIGN KEY(IdProducto)
REFERENCES Productos
GO

ALTER TABLE Empleados ADD FOREIGN KEY(IdSucursal)
REFERENCES Sucursales
GO

ALTER TABLE Equipos ADD FOREIGN KEY(IdSucursal)
REFERENCES Sucursales
GO

ALTER TABLE HorariosFunciones ADD FOREIGN KEY(IdSala)
REFERENCES Salas
GO

ALTER TABLE HorariosFunciones ADD FOREIGN KEY(IdPelicula)
REFERENCES Peliculas
GO

ALTER TABLE Peliculas ADD FOREIGN KEY(IdClasificacion)
REFERENCES Clasificaciones
GO

ALTER TABLE Tecnicos ADD FOREIGN KEY(IdEquipo)
REFERENCES Equipos
GO

ALTER TABLE Salas ADD FOREIGN KEY(IdSucursal)
REFERENCES Sucursales
GO

ALTER TABLE Empleados ADD FOREIGN KEY(IdHorarioEmpleado)
REFERENCES HorariosEmpleados
GO

-- INGRESAR DATOS

INSERT INTO HorariosEmpleados (HoraInicio, HoraFin) VALUES
('08:00:00', '16:00:00'),  
('09:00:00', '17:00:00'),
('10:00:00', '18:00:00'),
('12:00:00', '20:00:00'),
('14:00:00', '22:00:00')
GO


INSERT INTO Sucursales (Nombre, Direccion, Ciudad) VALUES 
('Cine Colombia', 'Calle 10 #15-20', 'Bogota'),
('Cinepolis', 'Av. 68 #45-32', 'Medellín'),
('Royal Films', 'Cra. 50 #22-11', 'Cali'),
('Procinal', 'Calle 80 #12-40', 'Barranquilla'),
('Cinemark', 'Av. Las Américas #33-21', 'Cartagena')
GO

INSERT INTO Membresias (Nombre, Descripcion) VALUES
('Premium', 'Descripcion1'),
('Básica', 'Descripcion2'),
('Gold', 'Descripcion3'),
('Familiar', 'Descripcion4'),
('Estudiante', 'Descripcion5')
GO

INSERT INTO Clientes (Cedula, Nombre, Edad, IdMembresia) VALUES
(1002456789, 'Juan Henao', 19, 1),
(1009876543, 'María Lopez', 25, 2),
(1012345678, 'Carlos Pérez', 32, 3),
(1098765432, 'Ana Gómez', 28, 4),
(1023456789, 'Luis Rodríguez', 41, 5)
GO

INSERT INTO Productos (Nombre, Descripcion, Precio, Imagen) SELECT 
'Crispetas', 'Crispetas saladas', 2000.00, BulkColumn
FROM OPENROWSET(
        BULK 'C:\Temp\Crispetas.png',
        SINGLE_BLOB
    ) AS img;
GO

INSERT INTO Productos (Nombre, Descripcion, Precio, Imagen) SELECT 
'Perros', 'Perro con gaseosa', 1500.50, BulkColumn
FROM OPENROWSET(
        BULK 'C:\Temp\Perros.png',
        SINGLE_BLOB
    ) AS img;
GO

INSERT INTO Productos (Nombre, Descripcion, Precio, Imagen) SELECT 
'Gaseosa', 'Bebida tamaño mediano', 3500.00, BulkColumn
FROM OPENROWSET(
        BULK 'C:\Temp\Gaseosa.png',
        SINGLE_BLOB
    ) AS img;
GO

INSERT INTO Productos (Nombre, Descripcion, Precio, Imagen) SELECT 
'Nachos', 'Nachos con queso', 5000.00, BulkColumn
FROM OPENROWSET(
        BULK 'C:\Temp\Nachos.png',
        SINGLE_BLOB
    ) AS img;
GO

INSERT INTO Productos (Nombre, Descripcion, Precio, Imagen) SELECT 
'Chocolate', 'Barra de chocolate', 2500.00, BulkColumn
FROM OPENROWSET(
        BULK 'C:\Temp\Chocolate.png',
        SINGLE_BLOB
    ) AS img;
GO

INSERT INTO Empleados (Cedula, Nombre, IdSucursal, IdHorarioEmpleado) VALUES
(1001234567, 'Andres Villa', 1, 1),  
(1007654321, 'Ana Monsalve', 2, 1),
(1005551111, 'Laura Méndez', 1, 2),
(1006662222, 'Felipe Rojas', 3, 2),
(1007773333, 'Camila Torres', 4, 2)
GO

INSERT INTO Salas (NumeroSala, Capacidad, Estado, IdSucursal) VALUES
(101, 50, 1, 1),  
(202, 30, 0, 2),
(303, 80, 1, 3),
(404, 60, 1, 4),
(505, 100, 1, 5)
GO

INSERT INTO Proveedores (Cedula, Nombre, IdProducto) VALUES
(123456789, 'Jose Rodriguez', 2),
(987654321, 'Monica Rivera', 3),
(555444333, 'Carlos Pérez', 1),
(222333444, 'Laura Martínez', 4),
(999888777, 'Sofía Gómez', 5)
GO

INSERT INTO Boletos (Asiento, Precio, IdCliente, IdSala) VALUES
(02, 300.00, 5, 1),
(15, 150.00, 1, 1),  
(22, 180.00, 2, 2),
(7, 200.00, 3, 1),  
(12, 250.00, 4, 3),  
(30, 300.00, 5, 1)
GO

INSERT INTO ClientesProductos (Monto, IdProducto, IdCliente) VALUES
(250.50, 2, 1),
(499.99, 3, 1),
(120.00, 1, 2),
(350.75, 4, 3),
(89.99, 5, 2)
GO

INSERT INTO Clasificaciones (Categoria, EdadMinima, Descripcion) VALUES
('G', 0, 'Apta para todo público'),
('PG', 7, 'Se recomienda supervisión de padres'),
('PG-13', 13, 'Mayores de 13 años'),
('R', 18, 'Restringida, solo adultos'),
('NC-17', 18, 'Contenido exclusivo para mayores de 18 años')
GO

INSERT INTO Peliculas (Titulo, Duracion, Genero, IdClasificacion) VALUES
('Toy Story', '01:21:00', 'Animación', 1),       
('Harry Potter', '02:32:00', 'Fantasía', 2),     
('Avengers', '02:28:00', 'Acción', 3),           
('Deadpool', '01:48:00', 'Comedia', 4),          
('50 Sombras', '02:05:00', 'Romance', 5)
GO

INSERT INTO HorariosFunciones (Fecha, Hora, IdSala, IdPelicula) VALUES
('2025-11-21 14:00', '14:00', 1, 3),
('2025-11-21 16:30', '16:30', 2, 5),
('2025-11-21 18:15', '18:15', 1, 2),
('2025-11-21 20:00', '20:00', 3, 4),
('2025-11-21 22:45', '22:45', 2, 1);
GO

INSERT INTO Equipos (Tipo, Marca, Estado, IdSucursal) VALUES
('Proyector Digital', 'Sony', 1, 1),     
('Sistema de Sonido', 'Bose', 1, 2),     
('Máquina de Crispetas', 'CinemarkTech', 1, 3), 
('Pantalla LED', 'Samsung', 0, 4),       
('Aire Acondicionado', 'LG', 1, 5)
GO

INSERT INTO Tecnicos (Cedula, Nombre, Especialidad, IdEquipo) VALUES
(100200300, 'Carlos Mendoza', 'Reparación de Proyectores', 1),
(200300400, 'Lucía Ramírez', 'Mantenimiento de Sonido', 2),
(300400500, 'Andrés López', 'Máquinas de Alimentos', 3),
(400500600, 'Mariana Torres', 'Pantallas y Sistemas Visuales', 4),
(500600700, 'Jorge Castillo', 'Climatización y Refrigeración', 5)
GO

INSERT INTO Usuarios VALUES
('usuario#1', 'JHGjkhtu6387456yssdf')