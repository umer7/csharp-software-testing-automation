using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestProject
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class Order
    {
        [TestMethod]
        public void FilterOrderManagement()
        {
            UtilityHelpers.Login("http://va24-pd-r340/Hoops/", "a2", "Karachi1");
           // UtilityHelpers.ManageFilterOrder("OrderList1_grid_chkSelect_10", true);
            UtilityHelpers.MenuFilter("Header1_MainMenu_0", "Header1_MainMenu_29", "Header1_MainMenu_30");
            UtilityHelpers.Logoff();
        }

       


    }
}
