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

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [Breed] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Cats] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [BirthDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Cats] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Countries] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Reviewers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Reviewers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [CatCategories] (
    [CatId] int NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_CatCategories] PRIMARY KEY ([CatId], [CategoryId]),
    CONSTRAINT [FK_CatCategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CatCategories_Cats_CatId] FOREIGN KEY ([CatId]) REFERENCES [Cats] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Owners] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [BirthDate] datetime2 NOT NULL,
    [CountryId] int NOT NULL,
    CONSTRAINT [PK_Owners] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Owners_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Reviews] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Text] nvarchar(max) NOT NULL,
    [ReviewerId] int NOT NULL,
    [CatId] int NOT NULL,
    CONSTRAINT [PK_Reviews] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Reviews_Cats_CatId] FOREIGN KEY ([CatId]) REFERENCES [Cats] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reviews_Reviewers_ReviewerId] FOREIGN KEY ([ReviewerId]) REFERENCES [Reviewers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [CatOwners] (
    [CatId] int NOT NULL,
    [OwnerId] int NOT NULL,
    CONSTRAINT [PK_CatOwners] PRIMARY KEY ([CatId], [OwnerId]),
    CONSTRAINT [FK_CatOwners_Cats_CatId] FOREIGN KEY ([CatId]) REFERENCES [Cats] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CatOwners_Owners_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [Owners] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_CatCategories_CategoryId] ON [CatCategories] ([CategoryId]);
GO

CREATE INDEX [IX_CatOwners_OwnerId] ON [CatOwners] ([OwnerId]);
GO

CREATE INDEX [IX_Owners_CountryId] ON [Owners] ([CountryId]);
GO

CREATE INDEX [IX_Reviews_CatId] ON [Reviews] ([CatId]);
GO

CREATE INDEX [IX_Reviews_ReviewerId] ON [Reviews] ([ReviewerId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230927125745_CatReviewWebAPITables', N'7.0.11');
GO

COMMIT;
GO

