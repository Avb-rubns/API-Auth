USE[RUBNS_AUTH]
GO
IF NOT EXISTS (
	SELECT 1
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Users')
BEGIN
CREATE TABLE Users
(
	UserID INT IDENTITY (1,1) NOT NULL CONSTRAINT PK_USERS_ID PRIMARY KEY CLUSTERED (UserID)
	,Name NVARCHAR(100) NOT NULL
	,Email NVARCHAR(100) NOT NULL
	,Password NVARCHAR(MAX) NOT NULL
	,RolID INT NULL DEFAULT (3)
	,Status bit null
)
END
GO
IF NOT EXISTS (
	SELECT 1
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Rols')
BEGIN
CREATE TABLE Rols
(
	RolID INT IDENTITY (1,1) NOT NULL CONSTRAINT PK_Rols_ID PRIMARY KEY CLUSTERED (RolID)
	,Name NVARCHAR(100) NOT NULL
	,Value NVARCHAR(100) NOT NULL
	,LevelPermission INT NOT NULL
	,Status BIT 
)
END
GO
IF OBJECT_ID(N'p_UserByEmail', N'P') IS NOT NULL
    DROP PROCEDURE p_UserByEmail;
GO

CREATE PROCEDURE p_UserByEmail @email NVARCHAR(100)
AS
BEGIN
    SELECT
		usr.UserID
		,usr.Name as UserName
		,Email
		,Password
		,Value
		,LevelPermission
		,Status
    FROM Users as usr
	INNER JOIN Rols as rol on usr.RolID = rol.RolID
    WHERE 
	usr.Email = @email
END
GO
IF NOT EXISTS (
	SELECT 1
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'SessionUsers')
BEGIN
CREATE TABLE SessionUsers
(
	 ID INT IDENTITY (1,1) NOT NULL CONSTRAINT PK_SessionUsers_ID PRIMARY KEY CLUSTERED (ID)
	,UserID INT NOT NULL
	,Token NVARCHAR(MAX) NOT NULL
	,Expiration  DATETIME NOT NULL
	,Registed DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP 
)
END
GO
IF OBJECT_ID(N'p_DeleteSessionUser', N'P') IS NOT NULL
    DROP PROCEDURE DeleteSessionUser;
GO

CREATE PROCEDURE p_DeleteSessionUser @Token NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
	    
		SET XACT_ABORT ON;
		BEGIN TRANSACTION;
		DECLARE @Result INT = 0;

		DELETE FROM SessionUsers WHERE Token = @Token;
		COMMIT TRANSACTION;

		 SET @Result = 1;

	END TRY
	 BEGIN CATCH
        ROLLBACK TRANSACTION;
		SET @Result = -3;
    END CATCH

	SELECT @Result AS Result;
END
GO