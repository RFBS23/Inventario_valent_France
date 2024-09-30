create table nivelacceso(
	idnivelacceso int primary key identity,
	nombreacceso varchar(60) not null unique,
	fecharegistro date default getdate()
)
go
insert into nivelacceso (nombreacceso) values
	('administrador'),
	('almacen'),
	('vendedor')
select * from nivelacceso
go

create table usuarios(
	idusuario int primary key identity,
	documento varchar(50) unique not null,
	nombres varchar(150) null,
    apellidos varchar(150) null,
	nombreusuario varchar(50) not null,
	correo varchar(100) not null,
	clave varchar(150) not null,
	idnivelacceso int references nivelacceso(idnivelacceso),
	estado bit not null default 1,
	fecharegistro datetime default getdate()
)
select * from usuarios
go

insert into usuarios (documento, nombres, apellidos, nombreusuario, correo, clave, idnivelacceso) values
	('12345678', 'peruba', 'pepopn', 'pepe', 'pepe@hotmail.pe', '12345', 1),
	('12345688', 'mundo', 'hola', 'pedro', 'pedro@gmail.com', '12345', 2),
	('12345667', 'pepis', 'pep', 'pepino', 'pepino@hotmail.pe', '12345', 3)
select u.idusuario, u.documento, u.nombres, u.apellidos, u.nombreusuario, u.correo, u.clave, u.estado, nv.idnivelacceso, nv.nombreacceso, CONVERT(VARCHAR(10), u.fecharegistro, 120)AS fecharegistro_usuario from usuarios u
inner join nivelacceso nv on nv.idnivelacceso = u.idnivelacceso
go

select idnivelacceso, nombreacceso from nivelacceso
go

create TABLE proveedores(
	idproveedor int PRIMARY KEY IDENTITY,
	nombreproveedor varchar(225),
	documento varchar(50),
	direccion varchar(50), -- direccion
	correo varchar(50),
	telefono varchar(50),
	fecharegistro date default getdate()
)
go
select idproveedor, nombreproveedor, documento, direccion, correo, telefono, fecharegistro from proveedores
insert into proveedores (nombreproveedor, documento, direccion, correo, telefono) values('sin razon social', 'sin ruc', 'n/n', 'sin correo', '---')
go

create table categorias(
	idcategoria int primary key identity,
	nombrecategoria varchar(100) not null,
	estado bit not null default 1,
	fecharegistro datetime default getdate()
)
go
select idcategoria, nombrecategoria, estado, CONVERT(VARCHAR(10), fecharegistro, 120)AS fecharegistro_categorias from categorias
go

insert into categorias (nombrecategoria) values
	('Caballeros'),
	('Damas')
go

select * from categorias
go

create table tallasropa(
	idtallaropa int primary key identity,
	nombretalla varchar(50) not null,
	idcategoria int references categorias(idcategoria) not null,
	estado bit not null default 1,
	fecharegistro DATETIME DEFAULT GETDATE(),
	fechamodificado DATETIME DEFAULT GETDATE()
)
go
SELECT DISTINCT idtallaropa, nombretalla FROM tallasropa tr
INNER JOIN categorias c ON c.idcategoria = tr.idcategoria

WITH TallasUnicas AS (SELECT idtallaropa, c.idcategoria, c.nombrecategoria, nombretalla, tr.estado, CONVERT(VARCHAR(10), tr.fecharegistro, 120) AS fecharegistro_tallas, CONVERT(VARCHAR(10), tr.fechamodificado, 120) AS fechamodificada_tallas, ROW_NUMBER() OVER (PARTITION BY nombretalla ORDER BY tr.idtallaropa) AS rn FROM tallasropa tr INNER JOIN categorias c ON c.idcategoria = tr.idcategoria WHERE tr.estado = 1 )
SELECT idtallaropa, idcategoria, nombrecategoria, nombretalla, estado, fecharegistro_tallas, fechamodificada_tallas FROM TallasUnicas WHERE rn = 1;

select distinct idtallaropa, c.idcategoria, c.nombrecategoria, nombretalla, tr.estado, CONVERT(VARCHAR(10), tr.fecharegistro, 120)AS fecharegistro_tallas, CONVERT(VARCHAR(10), tr.fechamodificado, 120)AS fechamodificada_tallas from tallasropa tr
inner join categorias c on c.idcategoria = tr.idcategoria where tr.estado = 1

insert into tallasropa (nombretalla, idcategoria) values
	('S', 1),
	('M', 2)
go
SELECT * FROM tallasropa
go

create table marca (
	idmarca int primary key identity,
	nombremarca varchar(100),
	estado bit not null default 1,
	fecharegistro date default getdate()
)
go
insert into marca (nombremarca) values ('valent france')
select idmarca, nombremarca, estado from marca
go

create table productos(
	idproducto INT PRIMARY KEY IDENTITY,
	rutaimagen varchar(100) null,
    nombreimagen varchar(100) null,
	rutaimagen2 varchar(100) null, -- agregado recien
	nombreimagen2 varchar(100) null, -- agregado recien
	rutaimagen3 varchar(100) null, -- agregado recien
	nombreimagen3 varchar(100) null, -- agregado recien
	rutaimagen4 varchar(100) null, -- agregado recien
	nombreimagen4 varchar(100) null, -- agregado recien
	codigo varchar(50) not null,
	nombre varchar(50) not null,
	descripcion varchar(50) not null,
	idcategoria int references categorias(idcategoria) not null,
	idtallaropa int references tallasropa(idtallaropa) not null,
	idmarca int REFERENCES marca(idmarca) not NULL,
	stock int default 0 not null,
	colores varchar(40) not null,
	numcaja varchar(50) not null,
	precioventa decimal(10,2) default 0 not null,
	temporada varchar(60) not null,
	descuento int default 0,
	total decimal(10,2) default 0 not null,
	ubicacion varchar(50) NULL,
	estado bit not null default 1,
	fecharegistro datetime default getdate()
)
go

/*agregados
alter table productos add preciocompra decimal(10,2) default 0;

EXEC sp_rename 'productos.rutaimagen2', 'rutaimagendos', 'COLUMN';
EXEC sp_rename 'productos.nombreimagen2', 'nombreimagendos', 'COLUMN';

alter table productos add rutaimagen2 varchar(100) null;
alter table productos add rutaimagen3 varchar(100) null;
alter table productos add rutaimagen4 varchar(100) null;

alter table productos add nombreimagen2 varchar(100) null;
alter table productos add nombreimagen3 varchar(100) null;
alter table productos add nombreimagen4 varchar(100) null;*/
/*fin agregados*/

select * from productos
go

select idproducto, rutaimagen, nombreimagen, codigo, nombre, descripcion, c.idcategoria, c.nombrecategoria, tr.idtallaropa, tr.nombretalla, m.idmarca, m.nombremarca, stock, colores, numcaja, precioventa, temporada, descuento, total, ubicacion, CONVERT(VARCHAR(10), p.fecharegistro, 120)AS fecharegistro_producto from productos p
inner join categorias c on c.idcategoria = p.idcategoria
inner join tallasropa tr on tr.idtallaropa = p.idtallaropa
inner join marca m on m.idmarca = p.idmarca
where ubicacion = 'Almacen';
go

update productos set rutaimagen = @rutaimagen, nombreimagen = @nombreimagen where idproducto = @idproducto

update productos set stock = stock + @cantidad where idproducto = @idproducto;
go
update productos set stock = stock - @cantidad where idproducto = @idproducto;
go

/*tienda*/
create table productos_tienda(
	idproductotienda INT PRIMARY KEY IDENTITY,
	codigo varchar(50) not null,
	nombre varchar(50) not null,
	descripcion varchar(50) not null,
	idcategoria int references categorias(idcategoria) not null,
	idtallaropa int references tallasropa(idtallaropa) not null,
	idmarca int REFERENCES marca(idmarca) not NULL,
	stock int default 0 not null,
	colores varchar(40) not null,
	numcaja varchar(50) not null,
	precioventa decimal(10,2) default 0 not null,
	preciocompra decimal(10,2) default 0 not null,
	temporada varchar(60) not null,
	descuento int default 0,
	total decimal(10,2) default 0 not null,
	estado bit not null default 1,
	promo2x1 bit not null default 0, -- agregado
	fecharegistro datetime default getdate()
)
go
select idproductotienda, codigo, nombre, descripcion, c.idcategoria, c.nombrecategoria, tr.idtallaropa, tr.nombretalla, m.idmarca, m.nombremarca, stock, colores, numcaja, precioventa, temporada, promo2x1, descuento, total,  CONVERT(VARCHAR(10), p.fecharegistro, 120)AS fecharegistro_producto from productos_tienda p
inner join categorias c on c.idcategoria = p.idcategoria
inner join tallasropa tr on tr.idtallaropa = p.idtallaropa
inner join marca m on m.idmarca = p.idmarca
select * from productos_tienda
go

alter table productos_tienda add promo2x1 bit not null default 0;
ALTER TABLE productos_tienda
DROP COLUMN promo2x1;

ALTER TABLE productos_tienda
DROP CONSTRAINT DF__productos__promo__6477ECF3;

SELECT name
FROM sys.default_constraints
WHERE parent_object_id = OBJECT_ID('productos_tienda')
AND parent_column_id = COLUMNPROPERTY(OBJECT_ID('productos_tienda'), 'promo2x1', 'promo2x1');

/*fin tienda*/

create table ventas(
	idventa int primary key identity,
	idusuario int references usuarios(idusuario),
	tipodocumento varchar(50),
	numerodocumento varchar(50),
	documentocliente varchar(50),
	nombrecliente varchar(100),
	montopago decimal(10,2),
	montocambio decimal(10,2),
	montototal decimal(10,2),
	fecharegistro datetime default getdate()
)
go
select * from ventas where numerodocumento = '00014'
go

create table detalle_venta(
	iddetalleventa int primary key identity,
	idventa int references ventas(idventa),
	idproductotienda INT REFERENCES productos_tienda(idproductotienda),
	precioventa decimal(10,2),
	cantidad int,
	subtotal decimal(10,2),
	fecharegistro datetime default getdate()
)
go
select * from detalle_venta
go

create table compra(
	idcompra int primary key identity,
	idusuario int references usuarios(idusuario),
	idproveedor int references proveedores(idproveedor),
	tipodocumento varchar(50),
	numerodocumento varchar(50),
	montototal decimal(10,2),
	fecharegistro datetime default getdate()
)
go
select * from compra
go

create table detallecompra(
	iddetallecompra int primary key identity,
	idcompra int references compra(idcompra),
	idproducto int references productos(idproducto),
	preciocompra decimal(10,2) default 0,
	precioventa decimal(10,2) default 0,
	cantidad int,
	montototal decimal(10,2),
	fecharegistro datetime default getdate()
)
go
select * from detallecompra
go

create table negocios(
	idnegocio int primary key,
	nombre varchar(60),
	ruc varchar(60),
	direccion varchar(60),
	logo varbinary(max) NULL
)
go
select * from negocios
select logo from negocios where idnegocio = 1
select idnegocio, nombre, ruc, direccion, logo from negocios where idnegocio = 1

insert into negocios(idnegocio, nombre, ruc, direccion) values
(1, 'valiant company', '23345361513221', 'por ahi');
go

select v.idventa, u.nombreusuario, v.documentocliente, v.nombrecliente, v.tipodocumento,
v.numerodocumento, v.montopago, v.montocambio, v.montototal, convert(char(10), v.fecharegistro, 103)[FechaRegistro] from ventas v
inner join usuarios u on u.idusuario = v.idusuario
where v.numerodocumento = '00001'

SELECT cp.idcompra, u.nombreusuario, p.documento, p.nombreproveedor, cp.tipodocumento, cp.numerodocumento, cp.montototal, CONVERT(CHAR(10), cp.fecharegistro, 103) AS [FechaRegistro] FROM compra cp
INNER JOIN usuarios u ON u.idusuario = cp.idusuario
INNER JOIN proveedores p ON p.idproveedor = cp.idproveedor
WHERE cp.numerodocumento = '00005'

select p.nombre + ' ' + p.descripcion + ' ' + p.colores + ' ' + tr.nombretalla as productos, dc.preciocompra, dc.cantidad, dc.montototal from detallecompra dc
inner join productos p on p.idproducto = dc.idproducto
inner join tallasropa tr on tr.idtallaropa = p.idtallaropa
where dc.idcompra = '00005'

select p.nombre + ' ' + p.descripcion + ' ' + p.colores + ' ' + tr.nombretalla as productos, p.descuento, dv.precioventa, dv.cantidad, dv.subtotal from detalle_venta dv
inner join productos p on p.idproducto = dv.idproducto
inner join tallasropa tr on tr.idtallaropa = p.idtallaropa
where dv.idventa = '00001'
