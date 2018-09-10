update [CPT_ResourceMaster] set skillsid = '25' where skillsid='25,'
update [CPT_ResourceDemand] set PriorityID=27 where
StatusMasterID=19
update [CPT_AllocateResource] set isdeployed = 0 where ResourceID=10344
select * from [dbo].[CPT_AccountMaster] where isactive=1
update [CPT_AllocateResource] set RoleID=7 
 update [dbo].[CPT_EmailTemplate] set Name='ResourceDemand' where Id=5

  update [dbo].[CPT_EmailTemplate] set BccEmailAddresses='binay.tiwari@gridinfocom.com' where Id=5

   update [dbo].[CPT_EmailTemplate] set Subject='Resource Demand' where Id=5

 update [dbo].[CPT_EmailTemplate] set Body='<div align="justify" style="font-family: Calibri;font-size: 15px; ">
<strong>Dear <b>${NAME}</b></strong>,&nbsp;
<p>This email was sent automatically by <b>${FORUMNAME}</b> in response to your request to recover your password. This is done for your protection only you, the recipient of this email can take the next step in the password recover process.</p>
<p>To reset your password and access your account please 
<a href="http://rahulgic-001-site1.htempurl.com/ChangePassword.aspx?UID=${UID}"> <b>click here<b> </a><br>
  <h6>If you did not forget your password, please ignore this email.</h6></p>
  <p><b>Warm Regards, </b></p>
  <p><b>Team ${FORUMNAME}</b></p>
  <p><h6>This email is system generated, please do not respond to this email.</h6></P>
  </div>' where Id=5

   update [dbo].[CPT_EmailTemplate] set Body='<div align="justify" style="font-family: Times New Roman;font-size: 15px; ">
<strong>Dear <b>${NAME}</b></strong>,&nbsp;
<p>This email was sent automatically by <b>${FORUMNAME}</b> in response to your <b>request demand</b>. This is to inform you that request of demand posted succesfully, the recipient of this email can take the next step in the <b>Resource Demand</b> process.</p>
<p>To see the resource demand 
<a href="http://rahulgic-001-site1.htempurl.com/ResourceDemand.aspx"> <b>click here<b> </a><br>
  <h6>If you did not added the request, please ignore this email.</h6></p>
  <p><b>Warm Regards, </b></p>
  <p><b>Team ${FORUMNAME}</b></p>
  <p><h6>This email is system generated, please do not respond to this email.</h6></P>
  </div>' where Id=5

  update [dbo].[CPT_EmailTemplate] set Subject = 'Allocation Details to New Account' where Id=7

   update [dbo].[CPT_EmailTemplate] set Body='<div align="justify" style="font-family: Times New Roman;font-size: 15px; ">
<strong>Dear ${NAME}</strong>,&nbsp;
<p>This is to inform you that Mr./Mrs ${JOINER} has not accepted your offer.</p> 
  <p><strong>Warm Regards, </strong></p>
  <p>Your ${FORUMNAME} Team</p>
  <p><h6>This email is system generated, please do not respond to this email.</h6></P>
  </div>' where Id=6

  update [dbo].[CPT_EmailTemplate] set Body='<div align="justify" style="font-family: Calibri;font-size: 15px; ">
<strong>Dear <b>${NAME}</b></strong>,&nbsp;
<p>You have been deployed on <b>${PROJECT}</b> (${PROCESS}) From <b>${STARTDATE}</b> To <b>${ENDDATE}</b>.</p>
<p>Contact your project manager for further assistance.</p>
<br>
<p><b>Warm Regards, </b></p>
<p><b>Team ${FORUMNAME}</b></p>
<p><h6>This email is system generated, please do not respond to this email.</h6></P>
</div>' where Id=11

  update [dbo].[CPT_AllocateResource] set StartDate = '2018-08-29 12:00:00 AM' where ResourceID=10423

   update [dbo].[CPT_AllocateResource] set enddate = '2018-09-20 12:00:00 AM' where enddate='2018-09-10 12:00:00 AM'
   update [dbo].[CPT_ResourceDetails] set enddate = '2018-09-20 12:00:00 AM' where enddate='2018-09-10 12:00:00 AM'
