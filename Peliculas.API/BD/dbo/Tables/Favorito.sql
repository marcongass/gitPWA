CREATE TABLE [dbo].[Favorito] (
    [idFavorito] UNIQUEIDENTIFIER NOT NULL,
    [idMedia]    INT              NOT NULL,
    [comentario] VARCHAR (MAX)    NULL,
    [puntuacion] DECIMAL (18)     NULL,
    [idUsuario]  UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([idFavorito] ASC)
);

