 CREATE TABLE Allocation(
	AllocationID [int] primary key IDENTITY(1,1) NOT NULL,
	ResourceID [int] NOT NULL references [CPT_ResourceMaster](EmployeeMasterID),
	RequestID [nvarchar](50) not NULL references [CPT_ResourceDemand](RequestID) ,
	AccountID [int] not NULL references [CPT_AccountMAster](AccountMasterID),
	StartDate [DateTime] not null,
	EndDate [DateTime] not null,
	Utilization [real] not null,
	Released [bit] not null
	)
