using ETA25_Intermediate.Session11.Models;
using Newtonsoft.Json;
using NPOI.XSSF.UserModel;
using NUnit.Framework;

namespace ETA25_Intermediate.Session11.TestDataProviders;

[TestFixture]
public static class UserDataProvider
{
    public static IEnumerable<TestCaseData> UserDataFromJson()
    {
        var filePath = Path.Combine("Session11", "Data", "UserData.json");
        var json = File.ReadAllText(filePath);

        var userList = JsonConvert.DeserializeObject<List<UserModel>>(json)!;

        //foreach (var user in userList)
        //{
        //    yield return new TestCaseData(user)
        //        .SetName($"FillFormWithJsonData_{user.FirstName}_{user.LastName}");
        //}
        return userList.Select(user => new TestCaseData(user)
                .SetName($"Fill_Form_With_Json_Data_{userList.IndexOf(user)}_{user.FirstName}_{user.LastName}"));
    }

    public static IEnumerable<TestCaseData> UserDataFromXlsx()
    {
        var filePath = Path.Combine("Session11", "Data", "UserData.xlsx");
        using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        var workbook = new XSSFWorkbook(fileStream);
        var excelSheet = workbook.GetSheetAt(0);

        // Output user list
        var userList = new List<UserModel>();

        for (int i = 1; i <= excelSheet.LastRowNum; i++)
        {
            var row = excelSheet.GetRow(i);
            if (row == null) continue;

            var hasGender = Enum.TryParse(typeof(Enums.Gender), row.GetCell(3).ToString()!, out object? userGender);
            var hasMobile = int.TryParse(row.GetCell(4).ToString()!, out int mobile);
            var hasDateOfBirth = DateOnly.TryParse(row.GetCell(5).ToString()!, out DateOnly dateOfBirth);
            var subjects = new List<string>(row.GetCell(6).ToString()!.Split(", "));

            var hobbiesStringList = new List<string>(row.GetCell(7).ToString()!.Split(", "));
            var hobbies = hobbiesStringList.Select(hobby => (Enums.Hobby)Enum.Parse(typeof(Enums.Hobby), hobby)).ToList();


            var userModel = new UserModel
            {
                FirstName = row.GetCell(0).ToString()!,
                LastName = row.GetCell(1).ToString()!,
                Email = row.GetCell(2).ToString()!,
                Gender = hasGender is true ? (Enums.Gender) userGender! : Enums.Gender.Male,
                Mobile = hasMobile is true ? mobile : 1234567890,
                DateOfBirth = hasDateOfBirth is true ? dateOfBirth : DateOnly.MinValue,
                Subjects = subjects,
                Hobbies = hobbies,
                Address = row.GetCell(8).ToString()!,
            };

            userList.Add(userModel);
        }

        return userList.Select(user => new TestCaseData(user)
                .SetName($"Fill_Form_With_Xlsx_Data_{userList.IndexOf(user)}_{user.FirstName}_{user.LastName}"));
    }
}
