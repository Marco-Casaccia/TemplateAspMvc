using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using Web.Models.HOME;
using Web.Common.Entities;
using Web.Common.IDataControllers;
using Web.DataControllers.DataControllers;
using Web.Common.Session;

namespace Web.Controllers
{

    public class HomeController : Controller
    {
        #region PUBLIC MEMBERS
        /// <summary>
        /// Constructor IoC
        /// </summary>
      
        public HomeController()
        {
            
             
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public ActionResult Index()
        {
            
            return View( );
        }
       
        #endregion

        #region PRIVATE MEMBERS
       

        
        #endregion
    }
}
