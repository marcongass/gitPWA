create procedure EliminarFavorito 
	@idFavorito as uniqueidentifier
as
begin
	set nocount on;

	begin transaction
		delete from Favorito where idFavorito = @idFavorito;
		select @idFavorito;
	commit transaction
end