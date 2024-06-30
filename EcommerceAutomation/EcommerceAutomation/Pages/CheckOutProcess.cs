using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using EcommerceAutomation.Pages;

namespace EcommerceAutomation.Pages
{
    public class CheckOutProcess
    {
        private IWebDriver driver;

        public CheckOutProcess(IWebDriver driver)
        {
            this.driver = driver;
        }

        bool isElementPresent = false; 


        public void CheckOut(IWebDriver driver, string productNamedetail)
        {
            System.Threading.Thread.Sleep(1500);

            driver.Navigate().Refresh(); //To avoid stale element exception

            System.Threading.Thread.Sleep(1500);

            var addToCartButton = driver.FindElement(By.XPath("//button[contains(@class, 'btn-add2cart') and contains(@class, 'add174cart') and contains(@onclick, \"cart.add('174'\")]"));

            System.Threading.Thread.Sleep(1000);

            addToCartButton.Click();

            System.Threading.Thread.Sleep(1500);

            Console.WriteLine("Item is added to Cart");

            var productLink = driver.FindElement(By.Id("cartlinks"));

            System.Threading.Thread.Sleep(1500);

            productLink.Click();

            System.Threading.Thread.Sleep(1500);


            //Verify Checkout Process

            //var ChkOut = driver.FindElement(By.ClassName("btn-cartcheckout"));
            var checkoutLink = driver.FindElement(By.XPath("//a[@class='waves-effect btn-cartcheckout' and contains(@onclick, \"CheckOut('https://www.ondoor.com/checkout/checkout')\")]"));

            checkoutLink.Click();
            System.Threading.Thread.Sleep(1500);

            Assert.AreEqual("https://www.ondoor.com/checkout/checkout", driver.Url, "User is not redirected to the checkout page.");

            try
            {
                isElementPresent = driver.FindElements(By.Id("offer")).Any();
                System.Threading.Thread.Sleep(1500);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Element Not Found");
            }
            if (isElementPresent == true)
            {
                var OfferPopup = driver.FindElement(By.ClassName("btn-gray-new"));

                OfferPopup.Click();
                System.Threading.Thread.Sleep(1500);
            }

            var orderSummaryElement = driver.FindElement(By.ClassName("order-sumary")); // Replace with the actual element on the order summary page
            Assert.IsNotNull(orderSummaryElement, "Order Summary page is not displayed.");

            Console.WriteLine("User is redirected to Order Summary Page, TestCase Result: Pass");
        }

    }


}
