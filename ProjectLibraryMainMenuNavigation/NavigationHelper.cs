using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System.Threading;


namespace ProjectLibraryNavigation
{
    /// <summary>
    /// Utlity Helper Class
    /// </summary>
    [CodedUITest]
    public static class MainMenuNavigation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainMenu"></param>
        /// <param name="subMenu"></param>
        /// <param name="childMenu"></param>
        public static void MenuFilter(string subMenu, string childMenu)
        {
            BrowserWindow browserWindow = new BrowserWindow();

            //HtmlCell menuCell = new HtmlCell(browserWindow);

            HtmlCell mainMenuCell = new HtmlCell(browserWindow);
            HtmlCell subMenuCell = new HtmlCell(browserWindow);
            HtmlCell childMenuCell = new HtmlCell(browserWindow);
            HtmlCell childSubMenuCell = new HtmlCell(browserWindow);

            browserWindow.WaitForControlReady(5000);

            //int i = 0;
            //while (i < cells.Length)
            //{
            //    menuCell = new HtmlCell(browserWindow);
            //    menuCell.SearchProperties[HtmlCell.PropertyNames.InnerText] = cells[i];
            //    menuCell.SearchProperties[HtmlCell.PropertyNames.Id] = cells[i];
            //    Mouse.Click(menuCell, menuCell.GetClickablePoint());
            //    Mouse.Click(menuCell);
            //}

            // Main Menu
            mainMenuCell.SearchProperties[HtmlCell.PropertyNames.Id] = "Header1_MainMenu_0";
            if (mainMenuCell.TryFind() == true)
            {
                Mouse.Click(mainMenuCell);
            }
            else
            {
                mainMenuCell.SearchProperties[HtmlCell.PropertyNames.Id] = "Header_MainMenu_0";
                Mouse.Click(mainMenuCell);
            }

            // Sub Menu 
            subMenuCell.SearchProperties[HtmlCell.PropertyNames.InnerText] = subMenu;
            Mouse.Click(subMenuCell);

            // Child Menu
            childMenuCell.SearchProperties[HtmlCell.PropertyNames.InnerText] = childMenu;
            Mouse.Click(childMenuCell);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainMenu"></param>
        /// <param name="subMenu"></param>
        /// <param name="childMenu"></param>
        /// <param name="childSubMenu"></param>
        public static void MenuFilter(string subMenu, string childMenu, string childSubMenu)
        {
            BrowserWindow browserWindow = new BrowserWindow();
            HtmlCell mainMenuCell = new HtmlCell(browserWindow);
            HtmlCell subMenuCell = new HtmlCell(browserWindow);
            HtmlCell childMenuCell = new HtmlCell(browserWindow);
            HtmlCell childSubMenuCell = new HtmlCell(browserWindow);

            browserWindow.WaitForControlReady(5000);
            // Main Menu
            mainMenuCell.SearchProperties[HtmlCell.PropertyNames.Id] = "Header1_MainMenu_0";
            if (mainMenuCell.TryFind() == true)
            { 
                Mouse.Click(mainMenuCell); 
            }
            else
            {
                mainMenuCell.SearchProperties[HtmlCell.PropertyNames.Id] = "Header_MainMenu_0";
                Mouse.Click(mainMenuCell);
            }
            // Sub Menu 
            subMenuCell.SearchProperties[HtmlCell.PropertyNames.InnerText] = subMenu;
            Mouse.Click(subMenuCell);

            // Child Menu
            childMenuCell.SearchProperties[HtmlCell.PropertyNames.InnerText] = childMenu;
            Mouse.Click(childMenuCell);

            // Child Sub Menu
            childSubMenuCell.SearchProperties[HtmlCell.PropertyNames.InnerText] = childSubMenu;
            Mouse.Click(childSubMenuCell);
        }


    }

    
   public class MenuNavigation
   {
       public struct NavigationMenuItems
       {
           public static string MainMenu = "Header_MainMenu_0";
           public static string MainMenu1 = "Header1_MainMenu_0";
           public static string MasterDataManagement = "Master Data Management";
           public static string SpecificationManagement = "Specification Management";
           public static string Receiving = "Receiving";
           public static string ReceiveMaterial = "Receive Material";
           public static string ManagePurchaseOrder = "Manage Purchase Orders";
           public static string CellTraphy = "Cell Traphy";
           public static string PersonData = "Person Data";
           public static string VisitData = "Visit Data";
           public static string MaterialManagement = "Material Management";
           public static string MoveMaterial = "Move Material";
           public static string WasteRawMaterial = "Waste Raw Material";
           public static string AdjustInventory = "AdjustInventory";
           public static string AllocateMaterial = "Allocate Material";
           public static string ExecuteMoveRequest = "Execute Move Request";
           public static string ManageMoveRequest = "Manage Move Request";
           public static string BatchRescale = "Batch Rescale";
           public static string Shipping = "Shipping";
           public static string MoveOutput = "Move Output";
           public static string TransferMaterial = "Transfer Material";
           public static string ContainerInformation = "Container Information";
           public static string RecordLotUDA = "Record Lot UDA";
           public static string ManagePallet = "Manage Pallet";
           public static string CreatePallet = "Create Pallet";
           public static string AdjustPallet = "Adjust Pallet";
           public static string BreakPallet = "Break Pallet";
           public static string Transfer = "Transfer";
           public static string ManageBulkTankTransfer = "Manage Bulk Tank Transfer";
           public static string InitializeTank = "Initialize Tank";
           public static string AddContainerToTank = "Add Container To Tank";
           public static string ChangeLotForTank = "Change Lot For Tank";
           public static string QualityManagement = "Quality Management";
           public static string ManageMaterialQCStatus = "Manage Material QC Status";
           public static string AssignLotFlag = "Assign Lot Flag";
           public static string CloseLot = "Close Lot";
           public static string CorrectHistory = "Correct History";
           public static string ReportSDA = "Report SDA";
           public static string Exceptions = "Exceptions";
           public static string ProductionPlanning = "Production Planning and Control";
           public static string OrderManagement = "Order Management";
           public static string Dispensing = "Dispensing";
           public static string BatchDispense = "BatchDispense";
           public static string MiscellaneousDispense = "MiscellaneousDispense";
           public static string WasteDispensedContainer = "Waste Dispensed Container";
           public static string ReturnDispensedContainerToInventory = "Return Dispensed Container To Inventory";
           public static string KitDispensedContainers = "Kit Dispensed Containers";
           public static string Aliqout = "Aliqout";
           public static string SingleScan = "Single Scan";
           public static string EquipmentManagement = "Equipment Management";
           public static string EquipmentWizard = "Equipment Wizard";
           public static string EquipmentMaintenance = "Equipment Maintenance";
           public static string RecordScaleCalibration = "Record Scale Calibration";
           public static string StandardizeScale = "Standardize Scale";
           public static string ConnectDevices = "Connect Devices";
           public static string AllocateEquipment = "Allocate Equipment";
           public static string AssignInvalidLocations = "Assign Invalid Locations";
           public static string ManageRoutes = "Manage Routes";
           public static string ManageControls = "Manage Controls";
           public static string ManageAutoclaveGlasswash = "Manage Autoclave Glasswash";
           public static string ConnectDisconnectRoutes = "Connect/Disconnect Routes";
           public static string ProductionExecution = "Production Execution";
           public static string UnitWorklist = "Unit Worklist";
           public static string InitiateWorksheet = "Initiate Worksheet";
           public static string ControlsFaceplate = "Controls Faceplate";
           public static string WorksheetManagement = "WorksheetManagement";
           public static string ManageOARs = "Manage OARs";
           public static string OrderWorklist = "OrderWorklist";
           public static string Utilities = "Utilities";
           public static string ReprintLabels = "Reprint Labels";
           public static string ConversionFactor = "Conversion Factor";
           public static string Reports = "Reports";
           public static string QCReports = "QC Reports";
           public static string BatchExceptionReport = "Batch Exception Report";
           public static string MaterialReports = "Material Reports";
           public static string MaterialSpecificationReport = "Material Specification Report";
           public static string InventoryLocatorReport = "Inventory Locator Report";
           public static string BackwardGeneologyReport = "Backward Geneology Report";
           public static string ForwardGeneologyReport = "Forward Geneology Report";
           public static string MiscellaneuousMaterialReceiptReport = "Miscellaneuous Material Receipt Report";
           public static string PurchaseOrderMaterialReceiptReport = "Purchase Order Material Receipt Report";
           public static string QCRetestExpirationDateHorizonReport = "QC Retest/Expiration Date Horizon Report";
           public static string LotCloseReviewReport = "Lot Close Review Report";
           public static string EquipmentReports = "Equipment Reports";
           public static string EquipmentLogReport = "Equipment Log Report";
           public static string AutoclaveGlasswashReport = "Autoclave/Glasswash Report";
           public static string ScaleStatusReport = "Scale Status Report";
           public static string AdministrativeReports = "Administrative Reports";
           public static string ConfigurationReports = "Configuration Reports";
           public static string SecurityReports = "Security Reports";
           public static string RecipeHistoryReports = "Recipe History Reports";
           public static string DispenseReports = "Dispense Reports";
           public static string BatchDispenseReports = "Batch Dispense Reports";
           public static string DispenseRoomStatusReport = "Dispense Room Status Report";
           public static string DispenseRecordReport = "Dispense Record Report";
           public static string DispenseAreaReplenishmentReport = "Dispense Area Replenishment Report";
           public static string MiscellaneousReports = "Miscellaneous Reports";
           public static string InProcessTestReports = "In Process Test Reports";
           public static string SystemAdministration = "System Administration";
           public static string SecurityAdministrator = "Security Administrator";
           public static string MonitorTaskConfiguration = "MonitorTaskConfiguration";
           public static string ConfigurationManager = "Configuration Manager";
           public static string DatabaseMaintenance = "Database Maintenance";
           public static string BarcodeLabelConfiguration = "Barcode Label Configuration";
           public static string ERPiInpector = "ERPi Inpector";
           public static string MenuEditor = "Menu Editor";
           public static string ManageTraining = "Manage Training";
       }

   }
}
