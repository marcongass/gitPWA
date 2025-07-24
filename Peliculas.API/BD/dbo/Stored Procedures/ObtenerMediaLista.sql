create procedure ObtenerMediaLista
	@idListaVisualizacion as uniqueidentifier
as
begin
	set nocount on;

	begin transaction
		select idMedia, prioridad, estado from ListaVisualizacion where idListaVisualizacion = @idListaVisualizacion;
	commit transaction
end