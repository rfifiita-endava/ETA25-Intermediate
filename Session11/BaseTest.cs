using ETA25_Intermediate.Session11.Drivers;
using ETA25_Intermediate.Session11.Enums;
using ETA25_Intermediate.Session11.HelperMethods;
using ETA25_Intermediate.Session11.Interfaces;
using ETA25_Intermediate.Session11.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ETA25_Intermediate.Session11;
public abstract class BaseTest
{
    protected IWebDriver Driver { get; private set; } = null!;
    public const string BaseUrl = "https://demoqa.com/";

    protected AlertHelper AlertHelper { get; private set; } = null!;
    protected JavascriptHelper JavascriptHelper { get; private set; } = null!;
    protected HomePage HomePage { get; private set; } = null!;
    protected DriverType DriverType { get; }

    protected BaseTest() : this(DriverType.Chrome)
    {
    }

    protected BaseTest(DriverType driverType)
    {
        DriverType = driverType;
    }

    [SetUp]
    public void Setup()
    {
        var arg = TestContext.CurrentContext.Test.Arguments.FirstOrDefault()?.ToString();
        var result = Enum.TryParse(arg, out DriverType driverTypeArg);

        // identify the type of browser class needed
        IBrowser browser = result is not false ? BrowserFactory.GetBrowser(driverTypeArg) : BrowserFactory.GetBrowser(DriverType);

        // initialize the actual IWebDriver
        Driver = browser.CreateDriver();

        Driver.Navigate().GoToUrl(BaseUrl);


        AlertHelper = new AlertHelper(Driver);
        JavascriptHelper = new JavascriptHelper(Driver);
        HomePage = new HomePage(Driver);
    }

    [TearDown]
    public void CleanUp()
    {
        if (Driver != null)
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }

    /// <summary>
    /// Please decorate this method with [SetUp] attribute
    /// and use it for extra setup before running tests
    /// </summary>
    public abstract void ExtraSetup();

    /// <summary>
    /// Please decorate this method with [TearDown] attribute
    /// and use it for extra cleanup after running tests
    /// </summary>
    public abstract void ExtraCleanup();
}
