namespace ProjectLibrarySpecManagementGeneral
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using System.Diagnostics;


    public partial class UIMap
    {
        private Dictionary<string, string> _modelDictionary;

        /// <summary>
        /// Constructor
        /// </summary>
        public UIMap()
        {            
            SetModelDictionary();
        }
 
        /// <summary>
        /// Dictionary work for pairing of Model Id with Model Name
        /// </summary>
        private void SetModelDictionary()
        {
            _modelDictionary = new Dictionary<string, string>();
            _modelDictionary.Add(TreeNode.Master, "M_tvTree_1");
            _modelDictionary.Add(TreeNode.Herndon, "M_tvTree_1_1");
            _modelDictionary.Add(TreeNode.AssemblyModel, "M_tvTree_1_1_1");
            _modelDictionary.Add(TreeNode.EquipmentModel, "M_tvTree_1_1_2");
            _modelDictionary.Add(TreeNode.InprocessTestModel, "M_tvTree_1_1_3");
            _modelDictionary.Add(TreeNode.InstructionModel, "M_tvTree_1_1_4");
            _modelDictionary.Add(TreeNode.MaterialModel, "M_tvTree_1_1_5");
            _modelDictionary.Add(TreeNode.ProcessModel, "M_tvTree_1_1_6");
            _modelDictionary.Add(TreeNode.StaffModel, "M_tvTree_1_1_7");
            _modelDictionary.Add(TreeNode.VariableModel, "M_tvTree_1_1_8");
        }

        /// <summary>
        /// Method used to navigate entire Specification Tree Menu
        /// </summary>
        /// <param name="navParams"></param>
        public void SpecNav(SpecManagementNavParams navParams)
        {
            Playback.PlaybackSettings.WaitForReadyTimeout = 10000;
            BrowserWindow browserWindow = new BrowserWindow();
            HtmlDiv MasterDiv = new HtmlDiv(browserWindow);
            HtmlDiv HerndonDiv = new HtmlDiv(browserWindow);
            HtmlDiv ModelDiv = new HtmlDiv(browserWindow);
            HtmlSpan NodeMaster = new HtmlSpan(browserWindow);
            HtmlSpan NodeHerndon = new HtmlSpan(browserWindow);
            HtmlSpan ModelName = new HtmlSpan(browserWindow);
            HtmlSpan ItemName = new HtmlSpan(browserWindow);
            HtmlSpan Action = new HtmlSpan(browserWindow);

            string[] ControlDefination = new string[] {"style=\"HEIGHT: 1px; DISPLAY: none\"", "style=\"HEIGHT: 2px; DISPLAY: none\""};
            string[] ModelId = new string[] { "M_tvTree_1", "M_tvTree_1_1" };

            MasterDiv.SearchProperties[HtmlDiv.PropertyNames.Id] = ModelId[0];
            HerndonDiv.SearchProperties[HtmlDiv.PropertyNames.Id] = ModelId[1];
            ModelDiv.SearchProperties[HtmlDiv.PropertyNames.Id] = _modelDictionary.ContainsKey(navParams.ModelName) ? _modelDictionary[navParams.ModelName] : "";
            ModelName.SearchProperties[HtmlSpan.PropertyNames.InnerText] = navParams.ModelName;
            ItemName.SearchProperties[HtmlSpan.PropertyNames.InnerText] = navParams.ItemName;
            Action.SearchProperties[HtmlSpan.PropertyNames.InnerText] = navParams.Action;

            if (!ItemName.Exists)
            {
                ItemName.SearchProperties[HtmlSpan.PropertyNames.InnerText] = navParams.ItemName + "*";
            }

            #region If all nodes are closed
            if (MasterDiv.ControlDefinition.Contains(ControlDefination[0]) && HerndonDiv.ControlDefinition.Contains(ControlDefination[0]) && ModelDiv.ControlDefinition.Contains(ControlDefination[1]))
            {
                ClickMaster();
                ClickHerndon();
                Mouse.DoubleClick(ModelName);        
                Mouse.Click(ItemName, MouseButtons.Right);
                Mouse.Click(Action);
            }
            #endregion

            #region If Master Open all other closed
            else if (MasterDiv.ControlDefinition.Contains(ControlDefination[0]) == false && HerndonDiv.ControlDefinition.Contains(ControlDefination[0]) && ModelDiv.ControlDefinition.Contains(ControlDefination[1]))
            {
                ClickHerndon();
                Mouse.DoubleClick(ModelName);
                Mouse.Click(ItemName, MouseButtons.Right);
                Mouse.Click(Action);
            }
            #endregion

            #region If Master and Herndon Open all other closed
            else if (MasterDiv.ControlDefinition.Contains(ControlDefination[0]) == false && HerndonDiv.ControlDefinition.Contains(ControlDefination[0]) == false && ModelDiv.ControlDefinition.Contains(ControlDefination[1]))
            {
                Mouse.DoubleClick(ModelName);
                Mouse.Click(ItemName, MouseButtons.Right);
                Mouse.Click(Action);
            }
            #endregion

            #region If Master Open, Herndon Closed and all other open
            else if (MasterDiv.ControlDefinition.Contains(ControlDefination[0]) == false && HerndonDiv.ControlDefinition.Contains(ControlDefination[0]) && ModelDiv.ControlDefinition.Contains(ControlDefination[1])== false)
            {
                ClickHerndon();
                Mouse.Click(ItemName, MouseButtons.Right);
                Mouse.Click(Action);
            }
            #endregion

            #region If Master Closed, all other open
            else if (MasterDiv.ControlDefinition.Contains(ControlDefination[0]) && HerndonDiv.ControlDefinition.Contains(ControlDefination[0])==false && ModelDiv.ControlDefinition.Contains(ControlDefination[1]) == false)
            {
                ClickMaster();
                Mouse.Click(ItemName, MouseButtons.Right);
                Mouse.Click(Action);
            }
            #endregion

            #region If all nodes are open
            else if (MasterDiv.ControlDefinition.Contains(ControlDefination[0])==false && HerndonDiv.ControlDefinition.Contains(ControlDefination[0])==false && ModelDiv.ControlDefinition.Contains(ControlDefination[1])==false)
            {
                Mouse.Click(ItemName, MouseButtons.Right);
                Mouse.Click(Action);
            }
            #endregion

        } 

        /// <summary>
        /// Used to click on Herndon Node of Spec Tree Menu
        /// </summary>
        void ClickHerndon()
        {
            BrowserWindow browserWindow = new BrowserWindow();
            HtmlDiv HerndonDiv = new HtmlDiv(browserWindow);
            HtmlSpan NodeHerndon = new HtmlSpan(browserWindow);

            HerndonDiv.SearchProperties[HtmlDiv.PropertyNames.Id] = "M_tvTree_1_1";
            NodeHerndon.SearchProperties[HtmlSpan.PropertyNames.InnerText] = "Herndon";
            Mouse.DoubleClick(NodeHerndon);    //Open Herndon
        }

        /// <summary>
        /// Used to click on Master Node of Spec Tree Menu
        /// </summary>
        void ClickMaster()
        {
            #region Variable Declarations
            HtmlImage expandCollaspeImg = this.SpecManagementWindow.SpecManagementDocument.MasterPane.ExpandCollaspeImg;
            HtmlSpan uIMasterPane = this.SpecManagementWindow.SpecManagementDocument.MasterPane.UIMasterPane;
            #endregion

            // Click '/HOOPS/WebResource.axd' image
            Mouse.Click(expandCollaspeImg, new Point(7, 14));
        }

        /// <summary>
        /// Used to perform right click actions on any grid of specification management like New, Find, Invoke PFC Editor, Verified, Submit, Approved etc...
        /// </summary>
        /// <param name="Item">Spec Management items like: BOM, Operation, Recipe etc</param>
        /// <param name="Action">Right Menu action on spec management grid e.g: New, Verify, Approve...</param>
        public void RightClickAction(string Item, string Action)
        {
            #region Variable Declarations
            HtmlCell itemCell = this.SpecManagementWindow.SpecManagementDocument.UIDiv_detail_bodyPane.UIItemTable.ItemCell;
            HtmlCell actionCell = this.SpecManagementWindow.SpecManagementDocument.UIDiv_gridContextMenuPane.UIItemTable.UIVerifyCell;
            #endregion

            itemCell.SearchProperties[HtmlCell.PropertyNames.InnerText] = Item;
            actionCell.SearchProperties[HtmlCell.PropertyNames.InnerText] = Action;

            Mouse.Click(itemCell, MouseButtons.Right);
            Mouse.Click(actionCell);
        }
               
        /// <summary>
        /// Used to create all spec items just need to send correct values in params
        /// </summary>
        /// <param name="specManagementGeneralParams"></param>
        public void CreateNewItem(SpecManagementGeneralParams specManagementGeneralParams)
        {
            BrowserWindow browserWindow = new BrowserWindow();

            browserWindow.SearchProperties[UITestControl.PropertyNames.Name] = specManagementGeneralParams.ItemType;
            browserWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "Internet Explorer_TridentDlgFrame";
            browserWindow.WindowTitles.Add(specManagementGeneralParams.ItemType);

            HtmlEdit ID = new HtmlEdit(browserWindow);
            HtmlEdit Description = new HtmlEdit(browserWindow);
            HtmlTextArea Desc = new HtmlTextArea(browserWindow);
            HtmlEdit EffectiveDate = new HtmlEdit(browserWindow);
            HtmlEdit ExpiryDate = new HtmlEdit(browserWindow);
            HtmlCheckBox EffectiveDateNow = new HtmlCheckBox(browserWindow);
            HtmlCheckBox ExpiryDateNow = new HtmlCheckBox(browserWindow);
            HtmlTextArea Icon = new HtmlTextArea(browserWindow);
            HtmlInputButton OK = new HtmlInputButton(browserWindow);
            HtmlButton Cancel = new HtmlButton(browserWindow);

            string[] SpecId = new string[] { "txtID", "txtMatlDescription", "txtDescription", "chkEffectDate", "chkExpireDate", "chkEffectDateNow", "chkExpireDateNow", "txtIcon", "btnOK" };

            if (specManagementGeneralParams.ID != null)
            {
                ID.SearchProperties[HtmlEdit.PropertyNames.Id] = SpecId[0];
                ID.Text = specManagementGeneralParams.ID;
            }

            if (specManagementGeneralParams.Description != null)
            {
                if (specManagementGeneralParams.ItemType == SpecManagementType.MaterialSpec)
                {
                    Desc.SearchProperties[HtmlTextArea.PropertyNames.Id] = SpecId[1]; // matspec
                    Desc.Text = specManagementGeneralParams.Description;
                }

                else if (specManagementGeneralParams.ItemType == SpecManagementType.BOA || specManagementGeneralParams.ItemType == SpecManagementType.BOE || specManagementGeneralParams.ItemType == SpecManagementType.BOI || specManagementGeneralParams.ItemType == SpecManagementType.BOM ||
                    specManagementGeneralParams.ItemType == SpecManagementType.BOP || specManagementGeneralParams.ItemType == SpecManagementType.BOS || specManagementGeneralParams.ItemType == SpecManagementType.BOT || specManagementGeneralParams.ItemType == SpecManagementType.BOV)
                {
                    Description.SearchProperties[HtmlEdit.PropertyNames.Id] = SpecId[2]; // other
                    Description.Text = specManagementGeneralParams.Description;
                }   
                    
                else
                {
                    Desc.SearchProperties[HtmlTextArea.PropertyNames.Id] = SpecId[2]; // equipspec, instruction, IPTCharac, Processmodel, Roles, Variables
                     Desc.Text = specManagementGeneralParams.Description;
                }
            }

            if(specManagementGeneralParams.EffectivityDate != null)
            {
                EffectiveDate.SearchProperties[HtmlEdit.PropertyNames.Id] = SpecId[3];
                EffectiveDate.Text = specManagementGeneralParams.EffectivityDate;
            }

            if (specManagementGeneralParams.ExpiryDate != null)
            {
                ExpiryDate.SearchProperties[HtmlEdit.PropertyNames.Id] = SpecId[4];
                ExpiryDate.Text = specManagementGeneralParams.ExpiryDate;
            }

            if (specManagementGeneralParams.EffectivityDateNowCheck)
            {
                EffectiveDateNow.SearchProperties[HtmlCheckBox.PropertyNames.Id] = SpecId[5];
                EffectiveDateNow.Checked = specManagementGeneralParams.EffectivityDateNowCheck;
            }

            if (specManagementGeneralParams.ExpiryDateNowCheck)
            {
                ExpiryDateNow.SearchProperties[HtmlCheckBox.PropertyNames.Id] = SpecId[6];
                ExpiryDateNow.Checked = specManagementGeneralParams.ExpiryDateNowCheck;
            }

            if (specManagementGeneralParams.Icon != null)
            {
                Icon.SearchProperties[HtmlTextArea.PropertyNames.Id] = SpecId[7];
                Icon.Text = specManagementGeneralParams.Icon;
            }

            OK.SearchProperties[HtmlInputButton.PropertyNames.Id] = SpecId[8];
            Mouse.Click(OK);

        }

        /// <summary>
        /// FindNewItem - Use 'FindNewItemParams' to pass parameters into this method.
        /// </summary>
        public void FindNewItem(FindNewItemParams _findParam)
        {
            #region Variable Declarations
            HtmlEdit iD = this.SpecManagementWindow.SpecManagementDocument.UIDiv_filterWindowBodyPane.ID;
            HtmlEdit version = this.SpecManagementWindow.SpecManagementDocument.UIDiv_filterWindowBodyPane.Version;
            HtmlEdit description = this.SpecManagementWindow.SpecManagementDocument.UIDiv_filterWindowBodyPane.Description;
            HtmlEdit checkOutBy = this.SpecManagementWindow.SpecManagementDocument.UIDiv_filterWindowBodyPane.CheckOutBy;
            HtmlEdit status = this.SpecManagementWindow.SpecManagementDocument.UIDiv_filterWindowBodyPane.Status;
            HtmlEdit lastChangeby = this.SpecManagementWindow.SpecManagementDocument.UIDiv_filterWindowBodyPane.LastChangeBy;
            HtmlEdit lastChangeDate = this.SpecManagementWindow.SpecManagementDocument.UIDiv_filterWindowBodyPane.LastChangeDate;
            HtmlEdit effectiveDate = this.SpecManagementWindow.SpecManagementDocument.UIDiv_filterWindowBodyPane.EffectiveDate;
            HtmlEdit expireDate = this.SpecManagementWindow.SpecManagementDocument.UIDiv_filterWindowBodyPane.ExpireDate;
            HtmlInputButton applyButton = this.SpecManagementWindow.SpecManagementDocument.UIDiv_ComplexFilterPane1.ApplyButton;
            HtmlCheckBox exactMatchCheckBox = this.SpecManagementWindow.SpecManagementDocument.ExactMatchCheckBox;
            HtmlCheckBox latestVersionCheckBox = this.SpecManagementWindow.SpecManagementDocument.LatestVersionCheckBox;
            HtmlCheckBox matchCaseCheckBox = this.SpecManagementWindow.SpecManagementDocument.CaseCheckBox;
            HtmlInputButton closeButton = this.SpecManagementWindow.SpecManagementDocument.UIDiv_ComplexFilterPane2.CloseButton;

            #endregion

            #region Steps

            if (_findParam.ID != null)
            {
                // Type 'ID' in text box
                iD.Text = _findParam.ID;
            }

            if (_findParam.Version != null)
            {
                // Type 'Versions' in text box
                version.Text = _findParam.Version;
            }

            if (_findParam.Description != null)
            {
                // Type 'Descriptions' in text box
                description.Text = _findParam.Description;
            }

            if (_findParam.CheckOutBy != null)
            {
                // Type 'COB' in text box
                checkOutBy.Text = _findParam.CheckOutBy;
            }

            if (_findParam.Status != null)
            {
                // Type 'Statuss' in text box
                status.Text = _findParam.Status;
            }

            if (_findParam.lastChangeBy != null)
            {
                // Type 'LCB' in text box
                lastChangeby.Text = _findParam.lastChangeBy;
            }

            if (_findParam.lastChangeDate != null)
            {
                // Type 'LCD' in text box
                lastChangeDate.Text = _findParam.lastChangeDate;
            }

            if (_findParam.EffectivityDate != null)
            {
                // Type 'ED' in text box
                effectiveDate.Text = _findParam.EffectivityDate;
            }

            if (_findParam.ExpiryDate != null)
            {
                // Type 'ED' in text box
                expireDate.Text = _findParam.ExpiryDate;
            }

            // Click 'Apply' button
            Mouse.Click(applyButton, new Point(40, 11));

            if (_findParam.ExactMatchChkbox != false)
            {
                // Select 'cbxExactMatch' check box
                exactMatchCheckBox.Checked = _findParam.ExactMatchChkbox;
            }

            if (_findParam.LatestVersionChkbox != false)
            {
                // Select 'cbxExactMatch' check box
                latestVersionCheckBox.Checked = _findParam.LatestVersionChkbox;
            }

            if (_findParam.MatchCaseChkbox != false)
            {
                // Select 'cbxExactMatch' check box
                matchCaseCheckBox.Checked = _findParam.MatchCaseChkbox;
            }


            // Click 'Close' button
            Mouse.Click(closeButton, new Point(27, 9));

            #endregion

        }
    
    }

    public class SpecManagementNavParams
    {
        public string ModelName { get; set; }
        public string ItemName { get; set; }
        public string Action { get; set; }
    }

    public class SpecManagementGeneralParams
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string EffectivityDate { get; set; }
        public string ExpiryDate { get; set; }
        public bool EffectivityDateNowCheck { get; set; }
        public bool ExpiryDateNowCheck { get; set; }
        public string Icon { get; set; }
        public string ItemType { get; set; }
    }

    public class FindNewItemParams
    {

        #region Fields
        /// <summary>
        /// Type 'ID' in text box
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Type 'Versions' in text box
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Type 'Descriptions' in text box
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Type 'COB' in text box
        /// </summary>
        public string CheckOutBy { get; set; }

        /// <summary>
        /// Type 'Statuss' in text box
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Type 'LCB' in text box
        /// </summary>
        public string lastChangeBy { get; set; }

        /// <summary>
        /// Type 'LCD' in text box
        /// </summary>
        public string lastChangeDate { get; set; }

        /// <summary>
        /// Type 'ED' in text box
        /// </summary>
        public string EffectivityDate { get; set; }

        /// <summary>
        /// Type 'ED' in text box
        /// </summary>
        public string ExpiryDate { get; set; }

        public bool ExactMatchChkbox { get; set; }
        public bool LatestVersionChkbox { get; set; }
        public bool MatchCaseChkbox { get; set; }

        #endregion
    }

    public class SpecManagementType
    {
        public static string MaterialSpec = "Material Specification Properties";
        public static string EquipmentSpec = "Euqipment Specification Properties";
        public static string Instruction = "Instruction Class Properties";
        public static string IPTCharacteristics = "In-Process Test Class Properties";
        public static string BOM = "BOM Properties";
        public static string BOP = "BOP Properties";
        public static string BOE = "BOE Properties";
        public static string BOA = "BOA Properties";
        public static string BOT = "BOT Properties";
        public static string BOI = "BOI Properties";
        public static string BOS = "BOS Properties";
        public static string BOV = "BOV Properties";
        public static string Worksheet = "Worksheet Properties";
        public static string UnitProcedure = "Unit Procedure Properties";
        public static string Operation = "Operation Properties";
        public static string Phase = "BOI Properties";
        public static string Role = "Role Class Properties";
        public static string Variable = "Variable Class Properties";
    }

    public class TreeNode
    {
            public static string Master = "Master";
            public static string Herndon = "Herndon";
            public static string AssemblyModel = "Assembly Model";
            public static string BillsOfAssembly = "Bills of Assembly ";
            public static string EquipmentModel = "Equipment Model";
            public static string BillsOfEquipment = "Bills of Equipment";
            public static string EquipmentSpecifications = "Equipment Specifications";
            public static string InstructionModel = "Instruction Model";
            public static string BillsOfInstruction = "Bills of Instruction";
            public static string Instructions = "Instructions";
            public static string InprocessTestModel = "In-process Test Model";
            public static string BillsofTests = "Bills of Tests";
            public static string IPTCharacteristics = "IPT Characteristics";
            public static string MaterialModel = "Material Model";
            public static string BillsOfMaterial = "Bills of Materials";
            public static string BillsOfProduct = "Bills of Products";
            public static string MaterialSpecifications = "Material Specifications";
            public static string ProcessModel = "Process Model";
            public static string Worksheets = "Worksheets";
            public static string Recipes = "Recipes";
            public static string UnitProcedures = "Unit Procedures";
            public static string Operations = "Operations";
            public static string Phases = "Phases";
            public static string StaffModel = "Staff Model";
            public static string BillsOfStaff = "Bills of Staff";
            public static string Roles = "Roles";
            public static string VariableModel = "Variable Model";
            public static string BillsOfVariables = "Bills of Variables";
            public static string Variables = "Variables";
    }

    public class TreeNodeActions
    {
        public static string New = "New..";
        public static string Import = "Import..";
        public static string Find = "Find";
    }

    public class RightClickActions
    {
        public static string Open = "Open...";
        public static string New = "New...";
        public static string Copy = "Copy";
        public static string Paste = "Paste";
        public static string Find = "Find";
        public static string WhereUsed = "Where Used";
        public static string CheckOutForEditing = "Check Out for Editing";
        public static string Properties = "Properties...";
        public static string InvokeActionListEditor = "Invoke Action List Editor";
        public static string InvokfPFCEditor = "Invoke PFC Editor";
        public static string Import = "Import";
        public static string Export = "Export";
        public static string CompareVersions = "Compare Versions";
        public static string PrepareReport = "Prepare Report";
        public static string ComponentParameterReport = "Component Parameter Report";
        public static string MasterRecord = "Master Record";
        public static string MakeObselete = "Make Obselete";
        public static string Delete = "Delete";
        public static string Verify = "Verify";
        public static string Submit = "Submit";
        public static string Approved = "Approve";
        public static string Checkin = "Check In";
        public static string Unlock = "Unlock";
    }


}
