﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using businessLogic;

namespace CapacityPlanning
{
    public partial class ResourcesOnBench : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ResourcesOnBenchBL.ResourcesOnBench(rptDsVsRes);
        }
       
    }
}