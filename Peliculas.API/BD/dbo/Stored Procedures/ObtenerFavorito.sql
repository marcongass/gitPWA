create procedure ObtenerFavorito
	@idFavorito as uniqueidentifier
as
begin
	set nocount on;

	begin transaction
		select idMedia, comentario, puntuacion from Favorito where idFavorito = @idFavorito;
	commit transaction
end