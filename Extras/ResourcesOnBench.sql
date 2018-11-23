SELECT EmployeeMasterID,EmployeetName,StartDate,EndDate,DesignationName,AccountName,ProcessName,[dbo].[ReportingManagerName]
(ReportingManagerID) As ReportingManager,OnBenchSince,blah FROM (SELECT CPT_ResourceMaster.EmployeeMasterID, CPT_ResourceMaster.EmployeetName, 
ISNULL(CAST(CPT_AllocateResource.StartDate AS VARCHAR(12)), '-') AS StartDate, ISNULL(CAST(CPT_AllocateResource.EndDate As VARCHAR(12)), '-') 
AS EndDate, ReportingManagerID, CPT_AllocateResource.EndDate As testdate, CPT_DesignationMaster.DesignationName, 
ISNULL(CPT_AccountMaster.AccountName, '-') AS AccountName, ISNULL(CPT_ResourceDemand.ProcessName, '-') AS ProcessName,
DATEDIFF(day,CPT_AllocateResource.StartDate,GETDATE()) As OnBenchSince,DATEDIFF(day,GETDATE(),CPT_AllocateResource.EndDate) As blah  FROM 
CPT_AccountMaster INNER JOIN  CPT_AllocateResource ON CPT_AccountMaster.AccountMasterID = CPT_AllocateResource.AccountID INNER JOIN  
CPT_ResourceDemand ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID   RIGHT OUTER JOIN CPT_ResourceMaster INNER JOIN 
CPT_DesignationMaster ON CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID ON CPT_AllocateResource.ResourceID 
= CPT_ResourceMaster.EmployeeMasterID WHERE CPT_ResourceMaster.RolesID NOT IN(1, 4, 5, 8, 15, 20, 26, 25, 28)  AND 
CPT_ResourceMaster.EmployeeMasterID NOT IN(SELECT RESOURCEID FROM CPT_AllocateResource WHERE[CPT_AllocateResource].ISDeployed = 1) 
AND ISDELETED = 0) a INNER JOIN 
(Select ResourceID, Max(EndDate)As EndDatea FROM CPT_AllocateResource Group by ResourceID) b ON a.EmployeeMasterID = b.ResourceID 
AND a.testdate = b.EndDatea 
UNION 
SELECT CPT_ResourceMaster.EmployeeMasterID,CPT_ResourceMaster.EmployeetName,'-' AS StartDate,'-' AS EndDate,CPT_DesignationMaster.DesignationName,
'-' AS AccountName,'-' AS ProcessName, [dbo].[ReportingManagerName](CPT_ResourceMaster.ReportingManagerID) As ReportingManager, 
'-' AS OnBenchSince,'-' AS blah FROM CPT_ResourceMaster INNER JOIN CPT_DesignationMaster ON 
CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID WHERE CPT_ResourceMaster.EmployeeMasterID NOT IN
(SELECT ResourceID FROM CPT_AllocateResource) AND CPT_ResourceMaster.RolesID NOT IN(1, 4, 5, 8, 15, 20, 26, 25, 28) AND ISDELETED = 0