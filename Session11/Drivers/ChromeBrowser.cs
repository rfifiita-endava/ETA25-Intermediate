using ETA25_Intermediate.Session11.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ETA25_Intermediate.Session11.Drivers;

public class ChromeBrowser : IBrowser
{
    public IWebDriver CreateDriver()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");

        return new ChromeDriver(options);
    }
}
