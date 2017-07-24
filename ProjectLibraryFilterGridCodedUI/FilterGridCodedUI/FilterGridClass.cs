using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
using MouseButtons = System.Windows.Forms.MouseButtons;


namespace FilterGridCodedUI
{
    public class GridHelper
    {
        /// <summary>
        /// Select a checkbox on POMSnet grid
        /// </summary>
        /// <param name="InnerTextAttribute">The value from the grid on which the filter will be applied e.g. Order ID, COntainer ID, Material ID etc</param>
        /// <param name="CheckBoxExpressionID">The HTML ID of the checkbox from the grid excluding the number in the end only e.g. dgContainer_chkContainer_</param>
        public void SelectCheckBoxGrid(string InnerTextAttribute, string CheckBoxExpressionID)
        {
            BrowserWindow _bw = new BrowserWindow();
            HtmlCell _Cell = new HtmlCell(_bw);
            HtmlCheckBox _chk = new HtmlCheckBox(_bw);
            
            _Cell.SearchProperties[HtmlCell.PropertyNames.InnerText] = InnerTextAttribute;

            _chk.SearchProperties[HtmlCheckBox.PropertyNames.Id] = string.Concat(CheckBoxExpressionID, 0);
            if (_chk.TryFind() && (_chk.Checked == true))
            {
                _chk.Checked = false;
            }

            if (_Cell.TryFind())
            {
                int _chk_select = _Cell.RowIndex - 1;
                _chk.SearchProperties[HtmlCheckBox.PropertyNames.Id] = string.Concat(CheckBoxExpressionID, _chk_select);
                _chk.Checked = true;
            }
        }
        /// <summary>
        /// CLicks on the select link on the Select batch grid on Weigh by batch Dispense
        /// Use this method on any grid to click a hyperlink on grid and the link text is not 'Select'
        /// </summary>
        /// <param name="BatchID"></param>
        public void ClickLinkOnGrid(string FilterCriteria1, string FilterCriteria2, string gridID)
        {
            BrowserWindow _browser = new BrowserWindow();
            HtmlCell _CellFilter1 = new HtmlCell(_browser);
            HtmlCell _CellFilter2 = new HtmlCell(_browser);
            HtmlHyperlink _Link = new HtmlHyperlink(_browser);
            int _click_select;

            // gridID is the link series ID found on the html source of the page
            // The HTML source has the link id as a href
            string ExpressionID1 = gridID;
            string ExpressionID2 = "$_ctl0";
            string hrefp1 = "javascript:__doPostBack('";
            string hrefp2 = "','')";


            // if both filter criteria is present e.g. filter by both material ID and BOM ref ID
            if(FilterCriteria1!=null && FilterCriteria2!=null)
            {
               _CellFilter1.SearchProperties[HtmlCell.PropertyNames.InnerText] = FilterCriteria1;
            
                if (_CellFilter1.TryFind())
                {
                    _CellFilter2.SearchProperties[HtmlCell.PropertyNames.InnerText] = FilterCriteria2;

                    if (_CellFilter1.TryFind() && _CellFilter2.TryFind())
                    {
                        _click_select = _CellFilter1.RowIndex+1;
                        _Link.SearchProperties[HtmlHyperlink.PropertyNames.Href] = string.Concat(hrefp1, ExpressionID1, _click_select, ExpressionID2, hrefp2);
                        Mouse.Click(_Link);
                    }
                }
            }
            else // filtering only on the first criteria
            {
                _CellFilter1.SearchProperties[HtmlCell.PropertyNames.InnerText] = FilterCriteria1;

                if (_CellFilter1.TryFind())
                {
                    _click_select = _CellFilter1.RowIndex+1;
                    _Link.SearchProperties[HtmlHyperlink.PropertyNames.Href] = string.Concat(hrefp1, ExpressionID1, _click_select, ExpressionID2, hrefp2);
                    Mouse.Click(_Link);
                }
            }
        }

        /// <summary>
        /// Use this method exclusively to select the batch ID from the grid
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="BatchID"></param>
        public void SelectBatchToDispenseGrid(string OrderID, string BatchID)
        {
            BrowserWindow _browser = new BrowserWindow();
            HtmlCell _OrderCell = new HtmlCell(_browser);
            HtmlCell _BatchCell = new HtmlCell(_browser);
            HtmlHyperlink _Link = new HtmlHyperlink(_browser);
            //int _click_select = 0; 
            int _click_select = 2; 

            string ExpressionID1 = "dgrdSelectBatch$_ctl";
            string ExpressionID2 = "$_ctl0";

            string hrefp1 = "javascript:__doPostBack('";
            string hrefp2 = "','')";

            _OrderCell.SearchProperties[HtmlCell.PropertyNames.InnerText] = OrderID;

            // find the cell matching the order id in grid
            //if (_OrderCell.TryFind())
            //{
            //   // if order id found in grid then find the batch id
            //    _BatchCell.SearchProperties[HtmlCell.PropertyNames.InnerText] = BatchID;

            //    // ensure that both order and batch IDs exist on the batch no matter in same row; 
            //    // this condition just finds that the order and batch ids both exist on the page
            //    if (_OrderCell.TryFind() && _BatchCell.TryFind())
            //    {
            //        // checking if the order and batch both exists on the same row on the grid then click the link
            //        if (_OrderCell.RowIndex == _BatchCell.RowIndex)
            //        {
            //            _click_select = _BatchCell.RowIndex + 1;
            //            _Link.SearchProperties[HtmlHyperlink.PropertyNames.Href] = string.Concat(hrefp1, ExpressionID1, _click_select, ExpressionID2, hrefp2);
            //            Mouse.Click(_Link);
            //        }
            //    }
            //}
            _BatchCell.SearchProperties[HtmlCell.PropertyNames.InnerText] = BatchID;

            // ensure that both order and batch IDs exist on the batch no matter in same row; 
            // this condition just finds that the order and batch ids both exist on the page
            if (_OrderCell.TryFind() && _BatchCell.TryFind())
            {
                // checking if the order and batch both exists on the same row on the grid then click the link
                //if (_OrderCell.RowIndex == _BatchCell.RowIndex)
                //{
                    _click_select = _BatchCell.RowIndex + 1;
                    _Link.SearchProperties[HtmlHyperlink.PropertyNames.Href] = string.Concat(hrefp1, ExpressionID1, _click_select, ExpressionID2, hrefp2);
                    Mouse.Click(_Link);
                //}
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InnerTextAttribute"></param>
        public void SelectValueOnGrid(string InnerTextAttribute)
        {
            BrowserWindow _bw = new BrowserWindow();
            HtmlCell _Cell = new HtmlCell(_bw);
            HtmlCheckBox _chk = new HtmlCheckBox(_bw);

            _Cell.SearchProperties[HtmlCell.PropertyNames.InnerText] = InnerTextAttribute;
            if (_Cell.TryFind())
            {
                Mouse.Click(_Cell);
            }
        }

        public void SelectValueOnGrid(string innerTextAttribute, string windowClass)
        {
            BrowserWindow browserWindow = new BrowserWindow();
            browserWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = windowClass;
            browserWindow.WindowTitles.Add("");
            browserWindow.TryFind();

            HtmlCell _Cell = new HtmlCell(browserWindow);
            //HtmlCheckBox _chk = new HtmlCheckBox(browserWindow);

            _Cell.SearchProperties[HtmlCell.PropertyNames.InnerText] = innerTextAttribute;
            if (_Cell.TryFind())
            {
                Mouse.Click(_Cell);
            }
        }

        /// <summary>
        /// Select multiple equipment classes
        /// </summary>
        /// <param name="EquipmentClass"></param>
        public void AssignEquipmentClass(string EquipmentClass)
        {
            BrowserWindow _browser = new BrowserWindow();
            HtmlCell _Cell = new HtmlCell(_browser);
            HtmlInputButton _arrowClickButton = new HtmlInputButton(_browser);
            string ExpressionID1 = "dgList:_ctl";
            string ExpressionID2 = ":_ctl0";

           _Cell.SearchProperties[HtmlCell.PropertyNames.InnerText] = EquipmentClass;

            if (_Cell.TryFind())
            {
                int _click_select = _Cell.RowIndex + 1;
                _arrowClickButton.SearchProperties[HtmlButton.PropertyNames.Name] = string.Concat(ExpressionID1, _click_select, ExpressionID2);
                Mouse.Click(_arrowClickButton);
            }
        }

        /// <summary>
        /// Remove Multiple Equipment Class
        /// </summary>
        /// <param name="EquipmentClass"></param>
        public void RemoveEquipmentClass(string EquipmentClass)
        {
            BrowserWindow _browser = new BrowserWindow();
            HtmlCell _Cell = new HtmlCell(_browser);
            HtmlInputButton _arrowClickButton = new HtmlInputButton(_browser);
            string ExpressionID1 = "dgMember:_ctl";
            string ExpressionID2 = ":_ctl1";

            _Cell.SearchProperties[HtmlCell.PropertyNames.InnerText] = EquipmentClass;

            if (_Cell.TryFind())
            {
                int _click_select = _Cell.RowIndex + 1;
                _arrowClickButton.SearchProperties[HtmlButton.PropertyNames.Name] = string.Concat(ExpressionID1, _click_select, ExpressionID2);
                Mouse.Click(_arrowClickButton);
            }
        }

        /// <summary>
        /// Select multiple equipment classes
        /// </summary>
        /// <param name="EquipmentClass"></param>
        public void ClickEditUpdateEquipmentClass(string InnerText)
        {
            BrowserWindow _browser = new BrowserWindow();
            HtmlCell _Cell = new HtmlCell(_browser);
            HtmlInputButton _clickEditButton = new HtmlInputButton(_browser);
            string ExpressionID1 = "dgMember:_ctl";
            string ExpressionID2 = ":_ctl0";

            _Cell.SearchProperties[HtmlCell.PropertyNames.InnerText] = InnerText;

            if (_Cell.TryFind())
            {
                int _click_select = _Cell.RowIndex + 1;
                _clickEditButton.SearchProperties[HtmlButton.PropertyNames.Name] = string.Concat(ExpressionID1, _click_select, ExpressionID2);
                Mouse.Click(_clickEditButton);
            }
           
        }

        /// <summary>
        /// User sends the batch and split ID to be initiated in unit worklist page
        /// </summary>
        /// <param name="BatchID"></param>
        /// <param name="SplitID"></param>
        public void InitiateSplitUnitWorklist(string BatchID, string SplitID)
        {
            BrowserWindow _browser = new BrowserWindow();
            HtmlCell _CellFilter1 = new HtmlCell(_browser);
            HtmlCell _CellFilter2 = new HtmlCell(_browser);
            HtmlInputButton _initateButton = new HtmlInputButton(_browser);
            int _buttonIndex;
            int batchRowIndex;
            int splitRowIndex;

            // The id of the button to be clicked broken down at the index value which changes
            string ExpressionID1 = "dgWorkList:_ctl";
            string ExpressionID2 = ":_ctl0";


            // set the search property by name of the batch and split
            _CellFilter1.SearchProperties[HtmlCell.PropertyNames.InnerText] = BatchID;
            _CellFilter2.SearchProperties[HtmlCell.PropertyNames.InnerText] = SplitID;

            // Find both the batch and split Ids on the page
            // At this point the first ID matching the batch and the first ID matching teh split is found
            // Not necessarily the split found belongs to the same batch
            _CellFilter1.TryFind();
            _CellFilter2.TryFind();

            // get the row indexes of the batch and split
            batchRowIndex = _CellFilter1.RowIndex;
            splitRowIndex = _CellFilter2.RowIndex;

            // this loop increases the row index of either the batch or split until the same row index is reached
            while (batchRowIndex != splitRowIndex)
            {
                // Once inside the loop need to find the split or batch again
                _CellFilter1.TryFind();
                _CellFilter2.TryFind();

                // if split is first found then hold the batch index 
                // and increase the split row index until the split row matches the batch row
                if (batchRowIndex > splitRowIndex)
                {
                    splitRowIndex++;
                }
                else
                {
                    batchRowIndex++;
                }
            }

            // now the batch and split found are on the same row
            if (batchRowIndex == splitRowIndex)
            {
                // the button row index is higher than the data values because of the header row
                // add +1 to either of the split or batch row index

                _buttonIndex = splitRowIndex + 1;
                _initateButton.SearchProperties[HtmlInputButton.PropertyNames.Name] = string.Concat(ExpressionID1, _buttonIndex, ExpressionID2);
                Mouse.Click(_initateButton);
            }
        }

        /// <summary>
        /// Filters the UnitWorklist Grid and clicks on the initiate button; Order/batch & Split IDs are mandatory
        /// </summary>
        /// <param name="filterUnitWorkListParams"></param>
        public void InitiateSplitUnitWorklist(FilterUnitWorkListParams filterUnitWorkListParams)
        {
            BrowserWindow _browser = new BrowserWindow();
            HtmlCell _BatchFilter = new HtmlCell(_browser);
            HtmlCell _SplitFilter = new HtmlCell(_browser);
            HtmlCell _OrderFilter = new HtmlCell(_browser);
            HtmlCell _UPFilter = new HtmlCell(_browser);
            HtmlInputButton _initateButton = new HtmlInputButton(_browser);
            
            int _buttonIndex;
            int batchRowIndex;
            int splitRowIndex;
            int orderRowIndex;
            int upRowIndex;

            // The id of the button to be clicked broken down at the index value which changes
            string ExpressionID1 = "dgWorkList:_ctl";
            string ExpressionID2 = ":_ctl0";


            // set the search property by name of the batch and split
            _BatchFilter.SearchProperties[HtmlCell.PropertyNames.InnerText] = filterUnitWorkListParams.BatchID;
            _SplitFilter.SearchProperties[HtmlCell.PropertyNames.InnerText] = filterUnitWorkListParams.SplitID;
            _OrderFilter.SearchProperties[HtmlCell.PropertyNames.InnerText] = filterUnitWorkListParams.OrderID;
            if ((filterUnitWorkListParams.UnitProcID != null) && (filterUnitWorkListParams.UnitProcIndex != null))
            {
                _UPFilter.SearchProperties[HtmlCell.PropertyNames.InnerText] = string.Concat(filterUnitWorkListParams.UnitProcID,
                    filterUnitWorkListParams.UnitProcIndex);
            }

            // Find both the batch and split Ids on the page
            // At this point the first ID matching the batch and the first ID matching teh split is found
            // Not necessarily the split found belongs to the same batch
            // get the row indexes of the batch and split

            _OrderFilter.TryFind();
            orderRowIndex = _OrderFilter.RowIndex;

            _BatchFilter.TryFind();
            batchRowIndex = _BatchFilter.RowIndex;

            _SplitFilter.TryFind();
            splitRowIndex = _SplitFilter.RowIndex;

            if ((filterUnitWorkListParams.UnitProcID != null) && (filterUnitWorkListParams.UnitProcIndex != null))
            {
                _UPFilter.TryFind();
                upRowIndex = _UPFilter.RowIndex;
            }


            // this loop increases the row index of either the batch or split until the same row index is reached
            while (batchRowIndex != splitRowIndex)
            {
                // Once inside the loop need to find the split or batch again
                _BatchFilter.TryFind();
                _SplitFilter.TryFind();

                // if split is first found then hold the batch index 
                // and increase the split row index until the split row matches the batch row
                if (batchRowIndex > splitRowIndex)
                {
                    splitRowIndex++;
                }
                else
                {
                    batchRowIndex++;
                }
            }

            // Increase the order or batch row indexes until they match with the Split index
            while (batchRowIndex != orderRowIndex)
            {
                // Once inside the loop need to find the order or batch again
                _BatchFilter.TryFind();
                _OrderFilter.TryFind();

                if (batchRowIndex > orderRowIndex)
                {
                    orderRowIndex++;
                }
                else
                {
                    batchRowIndex++;
                }
            }

            upRowIndex = batchRowIndex;
            if ((filterUnitWorkListParams.UnitProcID != null) && (filterUnitWorkListParams.UnitProcIndex != null))
            {
                while (splitRowIndex != upRowIndex)
                {
                    // Once inside the loop need to find the order or batch again
                    _BatchFilter.TryFind();
                    _OrderFilter.TryFind();
                    _SplitFilter.TryFind();
                    _UPFilter.TryFind();

                    if (upRowIndex > splitRowIndex)
                    {
                        splitRowIndex++;
                        orderRowIndex++;
                        batchRowIndex++;
                    }
                    else
                    {
                        upRowIndex++;
                    }
                }
            }

            // now the batch and split found are on the same row
            //if ((orderRowIndex == batchRowIndex) && (batchRowIndex == upRowIndex) && (upRowIndex == splitRowIndex))
            if ((orderRowIndex == batchRowIndex) && (batchRowIndex == splitRowIndex))
            {
                // the button row index is higher than the data values because of the header row
                // add +1 to either of the split or batch row index

                _buttonIndex = splitRowIndex + 1;
                _initateButton.SearchProperties[HtmlInputButton.PropertyNames.Name] = string.Concat(ExpressionID1, _buttonIndex, ExpressionID2);
                _initateButton.TryFind();
                Mouse.Click(_initateButton);
            }
        }

        public struct GridExpressionId
        {
            public static string RE_ManagePurchaseOrderGrid = "dgPurchaseOrderLineList_chkSelect_";
            public static string OM_OrderGrid = "OrderList1_grid_chkSelect_";
            public static string OM_BatchGrid = "BatchList1_grid_chkBatchSelect_";
            public static string OM_SplitGrid = "UnitProcList1_grid_chkSplitSelect_";
            public static string DP_SelectBatch = "dgrdSelectBatch$_ctl";
            public static string DP_SelectMatl = "dgrdSelectMaterialBatch$_ctl";
            public static string MM_AllocMatBatch = "dgBatch$_ctl";
            public static string MM_AllocMatUP = "dgUnitProcedure$_ctl";
            public static string MM_AllocMatSplit = "dgSplit$_ctl";
            public static string MM_AllocMatEditAlloc = "dgMaterial$_ctl";
            public static string UW_SplitsGrid = "dgWorkList:_ctl2:_ctl";
            

            //public static string MM_MoveMaterialGrid = "mygrid_chkSelect_";
            //public static string MM_ExecuteMoveRequestGrid = "mygrid_chkSelect_";
            //public static string MM_ManageMoveRequestGrid = "mygrid_chkSelect_";
            //public static string MM_CreateMoveRequestGrid = "mygrid_chkSelect_";
            //public static string MM_EditMoveRequestGrid = "mygrid_chkSelect_";

            public static string MM_MoveMaterialGrid = "mygrid_chkSelect_";


            public static string MM_BachRescaleGrid = "dgContainer_chkContainerSelect_";
            public static string MM_MoveOutputMaterialGrid = "dgOutputContainers_chkContainer_";

            //public static string MM_CreatePalletGrid = "Leftgrid_chkSelect_";
            //public static string MM_ManagePalletGrid = "Leftgrid_chkSelect_";

            public static string MM_PalletGrid = "Leftgrid_chkSelect_";

            public static string QM_QCStatusGrid = "ContainerTrackedMaterials1_mygrid_chkSelect_";



        }
    }

    /// <summary>
    /// The list of parameters required for filtering the record and clicking the initialize button for a split
    /// </summary>
    public class FilterUnitWorkListParams
    {
        /// <summary>
        /// Order ID. This is mandatory
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// Batch ID. This is mandatory
        /// </summary>
        public string BatchID { get; set; }

        /// <summary>
        /// Unit procedure ID. This is optional
        /// </summary>
        public string UnitProcID { get; set; }

        /// <summary>
        /// Split ID of a batch. This is mandatory
        /// </summary>
        public string SplitID { get; set; }

        /// <summary>
        /// This is the index which appears concatenated with the UP ID.
        /// The instance ID of the Unit procedure, number like 1,2,3 and so on. Optional.
        /// </summary>
        public string UnitProcIndex { get; set; }
    }
}
