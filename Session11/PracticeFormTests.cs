using ETA25_Intermediate.Session11.Enums;
using ETA25_Intermediate.Session11.HelperMethods;
using ETA25_Intermediate.Session11.Pages;
using NUnit.Framework;

namespace ETA25_Intermediate.Session11;

public class PracticeFormTests : BaseTest
{
    protected PracticeFormPage PracticeFormPage { get; private set; } = null!;

    [TearDown]
    public override void ExtraCleanup()
    {
        // add implementation here
    }

    [SetUp]
    public override void ExtraSetup()
    {
        PracticeFormPage = new PracticeFormPage(Driver);

        HomePage.AccessPageByName(CardName.Forms);

        PracticeFormPage.AccessSideMenuOption(FormsMenuOption.PracticeForm);
        JavascriptHelper.ScrollVertically(400);
    }

    [Test]
    public void PracticeFormTest1()
    {
        PracticeFormPage.FillInFormFields("Radu", "Fifiita", "test@test.com", Gender.Male, "00010305", "1992", "April", "16",
            new List<string>() { "English", "Accounting", "Physics" }, new List<Hobby>() { Hobby.Music, Hobby.Reading }, "Test Address 123, &*()");

        Thread.Sleep(3000);
    }

    [Test]
    public void PracticeFormTest2()
    {
        PracticeFormPage.FillInFormFields("Radu", "Fifiita", "test@test.com", Gender.Male, "00010305", "1992", "April", "16",
            new List<string>() { "English", "Accounting", "Physics" }, new List<Hobby>() { Hobby.Music, Hobby.Reading }, "Test Address 123, &*()");

        Thread.Sleep(3000);
    }
}
