use inventariovalentfrance
go

/*usuarios*/
create procedure spu_registrar_usuario(
    @documento VARCHAR(20),
    @nombres VARCHAR(40),
    @apellidos VARCHAR(40),
    @nombreusuario varchar(40),
    @correo varchar(70),
    @clave varchar(50),
    @estado bit,
    @idnivelacceso int,
    @idusuarioresultado int output,
    @mensaje varchar(100) output
)
as
begin
    set @idusuarioresultado = 0
    set @mensaje = ''
    if not exists(select * from usuarios where documento = @documento)
    begin
        insert into usuarios(documento, nombres, apellidos, nombreusuario, correo, clave, estado, idnivelacceso) values
        (@documento, @nombres, @apellidos, @nombreusuario, @correo, @clave, @estado, @idnivelacceso)
        set @idusuarioresultado = scope_identity()
    end
    else
        set @mensaje = 'no se puede repetir el documento de identidad'
    end
go

create PROCEDURE spu_editar_usuario(
    @idusuario int,
    @documento VARCHAR(20),
    @nombres VARCHAR(40),
    @apellidos VARCHAR(40),
    @nombreusuario varchar(40),
    @correo varchar(70),
    @clave varchar(50),
    @estado bit,
    @idnivelacceso int,
    @respuesta int output,
    @mensaje varchar(500) output
)
AS
BEGIN
    SET @respuesta = 0
    SET @mensaje = ''
    if not exists (SELECT * FROM usuarios where documento = @documento and idusuario != @idusuario)
    BEGIN
        UPDATE usuarios SET
        documento = @documento,
        nombres = @nombres,
        apellidos = @apellidos,
        nombreusuario = @nombreusuario,
        correo = @correo,
        clave = @clave,
        estado = @estado,
        idnivelacceso = @idnivelacceso
        WHERE idusuario = @idusuario
        set @respuesta = 1
    END
    ELSE
        SET @mensaje = 'No se puede repetir el mismo dni / carnet de extranjeria para mas de un usuario'
    END
GO

CREATE PROCEDURE spu_eliminar_usuario(
    @idusuario INT,
    @respuesta BIT OUTPUT,
    @mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @respuesta = 0
    SET @mensaje = ''
    DECLARE @pasoreglas BIT = 1
    IF EXISTS (SELECT * FROM ventas V 
        inner join usuarios u on u.idusuario = v.idusuario
        WHERE u.idusuario = @idusuario
    )
    BEGIN
        SET @pasoreglas = 0
        SET @respuesta = 0
        SET @mensaje = @mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una VENTA\n'
    END
    if(@pasoreglas = 1)
    BEGIN
        delete from usuarios WHERE idusuario = @idusuario
        set @respuesta = 1
    END
END
GO

/*categoria*/
create procedure spu_registrar_categoria(
	@nombrecategoria varchar(50),
	@estado bit,
    @fecharegistro datetime,
	@resultado int output,
	@mensaje varchar(100) output
)
as
begin
	set @resultado = 0
	if not exists (select * from categorias where nombrecategoria = @nombrecategoria)
	begin
		insert into categorias(nombrecategoria, estado, fecharegistro) 
        values (@nombrecategoria, @estado, @fecharegistro)
		set @resultado = SCOPE_IDENTITY()
	end
	else
		set @mensaje = 'No se puede duplicar la categoria'
end
go

create procedure spu_editar_categoria(
	@idcategoria int,
	@nombrecategoria varchar(50),
	@estado bit,
	@resultado bit output,
	@mensaje varchar(100) output
)
as
begin
	SET @resultado = 1

    -- Validar si la nueva categoría ya existe
    IF NOT EXISTS (SELECT 1 FROM categorias WHERE nombrecategoria = @nombrecategoria AND idcategoria != @idcategoria)
    BEGIN
        -- Verificar si la categoría está relacionada a algún producto
        IF (EXISTS (SELECT 1 FROM productos WHERE idcategoria = @idcategoria))
        BEGIN
            SET @resultado = 0
            SET @mensaje = 'No se puede cambiar el estado de la categoría porque está relacionada a productos.'
        END
        ELSE
        BEGIN
            -- Verificar si la categoría está relacionada a alguna talla
            IF (EXISTS (SELECT 1 FROM tallasropa WHERE idcategoria = @idcategoria))
            BEGIN
                SET @resultado = 0
                SET @mensaje = 'No se puede cambiar el estado de la categoría porque está relacionada a tallas.'
            END
            ELSE
            BEGIN
                -- Si la categoría no está relacionada a productos ni tallas, realizar la actualización
                UPDATE categorias
                SET
                    nombrecategoria = @nombrecategoria,
                    estado = @estado
                WHERE idcategoria = @idcategoria
            END
        END
    END
    ELSE
    BEGIN
        SET @resultado = 0
        SET @mensaje = 'No se puede repetir el nombre de la categoría.'
    END
end
go

create procedure spu_eliminar_categoria(
	@idcategoria int,
	@resultado bit output,
	@mensaje varchar(100) output
)
as
begin
	set @resultado = 1
	if not exists (select *  from categorias c 
		inner join productos p on p.idcategoria = c.idcategoria 
		where c.idcategoria = @idcategoria)
	begin
		delete top(1) from categorias where idcategoria = @idcategoria
	end
	else
		begin
			set @resultado = 0
			set @mensaje = 'La categoria esta relacionada con productos'
		end
end
go

/*tallas*/
create procedure spu_registrar_tallasropa(
	@nombretalla varchar(50),
	@idcategoria int,
	@resultado int output,
	@mensaje varchar(100) output
)as
begin
	set @resultado = 0
	begin
		insert into tallasropa(idcategoria, nombretalla) values (@idcategoria, @nombretalla)
		set @resultado = SCOPE_IDENTITY()
	end
end
go

create procedure spu_editar_tallasropa(
	@idtallaropa int,
	@idcategoria int,
	@nombretalla varchar(50),
	@resultado bit output,
	@mensaje varchar(100) output
)
as
begin
	set @resultado = 1
		update tallasropa set
		idcategoria = @idcategoria,
		nombretalla = @nombretalla
		where idtallaropa = @idtallaropa
end
go

create procedure spu_eliminar_tallasropa(
	@idtallaropa int,
	@resultado bit output,
	@mensaje varchar(100) output
)
as
begin
	set @resultado = 1
	if not exists (select *  from tallasropa tr 
		inner join productos pr on pr.idtallaropa = tr.idtallaropa
		where tr.idtallaropa = @idtallaropa)
	begin
		delete top(1) from tallasropa where idtallaropa = @idtallaropa
	end
	else
		begin
			set @resultado = 0
			set @mensaje = 'La Talla esta relacionada con uno de los productos y categorias'
		end
end
go

/*marcas*/
create procedure spu_registrar_marca(
	@nombremarca varchar(100),
	@estado bit,
	@resultado int output,
	@mensaje varchar(100) output
)as
begin
	set @resultado = 0
	if not exists (select * from marca where nombremarca = @nombremarca)
	begin
		insert into marca(nombremarca, estado) values (@nombremarca, @estado)
		set @resultado = SCOPE_IDENTITY()
	end
	else
		set @Mensaje = 'No se puede duplicar las marcas'
end
go

create procedure spu_editar_marca(
	@idmarca int,
	@nombremarca varchar(100),
	@estado bit,
	@resultado bit output,
	@mensaje varchar(100) output
)
as
begin
	SET @resultado = 1
    IF NOT EXISTS (SELECT 1 FROM marca WHERE nombremarca = @nombremarca AND idmarca != @idmarca)
    BEGIN
        -- Verificar si la marca estu relacionada a algun producto
        IF (EXISTS (SELECT 1 FROM productos WHERE idmarca = @idmarca))
        BEGIN
            SET @resultado = 0
            SET @mensaje = 'No se puede cambiar el estado de la marca porque esta relacionada a productos.'
        END
        ELSE
        BEGIN
            -- Si la marca no est� relacionada a productos, realizar la actualizaci�n
            UPDATE marca
            SET
            nombremarca = @nombremarca,
            estado = @estado
            WHERE idmarca = @idmarca
        END
    END
    ELSE
    BEGIN
        SET @resultado = 0
        SET @mensaje = 'No se puede repetir el nombre de la marca.'
    END
end
go

create procedure spu_eliminar_marca(
	@idmarca int,
	@resultado bit output,
	@mensaje varchar(100) output
)
as
begin
	SET @resultado = 1
    -- Verificar si la marca esta relacionada a algun producto
    IF EXISTS (SELECT 1 FROM productos WHERE idmarca = @idmarca)
    BEGIN
        SET @resultado = 0
        SET @mensaje = 'La marca esta relacionada con productos y no se puede eliminar.'
    END
    ELSE
    BEGIN
        -- Eliminar la marca
        DELETE FROM marca WHERE idmarca = @idmarca
    END
end
go

/*productos*/
create procedure spu_registrar_productoropa(
	@codigo varchar(50),
	@nombre varchar(50),
	@descripcion varchar(50),
	@idcategoria int,
	@idtallaropa int,
	@idmarca int,
	@stock int,
	@colores varchar(40),
	@numcaja varchar(50),
	@precioventa decimal(10,2),
	@temporada VARCHAR(60),
    @descuento INT = 0,
    @total DECIMAL(10, 2) = 0,
	@ubicacion varchar(50),
	@resultado int output,
	@mensaje varchar(100) output
)
as
begin
	set @resultado = 0
	-- if not exists (select * from productosropa where codigo = @codigo)
	begin
		insert into productos(codigo, nombre, descripcion, idcategoria, idtallaropa, idmarca, stock, colores, numcaja, precioventa, temporada, descuento, total, ubicacion) values
		(@codigo, @nombre, @descripcion, @idcategoria, @idtallaropa, @idmarca, @stock, @colores, @numcaja, @precioventa, @temporada, @descuento, @total, @ubicacion)
		set @resultado = SCOPE_IDENTITY()
	end
	--set @mensaje = 'El codigo ya se encuentra registrado en otra prenda'
end
go

create PROCEDURE spu_editar_productoropa (
    @idproducto INT,
    @codigo VARCHAR(50),
    @nombre VARCHAR(50),
    @descripcion VARCHAR(50),
    @idcategoria INT,
    @idtallaropa INT,
	@idmarca int,
    @stock INT,
    @colores VARCHAR(40),
    @numcaja VARCHAR(50),
    @precioventa DECIMAL(10,2),
    @temporada VARCHAR(60),
    @descuento INT = 0,
    @total DECIMAL(10, 2) = 0,
    @ubicacion VARCHAR(50),
    @resultado INT OUTPUT,
    @mensaje VARCHAR(100) OUTPUT
)
AS
BEGIN
    SET @resultado = 1;
    UPDATE productos
    SET
        codigo = @codigo,
        nombre = @nombre,
        descripcion = @descripcion,
        idcategoria = @idcategoria,
        idtallaropa = @idtallaropa,
		idmarca = @idmarca,
        stock = @stock,
        colores = @colores,
        numcaja = @numcaja,
        precioventa = @precioventa,
        temporada = @temporada,
        descuento = @descuento,
        total = @total,
        ubicacion = @ubicacion
    WHERE idproducto = @idproducto;
    IF @@ROWCOUNT = 0
    BEGIN
        SET @resultado = 0;
        SET @mensaje = 'No se encontró el producto para actualizar.';
    END
END
go

create procedure spu_eliminar_productoropa(
	@idproducto int,
	@respuesta bit output,
	@mensaje varchar(100) output
)
as
begin
    set @respuesta = 0;
    set @mensaje = '';
    declare @pasoreglas bit = 1;

    -- Verificar si el producto está relacionado a una venta en detalle_venta
    if exists (
            select *
            from detalle_venta dv
            inner join productos p on p.idproducto = dv.idproducto
            where p.idproducto = @idproducto
        )
    begin
        set @pasoreglas = 0;
        set @respuesta = 0;
        set @mensaje = @mensaje + 'No se puede eliminar porque se encuentra relacionado a una VENTA';
    end
        if (@pasoreglas = 1)
    begin
        delete from productos where idproducto = @idproducto;
        set @respuesta = 1;
    end
end;
go

/*procediminetos proveedores*/
create procedure spu_registrar_proveedores(
	@nombreproveedor varchar(225),
	@documento varchar(50),
	@direccion varchar(50),
	@correo varchar(50),
	@telefono varchar(50),
	@resultado int output,
	@mensaje varchar(500) output
)
as
begin
	set @resultado = 0
	declare @idpersona int
	if not exists (select * from proveedores where documento = @documento)
	begin
		insert into proveedores(nombreproveedor, documento, direccion, correo, telefono) values (@nombreproveedor, @documento, @direccion, @correo, @telefono)
		set @resultado = SCOPE_IDENTITY()
	end
	else
		set @mensaje = 'El numero de documento ya existe'
end
go

create procedure spu_editar_proveedores(
	@idproveedor int,
	@nombreproveedor varchar(225),
	@documento varchar(50),
	@direccion varchar(50),
	@correo varchar(50),
	@telefono varchar(50),
	@resultado int output,
	@mensaje varchar(500) output
)
as
begin
	SET @resultado = 1
	DECLARE @idpersona INT
	IF NOT EXISTS (select * from proveedores where documento = @documento and idproveedor != @idproveedor)
	begin
		update proveedores set
		nombreproveedor = @nombreproveedor,
		documento = @documento,
		direccion = @direccion,
		correo = @correo,
		telefono = @telefono
		where idproveedor = @idproveedor
	end
	else
	begin
		SET @resultado = 0
		set @mensaje = 'El numero de documento ya existe'
	end
end
go

create procedure spu_eliminar_proveedores(
	@idproveedor int,
	@resultado bit output,
	@mensaje varchar(500) output
)
as
begin
	set @resultado = 1
	begin
	 	delete top(1) from proveedores where idproveedor = @idproveedor
	end
end
go

create type [dbo].[EDetalle_Venta] as table(
	[idproducto] int null,
	[precioventa] decimal(10,2) null,
	[cantidad] int null,
	[subtotal] decimal(10,2) null
)
go

create procedure spu_registrar_venta
    @idusuario int,
    @tipodocumento varchar(50),
    @numerodocumento varchar(50),
    @documentocliente varchar(50),
    @nombrecliente varchar(100),
    @montopago decimal(10,2),
    @montocambio decimal(10,2),
    @montototal decimal(10,2),
    @detalleventa [EDetalle_Venta] readonly,
    @resultado bit OUTPUT,
    @mensaje varchar(100) OUTPUT
AS
BEGIN
    BEGIN TRY
        DECLARE @idventa int = 0
        SET @resultado = 1
        SET @mensaje = ''

        BEGIN TRANSACTION registro

        -- Insertar en la tabla ventas
        INSERT INTO ventas(idusuario, tipodocumento, numerodocumento, documentocliente, nombrecliente, montopago, montocambio, montototal)
        VALUES (@idusuario, @tipodocumento, @numerodocumento, @documentocliente, @nombrecliente, @montopago, @montocambio, @montototal)

        SET @idventa = SCOPE_IDENTITY()

        -- Insertar detalles de la venta en la tabla detalle_venta
        INSERT INTO detalle_venta(idventa, idproducto, precioventa, cantidad, subtotal)
        SELECT @idventa, idproducto, precioventa, cantidad, subtotal FROM @detalleventa

		COMMIT TRANSACTION registro
    END TRY
    BEGIN CATCH
        SET @resultado = 0
        SET @mensaje = ERROR_MESSAGE()
        ROLLBACK TRANSACTION registro
    END CATCH
END
GO

create type [dbo].[EDetalle_Compra] as TABLE(
    [idproducto] int null,
    [preciocompra] DECIMAL(18,2) NULL,
    [precioventa] DECIMAL(18,2) NULL,
    [cantidad] int NULL,
    [montototal] decimal(18,2) NULL
)
go

create procedure spu_registrocompra(
    @idusuario int,
    @idproveedor INT,
    @tipodocumento varchar(500),
    @numerodocumento varchar(500),
    @montototal decimal(18,2),
    @detallecompra [EDetalle_Compra] READONLY,
    @resultado bit OUTPUT,
    @mensaje varchar(500) OUTPUT
)
as
BEGIN
    BEGIN TRY
        DECLARE @idcompra int = 0
        set @resultado = 1
        set @mensaje = ''
        begin transaction registro
        insert into compra(idusuario, idproveedor, tipodocumento, numerodocumento, montototal)
        values (@idusuario, @idproveedor, @tipodocumento, @numerodocumento, @montototal)
        set @idcompra = SCOPE_IDENTITY()
        INSERT into detallecompra(idcompra, idproducto, preciocompra, precioventa, cantidad, montototal)
        select @idcompra, idproducto, preciocompra, precioventa, cantidad, montototal from @detallecompra
        update p set p.stock = p.stock + dc.cantidad,
        p.preciocompra = dc.preciocompra,
        p.precioventa = dc.precioventa
        from productos p
        inner join @detallecompra dc on dc.idproducto = p.idproducto
        commit transaction registro
    end try
    begin catch
        set @resultado = 0
        set @mensaje = ERROR_MESSAGE()
        rollback transaction registro
    end catch
end
go

create procedure spu_reporte_compras(
    @fechainicio varchar(10),
	@fechafin varchar(10),
    @idproveedor int
)
as
begin
set dateformat dmy;
select
convert(char(10), c.fecharegistro,103)[FechaRegistro], c.tipodocumento, c.numerodocumento, c.montototal,
u.nombreusuario[UsuarioRegistro],
pr.documento[docproveedor], pr.nombreproveedor[razonsocial],
p.codigo[CodigoProducto], p.nombre[NombreProducto], p.descuento[Descuento], ca.nombrecategoria[Categoria], dc.preciocompra, dc.precioventa, dc.cantidad, dc.montototal[subtotal]
from compra c
inner join usuarios u on u.idusuario = c.idusuario
inner join proveedores pr on pr.idproveedor = c.idproveedor
inner join detallecompra dc on dc.idcompra = c.idcompra
inner join productos p on p.idproducto = dc.idproducto
inner join categorias ca on ca.idcategoria = p.idcategoria
where convert(date, c.fecharegistro) between @fechainicio and @fechafin
and pr.idproveedor = iif(@idproveedor=0, pr.idproveedor, @idproveedor)
end
go

create procedure spu_reporte_venta(
	@fechainicio varchar(10),
	@fechafin varchar(10)
)
as
begin
set dateformat dmy;
select
convert(char(10), v.fecharegistro, 103)[FechaRegistro], v.tipodocumento, v.numerodocumento, v.montototal,
u.nombreusuario[UsuarioRegistro], v.documentocliente, v.nombrecliente,
p.codigo[CodigoProducto], p.nombre[NombreProducto], p.descuento[Descuento], ca.nombrecategoria[Categoria], dv.precioventa, dv.cantidad, dv.subtotal
from ventas v
inner join usuarios u on u.idusuario = v.idusuario
inner join detalle_venta dv on dv.idventa = v.idventa
inner join productos p on p.idproducto = dv.idproducto
inner join categorias ca on ca.idcategoria = p.idcategoria
where convert(date, v.fecharegistro) between @fechainicio and @fechafin
end
go