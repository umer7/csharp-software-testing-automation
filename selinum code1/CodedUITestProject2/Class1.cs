using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using WinForms = System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UITesting;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUITestProject2
{
    class Program
    {
        //[TestMethod]

        static void Main(string[] args)
        {
         public void TestingOne()
        {
            //string URL = "http://va24-pd-r4003w/Hoops";
            string URL = "file:///C:/Users/umer/Documents/Visual%20Studio%202015/Projects/dm21/dm21/h1.html";
            // string IE_DRIVER_PATH = @"C:\SeleniumIE\";
            string IE_DRIVER_PATH = @"D:\Fall 2k16\SoftwareTesting(CS-497)AmirImam\Selenium\SeleniumIE\IEDriverServer.exe";
            /*
             var options = new InternetExplorerOptions()
             {
                 InitialBrowserUrl = URL,
                 IntroduceInstabilityByIgnoringProtectedModeSettings = true
             };
             var driver = new InternetExplorerDriver(IE_DRIVER_PATH, options);
             */



            IWebDriver driver = new InternetExplorerDriver(IE_DRIVER_PATH);
            //  IWebDriver driver = new GoogleChormeDriver
            //IWebDriver driver = new FirefoxDriver();



            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();


            //IWebElement userIdInput = driver.FindElement(By.Id("txtUsername"));
            //IWebElement passwordInput = driver.FindElement(By.Id("txtPassword"));
            //IWebElement loginButton = driver.FindElement(By.Id("XbtnLogin"));
            //IWebElement userIdInput = driver.FindElement(By.CssSelector("#txtUsername"));
            //IWebElement loginButton = driver.FindElement(By.XPath("XbtnLogin"));


            //userIdInput.SendKeys("a1");
            //passwordInput.SendKeys("Karachi1.");
            //loginButton.SendKeys(Keys.Enter);

            //IWebElement loggOff = driver.FindElement(By.Id("Header1_lnkLogOff"));
            //loggOff.Click();



            //direct
            //  driver.FindElement(By.Id("txtUsername")).SendKeys("ms1");
            // driver.FindElement(By.Id("txtPassword")).SendKeys("Karachi1");
            //driver.FindElement(By.Id("XbtnLogin")).Click();

            //int index = 0;
            //WebElement baseTable = driver.findElement(By.className("table gradient myPage"));
            //List<WebElement> tableRows = baseTable.findElements(By.tagName("tr"));
            //tableRows.get(index).getText();

            // find the customer table
            IWebElement table = driver.FindElement(By.XPath("//div[@class='dataframe']/table"));

            // find the row
            IWebElement customer = table.FindElement(By.XPath("//tr/td[contains(text(), 'Martin')]"));

            // click on the row
            customer.Click();

            //driver.FindElement(By.CssSelector("#txtUsername")).SendKeys("a1");
            //driver.FindElement(By.XPath("id('txtPassword')")).Click();

            //  driver.FindElement(By.Id("Header1_lnkLogOff")).Click();

            // string myWindowHandle = driver.WindowHandles.ToString();
            //driver.SwitchTo().Window(myWindowHandle);

            //driver.FindElement(By.Id("OK")).Click();

            //driver.Close();
            //WinForms.MessageBox.Show("OK CLICKED");

            // Thread.Sleep(50000);



/*
            driver.Navigate().GoToUrl("http://va24-pd-r4003w/Hoops/Apps/RecipeExecution/OrderManagement/UI/OrderManagement.aspx");
            int rRindx = SelectCheckBoxGrid("001", "OrderList1_grid_chkSelect_");
            WinForms.MessageBox.Show(rRindx.ToString());

            // driver.FindElement(By.Id("OrderList1_grid_chkSelect_"+rRindx)).Click();
            */
        }


    
    }
        public int SelectCheckBoxGrid(string InnerTextAttribute, string CheckBoxExpressionID)
        {
            BrowserWindow _bw = new BrowserWindow();
            HtmlCell _Cell = new HtmlCell(_bw);
            HtmlCheckBox _chk = new HtmlCheckBox(_bw);

            _Cell.SearchProperties[HtmlCell.PropertyNames.InnerText] = InnerTextAttribute;
             int rCheckIndex = _Cell.RowIndex - 1;
            return rCheckIndex;
        }

     
    }
}