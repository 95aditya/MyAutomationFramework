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
    public class AddToCart
    {
        private IWebDriver driver;

        public AddToCart(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AddToCart1(IWebDriver driver, string productNamedetail)
        {
            //Verifying Add to Cart Button

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var productLink1 = wait.Until(d => d.FindElement(By.ClassName("add174cart"))).Displayed;

            Console.WriteLine("Add to Cart button is displayed");

            System.Threading.Thread.Sleep(1000);


            //Verify that user is able to add searched product into the cart

            var  addToCartButton = wait.Until(d => d.FindElement(By.ClassName("add174cart")));

            System.Threading.Thread.Sleep(1000);

            addToCartButton.Click();

            Console.WriteLine("Item is added to Cart");


            //Verify that user is redirected to cart page

            var productLink = driver.FindElement(By.Id("cartlinks"));

            System.Threading.Thread.Sleep(1500);

            productLink.Click();

            System.Threading.Thread.Sleep(2000);

            string PName = driver.FindElement(By.ClassName("cartem-name")).Text;

            Console.WriteLine(PName);

            Console.WriteLine(productNamedetail);


            //Declare Result of Entire test case using assertion

            System.Threading.Thread.Sleep(1500);

            Assert.AreEqual(PName, productNamedetail, "The product name does not match the search result.");

            Console.WriteLine("Product added to cart, TestCase Result: Pass");
        }

    }


}
