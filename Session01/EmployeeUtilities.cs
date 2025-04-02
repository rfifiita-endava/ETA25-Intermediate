using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETA25_Intermediate.Session01;
public static class EmployeeUtilities
{
    public static int CalculateSeniorityInYears(DateTime joinDate)
    {
        return DateTime.UtcNow.Year - joinDate.Year;
    }
}
