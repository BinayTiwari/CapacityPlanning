using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;


namespace businessLogic
{
    public class ResourceMasterBL
    {
        public int Insert( CPT_ResourceMaster resourcedetails)
        {


            using (CPContext db = new CPContext())
            {
                try
                {
                    db.CPT_ResourceMaster.Add(resourcedetails);
                    db.SaveChanges();

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
               
            }
            return 1;


        }

        public int Delete(CPT_ResourceMaster resourceDetails)
        {
            using (CPContext db = new CPContext())
            {

                try
                {

                    CPT_ResourceMaster resourceMaster = new CPT_ResourceMaster();
                    var deleteResourceDetails = from details in db.CPT_ResourceMaster
                                               where details.EmployeeMasterID == resourceDetails.EmployeeMasterID
                                               select details;

                    foreach (var detail in deleteResourceDetails)
                    {
                        
                        db.CPT_ResourceMaster.Remove(detail);
                    }
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }



            }
            return 1;
        }

        public int Update(CPT_ResourceMaster resourceDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = from details in db.CPT_ResourceMaster
                            where details.EmployeeMasterID == resourceDetails.EmployeeMasterID
                            select details;


                foreach (CPT_ResourceMaster detail in query)
                {
                    detail.EmployeeMasterID = resourceDetails.EmployeeMasterID;
                    detail.EmployeetName = resourceDetails.EmployeetName;
                    detail.EmployeePassword = resourceDetails.EmployeePassword;
                    detail.ReportingManagerID= resourceDetails.ReportingManagerID;
                    detail.Email = resourceDetails.Email;
                    detail.BaseLocation = resourceDetails.BaseLocation;
                    detail.Mobile = resourceDetails.Mobile;
                    detail.DesignationID = resourceDetails.DesignationID;
                    detail.RolesID = resourceDetails.RolesID;
                    detail.JoiningDate = resourceDetails.JoiningDate;
                    detail.PriorWorkExperience = resourceDetails.PriorWorkExperience;
                    detail.Address = resourceDetails.Address;
                    detail.PAN = resourceDetails.PAN;
                    detail.PassportNo = resourceDetails.PassportNo;
                    detail.PassportExpiryDate = resourceDetails.PassportExpiryDate;
                    detail.VisaExpiryDate = resourceDetails.VisaExpiryDate;
                    detail.DateOfModification = DateTime.Now;
                    detail.ModifiedBy = resourceDetails.ModifiedBy;
                    
                   



                }


                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }
            return 1;

        }

        public List<CPT_ResourceMaster> uiDataBinding(CPT_ResourceMaster resourceMaster)
        {
            List<CPT_ResourceMaster> data = new List<CPT_ResourceMaster>();
            using (CPContext db = new CPContext())
            {
                var query = from c in db.CPT_ResourceMaster
                            where c.EmployeeMasterID == resourceMaster.EmployeeMasterID
                            select c;
                foreach(var detail in query)
                {
                    
                    data.Add(detail);
                }
            }
            return data;
        }
    }
}
