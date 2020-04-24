using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Common.Entities
{
    /// <summary>
    /// Classe che rappresenta il ruolo nel sistema
    /// </summary>
    public class MacroArea
    {
        public long id { get; set; }
        public string zona { get; set; }
        public DateTime data_creazione { get; set; }
        public DateTime data_modifica { get; set; }
        public DateTime? data_cancellazione { get; set; }
    }
}
