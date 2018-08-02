using System;
using Entity;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace businessLogic
{
    public class ResourceDetailsBL
    {
        public int Insert(CPT_ResourceDetails demandDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    db.CPT_ResourceDetails.Add(demandDetails);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return 1;
        }
    }
}
