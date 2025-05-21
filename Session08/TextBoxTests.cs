using ETA25_Intermediate.Session08.Enums;
using ETA25_Intermediate.Session08.HelperMethods;
using ETA25_Intermediate.Session08.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ETA25_Intermediate.Session08;

public class TextBoxTests : BaseTest
{
    // Input field values
    //public const string FullName = "Radu Fifiita";
    //public const string Email = "rf-test@email123.com";
    //public const string CurrentAddress = "This is my current address 123";
    //public const string PermanentAddress = "The permanent address is this one %^&";

    [TestCase(["Radu Fifiita", "rf-test@email123.com", "This is my current address 123", "The permanent address is this one %^&"])]
    public void FillFormTest(string fullName, string email, string currentAddress, string permanentAddress)
    {
        // HomePage - Var1
        //_homePage.ElementsCard.Click();

        // HomePage - Var2
        //_homePage.AccessElementsPage();

        // HomePage - Var3
        HomePage.AccessPageByName(CardName.Elements);

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
        fullNameInput.SendKeys(fullName);
        userEmailInput.SendKeys(email);
        currentAddressInput.SendKeys(currentAddress);
        permanentAddressInput.SendKeys(permanentAddress);

        JavascriptHelper.Scroll(0, 500);

        // Save field value
        submitButton.Click();
        //JavascriptHelper.ForceClick(submitButton);

        Thread.Sleep(3000);
    }
}
