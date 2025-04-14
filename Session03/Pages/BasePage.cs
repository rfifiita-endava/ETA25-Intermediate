using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETA25_Intermediate.Session03.Pages;

public class BasePage
{
    public BasePage(IWebDriver driver)
    {
        Driver = driver;
    }

    protected IWebDriver Driver { get; }

    // WebElements
    public IWebElement ElementsMenu => GetMenuSection(1);
    public IWebElement FormsMenu => GetMenuSection(2);
    public IWebElement AlertsFramesWindowsMenu => GetMenuSection(3);
    public IWebElement WidgetsMenu => GetMenuSection(4);
    public IWebElement InteractionsMenu => GetMenuSection(5);
    public IWebElement BookStoreApplicationMenu => GetMenuSection(6);



    private IWebElement GetMenuSection(int elemNo)
    {
        if (elemNo < 1 || elemNo > 6)
        {
            throw new ArgumentException("Element number out of valid range [1-6]");
        }

        return Driver.FindElement(By.XPath($"//div[@class=\"element-group\"][{elemNo}]"));
    }
}
