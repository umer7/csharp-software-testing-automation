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


namespace ProjectLibraryMaterialModel.ProjectLibraryMaterialModelClasses
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
        public void MaterialModelMethod()
        {

            SetBOMLineItemsParams setMatLineItems = new SetBOMLineItemsParams()
            {
                RefLineNumber = 1,
                Checkin = "Yes",
                MaterialQty = "115",
                Transfer = "No"
            };

            SetBOPLineItemsParams setBOPLines = new SetBOPLineItemsParams()
            {
                RefLineNumber = 1,
                ProductQuantity="100",
                ProductUOM ="kg"
                
            };

            SetMaterialAttributesParams setMatAttribute = new SetMaterialAttributesParams()
            {
                AliquoteStock= "No",
                AssayName = "POTENCY",
                AssayProductionEntry= "Yes",
                AssayQCEntry= "Yes",
                DefaultQuantityStatus= "Released",
                InventoryTracking= "Lot",
                LotLvlUOMConvert= "No",
                InventoryUOM = "g",
                MaterialType="Raw Material",
                ProductType="My Product",
                StorageClass="AMBIENT"
            };

            SetBOMHeaderAttributesParams setBOMAttributes = new SetBOMHeaderAttributesParams()
            {
                BaseQuantity = "100",
                BaseQuantityUOM = "g",
                DispenseToStock = "Yes"
            };

           // this.MaterialModel.AddBOMLineItems(setMatLineItems);
            //this.MaterialModel.SetBOPLineItems(setBOPLines);
            //this.MaterialModel.SetMaterialAttributes(setMatAttribute);
           // this.MaterialModel.SetMaterialAttributesWithAssayClass(setMatAttribute);
            //this.MaterialModel.SetBOMHeaderAttributes(setBOMAttributes);
            this.MaterialModel.SetBOMLineItemsAttributesR400(setMatLineItems);
          //  this.MaterialModel.SaveSpecAndBOXWindow();
           // this.MaterialModel.CloseSpecAndBOXWindow();
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

        public MaterialModel MaterialModel
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new MaterialModel();
                }

                return this.map;
            }
        }

        private MaterialModel map;
    }
}
