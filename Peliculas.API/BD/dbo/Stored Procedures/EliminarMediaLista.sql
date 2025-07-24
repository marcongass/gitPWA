create procedure EliminarMediaLista
	@idListaVisualizacion as uniqueidentifier
as
begin
	set nocount on;

	begin transaction
		delete from ListaVisualizacion where idListaVisualizacion = @idListaVisualizacion;
		select @idListaVisualizacion;
	commit transaction
end