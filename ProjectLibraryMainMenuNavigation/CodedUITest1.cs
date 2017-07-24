using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System.Threading;
using ProjectLibraryNavigation;


namespace CodedUITestProject4
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {

        [TestMethod]
        public void Navigation()
        {
            // Calling of Four Level Menu
           // MainMenuNavigation.MenuFilter(MenuNavigation.NavigationMenuItems.Reports, MenuNavigation.NavigationMenuItems.MaterialReports, MenuNavigation.NavigationMenuItems.MaterialSpecificationReport);

            // Calling of Three Level Menu
            MainMenuNavigation.MenuFilter(MenuNavigation.NavigationMenuItems.MasterDataManagement, MenuNavigation.NavigationMenuItems.SpecificationManagement);
        }
    }
}
