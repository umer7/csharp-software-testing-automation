using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectLibraryExceptions.ExceptionsClasses;
using ProjectLibraryHome;
using ProjectLibraryNavigation;
using ProjectLibraryOrderManagement.OrderManagementClasses;
using ReceivingWorksheet = ProjectLibraryReceiving.ReceivingClasses;
using ReceivingPhase = ProjectLibraryPhaseExecution.ReceivingPhaseExecutionClasses;
using ProjectLibraryMaterialAllocation.MaterialAllocationClasses;
using ProjectLibrarySignoff.SignoffClasses;
using ProjectLibraryManageQCStatus;
using FilterGridCodedUI;
using BatchDispenseExecutionClasses;
using VolumeDispense;
using ProjectLibraryUnitWorklist;
using RecordValuePhase;
using ProjectLibraryEquipmentWizard.EquipmentWizardClasses;
using ProjectLibraryEquipmentMaintenance.EquipmentMaintenanceClasses;

namespace SmokeTestHelperProject.SmokeTestHelperClasses
{
    /// <summary>
    /// Execution of scenarios other than spec management
    /// </summary>
    public partial class SmokeTestExecution
    {

        [TestMethod]        
        public void Test_000_LoginPOMSnet()
        {
            HomeScreen.LoginPOMSnet(this.pomsURL, this.signOffUser, this.signOffPassword);

        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "C:\\POMSNetAutomationDLL\\data.csv", "data#csv", DataAccessMethod.Sequential), DeploymentItem("data.csv"), TestMethod]
        public void Test_0010_ReceivingExecution()
        {
            MainMenuNavigation.MenuFilter(MenuNavigation.Receiving, MenuNavigation.ReceiveMaterial);
            ReceivingWorksheet.Receiving receiving = new ReceivingWorksheet.Receiving();
            Playback.Wait(3000);
            this.LotContainerIDsReceiving = receiving.ReceiveMaterial(new ReceivingWorksheet.ReceiveMaterialParams
            {
                InnerTextID = this.ReceivingWorksheetID,
                UnitClass = this.ReceivingWorksheetUnitClass,
                SignoffUser = this.signOffUser,
                SignoffPassword = this.signOffPassword
            },
            new ReceivingPhase.ReceiveMaterialPhaseExecutionParams
            {
                MaterialID = this.MaterialID,
                NumberofContainers = this.NumberofContainers,
                NewLot = this.ReceivingNewLot,
                QuantityPerContainer = this.ReceivingQuantity,
                UOM = this.ReceivingUOM,
                Location = this.location,
                Area = this.ReceivingArea,
                SignOffComment = this.signOffComments,
                SignOffUser = this.signOffUser,
                SignOffPassword = this.signOffPassword
            }, null, null, null, null);

            #region Writing Lot and Container Id to data.csv
            string filePath = @"C:\POMSNetAutomationDLL\data.csv";
            string delimiter = ",";
            System.Security.AccessControl.FileSecurity fileSecurity = new System.Security.AccessControl.FileSecurity();
            System.IO.File.SetAccessControl(filePath, fileSecurity);
            string[][] output = new string[][]{  
	                new string[]{"LotID", "ContainerID"},  	                
                    new string[]{LotContainerIDsReceiving[0], "C"+LotContainerIDsReceiving[1]},  
	            };
            int length = output.GetLength(0);
            System.Text.StringBuilder sb = new  System.Text.StringBuilder();


            for (int index = 0; index < length; index++)
            {
                sb.AppendLine(string.Join(delimiter, output[index]));
                System.IO.File.WriteAllText(filePath, sb.ToString());
            }
            #endregion
        }

        [TestMethod]
        public void Test_0011_OrderManagementExecution()
        {
            this.orderManagement.CreateOrder(new OrderManagementParams
            {
                OrderID = this.OrderManagementOrderID,
                SignoffUser = this.signOffUser,
                SignoffPassword = this.signOffPassword,
                OrderNowDate = true,
                OrderProduct = this.ProductID,
                OrderQuantity = this.OrderManagementQuantity,
                OrderUOM = this.OrderManagementUOM
            });

            this.orderManagement.CreateNewBatch(new OrderManagementParams
            {
                BatchID = this.OrderManagementBatchID,
                OrderID = this.OrderManagementOrderID,
                BatchRecipe = this.RecipeID,
                BatchQuantity = this.OrderManagementQuantity,
                BatchUOM = this.OrderManagementUOM,
                BatchDateNow = true,
                SignoffUser = this.signOffUser,
                SignoffPassword = this.signOffPassword
            });

            this.orderManagement.ReleaseBatch(new OrderManagementParams
            {
                BatchID = this.OrderManagementBatchID,
                OrderID = this.OrderManagementOrderID,
                SignoffUser = this.signOffUser,
                SignoffPassword = this.signOffPassword
            });

            this.orderManagement.AssignUnit(new OrderManagementParams
            {
                BatchID = this.OrderManagementBatchID,
                OrderID = this.OrderManagementOrderID,
                numberofSplits = 1,
                SplitCheckBoxChecked = true,
                SplitID = new string[] { "1" },
                UnitID = new string[] { "Bulk A" },
                SignoffUser = this.signOffUser,
                SignoffPassword = this.signOffPassword
            });
        }

        [TestMethod]
        public void Test_012_MaterialAllocationExecution()
        {
            
            MainMenuNavigation.MenuFilter(MenuNavigation.MaterialManagement, MenuNavigation.AllocateMaterial);
            MaterialAllocation materialAllocation = new MaterialAllocation();
            Playback.Wait(2000);
            materialAllocation.SelectBatch(new MaterialAllocationsParams
            {
                OrderID = this.OrderManagementOrderID,
                BatchID = this.OrderManagementBatchID
            });
            materialAllocation.AllocateAllButton(new MaterialAllocationsParams{SignoffUser = signOffUser,
                SignoffPassword = signOffPassword});
            Playback.Wait(3000);
            materialAllocation.CloseButton();
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "C:\\POMSNetAutomationDLL\\data.csv", "data#csv", DataAccessMethod.Sequential), DeploymentItem("data.csv"), TestMethod]
        public void Test_013_QCStatusExecution()
        {
            MainMenuNavigation.MenuFilter(MenuNavigation.QualityManagement, MenuNavigation.ManageMaterialQCStatus);

            ManageQCStatus manageQCStatus = new ManageQCStatus();
            Signoff signoff = new Signoff();
            ManageQCStatusParams manageQCStatusParams = new ManageQCStatusParams()
            {
                LotID = this.TestContext.DataRow["LotID"].ToString(),
                ContainerID = this.TestContext.DataRow["ContainerID"].ToString().TrimStart('C'),
                NewStatus = "Released",
                RetestDateNotAvailable = false,
                ExpirationDateNotAvailable = false,
                RetestDate = "11/1/2017",
                ExpirationDate = "12/31/2017",
            };

            SignoffParams signoffParams = new SignoffParams() { 
            SignoffComment = this.signOffComments,
            SignoffUser1 = this.signOffUser,
            SignoffUser1Password =this.signOffPassword
            };

            manageQCStatus.ManageQCStatusLotTrack(manageQCStatusParams);
            Playback.Wait(2000);
            manageQCStatus.ClickCommitButton();
            Playback.Wait(2000);
            signoff.SingleDoubleSignOff(signoffParams);
            Playback.Wait(2000);
            manageQCStatus.CloseManageQCStatusWindow();
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "C:\\POMSNetAutomationDLL\\data.csv", "data#csv", DataAccessMethod.Sequential), DeploymentItem("data.csv"), TestMethod]
        public void Test_014_DispensingExecution()
        {
            #region Initialization
            SelectBatchforDispenseParams batchDispenseParams = new SelectBatchforDispenseParams
            {
                RoomCleanlinessStatus = this.DispenseRoomCleanStatus,
                SignOffUser = this.signOffUser,
                SignOffPassword = this.signOffPassword,
                SignOffComment = "Batch Dispense Room Cleaning",
                OrderID = this.OrderManagementOrderID,
                BatchID = this.OrderManagementBatchID,
                MaterialID = this.MaterialID,
                SecondSignOffUser = this.secondSignOffUser,
                SecondSignOffPassword = this.secondSignOffPassword,
                RawMaterialContainerID = this.TestContext.DataRow["ContainerID"].ToString().TrimStart('C'),
                DispenseMethod = this.DispenseMethod
            };

            VolumeDispenseExecutionParams volumeDispenseExecutionParams = new VolumeDispenseExecutionParams() {
                FirstSignOffUser = this.signOffUser,
                SecondSignOffUser = this.secondSignOffUser,
                FirstSignOffPassword = this.signOffPassword,
                SecondSignOffPassword = this.secondSignOffPassword,
                DispenseQuantity = "100",
                //InterimWeight = "100"
            };
            
            UnitWorkListExecution _unitWorkList = new UnitWorkListExecution();
            WeighByBatchDispense _weighByBatchDispense = new WeighByBatchDispense();
            WeighByBatchDispense _batchDispense = new WeighByBatchDispense();
            VolumeDispenseExecution volumeDispenseExecution = new VolumeDispenseExecution();
            GridHelper _gridHelper = new GridHelper();
            
            #endregion

            #region Steps
            
            // Navigate to Dispensing > Batch Dispense
            MainMenuNavigation.MenuFilter(MenuNavigation.Dispensing, MenuNavigation.BatchDispense);

            Playback.Wait(2000);

            _gridHelper.SelectValueOnGrid("WeighByBatch");

            Playback.Wait(1000);

            _batchDispense.SelectUnitForClass("CDS05");
            _batchDispense.BeginWorksheetButton();

            _unitWorkList.ClickOperationActionList("WeighByBatchOp", "1"); 

            Playback.Wait(2000);
            _weighByBatchDispense.VerifyAreaPage(batchDispenseParams);
            Playback.Wait(2000);
            _weighByBatchDispense.CleanUpdateRoomStatus(batchDispenseParams);
            Playback.Wait(2000);
            _weighByBatchDispense.SelectBatchMaterialForBatchDispense(batchDispenseParams);
            Playback.Wait(2000);
            _weighByBatchDispense.VerifyDispenseRoomCleaning(batchDispenseParams);
            Playback.Wait(2000);
            _weighByBatchDispense.VerifyRawMaterialContainerBatch(batchDispenseParams);
            Playback.Wait(2000); 
            _weighByBatchDispense.SelectDispenseMethod(batchDispenseParams);
            Playback.Wait(4000);
            volumeDispenseExecution.SetDispenseParameters(volumeDispenseExecutionParams);
            Playback.Wait(2000);
            volumeDispenseExecution.ClickCommitButton(volumeDispenseExecutionParams);
            Playback.Wait(2000);
            volumeDispenseExecution.ClickFinishButton();

            #endregion
        }

        [TestMethod]
        public void Test_015_CorrectHistoryExecution()
        {
            // Manual Run
        }

        [TestMethod]
        public void Test_016_BatchExecution()
        {
            #region Initializations
            UnitWorkListExecution _unitWorkList = new UnitWorkListExecution();
            RecordTextPhase.RecordTextPhase recordTextPhase = new RecordTextPhase.RecordTextPhase();
            ExceptionParams exceptionParams = new ExceptionParams()
            {
                ExceptionTypeComboBox = "Investigation",
                ExceptionAction = "CommentAction",
                InnerTextID = "INV_000001",
                ExceptionExplanation = "Test New Explanation",
                SignoffComments = "Test Comments",
                SignoffUser1 = this.signOffUser,
                SignoffUser1Password = this.signOffPassword,
                SignoffUser2 = this.secondSignOffUser,
                SignoffUser2Password = this.secondSignOffPassword
            };

            Exceptions exceptions = new Exceptions();

            UnitWorkListExecutionParams unitWorkListExecutionParams = new UnitWorkListExecutionParams() {
                SelectUnitClass = this.UnitWorkListUnitClass,
                SelectUnitID = this.UnitWorkListUnitID,
                BatchID = this.OrderManagementBatchID,
                SplitID = "1",
                OrderID = this.OrderManagementOrderID
            }; 
            #endregion

            #region Steps

            MainMenuNavigation.MenuFilter(MenuNavigation.ProductionExecution, MenuNavigation.UnitWorklist);

            _unitWorkList.ClickInitiateButtonOnUnitWorkList(unitWorkListExecutionParams);
            _unitWorkList.ClickOperationActionList();
            Playback.Wait(3000);
            _unitWorkList.ClickGoActionList("1");
            Playback.Wait(3000);
            recordTextPhase.ClickExceptionButton();
            Playback.Wait(2000);
            exceptions.RecordException(exceptionParams);
            Playback.Wait(2000);

            recordTextPhase.RecordTextExecution(new RecordTextPhase.RecordTextExecutionParams { RecordText = "Record Text Phase Comment" });

            #endregion           
        }

        [TestMethod]
        public void Test_017_CloseBatchExecution()
        {
            this.orderManagement.CloseBatch(new OrderManagementParams { OrderID = this.OrderManagementOrderID, BatchID = this.OrderManagementBatchID });
        }

        [TestMethod]
        public void Test_018_CloseExceptionExecution()
        {
            #region Initializations
            ExceptionParams _execParams = new ExceptionParams
            {
                ExceptionTypeComboBox = "Comment",
                InnerTextID = "INV_000001",
                ExceptionConclusion = "Exception Conclusion comments",
                SignoffComments = "Completing exception",
                SignoffUser1 = this.signOffUser,
                SignoffUser1Password = this.signOffPassword,
               // SignoffUser2 = this.secondSignOffUser,
               // SignoffUser2Password = this.secondSignOffPassword
            };

            Exceptions _exception = new Exceptions();
            GridHelper _grid = new GridHelper();

            OrderManagementParams orderManagementParams = new OrderManagementParams() {
            OrderID = this.OrderManagementOrderID,
            BatchID = this.OrderManagementBatchID
            };

            OrderManagement orderManagement = new OrderManagement();

            Signoff signoff = new Signoff();

            #endregion

            #region Steps

            MainMenuNavigation.MenuFilter(MenuNavigation.ProductionPlanning, MenuNavigation.OrderManagement);
            
            _grid.SelectCheckBoxGrid(orderManagementParams.OrderID, "OrderList1_grid_chkSelect_");
            Playback.Wait(2000);
            orderManagement.ClickBatchTab();
            Playback.Wait(2000);
            _grid.SelectCheckBoxGrid(orderManagementParams.BatchID, "BatchList1_grid_chkBatchSelect_");
            Playback.Wait(2000);

            orderManagement.ClickExceptionButton();
            Playback.Wait(3000);
            _exception.ApproveException(_execParams);
            Playback.Wait(2000);
            _exception.EditExceptionFromOrderManagement(_execParams);
            Playback.Wait(2000);
            
            _exception.CloseExceptionMenuPage();

            #endregion
             
        }

        [TestMethod]
        public void Test_019_GenerateEBRExecution()
        {
           //Manual

        }

        [TestMethod]
        public void Test_020_EquipmentWizardExecution()
        {
            MainMenuNavigation.MenuFilter(MenuNavigation.EquipmentManagement,MenuNavigation.EquipmentWizard);
            EquipmentWizard equipmentWizard = new EquipmentWizard();
            equipmentWizard.EquipmentWizardAddEquipment(new EquipmentWizardParams
            {
                EquipmentID = this.EquipmentID,
                EquipmentDescription="Equipment Description Test",
                ListAddEquipment = new string[] { "ST_Equip" },
                SignoffUser1Comment="Comment Test",
                SignoffUser1 = this.signOffUser,
                SignoffUser1Password = this.signOffPassword,
                Plant = "Herndon",
                Area = this.ReceivingArea,
                Location = "Any",
            });
            //equipmentWizard.EquipmentWizardWindow.Close();
        }

        [TestMethod]
        public void Test_021_EquipmentMaintainenceExecution()
        {
            MainMenuNavigation.MenuFilter(MenuNavigation.EquipmentManagement, MenuNavigation.EquipmentMaintenance);
            EquipmentMaintenance equipmentMaintenance = new EquipmentMaintenance();

            equipmentMaintenance.EquipmentMaintenanceMain(new EquipmentMaintenanceMainParams()
            {
                EquipmentID = this.EquipmentID,
                SignoffComments = "Test",
                SignoffUser1 = this.signOffUser,
                SignoffUser1Password = this.signOffPassword,
                AvailibilityComboBox = "Available",
                CleanlinessComboBox = "Clean",
                SterilityComboBox = "SIP"
            });
        }

        [TestMethod]
        public void Test_022_PomsnetHelpExecution()
        {
           
            
            HomeScreen.HomePOMSnet();
            Playback.Wait(2000);
            HomeScreen.HelpPOMSnet();
            Playback.Wait(2000);
            HomeScreen.AssertPOMSNetKnowledgeWeb();
           
        
        }

        [TestMethod]
        public void Test_023_PomsnetLogoffExecution()
        {
            HomeScreen.LogOffPOMSnet();
        }

       
    }
}
