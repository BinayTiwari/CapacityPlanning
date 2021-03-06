select * from [dbo].[CPT_AllocateResource] where enddate='2018-09-20'
select * from [dbo].[CPT_ResourceDemand]
select * from [dbo].[CPT_ResourceDetails]
select * from [CPT_ResourceDetails]
select * from [dbo].[CPT_CountryMaster]
select * from [dbo].[CPT_EmailTemplate]
select * from [dbo].[CPT_DesignationMaster]
select * from [dbo].[CPT_PriorityMaster]
select * from [dbo].[CPT_StatusMaster]
select * from [dbo].[CPT_SkillsMaster]
select * from [dbo].[CPT_ResourceMaster] where EmployeeMasterID =10381
select * from [dbo].[CPT_NewJoiners]
 where RequestId=370709 
select * from [dbo].[CPT_ResourceDetails] where enddate='2018-09-20'
select * from [dbo].[CPT_RoleMaster]
select * from [dbo].[CPT_DesignationMaster]
select * from [dbo].[CPT_OpportunityMaster]
select * from [dbo].[CPT_SalesStageMaster]
select * from [dbo].[CPT_PriorityMaster]
select SkillID from CPT_ResourceDetails




SELECT        CPT_ResourceMaster.EmployeetName, CPT_ResourceMaster.RolesID,CPT_AllocateResource.ResourceID
FROM            CPT_AllocateResource RIGHT OUTER JOIN
                         CPT_ResourceMaster ON CPT_AllocateResource.ResourceID = CPT_ResourceMaster.EmployeeMasterID
						 Where CPT_ResourceMaster.RolesID = 7 and CPT_ResourceMaster.Skillsid =15
						 AND CPT_ResourceMaster.EmployeeMasterID NOT IN (SELECT       CPT_AllocateResource.ResourceID FROM CPT_AllocateResource WHERE
(CPT_AllocateResource.StartDate BETWEEN '2019-01-31 00:00:00.000' AND  '2020-12-31 00:00:00.000') OR (CPT_AllocateResource.EndDate BETWEEN '2019-01-31 00:00:00.000' AND  '2020-12-31 00:00:00.000'))


SELECT * FROM CPT_AllocateResource
Create function TotalResurcesAllocated




SELECT        CPT_ResourceDetails.ResourceTypeID, CPT_ResourceDetails.RequestID, CPT_RoleMaster.RoleName,
 CPT_SkillsMaster.SkillsName, 
                         CPT_ResourceDetails.NoOfResources,dbo.TotalResurcesAllocated(CPT_RoleMaster.RoleMasterID,301456) As Allocated,  CPT_ResourceDetails.StartDate, CPT_ResourceDetails.EndDate
FROM            CPT_SkillsMaster INNER JOIN
                         CPT_ResourceDetails INNER JOIN
                         CPT_RoleMaster ON CPT_ResourceDetails.ResourceTypeID = CPT_RoleMaster.RoleMasterID ON 
						 CPT_SkillsMaster.SkillsMasterID = CPT_ResourceDetails.SkillID
						  WHERE  CPT_ResourceDetails.RequestID = 301456


						  Select SUM(NoOfResources) As Required FROM CPT_ResourceDetails where RequestID =  417140

						  SELECT COUNT(ROLEID) FROM CPT_AllocateResource WHERE  RequestID =  417140

						  SELECT [dbo].[IsAllResourcesAreMapped](301456) AS IsMapped



SELECT  CPT_ResourceMaster.EmployeeMasterID,CPT_ResourceMaster.EmployeetName, CPT_ResourceMaster.RolesID,CPT_AllocateResource.ResourceID,CPT_ResourceDemand.ProcessName,CPT_ResourceDemand.ResourceRequestedBy
,CPT_AllocateResource.EndDate
                     FROM CPT_AllocateResource RIGHT OUTER JOIN CPT_ResourceMaster ON CPT_AllocateResource.ResourceID = CPT_ResourceMaster.EmployeeMasterID
                     Where CPT_ResourceMaster.RolesID =  7   and CPT_ResourceMaster.Skillsid =  17 AND CPT_ResourceMaster.EmployeeMasterID NOT IN(SELECT CPT_AllocateResource.ResourceID FROM CPT_AllocateResource WHERE 
                     (CPT_AllocateResource.StartDate <='2018-08-01 00:00:00.000' ) OR (CPT_AllocateResource.EndDate >= '2018-09-07 00:00:00.000'))


SELECT CPT_ResourceMaster.EmployeeMasterID,CPT_ResourceMaster.EmployeetName,
CPT_ResourceMaster.RolesID,CPT_AllocateResource.ResourceID,CPT_ResourceDemand.ResourceRequestBy,
CPT_ResourceDemand.ProcessName,dbo.Owner(CPT_ResourceDemand.ResourceRequestBy) as Owner,
 CPT_AllocateResource.EndDate FROM CPT_AllocateResource RIGHT OUTER JOIN CPT_ResourceDemand 
 ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID RIGHT OUTER JOIN
  CPT_ResourceMaster ON CPT_AllocateResource.ResourceID =
   CPT_ResourceMaster.EmployeeMasterID Where CPT_ResourceMaster.RolesID = 7 
     and '16' in (Select CPT_ResourceMaster.Skillsid FROM CPT_ResourceMaster WHERE EmployeeMasterID = EmployeeMasterID) AND CPT_ResourceMaster.EmployeeMasterID NOT 
	 IN(SELECT CPT_AllocateResource.ResourceID FROM CPT_AllocateResource
	  WHERE (CPT_AllocateResource.EndDate >= '2018-09-14'))

	  Select * FROM CPT_ResourceMaster WHere RolesID = 7 Order By EmployeetName
	  
SELECT        CPT_ResourceMaster.EmployeetName, CPT_DesignationMaster.DesignationName, ISNULL(CPT_ResourceDemand.ProcessName,'-') AS ProcessName, ISNULL(CPT_AccountMaster.AccountName,'-') as AccountName, 
                        ISNULL(CAST(CPT_AllocateResource.EndDate AS VARCHAR(11)),'-') as ReleaseDate 
FROM            CPT_ResourceMaster left OUTER JOIN
                         CPT_AllocateResource ON CPT_ResourceMaster.EmployeeMasterID = CPT_AllocateResource.ResourceID left outer JOIN
                         CPT_DesignationMaster ON CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID left outer JOIN
                         CPT_ResourceDemand ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID left outer JOIN
                         CPT_AccountMaster ON CPT_AllocateResource.AccountID = CPT_AccountMaster.AccountMasterID 
						 where CPT_ResourceMaster.RolesID  NOT IN (1,4,8,15,16) 

except

SELECT        CPT_ResourceMaster.EmployeetName, CPT_DesignationMaster.DesignationName, CPT_ResourceDemand.ProcessName, CPT_AccountMaster.AccountName, 
                          CAST(CPT_AllocateResource.EndDate as Varchar(11)) as ReleaseDate
FROM            CPT_ResourceMaster inner JOIN
                         CPT_AllocateResource ON CPT_ResourceMaster.EmployeeMasterID = CPT_AllocateResource.ResourceID inner JOIN
                         CPT_DesignationMaster ON CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID inner JOIN
                         CPT_ResourceDemand ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID inner JOIN
                         CPT_AccountMaster ON CPT_AllocateResource.AccountID = CPT_AccountMaster.AccountMasterID
						 where isDeployed=1


						 and isDeployed=0 order by EmployeetName
						 and Released =1 and isDeployed=0

SELECT        CPT_ResourceMaster.EmployeetName,CPT_ResourceDemand.ProcessName, CPT_AllocateResource.EndDate,[dbo].[Owner](10161) as Owner
FROM            CPT_AllocateResource RIGHT OUTER JOIN
                         CPT_ResourceDemand ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID RIGHT OUTER JOIN
                         CPT_ResourceMaster ON CPT_AllocateResource.ResourceID = CPT_ResourceMaster.EmployeeMasterID
						 Where CPT_ResourceMaster.RolesID =  7   and CPT_ResourceMaster.Skillsid =  17 AND CPT_ResourceMaster.EmployeeMasterID NOT IN(SELECT CPT_AllocateResource.ResourceID FROM CPT_AllocateResource WHERE 
                     (CPT_AllocateResource.EndDate >='2018-07-01 00:00:00.000' )) OR (CPT_AllocateResource.EndDate >= '2018-09-07 00:00:00.000'))


[dbo].[Owner]



SELECT  CPT_ResourceMaster.EmployeeMasterID,CPT_ResourceMaster.EmployeetName, CPT_ResourceMaster.RolesID,CPT_AllocateResource.ResourceID,CPT_ResourceDemand.ProcessName,dbo.Owner(CPT_ResourceDemand.ResourceRequestedBy)
,CPT_AllocateResource.EndDate
                     FROM CPT_AllocateResource RIGHT OUTER JOIN CPT_ResourceMaster ON CPT_AllocateResource.ResourceID = CPT_ResourceMaster.EmployeeMasterID
                     Where CPT_ResourceMaster.RolesID =  7   and CPT_ResourceMaster.Skillsid =  17 AND CPT_ResourceMaster.EmployeeMasterID NOT IN(SELECT CPT_AllocateResource.ResourceID FROM CPT_AllocateResource WHERE 
                     (CPT_AllocateResource.EndDate <='2018-08-01 00:00:00.000' )) OR (CPT_AllocateResource.EndDate >= '2018-09-07 00:00:00.000'))

					  269
					 
					 Select * FROM CPT_ResourceDetails  WHERE RequestID = 159856

					SELECT * FROM  CPT_ResourceDemand

					update CPT_ResourceDemand set StatusMasterID=20 where RequestID=159856
					 Select * FROM CPT_AllocateResource WHERE ResourceID=639437

				--	 Update CPT_AllocateResource SET RequestDetailID = 
					 (Select RequestDetailID FROM CPT_ResourceDetails WHERE RequestID =639437)
					 WHERE RequestID = 639437

					 Select * FROM CPT_AllocateResource Where RequestID = 215709

					Update CPT_AllocateResource SET  RequestDetailID =198 WHERE AllocationID =92
	
	
SELECT        CPT_DesignationMaster.DesignationName, CPT_ResourceMaster.EmployeetName, CPT_DesignationMaster.DesignationMasterID
FROM            CPT_ResourceMaster INNER JOIN
                         CPT_DesignationMaster ON CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID


						 Select * FROM CPT_DesignationMaster
						 16

						 26



Select COUNT(EmployeetName) FROM CPT_ResourceMaster Where DesignationID Not IN(36,37,38,42)

SELECT        CPT_ResourceMaster.EmployeetName, CPT_DesignationMaster.DesignationName, ISNULL(CPT_ResourceDemand.ProcessName,'-') AS ProcessName, ISNULL(CPT_AccountMaster.AccountName,'-') as AccountName, 
                        ISNULL(CAST(CPT_AllocateResource.EndDate AS VARCHAR(11)),'-') as ReleaseDate 
FROM            CPT_ResourceMaster left OUTER JOIN
                         CPT_AllocateResource ON CPT_ResourceMaster.EmployeeMasterID = CPT_AllocateResource.ResourceID left outer JOIN
                         CPT_DesignationMaster ON CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID left outer JOIN
                         CPT_ResourceDemand ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID left outer JOIN
                         CPT_AccountMaster ON CPT_AllocateResource.AccountID = CPT_AccountMaster.AccountMasterID 
						 where CPT_ResourceMaster.RolesID  NOT IN (1,4,8,15,16)
						  group by EmployeetName,DesignationName,
						  ProcessName,AccountName,EndDate
						  and 

						 select COUNT(distinct(EmployeetName)) from CPT_ResourceMaster where CPT_ResourceMaster.RolesID  NOT IN (1,4,8,15,16)

 SELECT [CPT_AccountMaster].[AccountName],[CPT_RoleMaster].[],[CPT_RoleMaster].[RoleName],COUNT([CPT_AllocateResource].[RoleMasterID]) As ResourseNumber
  FROM  CPT_AccountMaster INNER JOIN
        CPT_AllocateResource ON CPT_AccountMaster.AccountMasterID = CPT_AllocateResource.AccountID INNER JOIN
        CPT_RoleMaster ON CPT_AllocateResource.RoleMasterID = CPT_RoleMaster.RoleMasterID
    PIVOT
(
       SUM(ResourseNumber)
       FOR [RoleName] IN (7)
) AS P
  Where [AccountID]  = [AccountID]
  Group by [CPT_AllocateResource].[RoleMasterID],[AccountID],[CPT_RoleMaster].[RoleName],[CPT_AccountMaster].[AccountName]
  ORDER BY [CPT_AccountMaster].[AccountName]


SELECT        CPT_ResourceMaster.EmployeeMasterID AS EmpID, CPT_ResourceMaster.EmployeetName, 
ISNULL(CAST(CPT_AllocateResource.StartDate AS VARCHAR(12)),'-') AS StartDate, ISNULL(CAST(CPT_AllocateResource.EndDate As VARCHAR(12)),'-') EndDate, 
                         CPT_DesignationMaster.DesignationName, ISNULL(CPT_AccountMaster.AccountName,'-') AS AccountName,
						 ISNULL(CPT_ResourceDemand.ProcessName,'-') AS ProcessName
FROM            CPT_AccountMaster INNER JOIN
                         CPT_AllocateResource ON CPT_AccountMaster.AccountMasterID = CPT_AllocateResource.AccountID INNER JOIN
                         CPT_ResourceDemand ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID RIGHT OUTER JOIN
                         CPT_ResourceMaster INNER JOIN
                         CPT_DesignationMaster ON CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID ON 
                         CPT_AllocateResource.ResourceID = CPT_ResourceMaster.EmployeeMasterID
WHERE DesignationID Not IN(36,37,38,42) ORDER BY CPT_ResourceMaster.EmployeetName


With Employees AS
  (
  SELECT [CPT_AccountMaster].[AccountName],[CPT_RoleMaster].[RoleName],COUNT([CPT_AllocateResource].[RoleMasterID]) As ResourseNumber
  FROM  CPT_AccountMaster INNER JOIN
        CPT_AllocateResource ON CPT_AccountMaster.AccountMasterID = CPT_AllocateResource.AccountID INNER JOIN
        CPT_RoleMaster ON CPT_AllocateResource.RoleMasterID = CPT_RoleMaster.RoleMasterID
  Where [AccountID]  = [AccountID]
  Group by [CPT_AllocateResource].[RoleMasterID],[CPT_RoleMaster].[RoleName],[CPT_AccountMaster].[AccountName]
  )
  Select [AccountName],[Human Resource],[Administrator],[Head Of Delivery],[Project Manager],[Developer],[Account Manager],[Team Lead],[Quality Control],[Architect],[Senior Developer],[Business Analyst],[Requestor],[Super Admin],[Head Business Analyst] from Employees
  pivot
  (
        SUM([ResourseNumber])
        FOR [RoleName]
        IN ([Human Resource],[Administrator],[Head Of Delivery],[Project Manager],[Developer],[Account Manager],[Team Lead],[Quality Control],[Architect],[Senior Developer],[Business Analyst],[Requestor],[Super Admin],[Head Business Analyst])
  )
  as pivotTable

SELECT CPT_ResourceMaster.EmployeeMasterID,CPT_ResourceMaster.EmployeetName,
CPT_RoleMaster.RoleName,CPT_ResourceDemand.ResourceRequestBy,
CPT_ResourceDemand.ProcessName,dbo.Owner(CPT_ResourceDemand.ResourceRequestBy) as Owner,
 CPT_AllocateResource.EndDate FROM CPT_AllocateResource RIGHT OUTER JOIN CPT_ResourceDemand 
 ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID RIGHT OUTER JOIN
  CPT_ResourceMaster ON CPT_AllocateResource.ResourceID =
   CPT_ResourceMaster.EmployeeMasterID
   INNER JOIN CPT_RoleMaster ON CPT_ResourceMaster.RolesID = CPT_RoleMaster.RoleMasterID
    Where  
    CPT_ResourceMaster.EmployeeMasterID NOT 
	 IN(SELECT CPT_AllocateResource.ResourceID FROM CPT_AllocateResource
	  WHERE (CPT_AllocateResource.EndDate >= '2018-09-06')) and
	  CPT_ResourceMaster.DesignationID NOT IN (36,37,38,42)

SELECT        CPT_ResourceMaster.EmployeetName, CPT_DesignationMaster.DesignationName,ISNULL(AccountName,'-') As AccountName ,
ISNULL(ProcessName,'-') As ProcessName, ISNULL(CAST(ReleaseDate AS VARCHAR(11)),'-') AS ReleaseDate
FROM            CPT_DesignationMaster INNER JOIN
                         CPT_ResourceMaster ON CPT_DesignationMaster.DesignationMasterID = CPT_ResourceMaster.DesignationID LEFT OUTER JOIN
                         CPT_AllocateResource ON CPT_ResourceMaster.EmployeeMasterID = CPT_AllocateResource.ResourceID
				LEFT OUTER JOIN	ResourcesOnBench	 ON CPT_ResourceMaster.EmployeeMasterID = ResourcesOnBench.ResourceID

					 WHERE CPT_ResourceMaster.DesignationID NOT IN (36,37,38,42) AND  CPT_AllocateResource.IsDeployed = 1






				SELECT     TOP 1 CPT_AllocateResource.AllocationID , CPT_AllocateResource.ResourceID  
                      , CPT_AllocateResource.EndDate As ReleaseDate,
                        CPT_AccountMaster.AccountName, CPT_ResourceDemand.ProcessName
                         
FROM            CPT_AllocateResource INNER JOIN
                         CPT_ResourceDemand ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID INNER JOIN
                         CPT_AccountMaster ON CPT_AllocateResource.AccountID = CPT_AccountMaster.AccountMasterID


WHERE        (CPT_AllocateResource.ResourceID = 10315)
ORDER BY CPT_AllocateResource.EndDate




With Employees AS
  (
  SELECT [CPT_AccountMaster].[AccountName],[CPT_RoleMaster].[RoleName],COUNT([CPT_AllocateResource].[RoleMasterID]) As ResourseNumber
  FROM  CPT_AccountMaster INNER JOIN
        CPT_AllocateResource ON CPT_AccountMaster.AccountMasterID = CPT_AllocateResource.AccountID INNER JOIN
        CPT_RoleMaster ON CPT_AllocateResource.RoleMasterID = CPT_RoleMaster.RoleMasterID
  Where [AccountID]  = [AccountID] AND [CPT_RoleMaster].RoleMasterID NOT IN (1,4,5,8,15,16,20) AND [CPT_AllocateResource].ISDeployed = 1
  Group by [CPT_AllocateResource].[RoleMasterID],[CPT_RoleMaster].[RoleName],[CPT_AccountMaster].[AccountName]
  )
  Select [AccountName],ISNULL([Project Manager],0) AS ProjectManager,ISNULL([Developer],0) AS Developer,ISNULL([Team Lead],0) As TeamLead ,ISNULL([Quality Control],0) AS QualityControl,ISNULL([Architect],0) AS Architect,ISNULL([Senior Developer],0) As SeniorDeveloper,ISNULL([Business Analyst],0) As BUsinessAnalyst from Employees
  pivot
  (
        SUM([ResourseNumber])
        FOR [RoleName]
        IN ([Project Manager]  ,[Developer],[Team Lead],[Quality Control],[Architect],[Senior Developer],[Business Analyst])
  )
  as pivotTable

  Select * FROM [CPT_RoleMaster] ()


Select RolesID, COUNT(RolesID) AS Total FROM CPT_ResourceMaster Where CPT_ResourceMaster.RolesID  
NOT IN (1,4,8,15,16) GROUP BY RolesID



SELECT DISTINCT EmployeeMasterID,EmployeetName,DesignationName,AccountName,ProcessName,StartDate,EndDate FROM (SELECT  CPT_ResourceMaster.EmployeeMasterID, CPT_ResourceMaster.EmployeetName, 
ISNULL(CAST(CPT_AllocateResource.StartDate AS VARCHAR(12)), '-') AS
 StartDate, ISNULL(CAST(CPT_AllocateResource.EndDate As VARCHAR(12)), '-') 
 EndDate,  CPT_DesignationMaster.DesignationName, ISNULL(CPT_AccountMaster.AccountName, '-') 
 AS AccountName,ISNULL(CPT_ResourceDemand.ProcessName, '-') AS ProcessName 
  FROM CPT_AccountMaster INNER JOIN  CPT_AllocateResource ON
   CPT_AccountMaster.AccountMasterID = CPT_AllocateResource.AccountID 
   INNER JOIN  CPT_ResourceDemand ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID
    RIGHT OUTER JOIN  CPT_ResourceMaster INNER JOIN 
	 CPT_DesignationMaster ON CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID ON 
	  CPT_AllocateResource.ResourceID = CPT_ResourceMaster.EmployeeMasterID  
	  WHERE CPT_ResourceMaster.RolesID  NOT IN (1,4,8,15,16)  
	 ) AS a    ORDER BY EmployeetName, EmployeeMasterID


	 select * from [dbo].[ResourcesOnBench]

	 select * from [dbo].[CPT_AllocateResource] where AllocationID=129  
	 
	 SELECT        RoleMasterID, AccountID
FROM            CPT_AllocateResource

select COUNT(RoleMasterID) As RoleCount,AccountID FROM CPT_AllocateResource where AccountID=AccountID
 and RoleMasterID=RoleMasterID
group by AccountID order by AccountID

select COUNT(RoleMasterID) As RoleCount FROM CPT_AllocateResource where AccountID=AccountID
group by RoleMasterID order by AccountID

select * from [dbo].[CPT_EmailTemplate] where [Subject] like '%Deploy%' 

SELECT 
    [Extent1].[EmployeeMasterID] AS [EmployeeMasterID], 
    [Extent1].[Photo] AS [Photo], 
    [Extent1].[EmployeetName] AS [EmployeetName], 
    [Extent1].[ReportingManagerID] AS [ReportingManagerID], 
    [Extent1].[Email] AS [Email], 
    [Extent1].[EmployeePassword] AS [EmployeePassword], 
    [Extent1].[BaseLocation] AS [BaseLocation], 
    [Extent1].[Mobile] AS [Mobile], 
    [Extent1].[DesignationID] AS [DesignationID], 
    [Extent1].[RolesID] AS [RolesID], 
    [Extent1].[JoiningDate] AS [JoiningDate], 
    [Extent1].[PriorWorkExperience] AS [PriorWorkExperience], 
    [Extent1].[PAN] AS [PAN], 
    [Extent1].[Skillsid] AS [Skillsid], 
    [Extent1].[Address] AS [Address], 
    [Extent1].[PassportNo] AS [PassportNo], 
    [Extent1].[PassportExpiryDate] AS [PassportExpiryDate], 
    [Extent1].[VisaExpiryDate] AS [VisaExpiryDate], 
    [Extent1].[DateOfCreation] AS [DateOfCreation], 
    [Extent1].[DateOfModification] AS [DateOfModification], 
    [Extent1].[CreatedBy] AS [CreatedBy], 
    [Extent1].[ModifiedBy] AS [ModifiedBy], 
    [Extent1].[LastLogin] AS [LastLogin], 
    [Extent1].[isMapped] AS [isMapped]
    FROM [dbo].[CPT_ResourceMaster] AS [Extent1]