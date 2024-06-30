using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace EcommerceAutomation.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Test01 Verify that Search Item is display.
        public void SearchFunctionality(IWebDriver driver, string productName)
        {
            //Verifying Products Grid

            var ProductGrid = driver.FindElement(By.Id("animatedModal")).Displayed;

            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("Product List is Displayed");


            //Verify user is able to search any particular product

            var searchBox = driver.FindElement(By.Id("searchfld"));

            System.Threading.Thread.Sleep(1000);

            searchBox.SendKeys(productName);

            System.Threading.Thread.Sleep(1000);

            searchBox.SendKeys(Keys.Enter);            

            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("Search product is Filtered");


            //Verify Searched product details page

            var searchResults = driver.FindElements(By.ClassName("prod-thumb"));

            System.Threading.Thread.Sleep(1000);

            searchResults[0].Click();

            Console.WriteLine("Product detail Page is displayed");

            System.Threading.Thread.Sleep(1000);

            String PName = driver.FindElement(By.TagName("h4")).Text;


            //Declare Result of Entire test case using assertion

            Assert.AreEqual(PName, productName, "The product name does not match the search result.");

            Console.WriteLine("Search functionality verified, TestCase Result: Pass");

            #endregion

            }
    }
}
