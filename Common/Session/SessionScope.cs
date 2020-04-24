using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Common.Entities;

namespace Web.Common.Session
{
    public class SessionScope : BaseSessionScope<SessionScope>
    {
        public SessionScope()
        {

        }
        /// <summary>
        /// Utente autenticato sul sistema
        /// </summary>
      
        /// <summary>
        /// Stringa di connessione
        /// </summary>
        public string ConnectionStringSQL
        {
            get;
            set;
        }

        public Object HostData { get; set; }

        

      

        
    }
}
