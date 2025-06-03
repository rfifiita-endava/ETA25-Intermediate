﻿using ETA25_Intermediate.Session10.Enums;
using ETA25_Intermediate.Session10.Interfaces;

namespace ETA25_Intermediate.Session10.Drivers;

public static class BrowserFactory
{
    public static IBrowser GetBrowser(DriverType driverType)
    {
        // Driver initialization
        switch (driverType)
        {
            case DriverType.Chrome:
                return new ChromeBrowser();
            case DriverType.Edge:
                return new EdgeBrowser();
            case DriverType.Firefox:
                return new FirefoxBrowser();
            default:
                throw new ArgumentException("Invalid type of browser!", nameof(driverType));

        }
    }
}
