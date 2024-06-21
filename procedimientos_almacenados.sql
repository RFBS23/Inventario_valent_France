use inventariovalentfrance
go

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