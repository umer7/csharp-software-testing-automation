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
using ProjectLibrarySpecManagementGeneral.SpecManagementGeneralClasses;
using ProjectLibraryNavigation;


namespace ProjectLibrarySpecManagementGeneral.SpecManagementGeneralClasses
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
             #region Initializations
            SpecManagementNavParams navparam1 = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.EquipmentModel,
                ItemName = SpecTreeNode.EquipmentSpecifications,
                Action = SpecTreeNodeActions.New
            };

            SpecManagementNavParams navparam2 = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.MaterialModel,
                ItemName = SpecTreeNode.MaterialSpecifications,
                Action = SpecTreeNodeActions.Find
            };

            SpecManagementGeneralParams specManagementGeneralParams = new SpecManagementGeneralParams()
            {
                ID = "MyItem42",
                Description = "Description",
              EffectivityDateNowCheck = true,
                ItemType = SpecManagementType.EquipmentSpec,
               // ListClasses = new string[] { "Assay","Bulk" }
                ListStatusTypes = new string[] {"Availability", "Cleanliness"}
            };

            FindNewItemParams findNewItemParams = new FindNewItemParams()
            {
                ID = "ST_MATL105",
            };

            ImportObjectParams importObjectParams = new ImportObjectParams()
            {
              BrowseFileName= "C:\\Users\\imammami\\Desktop\\19166_REC.xml"
            };

            SpecManagementNavParams navparam3 = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.ProcessModel,
                ItemName = SpecTreeNode.UnitProcedures,
                Action = SpecTreeNodeActions.New
            };

            #endregion

            //MainMenuNavigation.MenuFilter(MenuNavigation.MasterDataManagement, MenuNavigation.SpecificationManagement);
           //this.SpecManagementGeneral.SpecNav(navparam1);
           // this.SpecManagementGeneral.CreateNewItem(specManagementGeneralParams);
            //this.SpecManagementGeneral.SpecNav(navparam2);
            // this.SpecManagementGeneral.FindNewItem(findNewItemParams);
            this.SpecManagementGeneral.RightClickAction("12345", RightClickActions.Properties);
            // this.SpecManagementGeneral.ImportObject(importObjectParams);

           //this.SpecManagementGeneral.SpecNav(navparam1);
           

        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public SpecManagementGeneral SpecManagementGeneral
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new SpecManagementGeneral();
                }

                return this.map;
            }
        }

        private SpecManagementGeneral map;
    }
}
