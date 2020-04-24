using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.DataControllers.DataControllers;
using Web.Common.Entities;

namespace WebServices.UnitTest
{
    [TestClass]
    public class MuseiTest
    {
        [TestMethod]
        public void GetMusei()
        {
            MuseoDataController datacontroller = new MuseoDataController();
             
          
            DateTime data = new DateTime(2020, 4, 20);
            RequestMuseoFilter request = new RequestMuseoFilter()
            {

                IdMacroArea = 1,
                DataDa = data,
                DataAl = data.AddHours(23).AddMinutes(59).AddSeconds(59)

            };

            var musei = datacontroller.GetListMusei(request);
        }
    }
}
