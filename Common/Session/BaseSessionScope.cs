using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Web.Common.Session
{
    public class BaseSessionScope<T> where T : BaseSessionScope<T>, new()
    {
        public BaseSessionScope()
        {
        }

        public static T Instance
        {
            get
            {
                if (HttpContext.Current.Session["__SessionScope"] == null)
                    HttpContext.Current.Session["__SessionScope"] = new T();
                return (T)HttpContext.Current.Session["__SessionScope"];
            }
        }
    }
}
