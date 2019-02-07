USE [MvcPractice]
GO
/****** Object:  StoredProcedure [dbo].[Sp_InsertarUsuario]    Script Date: 06/02/2019 11:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_InsertarUsuario] 
       (
            @UserName VARCHAR(50),
            @Password VARCHAR(50)
       )
AS
BEGIN

SET NOCOUNT ON;

        INSERT INTO Usuario (UserName, Password) 
        VALUES  (@UserName, @Password);

END ;