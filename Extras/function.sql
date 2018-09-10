USE [DB_A3EE23_CapacityPlanning]
GO
/****** Object:  UserDefinedFunction [dbo].[TotalResurcesAllocated]    Script Date: 8/31/2018 2:26:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER FUNCTION [dbo].[TotalResurcesAllocated] 
(	
	-- Add the parameters for the function here
	@RoleID INT, 
	@RequestID INT

)
RETURNS INT 
AS

BEGIN
	DECLARE @Allocated AS INT
	SET @Allocated = (select  count(CPT_AllocateResource.RoleMasterID) as Allocated from CPT_AllocateResource 
	where CPT_AllocateResource.RequestID=@RequestID and CPT_AllocateResource.RoleMasterID = @RoleID)

	RETURN @Allocated
END



