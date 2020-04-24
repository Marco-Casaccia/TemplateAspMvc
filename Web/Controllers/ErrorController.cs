using Web.Common.IDataControllers;
using Web.Common.Session;
using Web.Models.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Controllers
{
    public class ErrorController : Controller
    {
		#region PUBLIC MEMBERS
        public ErrorController( 
			)
		{
            
		}
        public ActionResult Index(bool isNotAdmin, bool SessionExpired)
        {
            ErrorVM model = new ErrorVM();
            if (SessionExpired)
            {
                model.ErrorDescription = "401";
                model.ErrorDescription = "Sessione scaduta";
            }
            else if (isNotAdmin)
            {
                model.ErrorDescription = "ACCESS DENIED";
                model.ErrorDescription = "Non si dispongono dei privilegi necessari.";
            }
            return View(model);
        }
        
		#endregion

		#region PRIVATE MEMBERS
        

	
		#endregion
    }
}
