CREATE DATABASE db_proyectoCine
GO
USE db_proyectoCine
GO

-- Creacion de tablas

CREATE TABLE Sucursales
(
	IdSucursal INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Nombre NVARCHAR(MAX) NOT NULL,
	Direccion NVARCHAR(50) NOT NULL,
	Ciudad NVARCHAR(30) NOT NULL
)
CREATE TABLE Clasificaciones
(
	IdClasificaciones INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Categoria NVARCHAR(MAX) NOT NULL,
	EdadMinima INT NOT NULL,
	Descripcion NVARCHAR(50)
)

CREATE TABLE Peliculas
(
	IdPelicula INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Titulo NVARCHAR(50) NOT NULL,
	Duracion TIME(0) NOT NULL,
	Genero NVARCHAR(30) NOT NULL,
	IdClasificaciones INT NOT NULL,
	FOREIGN KEY (IdClasificaciones) REFERENCES Clasificaciones(IdClasificaciones)
)

CREATE TABLE Clientes
(
	IdCliente INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Cedula INT NOT NULL,
	Nombre NVARCHAR(MAX) NOT NULL,
	Edad SMALLINT NOT NULL
)

CREATE TABLE Membresias
(
	IdMembresias INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Nombre NVARCHAR(MAX) NOT NULL,
	FechaInicio SMALLDATETIME DEFAULT GETDATE(),
	IdCliente INT,
	FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
)

CREATE TABLE Proveedores
(
	IdProveedores INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Cedula INT NOT NULL,
	Nombre NVARCHAR(MAX) NOT NULL,
	Edad int not null
)

CREATE TABLE Productos
(
	IdProductos INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Nombre NVARCHAR(MAX) NOT NULL,
	Descripcion NVARCHAR(40),
	Precio DECIMAL(6, 2) NOT NULL,
	IdProveedor INT NOT NULL,
	FOREIGN KEY (IdProveedor) REFERENCES Proveedores(IdProveedores)
)




CREATE TABLE Salas
(
	IdSalas INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	NumeroSala INT NOT NULL,
	Capacidad INT,
	Estado BIT NOT NULL,
	IdSucursal INT NOT NULL,
	FOREIGN KEY (IdSucursal) REFERENCES Sucursales(IdSucursal)
)

CREATE TABLE Empleados
(
	IdEmpleados INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Cedula INT NOT NULL,
	Nombre NVARCHAR(50) NOT NULL,
	FechaContratacion SMALLDATETIME DEFAULT GETDATE(), 
	IdSucursal INT NOT NULL,
	FOREIGN KEY (IdSucursal) REFERENCES Sucursales(IdSucursal)
)

CREATE TABLE Equipos
(
	IdEquipos INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Tipo NVARCHAR(50),
	Marca NVARCHAR(MAX),
	Estado BIT NOT NULL,
	IdSucursal INT NOT NULL,
	FOREIGN KEY (IdSucursal) REFERENCES Sucursales(IdSucursal)
)

CREATE TABLE HorariosEmpleados
(
	IdHorariosEmpleados INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Fecha SMALLDATETIME DEFAULT GETDATE(),
	HoraInicio TIME(0) NOT NULL,
	HoraFin TIME(0) NOT NULL,
	IdEmpleados INT NOT NULL,
	FOREIGN KEY (IdEmpleados) REFERENCES Empleados(IdEmpleados)
)

CREATE TABLE HorariosFuncion
(
	IdHorariosFuncion INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Hora TIME NOT NULL,
	Fecha SMALLDATETIME DEFAULT GETDATE(),
	IdSalas INT NOT NULL,
	IdPelicula INT NOT NULL
)

CREATE TABLE Boletos
(
	IdBoletos INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Asiento NVARCHAR(10) NOT NULL,
	Precio DECIMAL(5, 2) NOT NULL,
	IdCliente INT NOT NULL,
	IdSalas INT NOT NULL,
	FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),
	FOREIGN KEY (IdSalas) REFERENCES Salas(IdSalas)
)
CREATE TABLE ClienteProducto
(
	IdClienteProducto INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	FechaCompra SMALLDATETIME DEFAULT GETDATE(),
	Monto DECIMAL(5, 2) NOT NULL,
	IdProductos INT NOT NULL,
	IdCliente INT NOT NULL,
	FOREIGN KEY (IdProductos) REFERENCES Productos(IdProductos),
	FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
)

CREATE TABLE Tecnicos
(
	IdTecnicos INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Cedula INT NOT NULL,
	Nombre NVARCHAR(MAX) NOT NULL,
	Especialidad NVARCHAR(60),
	IdEquipos INT NOT NULL
)




-- INGRESAR DATOS

INSERT INTO Sucursales (Nombre, Direccion, Ciudad) VALUES 
('Cine Colombia', 'Calle 10 #15-20', 'Bogota'),
('Cinepolis', 'Av. 68 #45-32', 'Medellín'),
('Royal Films', 'Cra. 50 #22-11', 'Cali'),
('Procinal', 'Calle 80 #12-40', 'Barranquilla'),
('Cinemark', 'Av. Las Américas #33-21', 'Cartagena')

INSERT INTO Clientes (Cedula, Nombre, Edad) VALUES
(1002456789, 'Juan Henao', 19),
(1009876543, 'María Lopez', 25),
(1012345678, 'Carlos Pérez', 32),
(1098765432, 'Ana Gómez', 28),
(1023456789, 'Luis Rodríguez', 41)

INSERT INTO Proveedores (Cedula, Nombre, Edad) VALUES
(123456789, 'Jose Rodriguez',50),
(987654321, 'Monica Rivera',34),
(555444333, 'Carlos Pérez',28),
(222333444, 'Laura Martínez',33),
(999888777, 'Sofía Gómez',46)

INSERT INTO Productos (Nombre, Descripcion, Precio, IdProveedor) VALUES
('Crispetas', 'Crispetas saladas', 2000.00, 1),
('Vaso', 'Vaso de Superman', 1500.50,2),
('Gaseosa', 'Bebida tamaño mediano', 3500.00, 3),
('Nachos', 'Nachos con queso', 5000.00, 4),
('Chocolate', 'Barra de chocolate', 2500.00,5)

INSERT INTO Empleados (Cedula, Nombre, IdSucursal) VALUES
(1001234567, 'Andres Villa', 1),  
(1007654321, 'Ana Monsalve', 2),
(1005551111, 'Laura Méndez', 1),
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



INSERT INTO Membresias (Nombre, IdCliente) VALUES
('Premium', 1),
('Básica', 2),
('Gold', 3),
('Familiar', 4),
('Estudiante', 5)

INSERT INTO Boletos (Asiento, Precio, IdCliente, IdSalas) VALUES
('32A', 300.00, 5, 1),
('15F', 150.00, 1, 1),  
('22C', 180.00, 2, 2),
('7G', 200.00, 3, 1),  
('12H', 250.00, 4, 3),  
('30E', 300.00, 5, 1)


INSERT INTO ClienteProducto (Monto, IdProductos, IdCliente) VALUES
(250.50, 2, 1),
(499.99, 3, 1),
(120.00, 6, 2),
(350.75, 4, 3),
(89.99, 5, 2)

INSERT INTO Clasificaciones (Categoria, EdadMinima, Descripcion) VALUES
('G', 0, 'Apta para todo público'),
('PG', 7, 'Se recomienda supervisión de padres'),
('PG-13', 13, 'Mayores de 13 años'),
('R', 18, 'Restringida, solo adultos'),
('NC-17', 18, 'Contenido exclusivo para mayores de 18 años')

INSERT INTO Peliculas (Titulo, Duracion, Genero, IdClasificaciones) VALUES
('Toy Story', '01:21:00', 'Animación', 1),       
('Harry Potter', '02:32:00', 'Fantasía', 2),     
('Avengers', '02:28:00', 'Acción', 3),           
('Deadpool', '01:48:00', 'Comedia', 4),          
('50 Sombras', '02:05:00', 'Romance', 5)

INSERT INTO HorariosFuncion (Hora,IdSalas, IdPelicula) VALUES
('12:00:00',1, 4),  
('11:30:00',2, 4),  
('14:20:00',1, 5),  
('16:15:00',2, 6),  
('18:30:00', 1, 7)

INSERT INTO Equipos (Tipo, Marca, Estado, IdSucursal) VALUES
('Proyector Digital', 'Sony', 1, 1),     
('Sistema de Sonido', 'Bose', 1, 2),     
('Máquina de Crispetas', 'CinemarkTech', 1, 3), 
('Pantalla LED', 'Samsung', 0, 4),       
('Aire Acondicionado', 'LG', 1, 5)

INSERT INTO Tecnicos (Cedula, Nombre, Especialidad, IdEquipos) VALUES
(100200300, 'Carlos Mendoza', 'Reparación de Proyectores', 3),
(200300400, 'Lucía Ramírez', 'Mantenimiento de Sonido', 4),
(300400500, 'Andrés López', 'Máquinas de Alimentos', 5),
(400500600, 'Mariana Torres', 'Pantallas y Sistemas Visuales', 6),
(500600700, 'Jorge Castillo', 'Climatización y Refrigeración', 7)


Select *from Boletos
Select *from Clasificaciones
Select *from ClienteProducto
Select *from Clientes
Select *from Empleados
Select *from Equipos
Select *from HorariosEmpleados
Select *from HorariosFuncion
Select *from Membresias
Select *from Peliculas
Select *from Productos
Select *from Proveedores
Select *from Salas
select * from Sucursales
select * from Tecnicos