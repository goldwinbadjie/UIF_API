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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241211050722_mssql.onprem_migration_273'
)
BEGIN
    CREATE TABLE [Claims] (
        [ClaimId] int NOT NULL IDENTITY,
        [RefID] nvarchar(max) NOT NULL,
        [IDCopy] varbinary(max) NOT NULL,
        [Unemployment] varbinary(max) NOT NULL,
        [MedicalCert] varbinary(max) NOT NULL,
        CONSTRAINT [PK_Claims] PRIMARY KEY ([ClaimId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241211050722_mssql.onprem_migration_273'
)
BEGIN
    CREATE TABLE [Users] (
        [UserId] int NOT NULL IDENTITY,
        [IDNumber] int NOT NULL,
        [MobileNumber] nvarchar(max) NOT NULL,
        [Initials] nvarchar(max) NOT NULL,
        [Surname] nvarchar(max) NOT NULL,
        [AccNo] nvarchar(max) NOT NULL,
        [deviceId] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241211050722_mssql.onprem_migration_273'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241211050722_mssql.onprem_migration_273', N'9.0.0');
END;

COMMIT;
GO

