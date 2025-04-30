using ETA25_Intermediate.Session05.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ETA25_Intermediate.Session05.Pages;
public class PracticeFormPage
{
    private readonly IWebDriver _driver;

    public PracticeFormPage(IWebDriver driver)
    {
        _driver = driver;
    }

    // WebElements
    public IWebElement FirstNameInput => _driver.FindElement(By.Id("firstName"));
    public IWebElement LastNameInput => _driver.FindElement(By.Id("lastName"));
    public IWebElement EmailInput => _driver.FindElement(By.Id("userEmail"));
    public IWebElement MobileInput => _driver.FindElement(By.Id("userNumber"));
    public IWebElement DateOfBirthInput => _driver.FindElement(By.Id("dateOfBirthInput"));
    public IWebElement CurrentAddressInput => _driver.FindElement(By.Id("currentAddress"));

    public void SelectGender(Gender gender)
    {
        switch (gender)
        {
            case Gender.Male:
                GetGenderElement(1).Click();
                break;
            case Gender.Female:
                GetGenderElement(2).Click();
                break;
            case Gender.Other:
                GetGenderElement(3).Click();
                break;
            default:
                break;
        }
    }

    public void SetDateOfBirth(string currentYear, string currentMonthName, string currentMonthDay)
    {
        // Identificam si initializam dateOfBirth input
        IWebElement dateOfBirthInput = _driver.FindElement(By.Id("dateOfBirthInput"));

        // Deschidem calendarul
        dateOfBirthInput.Click();

        // Initializam un Select element pentru year dropown
        IWebElement yearDropdownWe = _driver.FindElement(By.XPath("//select[contains(@class, \"year-select\")]"));
        var yearDropdown = new SelectElement(yearDropdownWe);

        // Selectam luna
        yearDropdown.SelectByValue(currentYear);

        // Initializam un Select element pentru month dropown
        IWebElement monthDropdownWe = _driver.FindElement(By.XPath("//select[contains(@class, \"month-select\")]"));
        var monthDropdown = new SelectElement(monthDropdownWe);

        // Selectam luna
        monthDropdown.SelectByText(currentMonthName);

        // Selectam ziua
        IWebElement dayOfCurrentMonth = _driver.FindElement(By.XPath($"//div[text()=\"{currentMonthDay}\" and not(contains(@class, \"--outside-month\"))]"));
        dayOfCurrentMonth.Click();
    }

    public void SelectSubjects(List<string> subjects)
    {
        var subjectInput = _driver.FindElement(By.Id("subjectsInput"));
        foreach(var subject in subjects)
        {
            subjectInput.SendKeys(subject);
            subjectInput.SendKeys(Keys.Enter);
        }
       
    }

    public void SelectHobbies(List<Hobby> hobbies)
    {
        foreach (Hobby hobby in hobbies)
        {
            switch (hobby)
            {
                case Hobby.Sports:
                    GetHobbyElement(1).Click();
                    break;
                case Hobby.Reading:
                    GetHobbyElement(2).Click();
                    break;
                case Hobby.Music:
                    GetHobbyElement(3).Click();
                    break;
                default:
                    break;
            }
        }

    }

    public void FillInFormFields(string firstName, string lastName, string email, Gender gender, string mobileNumber,
        string dateOfBirthYear, string dateOfBirthMonthName, string dateOfBirthDay, List<string> subjects, List<Hobby> hobbies, string address)
    {
        FirstNameInput.SendKeys(firstName);
        LastNameInput.SendKeys(lastName);
        EmailInput.SendKeys(email);
        SelectGender(gender);
        MobileInput.SendKeys(mobileNumber);
        SetDateOfBirth(dateOfBirthYear, dateOfBirthMonthName, dateOfBirthDay);
        SelectSubjects(subjects);
        SelectHobbies(hobbies);
        CurrentAddressInput.SendKeys(address);
    }

    // Private Methods
    private IWebElement GetGenderElement(int index)
    {
        if (index < 1 || index > 3)
        {
            throw new ArgumentException("The index value is outside of valid range [1-3].");
        }
        return _driver.FindElement(By.XPath($"//label[@for=\"gender-radio-{index}\"]"));
    }

    private IWebElement GetHobbyElement(int index)
    {
        if (index < 1 || index > 3)
        {
            throw new ArgumentException("The index value is outside of valid range [1-3].");
        }
        return _driver.FindElement(By.XPath($"//label[@for=\"hobbies-checkbox-{index}\"]"));
    }
}
