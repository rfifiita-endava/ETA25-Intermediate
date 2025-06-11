using ETA25_Intermediate.Session11.Enums;
using ETA25_Intermediate.Session11.HelperMethods;
using ETA25_Intermediate.Session11.Models;
using ETA25_Intermediate.Session11.Pages;
using ETA25_Intermediate.Session11.TestDataProviders;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ETA25_Intermediate.Session11;

public class PracticeFormTestsWithData : BaseTest
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

    [TestCase("Radu", "Fifiita", "test@test.com", Gender.Male, "00010305", "1992", "April", "16", "Test Address 123, &*()")]
    public void PracticeFormTestWithParams(
        string firstName, 
        string lastName,
        string email,
        Gender gender, 
        string mobileNumber, 
        string dateOfBirthYear, 
        string dateOfBirthMonth,
        string dateOfBirthDay,
        string address)
    {
        var subjectsList = new List<string>() { "English", "Accounting", "Physics" };
        var hobbiesList = new List<Hobby>() { Hobby.Music, Hobby.Reading };

        PracticeFormPage.FillInFormFields(firstName, lastName, email, gender, mobileNumber, dateOfBirthYear, dateOfBirthMonth, dateOfBirthDay,
            subjectsList, hobbiesList, address);

        Thread.Sleep(3000);
    }


    #region Data from JSON
    [Test, TestCaseSource(typeof(UserDataProvider), nameof(UserDataProvider.UserDataFromJson))]
    public void PracticeFormTestWithJsonData(UserModel user)
    {
        PracticeFormPage.FillInFormFields(
            user.FirstName,
            user.LastName,
            user.Email,
            user.Gender,
            user.Mobile.ToString(),
            user.DateOfBirth.Year.ToString(),
            user.DateOfBirth.Month.ToString(),
            user.DateOfBirth.Day.ToString(),
            user.Subjects!,
            user.Hobbies!,
            user.Address);

        Thread.Sleep(3000);
    }

    [Test, TestCaseSource(typeof(UserDataProvider), nameof(UserDataProvider.UserDataFromXlsx))]
    public void PracticeFormTestWithXlsxData(UserModel user)
    {
        PracticeFormPage.FillInFormFields(
            user.FirstName,
            user.LastName,
            user.Email,
            user.Gender,
            user.Mobile.ToString(),
            user.DateOfBirth.Year.ToString(),
            user.DateOfBirth.Month.ToString(),
            user.DateOfBirth.Day.ToString(),
            user.Subjects!,
            user.Hobbies!,
            user.Address);

        Thread.Sleep(3000);
    }
    #endregion
}
