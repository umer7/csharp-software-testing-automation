namespace ProjectLibraryEquipmentModel.ProjectLibraryEquipmentModelClasses
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
    
    
    public partial class EquipmentModel
    {
        /// <summary>
        ///This method is use to set values in in BOE line items
        ///</summary>
        public void SetBOELineItemsAttributes(SetBOELineItemsAttributesParams BOELineItemParam)
        {
            #region Search Criteria
            BrowserWindow BOELineItems = new BrowserWindow();
            BOELineItems.SearchProperties[UITestControl.PropertyNames.Name] = "Line Item(s)";
            BOELineItems.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            BOELineItems.WindowTitles.Add("Line Item(s)");

            HtmlComboBox preCheckIn = new HtmlComboBox(BOELineItems);
            HtmlComboBox scallingRule = new HtmlComboBox(BOELineItems);
            HtmlTextArea quantityRequired = new HtmlTextArea(BOELineItems);

            HtmlImage expandCollapse = new HtmlImage(BOELineItems);
            HtmlImage addLineImage = new HtmlImage(BOELineItems);
            HtmlImage saveImage = new HtmlImage(BOELineItems);
            HtmlImage closeWindow = new HtmlImage(BOELineItems);
            HtmlTextArea count = new HtmlTextArea(BOELineItems);


            int FirstLineItem;

            string ExpandCollapseTagInstance = (BOELineItemParam.RefLineNumber + 3).ToString();

            if (BOELineItemParam.RefLineNumber == 1)
            {
                FirstLineItem = 2;
            }
            else
            {
                FirstLineItem = (3 * BOELineItemParam.RefLineNumber) - 2 + 1;
            }
            #endregion

            #region set values
            if (BOELineItemParam.PreCheckIn != null && preCheckIn.TryFind())
            {

                preCheckIn.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = FirstLineItem.ToString();
                preCheckIn.SelectedItem = BOELineItemParam.PreCheckIn;
            }

            if (BOELineItemParam.QuantityRequired != null && quantityRequired.TryFind())
            {

                quantityRequired.FilterProperties[HtmlTextArea.PropertyNames.TagInstance] = BOELineItemParam.RefLineNumber.ToString();
                quantityRequired.Text = BOELineItemParam.QuantityRequired;

            }


            if (BOELineItemParam.ScalingRule != null && scallingRule.TryFind())
            {

                scallingRule.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = (FirstLineItem + 1).ToString();
                scallingRule.SelectedItem = BOELineItemParam.ScalingRule;
            }




                

            #endregion

        }

        /// <summary>
        ///This method is use to set Equipment attributes 
        ///</summary>
        public void SetEquipmentAttributes(SetEquipmentAttributesParams EqAttributesParam)
        {
            #region Search Criteria
            BrowserWindow equipmentAttWindow = new BrowserWindow();
            equipmentAttWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";

            Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument equipmentAttributeDocument = new Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument(equipmentAttWindow);
            equipmentAttributeDocument.FilterProperties[Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument.PropertyNames.AbsolutePath] = "/Hoops/Apps/especwebapplication/eSpecAttrElemGrid.aspx";


            HtmlTable capacityTable = new HtmlTable(equipmentAttributeDocument);
            HtmlTable moveableTable = new HtmlTable(equipmentAttributeDocument);
            HtmlTable typeTable = new HtmlTable(equipmentAttributeDocument);
            HtmlImage saveImage = new HtmlImage(equipmentAttributeDocument);

            capacityTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.0";
            moveableTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.1";
            typeTable.SearchProperties[HtmlTable.PropertyNames.Id] = "elems.2";

            HtmlEdit capacityMax = new HtmlEdit(capacityTable);
            HtmlEdit capacityMin = new HtmlEdit(capacityTable);
            HtmlComboBox capacityUOM = new HtmlComboBox(capacityTable);
            HtmlComboBox moveable = new HtmlComboBox(moveableTable);
            HtmlComboBox type = new HtmlComboBox(typeTable);
            #endregion

            #region Set Values
            capacityMax.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "2";

            if (EqAttributesParam.CapacityMax !=null && capacityMax.TryFind())
            {
                capacityMax.Text = EqAttributesParam.CapacityMax;
            }

            capacityMin.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "13";

            if (EqAttributesParam.CapacityMin !=null && capacityMin.TryFind())
            {
                capacityMin.Text = EqAttributesParam.CapacityMin;
            }

            capacityUOM.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "9";

            if (EqAttributesParam.CapacityUOM !=null && capacityUOM.TryFind())
            {
                capacityUOM.SelectedItem = EqAttributesParam.CapacityUOM;
            }

            moveable.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";

            if (EqAttributesParam.Moveable !=null && moveable.TryFind())
            {
                moveable.SelectedItem = EqAttributesParam.Moveable;
            }

            type.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "14";

            if(EqAttributesParam.Type !=null && type.TryFind())
            {
                type.SelectedItem = EqAttributesParam.Type;
            }

            #endregion

        }

        /// <summary>
        /// Use to set status type attributes of status type Cleanliness and Availability 
        /// </summary>
        /// <param name="equipStatusAttributesParam"></param>
        public void SetCleanlinessAndAvailabilityEquipStatusTypeAttributes(SetEquipmentStatusAttributesParams equipStatusAttributesParam)
        {
            #region Search Criteria
            BrowserWindow equipBrowserWindow = new BrowserWindow();
            equipBrowserWindow.SearchProperties[UITestControl.PropertyNames.Name] = "Status Values";
            equipBrowserWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            equipBrowserWindow.WindowTitles.Add("Status Values");
           
            HtmlComboBox comboBox = new HtmlComboBox(equipBrowserWindow);
            HtmlEdit editTextBox = new HtmlEdit(equipBrowserWindow);
            #endregion

            #region Set Values

            #region Availability
           
            if (equipStatusAttributesParam.AvailabilityAcquiredStatus != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityAcquiredStatus; 
                comboBox.SelectedItem = equipStatusAttributesParam.AvailabilityAcquiredStatus;
            }

            if (equipStatusAttributesParam.AvailabilityDefaultStatus != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityDefaultStatus;
                comboBox.SelectedItem = equipStatusAttributesParam.AvailabilityDefaultStatus;
            }

            if (equipStatusAttributesParam.AvailabilityReleasedStatus != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityReleasedStatus;
                comboBox.SelectedItem = equipStatusAttributesParam.AvailabilityReleasedStatus;
            }

            if (equipStatusAttributesParam.AvailabilityValidUnitStatuses != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityValidUnitStatuses;
                //Mouse.Click(editTextBox);
                editTextBox.Text = equipStatusAttributesParam.AvailabilityValidUnitStatuses;
            }
            #endregion

            #region Availability Available

            if (equipStatusAttributesParam.AvailabilityAvailableExpirationCycle != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityAvailableExpirationCycle;
                editTextBox.Text = equipStatusAttributesParam.AvailabilityAvailableExpirationCycle;
            }

            if (equipStatusAttributesParam.AvailabilityAvailableExpirationPeriod != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityAvailableExpirationPeriod;
                editTextBox.Text = equipStatusAttributesParam.AvailabilityAvailableExpirationPeriod;
            }

            if (equipStatusAttributesParam.AvailabilityAvailableExpirationPeriodUOM != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityAvailableExpirationPeriodUOM;
                comboBox.SelectedItem = equipStatusAttributesParam.AvailabilityAvailableExpirationPeriodUOM;
            }

            if (equipStatusAttributesParam.AvailabilityAvailableExpirationStatusValue != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityAvailableExpirationStatusValue;
                comboBox.SelectedItem = equipStatusAttributesParam.AvailabilityAvailableExpirationStatusValue;
            }

            if (equipStatusAttributesParam.AvailabilityAvailableExpirationUseHorizon != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityAvailableExpirationUseHorizon;
                editTextBox.Text = equipStatusAttributesParam.AvailabilityAvailableExpirationUseHorizon;
            }

            if (equipStatusAttributesParam.AvailabilityAvailableExpirationUseHorizonUOM != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityAvailableExpirationUseHorizonUOM;
                comboBox.SelectedItem = equipStatusAttributesParam.AvailabilityAvailableExpirationUseHorizonUOM;
            }
            #endregion

            #region Availability In Use

            if (equipStatusAttributesParam.AvailabilityInUseExpirationCycle != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityInUseExpirationCycle;
                editTextBox.Text = equipStatusAttributesParam.AvailabilityInUseExpirationCycle;
            }

            if (equipStatusAttributesParam.AvailabilityInUseExpirationPeriod != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityInUseExpirationPeriod;
                editTextBox.Text = equipStatusAttributesParam.AvailabilityInUseExpirationPeriod;
            }

            if (equipStatusAttributesParam.AvailabilityInUseExpirationStatusValue != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityInUseExpirationPeriodUOM;
                comboBox.SelectedItem = equipStatusAttributesParam.AvailabilityInUseExpirationPeriodUOM;
            }

            if (equipStatusAttributesParam.AvailabilityInUseExpirationStatusValue != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityInUseExpirationStatusValue;
                comboBox.SelectedItem = equipStatusAttributesParam.AvailabilityInUseExpirationStatusValue;
            }

            if (equipStatusAttributesParam.AvailabilityInUseExpirationUseHorizon != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityInUseExpirationUseHorizon;
                editTextBox.Text = equipStatusAttributesParam.AvailabilityInUseExpirationUseHorizon;
            }

            if (equipStatusAttributesParam.AvailabilityInUseExpirationUseHorizonUOM != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.AvailabilityInUseExpirationUseHorizonUOM;
                comboBox.SelectedItem = equipStatusAttributesParam.AvailabilityInUseExpirationUseHorizonUOM;
            }
            #endregion

            #region Cleanliness

            if (equipStatusAttributesParam.CleanlinessAcquiredStatus != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessAcquiredStatus;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessAcquiredStatus;
            }

            if (equipStatusAttributesParam.CleanlinessDefaultStatus != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessDefaultStatus;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessDefaultStatus;
            }

            if (equipStatusAttributesParam.CleanlinessReleasedStatus != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessDefaultStatus;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessReleasedStatus;
            }

            if (equipStatusAttributesParam.CleanlinessValidUnitStatuses != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessDefaultStatus;
                editTextBox.Text = equipStatusAttributesParam.CleanlinessValidUnitStatuses;
            }
            #endregion

            #region  Cleanliness CIP

            if (equipStatusAttributesParam.CleanlinessCIPExpirationCycle != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessCIPExpirationCycle;
                editTextBox.Text = equipStatusAttributesParam.CleanlinessCIPExpirationCycle;
            }

            if (equipStatusAttributesParam.CleanlinessCIPExpirationPeriod != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessCIPExpirationPeriod;
                editTextBox.Text = equipStatusAttributesParam.CleanlinessCIPExpirationPeriod;
            }

            if (equipStatusAttributesParam.CleanlinessCIPExpirationPeriodUOM != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessCIPExpirationPeriodUOM;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessCIPExpirationPeriodUOM;
            }

            if (equipStatusAttributesParam.CleanlinessCIPExpirationStatusValue != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessCIPExpirationPeriodUOM;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessCIPExpirationStatusValue;
            }

            if (equipStatusAttributesParam.CleanlinessCIPExpirationUseHorizon != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessCIPExpirationUseHorizon;
                editTextBox.Text = equipStatusAttributesParam.CleanlinessCIPExpirationUseHorizon;
            }

            if (equipStatusAttributesParam.CleanlinessCIPExpirationUseHorizonUOM != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessCIPExpirationUseHorizonUOM;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessCIPExpirationUseHorizonUOM;
            }
            #endregion

            #region Cleanliness Clean

            if (equipStatusAttributesParam.CleanlinessCleanActionName != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessCleanActionName;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessCleanActionName;
            }

            if (equipStatusAttributesParam.CleanlinessCleanExpirationCycle != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessCleanExpirationCycle;
                editTextBox.Text = equipStatusAttributesParam.CleanlinessCleanExpirationCycle;
            }

            if (equipStatusAttributesParam.CleanlinessCleanExpirationPeriod != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessCleanExpirationPeriod;
                editTextBox.Text = equipStatusAttributesParam.CleanlinessCleanExpirationPeriod;
            }

            if (equipStatusAttributesParam.CleanlinessCleanExpirationPeriodUOM != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessCleanExpirationPeriodUOM;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessCleanExpirationPeriodUOM;
            }

            if (equipStatusAttributesParam.CleanlinessCleanExpirationStatusValue != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessCleanExpirationStatusValue;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessCleanExpirationStatusValue;
            }

            if (equipStatusAttributesParam.CleanlinessCleanExpirationUseHorizon != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessCleanExpirationUseHorizon;
                editTextBox.Text = equipStatusAttributesParam.CleanlinessCleanExpirationUseHorizon;
            }

            if (equipStatusAttributesParam.CleanlinessCleanExpirationUseHorizonUOM != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessCleanExpirationUseHorizonUOM;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessCleanExpirationUseHorizonUOM;
            }
            #endregion

            #region Cleanliness Dirty
            if (equipStatusAttributesParam.CleanlinessDirtyExpirationCycle != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessDirtyExpirationCycle;
                editTextBox.Text = equipStatusAttributesParam.CleanlinessDirtyExpirationCycle;
            }

            if (equipStatusAttributesParam.CleanlinessDirtyExpirationPeriod != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessDirtyExpirationPeriod;
                editTextBox.Text = equipStatusAttributesParam.CleanlinessDirtyExpirationPeriod;
            }

            if (equipStatusAttributesParam.CleanlinessDirtyExpirationPeriodUOM != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessDirtyExpirationPeriodUOM;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessDirtyExpirationPeriodUOM;
            }

            if (equipStatusAttributesParam.CleanlinessDirtyExpirationStatusValue != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessDirtyExpirationStatusValue;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessDirtyExpirationStatusValue;
            }

            if (equipStatusAttributesParam.CleanlinessDirtyExpirationUseHorizon != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessDirtyExpirationUseHorizon;
                editTextBox.Text = equipStatusAttributesParam.CleanlinessDirtyExpirationUseHorizon;
            }

            if (equipStatusAttributesParam.CleanlinessDirtyExpirationUseHorizonUOM != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessDirtyExpirationUseHorizonUOM;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessDirtyExpirationUseHorizonUOM;
            }
            #endregion

            #region Cleanliness Flush

            if (equipStatusAttributesParam.CleanlinessFlushExpirationCycle != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessFlushExpirationCycle;
                editTextBox.Text = equipStatusAttributesParam.CleanlinessFlushExpirationCycle;
            }

            if (equipStatusAttributesParam.CleanlinessFlushExpirationPeriod != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessFlushExpirationPeriod;
                editTextBox.Text = equipStatusAttributesParam.CleanlinessFlushExpirationPeriod;
            }

            if (equipStatusAttributesParam.CleanlinessFlushExpirationPeriodUOM != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessFlushExpirationPeriodUOM;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessFlushExpirationPeriodUOM;
            }

            if (equipStatusAttributesParam.CleanlinessFlushExpirationStatusValue != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessFlushExpirationStatusValue;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessFlushExpirationStatusValue;
            }

            if (equipStatusAttributesParam.CleanlinessFlushExpirationUseHorizon != null)
            {
                editTextBox.SearchProperties[HtmlEdit.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessFlushExpirationUseHorizon;
                editTextBox.Text = equipStatusAttributesParam.CleanlinessFlushExpirationUseHorizon;
            }

            if (equipStatusAttributesParam.CleanlinessFlushExpirationUseHorizonUOM != null)
            {
                comboBox.SearchProperties[HtmlComboBox.PropertyNames.TagInstance] = StatusTypesTagInstance.CleanlinessFlushExpirationUseHorizonUOM;
                comboBox.SelectedItem = equipStatusAttributesParam.CleanlinessFlushExpirationUseHorizonUOM;
            }
            #endregion

            #endregion

        }
    }

    /// <summary>
    /// Params of BOE Line Items Attributes 
    /// </summary>
    public class SetBOELineItemsAttributesParams
    {
        public int RefLineNumber { get; set; }
        public string PreCheckIn { get; set; }
        public string QuantityRequired { get; set; }
        public string ScalingRule { get; set; }
    }

    /// <summary>
    /// Equipment Attributes Params
    /// </summary>
    public class SetEquipmentAttributesParams
    {
        public int RefLineNumber { get; set; }
        public string CapacityMax { get; set; }
        public string CapacityMin { get; set; }
        public string CapacityUOM { get; set; }
        public string Moveable { get; set; }
        public string Type { get; set; }

    }

    /// <summary>
    /// Equipment Status Attributes
    /// </summary>
    public class SetEquipmentStatusAttributesParams
    {
        public string AvailabilityAcquiredStatus { get; set; }
        public string AvailabilityDefaultStatus { get; set; }
        public string AvailabilityReleasedStatus { get; set; }
        public string AvailabilityValidUnitStatuses { get; set; }

        public string AvailabilityAvailableExpirationCycle { get; set; }
        public string AvailabilityAvailableExpirationPeriod { get; set; }
        public string AvailabilityAvailableExpirationPeriodUOM { get; set; }
        public string AvailabilityAvailableExpirationStatusValue { get; set; }
        public string AvailabilityAvailableExpirationUseHorizon { get; set; }
        public string AvailabilityAvailableExpirationUseHorizonUOM { get; set; }

        public string AvailabilityInUseExpirationCycle { get; set; }
        public string AvailabilityInUseExpirationPeriod { get; set; }
        public string AvailabilityInUseExpirationPeriodUOM { get; set; }
        public string AvailabilityInUseExpirationStatusValue { get; set; }
        public string AvailabilityInUseExpirationUseHorizon { get; set; }
        public string AvailabilityInUseExpirationUseHorizonUOM { get; set; }

        public string CleanlinessAcquiredStatus { get; set; }
        public string CleanlinessDefaultStatus { get; set; }
        public string CleanlinessReleasedStatus { get; set; }
        public string CleanlinessValidUnitStatuses { get; set; }

        public string CleanlinessCIPExpirationCycle { get; set; }
        public string CleanlinessCIPExpirationPeriod { get; set; }
        public string CleanlinessCIPExpirationPeriodUOM { get; set; }
        public string CleanlinessCIPExpirationStatusValue { get; set; }
        public string CleanlinessCIPExpirationUseHorizon { get; set; }
        public string CleanlinessCIPExpirationUseHorizonUOM { get; set; }

        public string CleanlinessCleanActionName { get; set; }
        public string CleanlinessCleanExpirationCycle { get; set; }
        public string CleanlinessCleanExpirationPeriod { get; set; }
        public string CleanlinessCleanExpirationPeriodUOM { get; set; }
        public string CleanlinessCleanExpirationStatusValue { get; set; }
        public string CleanlinessCleanExpirationUseHorizon { get; set; }
        public string CleanlinessCleanExpirationUseHorizonUOM { get; set; }

        public string CleanlinessDirtyExpirationCycle { get; set; }
        public string CleanlinessDirtyExpirationPeriod { get; set; }
        public string CleanlinessDirtyExpirationPeriodUOM { get; set; }
        public string CleanlinessDirtyExpirationStatusValue { get; set; }
        public string CleanlinessDirtyExpirationUseHorizon { get; set; }
        public string CleanlinessDirtyExpirationUseHorizonUOM { get; set; }

        public string CleanlinessFlushExpirationCycle { get; set; }
        public string CleanlinessFlushExpirationPeriod { get; set; }
        public string CleanlinessFlushExpirationPeriodUOM { get; set; }
        public string CleanlinessFlushExpirationStatusValue { get; set; }
        public string CleanlinessFlushExpirationUseHorizon { get; set; }
        public string CleanlinessFlushExpirationUseHorizonUOM { get; set; }








    }

    /// <summary>
    /// Cleanliness and Availability Status Types Attributes Tag instance
    /// </summary>
    public static class StatusTypesTagInstance
    {
        public static string AvailabilityAcquiredStatus = "5";
        public static string AvailabilityDefaultStatus = "16";
        public static string AvailabilityReleasedStatus = "27";
        public static string AvailabilityValidUnitStatuses = "82";
        public static string AvailabilityAvailableExpirationCycle = "99";
        public static string AvailabilityAvailableExpirationPeriod = "110";
        public static string AvailabilityAvailableExpirationPeriodUOM = "53";
        public static string AvailabilityAvailableExpirationStatusValue = "58";
        public static string AvailabilityAvailableExpirationUseHorizon = "139";
        public static string AvailabilityAvailableExpirationUseHorizonUOM = "66";
        public static string AvailabilityInUseExpirationCycle = "224";
        public static string AvailabilityInUseExpirationPeriod = "235";
        public static string AvailabilityInUseExpirationPeriodUOM = "82";
        public static string AvailabilityInUseExpirationStatusValue = "87";
        public static string AvailabilityInUseExpirationUseHorizon = "264";
        public static string AvailabilityInUseExpirationUseHorizonUOM = "95";
        public static string CleanlinessAcquiredStatus = "105";
        public static string CleanlinessDefaultStatus = "116";
        public static string CleanlinessReleasedStatus = "127";
        public static string CleanlinessValidUnitStatuses = "404";
        public static string CleanlinessCIPExpirationCycle = "421";
        public static string CleanlinessCIPExpirationPeriod = "432";
        public static string CleanlinessCIPExpirationPeriodUOM = "153";
        public static string CleanlinessCIPExpirationStatusValue = "158";
        public static string CleanlinessCIPExpirationUseHorizon = "461";
        public static string CleanlinessCIPExpirationUseHorizonUOM = "166";
        public static string CleanlinessCleanActionName = "176";
        public static string CleanlinessCleanExpirationCycle = "557";
        public static string CleanlinessCleanExpirationPeriod = "568";
        public static string CleanlinessCleanExpirationPeriodUOM = "193";
        public static string CleanlinessCleanExpirationStatusValue = "198";
        public static string CleanlinessCleanExpirationUseHorizon = "597";
        public static string CleanlinessCleanExpirationUseHorizonUOM = "206";
        public static string CleanlinessDirtyExpirationCycle = "682";
        public static string CleanlinessDirtyExpirationPeriod = "693";
        public static string CleanlinessDirtyExpirationPeriodUOM = "222";
        public static string CleanlinessDirtyExpirationStatusValue = "227";
        public static string CleanlinessDirtyExpirationUseHorizon = "722";
        public static string CleanlinessDirtyExpirationUseHorizonUOM = "235";
        public static string CleanlinessFlushExpirationCycle = "807";
        public static string CleanlinessFlushExpirationPeriod = "818";
        public static string CleanlinessFlushExpirationPeriodUOM = "251";
        public static string CleanlinessFlushExpirationStatusValue = "256";
        public static string CleanlinessFlushExpirationUseHorizon = "847";
        public static string CleanlinessFlushExpirationUseHorizonUOM = "264";
    
    }
}
