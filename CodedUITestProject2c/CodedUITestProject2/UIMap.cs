namespace CodedUITestProject2
{
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Drawing;
    using System.Windows.Input;
    using System.Text.RegularExpressions;


    public partial class UIMap
    {

        /// <summary>
        /// LoginCase - Use 'LoginCaseParams' to pass parameters into this method.
        /// </summary>
        public void LoginCase(string url, string user, string pass)
        {
            #region Variable Declarations
            BrowserWindow uIMSNcomHotmailOutlookWindow = this.UIMSNcomHotmailOutlookWindow;
            HtmlEdit uIUsernameEdit = this.UIMSNcomHotmailOutlookWindow.UIAdactIncomHotelReserDocument.UIUsernameEdit;
            HtmlEdit uIPasswordEdit = this.UIMSNcomHotmailOutlookWindow.UIAdactIncomHotelReserDocument.UIPasswordEdit;
            HtmlInputButton uILoginButton = this.UIMSNcomHotmailOutlookWindow.UIAdactIncomHotelReserDocument.UILoginButton;
            
            #endregion

            // Go to web page 'http://go.microsoft.com/fwlink/p/?LinkId=255141' using new browser instance
            this.UIMSNcomHotmailOutlookWindow.LaunchUrl(new System.Uri(this.LoginCaseParams.UIMSNcomHotmailOutlookWindowUrl));

            // Go to web page 'http://adactin.com/HotelApp/'
            uIMSNcomHotmailOutlookWindow.NavigateToUrl(new System.Uri(url));

            // Type 'TestAbuZohran' in 'username' text box
            uIUsernameEdit.Text = user;

            // Type '********' in 'password' text box
            uIPasswordEdit.Text = pass;

            // Click 'Login' button
            Mouse.Click(uILoginButton);
        }

        /// <summary>
        /// This method is used to automate login case with happy flow
        /// </summary>
        public void LoginCase(LoginCaseParam loginCaseParams)
        {
            #region Initializations
            BrowserWindow browserWindow = new BrowserWindow();
            HtmlEdit id = new HtmlEdit(browserWindow);
            HtmlEdit password = new HtmlEdit(browserWindow);
            HtmlInputButton submitButton = new HtmlInputButton(browserWindow);
            //HtmlCell idText = new HtmlCell(browserWindow);
            //HtmlCheckBox chkbox = new HtmlCheckBox(browserWindow);
            #endregion

            

            #region Searching/ Locate
            id.SearchProperties[HtmlEdit.PropertyNames.Id] = "username";
            password.SearchProperties[HtmlEdit.PropertyNames.Id] = "password";
            submitButton.SearchProperties[HtmlEdit.PropertyNames.Id] = "login";

            if (loginCaseParams.username !=null)
            {
                id.Text = loginCaseParams.username;
            }


            if (loginCaseParams.password != null)
            {
                password.Text = loginCaseParams.password;
            }
           
            Mouse.Click(submitButton);



            /*


            // idText.SearchProperties[HtmlCell.PropertyNames.InnerText] = "abc2";
            // int a = idText.RowIndex;
            string chckid = "check_" + a;
            //chkbox.SearchProperties[HtmlCheckBox.PropertyNames.Id] = chckid;
            #endregion

            #region Steps
            id.Text = "AmirTest";
            password.Text = "AmirTest";
            //chkbox.Checked = true;
            
    */

            

            #endregion



        }


        public class LoginCaseParam
        {
            /// <summary>
            /// 
            /// </summary>
            public string username { get; set; }
            
            /// <summary>
            /// 
            /// </summary>
            public string password { get; set; }


        }
        public virtual LoginCaseParams LoginCaseParams
        {
            get
            {
                if ((this.mLoginCaseParams == null))
                {
                    this.mLoginCaseParams = new LoginCaseParams();
                }
                return this.mLoginCaseParams;
            }
        }

        private LoginCaseParams mLoginCaseParams;
    }
    /// <summary>
    /// Parameters to be passed into 'LoginCase'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class LoginCaseParams
    {

        #region Fields
        /// <summary>
        /// Go to web page 'http://go.microsoft.com/fwlink/p/?LinkId=255141' using new browser instance
        /// </summary>
        public string UIMSNcomHotmailOutlookWindowUrl = "http://go.microsoft.com/fwlink/p/?LinkId=255141";

        /// <summary>
        /// Go to web page 'http://adactin.com/HotelApp/'
        /// </summary>
        public string UIMSNcomHotmailOutlookWindowUrl1 = "http://adactin.com/HotelApp/";

        /// <summary>
        /// Type 'TestAbuZohran' in 'username' text box
        /// </summary>
        public string UIUsernameEditText = "TestAbuZohran";

        /// <summary>
        /// Type '********' in 'password' text box
        /// </summary>
        public string UIPasswordEditPassword = "5KDXh6LpkcpWhZq54SbvDAVtAN3sSRpo";
        #endregion
    }
}
