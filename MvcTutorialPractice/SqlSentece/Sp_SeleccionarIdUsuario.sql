USE [MvcPractice]
GO
/****** Object:  StoredProcedure [dbo].[Sp_SeleccionarIdUsuario]    Script Date: 06/02/2019 11:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_SeleccionarIdUsuario] 
       (
            @UserName VARCHAR(50),
            @Password VARCHAR(50)
       )
AS
BEGIN

SET NOCOUNT ON;
              SELECT Id FROM Usuario WHERE UserName = @UserName AND Password = @Password;
END ;