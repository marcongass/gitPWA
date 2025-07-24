create procedure ObtenerFavoritosPorUsuario
	@idUsuario as uniqueidentifier
as
begin
	set nocount on;

	begin transaction
		select idFavorito, idMedia, comentario, puntuacion from Favorito where idUsuario = @idUsuario;
	commit transaction
end