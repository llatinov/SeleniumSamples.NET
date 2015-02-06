using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace AutomationRhapsody.DesignPatterns
{
    public class WebDriverFacade
    {
        private IWebDriver webDriver = null;
        private TimeSpan waitForElement = TimeSpan.FromSeconds(5);

        public WebDriverFacade(Browsers browser)
        {
            WebDriverFactory factory = new WebDriverFactory();
            webDriver = factory.CreateInstance(browser);
        }

        public void Start(string url)
        {
            webDriver.Url = url;
            webDriver.Navigate();
        }

        public void Stop()
        {
            webDriver.Quit();
        }

        public object ExecuteJavaScript(string script)
        {
            return ((IJavaScriptExecutor)webDriver).ExecuteScript("return " + script);
        }

        public IWebElement FindElement(By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, waitForElement);
                return wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch
            {
                return NullWebElement.NULL;
            }
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, waitForElement);
            return wait.Until(driver =>
            {
                try
                {
                    return driver.FindElements(by);
                }
                catch
                {
                    return null;
                }
            });
        }
    }
}
