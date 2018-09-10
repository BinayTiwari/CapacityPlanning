  insert into [CPT_ResourceDetails]
  insert into values('624789',1,1,'16',getDate(),getDate()+1)
  insert into [CPT_AllocateResource] values(6,'173962',98,getDate(),getDate()+1,null,null)
  insert into [dbo].[CPT_AllocateResource] values(1,'928828',82,getDate(),getDate()+1,1,0)
  insert into [dbo].[CPT_EmailTemplate] values(5,'ForgetPassword','','ForgetPassword','<div align="justify" style="font-family: Times New Roman;font-size: 11px; ">
<strong>Dear ${NAME}</strong>,&nbsp;
<p>This email was sent automatically by ${FORUMNAME} in response to your request to recover your password. This is done for your protection only you, the recipient of this email can take the next step in the password recover process.</p>
<p>To reset your password and access your account please 
<a href="http://http://rahulgic-001-site1.htempurl.com/ResetPassword.aspx?UID=${UID}"> click here </a><br>
  If you did not forget your password, please ignore this email.</p>
  <p><strong>Best wishes, </strong></p>
  <p>Your ${FORUMNAME} Team</p></div>',1,3,0)

    insert into [dbo].[CPT_EmailTemplate] values(8,'Onboard','','Welcome to GIC','<div align="justify" style="font-family: Times New Roman;font-size: 11px; ">
<strong>Dear All</strong>,&nbsp;
<p>We are pleased to announce that Mr./Mrs {JOINER} has joined us as ${DESIGNATION} 
at ${BASELOCATION} office effective from ${DOJ}.</p> 
  <p><strong>Best wishes, </strong></p>
  <p>Your ${FORUMNAME} Team</p></div>',1,6,0)

  insert into [dbo].[CPT_EmailTemplate] values(7,'AlignedResource',null,'Aligned Resource','<div align="justify" style="font-family: Times New Roman;font-size: 15px; ">
<strong>Dear ${NAME}</strong>,&nbsp;
<p>You have been allocated to ${ACCOUNT} From ${STARTDATE} To ${ENDDATE}.</p>
<p>Contact your project manager for further assistance.</p> 
  <p><strong>Best wishes, </strong></p>
  <p>Your ${FORUMNAME} Team</p></div>',1,5,0)

  insert into [dbo].[CPT_EmailTemplate] values(9,'UpdateResourceDemand','','Resource Demand','<div align="justify" style="font-family: Calibri;font-size: 15px; ">
<strong>Dear <b>${NAME}</b></strong>,&nbsp;
<p>Your resource demand has been updated successfully. Resource Manager will take the next step in the Resource Demand fulfillment process.</p>
<br />
<p>To see the status or make any changes in the resource demand please </p>

<a href="http://rahulgic-001-site1.htempurl.com/ResourceDemand.aspx"> <b>click here<b> </a><br>
  <p><b>Warm Regards, </b></p>
  <p><b>Team ${FORUMNAME}</b></p>
  <p><h6>This email is system generated, please do not respond to this email.</h6></P>
  </div>',1,7,0)

    insert into [dbo].[CPT_EmailTemplate] values(11,'DeployResource','','Deployed on Project','<div align="justify" style="font-family: Calibri;font-size: 15px; ">
<strong>Dear <b>${NAME}</b></strong>,&nbsp;
<p>You have been deployed on <b>${PROJECT}</b>(${PROCESS}) From <b>${STARTDATE}</b> To <b>${ENDDATE}</b>.</p>
<p>Contact your project manager for further assistance.</p>
<br>
<p><b>Warm Regards, </b></p>
<p><b>Team ${FORUMNAME}</b></p>
<p><h6>This email is system generated, please do not respond to this email.</h6></P>
</div>',1,9,0)