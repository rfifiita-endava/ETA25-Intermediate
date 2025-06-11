using OpenQA.Selenium;

namespace ETA25_Intermediate.Session11.HelperMethods;

public class JavascriptHelper
{
    private readonly IWebDriver _driver;
    private readonly IJavaScriptExecutor _javascriptExecutor;

    public JavascriptHelper(IWebDriver driver)
    {
        _driver = driver;
        _javascriptExecutor = (IJavaScriptExecutor)_driver;
    }

    /// <summary>
    /// Executes a javascript scroll to the x, y coordinates
    /// </summary>
    public void Scroll(int x, int y)
    {
        _javascriptExecutor.ExecuteScript($"window.scrollTo({x}, {y});");
    }

    public void ExecuteScript(string scriptJs)
    {
        _javascriptExecutor.ExecuteScript(scriptJs);
    }

    public string GetElementTextContent(string cssSelector)
    {
        return (string)_javascriptExecutor.ExecuteScript($"document.querySelector(\"{cssSelector}\").innerText");
    }

    public void ScrollHorizontally(int x)
    {
        _javascriptExecutor.ExecuteScript($"window.scrollTo({x}, 0);");
    }

    public void ScrollVertically(int y)
    {
        _javascriptExecutor.ExecuteScript($"window.scrollTo(0, {y});");
    }

    public void ForceClick(IWebElement element)
    {
        _javascriptExecutor.ExecuteScript("arguments[0].click();", element);
    }
}
