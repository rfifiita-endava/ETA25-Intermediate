using OpenQA.Selenium;

namespace ETA25_Intermediate.Session10.Interfaces;

public interface IBrowser
{
    IWebDriver CreateDriver();
}
