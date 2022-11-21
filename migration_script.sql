IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221121014813_Employee_Area_Subarea_Migration')
BEGIN
    CREATE TABLE [Areas] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(255) NOT NULL,
        CONSTRAINT [PK_Areas] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221121014813_Employee_Area_Subarea_Migration')
BEGIN
    CREATE TABLE [Employees] (
        [Id] int NOT NULL IDENTITY,
        [Names] nvarchar(255) NOT NULL,
        [Surnames] nvarchar(255) NOT NULL,
        [DocumentType] nvarchar(3) NOT NULL,
        [Document] nvarchar(255) NOT NULL,
        [Area] nvarchar(255) NOT NULL,
        [Subarea] nvarchar(255) NOT NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221121014813_Employee_Area_Subarea_Migration')
BEGIN
    CREATE TABLE [SubAreas] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(255) NOT NULL,
        [AreaId] int NOT NULL,
        CONSTRAINT [PK_SubAreas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SubAreas_Areas_AreaId] FOREIGN KEY ([AreaId]) REFERENCES [Areas] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221121014813_Employee_Area_Subarea_Migration')
BEGIN
    CREATE INDEX [IX_SubAreas_AreaId] ON [SubAreas] ([AreaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221121014813_Employee_Area_Subarea_Migration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221121014813_Employee_Area_Subarea_Migration', N'5.0.17');
END;
GO

COMMIT;
GO

