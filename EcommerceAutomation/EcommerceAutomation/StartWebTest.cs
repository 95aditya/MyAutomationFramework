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


namespace EcommerceAutomation
{
    class Program
    {
         
        static void Main(string[] args)
        {
            // Initialize the ChromeDriver
            IWebDriver driver = new ChromeDriver();

            try
            {
                // Navigate to the Ondoor website

                driver.Navigate().GoToUrl("https://www.ondoor.com/");

                System.Threading.Thread.Sleep(1000);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                driver.Manage().Window.Maximize();

                System.Threading.Thread.Sleep(1000);

                //Store specific product name in variable

                String ExpectedproductName = "Hamdard roohafza 750.00 ml";
                String ExpectedproductNamedetail = "Hamdard Roohafza 750.00 Ml...";

                //Create object for HomePage class

                HomePage hpage = new HomePage(driver);

                hpage.SearchFunctionality (driver, ExpectedproductName);


                // Create object for AddToCart

                AddToCart PDetails =  new AddToCart (driver);

                PDetails.AddToCart1(driver, ExpectedproductNamedetail);


                // Create object for CartManagment

                CartManagment CartDetails = new CartManagment (driver);

                CartDetails.CartManagment1(driver, ExpectedproductNamedetail);


                // Create object for CheckOutProcess class

                CheckOutProcess ChkOut = new CheckOutProcess (driver);

                ChkOut.CheckOut(driver, ExpectedproductNamedetail);

            }



            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


            finally
            {
                // Close the browser
                //driver.Quit();
                Console.WriteLine("Script Execute Success");
            }
        }
      
    }
}
