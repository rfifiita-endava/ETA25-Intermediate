using ETA25_Intermediate.Session09.Enums;
using ETA25_Intermediate.Session09.HelperMethods;
using ETA25_Intermediate.Session09.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace ETA25_Intermediate.Session09;
public abstract class BaseTest
{
    protected IWebDriver Driver { get; private set; } = null!;
    public const string BaseUrl = "https://demoqa.com/";

    protected AlertHelper AlertHelper { get; private set; } = null!;
    protected JavascriptHelper JavascriptHelper { get; private set; } = null!;
    protected HomePage HomePage { get; private set; } = null!;

    [SetUp]
    public void Setup()
    {
        var arg = TestContext.CurrentContext.Test.Arguments.FirstOrDefault()?.ToString();
        var result = Enum.TryParse(arg, out DriverType driverType);

        // Driver initialization
        switch (driverType)
        {
            case DriverType.Chrome:
                Driver = new ChromeDriver();
                break;
            case DriverType.Firefox:
                Driver = new FirefoxDriver();
                break;
            default:
                Driver = new ChromeDriver();
                break;
        }

        AlertHelper = new AlertHelper(Driver);
        JavascriptHelper = new JavascriptHelper(Driver);
        HomePage = new HomePage(Driver);

        Driver.Navigate().GoToUrl(BaseUrl);
        Driver.Manage().Window.Maximize();
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
