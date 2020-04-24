using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Common.Entities
{
    /// <summary>
    /// Classe che rappresenta Musei
    /// </summary>
    public class Museo
    {

        public int Id { get; set; }
        public DateTime data_creazione { get; set; }
        public DateTime? data_modifica { get; set; }
        public DateTime? data_cancellazione { get; set; }
        public int id_macroaree { get; set; }
        public string nome { get; set; }
        public string descrizione { get; set; }
        public string zona { get; set; }




    }
}
