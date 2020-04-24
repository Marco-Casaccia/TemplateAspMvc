using Web.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Common.IDataControllers
{
    public interface IMuseoDataControllers
    {
        /// <summary>
        /// Ricerca con filtri 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        List<Museo> GetListMusei(RequestMuseoFilter request);


        /// <summary>
        /// Recupero record relativi alle MascroAree  
        /// </summary>
        /// <returns></returns>
        List<MacroArea> GetMacroAree();

        /// <summary>
        /// Salvataggio
        /// </summary>
        /// <param name="museo"></param>
        /// <returns></returns>
        Museo Save(Museo museo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Museo GetMuseo(int id);

       
        /// <summary>
        /// Elimina Museo
        /// </summary>
        /// <param name="id"></param>
        void DeleteMuseo(int id);

    }
}
