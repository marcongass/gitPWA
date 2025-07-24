create procedure ObtenerListaCompletaPorUsuario
	@idUsuario as uniqueidentifier
as
begin
	set nocount on;

	begin transaction
		select idListaVisualizacion, idMedia, prioridad, estado from ListaVisualizacion where idUsuario = @idUsuario;
	commit transaction
end