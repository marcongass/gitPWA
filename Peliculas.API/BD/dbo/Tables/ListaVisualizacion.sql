CREATE TABLE [dbo].[ListaVisualizacion] (
    [idListaVisualizacion] UNIQUEIDENTIFIER NOT NULL,
    [idMedia]              INT              NOT NULL,
    [prioridad]            INT              NULL,
    [estado]               INT              NULL,
    [idUsuario]            UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([idListaVisualizacion] ASC)
);

