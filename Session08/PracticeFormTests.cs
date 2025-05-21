using ETA25_Intermediate.Session08.Enums;
using ETA25_Intermediate.Session08.HelperMethods;
using ETA25_Intermediate.Session08.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ETA25_Intermediate.Session08;
public class PracticeFormTests : BaseTest
{
    [Test]
    public void PracticeFormTest1()
    {
        HomePage.AccessPageByName(CardName.Forms);

        IWebElement practiceFormOption = Driver.FindElement(By.XPath("//span[text()=\"Practice Form\"]"));
        practiceFormOption.Click();
        JavascriptHelper.ScrollVertically(400);

        PracticeFormPage.FillInFormFields("Radu", "Fifiita", "test@test.com", Gender.Male, "00010305", "1992", "April", "16",
            new List<string>() { "English", "Accounting", "Physics" }, new List<Hobby>() { Hobby.Music, Hobby.Reading }, "Test Address 123, &*()");

        Thread.Sleep(3000);
    }
}
