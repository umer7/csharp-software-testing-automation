namespace ProjectLibraryProcessModel.ProjectLibraryProcessModelClasses
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
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    
    //using System.Windows.Forms;
    
    
    public partial class ProcessModel
    {
        private Dictionary<string, string> _saveDictionary;
        private Dictionary<string, string> _closeDictionary;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProcessModel()
        {
            SaveProcesModelTabDictionary();
            CloseProcesModelTabDictionary();
        }

        #region Dictionay
        private void SaveProcesModelTabDictionary()
        {
            _saveDictionary = new Dictionary<string, string>();
            _saveDictionary.Add(ProcessModelTab.Attributes, "imgAttrSave");
            _saveDictionary.Add(ProcessModelTab.Parameters, "imgParamSave");
            _saveDictionary.Add(ProcessModelTab.Bills, "imgBillSave");
            _saveDictionary.Add(ProcessModelTab.Worksheets, "imgWksSave");
            _saveDictionary.Add(ProcessModelTab.StatusTypes, "imgStSaveSt");
        }

        private void CloseProcesModelTabDictionary()
        {
            _closeDictionary = new Dictionary<string, string>();
            _closeDictionary.Add(ProcessModelTab.Attributes, "imgAttrClose");
            _closeDictionary.Add(ProcessModelTab.Parameters, "imgParamClose");
            _closeDictionary.Add(ProcessModelTab.Bills, "imgBillClose");
            _closeDictionary.Add(ProcessModelTab.Components, "img1");
            _closeDictionary.Add(ProcessModelTab.Worksheets, "imgWksClose");
            _closeDictionary.Add(ProcessModelTab.StatusTypes, "img3");
        }

        #endregion

        /// <summary>
        /// set recipe attributes
        /// </summary>
        /// <param name="setAttributesParams"></param>
        public void SetRecipeAttributes(SetRecipeAttributesParams setAttributesParams)
        {
            BrowserWindow optionWindow = new BrowserWindow();

            optionWindow.SearchProperties[UITestControl.PropertyNames.Name] = "Attributes for - " + setAttributesParams.ObjectName;
            optionWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            optionWindow.WindowTitles.Add("Attributes for - " + setAttributesParams.ObjectName);


            HtmlHeaderCell attributesTab = new HtmlHeaderCell(optionWindow);
            HtmlTextArea maximum = new HtmlTextArea(optionWindow);
            HtmlTextArea minimum = new HtmlTextArea(optionWindow);
            HtmlTextArea target = new HtmlTextArea(optionWindow);
            HtmlCustom autoRelease = new HtmlCustom(optionWindow);
            HtmlCustom productID = new HtmlCustom(optionWindow);
            HtmlCustom uOM = new HtmlCustom(optionWindow);
            HtmlCustom recipeType = new HtmlCustom(optionWindow);
            HtmlImage dropDown = new HtmlImage(optionWindow);
            HtmlComboBox span = new HtmlComboBox(optionWindow);
            HtmlDiv div = new HtmlDiv(optionWindow);


            attributesTab.SearchProperties[HtmlHeaderCell.PropertyNames.InnerText] = "Attributes";
            Mouse.Click(attributesTab);

            maximum.FilterProperties[HtmlTextArea.PropertyNames.Title] = "\n                                Attribute: Quantity / Element: Maximum";
            maximum.Text = setAttributesParams.RecipeMaximumQty;

            target.FilterProperties[HtmlTextArea.PropertyNames.Title] = "\n                                Attribute: Quantity / Element: Target Number";
            target.Text = setAttributesParams.RecipeTargetQty;

            minimum.FilterProperties[HtmlTextArea.PropertyNames.Title] = "\n                                Attribute: Quantity / Element: Minimum";
            minimum.Text = setAttributesParams.RecipeMinimumQty;

            Playback.Wait(3000);

            System.Web.Script.Serialization.JavaScriptSerializer jsArray = new System.Web.Script.Serialization.JavaScriptSerializer();
            var testArray = jsArray.Serialize(setAttributesParams.RecipeCustomControlAttribute);
            var resultTest = optionWindow.ExecuteScript(
            " var index = 0; var arrElementVal = " + testArray + "; var boxes = document.forms['ProcObjectGrid'].getElementsByTagName('input');" +
            " for (i = 0; i < boxes.length; i++)" +
            "{" +
            "   if (boxes[i].type == 'text')" +
            "     {" +
            " boxes[i].value = arrElementVal[index ++]; var inputElm = boxes[i]; inputElm.fireEvent('onchange'); }}");

            Playback.Wait(2000);
          
        }

        /// <summary>
        /// used to add bill to UP
        /// </summary>
        /// <param name="addBillParam"></param>
        public void AddBills(AddBillParams addBillParam)
        {
            BrowserWindow optionWindow = new BrowserWindow();
            BrowserWindow addBillWindow = new BrowserWindow();

            optionWindow.SearchProperties[UITestControl.PropertyNames.Name] = "Bills of X Objects for - " + addBillParam.ObjectName;
            optionWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            optionWindow.WindowTitles.Add("Bills of X Objects for - " + addBillParam.ObjectName);

            addBillWindow.SearchProperties[UITestControl.PropertyNames.Name] = "ProcBoxesPropsPage";
            addBillWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "Internet Explorer_TridentDlgFrame";
            addBillWindow.WindowTitles.Add("ProcBoxesPropsPage");

            HtmlHeaderCell billsTab = new HtmlHeaderCell(optionWindow);
            HtmlEdit billNumber = new HtmlEdit(addBillWindow);
            HtmlComboBox boxType = new HtmlComboBox(addBillWindow);
            HtmlComboBox billId = new HtmlComboBox(addBillWindow);
            HtmlComboBox boxVer = new HtmlComboBox(addBillWindow);
            HtmlCheckBox approvedCheckbox = new HtmlCheckBox(addBillWindow);
            HtmlCheckBox lastestVerCheckbox = new HtmlCheckBox(addBillWindow);
            HtmlComboBox boxLocation = new HtmlComboBox(addBillWindow);
            HtmlComboBox boxLevel = new HtmlComboBox(addBillWindow);
            HtmlDiv commentsTab = new HtmlDiv(optionWindow);
            HtmlEdit comments = new HtmlEdit(addBillWindow);
            HtmlInputButton oKButton = new HtmlInputButton(addBillWindow);
            HtmlImage addImage = new HtmlImage(optionWindow);

            billsTab.SearchProperties[HtmlHeaderCell.PropertyNames.InnerText] = "Bills";
            Mouse.Click(billsTab);

            addImage.SearchProperties[HtmlImage.PropertyNames.Id] = "imgBillAddBill";
            Mouse.Click(addImage);


            if (addBillParam.BillNumber != null)
            {
                billNumber.SearchProperties[HtmlEdit.PropertyNames.Id] = "txtBoxNo";
                billNumber.Text = addBillParam.BillNumber;
            }

            if (addBillParam.BillId != null)
            {
                boxType.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ddlBoxType";
                boxType.SelectedItem = addBillParam.BillType;
            }

            if (addBillParam.BillLevel != null)
            {
                boxLevel.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ddlBoxLevel";
                boxLevel.SelectedItem = addBillParam.BillLevel;
            }

            if (addBillParam.BillLocation != null)
            {
                boxLocation.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ddlBoxLocation";
                boxLocation.SelectedItem = addBillParam.BillLocation;
            }

            if (addBillParam.BillId != null)
            {
                billId.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ddlBoxId";
                billId.SelectedItem = addBillParam.BillId;
            }

            if (addBillParam.BillVersion != null)
            {
                boxVer.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ddlBoxVer";
                boxVer.SelectedItem = addBillParam.BillVersion;
            }

            if (addBillParam.ApprovedCheckBox == true)
            {
                approvedCheckbox.SearchProperties[HtmlCheckBox.PropertyNames.Id] = "chkApproved";
                approvedCheckbox.Checked = addBillParam.ApprovedCheckBox;
            }

            if (addBillParam.LatestCheckBox == true)
            {
                lastestVerCheckbox.SearchProperties[HtmlCheckBox.PropertyNames.Id] = "chkLatestVer";
                lastestVerCheckbox.Checked = addBillParam.LatestCheckBox;
            }


            if (addBillParam.Comments != null)
            {
                commentsTab.SearchProperties[HtmlDiv.PropertyNames.Id] = "tabstripPropPages_CommentsTab";
                Mouse.Click(commentsTab);

                billNumber.SearchProperties[HtmlEdit.PropertyNames.Id] = " txtComments";
                billNumber.Text = addBillParam.Comments;
            }


            oKButton.SearchProperties[HtmlInputButton.PropertyNames.Id] = "btnOK";
            oKButton.TryFind();
            Mouse.Click(oKButton);

        }

        /// <summary>
        /// used to set Unit Procedure attributes
        /// </summary>
        /// <param name="setAttributesParams"></param>
        public void SetUPAttributes(SetUPAttibutesParams setAttributesParams)
        {

            #region Initializations
            BrowserWindow UPAttributeWindow = new BrowserWindow();

            UPAttributeWindow.SearchProperties[UITestControl.PropertyNames.Name] = "Attributes for - " + setAttributesParams.ObjectName;
            UPAttributeWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            UPAttributeWindow.WindowTitles.Add("Attributes for - " + setAttributesParams.ObjectName);


            HtmlHeaderCell attributesTab = new HtmlHeaderCell(UPAttributeWindow);
            HtmlTextArea numberOfSplits = new HtmlTextArea(UPAttributeWindow);
            HtmlDiv div = new HtmlDiv(UPAttributeWindow);

            #endregion

            #region Value Setting
            attributesTab.SearchProperties[HtmlHeaderCell.PropertyNames.InnerText] = "Attributes";
            Mouse.Click(attributesTab);

            Playback.Wait(3000);
            
            System.Web.Script.Serialization.JavaScriptSerializer jsArray = new System.Web.Script.Serialization.JavaScriptSerializer();
            var testArray = jsArray.Serialize(setAttributesParams.UPCustomControlAttribute);
            var resultTest = UPAttributeWindow.ExecuteScript(
            " var index = 0; var arrElementVal = " + testArray + "; var boxes = document.forms['ProcObjectGrid'].getElementsByTagName('input');" +
            " for (i = 0; i < boxes.length; i++)" + 
            "{" +
            "   if (boxes[i].type == 'text')" +
            "     {"+
            " boxes[i].value = arrElementVal[index ++]; var inputElm = boxes[i]; inputElm.fireEvent('onchange'); }}");

            Playback.Wait(1000);
            
            if (setAttributesParams.NumberOfSplits != null)
            {
                numberOfSplits.FilterProperties[HtmlTextArea.PropertyNames.Title] = "\n                                Attribute: Number of Splits / Element: Integer";
                numberOfSplits.Text = setAttributesParams.NumberOfSplits;
            }

            #endregion

        }

        /// <summary>
        /// Used to click Save image of any Process Model item(Worksheet, Recipe, UP, OP and Phase) in any tab like Attributes, Bills, Parameter etc..
        /// </summary>
        /// <param name="TabName">Process Model Tab Name e.g: ProcessModelTab.Parameters, ProcessModelTab.Bills, ProcessModelTab.Attributes </param>
        public void SaveProcesModelTab(string TabName)
        {
            BrowserWindow processModelWindow = new BrowserWindow();
            processModelWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            HtmlImage saveButton = new HtmlImage(processModelWindow);

            saveButton.SearchProperties[HtmlImage.PropertyNames.Id] = _saveDictionary.ContainsKey(TabName) ? _saveDictionary[TabName] : "";
            saveButton.TryFind();
            Mouse.Click(saveButton);
        }

        /// <summary>
        /// Used to click Close image of any Process Model item(Worksheet, Recipe, UP, OP and Phase) in any tab like Attributes, Bills, Parameter etc..
        /// </summary>
        /// <param name="TabName">Process Model Tab Name e.g: ProcessModelTab.Parameters, ProcessModelTab.Bills, ProcessModelTab.Attributes </param>
        public void CloseProcesModelTab(string TabName)
        {
            BrowserWindow processModelWindow = new BrowserWindow();
            processModelWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            HtmlImage closeButton = new HtmlImage(processModelWindow);

            closeButton.SearchProperties[HtmlImage.PropertyNames.Id] = _closeDictionary.ContainsKey(TabName) ? _closeDictionary[TabName] : "";
            //closeButton.TryFind();
           // Mouse.Click(closeButton);
            processModelWindow.Close();
        }

        /// <summary>
        /// used to add phase to operation
        /// </summary>
        /// <param name="addPhaseToOperationParams"></param>
        public void AddPhaseToOperation(string PhaseID)
        {
            BrowserWindow _actionListEditorWindow = new BrowserWindow();
            BrowserWindow _actionItemProperties = new BrowserWindow();
            HtmlInputButton _newActionItemButton = new HtmlInputButton(_actionListEditorWindow);

            _actionItemProperties.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            HtmlDocument _actionItemPropertiesDoc = new HtmlDocument(_actionItemProperties);
            _actionItemPropertiesDoc.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/hoops/Apps/ActionListApp/CompProperties.aspx";

            HtmlButton _okButton = new HtmlButton(_actionItemPropertiesDoc);
            HtmlDiv _clickPhasePane = new HtmlDiv(_actionListEditorWindow);
            HtmlDiv _selectPhaseID = new HtmlDiv(_actionListEditorWindow);
            _actionListEditorWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";


            // Find and click New Action Item Button
            _newActionItemButton.SearchProperties[HtmlInputButton.PropertyNames.Id] = "NewLineButton";

            Playback.Wait(3000);
            if (_newActionItemButton.TryFind())
            {
                Mouse.Click(_newActionItemButton);

                // Find and click Phase in the drop-down
                _clickPhasePane.SearchProperties[HtmlDiv.PropertyNames.Id] = "dropgc_7";
                _clickPhasePane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "Phase";

                if (_clickPhasePane.TryFind())
                {
                    // Find and click Phase name in the drop-down
                    Mouse.Click(_clickPhasePane);

                    //_selectPhaseID.SearchProperties[HtmlDiv.PropertyNames.Name] = addPhaseToOperationParams.PhaseID;  //"RecordText, Ver. 1.001";
                    _selectPhaseID.FilterProperties[HtmlDiv.PropertyNames.InnerText] = PhaseID;//"RecordText, Ver. 1.001";
                    if (_selectPhaseID.TryFind())
                    {
                        Mouse.Click(_selectPhaseID);

                        _okButton.SearchProperties[HtmlButton.PropertyNames.Id] = "OKButton";
                        _okButton.SearchProperties[HtmlButton.PropertyNames.Type] = "button";
                        _okButton.FilterProperties[HtmlButton.PropertyNames.Class] = "SmallButton";

                        Playback.Wait(3000);
                        _okButton.TryFind();
                        Mouse.Click(_okButton);
                    }

                }

            }
        }

        /// <summary>
        /// used to add operation to UP
        /// </summary>
        /// <param name="addOperationToUPParams"></param>
        public void AddOperationToUP(string OperationID, string VersionID)
        {
            //Variable decleration
            BrowserWindow _PFCEditorUPWindow = new BrowserWindow();
            _PFCEditorUPWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            
            BrowserWindow _actionItemProperties = new BrowserWindow();
            //_actionItemProperties.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            HtmlInputButton _newActionItemButton = new HtmlInputButton(_PFCEditorUPWindow);
            HtmlDiv _uIOperationPane = new HtmlDiv(_PFCEditorUPWindow);
            HtmlDiv _selectOperationID = new HtmlDiv(_PFCEditorUPWindow);
            HtmlDiv _uIPFCPanelPane = new HtmlDiv(_PFCEditorUPWindow);
            HtmlDocument _actionItemPropertiesDoc = new HtmlDocument(_actionItemProperties);
            _actionItemPropertiesDoc.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/hoops/Apps/ActionListApp/CompProperties.aspx";
            _actionItemPropertiesDoc.WindowTitles.Contains ("New Operation Properties");
            HtmlButton _okButton = new HtmlButton(_actionItemPropertiesDoc);
            

            #region Search Criteria _newActionItemButton
            _newActionItemButton.SearchProperties[HtmlButton.PropertyNames.Id] = "NewLineButton";
            _newActionItemButton.FilterProperties[HtmlButton.PropertyNames.Type] = "button";
            #endregion

            if (_newActionItemButton.TryFind())
            {
                Mouse.Click(_newActionItemButton);

                #region Search Criteria _uIOperationPane
                _uIOperationPane.SearchProperties[HtmlDiv.PropertyNames.Id] = "dropgc_9";
                _uIOperationPane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "Operation";
                #endregion
                
                if (_uIOperationPane.TryFind())
                {
                    Mouse.Click(_uIOperationPane);

                    #region Search Criteria _selectOperationID
                    _selectOperationID.FilterProperties[HtmlDiv.PropertyNames.InnerText] = OperationID
                        + ", " + VersionID; 
                    #endregion

                   if (_selectOperationID.TryFind())
                    {
                        Playback.Wait(3000);
                        Mouse.Click(_selectOperationID);

                        _uIPFCPanelPane.SearchProperties[HtmlDiv.PropertyNames.Id] = "PFCPanel";

                        if (_uIPFCPanelPane.TryFind())
                        {
                            
                          Mouse.Click(_uIPFCPanelPane, new Point(140, 50));
                          
                            #region Search Criteria _okButton
                            _okButton.SearchProperties[HtmlButton.PropertyNames.Id] = "OKButton";
                            _okButton.SearchProperties[HtmlButton.PropertyNames.Type] = "button";
                            _okButton.FilterProperties[HtmlButton.PropertyNames.Class] = "SmallButton";
                            #endregion

                            Playback.Wait(5000);

                            _okButton.TryFind();
                            Mouse.Click(_okButton);
                            
                        }
                    }
                }
            }

        }

        /// <summary>
        /// used to add operation to UP
        /// </summary>
        /// <param name="addOperationToUPParams"></param>
        public void AddUPToRecipe(string UnitProcedureID, string VersionID)
        {
            //Variable decleration
            BrowserWindow _PFCEditorUPWindow = new BrowserWindow();
            _PFCEditorUPWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";

            BrowserWindow _actionItemProperties = new BrowserWindow();
            //_actionItemProperties.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            HtmlInputButton _newActionItemButton = new HtmlInputButton(_PFCEditorUPWindow);
            HtmlDiv _uIOperationPane = new HtmlDiv(_PFCEditorUPWindow);
            HtmlDiv _selectOperationID = new HtmlDiv(_PFCEditorUPWindow);
            HtmlDiv _uIPFCPanelPane = new HtmlDiv(_PFCEditorUPWindow);
            HtmlDocument _actionItemPropertiesDoc = new HtmlDocument(_actionItemProperties);
            _actionItemPropertiesDoc.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/hoops/Apps/ActionListApp/CompProperties.aspx";
            _actionItemPropertiesDoc.WindowTitles.Contains("New Unit Procedure Properties");
            HtmlButton _okButton = new HtmlButton(_actionItemPropertiesDoc);


            #region Search Criteria _newActionItemButton
            _newActionItemButton.SearchProperties[HtmlButton.PropertyNames.Id] = "NewLineButton";
            _newActionItemButton.FilterProperties[HtmlButton.PropertyNames.Type] = "button";
            #endregion

            if (_newActionItemButton.TryFind())
            {
                Mouse.Click(_newActionItemButton);

                #region Search Criteria _uIOperationPane
                _uIOperationPane.SearchProperties[HtmlDiv.PropertyNames.Id] = "dropgc_10";
                _uIOperationPane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "Unit Procedure";
                #endregion

                if (_uIOperationPane.TryFind())
                {
                    Mouse.Click(_uIOperationPane);

                    #region Search Criteria _selectOperationID
                    _selectOperationID.FilterProperties[HtmlDiv.PropertyNames.InnerText] = UnitProcedureID
                        + ", " + VersionID;
                    #endregion

                    if (_selectOperationID.TryFind())
                    {
                        Playback.Wait(3000);
                        Mouse.Click(_selectOperationID);

                        _uIPFCPanelPane.SearchProperties[HtmlDiv.PropertyNames.Id] = "PFCPanel";

                        if (_uIPFCPanelPane.TryFind())
                        {

                            Mouse.Click(_uIPFCPanelPane, new Point(140, 50));

                            #region Search Criteria _okButton
                            _okButton.SearchProperties[HtmlButton.PropertyNames.Id] = "OKButton";
                            _okButton.SearchProperties[HtmlButton.PropertyNames.Type] = "button";
                            _okButton.FilterProperties[HtmlButton.PropertyNames.Class] = "SmallButton";
                            #endregion

                            Playback.Wait(5000);

                            _okButton.TryFind();
                            Mouse.Click(_okButton);

                        }
                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDragStopDragParams"></param>
        public void StartDragStopDrag(string OperationID)

        {

            BrowserWindow _PFCEditorUPWindow = new BrowserWindow();
            _PFCEditorUPWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            _PFCEditorUPWindow.WindowTitles.Contains ("Editing Unit Procedure");
            HtmlImage _startBox = new HtmlImage(_PFCEditorUPWindow);
            HtmlImage _endBox = new HtmlImage(_PFCEditorUPWindow);
            HtmlImage _operationBox = new HtmlImage(_PFCEditorUPWindow);

            _startBox.SearchProperties[HtmlImage.PropertyNames.Id] = "obCmt0";
            _endBox.SearchProperties[HtmlImage.PropertyNames.Id] = "obCmt1";
            _operationBox.SearchProperties[HtmlImage.PropertyNames.Id] = "ob" + OperationID + "1"; //"ob19922_DisplayWarningOP1";

            _startBox.TryFind();
            _startBox.EnsureClickable();
            Mouse.StartDragging(_startBox);
            Mouse.StopDragging(_operationBox);

            _operationBox.TryFind();
            _operationBox.EnsureClickable();
            Mouse.StartDragging(_operationBox);
            Mouse.StopDragging(_endBox);
        
        }

        /// <summary>
        /// used to click save button in PFC editor
        /// </summary>
        public void SavePFCEditor()
        {
            BrowserWindow _PFCEditorUPWindow = new BrowserWindow();
            _PFCEditorUPWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";

            HtmlImage _saveButton = new HtmlImage(_PFCEditorUPWindow);
            _saveButton.SearchProperties[HtmlImage.PropertyNames.Id] = "SaveButton";

            _saveButton.TryFind();
            _saveButton.EnsureClickable();
            Mouse.Click(_saveButton);
            Playback.Wait(10000);
            
        }

        /// <summary>
        /// used to close PFC editor
        /// </summary>
        public void ClosePFCEditor()
        {

            BrowserWindow _PFCEditorUPWindow = new BrowserWindow();
            _PFCEditorUPWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            _PFCEditorUPWindow.Close();
        }

        /// <summary>
        /// Use to click on 'Open' button
        /// </summary>
        public void OpenMBR()
        {
            BrowserWindow browserWindow = new BrowserWindow();
            browserWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";

            WinToolBar toolBar = new WinToolBar(browserWindow);
            toolBar.SearchProperties[WinToolBar.PropertyNames.Name] = "Notification";

            WinButton okButton = new WinButton(toolBar);
            okButton.SearchProperties[WinButton.PropertyNames.Name] = "Open";

            Playback.Wait(3000);

            okButton.TryFind();
            Mouse.Click(okButton);
        }

        /// <summary>
        /// Use to verify the MBR report generate or not
        /// </summary>
        public void AssertMBRReport()
        {
            WinWindow winWindow = new WinWindow();
            winWindow.SearchProperties[WinWindow.PropertyNames.Name] = "AVPageView";
            winWindow.SearchProperties[WinWindow.PropertyNames.ClassName] = "AVL_AVView";
            winWindow.WindowTitles.Add("report.pdf - Adobe Reader");
            winWindow.TryFind();

            WinTitleBar mbrTitleBar = new WinTitleBar(winWindow);

            WinButton closeButton = new WinButton(winWindow);
            closeButton.SearchProperties[WinButton.PropertyNames.Name] = "Close";
            closeButton.TryFind();

            string MBRExpectedText = "report.pdf - Adobe Reader";

            StringAssert.Contains(MBRExpectedText, mbrTitleBar.DisplayText, "Assertion Failed: MBR not generated");
            Playback.Wait(2000);

            Mouse.Click(closeButton);
        }
    }

    public class SetRecipeAttributesParams
    {
        /// <summary>
        /// Recipe ID
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// Recipe Maximum Quantity
        /// </summary>
        public string RecipeMaximumQty { get; set; }

        /// <summary>
        /// Recipe Target Quantity
        /// </summary>
        public string RecipeTargetQty { get; set; }

        /// <summary>
        /// REcipe Minimum Quantity
        /// </summary>
        public string RecipeMinimumQty { get; set; }

        /// <summary>
        /// Recipe Attributes except MAXIMUM, TARGETNUMBER, MINIMUM
        /// e.g: {"Yes", "M999093", "g", "Production"}
        /// </summary>
        public string[] RecipeCustomControlAttribute { get; set; }
    }

    public class SetUPAttibutesParams
    {
        /// <summary>
        /// Unit Procedure ID
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// Should be an integer e.g: 1,2,3...
        /// </summary>
        public string NumberOfSplits { get; set; }

        /// <summary>
        /// UP Attributes except No of Splits
        /// e.g: {"Yes", "Yes", "No", "Operator Security", "ProductionOperator", "Verifier Security", "ProductionVerifier", "Alternate Security", "ProductionVerifier", "1000L Bulk Tank"}
        /// </summary>
        public string [] UPCustomControlAttribute { get; set; }
    }

    public class ProcessModelTab
    {
        public static string Attributes = "Attributes";
        public static string Parameters = "Parameters";
        public static string Bills = "Bills";
        public static string Components = "Components";
        public static string Worksheets = "Worksheets";
        public static string StatusTypes = "Status Types";
    }

    public class AddBillParams
    {
        public string ObjectName { get; set; }
        public string BillNumber { get; set; }
        public string BillType { get; set; }
        public string BillId { get; set; }
        public string BillLevel { get; set; }
        public string BillLocation { get; set; }
        public string BillVersion { get; set; }
        public bool ApprovedCheckBox { get; set; }
        public bool LatestCheckBox { get; set; }
        public string Comments { get; set; }
    }
}
