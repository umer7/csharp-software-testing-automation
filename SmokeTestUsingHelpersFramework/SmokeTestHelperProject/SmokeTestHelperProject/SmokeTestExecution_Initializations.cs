using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectLibrarySpecManagementGeneral.SpecManagementGeneralClasses;
using ProjectLibraryMaterialModel.ProjectLibraryMaterialModelClasses;
using ProjectLibraryOrderManagement.OrderManagementClasses;
using ProjectLibraryEquipmentModel.ProjectLibraryEquipmentModelClasses;
using ProjectLibraryProcessModel.ProjectLibraryProcessModelClasses;

namespace SmokeTestHelperProject.SmokeTestHelperClasses
{
    [CodedUITest]
    public partial class SmokeTestExecution
    {
        string pomsURL = "http://va24-pd-r4002w/Hoops";
        string MaterialID = "ST_MATL_01";
        string EquipmentID = "ST_Equip";
        string BOMID = "ST_BOM";
        string BOEID = "ST_BOE";
        string ProductID = "ST_Prod";
        string BOPID = "ST_BOP";
        string signOffComments = "Test123";
        string signOffUser = "a1";
        string signOffPassword = "Karachi1.";
        string secondSignOffUser = "w1";
        string secondSignOffPassword = "Karachi123";
        string[] LotContainerIDsReceiving = new string[2];
        string OperationID = "ST_OP";
        string Description = "Smoke Test General Description";
        string PhaseID = "RecordText, Ver. 1.001";
        string UnitProcedureID = "ST_UP";
        string RecipeID = "ST_Recipe";
        string ReceivingWorksheetID = "Receiving";
        string ReceivingWorksheetUnitClass = "Bay1";
        string NumberofContainers = "1";
        string location = "InputArea1";
        bool ReceivingNewLot = true;    
        string ReceivingArea = "Central Dispense";
        string ReceivingQuantity = "100";
        string ReceivingUOM = "g";
        string OrderManagementOrderID = "ST_Order1";
        string OrderManagementQuantity = "100";
        string OrderManagementUOM = "g";
        string OrderManagementBatchID = "ST_Batch1";
        string NewQCStatus = "Conditional Released";
        string DispenseMethod = "Volume Dispense";
        string DispenseRoomCleanStatus = "Complete Clean";
        string UnitWorkListUnitClass = "1000L Bulk Tank";
        string UnitWorkListUnitID = "Bulk A";

        MaterialModel materialModel = new MaterialModel();
        SpecManagementGeneral specManagementGeneral = new SpecManagementGeneral();
        EquipmentModel equipmentModel = new EquipmentModel();
        ProcessModel processModel = new ProcessModel();
        OrderManagement orderManagement = new OrderManagement();

       

        /// <summary>
        /// Constructor
        /// </summary>
        public SmokeTestExecution()
        {

        }

        //[TestInitialize]
        //public void DriverSetup()
        //{
        //    // Code for log in goes here
        //}

        [ClassInitialize]
        public static void CodedUITest1ClassSetup(TestContext _Context)
        {
        }


        //[TestCleanup]
        //public void DriverCleanup()
        //{
        //    // code for log-out goes here
        //}

        //[ClassCleanup]
        //public static void CodedUITestClassCleanup()
        //{ }

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

        //public SmokeTestHelper SmokeTestHelper
        //{
        //    get
        //    {
        //        if ((this.map == null))
        //        {
        //            this.map = new SmokeTestHelper();
        //        }

        //        return this.map;
        //    }
        //}

        //private SmokeTestHelper map;
    }
}