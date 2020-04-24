using Web.App_Filters;
using Web.Common.Entities;
using Web.Common.IDataControllers;
using Web.Common.Session;
using Web.DataControllers.DataControllers;
using Web.Models.Admin;
using Web.Models.MUSEI;
 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [AdminActionFilter]
    public class AdminController : Controller
    {
        #region PUBLIC MEMBERS
        public AdminController( IMuseoDataControllers  museoDataControllers   
            )
        {
            this._museoDataControllers = museoDataControllers ;
          
       
        }

        public ActionResult Index()
        {
            return View();
        }

       
        #region Amministrazione Museo
        /// <summary>
        /// <Gestione lista musei
        /// </summary>
        /// <returns></returns>
        public ActionResult MuseiIndex()
        {
            MuseiVM model = new MuseiVM();
            List<MacroArea> macroAree = this._museoDataControllers.GetMacroAree();
            model.ListaMacroAree = macroAree;
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult MuseoAdd()
        {
            ViewBag.Error = TempData["Error"];
            MuseiVM model = new MuseiVM();
            List<MacroArea> macroAree = this._museoDataControllers.GetMacroAree();
            model.ListaMacroAree = macroAree;
            return View(model);
        }


        /// <summary>
        /// Gestone per l'inserimento dei musei
        /// </summary>
        /// <param name="museo"></param>
        /// <returns></returns>
        public PartialViewResult NewMuseo(Museo museo)
        {
            MuseiVM model = new MuseiVM();
  
            model.Museo = this._museoDataControllers.Save(museo);
            model.ListaMusei.Add(model.Museo);
 
            return PartialView("../Museo/_listMusei", model);

        }



        /// <summary>
        /// Gestone del filtro dei musei
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public PartialViewResult FiltroMusei(MuseoFilter filter)
        {
            MuseiVM model = new MuseiVM();

            RequestMuseoFilter request = new RequestMuseoFilter()
            {

                IdMacroArea = filter.IdMacroArea,
                DataDa = filter.DataDa,
                DataAl = filter.DataAl.AddHours(23).AddMinutes(59).AddSeconds(59)

            };

            model.ListaMusei = this._museoDataControllers.GetListMusei(request);


            return PartialView("Museo/_adminMusei", model);

        }

        #endregion
        #endregion

        #region PRIVATE METHODS

         
     

        #endregion

        #region PRIVATE MEMBERS
        
        private IMuseoDataControllers  _museoDataControllers
        {
            get;
            set;
        }

        #endregion
    }
}
