using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AutomationRhapsody.Utf8icons
{
    class Program
    {
        static void Main(string[] args)
        {
            // Launch browser
            IWebDriver webDriver = new FirefoxDriver();
            webDriver.Url = "http://automationrhapsody.com/examples/utf8icons.html";
            webDriver.Navigate();

            // Locate element
            IWebElement element = webDriver.FindElement(By.CssSelector("span.cancel"));
            
            // Debug info
            bool isDisplayed = element.Displayed; // false
            int width = element.Size.Width; // 0
            int heigth = element.Size.Height; // 17

            // Try to click -> An unhandled exception of type 'OpenQA.Selenium.ElementNotVisibleException' occurred in WebDriver.dll
            //element.Click();

            // jQuery workaround of the click
            ((IJavaScriptExecutor)webDriver).
                ExecuteScript("$('span.cancel').click()");

            // JavaScript workaround of the click
            ((IJavaScriptExecutor)webDriver).
                ExecuteScript("document.getElementsByClassName('cancel')[0].click();");

            // Locate same element with jQuery
            element = (IWebElement)((IJavaScriptExecutor)webDriver).ExecuteScript("return $('span.cancel')[0]");
            // Debug info
            isDisplayed = element.Displayed; // false
            width = element.Size.Width; // 0
            heigth = element.Size.Height; // 17
        }
    }
}
