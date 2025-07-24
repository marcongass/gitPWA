create procedure EditarFavorito 
	@idFavorito as uniqueidentifier, @comentario as nvarchar(max), @puntuacion as decimal(18,0)
as
begin
	set nocount on;

	begin transaction
		update Favorito set comentario = @comentario, puntuacion = @puntuacion where idFavorito = @idFavorito;
		select @idFavorito;
	commit transaction
end