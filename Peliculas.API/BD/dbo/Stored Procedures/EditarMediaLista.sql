create procedure EditarMediaLista
	@idListaVisualizacion as uniqueidentifier, @prioridad as int, @estado as int
as
begin
	set nocount on;

	begin transaction
		update ListaVisualizacion set prioridad = @prioridad, estado = @estado where idListaVisualizacion = @idListaVisualizacion;
		select @idListaVisualizacion;
	commit transaction
end