delete from [CPT_AllocateResource]
delete from [CPT_ResourceDetails] where RequestId=268771
delete from [CPT_ResourceDemand] where processname='Test'
delete from [CPT_ResourceDetails]
delete from [dbo].[CPT_AccountMaster] where IsActive=0
delete from [CPT_PriorityMaster] where PriorityID=30
delete from [CPT_AccountMaster] where isActive=0