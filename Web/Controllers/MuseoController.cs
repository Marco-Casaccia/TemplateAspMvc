using Web.Common.Entities;
using Web.Common.IDataControllers;
using Web.Common.Session;
using Web.Models;
using Web.Models.MUSEI;

 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Classe per il filtro degli events
    /// </summary>
    public class MuseoFilter
    {
        //public int id { get; set; }
        public int IdMacroArea { get; set; }
        public DateTime DataDa { get; set; }
        public DateTime DataAl { get; set; }
        //public int startIndex { get; set; }
        //public int endIndex { get; set; }

    }


    public class MuseoController : Controller
    {
        #region Public Members

        public MuseoController(IMuseoDataControllers museoDataControllers)
        {
            this._museoDataControllers = museoDataControllers;
          
        }
        /// <summary>
        /// <Gestione lista Eventi
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
             
            return View();
            
        }
     
        /// <summary>
        /// Visualizza dettaglio
        /// </summary>
        /// <param name="idMuseo"></param>
        /// <returns></returns>
        public ActionResult Detail(int idMuseo)
        {

            MuseiVM model = new MuseiVM();

            List<MacroArea> macroAree = this._museoDataControllers.GetMacroAree();
            model.ListaMacroAree = macroAree;
            model.SelectedMuseo = this._museoDataControllers.GetMuseo(idMuseo);

            return View("_detail", model);
        }
        
        /// <summary>
        /// Salvataggio
        /// </summary>
        /// <param name="museo"></param>
        public void SaveMuseo(Museo museo)
        {
            this._museoDataControllers.Save(museo);
        }
        /// <summary>
        /// Elimina Museo
        /// </summary>
        /// <param name="idmuseo"></param>
        public void DeleteMuseo(int idmuseo)
        {
            this._museoDataControllers.DeleteMuseo(idmuseo);
        }

     

        /// <summary>
        /// Gestone del filtro degli events
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


            return PartialView("_listMusei", model);

        }

         
        #endregion

        #region Private Members
 
        private IMuseoDataControllers _museoDataControllers
        {
            get;
            set;
        }

        #endregion
    }
}
