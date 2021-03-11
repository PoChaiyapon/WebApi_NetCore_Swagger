USE [MYDB]
GO

/****** Object:  StoredProcedure [dbo].[SP_Product]    Script Date: 11/3/2021 21:50:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_Product]
@TYPE			nvarchar(20) = NULL,
@Id				INT = NULL,
@Product_code	nvarchar(10) = NULL,
@Product_name	nvarchar(50) = NULL,
@Product_type	nvarchar(20) = NULL,
@Description	nvarchar(100) = NULL,
@Create_date	datetime = NULL,
@Modify_date	datetime = NULL,
@Enable			bit = NULL

AS

IF		@TYPE = 'ADD_PRODUCT'		goto ADD_PRODUCT
ELSE IF @TYPE = 'GET_PRODUCT'		goto GET_PRODUCT
ELSE IF @TYPE = 'UPDATE_PRODUCT'	goto UPDATE_PRODUCT
ELSE IF @TYPE = 'DEL_PRODUCT'		goto DEL_PRODUCT

ADD_PRODUCT:
	if @Product_code is null or @Product_code = ''
		return
	insert into MYDB..Product(Product_code,
							Product_name,
							Product_type,
							Description,
							Create_date,
							Modify_date,
							Enable)
	values (@Product_code, @Product_name, @Product_type, @Description, @Create_date, null, @Enable)
RETURN

GET_PRODUCT:
	IF @Id is NULL or @Id = ''
	begin
		select*from MYDB..Product
	end
	else
	begin
		select*from MYDB..Product where Id = @Id
	end
RETURN

UPDATE_PRODUCT:
	update MYDB..Product
		set Product_name = @Product_name,
			Product_type = @Product_type,
			Description = @Description,
			Modify_date = GETDATE(),
			Enable = @Enable
	where Id = @Id
RETURN

DEL_PRODUCT:
	delete from MYDB..Product where Id =@Id
RETURN

GO


