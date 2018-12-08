using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Threading;
using System.IO;

namespace HW_Selenium_Basic_pt1
{
    class Program
    {
        //private static IWebDriver driver;
        static void Main(string[] args)
        {
            IWebDriver driverCh = new ChromeDriver();
            HomeWorkTasks(driverCh);
            /*IWebDriver driverMF = new FirefoxDriver();
            HomeWorkTasks(driverMF);
            IWebDriver driverIE = new InternetExplorerDriver();
            HomeWorkTasks(driverIE);*/

        }
        public static void HomeWorkTasks(IWebDriver driver)
        {
            //1.Navigate to http://www.leafground.com/
            //driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.leafground.com/");
            
            //2.Click "Edit"
            driver.FindElement(By.CssSelector("[href*='pages/Edit.html']"))
                .Click();
            
            //3.Enter text into first input
            driver.FindElement(By.Id("email")).
                SendKeys("tester.petrov9078@gmail.com");
            
            //4.Delete text from third input
            driver.FindElements(By.Name("username")).First().
                Clear();

            //5.Verify that last input is disabled
            IWebElement lastInput;
            lastInput = driver.FindElement(By.CssSelector("input[disabled='true']"));
            if (!lastInput.Enabled)
            {
                Console.WriteLine("Last input is disabled");
            }
            else throw new InvalidOperationException("Last input is not disabled");

            //6.Go back
            driver.Navigate().
                Back();
            
            //7.Click "Button"
            driver.FindElement(By.LinkText("Button")).
                Click();
            
            //8.Save page url
            string url = driver.Url;
            Console.WriteLine("Saved url: " + url);
            if (!url.Contains("http://www.leafground.com"))
            {
                throw new InvalidOperationException("Invalid page url");
            }

            //9.Click "Go to Home Page" button
            driver.FindElement(By.Id("home")).
                Click();
            
            //10.Go back
            driver.Navigate().
                Back();
            
            //11.Get css value of "What color am I?" button
            string cssproperty = driver.FindElement(By.Id("color"))
                .GetCssValue("background-color");
            Console.WriteLine("Used css value is: " + cssproperty);

            //12.Click HyperLink section
            driver.FindElement(By.CssSelector("[href*='home.html']"))
                .Click();
            driver.FindElement(By.LinkText("HyperLink")).
                Click();
            
            //13.Click "Go to Home Page" using LinkText
            driver.FindElement(By.LinkText("Go to Home Page")).
                Click();
            
            //14.Navigate to Radio buttons section
            driver.FindElement(By.CssSelector("[href*='pages/radio.html']"))
                .Click();
            
            //15.Click "No" radio button
            driver.FindElement(By.Id("no")).
                Click();
            
            //16.Verify Checked and Unchecked radio buttons
            IWebElement radiobutton1;
            IWebElement radiobutton2;
            radiobutton1 = driver.FindElements(By.CssSelector("input[name='news']")).First();  //////////////
            radiobutton2 = driver.FindElements(By.CssSelector("input[name='news']")).Last();
            if (!radiobutton1.Selected)
            {
                Console.WriteLine("First radiobutton is unchecked");
            }
            else throw new InvalidOperationException("First radiobutton is checked");

            if (radiobutton2.Selected)
            {
                Console.WriteLine("Second radiobutton is checked");
            }
            else throw new InvalidOperationException("Second radiobutton is unchecked");

            //17.Refresh the page
            driver.Navigate().
                Refresh();

            //18.Verify that "No" radio button isn't selected
            IWebElement radiobuttonNo;
            radiobuttonNo = driver.FindElement(By.Id("no"));
            if (!radiobuttonNo.Selected)
            {
                Console.WriteLine("'No' radiobutton is not selected");
            }
            else throw new InvalidOperationException("'No' radiobutton is selected");

            //19.Get the text of selected radio button in "Select your age group" section (optional)
            string textvalue = driver.FindElements(By.Name("age"))[1].Text;
           
            //20.Go to home page
            driver.FindElement(By.CssSelector("[href*='home.html']"))
                .Click();

            //21.Get attribute of Edit section
            string editAttribute = driver.FindElement(By.CssSelector("[href*='pages/Edit.html']"))
                .GetAttribute("href");
            Console.WriteLine("Attribute of Edit section: " + editAttribute);

            driver.Quit();
        }
    }
}
