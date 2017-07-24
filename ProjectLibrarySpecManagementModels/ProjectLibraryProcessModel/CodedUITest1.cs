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



namespace ProjectLibraryProcessModel.ProjectLibraryProcessModelClasses
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
        public void ProcessModelMethod()
        {
            #region Initializations
            AddBillParams addBillParam = new AddBillParams()
            {
                ObjectName = "00_REC1",
                BillType = "BOE",
                BillId = "Bills",
                LatestCheckBox = true
            };

            SetRecipeAttributesParams setRecAttributes = new SetRecipeAttributesParams()
            {
                ObjectName = "ST_Recipe1",
                RecipeMaximumQty = "1200",
                RecipeTargetQty = "900",
                RecipeMinimumQty = "200",
                RecipeCustomControlAttribute = new string[] { "Yes", "M999093", "g", "Production" }
            };

            SetUPAttibutesParams setUPAttributes = new SetUPAttibutesParams()
            {
                ObjectName = "ST_UP1",
                UPCustomControlAttribute = new string[] { "Yes", "No", "No", "Operator Security", "ProductionOperator", "Verifier Security", "ProductionVerifier", "Alternate Security", "ProductionVerifier", "1000L Bulk Tank" }
            };

            string PhaseID = "RecordText, Ver. 1.001";
            string OperationID = "19922_DisplayWarningOP";
            string VersionID = "Ver. 2.001";

            
            #endregion

           // this.ProcessModel.SetRecipeAttributes(setRecAttributes);
           // this.ProcessModel.AddBills(addBillParam);
            //this.ProcessModel.SetUPAttributes(setUPAttributes);

            this.ProcessModel.SetRecipeAttributes(setRecAttributes);
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

        public ProcessModel ProcessModel
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new ProcessModel();
                }

                return this.map;
            }
        }

        private ProcessModel map;
    }
}
