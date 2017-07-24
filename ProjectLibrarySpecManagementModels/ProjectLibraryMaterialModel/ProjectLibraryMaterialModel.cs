namespace ProjectLibraryMaterialModel.ProjectLibraryMaterialModelClasses
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
    using System.Windows.Forms;
    
    
    public partial class MaterialModel
    {
        /// <summary>
        /// set values of BOM line items attributes 
        /// </summary>
        /// <param name="matLineItemParam"></param>
        public void SetBOMLineItemsAttributesR400(SetBOMLineItemsParams matLineItemParam)
        {
            #region Search Criteria
            BrowserWindow bw = new BrowserWindow();
            bw.SearchProperties[UITestControl.PropertyNames.Name] = "Line Item(s)";
            bw.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            bw.WindowTitles.Add("Line Item(s)");

            Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument hDoc = new Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument(bw);
            hDoc.FilterProperties[Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument.PropertyNames.AbsolutePath] = "/Hoops/Apps/especwebapplication/eSpecLineItems.aspx";

            HtmlTable table = new HtmlTable(bw);
            table.SearchProperties[HtmlTable.PropertyNames.Id] = "dgItems";
            HtmlComboBox additionGroup = new HtmlComboBox(bw);
            HtmlComboBox allowBatchStaging = new HtmlComboBox(bw);
            HtmlComboBox allowWhseDispense = new HtmlComboBox(bw);
            HtmlComboBox checkin = new HtmlComboBox(bw);
            HtmlComboBox checkWeighRule = new HtmlComboBox(bw);
            HtmlTextArea checkWeighTolerance = new HtmlTextArea(bw);
            HtmlTextArea dispenseComment = new HtmlTextArea(bw);
            HtmlComboBox dispenseMethod = new HtmlComboBox(bw);
            HtmlComboBox dispenseUOM = new HtmlComboBox(bw);
            HtmlComboBox dispenseAreaID = new HtmlComboBox(bw);
            HtmlComboBox dispenseAreaType = new HtmlComboBox(bw);
            HtmlTextArea dispenseToleranceLower = new HtmlTextArea(bw);
            HtmlComboBox dispenseToleranceRule = new HtmlComboBox(bw);
            HtmlTextArea dispenseToleranceUpper = new HtmlTextArea(bw);
            HtmlComboBox equipmentClass = new HtmlComboBox(bw);
            HtmlTextArea eXT_BOM_REF_NO = new HtmlTextArea(bw);
            HtmlTextArea materialQty = new HtmlTextArea(bw);
            HtmlComboBox materialQtyUOM = new HtmlComboBox(bw);
            HtmlComboBox Optimizable = new HtmlComboBox(bw);
            HtmlTextArea percentageYield = new HtmlTextArea(bw);
            HtmlComboBox scaleClass = new HtmlComboBox(bw);
            HtmlComboBox scalingRule = new HtmlComboBox(bw);
            HtmlComboBox transfer = new HtmlComboBox(bw);
            HtmlCell allowBatchStagingCell = new HtmlCell(bw);
            HtmlCell allowWhseDispenseCell = new HtmlCell(bw);

           allowBatchStagingCell.SearchProperties[HtmlCell.PropertyNames.InnerText] = "Allow Batch Staging";
           allowWhseDispenseCell.SearchProperties[HtmlCell.PropertyNames.InnerText] = "Allow Whse Dispense";

            int FirstLineItemHtmlCombo, FirstLineItemHtmlEdit;
            string ExpandCollapseTagInstance = (matLineItemParam.RefLineNumber + 12).ToString();


            if (matLineItemParam.RefLineNumber == 1)
            {
                FirstLineItemHtmlCombo = 2;
            }
            else
            {
                FirstLineItemHtmlCombo = (17 * matLineItemParam.RefLineNumber) - 17 + 2;
                
            }
            
            FirstLineItemHtmlEdit = (7 * matLineItemParam.RefLineNumber) - 7 + 1;

            #endregion

            #region set values on HTMLCOMBO
            if (matLineItemParam.AdditionGroup != null)
            {

                additionGroup.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = FirstLineItemHtmlCombo.ToString();
                additionGroup.SelectedItem = matLineItemParam.AdditionGroup;
            }

            if (matLineItemParam.AllowBatchStaging != null)
            {
                allowBatchStaging.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 1).ToString();
                allowBatchStaging.SelectedItem = matLineItemParam.AllowBatchStaging;
            }

            if (matLineItemParam.AllowWhseDispense != null)
            {
                allowWhseDispense.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 2).ToString();
                allowWhseDispense.SelectedItem = matLineItemParam.AllowWhseDispense;
            }

            if (matLineItemParam.Checkin != null)
            {
                checkin.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 3).ToString();
                checkin.SelectedItem = matLineItemParam.Checkin;
            }

            if (matLineItemParam.CheckWeighRule != null)
            {
                checkWeighRule.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 4).ToString();
                checkWeighRule.SelectedItem = matLineItemParam.CheckWeighRule;
            }

            if (matLineItemParam.DispenseMethod != null)
            {
                dispenseMethod.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 5).ToString();
                dispenseMethod.SelectedItem = matLineItemParam.DispenseMethod;
            }

            if (matLineItemParam.DispenseUOM != null)
            {
                dispenseUOM.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 6).ToString();
                dispenseUOM.SelectedItem = matLineItemParam.DispenseUOM;
            }

            if (matLineItemParam.DispenseAreaType != null)
            {
                dispenseAreaType.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 8).ToString();
                dispenseAreaType.SelectedItem = matLineItemParam.DispenseAreaType;
            }

            if (matLineItemParam.DispenseAreaID != null)
            {
                dispenseAreaID.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 7).ToString();
                dispenseAreaID.SelectedItem = matLineItemParam.DispenseAreaID;
            }

            if (matLineItemParam.DispenseToleranceRule != null)
            {
                dispenseToleranceRule.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 9).ToString();
                dispenseToleranceRule.SelectedItem = matLineItemParam.DispenseToleranceRule;
            }

            if (matLineItemParam.EquipmentClass != null)
            {
                equipmentClass.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 10).ToString();
                equipmentClass.SelectedItem = matLineItemParam.EquipmentClass;
            }

            if (matLineItemParam.MaterialQtyUOM != null)
            {
                materialQtyUOM.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 11).ToString();
                materialQtyUOM.SelectedItem = matLineItemParam.MaterialQtyUOM;
            }

            if (matLineItemParam.Optimizable != null)
            {
                Optimizable.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 12).ToString();
                Optimizable.SelectedItem = matLineItemParam.Optimizable;
            }

            if (matLineItemParam.ScaleClass != null)
            {
                scaleClass.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 13).ToString();
                scaleClass.SelectedItem = matLineItemParam.ScaleClass;
            }

            if (matLineItemParam.ScalingRule != null)
            {
                scalingRule.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 14).ToString();
                scalingRule.SelectedItem = matLineItemParam.ScalingRule;
            }

            if (matLineItemParam.Transfer != null)
            {
                transfer.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 15).ToString();
                transfer.SelectedItem = matLineItemParam.Transfer;
            }

            #endregion
            
            #region Set values on HTMLTextArea

            if (matLineItemParam.CheckWeighTolerance != null)
            {

                checkWeighTolerance.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = FirstLineItemHtmlEdit.ToString();
                checkWeighTolerance.Text = matLineItemParam.CheckWeighTolerance;
            }

            if (matLineItemParam.DispenseComment != null)
            {

                dispenseComment.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = (FirstLineItemHtmlEdit + 1).ToString();
                dispenseComment.Text = matLineItemParam.DispenseComment;
            }

            if (matLineItemParam.DispenseToleranceLower != null)
            {

                dispenseToleranceLower.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = (FirstLineItemHtmlEdit + 2).ToString();
                dispenseToleranceLower.Text = matLineItemParam.DispenseToleranceLower;
            }

            if (matLineItemParam.DispenseToleranceUpper != null)
            {

                dispenseToleranceUpper.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = (FirstLineItemHtmlEdit + 3).ToString();
                dispenseToleranceUpper.Text = matLineItemParam.DispenseToleranceUpper;
            }

            if (matLineItemParam.EXT_BOM_REF_NO != null)
            {

                eXT_BOM_REF_NO.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = (FirstLineItemHtmlEdit + 4).ToString();
                eXT_BOM_REF_NO.Text = matLineItemParam.EXT_BOM_REF_NO;
            }
            if (matLineItemParam.MaterialQty != null)
            {

                materialQty.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = (FirstLineItemHtmlEdit + 5).ToString();
                materialQty.Text = matLineItemParam.MaterialQty;
            }

            if (matLineItemParam.PercentageYield != null)
            {

                percentageYield.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = (FirstLineItemHtmlEdit + 6).ToString();
                percentageYield.Text = matLineItemParam.PercentageYield;
            }


            #endregion
        }

        /// <summary>
        /// set values of BOM line items attributes 
        /// </summary>
        /// <param name="matLineItemParam"></param>
        public void SetBOMLineItemsAttributesR340(SetBOMLineItemsParams matLineItemParam)
        {
            #region Search Criteria
            BrowserWindow bw = new BrowserWindow();
            bw.SearchProperties[UITestControl.PropertyNames.Name] = "Line Item(s)";
            bw.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            bw.WindowTitles.Add("Line Item(s)");

            Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument hDoc = new Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument(bw);
            hDoc.FilterProperties[Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument.PropertyNames.AbsolutePath] = "/Hoops/Apps/especwebapplication/eSpecLineItems.aspx";

            HtmlTable table = new HtmlTable(bw);
            table.SearchProperties[HtmlTable.PropertyNames.Id] = "dgItems";
            HtmlComboBox additionGroup = new HtmlComboBox(bw);
            HtmlComboBox checkin = new HtmlComboBox(bw);
            HtmlComboBox checkWeighRule = new HtmlComboBox(bw);
            HtmlTextArea checkWeighTolerance = new HtmlTextArea(bw);
            HtmlTextArea dispenseComment = new HtmlTextArea(bw);
            HtmlComboBox dispenseMethod = new HtmlComboBox(bw);
            HtmlComboBox dispenseUOM = new HtmlComboBox(bw);
            HtmlComboBox dispenseAreaID = new HtmlComboBox(bw);
            HtmlComboBox dispenseAreaType = new HtmlComboBox(bw);
            HtmlTextArea dispenseToleranceLower = new HtmlTextArea(bw);
            HtmlComboBox dispenseToleranceRule = new HtmlComboBox(bw);
            HtmlTextArea dispenseToleranceUpper = new HtmlTextArea(bw);
            HtmlComboBox equipmentClass = new HtmlComboBox(bw);
            HtmlTextArea eXT_BOM_REF_NO = new HtmlTextArea(bw);
            HtmlTextArea materialQty = new HtmlTextArea(bw);
            HtmlComboBox materialQtyUOM = new HtmlComboBox(bw);
            HtmlComboBox Optimizable = new HtmlComboBox(bw);
            HtmlTextArea percentageYield = new HtmlTextArea(bw);
            HtmlComboBox scaleClass = new HtmlComboBox(bw);
            HtmlComboBox scalingRule = new HtmlComboBox(bw);
            HtmlComboBox transfer = new HtmlComboBox(bw);
            HtmlCell allowBatchStagingCell = new HtmlCell(bw);
            HtmlCell allowWhseDispenseCell = new HtmlCell(bw);

            int FirstLineItemHtmlCombo, FirstLineItemHtmlEdit;
            string ExpandCollapseTagInstance = (matLineItemParam.RefLineNumber + 12).ToString();


            if (matLineItemParam.RefLineNumber == 1)
            {
                FirstLineItemHtmlCombo = 2;
            }
            else
            {
                FirstLineItemHtmlCombo = (15 * matLineItemParam.RefLineNumber) - 15 + 2;

            }

            FirstLineItemHtmlEdit = (7 * matLineItemParam.RefLineNumber) - 7 + 1;

            #endregion

            #region set values on HTMLCOMBO
            if (matLineItemParam.AdditionGroup != null)
            {

                additionGroup.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = FirstLineItemHtmlCombo.ToString();
                additionGroup.SelectedItem = matLineItemParam.AdditionGroup;
            }

            if (matLineItemParam.Checkin != null)
            {
                checkin.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 1).ToString();
                checkin.SelectedItem = matLineItemParam.Checkin;
            }

            if (matLineItemParam.CheckWeighRule != null)
            {
                checkWeighRule.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 2).ToString();
                checkWeighRule.SelectedItem = matLineItemParam.CheckWeighRule;
            }

            if (matLineItemParam.DispenseMethod != null)
            {
                dispenseMethod.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 3).ToString();
                dispenseMethod.SelectedItem = matLineItemParam.DispenseMethod;
            }

            if (matLineItemParam.DispenseUOM != null)
            {
                dispenseUOM.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 4).ToString();
                dispenseUOM.SelectedItem = matLineItemParam.DispenseUOM;
            }

            if (matLineItemParam.DispenseAreaType != null)
            {
                dispenseAreaType.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 5).ToString();
                dispenseAreaType.SelectedItem = matLineItemParam.DispenseAreaType;
            }

            if (matLineItemParam.DispenseAreaID != null)
            {
                dispenseAreaID.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 6).ToString();
                dispenseAreaID.SelectedItem = matLineItemParam.DispenseAreaID;
            }

            if (matLineItemParam.DispenseToleranceRule != null)
            {
                dispenseToleranceRule.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 7).ToString();
                dispenseToleranceRule.SelectedItem = matLineItemParam.DispenseToleranceRule;
            }

            if (matLineItemParam.EquipmentClass != null)
            {
                equipmentClass.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 8).ToString();
                equipmentClass.SelectedItem = matLineItemParam.EquipmentClass;
            }

            if (matLineItemParam.MaterialQtyUOM != null)
            {
                materialQtyUOM.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 9).ToString();
                materialQtyUOM.SelectedItem = matLineItemParam.MaterialQtyUOM;
            }

            if (matLineItemParam.Optimizable != null)
            {
                Optimizable.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 10).ToString();
                Optimizable.SelectedItem = matLineItemParam.Optimizable;
            }

            if (matLineItemParam.ScaleClass != null)
            {
                scaleClass.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 11).ToString();
                scaleClass.SelectedItem = matLineItemParam.ScaleClass;
            }

            if (matLineItemParam.ScalingRule != null)
            {
                scalingRule.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 12).ToString();
                scalingRule.SelectedItem = matLineItemParam.ScalingRule;
            }

            if (matLineItemParam.Transfer != null)
            {
                transfer.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItemHtmlCombo + 13).ToString();
                transfer.SelectedItem = matLineItemParam.Transfer;
            }

            #endregion

            #region Set values on HtmlTextArea

            if (matLineItemParam.CheckWeighTolerance != null)
            {

                checkWeighTolerance.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = FirstLineItemHtmlEdit.ToString();
                checkWeighTolerance.Text = matLineItemParam.CheckWeighTolerance;
            }

            if (matLineItemParam.DispenseComment != null)
            {

                dispenseComment.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = (FirstLineItemHtmlEdit + 1).ToString();
                dispenseComment.Text = matLineItemParam.DispenseComment;
            }

            if (matLineItemParam.DispenseToleranceLower != null)
            {

                dispenseToleranceLower.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = (FirstLineItemHtmlEdit + 2).ToString();
                dispenseToleranceLower.Text = matLineItemParam.DispenseToleranceLower;
            }

            if (matLineItemParam.DispenseToleranceUpper != null)
            {

                dispenseToleranceUpper.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = (FirstLineItemHtmlEdit + 3).ToString();
                dispenseToleranceUpper.Text = matLineItemParam.DispenseToleranceUpper;
            }

            if (matLineItemParam.EXT_BOM_REF_NO != null)
            {

                eXT_BOM_REF_NO.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = (FirstLineItemHtmlEdit + 4).ToString();
                eXT_BOM_REF_NO.Text = matLineItemParam.EXT_BOM_REF_NO;
            }
            if (matLineItemParam.MaterialQty != null)
            {

                materialQty.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = (FirstLineItemHtmlEdit + 5).ToString();
                materialQty.Text = matLineItemParam.MaterialQty;
            }

            if (matLineItemParam.PercentageYield != null)
            {

                percentageYield.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = (FirstLineItemHtmlEdit + 6).ToString();
                percentageYield.Text = matLineItemParam.PercentageYield;
            }

            #endregion
        }

        /// <summary>
        /// set values of BOP Line items attributes
        /// </summary>
        /// <param name="bOPLineItemParam"></param>
        public void SetBOPLineItemsAttributes(SetBOPLineItemsParams bOPLineItemParam)
        {
            #region Search Criteria
            BrowserWindow bw = new BrowserWindow();
            bw.SearchProperties[UITestControl.PropertyNames.Name] = "Line Item(s)";
            bw.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            bw.WindowTitles.Add("Line Item(s)");

            Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument hDoc = new Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument(bw);
            hDoc.FilterProperties[Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument.PropertyNames.AbsolutePath] = "/Hoops/Apps/especwebapplication/eSpecLineItems.aspx";

            HtmlComboBox productUOM = new HtmlComboBox(bw);
            HtmlTextArea productQty = new HtmlTextArea(bw);

            int FirstLineItem;

            if (bOPLineItemParam.RefLineNumber == 1)
            {
                FirstLineItem = 2;
            }
            else
            {
                FirstLineItem = (3 * bOPLineItemParam.RefLineNumber) - 2 + 1;
            }
            #endregion

            #region set values
           
            if (bOPLineItemParam.ProductQuantity != null)
            {

                productQty.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (bOPLineItemParam.RefLineNumber).ToString();
                productQty.Text = bOPLineItemParam.ProductQuantity;
            }

            if (bOPLineItemParam.ProductUOM != null)
            {

                productUOM.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItem).ToString();
                productUOM.SelectedItem = bOPLineItemParam.ProductUOM;
            }

            #endregion
        }

        /// <summary>
        /// Generic method used to click add line button and set values on properties window 
        /// </summary>
        /// <param name="addLineItemsParams"></param>
        public void CreateNewLineItem(CreateNewLineItemParams addLineItemsParams)
        {
            BrowserWindow addLineItemWindow = new BrowserWindow();
            addLineItemWindow.SearchProperties[UITestControl.PropertyNames.Name] = "Line Item(s)";
            addLineItemWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            addLineItemWindow.WindowTitles.Add("Line Item(s)");

            Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument hDoc = new Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument(addLineItemWindow);
            hDoc.FilterProperties[Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument.PropertyNames.AbsolutePath] = "/Hoops/Apps/especwebapplication/eSpecLineItems.aspx";


            BrowserWindow createLineWindow = new BrowserWindow();

            createLineWindow.SearchProperties[UITestControl.PropertyNames.Name] = "BoxObjectLineItemsPropsPage";
            createLineWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "Internet Explorer_TridentDlgFrame";
            createLineWindow.WindowTitles.Add("BoxObjectLineItemsPropsPage");

            
            
            HtmlEdit itemRefNo = new HtmlEdit(createLineWindow);
            HtmlEdit subNo = new HtmlEdit(createLineWindow);
            HtmlImage addLineImage = new HtmlImage(addLineItemWindow);

            HtmlComboBox itemLevel = new HtmlComboBox(createLineWindow);
            HtmlComboBox itemLocation = new HtmlComboBox(createLineWindow);
            HtmlComboBox itemId = new HtmlComboBox(createLineWindow);
            HtmlComboBox itemVersion = new HtmlComboBox(createLineWindow);
            HtmlComboBox activeFlag = new HtmlComboBox(createLineWindow);
            HtmlComboBox aggregateFlag = new HtmlComboBox(createLineWindow);
            HtmlCheckBox approvedCheckbox = new HtmlCheckBox(createLineWindow);
            HtmlCheckBox lastestVerCheckbox = new HtmlCheckBox(createLineWindow);
            HtmlInputButton oKButton = new HtmlInputButton(createLineWindow);

            addLineImage.FilterProperties[HtmlImage.PropertyNames.TagInstance] = "7";
            Mouse.Click(addLineImage);

            if (addLineItemsParams.ItemRefNo != null)
            {
                itemRefNo.SearchProperties[HtmlEdit.PropertyNames.Id] = "txtRefNo";
                itemRefNo.Text = addLineItemsParams.ItemRefNo;
            }

            if (addLineItemsParams.SubstitutionNo != null)
            {
                subNo.SearchProperties[HtmlEdit.PropertyNames.Id] = "txtSubNo";
                subNo.Text = addLineItemsParams.SubstitutionNo;
            }

            if (addLineItemsParams.ItemLevel != null)
            {
                itemLevel.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ddlItemLevel";
                itemLevel.SelectedItem = addLineItemsParams.ItemLevel;
            }

            if (addLineItemsParams.ItemLocation != null)
            {
                itemLocation.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ddlItemLocation";
                itemLocation.SelectedItem = addLineItemsParams.ItemLocation;
            }

            if (addLineItemsParams.ItemId != null)
            {
                itemId.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ddlItemId";
                itemId.SelectedItem = addLineItemsParams.ItemId;
            }

            if (addLineItemsParams.ItemVersion != null)
            {
                itemVersion.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ddlItemVer";
                itemVersion.SelectedItem = addLineItemsParams.ItemVersion;
            }

            if (addLineItemsParams.ActiveFlag != null)
            {
                activeFlag.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ddlActiveFlag";
                activeFlag.SelectedItem = addLineItemsParams.ActiveFlag;
            }

            if (addLineItemsParams.AggregateFlag != null)
            {
                aggregateFlag.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ddlAggregateFlag";
                aggregateFlag.SelectedItem = addLineItemsParams.AggregateFlag;
            }

            if (addLineItemsParams.ApprovedCheckBox == true)
            {
                approvedCheckbox.SearchProperties[HtmlCheckBox.PropertyNames.Id] = "chkApproved";
                approvedCheckbox.Checked = addLineItemsParams.ApprovedCheckBox;
            }

            if (addLineItemsParams.ApprovedCheckBox == true)
            {
                lastestVerCheckbox.SearchProperties[HtmlCheckBox.PropertyNames.Id] = "chkLatestVer";
                lastestVerCheckbox.Checked = addLineItemsParams.ApprovedCheckBox;
            }


            oKButton.SearchProperties[HtmlInputButton.PropertyNames.Id] = "btnOK";
            Mouse.Click(oKButton);

        }

        /// <summary>
        /// set attributes of material for Common Class only 
        /// </summary>
        /// <param name="materialAttributeParams"></param>
        public void SetMaterialAttributes(SetMaterialAttributesParams materialAttributeParams)
        {
            #region Initializations
            BrowserWindow materialAttributeWindow = new BrowserWindow();
            materialAttributeWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";

            Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument materialAttributeDocument = new Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument(materialAttributeWindow);
            materialAttributeDocument.FilterProperties[Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument.PropertyNames.AbsolutePath] = "/Hoops/Apps/especwebapplication/eSpecAttrElemGrid.aspx";
                                                                                                                                                     

            HtmlTable aliquotStockTable = new HtmlTable(materialAttributeDocument);
            HtmlTable defaultQuantityTable = new HtmlTable(materialAttributeDocument);
            HtmlTable inventoryTrackingTable = new HtmlTable(materialAttributeDocument);
            HtmlTable inventoryUOMTable = new HtmlTable(materialAttributeDocument);
            HtmlTable lotLvlUOMConvertTable = new HtmlTable(materialAttributeDocument);
            HtmlTable materialTypeTable = new HtmlTable(materialAttributeDocument);
            HtmlTable productTypeTable = new HtmlTable(materialAttributeDocument);
            HtmlTable storageClassTable = new HtmlTable(materialAttributeDocument);
           
            aliquotStockTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.0";
            defaultQuantityTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.1";
            inventoryTrackingTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.2";
            inventoryUOMTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.3";
            lotLvlUOMConvertTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.4";
            materialTypeTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.5";
            productTypeTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.6";
            storageClassTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.7";

            HtmlComboBox aliquotStockComboBox = new HtmlComboBox(aliquotStockTable);
            HtmlComboBox defaultQuantityComboBox = new HtmlComboBox(defaultQuantityTable);
            HtmlComboBox inventoryTrackingComboBox = new HtmlComboBox(inventoryTrackingTable);
            HtmlComboBox inventoryUOMComboBox = new HtmlComboBox(inventoryUOMTable);
            HtmlComboBox lotLvlUOMConvertComboBox = new HtmlComboBox(lotLvlUOMConvertTable);
            HtmlComboBox materialTypeComboBox = new HtmlComboBox(materialTypeTable);
            HtmlEdit productTypeTextBox = new HtmlEdit(productTypeTable);
            HtmlComboBox storageClassComboBox = new HtmlComboBox(storageClassTable);


            aliquotStockComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
            defaultQuantityComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
            inventoryTrackingComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
            inventoryUOMComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
            lotLvlUOMConvertComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
            materialTypeComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
            productTypeTextBox.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "1";
            storageClassComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";

            #endregion

            #region set values 

            if (materialAttributeParams.AliquoteStock != null && aliquotStockComboBox.TryFind())
            {
                aliquotStockComboBox.SelectedItem = materialAttributeParams.AliquoteStock;
            }

            if (materialAttributeParams.DefaultQuantityStatus != null && defaultQuantityComboBox.TryFind())
            {
                defaultQuantityComboBox.SelectedItem = materialAttributeParams.DefaultQuantityStatus;
            }

            if (materialAttributeParams.InventoryTracking != null && inventoryTrackingComboBox.TryFind())
            {
                inventoryTrackingComboBox.SelectedItem = materialAttributeParams.InventoryTracking;
            }

            if (materialAttributeParams.InventoryUOM != null && inventoryUOMComboBox.TryFind())
            {
                inventoryUOMComboBox.SelectedItem = materialAttributeParams.InventoryUOM;
            }

            if (materialAttributeParams.LotLvlUOMConvert != null && lotLvlUOMConvertComboBox.TryFind())
            {
                lotLvlUOMConvertComboBox.SelectedItem = materialAttributeParams.LotLvlUOMConvert;
            }

            if (materialAttributeParams.MaterialType != null && materialTypeComboBox.TryFind())
            {
                materialTypeComboBox.SelectedItem = materialAttributeParams.MaterialType;
            }

            if (materialAttributeParams.ProductType != null && productTypeTextBox.TryFind())
            {
                productTypeTextBox.Text = materialAttributeParams.ProductType;
            }

            if (materialAttributeParams.StorageClass != null && storageClassComboBox.TryFind())
            {
                storageClassComboBox.SelectedItem = materialAttributeParams.StorageClass;
            }
            #endregion
        }

        /// <summary>
        /// set attributes of material having Common and Assay class
        /// </summary>
        /// <param name="materialAttributeParams"></param>
        public void SetMaterialAttributesWithAssayClass(SetMaterialAttributesParams materialAttributeParams)
        {
            #region Initializations
            BrowserWindow materialAttributeWindow = new BrowserWindow();
            materialAttributeWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";

            Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument materialAttributeDocument = new Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument(materialAttributeWindow);
            materialAttributeDocument.FilterProperties[Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument.PropertyNames.AbsolutePath] = "/Hoops/Apps/especwebapplication/eSpecAttrElemGrid.aspx";

            HtmlTable aliquotStockTable = new HtmlTable(materialAttributeDocument);
            HtmlTable assayTable = new HtmlTable(materialAttributeDocument);
            HtmlTable defaultQuantityTable = new HtmlTable(materialAttributeDocument);
            HtmlTable inventoryTrackingTable = new HtmlTable(materialAttributeDocument);
            HtmlTable inventoryUOMTable = new HtmlTable(materialAttributeDocument);
            HtmlTable lotLvlUOMConvertTable = new HtmlTable(materialAttributeDocument);
            HtmlTable materialTypeTable = new HtmlTable(materialAttributeDocument);
            HtmlTable productTypeTable = new HtmlTable(materialAttributeDocument);
            HtmlTable storageClassTable = new HtmlTable(materialAttributeDocument);

            aliquotStockTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.0";
            assayTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.1";
            defaultQuantityTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.2";
            inventoryTrackingTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.3";
            inventoryUOMTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.4";
            lotLvlUOMConvertTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.5";
            materialTypeTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.6";
            productTypeTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.7";
            storageClassTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.8";

            HtmlComboBox aliquotStockComboBox = new HtmlComboBox(aliquotStockTable);
            HtmlComboBox assayNameComboBox = new HtmlComboBox(assayTable);
            HtmlComboBox assayProductionEntryComboBox = new HtmlComboBox(assayTable);
            HtmlComboBox assayQCEntryComboBox = new HtmlComboBox(assayTable);
            HtmlComboBox defaultQuantityComboBox = new HtmlComboBox(defaultQuantityTable);
            HtmlComboBox inventoryTrackingComboBox = new HtmlComboBox(inventoryTrackingTable);
            HtmlComboBox inventoryUOMComboBox = new HtmlComboBox(inventoryUOMTable);
            HtmlComboBox lotLvlUOMConvertComboBox = new HtmlComboBox(lotLvlUOMConvertTable);
            HtmlComboBox materialTypeComboBox = new HtmlComboBox(materialTypeTable);
            HtmlEdit productTypeTextBox = new HtmlEdit(productTypeTable);
            HtmlComboBox storageClassComboBox = new HtmlComboBox(storageClassTable);


            aliquotStockComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
            assayNameComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
            assayProductionEntryComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "7";
            assayQCEntryComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "13";
            defaultQuantityComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
            inventoryTrackingComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
            inventoryUOMComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
            lotLvlUOMConvertComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
            materialTypeComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
            productTypeTextBox.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "1";
            storageClassComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";

            #endregion

            #region steps

            if (materialAttributeParams.AliquoteStock != null && aliquotStockComboBox.TryFind())
            {
                aliquotStockComboBox.WaitForControlEnabled();
                aliquotStockComboBox.WaitForControlReady();
                Playback.Wait(3000);
                aliquotStockComboBox.SelectedItem = materialAttributeParams.AliquoteStock;
            }

            if (materialAttributeParams.AssayName != null && assayNameComboBox.TryFind())
            {
                assayNameComboBox.SelectedItem = materialAttributeParams.AssayName;
            }

            if (materialAttributeParams.AssayProductionEntry != null && assayProductionEntryComboBox.TryFind())
            {
                assayProductionEntryComboBox.SelectedItem = materialAttributeParams.AssayProductionEntry;
            }

            if (materialAttributeParams.AssayQCEntry != null && assayQCEntryComboBox.TryFind())
            {
                assayQCEntryComboBox.SelectedItem = materialAttributeParams.AssayQCEntry;
            }

            if (materialAttributeParams.DefaultQuantityStatus != null && defaultQuantityComboBox.TryFind())
            {
                defaultQuantityComboBox.SelectedItem = materialAttributeParams.DefaultQuantityStatus;
            }

            if (materialAttributeParams.InventoryTracking != null && inventoryTrackingComboBox.TryFind())
            {
                inventoryTrackingComboBox.SelectedItem = materialAttributeParams.InventoryTracking;
            }

            if (materialAttributeParams.InventoryUOM != null && inventoryUOMComboBox.TryFind())
            {
                inventoryUOMComboBox.SelectedItem = materialAttributeParams.InventoryUOM;
            }

            if (materialAttributeParams.LotLvlUOMConvert != null && lotLvlUOMConvertComboBox.TryFind())
            {
                lotLvlUOMConvertComboBox.SelectedItem = materialAttributeParams.LotLvlUOMConvert;
            }

            if (materialAttributeParams.MaterialType != null && materialTypeComboBox.TryFind())
            {
                materialTypeComboBox.SelectedItem = materialAttributeParams.MaterialType;
            }

            if (materialAttributeParams.ProductType != null && productTypeTextBox.TryFind())
            {
                productTypeTextBox.Text = materialAttributeParams.ProductType;
            }

            if (materialAttributeParams.StorageClass != null && storageClassComboBox.TryFind())
            {
                storageClassComboBox.SelectedItem = materialAttributeParams.StorageClass;
            }

            
        #endregion

        }

        /// <summary>
        /// This method is used to set the header attributes of BOM
        /// </summary>
        /// <param name="setBOMHeaderAttributesParams"></param>
        public void SetBOMHeaderAttributes(SetBOMHeaderAttributesParams setBOMHeaderAttributesParams)
        {

            BrowserWindow bOMHeaderAttributeWindow = new BrowserWindow();
            bOMHeaderAttributeWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            if (bOMHeaderAttributeWindow.TryFind())
            {

                //Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument bomHeaderAttributeDocument = new Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument(bOMHeaderAttributeWindow);
                //bomHeaderAttributeDocument.FilterProperties[Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument.PropertyNames.AbsolutePath] = "/Hoops/Apps/especwebapplication/eSpecAttrElemGrid.aspx";
                //bomHeaderAttributeDocument.TryFind();

                HtmlTable baseQuantityTable = new HtmlTable(bOMHeaderAttributeWindow);
                HtmlTable dispenseToStockTable = new HtmlTable(bOMHeaderAttributeWindow);

                baseQuantityTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.0";
                baseQuantityTable.FilterProperties[HtmlTable.PropertyNames.TagInstance] = "12";

                dispenseToStockTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.1";
                dispenseToStockTable.FilterProperties[HtmlTable.PropertyNames.TagInstance] = "13";

                HtmlEdit baseQuantity = new HtmlEdit(baseQuantityTable);
                HtmlComboBox baseQuantityUOM = new HtmlComboBox(baseQuantityTable);
                HtmlComboBox dispenseToStock = new HtmlComboBox(dispenseToStockTable);

                baseQuantity.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "2";
                baseQuantity.TryFind();
                baseQuantity.Text = setBOMHeaderAttributesParams.BaseQuantity;

                baseQuantityUOM.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "5";
                baseQuantityUOM.SelectedItem = setBOMHeaderAttributesParams.BaseQuantityUOM;

                dispenseToStock.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
                dispenseToStock.SelectedItem = setBOMHeaderAttributesParams.DispenseToStock;
            }
        }
        
        /// <summary>
        /// Click Save button in all BOX Item and all specification window except process model
        /// </summary>
        public void SaveSpecAndBOXWindow()
        {
            BrowserWindow MaterialAttributeWindow = new BrowserWindow();
            MaterialAttributeWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";

            HtmlImage saveButton = new HtmlImage(MaterialAttributeWindow);
            var saveButtonIds = new string[] { "SaveButton", "imgSave" };

            foreach (var saveButtonId in saveButtonIds)
            {
                saveButton.SearchProperties[HtmlImage.PropertyNames.Id] = saveButtonId;
                if (saveButton.TryFind())
                {
                    Mouse.Click(saveButton);
                }
            }

            MaterialAttributeWindow.Close();
        }

        /// <summary>
        /// Click Close button in all BOX Item and all specification window except process model
        /// </summary>
        public void CloseSpecAndBOXWindow()
        {
            BrowserWindow SpecAndBOXWindow = new BrowserWindow();
            SpecAndBOXWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";

            HtmlImage closeButton = new HtmlImage(SpecAndBOXWindow);

            closeButton.SearchProperties[HtmlImage.PropertyNames.Id] = "imgClose";

            if (closeButton.TryFind())
            {
                Mouse.Click(closeButton);
            }
            else {
                //SpecAndBOXWindow.Close();
            
            }
        }

    }

    /// <summary>
    /// Params for BOM Line Items
    /// </summary>
    public class SetBOMLineItemsParams
    {
        public string AdditionGroup { get; set; }
        public string AllowBatchStaging { get; set; }
        public string AllowWhseDispense { get; set; }
        public string Checkin { get; set; }
        public string CheckWeighRule { get; set; }
        public string CheckWeighTolerance { get; set; }
        public string DispenseComment { get; set; }
        public string DispenseMethod { get; set; }
        public string DispenseUOM { get; set; }
        public string DispenseAreaID { get; set; }
        public string DispenseAreaType { get; set; }
        public string DispenseToleranceLower { get; set; }
        public string DispenseToleranceRule { get; set; }
        public string DispenseToleranceUpper { get; set; }
        public string EquipmentClass { get; set; }
        public string EXT_BOM_REF_NO { get; set; }
        public string MaterialQty { get; set; }
        public string MaterialQtyUOM { get; set; }
        public string Optimizable { get; set; }
        public string PercentageYield { get; set; }
        public string ScaleClass { get; set; }
        public string ScalingRule { get; set; }
        public string Transfer { get; set; }
        public int RefLineNumber { get; set; }
         

    }

    /// <summary>
    /// Params for BOP Line Items
    /// </summary>
    public class SetBOPLineItemsParams
    {
        public int RefLineNumber { get; set; }
        public string ProductQuantity { get; set; }
        public string ProductUOM { get; set; }
        public string OutputToleranceLower { get; set; }
        public string OutputToleranceRule { get; set; }
        public string OutputToleranceUpper { get; set; }
    }

    /// <summary>
    /// Params for New Item Properties Window
    /// </summary>
    public class CreateNewLineItemParams
    {
        public string ObjectName { get; set; }
        public string ItemRefNo { get; set; }
        public string SubstitutionNo { get; set; }
        public string ItemLevel { get; set; }
        public string ItemLocation { get; set; }
        public string ItemId { get; set; }
        public string ItemVersion { get; set; }
        public bool   ApprovedCheckBox { get; set; }
        public bool   LatestCheckBox { get; set; }
        public string Comments { get; set; }
        public string ActiveFlag { get; set; }
        public string AggregateFlag { get; set; }
    }

    /// <summary>
    /// Params for Material Attributes
    /// </summary>
    public class SetMaterialAttributesParams
    {
        public string AliquoteStock { get; set; }
        public string DefaultQuantityStatus { get; set; }
        public string InventoryTracking { get; set; }
        public string InventoryUOM { get; set; }
        public string LotLvlUOMConvert { get; set; }
        public string MaterialType { get; set; }
        public string ProductType { get; set; }
        public string StorageClass { get; set; }
        public string AssayName { get; set; }
        public string AssayProductionEntry { get; set; }
        public string AssayQCEntry { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SetBOMHeaderAttributesParams
    {
        public string BaseQuantity { get; set; }
        public string BaseQuantityUOM { get; set; }
        public string DispenseToStock { get; set; }
    }

    /// <summary>
    /// Line iTem type
    /// </summary>
    public class LineItemType
    {
        public static string BOM = "Create BOM Line Item";
        public static string BOP = "Create BOP Line Item";
        public static string BOE = "Create BOE Line Item";
    }


}
