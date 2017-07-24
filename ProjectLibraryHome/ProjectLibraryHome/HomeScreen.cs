using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectLibraryHome
{
    public static class HomeScreen
    {
        public static void LoginPOMSnet(string url, string username, string password)
        {
            BrowserWindow browserWindow = BrowserWindow.Launch(new System.Uri(url));
            browserWindow.WaitForControlReady();

            HtmlEdit txtUsername = new HtmlEdit(browserWindow);
            txtUsername.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "txtUsername");
            txtUsername.SetProperty(HtmlEdit.PropertyNames.Text, username);

            HtmlEdit txtPassword = new HtmlEdit(browserWindow);
            txtPassword.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "txtPassword");
            txtPassword.SetProperty(HtmlEdit.PropertyNames.Text, password);

            HtmlInputButton inputButton = new HtmlInputButton(browserWindow);
            inputButton.SearchProperties.Add(HtmlInputButton.PropertyNames.Id, "XbtnLogin");
            Mouse.Click(inputButton);

            browserWindow.CloseOnPlaybackCleanup = false;
        }

        public static void LogOffPOMSnet()
        {
            BrowserWindow browserWindow = new BrowserWindow();
            HtmlCustom logOffLink = new HtmlCustom(browserWindow);

            logOffLink.SearchProperties[HtmlCustom.PropertyNames.Id] = "Header1_lnkLogOff";

            if (logOffLink.TryFind())
            {
                Mouse.Click(logOffLink);
            }
            else
            {
                logOffLink.SearchProperties[HtmlCustom.PropertyNames.Id] = "Header_lnkLogOff";
                logOffLink.TryFind();
                Mouse.Click(logOffLink);
            }

            WinWindow bW = new WinWindow();
            bW.SearchProperties[WinWindow.PropertyNames.Name] = "Message from webpage";
            WinButton OKButton = new WinButton(bW);


            OKButton.SearchProperties[WinButton.PropertyNames.Name] = "OK";
            OKButton.TryFind();
            OKButton.EnsureClickable();
            OKButton.WaitForControlReady(3000);
            Mouse.Click(OKButton);
        }

        public static void HelpPOMSnet()
        {
            BrowserWindow browserWindow = new BrowserWindow();
            HtmlHyperlink helpLink = new HtmlHyperlink(browserWindow);
            
            helpLink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = "Help";

            if (helpLink.TryFind())
            {
                helpLink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = "Help";
                Mouse.Click(helpLink);
            }
            else
            {
                helpLink.SearchProperties[HtmlHyperlink.PropertyNames.Id] = "Header1_lnkHelp";
                helpLink.TryFind();
                Mouse.Click(helpLink);
            }
        }

        public static void AccountPOMSnet()
        {
            BrowserWindow browserWindow = new BrowserWindow();
            HtmlHyperlink accountLink = new HtmlHyperlink(browserWindow);


            accountLink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = "Account";

            if (accountLink.TryFind())
            {
                accountLink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = "Account";
                Mouse.Click(accountLink);
            }
            else
            {
                accountLink.SearchProperties[HtmlHyperlink.PropertyNames.Id] = "Header1_lnkAccount";
                accountLink.TryFind();
                Mouse.Click(accountLink);
            }


        }

        public static void HomePOMSnet()
        {
            BrowserWindow browserWindow = new BrowserWindow();
            HtmlHyperlink homeLink = new HtmlHyperlink(browserWindow);


            homeLink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = "Home";

              if (homeLink.TryFind())
            {
                homeLink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = "Home";
                Mouse.Click(homeLink);
            }
            else
            {
                homeLink.SearchProperties[HtmlHyperlink.PropertyNames.Id] = "Header1_lnkHome";
                homeLink.TryFind();
                Mouse.Click(homeLink);
            }

           
        }

        public static void AssertPOMSNetKnowledgeWeb()
        {
            #region Initialization
            BrowserWindow helpWindow = new BrowserWindow();
            helpWindow.SearchProperties[UITestControl.PropertyNames.Name] = "POMSnet KnowledgeWeb";
            helpWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            helpWindow.WindowTitles.Add("POMSnet KnowledgeWeb");

            #endregion

            helpWindow.TryFind();
            StringAssert.Contains(helpWindow.Name, "POMSnet KnowledgeWeb", "POMSnet KnowledgeWeb Assert Failed");
            Playback.Wait(2000);
            helpWindow.Close();
        
            
           
        
        }

    }
}
