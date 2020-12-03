
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/02/2020 17:47:11
-- Generated from EDMX file: C:\Users\User\source\repos\Gestionex\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [gestionex];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProveedoresMarcas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Marcas] DROP CONSTRAINT [FK_ProveedoresMarcas];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartamentosEmpleados]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empleados] DROP CONSTRAINT [FK_DepartamentosEmpleados];
GO
IF OBJECT_ID(N'[dbo].[FK_UnidadMedidaArticulos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT [FK_UnidadMedidaArticulos];
GO
IF OBJECT_ID(N'[dbo].[FK_MarcasArticulos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT [FK_MarcasArticulos];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticulosSolicitudArticulos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SolicitudArticulos] DROP CONSTRAINT [FK_ArticulosSolicitudArticulos];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpleadosSolicitudArticulos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SolicitudArticulos] DROP CONSTRAINT [FK_EmpleadosSolicitudArticulos];
GO
IF OBJECT_ID(N'[dbo].[FK_SolicitudArticulosOrdenCompra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenCompras] DROP CONSTRAINT [FK_SolicitudArticulosOrdenCompra];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Proveedores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedores];
GO
IF OBJECT_ID(N'[dbo].[Marcas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Marcas];
GO
IF OBJECT_ID(N'[dbo].[Articulos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articulos];
GO
IF OBJECT_ID(N'[dbo].[Departamentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departamentos];
GO
IF OBJECT_ID(N'[dbo].[Empleados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empleados];
GO
IF OBJECT_ID(N'[dbo].[SolicitudArticulos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SolicitudArticulos];
GO
IF OBJECT_ID(N'[dbo].[UnidadMedidas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UnidadMedidas];
GO
IF OBJECT_ID(N'[dbo].[OrdenCompras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrdenCompras];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Proveedores'
CREATE TABLE [dbo].[Proveedores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cedula] nvarchar(max)  NOT NULL,
    [NombreComercial] nvarchar(max)  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'Marcas'
CREATE TABLE [dbo].[Marcas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [ProveedoresId] int  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'Articulos'
CREATE TABLE [dbo].[Articulos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Existencia] int  NOT NULL,
    [Estado] bit  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [UnidadMedidaId] int  NOT NULL,
    [MarcasId] int  NOT NULL
);
GO

-- Creating table 'Departamentos'
CREATE TABLE [dbo].[Departamentos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'Empleados'
CREATE TABLE [dbo].[Empleados] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cedula] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Estado] bit  NOT NULL,
    [DepartamentosId] int  NOT NULL
);
GO

-- Creating table 'SolicitudArticulos'
CREATE TABLE [dbo].[SolicitudArticulos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Estado] bit  NOT NULL,
    [Cantidad] int  NOT NULL,
    [ArticulosId] int  NOT NULL,
    [EmpleadosId] int  NOT NULL
);
GO

-- Creating table 'UnidadMedidas'
CREATE TABLE [dbo].[UnidadMedidas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'OrdenCompras'
CREATE TABLE [dbo].[OrdenCompras] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NumeroOrden] int  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Estado] bit  NOT NULL,
    [Cantidad] int  NOT NULL,
    [CostoUnitario] float  NOT NULL,
    [SolicitudArticulosId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Proveedores'
ALTER TABLE [dbo].[Proveedores]
ADD CONSTRAINT [PK_Proveedores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Marcas'
ALTER TABLE [dbo].[Marcas]
ADD CONSTRAINT [PK_Marcas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [PK_Articulos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Departamentos'
ALTER TABLE [dbo].[Departamentos]
ADD CONSTRAINT [PK_Departamentos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [PK_Empleados]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SolicitudArticulos'
ALTER TABLE [dbo].[SolicitudArticulos]
ADD CONSTRAINT [PK_SolicitudArticulos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UnidadMedidas'
ALTER TABLE [dbo].[UnidadMedidas]
ADD CONSTRAINT [PK_UnidadMedidas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrdenCompras'
ALTER TABLE [dbo].[OrdenCompras]
ADD CONSTRAINT [PK_OrdenCompras]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProveedoresId] in table 'Marcas'
ALTER TABLE [dbo].[Marcas]
ADD CONSTRAINT [FK_ProveedoresMarcas]
    FOREIGN KEY ([ProveedoresId])
    REFERENCES [dbo].[Proveedores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProveedoresMarcas'
CREATE INDEX [IX_FK_ProveedoresMarcas]
ON [dbo].[Marcas]
    ([ProveedoresId]);
GO

-- Creating foreign key on [DepartamentosId] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [FK_DepartamentosEmpleados]
    FOREIGN KEY ([DepartamentosId])
    REFERENCES [dbo].[Departamentos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartamentosEmpleados'
CREATE INDEX [IX_FK_DepartamentosEmpleados]
ON [dbo].[Empleados]
    ([DepartamentosId]);
GO

-- Creating foreign key on [UnidadMedidaId] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [FK_UnidadMedidaArticulos]
    FOREIGN KEY ([UnidadMedidaId])
    REFERENCES [dbo].[UnidadMedidas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnidadMedidaArticulos'
CREATE INDEX [IX_FK_UnidadMedidaArticulos]
ON [dbo].[Articulos]
    ([UnidadMedidaId]);
GO

-- Creating foreign key on [MarcasId] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [FK_MarcasArticulos]
    FOREIGN KEY ([MarcasId])
    REFERENCES [dbo].[Marcas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MarcasArticulos'
CREATE INDEX [IX_FK_MarcasArticulos]
ON [dbo].[Articulos]
    ([MarcasId]);
GO

-- Creating foreign key on [ArticulosId] in table 'SolicitudArticulos'
ALTER TABLE [dbo].[SolicitudArticulos]
ADD CONSTRAINT [FK_ArticulosSolicitudArticulos]
    FOREIGN KEY ([ArticulosId])
    REFERENCES [dbo].[Articulos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticulosSolicitudArticulos'
CREATE INDEX [IX_FK_ArticulosSolicitudArticulos]
ON [dbo].[SolicitudArticulos]
    ([ArticulosId]);
GO

-- Creating foreign key on [EmpleadosId] in table 'SolicitudArticulos'
ALTER TABLE [dbo].[SolicitudArticulos]
ADD CONSTRAINT [FK_EmpleadosSolicitudArticulos]
    FOREIGN KEY ([EmpleadosId])
    REFERENCES [dbo].[Empleados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadosSolicitudArticulos'
CREATE INDEX [IX_FK_EmpleadosSolicitudArticulos]
ON [dbo].[SolicitudArticulos]
    ([EmpleadosId]);
GO

-- Creating foreign key on [SolicitudArticulosId] in table 'OrdenCompras'
ALTER TABLE [dbo].[OrdenCompras]
ADD CONSTRAINT [FK_SolicitudArticulosOrdenCompra]
    FOREIGN KEY ([SolicitudArticulosId])
    REFERENCES [dbo].[SolicitudArticulos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SolicitudArticulosOrdenCompra'
CREATE INDEX [IX_FK_SolicitudArticulosOrdenCompra]
ON [dbo].[OrdenCompras]
    ([SolicitudArticulosId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------