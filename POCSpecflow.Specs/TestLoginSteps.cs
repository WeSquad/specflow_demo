using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using NUnit.Framework;

namespace POCSpecflow.Specs
{
    [Binding]
    public class TestLoginSteps
    {
        private IWebDriver driver;
        [Given(@"user has open IE")]
        public void GivenUserHasOpenIE()
        {
            driver = new InternetExplorerDriver();
            driver.Url = "http://localhost:55857/";
            ScenarioContext.Current.Set<IWebDriver>(driver);
            TestContext.Out.WriteLine("opening IE browser" );
            //ScenarioContext.Current.Pending();
        }
        
        [Given(@"user has entered a ""(.*)""")]
        public void GivenUserHasEnteredA(string p0)
        {
        
            IWebElement emailInput = driver.FindElement(By.Id("Email"));
            Console.WriteLine("seting input at :" +p0);
            emailInput.SendKeys(p0);
            //ScenarioContext.Current.Pending();
        }
        
        [Given(@"user has ented a ""(.*)""")]
        public void GivenUserHasEntedA(string p0)
        {
            
            IWebElement emailInput = driver.FindElement(By.Id("Password"));
            Console.WriteLine("seting input at :" + p0);
            emailInput.SendKeys(p0);
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"the user press on the login button")]
        public void WhenTheUserPressOnTheLoginButton()
        {
            IWebElement emailInput = driver.FindElement(By.Id("submitBtn"));
            emailInput.Click();
            
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result must be ""(.*)""")]
        public void ThenTheResultMustBe(string p0)
        {
            IWebElement warning = driver.FindElement(By.Id("notValidData"));
            string warningSign = warning.GetAttribute("innerHTML");
            if(p0 == "valid")
            {
                Assert.AreEqual(warningSign, "");
            }
            else
            {
                Assert.AreNotEqual(warningSign, "");
            }
            
            driver.Quit(); //also close the  IEDriverServer.exe console
            //ScenarioContext.Current.Pending();

        }
    }
}
