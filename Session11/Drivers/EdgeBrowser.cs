using ETA25_Intermediate.Session11.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace ETA25_Intermediate.Session11.Drivers;

public class EdgeBrowser : IBrowser
{
    public IWebDriver CreateDriver()
    {
        var options = new EdgeOptions();
        options.AddArgument("--start-maximized");

        return new EdgeDriver(options);
    }
}
