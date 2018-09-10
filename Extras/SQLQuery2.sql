SELECT        RoleMasterID, AccountID
FROM            CPT_AllocateResource

select COUNT(RoleMasterID) As RoleCount,AccountID FROM CPT_AllocateResource where AccountID=AccountID
 and RoleMasterID=RoleMasterID
group by AccountID order by AccountID

select COUNT(RoleMasterID) As RoleCount FROM CPT_AllocateResource where AccountID=AccountID
group by RoleMasterID order by AccountID

select * from [dbo].[CPT_EmailTemplate] where [Subject] like '%Deploy%' 