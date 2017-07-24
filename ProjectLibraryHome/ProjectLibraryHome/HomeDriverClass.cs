using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibraryHome
{
    public class HomeDriver
    {
         public HomeDriver()
        {
        }

         [TestMethod]
         public void RecordValueAuthorTestMethod()
         {
             HomeScreen.LoginPOMSnet("","","");

         }
    }
}
