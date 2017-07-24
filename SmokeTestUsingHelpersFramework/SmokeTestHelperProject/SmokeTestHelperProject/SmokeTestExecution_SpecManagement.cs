using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectLibraryNavigation;
using ProjectLibrarySpecManagementGeneral.SpecManagementGeneralClasses;
using ProjectLibraryMaterialModel.ProjectLibraryMaterialModelClasses;
using ProjectLibraryEquipmentModel.ProjectLibraryEquipmentModelClasses;
using RecordTextPhase;
using ProjectLibraryProcessModel.ProjectLibraryProcessModelClasses;

namespace SmokeTestHelperProject.SmokeTestHelperClasses
{
    /// <summary>
    /// Spec management methods only in this file
    /// </summary>
    public partial class SmokeTestExecution
    {
        [TestMethod]
        public void Test_001_CreateMaterialExecution()
        {
            #region Initializations

           
            SpecManagementNavParams createMaterialNavigation = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.MaterialModel,
                ItemName = SpecTreeNode.MaterialSpecifications,
                Action = SpecTreeNodeActions.New
            };

            SpecManagementGeneralParams createMaterialParams = new SpecManagementGeneralParams()
            {
                ID = MaterialID,
                Description = "Description",
                EffectivityDateNowCheck = true,
                ItemType = SpecManagementType.MaterialSpec,
                ListClasses = new string[] { "Assay" }
            };

            SpecManagementNavParams find = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.MaterialModel,
                ItemName = SpecTreeNode.MaterialSpecifications,
                Action = SpecTreeNodeActions.Find
            };

            FindNewItemParams findmaterial = new FindNewItemParams()
            {
                ID = MaterialID
            };

            SetMaterialAttributesParams setMatAttribute = new SetMaterialAttributesParams()
            {
                AliquoteStock = "No",
                AssayName = "POTENCY",
                AssayProductionEntry = "Yes",
                AssayQCEntry = "Yes",
                DefaultQuantityStatus = "Released",
                InventoryTracking = "Lot",
                LotLvlUOMConvert = "No",
                InventoryUOM = "g",
                MaterialType = "Raw Material",
                ProductType = "My Product",
                StorageClass = "AMBIENT"
            };

            #endregion

            #region Steps

            MainMenuNavigation.MenuFilter(MenuNavigation.MasterDataManagement, MenuNavigation.SpecificationManagement);
            specManagementGeneral.SpecNav(createMaterialNavigation); // Navigate to Spec Management
            specManagementGeneral.CreateNewItem(createMaterialParams);// Create Material with Assay Class
            specManagementGeneral.SpecNav(find);// Open Find Panel
            specManagementGeneral.FindNewItem(findmaterial); //find Material
            specManagementGeneral.RightClickAction(MaterialID, RightClickActions.OpenAttributes);//rightclick
            Playback.Wait(9000);
            materialModel.SetMaterialAttributesWithAssayClass(setMatAttribute);//attribute set POTENCY
            materialModel.SaveSpecAndBOXWindow(); // Save material attributes; Updated method to close the window after saving attribute
            Playback.Wait(3000);
            materialModel.CloseSpecAndBOXWindow(); //Close material attribute window No need to call a new method for this
            Playback.Wait(3000);
            specManagementGeneral.RightClickAction(MaterialID, RightClickActions.Verify);//rightclick//verify
            specManagementGeneral.RightClickAction(MaterialID, RightClickActions.Submit);//rightclick//submit
            specManagementGeneral.RightClickAction(MaterialID, RightClickActions.Approved);//rightclick//approved

            #endregion

        }

        [TestMethod]
        public void Test_002_CreateBOMExecution()
        {
            #region Initializations

            
           
            SpecManagementNavParams createBOMNavigation = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.MaterialModel,
                ItemName = SpecTreeNode.BillsOfMaterial,
                Action = SpecTreeNodeActions.New
            };

            SpecManagementGeneralParams createBOMParams = new SpecManagementGeneralParams()
            {
                ID = BOMID,
                Description = "Description",
                EffectivityDateNowCheck = true,
                ItemType = SpecManagementType.BOM
            };

            SpecManagementNavParams find = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.MaterialModel,
                ItemName = SpecTreeNode.BillsOfMaterial,
                Action = SpecTreeNodeActions.Find
            };

            FindNewItemParams findBOM = new FindNewItemParams()
            {
                ID = BOMID
            };

            SetBOMLineItemsParams setBOMLineItems = new SetBOMLineItemsParams()
            {
                RefLineNumber = 1,
                MaterialQty="100",
                MaterialQtyUOM="g",
                DispenseAreaID="100-A",
                DispenseAreaType="Central",
                Transfer = "No",
                DispenseUOM = "g",
                PercentageYield = "70"
            };

            CreateNewLineItemParams createBOMLineItemParam = new CreateNewLineItemParams()
            { 
              ItemId=MaterialID,
              ItemVersion = "1.001"
            };

            SetBOMHeaderAttributesParams setBOMHeaderAttributes = new SetBOMHeaderAttributesParams()
            {
                BaseQuantity = "100",
                BaseQuantityUOM = "g",
                DispenseToStock = "Yes"
            };


            #endregion

            #region Steps

            specManagementGeneral.SpecNav(createBOMNavigation); // Navigate to Spec Management
            specManagementGeneral.CreateNewItem(createBOMParams);// Create BOM
            specManagementGeneral.SpecNav(find);// Open Find Panel
            specManagementGeneral.FindNewItem(findBOM); //find Material
            specManagementGeneral.RightClickAction(BOMID, RightClickActions.OpenHeader);//rightclick
            Playback.Wait(3000);
            materialModel.SetBOMHeaderAttributes(setBOMHeaderAttributes);//set header values
            materialModel.SaveSpecAndBOXWindow();//save
            materialModel.CloseSpecAndBOXWindow();//close
           
            specManagementGeneral.RightClickAction(BOMID, RightClickActions.OpenLineItems);//open line items
            materialModel.CreateNewLineItem(createBOMLineItemParam);//addline items
            materialModel.SetBOMLineItemsAttributesR400(setBOMLineItems); //setline items attributesvalues
            materialModel.SaveSpecAndBOXWindow();//save
            materialModel.CloseSpecAndBOXWindow();//close      

            specManagementGeneral.RightClickAction(BOMID, RightClickActions.Verify);//rightclick//verify
            specManagementGeneral.RightClickAction(BOMID, RightClickActions.Submit);//rightclick//submit
            specManagementGeneral.RightClickAction(BOMID, RightClickActions.Approved);//rightclick//approved
            
            #endregion

        }

        [TestMethod]
        public void Test_003_CreateEquipmentExecution()
        {
            #region Initializations

            SpecManagementNavParams createEquipmentNavigation = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.EquipmentModel,
                ItemName = SpecTreeNode.EquipmentSpecifications,
                Action = SpecTreeNodeActions.New
            };

            SpecManagementGeneralParams createEquipmentParams = new SpecManagementGeneralParams()
            {
                ID = EquipmentID,
                Description = "Description",
                EffectivityDateNowCheck = true,
                ItemType = SpecManagementType.EquipmentSpec,
                ListStatusTypes = new string[] { "Cleanliness", "Availability" }
            };

            SpecManagementNavParams find = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.EquipmentModel,
                ItemName = SpecTreeNode.EquipmentSpecifications,
                Action = SpecTreeNodeActions.Find
            };

            FindNewItemParams findEquipment = new FindNewItemParams()
            {
                ID = EquipmentID
            };

            SetEquipmentAttributesParams setEquipmentAttributes = new SetEquipmentAttributesParams()
            {
                CapacityMax = "10",
                CapacityMin = "5",
                CapacityUOM = "g",
                Moveable = "Yes",
                Type = "Scale"
            };
            
            SetEquipmentStatusAttributesParams setEquipmentStatusAttributesParams = new SetEquipmentStatusAttributesParams()
            {
                CleanlinessDefaultStatus = "Clean"
            };


            #endregion

            #region Steps

            specManagementGeneral.SpecNav(createEquipmentNavigation); // Navigate to Spec Management
            specManagementGeneral.CreateNewItem(createEquipmentParams);// Create Equipment
            specManagementGeneral.SpecNav(find);// Open Find Panel
            specManagementGeneral.FindNewItem(findEquipment); //find Material
            specManagementGeneral.RightClickAction(EquipmentID, RightClickActions.OpenAttributes);//rightclick
            Playback.Wait(3000);
            equipmentModel.SetEquipmentAttributes(setEquipmentAttributes);//attribute set POTENCY
            materialModel.SaveSpecAndBOXWindow(); // Save equipment attributes
            materialModel.CloseSpecAndBOXWindow(); //Close equipment attribute window
            specManagementGeneral.RightClickAction(EquipmentID, RightClickActions.OpenStatusValues);//rightclick
            equipmentModel.SetCleanlinessAndAvailabilityEquipStatusTypeAttributes(setEquipmentStatusAttributesParams);
            materialModel.SaveSpecAndBOXWindow(); // Save equipment attributes
            materialModel.CloseSpecAndBOXWindow(); //Close equipment attribute window
            specManagementGeneral.RightClickAction(EquipmentID, RightClickActions.Verify);//rightclick//verify
            specManagementGeneral.RightClickAction(EquipmentID, RightClickActions.Submit);//rightclick//submit
            specManagementGeneral.RightClickAction(EquipmentID, RightClickActions.Approved);//rightclick//approved

            #endregion
        }

        [TestMethod]
        public void Test_004_CreateBOEExecution()
        {
            #region Initializations

            SpecManagementNavParams createBOENavigation = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.EquipmentModel,
                ItemName = SpecTreeNode.BillsOfEquipment,
                Action = SpecTreeNodeActions.New
            };

            SpecManagementGeneralParams createBOEParams = new SpecManagementGeneralParams()
            {
                ID = BOEID,
                Description = "Description",
                EffectivityDateNowCheck = true,
                ItemType = SpecManagementType.BOE
            };

            SpecManagementNavParams find = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.EquipmentModel,
                ItemName = SpecTreeNode.BillsOfEquipment,
                Action = SpecTreeNodeActions.Find
            };

            FindNewItemParams findBOE = new FindNewItemParams()
            {
                ID = BOEID
            };

            SetBOELineItemsAttributesParams setBOELineItems = new SetBOELineItemsAttributesParams()
            {
                RefLineNumber = 1,
                PreCheckIn="Allowed",
                QuantityRequired="50",
                ScalingRule="Percent"
            };

            CreateNewLineItemParams createBOELineItemParam = new CreateNewLineItemParams()
            {
                ItemId = EquipmentID,
                ItemVersion = "1.001"
            };

            #endregion

            #region Steps

            specManagementGeneral.SpecNav(createBOENavigation); // Navigate to Spec Management
            specManagementGeneral.CreateNewItem(createBOEParams);// Create BOM
            specManagementGeneral.SpecNav(find);// Open Find Panel
            specManagementGeneral.FindNewItem(findBOE); //find Material
            specManagementGeneral.RightClickAction(BOEID, RightClickActions.OpenLineItems);//open line items
            materialModel.CreateNewLineItem(createBOELineItemParam);//addline items
            equipmentModel.SetBOELineItemsAttributes(setBOELineItems); //setline items attributesvalues
            materialModel.SaveSpecAndBOXWindow();//save
            materialModel.CloseSpecAndBOXWindow();//close      

            specManagementGeneral.RightClickAction(BOEID, RightClickActions.Verify);//rightclick//verify
            specManagementGeneral.RightClickAction(BOEID, RightClickActions.Submit);//rightclick//submit
            specManagementGeneral.RightClickAction(BOEID, RightClickActions.Approved);//rightclick//approved

            #endregion
        }

        [TestMethod]
        public void Test_005_CreateProductExecution()
        {
            #region Initializations


            SpecManagementGeneral specManagementGeneral = new SpecManagementGeneral();

            MaterialModel materialModel = new MaterialModel();

            SpecManagementNavParams createProductNavigation = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.MaterialModel,
                ItemName = SpecTreeNode.MaterialSpecifications,
                Action = SpecTreeNodeActions.New
            };

            SpecManagementGeneralParams createProductParams = new SpecManagementGeneralParams()
            {
                ID = ProductID,
                Description = "Description",
                EffectivityDateNowCheck = true,
                ItemType = SpecManagementType.MaterialSpec
            };

            SpecManagementNavParams find = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.MaterialModel,
                ItemName = SpecTreeNode.MaterialSpecifications,
                Action = SpecTreeNodeActions.Find
            };

            FindNewItemParams findProduct = new FindNewItemParams()
            {
                ID = ProductID
            };

            SetMaterialAttributesParams setProductAttribute = new SetMaterialAttributesParams()
            {
                AliquoteStock = "No",
                DefaultQuantityStatus = "Released",
                InventoryTracking = "Lot",
                LotLvlUOMConvert = "No",
                InventoryUOM = "g",
                MaterialType = "Product",
                ProductType = "My Product",
                StorageClass = "AMBIENT"
            };

            #endregion

            #region Steps

            specManagementGeneral.SpecNav(createProductNavigation); // Navigate to Spec Management
            specManagementGeneral.CreateNewItem(createProductParams);// Create Material with Assay Class
            specManagementGeneral.SpecNav(find);// Open Find Panel
            specManagementGeneral.FindNewItem(findProduct); //find Material
            specManagementGeneral.RightClickAction(ProductID, RightClickActions.OpenAttributes);//rightclick
            
            materialModel.SetMaterialAttributes(setProductAttribute);//attribute set POTENCY
            materialModel.SaveSpecAndBOXWindow(); // Save material attributes
            materialModel.CloseSpecAndBOXWindow(); //Close material attribute window

            specManagementGeneral.RightClickAction(ProductID, RightClickActions.Verify);//rightclick//verify
            specManagementGeneral.RightClickAction(ProductID, RightClickActions.Submit);//rightclick//submit
            specManagementGeneral.RightClickAction(ProductID, RightClickActions.Approved);//rightclick//approved

            #endregion
        }

        [TestMethod]
        public void Test_006_CreateBOPExecution()
        {
            #region Initializations
            SpecManagementGeneral specManagementGeneral = new SpecManagementGeneral();
            MaterialModel materialModel = new MaterialModel();

            SpecManagementNavParams createBOPNavigation = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.MaterialModel,
                ItemName = SpecTreeNode.BillsOfProduct,
                Action = SpecTreeNodeActions.New
            };

            SpecManagementGeneralParams createBOPParams = new SpecManagementGeneralParams()
            {
                ID = BOPID,
                Description = "Description",
                EffectivityDateNowCheck = true,
                ItemType = SpecManagementType.BOP
            };

            SpecManagementNavParams find = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.MaterialModel,
                ItemName = SpecTreeNode.BillsOfProduct,
                Action = SpecTreeNodeActions.Find
            };

            FindNewItemParams findBOP = new FindNewItemParams()
            {
                ID = BOPID
            };

            SetBOPLineItemsParams setBOPLineItemsParams = new SetBOPLineItemsParams() { 
            
                RefLineNumber=1,
                ProductQuantity= "100",
                ProductUOM="g"
            };

            CreateNewLineItemParams createBOMLineItemParam = new CreateNewLineItemParams()
            {
                ItemId = ProductID,
                ItemVersion = "1.001"
            };

            #endregion

            #region Steps

            specManagementGeneral.SpecNav(createBOPNavigation); // Navigate to Spec Management
            specManagementGeneral.CreateNewItem(createBOPParams);// Create Material with Assay Class
            specManagementGeneral.SpecNav(find);// Open Find Panel
            specManagementGeneral.FindNewItem(findBOP); //find Material
            specManagementGeneral.RightClickAction(BOPID, RightClickActions.OpenLineItems);//rightclick
            
            materialModel.CreateNewLineItem(createBOMLineItemParam);
            materialModel.SetBOPLineItemsAttributes(setBOPLineItemsParams);//attribute set POTENCY
            materialModel.SaveSpecAndBOXWindow(); // Save material attributes
            materialModel.CloseSpecAndBOXWindow(); //Close material attribute window
            
            specManagementGeneral.RightClickAction(BOPID, RightClickActions.Verify);//rightclick//verify
            specManagementGeneral.RightClickAction(BOPID, RightClickActions.Submit);//rightclick//submit
            specManagementGeneral.RightClickAction(BOPID, RightClickActions.Approved);//rightclick//approved

            #endregion
        }

        [TestMethod]
        public void Test_007_CreateOPExecution()
        {

            #region Initializations

            SpecManagementNavParams specManagementNavParams = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.ProcessModel,
                ItemName = SpecTreeNode.Operations,
                Action = SpecTreeNodeActions.New
            };

            SpecManagementGeneralParams specManagementGeneralParams = new SpecManagementGeneralParams()
            {
                ID = this.OperationID,
                Description = Description,
                EffectivityDateNowCheck = true
            };

            SpecManagementNavParams navigationOperation = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.ProcessModel,
                ItemName = SpecTreeNode.Operations,
                Action = SpecTreeNodeActions.Find
            };

            FindNewItemParams findNewItemParams = new FindNewItemParams() {
                ID = OperationID,
                LatestVersionChkbox = true
            };

            RecordTextAuthorParams recordTextAuthorParams = new RecordTextAuthorParams()
            {
                Instructions = "Record text as required",
                RecordText= true,
                MinimumCharacters = "1",
                MaximumCharacters = "1023",
                TextAreAllCapitalLetters = true,
                RecordType = "Other",
                ConfirmationType = "None"
            };


            RecordTextPhase.RecordTextPhase recordTextPhaseAuthor = new RecordTextPhase.RecordTextPhase();
            #endregion

            #region Steps

            MainMenuNavigation.MenuFilter(MenuNavigation.MasterDataManagement, MenuNavigation.SpecificationManagement);
            specManagementGeneral.SpecNav(specManagementNavParams);
            specManagementGeneral.CreateNewItem(specManagementGeneralParams);
            specManagementGeneral.SpecNav(navigationOperation);
            specManagementGeneral.FindNewItem(findNewItemParams);
            specManagementGeneral.RightClickAction(OperationID, RightClickActions.InvokeActionListEditor);
            Playback.Wait(2000);
            processModel.AddPhaseToOperation(this.PhaseID);
            Playback.Wait(3000);
            recordTextPhaseAuthor.RecordTextAuthor(recordTextAuthorParams);

            processModel.SavePFCEditor();
            Playback.Wait(5000);
            processModel.ClosePFCEditor();

            specManagementGeneral.RightClickAction(OperationID, RightClickActions.Verify);
            Playback.Wait(5000);
            specManagementGeneral.RightClickAction(OperationID, RightClickActions.Submit);
            specManagementGeneral.RightClickAction(OperationID, RightClickActions.Approved);

            #endregion

        }

        [TestMethod]
        public void Test_008_CreateUPExecution()
        {

            #region Initialization

            SpecManagementNavParams specManagementNavParams = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.ProcessModel,
                ItemName = SpecTreeNode.UnitProcedures,
                Action = SpecTreeNodeActions.New
            };

            SpecManagementGeneralParams createUnitProcedureParams = new SpecManagementGeneralParams()
            {
                ID = this.UnitProcedureID,
                Description = Description,
                EffectivityDateNowCheck = true
            };

            SpecManagementNavParams findUnitProcedureNavParams = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.ProcessModel,
                ItemName = SpecTreeNode.UnitProcedures,
                Action = SpecTreeNodeActions.Find
            };

            FindNewItemParams findNewItemParams = new FindNewItemParams()
            {
                ID = this.UnitProcedureID, 
            };

            SetUPAttibutesParams setUPAttributes = new SetUPAttibutesParams()
            {
                ObjectName = "ST_UP1",
                UPCustomControlAttribute = new string[] { "Yes", "No", "No", "Operator Security", "ProductionOperator", "Verifier Security", "ProductionVerifier", "Alternate Security", "ProductionVerifier", "1000L Bulk Tank" }
            };

            #endregion

            #region Steps

            #region Create UP, Set Attributes and Add Bills
            
            MainMenuNavigation.MenuFilter(MenuNavigation.MasterDataManagement, MenuNavigation.SpecificationManagement);
            specManagementGeneral.SpecNav(specManagementNavParams);
            specManagementGeneral.CreateNewItem(createUnitProcedureParams);
            specManagementGeneral.SpecNav(findUnitProcedureNavParams);
            specManagementGeneral.FindNewItem(findNewItemParams);
            specManagementGeneral.RightClickAction(this.UnitProcedureID, RightClickActions.Open);

            Playback.Wait(1000);
            processModel.SetUPAttributes(setUPAttributes);
            Playback.Wait(2000);

            #region Add Bills
            processModel.AddBills(new ProjectLibraryProcessModel.ProjectLibraryProcessModelClasses.AddBillParams
            {
                ObjectName = this.UnitProcedureID,
                BillType = "BOM",
                BillId = this.BOMID,
                LatestCheckBox = true
            });

            processModel.AddBills(new ProjectLibraryProcessModel.ProjectLibraryProcessModelClasses.AddBillParams
            {
                ObjectName = this.UnitProcedureID,
                BillType = "BOE",
                BillId = this.BOEID,
                LatestCheckBox = true
            });

            processModel.AddBills(new ProjectLibraryProcessModel.ProjectLibraryProcessModelClasses.AddBillParams
            {
                ObjectName = this.UnitProcedureID,
                BillType = "BOP",
                BillId = this.BOPID,
                LatestCheckBox = true
            });
            #endregion

            processModel.SaveProcesModelTab(ProcessModelTab.Bills);
            Playback.Wait(5000);
            processModel.CloseProcesModelTab(ProcessModelTab.Attributes);

            #endregion

            #region PFC Editor:  Add Operation to UP, Save & Close PFC Editor 
           
            specManagementGeneral.RightClickAction(this.UnitProcedureID, RightClickActions.InvokePFCEditor);
            Playback.Wait(3000);
            processModel.AddOperationToUP(this.OperationID, "Ver. 1.001");
            processModel.StartDragStopDrag(this.OperationID);
            processModel.SavePFCEditor();
            Playback.Wait(5000);
            processModel.ClosePFCEditor();

            #endregion 

            #region Verify Submit Approved UP

            Playback.Wait(2000);
            specManagementGeneral.RightClickAction(this.UnitProcedureID, RightClickActions.Verify);
            Playback.Wait(5000);
            specManagementGeneral.RightClickAction(this.UnitProcedureID, RightClickActions.Submit);
            specManagementGeneral.RightClickAction(this.UnitProcedureID, RightClickActions.Approved);
            #endregion

            #endregion


        }

        [TestMethod]
        public void Test_009_CreateRecipeExecution()
        {
            #region Initialization

            SpecManagementGeneral specManagementGeneral  = new SpecManagementGeneral();

            SpecManagementNavParams recipeNavigation = new SpecManagementNavParams() 
            {
                ModelName = SpecTreeNode.ProcessModel,
                ItemName = SpecTreeNode.Recipes,
                Action = SpecTreeNodeActions.New            
            };

            SpecManagementGeneralParams createNewRecipeDetails = new SpecManagementGeneralParams() 
            {
                ID = this.RecipeID,
                Description = Description,
                EffectivityDateNowCheck = true,
            };

            SpecManagementNavParams findRecipe = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.ProcessModel,
                ItemName = SpecTreeNode.Recipes,
                Action = SpecTreeNodeActions.Find
            };

            FindNewItemParams recipeFindCriteria = new FindNewItemParams()
            {
                ID = this.RecipeID,
                LatestVersionChkbox = true 
            };

            SetRecipeAttributesParams setRecipeAttributesParams = new SetRecipeAttributesParams()
            {
                ObjectName = this.RecipeID,
                RecipeMaximumQty = "100",
                RecipeTargetQty = "90",
                RecipeMinimumQty = "20",
                RecipeCustomControlAttribute = new string[] { "Yes", this.ProductID, "g", "Production" }
            };


            #endregion

            #region Steps

            #region Create Recipe, Set Attributes

            MainMenuNavigation.MenuFilter(MenuNavigation.MasterDataManagement, MenuNavigation.SpecificationManagement);
            specManagementGeneral.SpecNav(recipeNavigation);
            specManagementGeneral.CreateNewItem(createNewRecipeDetails);
            specManagementGeneral.SpecNav(findRecipe);
            specManagementGeneral.FindNewItem(recipeFindCriteria);
            specManagementGeneral.RightClickAction(this.RecipeID, RightClickActions.Open);
            processModel.SetRecipeAttributes(setRecipeAttributesParams);

            processModel.SaveProcesModelTab(ProcessModelTab.Attributes);
            Playback.Wait(3000);
            processModel.CloseProcesModelTab(ProcessModelTab.Attributes);

            #endregion

            #region PFC Editor: Add Unit Procedure to Recipe and Save & Closed PFC Editor

            specManagementGeneral.RightClickAction(this.RecipeID, RightClickActions.InvokePFCEditor);
            Playback.Wait(3000);
            processModel.AddUPToRecipe(this.UnitProcedureID, "Ver. 1.001");
            processModel.StartDragStopDrag(this.UnitProcedureID);
            processModel.SavePFCEditor();
            Playback.Wait(5000);
            processModel.ClosePFCEditor();

            #endregion

            #region Verified, Submit, Approved Recipe

            specManagementGeneral.RightClickAction(this.RecipeID, RightClickActions.Verify);
            Playback.Wait(5000);
            specManagementGeneral.RightClickAction(this.RecipeID, RightClickActions.Submit);
            specManagementGeneral.RightClickAction(this.RecipeID, RightClickActions.Approved);
            #endregion

            #endregion

        }

        [TestMethod]
        public void Test_024_GenerateMBRExecution()
        {
            #region Initializations
            SpecManagementGeneral specManagementGeneral = new SpecManagementGeneral();
            ProcessModel processModel = new ProcessModel();

            SpecManagementNavParams recipeNavigation = new SpecManagementNavParams()
            {
                ModelName = SpecTreeNode.ProcessModel,
                ItemName = SpecTreeNode.Recipes,
                Action = SpecTreeNodeActions.Find
            };

            FindNewItemParams findrecipe = new FindNewItemParams()
            {
                ID = this.RecipeID
            };
            #endregion

            #region Steps

            MainMenuNavigation.MenuFilter(MenuNavigation.MasterDataManagement, MenuNavigation.SpecificationManagement);
            specManagementGeneral.SpecNav(recipeNavigation); // Navigate to Spec Management
            specManagementGeneral.FindNewItem(findrecipe); //find Recipe
            specManagementGeneral.RightClickAction(RecipeID, RightClickActions.MasterRecord);//rightclick
            Playback.Wait(5000);

            processModel.OpenMBR();
            Playback.Wait(5000);
            processModel.AssertMBRReport();

            #endregion
        }


    }
}
