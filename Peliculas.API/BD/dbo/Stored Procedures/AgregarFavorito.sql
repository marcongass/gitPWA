--comment

create procedure AgregarFavorito 
	@idFavorito as uniqueidentifier, @idMedia as int, @comentario as nvarchar(max), @puntuacion as decimal(18,0), @idUsuario as uniqueidentifier
as
begin
	set nocount on;

	begin transaction
		insert into Favorito(idFavorito, idMedia, comentario, puntuacion, idUsuario) values (@idFavorito, @idMedia, @comentario, @puntuacion, @idUsuario);
		select @idFavorito;
	commit transaction
end