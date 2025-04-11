using ETA25_Intermediate.Session02.HelperMethods;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ETA25_Intermediate.Session02;

public class TextBoxTests
{
    public IWebDriver Driver;
    public const string BaseUrl = "https://demoqa.com/";
    public JavascriptHelper JavascriptHelper;

    // Input field values
    public const string FullName = "Radu Fifiita";
    public const string Email = "rf-test@email123.com";
    public const string CurrentAddress = "This is my current address 123";
    public const string PermanentAddress = "The permanent address is this one %^&";

    public TextBoxTests()
    {
        Driver = new ChromeDriver();
        JavascriptHelper = new JavascriptHelper(Driver);
    }

    [SetUp]
    public void Setup()
    {
        Driver.Navigate().GoToUrl(BaseUrl);

        Driver.Manage().Window.Maximize();
    }

    [Test]
    public void FillFormTest()
    {
        IWebElement elementButton = Driver.FindElement(By.XPath("//h5[text()=\"Elements\"]"));
        elementButton.Click();

        IWebElement textBoxOption = Driver.FindElement(By.XPath("//span[text()=\"Text Box\"]"));
        textBoxOption.Click();

        // Initializam un WebElement pentru input-ul "Full Name"
        //By fullNameInputSelector = By.Id("userName");
        //IWebElement fullNameInput = Driver.FindElement(fullNameInputSelector);

        IWebElement fullNameInput = Driver.FindElement(By.Id("userName"));

        IWebElement userEmailInput = Driver.FindElement(By.Id("userEmail"));

        IWebElement currentAddressInput = Driver.FindElement(By.Id("currentAddress"));

        IWebElement permanentAddressInput = Driver.FindElement(By.Id("permanentAddress"));

        IWebElement submitButton = Driver.FindElement(By.Id("submit"));

        // Fill in fields with values
        fullNameInput.SendKeys(FullName);
        userEmailInput.SendKeys(Email);
        currentAddressInput.SendKeys(CurrentAddress);
        permanentAddressInput.SendKeys(PermanentAddress);

        JavascriptHelper.Scroll(0, 500);

        // Save field value
        submitButton.Click();
        //JavascriptHelper.ForceClick(submitButton);

        Thread.Sleep(3000);
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
}
