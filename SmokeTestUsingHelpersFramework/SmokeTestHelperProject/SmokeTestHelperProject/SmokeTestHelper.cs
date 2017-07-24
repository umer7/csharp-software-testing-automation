namespace SmokeTestHelperProject.SmokeTestHelperClasses
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using ProjectLibraryPhaseExecution.ReceivingPhaseExecutionClasses;
    using ProjectLibraryManageQCStatus;
    using ErrorWritingCodedUI;
    using ProjLibraryMoveMaterial.ProjectLibraryAdHocMoveClasses;
    using ProjectLibraryTransferMaterial;
    using ProjectLibrarySignoff.SignoffClasses;
    using ProjectLibraryExceptions.ExceptionsClasses;
    using ProjectLibraryEquipmentMaintenance.EquipmentMaintenanceClasses;
    using ProjectLibraryConversionFactor.ConversionFactorClasses;
    using ProjectLibraryBatchReScale.BatchRescaleClasses;
    using VolumeDispense;
    using BatchDispenseExecutionClasses;
    using ProjectLibraryReceiving.ReceivingClasses;
    using ProjectLibraryOrderManagement.OrderManagementClasses;
    using ProjectLibraryMaterialAllocation.MaterialAllocationClasses;
    using System.Windows.Forms;
    using ProjectLibraryNavigation;
    using FilterGridCodedUI;
    using POMSnetSmokeTest.OrderManage_BatchExecClasses;
    using Workbook = Microsoft.Office.Interop.Excel.Workbook;
    using Sheet = Microsoft.Office.Interop.Excel.Sheets;
    using Worksheet = Microsoft.Office.Interop.Excel.Worksheet;
    using Application = Microsoft.Office.Interop.Excel._Application;
    using Range = Microsoft.Office.Interop.Excel.Range;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection;
    using POMSnetSmokeTest.EquipmentMangeInvetoryRptClasses;
    using POMSnetSmokeTest.ManageQCStatusClasses;
    using POMSnetSmokeTest.SpecManageOPUPRecClasses;
    using System.IO;
    using System.Diagnostics;
    using POMSnetSmokeTest;
    using PhaseExecution;
    using ProjectLibraryGenerateEBR.GenerateEBRClasses;
    using ProjectLibraryEquipmentWizard.EquipmentWizardClasses;
    using ProjectLibraryEquipmentMaintenance.EquipmentMaintenanceClasses;
    using ProjectLibraryHome;
    
    public partial class SmokeTestHelper
    {
        
        #region Global Variables
        //public static string quantity = "100";
        //public static string orderId = DateTime.Now.ToString("HHmm");
        //public static string batchId = DateTime.Now.ToString("HHmm");
        public static string convert = DateTime.Now.ToString("HHmmHHmm");
        DirectoryInfo dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
        public static string path;
        private static Application application;            
        private static Workbook workbook;
        private static Sheet sheet;
        private static Worksheet worksheet;
        private static Worksheet worksheetresult;
        public static Range find;
        int xlsrow;
        Boolean pomssessionexist;
        #endregion

        public SmokeTestHelper()
        {
            path = Path.Combine(dirInfo.Parent.Parent.Parent.FullName, Assembly.GetExecutingAssembly().GetName().Name, "POMSNetWorksheet.xls");             
        }


        /// <summary>
        /// Create material only
        /// </summary>
        public void CreateMaterial()
        {
            SmokeTest _recDriverObj = new SmokeTest();
            _recDriverObj.MaterialSpecification();
        }

        /// <summary>
        /// Attach a material and create BOM
        /// </summary>
        public void CreateBOM()
        {
            SmokeTest _recDriverObj = new SmokeTest();
            _recDriverObj.BOMCreation();
        }

        /// <summary>
        /// Create Equipment only
        /// </summary>
        public void CreateEquipment()
        {
            SmokeTest _recDriverObj = new SmokeTest();
            _recDriverObj.EquipmentSpecification();
        }

        /// <summary>
        /// Create BOE
        /// </summary>
        public void CreateBOE()
        {
            SmokeTest _recDriverObj = new SmokeTest();
            _recDriverObj.BillOfEquipment();
        }

        /// <summary>
        /// Create product and attach product to a new BOP
        /// </summary>
        public void CreateProdBOP()
        {
            SmokeTest _recDriverObj = new SmokeTest();
            _recDriverObj.CreateValidateProductAndBillOfProduct();
        }

        /// <summary>
        /// Creates Operation, attaches Phases; creates UP and recipe as well
        /// </summary>
        public void CreateRecipe()
        {
            SmokeTest _recDriverObj = new SmokeTest();
            _recDriverObj.PhaseOPUPRecipe();
        }

        /// <summary>
        /// Calls the receiving helper methods
        /// </summary>
        public string[] Recieving()
        {
            string[] LotContainerIDsReceiving = new string[2];

            Receiving receiving = new Receiving();

            LotContainerIDsReceiving = receiving.ReceiveMaterial(new ReceiveMaterialParams
            {
                UnitClass = "Bay1",
                SignoffUser = "Master1",
                SignoffPassword = "oVh+gGDYJsN63xgouiVy6rd+zy3tavV7",
                InnerTextID = "Receiving"
            },
            new ReceiveMaterialPhaseExecutionParams
            {
                MaterialID = "1111",
                NumberofContainers = "1",
                NewLot = true,
                QuantityPerContainer = "100",
                UOM = "g",
                Location = "Any",
                Area = "General Warehouse",
                SignOffUser = "aa1",
                SignOffPassword = "prry0cvvzdA/rNV1TktZgAVrOncH7FRA"
            }, null, null, null, null);

            return LotContainerIDsReceiving;
        }

        /// <summary>
        /// Calls the Order Management helper class
        /// </summary>
        public void OrderManagement()
        {
            OrderManagement _OM = new OrderManagement();
            _OM.CreateOrder(new OrderManagementParams
            {
                OrderID = "ST_Order",
                SignoffUser = "aa1",
                SignoffUserPassword = "prry0cvvzdA/rNV1TktZgAVrOncH7FRA",
                NowDate = true,
                Product = "ST_Product",
                Quantity = "100",
                UOM = "g"
            });

            _OM.CreateNewBatch(new CreateNewBatchParams
            {
                BatchID = "ST_Batch",
                OrderID = "ST_Order",
                Recipe = "ST_Recipe",
                Quantity = "100",
                UOM = "g",
                DateNow = true,
                SignOffUser = "aa1",
                SignOffPassword = "prry0cvvzdA/rNV1TktZgAVrOncH7FRA"
            });

            _OM.ReleaseBatch(new ReleaseBatchParams
            {
                BatchID = "ST_Batch",
                OrderID = "ST_Order",
                SignOffUser = "aa1",
                SignOffPassword = "prry0cvvzdA/rNV1TktZgAVrOncH7FRA"
            });

            _OM.AssignUnit(new AssignUnitParams
            {
                BatchID = "ST_Batch",
                OrderID = "ST_Order",
                numberofSplits = 1,
                SplitCheckBoxChecked = true,
                SplitID = new string[] { "1" },
                UnitID = new string[] { "Incub1" },
                SignoffUser = "aa1",
                SignoffPassword = "prry0cvvzdA/rNV1TktZgAVrOncH7FRA"
            });
        }

        /// <summary>
        /// Calls the Material Allocation helper classes
        /// </summary>
        public void AllocateMaterial()
        {
            MaterialAllocation _MaterialAlloc = new MaterialAllocation();
            _MaterialAlloc.EditAllocations(new MaterialAllocationsParams
            {
                OrderID = "ST_Order"
            });
            _MaterialAlloc.AllocateAllButton();
            Signoff _SignOff = new Signoff();
            _SignOff.SingleSignoff(new SignoffParams
            {
                SignoffUser1 = "aa1",
                SignoffUser1Password = "prry0cvvzdA/rNV1TktZgAVrOncH7FRA"
            });

            // Code for clicking OK goes here
            //BrowserWindow _bwin = new BrowserWindow();
            //Microsoft.VisualStudio.TestTools.UITesting.WinControls.WinButton _OKBUtton = new Microsoft.VisualStudio.TestTools.UITesting.WinControls.WinButton(_bwin);
            //Microsoft.VisualStudio.TestTools.UITesting.WinControls.WinButton _OKBUtton = 
        }

        /// <summary>
        /// Calls the ManageQC Status helper classes
        /// </summary>
        /// <param name="LotContainerIDsReceiving"></param>
        public void ManageQCStatus()
        {
            ManageQCStatusClass _QCStatus = new ManageQCStatusClass();
            _QCStatus.ManageQCStatus(new ManageQCStatusParams
            {
                ContainerID = "0000000052",
                LotID = "L0000000036",
                NewStatus = "Conditional Released",
                RetestDateNotAvailable = true,
                ExpirationDateNotAvailable = true,
                SignOffUser = "aa1",
                SignOffPassword = "prry0cvvzdA/rNV1TktZgAVrOncH7FRA"
            });
        }

        /// <summary>
        /// Calls the dispensing helper classes 
        /// </summary>
        /// <param name="RawMaterialContainerID"></param>
        public void BatchDispense(string RawMaterialContainerID)
        {
            BrowserWindow _Browser = new BrowserWindow();
            HtmlComboBox _SelectUnitForClassBatchDispense = new HtmlComboBox(_Browser);
            HtmlInputButton _BeginWorkSheet = new HtmlInputButton(_Browser);
            HtmlImage _WeighByBatchOP = new HtmlImage(_Browser);

            SelectBatchforDispenseParams BatchDispenseParams = new SelectBatchforDispenseParams
            {
                RoomCleanlinessStatus = "Complete Clean",
                SignOffUser = "aa1",
                SignOffPassword = "prry0cvvzdA/rNV1TktZgAVrOncH7FRA",
                SignOffComment = "Batch Dispense Room Cleaning",
                OrderID = "ST_Order",
                BatchID = "ST_Batch",
                MaterialID = "ST_MATL01",
                SecondSignOffUser = "aa1",
                SecondSignOffPassword = "prry0cvvzdA/rNV1TktZgAVrOncH7FRA",
                RawMaterialContainerID = RawMaterialContainerID,
                DispenseMethod = "Volume Dispense"
            };

            MainMenuNavigation.MenuFilter(MenuNavigation.Dispensing, MenuNavigation.BatchDispense);

            GridHelper _gridHelper = new GridHelper();
            _gridHelper.SelectValueOnGrid("WeighByBatch");

            _SelectUnitForClassBatchDispense.SearchProperties[HtmlComboBox.PropertyNames.Id] = "cmbSelectUnitClass";
            if (_SelectUnitForClassBatchDispense.TryFind())
            {
                _SelectUnitForClassBatchDispense.SelectedItem = "CDS01";
            }

            _BeginWorkSheet.SearchProperties[HtmlInputButton.PropertyNames.Id] = "cmdBeginWorkSheet";
            Mouse.Click(_BeginWorkSheet);

            _WeighByBatchOP.SearchProperties[HtmlImage.PropertyNames.Id] = "obWeighByBatchOp1";
            Mouse.Click(_WeighByBatchOP);

            WeighByBatchDispense _weighByBatchDispense = new WeighByBatchDispense();
            _weighByBatchDispense.CleanUpdateRoomStatus(BatchDispenseParams);

            _weighByBatchDispense.SelectBatchMaterialForBatchDispense(BatchDispenseParams);
            _weighByBatchDispense.VerifyDispenseRoomCleaning(BatchDispenseParams);
            _weighByBatchDispense.VerifyRawMaterialContainerBatch(BatchDispenseParams);
            _weighByBatchDispense.SelectDispenseMethod(BatchDispenseParams);

            VolumeDispenseExecution _VolumeDispense = new VolumeDispenseExecution();
            _VolumeDispense.ExecuteVolumeDispensePhase(new VolumeDispenseExecutionParams
            {
                FirstSignOffUser = "aa1",
                SecondSignOffUser = "aa2",
                FirstSignOffPassword = "prry0cvvzdA/rNV1TktZgAVrOncH7FRA",
                SecondSignOffPassword = "prry0cvvzdA/rNV1TktZgAVrOncH7FRA",
                DispenseQuantity = "100",
                ContainersToLabel = RawMaterialContainerID,
                InterimWeight = "100"
            });
        }

        /// <summary>
        /// Calls the correct history recorded code
        /// </summary>
        public void CorrectHistory()
        {
            SmokeTest _recDriverObj = new SmokeTest();
            _recDriverObj.CorrectHistory();
        }

        /// <summary>
        /// Executes Batch from unit worklist
        /// </summary>
        /// <param name="unitClass"></param>
        /// <param name="unitID"></param>
        /// <param name="_recTempPhaseParam"></param>
        public void BatchExecution(string unitClass,string unitID, RecordTempPhaseParams _recTempPhaseParam)
        {

            this.UnitWorkslistSelection(unitClass, unitID, GridHelper.GridExpressionId.UW_SplitsGrid);
            ExecutePhases _ep = new ExecutePhases();
            _ep.ExecuteRecordTempPhase(_recTempPhaseParam);
        }

        /// <summary>
        /// Use this method to select a batch\split for execution
        /// </summary>
        /// <param name="SelectUnitClass"></param>
        /// <param name="SelectUnitID"></param>
        void UnitWorkslistSelection(string SelectUnitClass, string SelectUnitID, string BatchID)
        {
            #region Variables
            BrowserWindow _Browser = new BrowserWindow();
            HtmlComboBox _SelectUnitClassforBatchExecution = new HtmlComboBox(_Browser);
            HtmlComboBox _SelectUnitID = new HtmlComboBox(_Browser);
            #endregion

            MainMenuNavigation.MenuFilter(MenuNavigation.ProductionExecution, MenuNavigation.UnitWorklist);

            _SelectUnitClassforBatchExecution.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ddlUnitClasses";
            _SelectUnitID.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ddlUnits";
            
            if (SelectUnitClass != null)
            {
                if (_SelectUnitClassforBatchExecution.TryFind())
                {
                    _SelectUnitClassforBatchExecution.SelectedItem = SelectUnitClass;
                }
            }

            if (SelectUnitID != null)
            {
                if (_SelectUnitID.TryFind())
                {
                    _SelectUnitID.SelectedItem = SelectUnitID;
                }
            }

            GridHelper _grid = new GridHelper();
            _grid.ClickLinkOnGrid(BatchID, null, GridHelper.GridExpressionId.UW_SplitsGrid);
        }

        /// <summary>
        /// Close batch using Order management helper
        /// </summary>
        /// <param name="BatchID"></param>
        public void CloseBatch(string BatchID)
        {
            OrderManagement _OM = new ProjectLibraryOrderManagement.OrderManagementClasses.OrderManagement();
            _OM.CloseBatch(new ReleaseBatchParams { BatchID = BatchID });
        }

        /// <summary>
        /// Close exception using helpers
        /// </summary>
        /// <param name="_ExecParams"></param>
        public void CloseException(ExceptionParams _ExecParams)
        {
            Exceptions _Exception = new Exceptions();

            _Exception.ExceptionMain(_ExecParams);
            _Exception.ApproveException(_ExecParams);
            _Exception.RecordException(_ExecParams);
            _Exception.CloseExceptionPage();
        }
        
        /// <summary>
        /// Generates the EBR from Order Management 
        /// </summary>
        public void GenerateEBR()
        {
            GenerateEBR _generateEBR = new GenerateEBR();
            _generateEBR.GenerateEBRReport(new GenerateEBRReportParams {
                OrderID = "ST_Order",
                BatchID = "ST_Batch",
                BatchGridCheckBox = true,
                OrderGridCheckBox = true
            });
        }

        /// <summary>
        /// Executes the equipment wizard functionality
        /// </summary>
        public void EquipmentWizard()
        {
            EquipmentWizard equipmentWizard = new EquipmentWizard();
            equipmentWizard.EquipmentWizardEditEquipment(new EquipmentWizardParams
            {
                EquipmentIDSelectGrid = "SmokeTest_Equipment",
                ListAddEquipment = new string[] { "SmokeTest_Equipment" },
                //ListRemoveEquipment = new string[] { "1Equip" },
                SignoffUser1 = "aa1",
                SignoffUser1Password = "prry0cvvzdAoODYbjKjHSEvtZuiuVPA1",
                Plant = "Herndon",
                Area = "General Warehouse",
                Location = "Any",
                ListStatusType = new string[] { "Availability", "Cleanliness", "Sterility" },
                ListClassName = new string[] { "ST_EQUIP01" }
            });
        }

        /// <summary>
        /// Execute equipment maintainance
        /// </summary>
        public void EquipmentMaintainance()
        {
            EquipmentMaintenance equipmentMaintenance = new EquipmentMaintenance();

            equipmentMaintenance.EquipmentMaintenanceMain(new EquipmentMaintenanceMainParams()
            {
                EquipmentID = "SmokeTest_Equipment",
                SignoffUser1 = "aa1",
                SignoffUser1Password = "prry0cvvzdAoODYbjKjHSEvtZuiuVPA1",
                AvailibilityComboBox = "Available",
                CleanlinessComboBox = "Clean",
                SterilityComboBox = "SIP",
                SignoffComments = "Test"
            });
        }

        public void PomsnetHelp()
        {
            HomeScreen.LoginPOMSnet("http://va24-pd-r4003w/HOOPS/Welcome.aspx", "w1", "Karachi123");
            BrowserWindow _Browser = new BrowserWindow();
            HtmlHyperlink helpHyperlink = new HtmlHyperlink(_Browser);
            helpHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.Id] = "Header1_lnkHelp";
            Mouse.Click(helpHyperlink);
            Playback.Wait(5000);
            BrowserWindow newBrowserWindow = new BrowserWindow();
            newBrowserWindow.SearchProperties[UITestControl.PropertyNames.Name] = "POMSnet KnowledgeWeb";
            newBrowserWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            newBrowserWindow.WindowTitles.Add("POMSnet KnowledgeWeb");
            newBrowserWindow.Close();
        }
    }
}
