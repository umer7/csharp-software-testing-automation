using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System.Threading;


namespace TestProject
{
    /// <summary>
    /// Utlity Helper Class
    /// </summary>
    [CodedUITest]
    public static class UtilityHelpers
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="url"></param>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        public static void Login(string url, string userName, string userPassword)
        {
            BrowserWindow browserWindow = BrowserWindow.Launch(new System.Uri(url));
            browserWindow.WaitForControlReady();

            #region login
            HtmlEdit txtUsername = new HtmlEdit(browserWindow);
            txtUsername.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "txtUsername");
            txtUsername.SetProperty(HtmlEdit.PropertyNames.Text, userName);

            HtmlEdit txtPassword = new HtmlEdit(browserWindow);
            txtPassword.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "txtPassword");
            txtPassword.SetProperty(HtmlEdit.PropertyNames.Text, userPassword);

            HtmlInputButton inputButton = new HtmlInputButton(browserWindow);
            inputButton.SearchProperties.Add(HtmlInputButton.PropertyNames.Id, "XbtnLogin");
            Mouse.Click(inputButton);

            Thread.Sleep(5000);
            #endregion
        }


        /// <summary>
        /// Log Off
        /// </summary>
        public static void Logoff()
        {
            BrowserWindow browserWindow = new BrowserWindow();
            #region logout
            HtmlCustom htmlCustom = new HtmlCustom(browserWindow);
            htmlCustom.SearchProperties.Add(HtmlCustom.PropertyNames.Id, "Header1_lnkLogOff");
            Mouse.Click(htmlCustom);
            browserWindow.PerformDialogAction(BrowserDialogAction.Ok);
            //Thread.Sleep(5000);
            #endregion
        }

        /// <summary>
        /// check the ORder in ORder Management Grid
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="orderCheckBox"></param>
        public static void ManageFilterOrder(string orderNumber, bool orderCheckBox)
        {
            BrowserWindow browserWindow = new BrowserWindow();
            HtmlCell mainMenuCell = new HtmlCell(browserWindow);
            HtmlCell productionPlanninganCell = new HtmlCell(browserWindow);
            HtmlCheckBox orderListCheckBox = new HtmlCheckBox(browserWindow);
            HtmlCell orderManagementCell = new HtmlCell(browserWindow);
            HtmlCell orderCell = new HtmlCell(browserWindow);

            browserWindow.WaitForControlReady(50000);
            // Main Menu
            mainMenuCell.SearchProperties[HtmlCell.PropertyNames.Id] = "Header1_MainMenu_0";
            Mouse.Click(mainMenuCell);

            // Production Planning 
            productionPlanninganCell.SearchProperties[HtmlCell.PropertyNames.Id] = "Header1_MainMenu_29";
            Mouse.Click(productionPlanninganCell);

            // Production Planning  >> Order Mangement
            orderManagementCell.SearchProperties[HtmlCell.PropertyNames.Id] = "Header1_MainMenu_30";            
            Mouse.Click(orderManagementCell);

            browserWindow.WaitForControlReady(50000);            
            orderListCheckBox.SearchProperties[HtmlCheckBox.PropertyNames.Id] = orderNumber;
            browserWindow.WaitForControlReady(50000);
            orderListCheckBox.Checked = orderCheckBox;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainMenu"></param>
        /// <param name="subMenu"></param>
        /// <param name="childMenu"></param>
        public static void MenuFilter(string mainMenu, string subMenu, string childMenu)
        {
            BrowserWindow browserWindow = new BrowserWindow();
            HtmlCell mainMenuCell = new HtmlCell(browserWindow);
            HtmlCell subMenuCell = new HtmlCell(browserWindow);
            HtmlCell childMenuCell = new HtmlCell(browserWindow);
            HtmlCell childSubMenuCell = new HtmlCell(browserWindow);

            browserWindow.WaitForControlReady(50000);
            // Main Menu
            mainMenuCell.SearchProperties[HtmlCell.PropertyNames.Id] = mainMenu;
            Mouse.Click(mainMenuCell);

            // Sub Menu 
            subMenuCell.SearchProperties[HtmlCell.PropertyNames.Id] = subMenu;
            Mouse.Click(subMenuCell);

            // Child Menu
            childMenuCell.SearchProperties[HtmlCell.PropertyNames.Id] = childMenu;
            Mouse.Click(childMenuCell);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainMenu"></param>
        /// <param name="subMenu"></param>
        /// <param name="childMenu"></param>
        /// <param name="childSubMenu"></param>
        public static void MenuFilter(string mainMenu, string subMenu, string childMenu, string childSubMenu)
        {
            BrowserWindow browserWindow = new BrowserWindow();
            HtmlCell mainMenuCell = new HtmlCell(browserWindow);
            HtmlCell subMenuCell = new HtmlCell(browserWindow);
            HtmlCell childMenuCell = new HtmlCell(browserWindow);
            HtmlCell childSubMenuCell = new HtmlCell(browserWindow);

            browserWindow.WaitForControlReady(50000);
            // Main Menu
            mainMenuCell.SearchProperties[HtmlCell.PropertyNames.Id] = mainMenu;
            Mouse.Click(mainMenuCell);

            // Sub Menu 
            subMenuCell.SearchProperties[HtmlCell.PropertyNames.Id] = subMenu;
            Mouse.Click(subMenuCell);

            // Child Menu
            childMenuCell.SearchProperties[HtmlCell.PropertyNames.Id] = childMenu;
            Mouse.Click(childMenuCell);

            // Child Sub Menu
            childSubMenuCell.SearchProperties[HtmlCell.PropertyNames.Id] = childMenu;
            Mouse.Click(childSubMenuCell);
        }


    }

    
   public static class MenuId
  {
     static string MainMenu = "Header1_MainMenu_0";
     static string ProductionPlanning = "Header1_MainMenu_29";
     static string OrderManagement = "Header1_MainMenu_30";

  }
}
