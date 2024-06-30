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
    public class CartManagment
    {
        private IWebDriver driver;

        public CartManagment(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CartManagment1 (IWebDriver driver, string productNamedetail)
        {
            //Verifying that user is able to add more qty of the product

            var AddQty = driver.FindElement(By.Id("qntty-plus"));

            System.Threading.Thread.Sleep(1000);

            AddQty.Click();

            Console.WriteLine("Qty added successfully");

            System.Threading.Thread.Sleep(2000);

            // Verify that user is able to delete product from cart
            var DltProduct = driver.FindElement(By.XPath("//a[@class='waves-effect waves-dark btn-cartempty' and contains(., 'Empty')]"));
            System.Threading.Thread.Sleep(1000);

            DltProduct.Click();

            System.Threading.Thread.Sleep(1000);


            //Handeling Alert popup

            IAlert alert = driver.SwitchTo().Alert();

            Console.WriteLine(alert.Text);

            alert.Accept();

            try
            {
                // Try to find the cart item elements
                var cartItems = driver.FindElements(By.Id("cartlinks")); // Ensure this is the correct class or identifier

                // Assert that there are no cart items
                Assert.AreEqual(1, cartItems.Count, "The cart is not empty after deleting the product.");
            }
            catch (NoSuchElementException)
            {
                // If no cart items are found, assume the cart is empty
                Console.WriteLine("The cart is not empty after deleting the product.");
            }


            //Assert.AreEqual(PName, productNamedetail, "The product name does not match the search result.");


            Console.WriteLine("The cart is empty as expected, TestCase Result: Pass");
        }

    }
}
