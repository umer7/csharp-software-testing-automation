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


namespace ProjectLibraryEquipmentModel.ProjectLibraryEquipmentModelClasses
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
        public void EquipmentModelMethod()
        {
            SetEquipmentAttributesParams setEquipmentAttributes = new SetEquipmentAttributesParams()
            {
                CapacityMax = "10",
                CapacityMin = "5",
                CapacityUOM = "g",
                Moveable = "Yes",
                Type = "Scale"
            };

           
            SetBOELineItemsAttributesParams bOELineItemsAttributesParams = new SetBOELineItemsAttributesParams()
            {
                RefLineNumber = 1,
                PreCheckIn = "Allowed",
                QuantityRequired = "10",
                ScalingRule = "Fixed"
            };

            SetEquipmentStatusAttributesParams setEquipmentStatusAttributesParams = new SetEquipmentStatusAttributesParams()
            {
                CleanlinessDefaultStatus = "Clean"
            };

            this.EquipmentModel.SetBOELineItemsAttributes(bOELineItemsAttributesParams);
            //this.EquipmentModel.SetEquipmentAttributes(setEquipmentAttributes);
            //this.EquipmentModel.CreateNewLineItem(newLineItemParams);

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

        public EquipmentModel EquipmentModel
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new EquipmentModel();
                }

                return this.map;
            }
        }

        private EquipmentModel map;
    }
}
