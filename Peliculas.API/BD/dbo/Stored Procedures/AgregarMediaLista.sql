create procedure AgregarMediaLista
	@idListaVisualizacion as uniqueidentifier, @idMedia as int, @prioridad as int, @estado as int, @idUsuario as uniqueidentifier
as
begin
	set nocount on;

	begin transaction
		insert into ListaVisualizacion(idListaVisualizacion, idMedia, prioridad, estado, idUsuario) values (@idListaVisualizacion, @idMedia, @prioridad, @estado, @idUsuario);
		select @idListaVisualizacion;
	commit transaction
end