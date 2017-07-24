namespace ProjectLibrarySignoff.SignoffClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
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


    public partial class Signoff
    {

        public void SingleInitial(SignoffParams singleInitialParams)
        {
            BrowserWindow _BWindow = new BrowserWindow();
            HtmlEdit _Initials = new HtmlEdit(_BWindow);
            HtmlInputButton _OkButton = new HtmlInputButton(_BWindow);

            _Initials.SearchProperties[HtmlEdit.PropertyNames.Id] = "SignoffControl1:lblFirstUser";
            _Initials.Text = singleInitialParams.SignoffUser1;

            _OkButton.SearchProperties[HtmlInputButton.PropertyNames.Id] = "SignoffControl1_Ok";
            Mouse.Click(_OkButton);

        }
           
        /// <summary>
        /// Used for single and double signoff, double signoff code execute only if user send param of double signoff  
        /// </summary>
        /// <param name="signoffParams">Comments, User1, Password1, User Verifier, Password Verifier</param>
        public void SingleDoubleSignOff(SignoffParams signoffParams)
        {
            #region Initializations
            BrowserWindow signOffWindow = new BrowserWindow();

            var signoffWindowClasses = new string[] { "Internet Explorer_TridentDlgFrame", "IEFrame" };

            HtmlTextArea comment = new HtmlTextArea(signOffWindow);
            HtmlEdit user1 = new HtmlEdit(signOffWindow);
            HtmlEdit password = new HtmlEdit(signOffWindow);
            HtmlInputButton okButton = new HtmlInputButton(signOffWindow);
            HtmlEdit user2 = new HtmlEdit(signOffWindow);
            HtmlEdit passwordVer = new HtmlEdit(signOffWindow);
            HtmlInputButton okButtonVer = new HtmlInputButton(signOffWindow);

            var signOffParamsList = new[]{
                    new SignOffControls{CommentId="SignoffUserControl1_lblComment",UserId="SignoffUserControl1_lblFirstUser",PasswordId="SignoffUserControl1_lblUserPwd",OkButtonId="SignoffUserControl1_Ok", VerifierId="SignoffUserControl1_lblVerifierID", VerifierPassword="SignoffUserControl1_lblVerPwd", VerOkButtonId="SignoffUserControl1_verOk"},
                    new SignOffControls{CommentId="SignoffUserControl1:lblComment",UserId="SignoffUserControl1:lblFirstUser",PasswordId="SignoffUserControl1:lblUserPwd",OkButtonId="SignoffUserControl1:Ok", VerifierId="SignoffUserControl1:lblVerifierID", VerifierPassword="SignoffUserControl1:lblVerPwd", VerOkButtonId="SignoffUserControl1:verOk"},
                    new SignOffControls{CommentId="SignoffControl1_lblComment",UserId="SignoffControl1_lblFirstUser",PasswordId="SignoffControl1_lblUserPwd", OkButtonId="SignoffControl1_Ok", VerifierId="SignoffControl1_lblVerifierID", VerifierPassword="SignoffControl1_lblVerPwd", VerOkButtonId="SignoffControl1_verOk"}
                                              };   

            #endregion

            #region Single Double Signoff Logic
            // set ClassName and search the window by using all Class Name in the array list 
            bool bterminate = false;
            foreach (var signoffWindowClass in signoffWindowClasses)
            {
                signOffWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = signoffWindowClass;
                if (signOffWindow.TryFind())
                {
                    // set Id and search each control by using all Control Id in the array list
                    foreach (var signOffParams in signOffParamsList)
                    {
                        comment.SearchProperties[HtmlTextArea.PropertyNames.Id] = signOffParams.CommentId;
                        user1.SearchProperties[HtmlEdit.PropertyNames.Id] = signOffParams.UserId;
                        password.SearchProperties[HtmlEdit.PropertyNames.Id] = signOffParams.PasswordId;
                        okButton.SearchProperties[HtmlInputButton.PropertyNames.Id] = signOffParams.OkButtonId;

                        if (comment.TryFind() && user1.TryFind() && password.TryFind() && okButton.TryFind())
                        {
                            #region Single Signoff
                            comment.Text = signoffParams.SignoffComment;
                            user1.Text = signoffParams.SignoffUser1;
                            password.Text = signoffParams.SignoffUser1Password;
                            Mouse.Click(okButton);
                            #endregion

                            #region Double Signoff Code
                            if (signoffParams.SignoffUser2 != null && signoffParams.SignoffUser2Password != null)
                            {
                                user2.SearchProperties[HtmlEdit.PropertyNames.Id] = signOffParams.VerifierId;
                                passwordVer.SearchProperties[HtmlEdit.PropertyNames.Id] = signOffParams.VerifierPassword;
                                okButtonVer.SearchProperties[HtmlInputButton.PropertyNames.Id] = signOffParams.VerOkButtonId;

                                user2.WaitForControlReady();
                                user2.WaitForControlEnabled();
                                user2.Text = signoffParams.SignoffUser2;
                                passwordVer.Text = signoffParams.SignoffUser2Password;
                                Mouse.Click(okButtonVer);
                            }
                            #endregion

                            bterminate = true;
                            break;
                        }
                        else if (comment.TryFind())
                        {
                            HtmlInputButton verOkButton = new HtmlInputButton(signOffWindow);
                            verOkButton.SearchProperties[HtmlInputButton.PropertyNames.Id] = "SignoffUserControl1_verOk";
                            comment.Text = signoffParams.SignoffComment;
                            verOkButton.TryFind();
                            Mouse.Click(verOkButton);
                            bterminate = true;
                            break;
                        }
                       
                    } 

                }
                if (bterminate)
                    break;
            }
            #endregion
        }

    }

    /// <summary>
    /// Parameters to be passed into 'SingleSignoff'
    /// </summary>
    public class SignoffParams
    {
        #region Fields
        public string SignoffComment { get; set; }
        public string SignoffUser1 { get; set; }
        public string SignoffUser1Password { get; set; }
        public string SignoffUser2 { get; set; }
        public string SignoffUser2Password { get; set; }
        public string SignoffType { get; set; }
        #endregion
    }

    public class SignOffControls
    {
        public string CommentId;
        public string UserId;
        public string VerifierId;
        public string VerifierPassword;
        public string PasswordId;
        public string OkButtonId;
        public string VerOkButtonId;
    }
}

