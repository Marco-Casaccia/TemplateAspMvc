using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Common.Entities;


namespace Web.Models.MUSEI
{

    public class MuseiVM
    {
        public MuseiVM()
        {
            this.ListaMusei = new List<Web.Common.Entities.Museo>();
            this.Museo = new Museo();
            this.SelectedMuseo = new Museo();
            this.ListaMacroAree = new List<MacroArea>();
        }
        /// <summary>
        /// Lista utenti
        /// </summary>
        public List<Web.Common.Entities.Museo> ListaMusei { get; set; }

        /// <summary>
        /// Lista macroaree
        /// </summary>
        public List<Web.Common.Entities.MacroArea> ListaMacroAree { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Museo Museo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Museo SelectedMuseo
        {
            get;
            set;
        }
    }
}
