Use master
go
----------------------------------------------------------------------
if exists (Select * From SysDataBases Where name = 'PronosticoDelTiempo2')
Begin
	Drop Database PronosticoDelTiempo2
end
go
----------------------------------------------------------------------
Create DataBase PronosticoDelTiempo2
--on(
	--Name= PronosticoDelTiempo2,
	--Filename = 'c:\Proyecto Final\PronosticodelTiempo2/BasedeDatos.mdf'
--)
go
----------------------------------------------------------------------
Use PronosticoDelTiempo2
go
----------------------------------------------------------------------
Create table Usuario(
	NombreLogueo varchar(20)primary key not null,
	Contraseña varchar(20)not null,
	NombreCompleto varchar(50)not null,
	)
go
-----------------------------------------------------------------------
Create table Paises(
	NombrePais varchar(20) null,
	CodigoPais varchar (3)not null Primary Key,
)
go
-----------------------------------------------------------------------
Create table Ciudades(
	NombreCiudad varchar(20) not null,
	CodigoCiudad varchar(3)not null,
	CodigoPais varchar (3)Foreign Key (CodigoPais)references Paises(CodigoPais),
	primary key(CodigoCiudad, CodigoPais)
)
go
----------------------------------------------------------------------
Create table Pronostico(
	CodRegistro int Identity(1,1) not null Primary Key,
	CodigoCiudad varchar(3),
	CodigoPais varchar(3),
	NombreLogueo varchar (20) not null,
	Fecha date not null,
	Hora time not null,
	TemperaturaMax int null,
	TemperaturaMin int null,
	VelocidadViento int null,
	TipodeCielo varchar (20) null,
	ProbabilidadLluvia int null,
	Foreign Key (NombreLogueo) references Usuario (NombreLogueo),
	Foreign Key (CodigoCiudad, CodigoPais) references Ciudades (CodigoCiudad, CodigoPais)
)
go
----------------------------------------------------------------------
insert into Usuario(NombreLogueo, Contraseña, NombreCompleto)values ('Matias', '123456', 'Matias Cuello');
insert into Usuario(NombreLogueo, Contraseña, NombreCompleto)values ('Roberto', '123456', 'Roberto Gomez');
insert into Usuario(NombreLogueo, Contraseña, NombreCompleto)values ('Jose', '123456', 'Jose Perez');
insert into Usuario(NombreLogueo, Contraseña, NombreCompleto)values ('Lucia', '123456', 'Lucia Gonzalez');
go
----------------------------------------------------------------------
insert into Paises (NombrePais, CodigoPais)values ('Uruguay', 'Uru');
insert into Paises (NombrePais, CodigoPais)values ('Mexico', 'Mex');
insert into Paises (NombrePais, CodigoPais)values ('Argentina', 'Arg');
insert into Paises (NombrePais, CodigoPais)values ('Rusia', 'Rus');
insert into Paises (NombrePais, CodigoPais)values ('Colombia', 'Col');
go
----------------------------------------------------------------------
insert into Ciudades (NombreCiudad, CodigoCiudad, CodigoPais)values ('Montevideo', 'Mon', 'Uru');
insert into Ciudades (NombreCiudad, CodigoCiudad, CodigoPais)values ('Juarez', 'Jua', 'Mex');
insert into Ciudades (NombreCiudad, CodigoCiudad, CodigoPais)values ('Buenos Aires', 'BuA', 'Arg');
insert into Ciudades (NombreCiudad, CodigoCiudad, CodigoPais)values ('Moscu', 'Mos', 'Rus');
insert into Ciudades (NombreCiudad, CodigoCiudad, CodigoPais)values ('Cali', 'Cal', 'Col');
go
----------------------------------------------------------------------
insert into Pronostico (CodigoCiudad,CodigoPais, NombreLogueo, Fecha, Hora, TemperaturaMax, TemperaturaMin, VelocidadViento, TipodeCielo, ProbabilidadLluvia)values 
('Mon','Uru', 'Matias', '15/3/2022', '9:00', '32', '15', '100', 'Despejado', '50');
insert into Pronostico (CodigoCiudad,CodigoPais, NombreLogueo, Fecha, Hora, TemperaturaMax, TemperaturaMin, VelocidadViento, TipodeCielo, ProbabilidadLluvia)values 
('BuA', 'Arg','Roberto', '15/3/2022', '12:00', '28','18', '20', 'Nuboso', '10');
insert into Pronostico (CodigoCiudad,CodigoPais, NombreLogueo, Fecha, Hora, TemperaturaMax, TemperaturaMin, VelocidadViento, TipodeCielo, ProbabilidadLluvia)values 
('Jua', 'Mex','Jose', '14/3/2022', '12:00', '28','18', '20', 'Nuboso', '10');
insert into Pronostico (CodigoCiudad,CodigoPais, NombreLogueo, Fecha, Hora, TemperaturaMax, TemperaturaMin, VelocidadViento, TipodeCielo, ProbabilidadLluvia)values 
('Cal', 'Col','Roberto', '15/3/2022', '12:00', '23','1', '20', 'Nuboso', '18');
go
-----------------------------------------------------------------------
-- USUARIO ------------------------------------------------------------
-----------------------------------------------------------------------
CREATE PROC AltaUsuario @NombreLogueo varchar(20),@Contraseña varchar(20), @NombreCompleto varchar(50) AS
BEGIN
	if (Exists(Select * From Usuario Where NombreLogueo=@NombreLogueo))
		return 1
	Insert Usuario values(@NombreLogueo,@Contraseña, @NombreCompleto)
	If (@@ERROR <> 0)
			return -2
			else
			return -1
END
GO
----------------------------------------------------------------------------
create PROC BajaUsuario @NombreLogueo varchar(20) AS
BEGIN
	if (Not Exists(Select * From Usuario Where NombreLogueo=@NombreLogueo))
		return -1
	if (Exists(Select * From Pronostico Where NombreLogueo=@NombreLogueo))
		return 0
		
	DELETE 
	from Usuario 
	where NombreLogueo=@NombreLogueo
	
	if (@@ERROR<>0)
		return 1
	else
		return 2
end
GO
---------------------------------------------------------------------------
CREATE PROC BuscaUsuario @NombreLogueo  varchar(20) AS
BEGIN
	SELECT *
	FROM Usuario
	WHERE NombreLogueo=@NombreLogueo
END
GO
---------------------------------------------------------------------------
CREATE PROC ModificarUsuario @NombreLogueo varchar(20),@Contraseña varchar(20),@NombreCompleto varchar(50)  AS
BEGIN
	if (Not Exists(Select * From Usuario Where NombreLogueo=@NombreLogueo))
		return -1
	Begin
		Update Usuario
		Set Contraseña=@Contraseña,NombreCompleto=@NombreCompleto
		Where NombreLogueo=@NombreLogueo
		If (@@ERROR = 0)
			return 1
		Else
			return -2
	End
END
GO
---------------------------------------------------------------------------
Create Procedure LogueoUsuario @NombreLogueo varchar(20), @Contraseña varchar(20) AS
Begin
	Select *
	From Usuario
	Where NombreLogueo=@NombreLogueo AND Contraseña=@Contraseña
End
GO
-----------------------------------------------------------------------------
--Paises---------------------------------------------------------------------
-----------------------------------------------------------------------------
create PROC AltaPais @CodigoPais varchar(3),@NombrePais varchar(20) AS
BEGIN
if ((LEN (@CodigoPais)=3))and (@CodigoPais) like'[a-z][a-z][a-z]'
BEGIN
	if (Exists(Select * From Paises Where CodigoPais = @CodigoPais))
		return -1
	Insert Paises(CodigoPais,NombrePais) values(@CodigoPais, @NombrePais)
	If (@@ERROR <> 0)
			return -2
			else
			return 1
		
END
END
GO
-----------------------------------------------------------------------------
Create PROC BajaPais @CodigoPais varchar(3)  AS
BEGIN
	if( Not Exists(Select * From Paises Where CodigoPais = @CodigoPais))
		return -1
	if (Exists(Select * From Pronostico Where CodigoPais=@CodigoPais))
		return -2
	Begin
	--Baja,no hay dependecias
	begin transaction
	Delete From Ciudades WHERE CodigoPais = @CodigoPais
	If (@@ERROR <> 0)
		begin
			rollback 
			return -3
		end
	delete from Paises where CodigoPais = @CodigoPais
	if (@@ERROR<>0)
	begin
		Rollback
		return -4
	end
	
	commit
		return 1
	END
END
GO
-------------------------------------------------------------------------------
CREATE PROC ModificarPais @CodigoPais varchar(3),@NombrePais varchar(20) AS
BEGIN
	if(not Exists(Select * From Paises Where CodigoPais = @CodigoPais))
		return -1
	Else
		Begin
			Update Paises
			Set NombrePais=@NombrePais 
			Where CodigoPais=@CodigoPais
			If (@@ERROR = 0)
				return 1
			Else
				return -2
		End
END
GO
--------------------------------------------------------------------------------
Create PROC BuscarPais @CodigoPais varchar(3) as
BEGIN
	SELECT NombrePais
	FROM Paises
	WHERE CodigoPais=@CodigoPais
END
GO
---------------------------------------------------------------------------------
CREATE PROC ListarPaises as
BEGIN
	SELECT * FROM Paises
END
GO
---------------------------------------------------------------------------------
--Ciudades-----------------------------------------------------------------------
---------------------------------------------------------------------------------
create PROC AltaCiudad @CodigoPais varchar(3),@CodigoCiudad varchar(3),@NombreCiudad varchar(20) AS
BEGIN
if ((LEN (@CodigoCiudad)=3))and (@CodigoCiudad) like'[a-z][a-z][a-z]'
BEGIN
	if (not Exists(Select * From Paises Where CodigoPais = @CodigoPais))
		return -1
	if (Exists(Select * From Ciudades  Where CodigoPais=@CodigoPais and CodigoCiudad=@CodigoCiudad))
		return -2
begin		
	Insert Ciudades(CodigoPais, CodigoCiudad, NombreCiudad) values(@CodigoPais,@CodigoCiudad,@NombreCiudad)
	If (@@ERROR <> 0)
		return -3
	else
		return 1	
END
end
end
GO
---------------------------------------------------------------------------------
create PROC BajaCiudad @CodigoPais varchar(3),@CodigoCiudad varchar(3) as
BEGIN
	if (Not Exists(Select * From Ciudades Where  CodigoCiudad= @CodigoCiudad ))
		return -1		
	BEGIN
		BEGIN TRANSACTION
		Delete From Pronostico WHERE CodigoPais=@CodigoPais and CodigoCiudad=@CodigoCiudad
			If (@@ERROR <> 0)
				begin
					rollback 
					return -2
				END
		DELETE from Ciudades where CodigoPais = @CodigoPais and CodigoCiudad=@CodigoCiudad
		if (@@ERROR<>0)
		begin
			Rollback
			return -3
		end
		
		COMMIT
			return 1
		END
END
GO
---------------------------------------------------------------------------------
CREATE PROC ModificarCiudad
@CodigoPais varchar(3),@CodigoCiudad varchar(3),@NombreCiudad varchar(20) AS
BEGIN
	if (Not Exists(Select * From Ciudades Where CodigoPais = @CodigoPais AND CodigoCiudad=@CodigoCiudad))
		return -1
	Begin
		Update Ciudades
		Set NombreCiudad=@NombreCiudad
		Where CodigoPais=@CodigoPais AND CodigoCiudad=@CodigoCiudad
		If (@@ERROR = 0)
			return 1
		Else
			return --2
	End
END
GO
---------------------------------------------------------------------------------
CREATE PROC BuscarCiudad  @CodigoPais varchar(3),@CodigoCiudad varchar(3) as
BEGIN
	SELECT *
	FROM Ciudades
	WHERE CodigoPais=@CodigoPais AND CodigoCiudad=@CodigoCiudad
END
GO 
---------------------------------------------------------------------------------
CREATE PROC ListarCiudadess as
BEGIN
	SELECT * FROM Ciudades
END
GO
---------------------------------------------------------------------------------
create procedure ListarCiudadesPorPais
@CodigoPais varchar (3)
as
begin
	select *
	from Ciudades
	where CodigoPais = @CodigoPais
end
go
---------------------------------------------------------------------------------
--Pronostico---------------------------------------------------------------------
---------------------------------------------------------------------------------
--AgregarPronostico
create PROC AltaPronostico @CodigoCiudad varchar(3),@CodigoPais varchar(3),@Nombrelogueo varchar(20),@Fecha Date, @Hora Time,@TemperaturaMax int,
							@TemperaturaMin int, @VelocidadViento int, @TipodeCielo varchar(20), @ProbabilidadLluvia int  AS
BEGIN
if (@TemperaturaMax > 0 and @TemperaturaMax < 100) and (@TemperaturaMin > -15 and @TemperaturaMin < 50) and 
(@VelocidadViento >= 0 ) and (@ProbabilidadLluvia >= 0 and @ProbabilidadLluvia < 100)
BEGIN
	if(Not Exists(Select * From Usuario Where NombreLogueo=@Nombrelogueo))
		return -1
	if(Not Exists(Select * From Ciudades Where CodigoPais=@CodigoPais AND CodigoCiudad=@CodigoCiudad))
		return -2
	if ( exists ( select * from Pronostico where CodigoCiudad = @CodigoCiudad and CodigoPais = @CodigoPais 
		and Fecha = @Fecha and Hora = @Hora ))
		return -3
	declare @Error int
	declare @AgregarPronostico int
	
	begin tran
			
	Insert into Pronostico Values (@CodigoCiudad,@CodigoPais,@Nombrelogueo,@Fecha, @Hora,@TemperaturaMax,
							@TemperaturaMin, @VelocidadViento, @TipodeCielo, @ProbabilidadLluvia) 
	set @Error = @@ERROR
	
	if @Error != 0
	begin
		rollback tran
		return -4

	END
	set @AgregarPronostico = IDENT_CURRENT('Pronostico')
	commit tran
	return 1
end
end
GO
---------------------------------------------------------------------------------

create proc ListarPronosticoPorCiudad @CodigoCiudad varchar(3), @CodigoPais varchar (3)
as
Begin
	Select * 
	from Pronostico
	Where Pronostico.CodigoCiudad = @CodigoCiudad and Pronostico.CodigoPais = @CodigoPais
end
go
-----------------------------------------------------------------------------------
create procedure ListarPronosticoPorDia
@Fecha date
as
begin
	select *
	from Pronostico
	where Pronostico.Fecha = @Fecha
end
go
---------------------------------------------------------------------------------
create procedure ListarPronosticoDefault
as
begin
	select *
	from Pronostico
	where Fecha = CONVERT(date, GETDATE()); 
end
go
---------------------------------------------------------------------------------


