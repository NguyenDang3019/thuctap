using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace an_phat
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SimpleMembershipInitializer();



        }

            private void SimpleMembershipInitializer()
            {
               
                    if (!WebMatrix.WebData.WebSecurity.Initialized)
                    {
                        WebSecurity.InitializeDatabaseConnection("AnPhatDB", "Users", "ID", "Email", true);  
                    }
                
               
            }
        }
    
          
    }
    

