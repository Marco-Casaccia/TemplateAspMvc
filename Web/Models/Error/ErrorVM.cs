using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Error
{
    public class ErrorVM
    {
        public ErrorVM()
        {
            this.ErrorDescription = "";
            this.ErrorCode = "";
        }
        public string ErrorDescription { get; set; }
        public string ErrorCode { get; set; }
    }
}