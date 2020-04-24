using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Common.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestDataControllerBase
    {
        public string ConnectionString { get; set; }
    }

    /// <summary>
    /// Request filtro ricerca events
    /// </summary>
    public class RequestEventFilter : RequestDataControllerBase
	{
		public int IdUser { get; set; }
		public int IdEventType { get; set; }
		public DateTime? DataDa { get; set; }
		public DateTime? DataAl { get; set; }
		public int startIndex { get; set; }
		public int endIndex { get; set; }
		public int PageSize { get; set; }
		public int Page { get; set; }


	

	}
    public class RequestMuseoFilter  
    {
        public int Id { get; set; }
        //public int IdEventType { get; set; }
         public int IdMacroArea { get; set; }
        public DateTime? DataDa { get; set; }
        public DateTime? DataAl { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }

    }
}
