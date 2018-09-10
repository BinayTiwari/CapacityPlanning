alter table [dbo].[CPT_ResourceMaster] add isMapped real default 0
alter table [CPT_AllocateResource] alter column Utilization default 0

USE [DB_A3EE23_CapacityPlanning]
GO
/****** Object:  UserDefinedFunction [dbo].[Owner]    Script Date: 9/4/2018 11:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[Owner] 
(	
	-- Add the parameters for the function here
	@ResourceRequestBy INT
	

)
RETURNS nvarchar(50)  
AS

BEGIN
	DECLARE @Owner AS nvarchar(50)
	SET @Owner = (select EmployeetName as Owner from CPT_ResourceMaster 
	where CPT_ResourceMaster.EmployeeMasterID=@ResourceRequestBy)

	RETURN @Owner
END

select EmployeetName as Owner from CPT_ResourceMaster 
	where CPT_ResourceMaster.EmployeeMasterID=10161
	
USE [DB_A3EE23_CapacityPlanning]
GO
/****** Object:  UserDefinedFunction [dbo].[TotalResurcesAllocated]    Script Date: 9/4/2018 12:37:40 PM ******/
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
	@RequestDetailID INT

)
RETURNS INT 
AS

BEGIN
	DECLARE @Allocated AS INT
	SET @Allocated = (select  count(CPT_AllocateResource.RoleMasterID) as Allocated from CPT_AllocateResource 
	where CPT_AllocateResource.RequestDetailID=@RequestDetailID and CPT_AllocateResource.RoleMasterID = @RoleID)

	RETURN @Allocated
END


select  count(CPT_AllocateResource.RoleMasterID) as Allocated from CPT_AllocateResource 
	where CPT_AllocateResource.RequestDetailID=277 and CPT_AllocateResource.RoleMasterID = 7	