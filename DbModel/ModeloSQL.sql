CREATE TABLE Aluguel (
    [Titulo]            NVARCHAR (100) NOT NULL,
    [Autor]             NVARCHAR (100) NOT NULL,
    [Alugado por]       NVARCHAR (100) NOT NULL,
    [Data de saida]     DATE           NOT NULL,
    [Data de devolução] DATE           NOT NULL,
    [Status]            NVARCHAR (9)   NOT NULL
);
CREATE TABLE Clientes (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Nome completo] NVARCHAR (100) NOT NULL,
    [Endereco]      NVARCHAR (100) NOT NULL,
    [Cidade]        NVARCHAR (100) NOT NULL,
    [Estado]        NVARCHAR (2)   NOT NULL,
    [Cep]           NCHAR (9)      NULL,
    [Telefone1]     NCHAR (18)     NOT NULL,
    [Telefone2]     NCHAR (18)     NULL,
    [Email]         NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
CREATE TABLE Livros (
    [ID]      INT            NOT NULL,
    [Titulo]  NVARCHAR (100) NOT NULL,
    [Autor]   NVARCHAR (100) NOT NULL,
    [Editora] NVARCHAR (100) NOT NULL,
    [Edicao]  NVARCHAR (100) NULL,
    [Ano]     INT            NULL,
    [Genero]  NVARCHAR (100) NULL,
    [ISBN]    NVARCHAR (17)  NULL,
    CONSTRAINT [PK_Livros] PRIMARY KEY CLUSTERED ([ID] ASC)
);
CREATE TABLE Usuarios (
    [ID]      INT           IDENTITY (1, 1) NOT NULL,
    [Usuario] NVARCHAR (50) NOT NULL,
    [Senha]   NVARCHAR (50) NOT NULL,
    [Tipo]    NVARCHAR (3)  NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
INSERT INTO Usuarios(Usuario, Senha, Tipo) VALUES ('admin', 'admin', 'ADM');